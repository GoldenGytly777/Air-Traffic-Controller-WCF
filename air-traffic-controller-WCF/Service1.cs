using System;
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
        public string getFlightInfo(string v1, string v2, int a)
        {
            throw new NotImplementedException();
        }
    }
}
