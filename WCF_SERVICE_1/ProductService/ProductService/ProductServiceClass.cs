using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ProductServiceClass : IProductService
    {
        public int requestOrder(int clientId, int productId, int quantity, string date, int shipperId)
        {
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                var result = ctx.spCreatePendingOrder(clientId, productId, quantity, System.DateTime.Parse(date), shipperId);
                if (result > 0)
                {
                    var orderId = ctx.PendingOrders.Max(p => p.OrderID);
                    return orderId;
                } else return -1;
            }
        }

        public bool acceptOrder(int orderId)
        {
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                var result = ctx.spConfirmPendingOrder(orderId);
                if (result > 0)
                {
                    Order o = ctx.Orders.Find(orderId);
                    HQServiceReference.HQServiceClient client =
                        new HQServiceReference.HQServiceClient();
                    bool logRet =
                        client.logLocalOrder(o.OrderID, o.ClientID, o.ProductID, o.Date.ToShortDateString(), o.Quantity, o.ShipperID, true);
                    return logRet;
                } else
                {
                    return false;
                }
            }
        }

        public bool deliverStock(int productId, int quantity)
        {
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                Product p = ctx.Products.Find(productId);
                p.Quantity = p.Quantity + quantity;
                int ret = ctx.SaveChanges();
                return (ret > 0);
            }
        }

        //return new order id in hq table
        public int requestStockToHQ(int productId, int quantity)
        {
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                int proposedIdFromOrders = ctx.Orders.Max(p => p.OrderID);
                int proposedIdFromPending = ctx.PendingOrders.Max(p => p.OrderID);
                HQServiceReference.HQServiceClient client =
                    new HQServiceReference.HQServiceClient();
                int newId = client.requestStockHQ(Math.Max(proposedIdFromOrders, 
                                                proposedIdFromPending), 
                                                "uk", 
                                                productId, 
                                                quantity);
                return newId;
            }
        }
    }
}
