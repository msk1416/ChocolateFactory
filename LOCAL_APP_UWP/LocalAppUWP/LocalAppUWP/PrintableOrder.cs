using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalAppUWP.ProductServiceReference;
namespace LocalAppUWP
{
    class PrintableOrder
    {
        
        public int orderId { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public string date { get; set; }
        public string shipper { get; set; }
        public string status { get; set; }
        public string justification { get; set; }

        public PrintableOrder(OrderDTO o, string prodName, string shipperName)
        {
            status = o.Accepted == 1 ? "Accepted" : "Dismissed";
            justification = o.Accepted == 1 ? "" : o.Justification;
            this.orderId = o.OrderID;
            this.product = prodName;
            this.quantity = o.Quantity;
            this.date = o.Date.ToString("dd/MM/yyy");
            this.shipper = shipperName;
        }

        public PrintableOrder(PendingOrderDTO po, string prodName, string shipperName)
        {
            status = "Pending";
            justification = "";
            this.orderId = po.OrderID;
            this.product = prodName;
            this.quantity = po.Quantity;
            this.date = po.Date.ToString("dd/MM/yyy");
            this.shipper = shipperName;
        }
    }
}
