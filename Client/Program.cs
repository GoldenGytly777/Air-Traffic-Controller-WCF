using System;
using System.Collections.Generic;
using Client.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            string [] citiesTo = client.getCitiesTo();
            HashSet<string> citiesToUnique = new HashSet<string>();
            foreach(string s in citiesTo)
            {
                citiesToUnique.Add(s);
            }
            string[] citiesFrom = client.getCitiesFrom();
            HashSet<string> citiesFromUnique = new HashSet<string>();
            foreach (string s in citiesFrom)
            {
                citiesFromUnique.Add(s);
            }
            
            do
            {
                try
                {
                    Console.WriteLine("Enter airport: ");     
                    string cityFrom = Console.ReadLine();
                
                    Console.WriteLine("Enter airport destination: ");
                    string cityTo = Console.ReadLine();

                    Console.WriteLine("Scope from: ");
                    int scopeFrom = int.Parse(Console.ReadLine());

                    Console.WriteLine("Scope to: ");
                    int scopeTo = int.Parse(Console.ReadLine());
                    if((scopeFrom<24 && scopeFrom >= 0) && (scopeTo < 24 && scopeTo >= 0))
                    {
                        Console.WriteLine(client.getFlightInScope(cityFrom, cityTo, scopeFrom, scopeTo));
                    }else
                        Console.WriteLine("Wrong argument should be integer value between 0-23");
                }
                catch(FormatException)
                {
                    Console.WriteLine("Wrong argument should be integer value between 0-23");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Wrong city argument");
                }
                

                

                Console.WriteLine("Type ESC to exit");
             
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            client.Close();
        }



    }
}