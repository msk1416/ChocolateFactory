using SOAP_REST_CLIENT.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOAP_REST_CLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.ServiceClient client = new ServiceReference.ServiceClient();
            
            string line;
            Console.WriteLine("Insert an option\n1 - show available chocolates\n2 - insert new chocolate\nexit - finish program");
            Console.Write(">");
            while ((line = Console.ReadLine()) != null)
            {
                if (line == "1")
                {
                    Chocolate[] all = client.GetChocolates();
                    for (int i=0; i < all.Length; i++)
                    {
                        Console.WriteLine("id " + all[i].ChocId + ": " + all[i].ChocName + " - " + all[i].ChocQuant + " unit(s)");
                    }
                } else if (line == "2")
                {
                    Console.Write("Name of the chocolate: ");
                    string newChoc = Console.ReadLine();
                    if (client.newChocolate(newChoc.Split()[0]))
                    {
                        Console.WriteLine("Chocolate with name " + newChoc.Split()[0] + " was inserted successfully.");
                    } else
                    {
                        Console.WriteLine("Unfortunately this chocolate could not be added.");
                    }
                } else if (line == "exit")
                {
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
