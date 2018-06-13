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
using GlobalAdminApp.HQServiceReference;
using GlobalAdminApp.ProductServiceReference;

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
            pendingOrdersListView.Items.Clear();
            HQServiceClient clientHQ = new HQServiceClient();
            ProductServiceClient clientPS = new ProductServiceClient();
            //var pendingOrders = await client.getPendingOrdersAsync();
            var pendingStockOrders = await clientHQ.getPendingStockOrdersAsync();
            var products = await clientPS.getProductsAsync();

            List<string> productList = new List<string>();

            foreach (ProductDTO pr in products)
            {
                productList.Add(pr.ProductName);
            }


            var prodArray = pendingStockOrders.ToArray();
            foreach (PendingStockOrderDTO p in pendingStockOrders)
            {
                pendingOrdersListView.Items.Add("ID: " + p.OrderID + "     Product: " + productList[p.ProductID] + "    Quantity: " + p.QuantityAsked);
            }
            await clientHQ.CloseAsync();
            await clientPS.CloseAsync();
        }

        private async void AcceptStockRequestButton_Click(object sender, RoutedEventArgs e)
        {
            HQServiceClient clientHQ = new HQServiceClient();
            var pendingStockOrders = await clientHQ.getPendingStockOrdersAsync();

            List<int>pendingStockOrdersIdList = new List<int>();

            foreach (PendingStockOrderDTO p in pendingStockOrders)
            {
                pendingStockOrdersIdList.Add(p.OrderID);              
            }

            try
            {
                await clientHQ.acceptStockRequestAsync(pendingStockOrdersIdList[pendingOrdersListView.SelectedIndex]);
                PendingOrdersTextBlock2.Text = "Pending stock order " + pendingStockOrdersIdList[pendingOrdersListView.SelectedIndex] + " accepted";
            }
            catch (Exception exception)
            {
                PendingOrdersTextBlock2.Text = "Pending stock order " + pendingStockOrdersIdList[pendingOrdersListView.SelectedIndex] + " not accepted";
            }
            await clientHQ.CloseAsync();
        }

        private async void DismissStockRequestButton_Click(object sender, RoutedEventArgs e)
        {
            HQServiceClient clientHQ = new HQServiceClient();
            var pendingStockOrders = await clientHQ.getPendingStockOrdersAsync();

            List<int> pendingStockOrdersIdList = new List<int>();

            foreach (PendingStockOrderDTO p in pendingStockOrders)
            {
                pendingStockOrdersIdList.Add(p.OrderID);
            }

            try
            {
                await clientHQ.dismissStockOrderAsync(pendingStockOrdersIdList[pendingOrdersListView.SelectedIndex]);
                PendingOrdersTextBlock2.Text = "Pending Stock Order "+ pendingStockOrdersIdList[pendingOrdersListView.SelectedIndex] + " declined";
            }
            catch (Exception exception)
            {
                PendingOrdersTextBlock2.Text = "Pending Stock Order " + pendingStockOrdersIdList[pendingOrdersListView.SelectedIndex] + " not declined";
            }

            await clientHQ.CloseAsync();
        }

        private async void RefreshStockButton_Click(object sender, RoutedEventArgs e)
        {
            StockListView.Items.Clear();
            HQServiceClient clientHQ = new HQServiceClient();
            var ProductStock = await clientHQ.getProductStocksAsync();
            
            var prodArray = ProductStock.ToArray();
            foreach (ProductStockDTO p in ProductStock)
            {
                StockListView.Items.Add("ID: " + p.ProductID + "  Product name: " + p.ProductName + "  Type: " + p.ProductType + "  Quantity: " + p.quantity);
            }
            await clientHQ.CloseAsync();
        }

        
    }
}
