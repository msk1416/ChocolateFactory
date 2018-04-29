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
        String prevProduct;
        int prevSelected = -1;
        int indexSelected = -1;
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
            populateClientsList();
            populateShippersList();
            programmedDate.MinDate = DateTime.Now;
        }

        private async void populateProductsList()
        {
            ProductServiceClient client
                = new ProductServiceClient();
            products = await client.getProductsAsync();
            foreach (ProductDTO p in products)
            {
                productsListView.Items.Add(p.Type.Trim() + " " + p.ProductName.Trim());
            }
            client.CloseAsync();
        }

        private async void populateClientsList()
        {
            clientDropDown.IsEnabled = false;
            ProductServiceClient client
                = new ProductServiceClient();
            clients = await client.getClientsAsync();
            foreach (ClientDTO c in clients)
            {
                MenuFlyoutItem item = new MenuFlyoutItem();
                item.Text = c.Name;
                item.Click += (s, e1) =>
                {
                    currentSelectionText.Visibility = Visibility.Visible;
                    currentSelectionPlaceholder.Text = item.Text;
                    currentSelectionPlaceholder.Visibility = Visibility.Visible;
                };

                menuFlyoutClients.Items.Add(item);
            }
            clientDropDown.IsEnabled = true;
        }

        private async void populateShippersList()
        {
            shippersDropDown.IsEnabled = false;
            ProductServiceClient client
                = new ProductServiceClient();
            shippers = await client.getShippersAsync();
            foreach (ShipperDTO sh in shippers)
            {
                MenuFlyoutItem item = new MenuFlyoutItem();
                item.Text = sh.Name;
                item.Click += (s, e1) =>
                {
                    currentSelectedShipperText.Visibility = Visibility.Visible;
                    currentSelectedShipperPlaceholder.Text = item.Text;
                    currentSelectedShipperPlaceholder.Visibility = Visibility.Visible;
                };

                menuFlyoutShippers.Items.Add(item);
            }
            shippersDropDown.IsEnabled = true;
        }

        private void onClientItemClick(object sender, EventArgs e)
        {
            currentSelectionText.Visibility = Visibility.Visible;
            currentSelectionPlaceholder.Text = e.ToString();
            currentSelectionPlaceholder.Visibility = Visibility.Visible;
        }

        private void productsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (indexSelected == -1)
                InitialText.Visibility = Visibility.Collapsed;
            resetPage(generateTitle(e.ClickedItem.ToString()));
            /*if (prevSelected != indexSelected && prevSelected != -1)
            {
                if (shouldAlertUser())
                {
                   showAlertPopupAsync(e.ClickedItem.ToString());
                } else
                {
                    resetPage(e.ClickedItem.ToString());
                    prevSelected = indexSelected;
                }
            } else if (prevSelected == -1)
            {
                resetPage(generateTitle(e.ClickedItem.ToString()));
            }/*
            //requestTitle.Text = generateTitle();
            if (indexSelected >= 0 && shouldAlertUser())
            {
                showAlertPopupAsync(e.ClickedItem.ToString());
            } else if (selectedProduct == null)
            {
                resetPage(e.ClickedItem.ToString());
                selectedProduct = e.ClickedItem.ToString();
                indexSelected = e.ClickedItem
            }*/
        }

        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
            if (prevSelected == -1 && indexSelected == -1)
            {
                indexSelected = productsListView.SelectedIndex;
            } else
            {
                prevSelected = indexSelected;
                indexSelected = productsListView.SelectedIndex;
            }*/
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

        private void SendRequestBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool shouldAlertUser()
        {
            if (currentSelectionPlaceholder.Visibility == Visibility.Visible ||
                currentSelectedShipperPlaceholder.Visibility == Visibility.Visible ||
                !quantity.Text.Equals("") ||
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
            currentSelectionText.Visibility = Visibility.Collapsed;
            currentSelectionPlaceholder.Visibility = Visibility.Collapsed;
            quantity.Text = "";
            todayCBox.IsChecked = true;
            currentSelectedShipperText.Visibility = Visibility.Collapsed;
            currentSelectedShipperPlaceholder.Visibility = Visibility.Collapsed;
            requestContentStackPanel.Visibility = Visibility.Visible;
        }

        private String generateTitle(String product)
        {
            return "Make a " + product + " request";
        }

    }
}
