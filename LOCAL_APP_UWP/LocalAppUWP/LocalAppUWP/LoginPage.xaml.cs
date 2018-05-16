using LocalAppUWP.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LocalAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        ObservableCollection<ClientDTO> clients = new ObservableCollection<ClientDTO>();
        int selectedClientId;
        public LoginPage()
        {
            this.InitializeComponent();
            populateClientsList();
        }

        private async void populateClientsList()
        {
            ProductServiceClient client
                = new ProductServiceClient();
            clients = await client.getClientsAsync();
            foreach (ClientDTO c in clients)
            {
                clientsListView.Items.Add(c.ClientID + " - " + c.Name.Trim() + " (" + c.City.Trim() + ")");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (clientsListView.SelectedIndex >= 0)
                this.Frame.Navigate(typeof(RequestPage), findClientById(selectedClientId));
        }

        private void clientsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectedClientId = Int32.Parse(e.ClickedItem.ToString().Split(' ')[0]);
        }

        private ClientDTO findClientById(int id)
        {
            foreach (ClientDTO c in clients)
            {
                if (c.ClientID == id)
                    return c;
            }
            return null;
        }
    }
}
