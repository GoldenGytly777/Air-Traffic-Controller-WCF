using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class Flight
    {
        private string cityFrom;
        private string cityTo;
        private int departure;
        private int arrival;

        public Flight(string cityFrom, string cityTo, int departure, int arrival) {
            this.cityFrom = cityFrom;
            this.cityTo = cityTo;
            this.departure = departure;
            this.arrival = arrival;
        }

        public string CityFrom { get => cityFrom; set => cityFrom = value; }
        public string CityTo { get => cityTo; set => cityTo = value; }
        public int Departure { get => departure; set => departure = value; }
        public int Arrival { get => arrival; set => arrival = value; }

        public override string ToString()
        {
            return
                "\n-----------------"+
                "\nFrom: " +cityFrom+
                "\nTo: "+cityTo+
                "\nDeparture: "+departure+
                "\nArrival: "+arrival
                + "\n-----------------";
        }
    }
}
