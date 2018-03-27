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
    public class ProductService : IProductService
    {
        public Product GetProduct(int p_id)
        {
            ChocolateCoEntities context = new ChocolateCoEntities();
            var productEntity = (from p
                                 in context.ProductEntities
                                 where p.ProductID == p_id
                                 select p).FirstOrDefault();
            if (productEntity != null)
            {
                return TranslateProductEntityToProduct(productEntity);
            } else
            {
                throw new Exception("Invalid product id.");
            }
            
        }
        private Product TranslateProductEntityToProduct(
              ProductEntity productEntity)
        {
            Product product = new Product();
            product.ID = productEntity.ProductID;
            product.Name = productEntity.Name.Trim();
            product.Type = productEntity.Type.Trim();
            product.Quantity = productEntity.Quantity;
            product.Price = productEntity.Price;
            product.Cost = productEntity.Cost;
            return product;
        }

        public Product[] GetProducts()
        {
            using (var ctx = new ChocolateCoEntities())
            {
                var productEntities = (from p
                                        in ctx.ProductEntities
                                        select p);
                ProductEntity[] arr = productEntities.ToArray();
                Product[] ret = new Product[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    ret[i] = TranslateProductEntityToProduct(arr[i]);
                }
                return ret;
            }
                
        }

        public bool newProduct(string _name, string _type, int _quant, int _price, int _cost)
        {
            ProductEntity new_p = new ProductEntity();
            new_p.Name = _name;
            new_p.Type = _type;
            new_p.Quantity = _quant;
            new_p.Price = _price;
            new_p.Cost = _cost;
            using (var ctx = new ChocolateCoEntities())
            {
                var res = ctx.ProductEntities.Add(new_p);
                ctx.SaveChanges();
                return (res != null);
            }
        }
    }
}
