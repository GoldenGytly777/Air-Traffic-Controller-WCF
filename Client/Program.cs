using System;
using System.Collections.Generic;
using Client.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
            HashSet<string> citiesToUnique = new HashSet<string>();
            HashSet<string> citiesFromUnique = new HashSet<string>();
            Service1Client client = new Service1Client();
            string [] citiesTo = client.getCitiesTo();
            
            foreach(string s in citiesTo)
            {
                citiesToUnique.Add(s);
            }
            string[] citiesFrom = client.getCitiesFrom();
            
            foreach (string s in citiesFrom)
            {
                citiesFromUnique.Add(s);
            }
            
            do
            {
                try
                {
                    string response = client.getFlightInScope(getFromCity(citiesFromUnique), getToCity(citiesToUnique), getScope());
                    if (response.Equals(""))
                    {
                        Console.WriteLine("There is no connection between this cities in this scope");
                    }
                    else
                    Console.WriteLine(response);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Type ESC to exit");
             
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            client.Close();
        }
        static private string getFromCity(HashSet<string> citiesFromUnique)
        {
            Console.WriteLine("Enter airport: ");
            string cityFrom = Console.ReadLine();
            if (!citiesFromUnique.Contains(cityFrom.ToUpper()))
                throw new ArgumentException("There is no airport in this city!");
            return cityFrom;
        }
        static private string getToCity(HashSet<string> citiesToUnique)
        {
            Console.WriteLine("Enter airport destination: ");
            string cityTo = Console.ReadLine();
            if (!citiesToUnique.Contains(cityTo.ToUpper()))
                throw new ArgumentException("There is no airport in this city!");
            return cityTo;
        }
        static private int getScope()
        {
            Console.WriteLine("Scope: ");
            int scopeFrom = int.Parse(Console.ReadLine());
            return scopeFrom;
        }

        }
}