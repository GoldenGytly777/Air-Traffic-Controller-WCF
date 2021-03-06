﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace air_traffic_controller_WCF
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string getFlightInScope(string cityFrom, string cityTo, int scope);
        [OperationContract]
        string getAllFlights();
        [OperationContract]
        string getFlightsFromTo(string cityFrom, string cityTo);
        [OperationContract]
        HashSet<string> getCitiesTo();
        [OperationContract]
        HashSet<string> getCitiesFrom();
    }
}
