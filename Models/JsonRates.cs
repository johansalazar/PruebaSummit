using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_tecnica_Summit_Systems.Models
{
    //"data": {
    //    "currency": "USD",
    //    "rates": {
    public class JsonRates
    {
        public Data data { get; set; }

        public class Data
        {
            public string currency { get; set; }
            public Rates rates { get; set; }
        }
        public class Rates
        {
            public string COP { get; set; }
        }
    }
}