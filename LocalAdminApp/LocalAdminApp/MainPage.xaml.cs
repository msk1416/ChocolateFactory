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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async Task RefreshPendingOrders_Click(object sender, RoutedEventArgs e)
        {

            //Task<ObservableCollection<PendingOrderDTO>> pendingOrders = client.getPendingOrdersAsync();
           
            try
            {
                // PendingOrdersListView.Items.Add(pendingOrders.Result);
                
                ObservableCollection<PendingOrderDTO> pendingOrdersContainer = await client.getPendingOrdersAsync();
                
                
                foreach (var newValue in pendingOrdersContainer)
                    PendingOrdersListView.Items.Add(newValue);

            }
            catch (Exception exception)
            {

                throw;
            }

        }
    }
}
