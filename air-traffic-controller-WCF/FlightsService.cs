using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace air_traffic_controller_WCF
{
    class FlightsService
    {
        private List<Flight> allFlights;
        Dictionary<string, List<Flight>> allFlightsToCity = new Dictionary<string, List<Flight>>();


        public FlightsService(List<Flight> flights)
        {
            this.allFlights = flights;
            initDictionary();
        }
        public void initDictionary()
        {
            //to jest slownik tak naprawde wszystkich lotow do danego miastas
            foreach (String city in getUniqueCitiesTo())
            {
                List<Flight> avaibleFlights = new List<Flight>();
                foreach (Flight flight in allFlights)
                {
                    if (flight.CityTo.Equals(city))
                    {
                        avaibleFlights.Add(flight);
                    }
                }
                allFlightsToCity.Add(city, avaibleFlights);
            }
        }
        public HashSet<String> getUniqueCitiesTo()
        {
            HashSet<String> uniqueCities = new HashSet<string>();
            foreach (Flight flight in allFlights)
            {
                uniqueCities.Add(flight.CityTo);
            }
            return uniqueCities;
        }
        public List<Flight> getAllFlights()
        {
            return allFlights;
        }
        public static String flightsToString(List<Flight> flights)
        {
            StringBuilder flightsAsString = new StringBuilder();
            foreach (Flight flight in flights)
            {
                flightsAsString.Append(flight.ToString());
            }
            return flightsAsString.ToString();
        }
        public String findFlightFromToInScope(string cityFrom, string cityTo, int scope)
        {
            List<List<Flight>> allPaths = new List<List<Flight>>();

            findFlightFromToInScopeR(cityFrom, cityTo, scope, null, allPaths);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (List<Flight> flights in allPaths)
            {
                stringBuilder.Append("Destination city:"+cityTo);
                foreach (Flight flight in flights)
                {
                    stringBuilder.Append(" Arrival:" + flight.Arrival + " <- " + flight.CityFrom + " Departure:" + flight.Departure);

                }
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }
        public void findFlightFromToInScopeR(string cityFrom, string cityTo, int scope, List<Flight> flightsDone, List<List<Flight>> allPaths)
        {
            if (flightsDone == null)
                flightsDone = new List<Flight>();
            if (cityFrom.Equals(cityTo))
            {
                allPaths.Add(flightsDone);
                return;
            }
            else
            {
                if (scope >= 0)
                {
                    List<Flight> flightsFrom = allFlightsToCity[cityTo];
                    foreach (Flight flight in flightsFrom)
                    {
                        bool isRepeat = false;
                        List<Flight> newList = new List<Flight>(flightsDone);
                        foreach (Flight flight1 in newList)
                        {
                            if (flight == flight1)
                            {
                                isRepeat = true;
                            }
                        }
                        if (!isRepeat)
                        {
                            newList.Add(flight);
                            if (scope - (flight.Arrival - flight.Departure) >= 0)
                                findFlightFromToInScopeR(cityFrom, flight.CityFrom, scope - (flight.Arrival - flight.Departure), newList, allPaths);
                        }

                    }
                }
            }
        }
        public List<Flight> findFlightFromTo(string cityFrom, string cityTo)
        {
            List<Flight> flights = new List<Flight>();
            foreach (Flight flight in allFlights)
            {
                if (checkCities(flight, cityFrom, cityTo))
                {
                    flights.Add(flight);
                }
            }
            return flights;
        }

        internal static string flightsToString(Func<List<Flight>> getAllFlights)
        {
            throw new NotImplementedException();
        }

        private bool checkCities(Flight flight, string cityFrom, string cityTo)
        {
            return (flight.CityFrom.ToUpper().Equals(cityFrom.ToUpper()) && flight.CityTo.ToUpper().Equals(cityTo.ToUpper()));
        }
        private List<Flight> findFlightInScope(List<Flight> flights, int scope)
        {
            List<Flight> flightsInScope = new List<Flight>();
            foreach (Flight flight in flights)
            {
                if (checkScope(flight, scope))
                {
                    flightsInScope.Add(flight);
                }
            }
            return flightsInScope;
        }
        private bool checkScope(Flight flight, int scope)
        {
            return flight.Arrival - flight.Departure <= scope;
        }
        public HashSet<string> getCitiesTo()
        {
            HashSet<string> uniqueCities = new HashSet<string>();
            foreach (Flight flight in allFlights)
            {
                uniqueCities.Add(flight.CityTo.ToUpper());
            }
            return uniqueCities;
        }

        public HashSet<string> getCitiesFrom()
        {
            HashSet<string> uniqueCities = new HashSet<string>();
            foreach (Flight flight in allFlights)
            {
                uniqueCities.Add(flight.CityFrom.ToUpper());
            }
            return uniqueCities;
        }
    }
}
