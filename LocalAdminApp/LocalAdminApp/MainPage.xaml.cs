using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LocalAdminApp.ProductServiceReference;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LocalAdminApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ProductServiceClient client = new ProductServiceClient();
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductServiceClient client
                = new ProductServiceClient();
            var pendingOrders = await client.getPendingOrdersAsync();
            List<int> pendingOrdersIdList = new List<int>();
            foreach (PendingOrderDTO po in pendingOrders)
            {
                pendingOrdersIdList.Add(po.OrderID);
            }
            try
            {
                await client.acceptOrderAsync(PendingOrdersListView.SelectedIndex);
                PendingOrdersTextBox.Text = "Pending order " + pendingOrdersIdList[PendingOrdersListView.SelectedIndex] + " accepted.";
            }
            catch (Exception exception)
            {
                PendingOrdersTextBox.Text = "Pending order " + pendingOrdersIdList[PendingOrdersListView.SelectedIndex] + "not accepted." + exception;
            }


            await client.CloseAsync();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private async void RefreshPendingOrders_Click(object sender, RoutedEventArgs e)
        {

            PendingOrdersListView.Items.Clear();
            ProductServiceClient client
                = new ProductServiceClient();
            var pendingOrders = await client.getPendingOrdersAsync();
            var products = await client.getProductsAsync();
            var clients = await client.getClientsAsync();
            List<string> productsList = new List<string>();
            List<string> clientsList = new List<string>();
            foreach (ProductDTO pr in products)
            {
                productsList.Add(pr.ProductName);
            }

            foreach (ClientDTO c in clients)
            {
                clientsList.Add(c.Name);
            }

            var prodArray = productsList.ToArray();
            foreach (PendingOrderDTO p in pendingOrders)
            {
                PendingOrdersListView.Items.Add(p.OrderID + " Client " + clientsList[p.ProductID] + " product " + productsList[p.ProductID] + " quantity " + p.Quantity);
            }
            await client.CloseAsync();

        }
    }
}
