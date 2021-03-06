//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public System.DateTime Date { get; set; }
        public int ShipperID { get; set; }
        public byte Accepted { get; set; }
        public string Justification { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Shipper Shipper1 { get; set; }
    }
}
