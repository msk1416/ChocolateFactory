using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpdateService.HQServiceReference;
using UpdateService.ProductServiceReference;
using System.Runtime.InteropServices;
namespace UpdateService
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServiceClient prodcli =
                new ProductServiceClient();
            HQServiceClient hqcli =
                new HQServiceClient();
            List<int> productStocks = new List<int>();
            foreach (ProductDTO p in prodcli.getProducts())
            {
                productStocks.Add(p.ProductID);
                productStocks.Add(p.Quantity);
            }
            hqcli.updateBranchStock(productStocks.ToArray());
        }
    }
}
