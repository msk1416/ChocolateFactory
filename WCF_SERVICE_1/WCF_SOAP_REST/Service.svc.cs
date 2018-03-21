using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using System.Data.SqlClient;
using System.Data;

namespace WCF_SOAP_REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Required)]
    public class Service : IService
    {
        public Employee[] GetEmployees()
        {
            return new Employee[]
            {
                new Employee () {EmpNo=101, EmpName="Jonah", DeptName="CTD"},
                new Employee () {EmpNo=102, EmpName="Dylan", DeptName="IT"},
                new Employee () {EmpNo=103, EmpName="Mike", DeptName="IT"},
                new Employee () {EmpNo=104, EmpName="Jenn", DeptName="SLS"},
                new Employee () {EmpNo=105, EmpName="Esther", DeptName="HR"}
            };
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Chocolate[] GetChocolates()
        {
            //TODO: connect to database and retrieve chocolates
            string connectionString = null;
            connectionString = "Data Source=localhost;Initial Catalog=ChocolateCo.;User ID=sergi;Password=admin";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            Chocolate[] ret = null;
            List<Chocolate> list = new List<Chocolate>();
            try
            {
                Console.Out.WriteLine("Connection Opened!");
                SqlCommand cmd = new SqlCommand("select * from dbo.Products;  ", cnn);
                SqlDataReader reader;
                DataRow row;
                DataTable table = new DataTable();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();
                
                reader = cmd.ExecuteReader();
                
                for (int i =0; i < reader.FieldCount; i++)
                {
                    table.Columns.Add(new DataColumn(i.ToString()));
                }
                // Data is accessible through the DataReader object here.
                while (reader.Read())
                {
                    row = table.NewRow();
                    row.ItemArray = new object[reader.FieldCount-1];

                    Chocolate c = new Chocolate();
                    c.ChocId = (int)reader.GetInt32(0);
                    c.ChocName = reader.GetString(1);
                    c.ChocType = reader.GetString(2);
                    c.ChocQuant = (int)reader.GetInt32(3);
                    c.ChocPrice = (int)reader.GetInt32(4);
                    c.ChocCost = (int)reader.GetInt32(5);
                    list.Add(c);
                }
                cnn.Close();
            } catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.Out.WriteLine("Connection COULD NOT be opened.");
            }
            return list.ToArray();
        }
      
        public bool newChocolate(string name, string type, int quant, int price, int cost)
        {
            string connectionString = null;
            connectionString = "Data Source=localhost;Initial Catalog=ChocolateCo.;User ID=sergi;Password=admin";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);

            try
            {
                string sqlQuery = "insert into dbo.Products (" +
                    "Name, " +
                    "Type, " +
                    "Quantity, " +
                    "Price, " +
                    "Cost" +
                    ") values('" + name + "', '" + type + "', " + quant + ", " + price + ", " + cost + ");";
                Console.Out.WriteLine("Connection Opened!");
                SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();
                reader = cmd.ExecuteReader();
                return (reader.RecordsAffected > 0);
            } catch (Exception e)
            {
                Console.WriteLine("Connection failed to open or the product could not be inserted.");
                return false;
            }
        }
        
    }
}
