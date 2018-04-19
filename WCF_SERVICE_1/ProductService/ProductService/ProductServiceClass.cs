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

        public bool dismissOrder(int orderId)
        {
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                PendingOrder po = ctx.PendingOrders.Find(orderId);
                HQServiceReference.HQServiceClient client =
                    new HQServiceReference.HQServiceClient();
                bool logRet =
                    client.logLocalOrder(po.OrderID, po.ClientID, po.ProductID, po.Date.ToShortDateString(), po.Quantity, po.ShipperID, false);
                return logRet;
            }
        }



        private OrderDTO DTO(Order o)
        {
            OrderDTO ret = new OrderDTO();
            ret.ClientID = o.ClientID;
            ret.Date = o.Date;
            ret.OrderID = o.OrderID;
            ret.ProductID = o.ProductID;
            ret.Quantity = o.Quantity;
            ret.ShipperID = o.ShipperID;
            return ret;
        }

        private PendingOrderDTO DTO(PendingOrder po)
        {
            PendingOrderDTO ret = new PendingOrderDTO();
            ret.ClientID = po.ClientID;
            ret.Date = po.Date;
            ret.OrderID = po.OrderID;
            ret.ProductID = po.ProductID;
            ret.Quantity = po.Quantity;
            ret.ShipperID = po.ShipperID;
            return ret;
        }

        private ClientDTO DTO(Client c)
        {
            ClientDTO ret = new ClientDTO();
            ret.City = c.City;
            ret.ClientID = c.ClientID;
            ret.Name = c.Name;
            ret.PreferedFormat = c.PreferedFormat;
            return ret;
        }

        private ProductDTO DTO(Product p)
        {
            ProductDTO ret = new ProductDTO();
            ret.Cost = p.Cost;
            ret.Price = p.Price;
            ret.ProductID = p.ProductID;
            ret.ProductName = p.ProductName;
            ret.Quantity = p.Quantity;
            ret.Type = p.Type;
            return ret;
        }

        private ShipperDTO DTO(Shipper s)
        {
            ShipperDTO ret = new ShipperDTO();
            ret.City = s.City;
            ret.CostPerTon = s.CostPerTon;
            ret.Name = s.Name;
            ret.ShipperID = s.ShipperID;
            return ret;
        }

        public List<OrderDTO> getOrders()
        {
            List<OrderDTO> list = new List<OrderDTO>();
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                List<Order> orders = ctx.Orders.ToList();
                foreach (Order o in orders) {
                    list.Add(DTO(o));
                }
                return list;
            }
        }

        public List<PendingOrderDTO> getPendingOrders()
        {
            List<PendingOrderDTO> list = new List<PendingOrderDTO>();
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                List<PendingOrder> orders = ctx.PendingOrders.ToList();
                foreach (PendingOrder po in orders)
                {
                    list.Add(DTO(po));
                }
                return list;
            }
        }

        public List<ClientDTO> getClients()
        {
            List<ClientDTO> list = new List<ClientDTO>();
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                List<Client> clients = ctx.Clients.ToList();
                foreach (Client c in clients)
                {
                    list.Add(DTO(c));
                }
                return list;
            }
        }

        public List<ProductDTO> getProducts()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                List<Product> products = ctx.Products.ToList();
                foreach (Product p in products)
                {
                    list.Add(DTO(p));
                }
                return list;
            }
        }

        public List<ShipperDTO> getShippers()
        {
            List<ShipperDTO> list = new List<ShipperDTO>();
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                List<Shipper> shippers = ctx.Shippers.ToList();
                foreach (Shipper s in shippers)
                {
                    list.Add(DTO(s));
                }
                return list;
            }
        }
    }
}
