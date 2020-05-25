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
        //TODO read csv
        //zapisanie do listy wiadomosci z csv
        //wyslanie poszczegolnych rekordow wdl patternu
        string patha = @"..\loty.csv";

        private List<List<String>> flightsSchedule = new List<List<String>>();

        public string getAllFlights()
        {
            throw new NotImplementedException();
        }

        public string getFlightInScope(string cityFrom, string cityTo, int scopeFrom, int scopeTo)
        {
            throw new NotImplementedException();
        }

        public string getFlightsFromTo(string cityFrom, string cityTo)
        {
            throw new NotImplementedException();
        }
    }
}
