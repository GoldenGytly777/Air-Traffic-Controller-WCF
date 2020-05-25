using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create an instance of the WCF proxy.
            Service1Client client = new Service1Client();

            // Step 2: Call the service operations.
            // Call the Add service operation.
            do
            {
                Console.WriteLine("Enter airport: ");
                string cityFrom = Console.ReadLine();

                Console.WriteLine("Enter airport destination: ");
                string cityTo = Console.ReadLine();

                Console.WriteLine("Scope from: ");
                int scopeFrom = int.Parse(Console.ReadLine());

                Console.WriteLine("Scope to: ");
                int scopeTo = int.Parse(Console.ReadLine());

                Console.WriteLine(client.getFlightInScope(cityFrom, cityTo, scopeFrom, scopeTo));

                Console.WriteLine("Type ESC to exit");
             
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            client.Close();
        }
        
    }
}