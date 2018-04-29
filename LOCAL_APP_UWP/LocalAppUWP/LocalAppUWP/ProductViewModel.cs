using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalAppUWP.ProductServiceReference;
using System.Collections.ObjectModel;
namespace LocalAppUWP
{
    public class ProductViewModel
    {
        private ObservableCollection<ProductDTO> products = new ObservableCollection<ProductDTO>();
        public ObservableCollection<ProductDTO> Products { get { return this.products; } }
        public ProductViewModel()
        {
            populateProducts();
            
        }
        async void populateProducts()
        {
            ProductServiceClient client
                            = new ProductServiceClient();
            ObservableCollection<ProductDTO> tmp = await client.getProductsAsync();
            foreach (ProductDTO p in products)
            {
                this.products.Add(p);
            }
        }
    }
}
