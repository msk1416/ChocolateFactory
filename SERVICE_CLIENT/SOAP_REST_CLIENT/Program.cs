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
                        Console.WriteLine("id " + all[i].ChocId + ": " + all[i].ChocName + "(" + all[i].ChocType + ") - " + all[i].ChocQuant + " unit(s) - Price: EUR " + all[i].ChocPrice + ";, Cost: EUR " + all[i].ChocCost);
                    }
                } else if (line == "2")
                {
                    Chocolate newChoc = new Chocolate();
                    Console.Write("Name of the chocolate: ");
                    newChoc.ChocName = Console.ReadLine().Split()[0];

                    Console.Write("Type: ");
                    newChoc.ChocType = Console.ReadLine().Split()[0];

                    Console.Write("Insert number of units: ");
                    newChoc.ChocQuant = Int32.Parse(Console.ReadLine().Split()[0]);

                    Console.Write("Insert price and cost (separated by a space): ");
                    string tmp = Console.ReadLine();
                    newChoc.ChocPrice = Int32.Parse(tmp.Split()[0]);
                    newChoc.ChocCost = Int32.Parse(tmp.Split()[1]);

                    if (client.newChocolate(newChoc.ChocName, newChoc.ChocType, newChoc.ChocQuant, newChoc.ChocPrice, newChoc.ChocCost)) 
                    {
                        Console.WriteLine("Chocolate with name " + newChoc.ChocName + " was inserted successfully.");
                    } else
                    {
                        Console.WriteLine("Unfortunately this chocolate could not be added.");
                    }
                } else if (line == "exit")
                {
<<<<<<< HEAD
                    Console.WriteLine("exiting the application...");
=======
                    Console.WriteLine("exiting...");
>>>>>>> a822c60fc41cd425bb6ea3eae68289e811e81d35
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
