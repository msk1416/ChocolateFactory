using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProductService
{   
    [DataContract]
    public class OrderDTO
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
        [DataMember]
        public int ShipperID { get; set; }
        [DataMember]
        public int Accepted { get; set; }
        [DataMember]
        public string Justification { get; set; }
    }
    [DataContract]
    public class PendingOrderDTO
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
        [DataMember]
        public int ShipperID { get; set; }

    }

    [DataContract]
    public class ClientDTO
    {
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PreferedFormat { get; set; }
    }

    [DataContract]
    public class ProductDTO
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public int Cost { get; set; }
    }

    [DataContract]
    public class ShipperDTO
    {
        [DataMember]
        public int ShipperID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public int CostPerTon { get; set; }
    }
}
