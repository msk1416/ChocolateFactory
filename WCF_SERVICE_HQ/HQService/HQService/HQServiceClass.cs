using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HQService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class HQServiceClass : IHQService
    {
        public int acceptStockRequest(int orderId)
        {
            using (var ctx = new ChocolateCoHQEntities1())
            {
                UkBranchServiceReference.ProductServiceClient client = 
                                new UkBranchServiceReference.ProductServiceClient();
                PendingStockOrders pso = ctx.PendingStockOrders.Find(orderId);
                bool ret = client.deliverStock(pso.ProductID, pso.QuantityAsked);
                client.Close();
                if (ret)
                {
                    ProductStock ps = ctx.ProductStock.Find(pso.ProductID);
                    ps.quantity = ps.quantity - pso.QuantityAsked;
                    StockOrdersLog sol = new StockOrdersLog();
                    sol.OrderId = orderId;
                    sol.ProductID = pso.ProductID;
                    sol.branch = pso.branch;
                    sol.Quantity = pso.QuantityAsked;
                    StockOrdersLog errSol = ctx.StockOrdersLog.Add(sol);

                    ctx.PendingStockOrders.Remove(pso);
                    int rowcount = ctx.SaveChanges();
                    return rowcount;
                } else
                {
                    return -1;
                }
            }
            
        }

        public bool dismissStockOrder(int orderId)
        {
            using (var ctx = new ChocolateCoHQEntities1())
            {
                PendingStockOrders pso = ctx.PendingStockOrders.Find(orderId);
                ctx.PendingStockOrders.Remove(pso);
                int ret = ctx.SaveChanges();
                return (ret > 0);
            }
        }

        public bool logLocalOrder(int orderId, int localClientId, int productId, string date, int quantity, int localShipperId, bool isAccepted, string justification)
        {
            using (var ctx = new ChocolateCoHQEntities1())
            {
                OrdersLog ol = new OrdersLog();
                ol.OrderID = orderId;
                ol.LocalClientID = localClientId;
                ol.ProductID = productId;
                ol.Date = DateTime.Parse(date);
                ol.Quantity = quantity;
                ol.LocalShipperID = localShipperId;
                ol.Accepted = (short)(isAccepted ? 1 : 0);
                ol.Justification = justification;
                ctx.OrdersLog.Add(ol);
                int ret = ctx.SaveChanges();
                return (ret > 0);
            }
        }

        public int requestStockHQ(int proposedOrderId, string branch, int productId, int quantityAsked)
        {
            using (var ctx = new ChocolateCoHQEntities1())
            {
                PendingStockOrders pso = new PendingStockOrders();
                pso.branch = branch;
                pso.ProductID = productId;
                pso.QuantityAsked = quantityAsked;
                int maxLoggedId = 0, maxPendingId = 0, maxStockLogId = 0;
                if (ctx.OrdersLog.Any())
                {
                    maxLoggedId = ctx.OrdersLog.Max(o => o.OrderID);
                }
                if (ctx.PendingStockOrders.Any())
                {
                    maxPendingId = ctx.PendingStockOrders.Max(o => o.OrderID);
                }
                if (ctx.StockOrdersLog.Any())
                {
                    maxStockLogId = ctx.StockOrdersLog.Max(o => o.OrderId);
                }
                int finalId = Math.Max(maxLoggedId, maxPendingId);
                finalId = Math.Max(finalId, maxStockLogId);
                finalId = Math.Max(finalId, proposedOrderId) + 1;
                pso.OrderID = finalId;
                ctx.PendingStockOrders.Add(pso);
                int ret = ctx.SaveChanges();
                if (ret > 0) return finalId;
                else return -1;
            }
        }

        public List<PendingStockOrderDTO> getPendingStockOrders()
        {
            List<PendingStockOrderDTO> list = new List<PendingStockOrderDTO>();
            using (var ctx = new ChocolateCoHQEntities1())
            {
                List<PendingStockOrders> psos = ctx.PendingStockOrders.ToList();
                foreach (PendingStockOrders pso in psos)
                {
                    list.Add(DTO(pso));
                }
                return list;
            }
        }

        public List<ProductStockDTO> getProductStocks()
        {
            List<ProductStockDTO> list = new List<ProductStockDTO>();
            using (var ctx = new ChocolateCoHQEntities1())
            {
                List<ProductStock> pslist = ctx.ProductStock.ToList();
                foreach (ProductStock ps in pslist)
                {
                    list.Add(DTO(ps));
                }
                return list;
            }
        }


        public List<BranchDTO> getBranches()
        {
            List<BranchDTO> list = new List<BranchDTO>();
            using (var ctx = new ChocolateCoHQEntities1())
            {
                List<Branches> brlist = ctx.Branches.ToList();
                foreach (Branches br in brlist)
                {
                    list.Add(DTO(br));
                }
                return list;
            }
        }

        

        public List<OrdersLogDTO> getOrdersLogs()
        {
            List<OrdersLogDTO> list = new List<OrdersLogDTO>();
            using (var ctx = new ChocolateCoHQEntities1())
            {
                List<OrdersLog> ologlist = ctx.OrdersLog.ToList();
                foreach (OrdersLog olog in ologlist)
                {
                    list.Add(DTO(olog));
                }
                return list;
            }
        }


        public List<StockOrderLogDTO> getStockOrderLogs()
        {
            List<StockOrderLogDTO> list = new List<StockOrderLogDTO>();
            using (var ctx = new ChocolateCoHQEntities1())
            {
                List<StockOrdersLog> sologlist = ctx.StockOrdersLog.ToList();
                foreach (StockOrdersLog sol in sologlist)
                {
                    list.Add(DTO(sol));
                }
                return list;
            }
        }

        private OrdersLogDTO DTO(OrdersLog olog)
        {
            OrdersLogDTO ret = new OrdersLogDTO();
            ret.Accepted = olog.Accepted;
            ret.Date = olog.Date;
            ret.LocalClientID = olog.LocalClientID;
            ret.LocalShipperID = olog.LocalShipperID;
            ret.OrderID = olog.OrderID;
            ret.ProductID = olog.ProductID;
            ret.Quantity = olog.Quantity;
            return ret;
        }

        private BranchDTO DTO(Branches br)
        {
            BranchDTO ret = new BranchDTO();
            ret.location = br.location;
            ret.name = br.name;
            return ret;
        }

        private StockOrderLogDTO DTO(StockOrdersLog sol)
        {
            StockOrderLogDTO ret = new StockOrderLogDTO();
            ret.branch = sol.branch;
            ret.OrderId = sol.OrderId;
            ret.ProductID = sol.ProductID;
            ret.Quantity = sol.Quantity;
            return ret;
        }

        private ProductStockDTO DTO(ProductStock ps)
        {
            ProductStockDTO ret = new ProductStockDTO();
            ret.ProductID = ps.ProductID;
            ret.ProductName = ps.ProductName;
            ret.ProductType = ps.ProductType;
            ret.quantity = ps.quantity;
            return ret;
        }

        private PendingStockOrderDTO DTO(PendingStockOrders pso)
        {
            PendingStockOrderDTO ret = new PendingStockOrderDTO();
            ret.branch = pso.branch;
            ret.OrderID = pso.OrderID;
            ret.ProductID = pso.ProductID;
            ret.QuantityAsked = pso.QuantityAsked;
            return ret;
        }

        public void updateBranchStock(List<int> productsStock)
        {
            using (ChocolateCoHQEntities1 ctx = new ChocolateCoHQEntities1())
            {
                for (int i = 0; i < productsStock.Count; i += 2)
                {
                    var p = ctx.ProductStock.Find(productsStock.ElementAt(i));
                    p.quantity_uk = productsStock.ElementAt(i + 1);
                }
                ctx.SaveChanges();
            }
        }
    }
}
