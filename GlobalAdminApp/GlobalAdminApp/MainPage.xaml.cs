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
using GlobalAdminApp.ServiceReference1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlobalAdminApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void RefreshOrders_Click(object sender, RoutedEventArgs e)
        {
            HQServiceClient client = new HQServiceClient();
            //var pendingOrders = await client.getPendingOrdersAsync();
            var pendingStockOrders = await client.getPendingStockOrdersAsync();
            var productList = await client.getProductStocksAsync();

            var prodArray = pendingStockOrders.ToArray();
            foreach (PendingStockOrderDTO p in pendingStockOrders)
            {
                pendingOrdersListView.Items.Add(p.OrderID + " " + p.ProductID + " " + p.QuantityAsked);
            }
            await client.CloseAsync();
        }

        private void AcceptStockRequestButton_Click(object sender, RoutedEventArgs e)
        {
            StockOrdersListView.Items.Add("123");

        }
    }
}
