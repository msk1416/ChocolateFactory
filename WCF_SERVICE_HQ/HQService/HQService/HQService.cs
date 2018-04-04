using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HQService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class HQService : IHQService
    {
        public bool CheckInsertIsDone(int _id, string _name, string _type, int _quant, int _price, int _cost)
        {
            ProductEntity new_p = new ProductEntity();
            new_p.ProductID = _id;
            new_p.Name = _name;
            new_p.Type = _type;
            new_p.Quantity = _quant;
            new_p.Price = _price;
            new_p.Cost = _cost;
            using (var ctx = new ChocolateCoHQEntities())
            {
                var res = ctx.ProductEntities.Add(new_p);
                ctx.SaveChanges();
                return (res != null);
            }
        }

        public bool CheckUpdateProductIsDone(int _id, int new_quant, int new_price, int new_cost)
        {

            using (var ctx = new ChocolateCoHQEntities())
            {
                var productToUpdate = (from p
                                    in ctx.ProductEntities
                                     where p.ProductID == _id
                                     select p).FirstOrDefault();
                if (new_quant >= 0) productToUpdate.Quantity = new_quant;
                if (new_price >= 0) productToUpdate.Price = new_price;
                if (new_cost >= 0) productToUpdate.Cost = new_cost;
                var res = ctx.SaveChanges();
                return (res > 0);
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
