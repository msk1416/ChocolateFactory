using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HQService
{
    [DataContract]
    public class ProductStockDTO
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductType { get; set; }
        [DataMember]
        public int quantity { get; set; }
    }

    [DataContract]
    public class PendingStockOrderDTO
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public string branch { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int QuantityAsked { get; set; }
    }

    [DataContract]
    public class OrdersLogDTO
    {
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int LocalClientID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int LocalShipperID { get; set; }
        [DataMember]
        public short Accepted { get; set; }
    }

    [DataContract]
    public class BranchDTO
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string location { get; set; }
    }

    [DataContract]
    public class StockOrderLogDTO
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public string branch { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
