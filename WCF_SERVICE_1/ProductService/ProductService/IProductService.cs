using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProductService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product GetProduct(int p_id);

        [OperationContract]
        [WebGet(UriTemplate = "/Products", ResponseFormat = WebMessageFormat.Xml)]
        Product[] GetProducts();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/InsertProduct",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        Boolean newProduct(int _id, string _name, string _type, int _quant, int _price, int _cost);

        [OperationContract]
        bool updateProduct(int _id, int _quant, int _price, int _cost);
        
    }

    public class Chocolate
    {
        [DataMember]
        public int ChocId { get; set; }

        [DataMember]
        public string ChocName { get; set; }

        [DataMember]
        public string ChocType { get; set; }

        [DataMember]
        public int ChocQuant { get; set; }

        [DataMember]
        public int ChocPrice { get; set; }

        [DataMember]
        public int ChocCost { get; set; }
    }

    //[DataContract]
    //public class Employee
    //{
    //    [DataMember]
    //    public int EmpNo { get; set; }

    //    [DataMember]
    //    public string EmpName { get; set; }

    //    [DataMember]
    //    public string DeptName { get; set; }
    //}

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public int Cost { get; set; }
    }
}
