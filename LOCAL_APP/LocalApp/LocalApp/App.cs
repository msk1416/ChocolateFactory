using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalApp.ProductServiceReference;

namespace LocalApp
{
    class App
    {
        static void Main(string[] args)
        {
            ProductServiceClient client = new ProductServiceClient();
            printWelcome();
            printOptions();
            int op = getIntegerFromUserInput();
            while (op != -1)
            {
                if (op == 1)
                {
                    List<OrderDTO> orders = client.getOrders().ToList();
                    pl("Orders already done:");
                    pl("OrderID, ClientID, ProductID, Quantity, Date, ShipperID");
                    pl("-------------------------------------------------------");
                    foreach (OrderDTO o in orders)
                    {
                        pl(o.OrderID + ", " + o.ClientID + ", " + o.ProductID + ", " + o.Quantity + ", " + o.Date.ToShortDateString() + ", " + o.ShipperID);
                    }

                } else if (op == 2)
                {
                    List<PendingOrderDTO> orders = client.getPendingOrders().ToList();
                    pl("Orders pending to be accepted:");
                    pl("OrderID, ClientID, ProductID, Quantity, Date, ShipperID");
                    pl("-------------------------------------------------------");
                    foreach (PendingOrderDTO o in orders)
                    {
                        pl(o.OrderID + ", " + o.ClientID + ", " + o.ProductID + ", " + o.Quantity + ", " + o.Date.ToShortDateString() + ", " + o.ShipperID);
                    }
                } else if (op == 3)
                {
                    p("Client identifier > ");
                    int clientId = getIntegerFromUserInput();
                    p("Product identifier > ");
                    int productId = getIntegerFromUserInput();
                    p("Quantity of the product > ");
                    int quantity = getIntegerFromUserInput();
                    p("Date (dd/mm/yyyy) > ");
                    String date = getStringFromUserInput();
                    p("Shipper identifier > ");
                    int shipperId = getIntegerFromUserInput();
                    int orderId =
                        client.requestOrder(clientId, productId, quantity, date, shipperId);
                    if (orderId > 0)
                    {
                        pl("Order has been requested, the following identifies has been generated: " + orderId);
                    } else
                    {
                        pl("Some error happened and the request could not be registered.");
                    }
                } else if (op == 4)
                {
                    List<ClientDTO> clients = client.getClients().ToList();
                    pl("Clients in database:");
                    pl("Identifier, Name, City, Prefered format");
                    pl("-------------------------------------");
                    foreach (ClientDTO c in clients)
                    {
                        pl(c.ClientID + ", " + c.Name + ", " + c.City + ", " + c.PreferedFormat);
                    }
                } else if (op == 5)
                {
                    List<ProductDTO> products = client.getProducts().ToList();
                    pl("Products in database:");
                    pl("Identifier, Name, Type, Local stock, Price, Cost");
                    pl("------------------------------------------------");
                    foreach (ProductDTO p in products)
                    {
                        pl(p.ProductID + ", " + p.ProductName + ", " + p.Type + ", " + p.Quantity + ", " + p.Price + ", " + p.Cost);
                    }
                } else if (op == 6)
                {
                    List<ShipperDTO> shippers = client.getShippers().ToList();
                    pl("Shippers in database:");
                    pl("Identifier, Name, City, Cost per ton");
                    pl("------------------------------------");
                    foreach (ShipperDTO s in shippers)
                    {
                        pl(s.ShipperID + ", " + s.Name + ", " + s.City + ", " + s.CostPerTon);
                    }
                } else if (op == -1)
                {
                    client.Close();
                    return;
                } else
                {
                    pl("Please input a valid option.");
                }
                pl(" ");
                printOptions();
                op = getIntegerFromUserInput();
            }
        }

        static private int getIntegerFromUserInput()
        {
            return Int32.Parse(Console.ReadLine().Split(' ')[0]);
        }
        static private String getStringFromUserInput()
        {
            return Console.ReadLine().Split(' ')[0];
        }
        static private void printWelcome()
        {
            Console.WriteLine("Welcome to the ChocolateFactory.");
        }
        static private void printOptions()
        {
            Console.WriteLine("Select an option from the list:");
            Console.WriteLine(" 1 - Print all orders ");
            Console.WriteLine(" 2 - Print all pending orders");
            Console.WriteLine(" 3 - Request an order");
            Console.WriteLine(" 4 - Print all clients");
            Console.WriteLine(" 5 - Print all products");
            Console.WriteLine(" 6 - Print all shippers");
            Console.WriteLine(" -1 - Exit the application");
            Console.Write("> ");
        }
        static private void p(String msg)
        {
            Console.Write(msg);
        }

        static private void pl(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
