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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LocalAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RequestPage : Page
    {
        ObservableCollection<ProductDTO> products = new ObservableCollection<ProductDTO>();
        ObservableCollection<ClientDTO> clients = new ObservableCollection<ClientDTO>();
        ObservableCollection<ShipperDTO> shippers = new ObservableCollection<ShipperDTO>();
        String selectedProduct;
        String loggedClientName;
        int loggedClientId;
        String selectedShipper;
        int prevSelected = -1;
        int indexSelected = -1;
        private string defaultLblSuccessText = "Order request was a success, new ID is ---- . Feel free to request more products.";
        public RequestPage()
        {
            this.InitializeComponent();
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
            //populateClientsList();
            populateShippersList();
            programmedDate.MinDate = DateTime.Now;
            loggedClientName = ((ClientDTO)e.Parameter).Name;
            loggedClientId = ((ClientDTO)e.Parameter).ClientID;
            lblLoggedAs.Text = lblLoggedAs.Text.Replace("----", loggedClientName);
        }

        private async void populateProductsList()
        {
            ProductServiceClient client
                = new ProductServiceClient();
            products = await client.getProductsAsync();
            foreach (ProductDTO p in products)
            {
                productsListView.Items.Add("[" + p.ProductID + "] " + p.Type.Trim() + " " + p.ProductName.Trim());
            }
            client.CloseAsync();
        }
        /*
        private async void populateClientsList()
        {
            clientDropDown.IsEnabled = false;
            ProductServiceClient client
                = new ProductServiceClient();
            clients = await client.getClientsAsync();
            foreach (ClientDTO c in clients)
            {
                MenuFlyoutItem item = new MenuFlyoutItem();
                item.Text = "[" + c.ClientID + "] " + c.Name;
                item.Click += (s, e1) =>
                {
                    currentSelectedClientText.Visibility = Visibility.Visible;
                    currentSelectedClientPlaceholder.Text = item.Text;
                    currentSelectedClientPlaceholder.Visibility = Visibility.Visible;
                    loggedClientName = item.Text;
                };

                menuFlyoutClients.Items.Add(item);
            }
            clientDropDown.IsEnabled = true;
        }
        */
        private async void populateShippersList()
        {
            shippersDropDown.IsEnabled = false;
            ProductServiceClient client
                = new ProductServiceClient();
            shippers = await client.getShippersAsync();
            foreach (ShipperDTO sh in shippers)
            {
                MenuFlyoutItem item = new MenuFlyoutItem();
                item.Text = "[" + sh.ShipperID + "] " + sh.Name;
                item.Click += (s, e1) =>
                {
                    currentSelectedShipperText.Visibility = Visibility.Visible;
                    currentSelectedShipperPlaceholder.Text = item.Text;
                    currentSelectedShipperPlaceholder.Visibility = Visibility.Visible;
                    selectedShipper = item.Text;
                };

                menuFlyoutShippers.Items.Add(item);
            }
            shippersDropDown.IsEnabled = true;
        }
        /*
        private void onClientItemClick(object sender, EventArgs e)
        {
            currentSelectedClientText.Visibility = Visibility.Visible;
            currentSelectedClientPlaceholder.Text = e.ToString();
            currentSelectedClientPlaceholder.Visibility = Visibility.Visible;
        }
        */
        private void productsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (indexSelected == -1)
            {
                InitialText.Visibility = Visibility.Collapsed;
                selectedProduct = retrieveName(e.ClickedItem.ToString());
            }
            resetPage(generateTitle(retrieveName(e.ClickedItem.ToString())));

        }

        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void showAlertPopupAsync(String newProduct)
        {
            MessageDialog dialog = new MessageDialog("If you select a different product you will lose the current order state. Are you sure you want to select the new product?");
            dialog.Commands.Add(new UICommand("Yes", null));
            dialog.Commands.Add(new UICommand("No", null));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            var cmd = await dialog.ShowAsync();

            if (cmd.Label == "Yes")
            {
                prevSelected = indexSelected;
                selectedProduct = newProduct;
                resetPage(generateTitle(newProduct));
                
            } else if (cmd.Label == "No")
            {
                //return selection to previous state
                indexSelected = prevSelected;
                productsListView.SelectedIndex = indexSelected;
            }
        }

        private void clientDropDown_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void quantity_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (sender.Text.Length > 0 && !Char.IsDigit(sender.Text.Last()))
            {
                sender.Text = sender.Text.Substring(0, sender.Text.Length - 1);
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void programDateRB_Unchecked(object sender, RoutedEventArgs e)
        {
            programmedDate.IsEnabled = false;
        }

        private void programDateRB_Checked(object sender, RoutedEventArgs e)
        {
            programmedDate.IsEnabled = true;
        }

        private void shippersDropDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearFieldsBtn_Click(object sender, RoutedEventArgs e)
        {
            resetPage(generateTitle(productsListView.SelectedItem.ToString()));
        }

        private async void SendRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkEnteredData())
            {
                //valid request
                int shipperId = retrieveID(currentSelectedShipperPlaceholder.Text);
                int quantity = Int32.Parse(quantityInputBox.Text);
                int productId = retrieveID(productsListView.SelectedItem.ToString());
                DateTime selectedDate = 
                    (todayCBox.IsChecked.Value) ? DateTime.Now.Date : programmedDate.Date.Value.Date;
                ProductServiceClient client =
                    new ProductServiceClient();
                int ret = await client.requestOrderAsync(loggedClientId, productId, quantity, selectedDate.Date.ToString("dd/MM/yyyy"), shipperId);
                if (ret > 0)
                {
                    //returned value is the new id
                    lblSuccess.Text = defaultLblSuccessText.Replace("----", ret.ToString());
                    lblSuccess.Visibility = Visibility.Visible;
                    lblError.Visibility = Visibility.Collapsed;
                }
                    
            }
            else
            {
                //invalid request
                lblError.Visibility = Visibility.Visible;
            }
        }

        private int retrieveID (String txt)
        {
            int from = txt.IndexOf("[") + 1;
            int to = txt.IndexOf("]");
            return Int32.Parse(txt.Substring(from, to - from));
        }
        private String retrieveName (String txt)
        {
            int from = txt.IndexOf("]");
            return txt.Substring(from + 1);
        }
        //return true if entered data is valid
        private bool checkEnteredData()
        {
            bool valid = true;
            int tmp = 0;
            valid &= (int.TryParse(quantityInputBox.Text, out tmp));
            valid &= !(loggedClientName is null);
            valid &= !(selectedProduct is null);
            valid &= !(selectedShipper is null);
            valid &= ((programmedDate.Date != null) || todayCBox.IsChecked.Value);
            return valid;
        }

        private bool shouldAlertUser()
        {
            if (currentSelectedShipperPlaceholder.Visibility == Visibility.Visible ||
                !quantityInputBox.Text.Equals("") ||
                !todayCBox.IsChecked.Value)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void resetPage(String selectedProduct)
        {
            requestTitle.Text = selectedProduct;
            /*currentSelectedClientText.Visibility = Visibility.Collapsed;
            currentSelectedClientPlaceholder.Visibility = Visibility.Collapsed;*/
            quantityInputBox.Text = "";
            todayCBox.IsChecked = true;
            currentSelectedShipperText.Visibility = Visibility.Collapsed;
            currentSelectedShipperPlaceholder.Visibility = Visibility.Collapsed;
            requestContentStackPanel.Visibility = Visibility.Visible;
            selectedShipper = null;
            lblError.Visibility = Visibility.Collapsed;
            lblSuccess.Text = defaultLblSuccessText;
            lblSuccess.Visibility = Visibility.Collapsed;
        }

        private String generateTitle(String product)
        {
            return "Make a " + product + " request";
        }

        private void listViewOptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem.ToString().Equals("View my orders"))
            {
                requestStackPanel.Visibility = Visibility.Collapsed;
                optionsWindow.Visibility = Visibility.Visible;
            } else if (e.ClickedItem.ToString().Equals("Log out"))
            {
                this.Frame.Navigate(typeof(LoginPage));
            }
        }
    }
}
