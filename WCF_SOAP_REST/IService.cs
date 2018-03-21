using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_SOAP_REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        [WebGet(UriTemplate = "/Employees", ResponseFormat = WebMessageFormat.Xml)]
        Employee[] GetEmployees();

        // TODO: Add your service operations here
        [OperationContract]
        [WebGet(UriTemplate = "/Chocolates", ResponseFormat = WebMessageFormat.Xml)]
        Chocolate[] GetChocolates();

        // TODO: Add your service operations here
        [OperationContract]
        [WebInvoke(Method = "POST", 
            UriTemplate = "/InsertChocolate", 
            ResponseFormat = WebMessageFormat.Xml, 
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        Boolean newChocolate(string name);
    }

    public class Chocolate
    {
        [DataMember]
        public string ChocName { get; set; }

        [DataMember]
        public int ChocId { get; set; }

        [DataMember]
        public int ChocQuant { get; set; }
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpNo { get; set; }

        [DataMember]
        public string EmpName { get; set; }

        [DataMember]
        public string DeptName { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
