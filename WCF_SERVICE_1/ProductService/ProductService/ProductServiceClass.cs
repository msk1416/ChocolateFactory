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
        public Product GetProduct(int p_id)
        {
            /*ChocolateStoreUkEntities context = new ChocolateStoreUkEntities();
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
            }*/
            return new Product();
        }/*
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
        }*/

        public Product[] GetProducts()
        {/*
            using (var ctx = new ChocolateStoreUkEntities())
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
            }*/
            return null;
        }

        public bool newProduct(int _id, string _name, string _type, int _quant, int _price, int _cost)
        {
            /*HQServiceReference.HQServiceClient client = new HQServiceReference.HQServiceClient();
            if (client.CheckInsertIsDone(_id, _name, _type, _quant, _price, _cost))
            {
                ProductEntity new_p = new ProductEntity();
                new_p.ProductID = _id;
                new_p.Name = _name;
                new_p.Type = _type;
                new_p.Quantity = _quant;
                new_p.Price = _price;
                new_p.Cost = _cost;
                using (var ctx = new ChocolateStoreUkEntities())
                {
                    var res = ctx.ProductEntities.Add(new_p);
                    ctx.SaveChanges();
                    return (res != null);
                }
            } else
            {
                return false;
            }*/
            return false;
        }

        public bool updateProduct(int _id, int _quant, int _price, int _cost)
        {
            /*HQServiceReference.HQServiceClient client = new HQServiceReference.HQServiceClient();
            if (client.CheckUpdateProductIsDone(_id, _quant, _price, _cost))
            {
                using (var ctx = new ChocolateStoreUkEntities())
                {
                    var productToUpdate = (from p
                                        in ctx.ProductEntities
                                           where p.ProductID == _id
                                           select p).FirstOrDefault();
                    if (_quant >= 0) productToUpdate.Quantity = _quant;
                    if (_price >= 0) productToUpdate.Price = _price;
                    if (_cost >= 0)  productToUpdate.Cost = _cost;
                    var res = ctx.SaveChanges();
                    return (res > 0);
                }
            } else
            {
                return false;
            }*/
            return false;
        }

        public bool requestOrder(int clientId, int productId, int quantity, string date, int shipperId)
        {
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                var result = ctx.spCreatePendingOrder(clientId, productId, quantity, System.DateTime.Parse(date), shipperId);
                return (result > 0);
            }
        }

        public bool acceptOrder(int orderId)
        {
            using (var ctx = new ChocolateStoreUkEntities2())
            {
                var result = ctx.spConfirmPendingOrder(orderId);
                return (result > 0);
            }
        }
    }
}
