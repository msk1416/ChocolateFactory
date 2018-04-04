using SOAP_REST_CLIENT.ServiceReference;
using SOAP_REST_CLIENT.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOAP_REST_CLIENT
{
    class Client
    {
        static void Main(string[] args)
        {
            ProductServiceReference.ProductServiceClient client = 
                new ProductServiceReference.ProductServiceClient();
            string line;
            Console.WriteLine("Insert an option\n1 - show available chocolates\n2 - insert new chocolate\n3 - update existing product\nexit - finish program");
            Console.Write(">");
            while ((line = Console.ReadLine()) != null)
            {
                if (line == "1")
                {
                    ProductServiceReference.Product[] all = client.GetProducts();
                    for (int i = 0; i < all.Length; i++)
                    {
                        Console.WriteLine("id " + all[i].ID + ": " 
                            + all[i].Name + " (" 
                            + all[i].Type + ") - " 
                            + all[i].Quantity 
                            + " unit(s) - Price: EUR " + all[i].Price 
                            + ", Cost: EUR " + all[i].Cost);
                    }
                }
                else if (line == "2")
                {
                    Product newProd = new Product();
                    Console.Write("Insert unique Id: ");
                    newProd.ID = Int32.Parse(Console.ReadLine().Split()[0]);

                    
                    Console.Write("Name of the product: ");
                    newProd.Name = Console.ReadLine().Split()[0].Trim();

                    Console.Write("Type: ");
                    newProd.Type = Console.ReadLine().Split()[0].Trim();

                    Console.Write("Insert number of units: ");
                    newProd.Quantity = Int32.Parse(Console.ReadLine().Split()[0]);

                    Console.Write("Insert price and cost (separated by a space): ");
                    string tmp = Console.ReadLine();
                    newProd.Price = Int32.Parse(tmp.Split()[0]);
                    newProd.Cost = Int32.Parse(tmp.Split()[1]);

                    if (client.newProduct(newProd.ID, newProd.Name, newProd.Type, newProd.Quantity, newProd.Price, newProd.Cost))
                    {
                        Console.WriteLine("Chocolate with name " + newProd.Name + " was inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately this chocolate could not be added.");
                    }
                } else if (line == "3")
                {
                    Console.Write("Insert ID of the product to modify: ");
                    int id = Int32.Parse(Console.ReadLine().Split()[0]);
                    int q, p, c;
                    bool worked = false;
                    Console.Write("Insert which parameter you want to modify (Q for quantity, P for price or C for cost:");
                    string op = Console.ReadLine().Split()[0];
                    if (op[0].Equals('Q') || op[0].Equals('q'))
                    {
                        Console.Write("New Quantity: ");
                        q = Int32.Parse(Console.ReadLine().Split()[0]);
                        worked = client.updateProduct(id, q, -1, -1);
                    } else if (op[0].Equals('P') || op[0].Equals('p'))
                    {
                        Console.Write("New Price: ");
                        p = Int32.Parse(Console.ReadLine().Split()[0]);
                        worked = client.updateProduct(id, -1, p, -1);
                    } else if (op[0].Equals('C') || op[0].Equals('c'))
                    {
                        Console.Write("New Cost: ");
                        c = Int32.Parse(Console.ReadLine().Split()[0]);
                        worked = client.updateProduct(id, -1, -1, c);
                    } else
                    {
                        Console.WriteLine("Invalid operation. Try again.");
                    }
                    if (worked)
                    {
                        Console.WriteLine("Product with id " + id + " has been updated successfully.");
                    } else
                    {
                        Console.WriteLine("No product has been updated due to errors happened.");
                    }
                }
                else if (line == "exit")
                {
                    Console.WriteLine("exiting the application...");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid option.");
                }
                Console.WriteLine();
                Console.WriteLine("Insert an option\n1 - show available chocolates\n2 - insert new chocolate\n3 - update existing product\nexit - finish program");
                Console.Write(">");
            }
        }
    }
}
