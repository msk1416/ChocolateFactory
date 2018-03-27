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
            //ServiceReference.ServiceClient client = new ServiceReference.ServiceClient();
            ProductServiceReference.ProductServiceClient client = 
                new ProductServiceReference.ProductServiceClient();
            string line;
            Console.WriteLine("Insert an option\n1 - show available chocolates\n2 - insert new chocolate\nexit - finish program");
            Console.Write(">");
            while ((line = Console.ReadLine()) != null)
            {
                if (line == "1")
                {
                    //Chocolate[] all = client.GetChocolates();
                    //for (int i = 0; i < all.Length; i++)
                    //{
                    //    Console.WriteLine("id " + all[i].ChocId + ": " + all[i].ChocName + " (" + all[i].ChocType + ") - " + all[i].ChocQuant + " unit(s) - Price: EUR " + all[i].ChocPrice + ";, Cost: EUR " + all[i].ChocCost);
                    //}
                    ProductServiceReference.Product[] all = client.GetProducts();
                    for (int i = 0; i < all.Length; i++)
                    {
                        Console.WriteLine("id " + all[i].ID + ": " 
                            + all[i].Name + " (" 
                            + all[i].Type + ") - " 
                            + all[i].Quantity 
                            + " unit(s) - Price: EUR " + all[i].Price 
                            + ";, Cost: EUR " + all[i].Cost);
                    }
                }
                else if (line == "2")
                {
                    Product newProd = new Product();
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

                    if (client.newProduct(newProd.Name, newProd.Type, newProd.Quantity, newProd.Price, newProd.Cost))
                    {
                        Console.WriteLine("Chocolate with name " + newProd.Name + " was inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately this chocolate could not be added.");
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
                Console.WriteLine("Insert an option\n1 - show available chocolates\n2 - insert new chocolate\nexit - finish program");
                Console.Write(">");
            }
        }
    }
}
