﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace air_traffic_controller_WCF
{
    class FlightsService
    {
        private List<Flight> allFlights;

        

        public FlightsService(List<Flight> flights)
        {
            this.allFlights = flights;
        }
        public List<Flight> getAllFlights()
        {
            return allFlights;
        }
        public static String flightsToString(List<Flight> flights)
        {
            StringBuilder flightsAsString = new StringBuilder();
            foreach(Flight flight in flights)
            {
                flightsAsString.Append(flight.ToString());
            }
            return flightsAsString.ToString();
        }
        public List<Flight> findFlightFromToInScope(string cityFrom, string cityTo, int scopeFrom, int scopeTo)
        {
            List<Flight> flightsFromTo = findFlightFromTo(cityFrom, cityTo);
            List<Flight> flightsInScopeFromTo = findFlightInScope(flightsFromTo, scopeFrom, scopeTo);
            return flightsInScopeFromTo;
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
        private List<Flight> findFlightInScope(List<Flight> flights, int scopeFrom, int scopeTo)
        {
            List<Flight> flightsInScope = new List<Flight>();
            foreach (Flight flight in flights)
            {
                if (checkScope(flight, scopeFrom, scopeTo))
                {
                    flightsInScope.Add(flight);
                }
            }
            return flightsInScope;
        }
        private bool checkScope(Flight flight, int scopeFrom, int scopeTo)
        {
            //It is very simplified
            if (scopeFrom <= scopeTo)
            {
                return flight.Departure >= scopeFrom && flight.Arrival <= scopeTo;
            }
            return (flight.Departure >= scopeFrom && flight.Arrival <= scopeTo)
                    || (flight.Departure <= scopeTo && flight.Arrival <= scopeTo)
                    || (flight.Departure >= scopeFrom && flight.Arrival >= scopeFrom);
        }
        public HashSet<string> getCitiesTo()
        {
            HashSet<string> uniqueCities = new HashSet<string>();
            foreach(Flight flight in allFlights){
                uniqueCities.Add(flight.CityTo);
            }
            return uniqueCities;
        }

        public HashSet<string> getCitiesFrom()
        {
            HashSet<string> uniqueCities = new HashSet<string>();
            foreach (Flight flight in allFlights)
            {
                uniqueCities.Add(flight.CityFrom);
            }
            return uniqueCities;
        }
    }
}
