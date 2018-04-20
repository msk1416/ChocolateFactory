using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LocalAppUWP.ProductServiceReference;
using System.Collections.ObjectModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LocalAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        ObservableCollection<ProductDTO> products;
        public BlankPage1()
        {
            this.InitializeComponent();
            populateProductsList();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            populateProductsList();
        }

        private async void populateProductsList()
        {
            ProductServiceClient client
                = new ProductServiceClient();
            products = await client.getProductsAsync();
            productsList.ItemsSource = products;
        }

        
    }
}
