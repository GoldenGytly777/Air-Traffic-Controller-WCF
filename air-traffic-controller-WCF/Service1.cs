using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace air_traffic_controller_WCF
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class Service1 : IService1
    {
        //hardcoded
        string patha = @"..\..\..\Resources\flightsSchedule.csv";
        FlightsService flishtsSchedule;

        public Service1()
        {
            flishtsSchedule = createFlightService();
        }
        private FlightsService createFlightService()
        {
            return new FlightsService(convertCSVFileToListOfFlights());
        }
        private List<Flight> convertCSVFileToListOfFlights()
        {
            List<Flight> flights = new List<Flight>();
            using (var reader = new StreamReader(patha))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    string[] elementsOfRow = row.Split(',');
                    flights.Add(new Flight(elementsOfRow[0], elementsOfRow[1], int.Parse(elementsOfRow[2]), int.Parse(elementsOfRow[3])));
                }
            }
            return flights;
        }
        public string getAllFlights()
        {
            return FlightsService.flightsToString(flishtsSchedule.getAllFlights);
        }

        public string getFlightInScope(string cityFrom, string cityTo, int scopeFrom, int scopeTo)
        {
            return FlightsService.flightsToString(flishtsSchedule.findFlightFromToInScope(cityFrom, cityTo, scopeFrom, scopeTo));
        }

        public string getFlightsFromTo(string cityFrom, string cityTo)
        {
            throw new NotImplementedException();
        }

        
    }
}
