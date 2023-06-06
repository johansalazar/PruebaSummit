using Newtonsoft.Json;
using Prueba_tecnica_Summit_Systems.BussinesLayer;
using Prueba_tecnica_Summit_Systems.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Prueba_tecnica_Summit_Systems.Services
{
    public class NumericServices
    {
        internal DataDict Process(decimal valorIngresado)
        {
            DataDict dataDict = new DataDict();
            try
            {
                ExternalServices externalServices = new ExternalServices();

                string rates = externalServices.rates();
                decimal Resultado = 0;
                if (rates != null)
                {
                    JsonRates jsonRates = JsonConvert.DeserializeObject<JsonRates>(rates);
                    decimal valor = decimal.Parse(jsonRates.data.rates.COP, CultureInfo.InvariantCulture);
                    //Convert.ToDouble(jsonRates.data.rates.COP);
                    if (valor > 0)
                    {
                        Resultado = valor * valorIngresado;
                    }
                    dataDict.MessageError = "";
                    dataDict.Text = ServiceState.Accepted + "-" + Resultado.ToString();
                }
                else
                {
                    dataDict.MessageError = "No hay texto";
                    dataDict.Text = ServiceState.Aborted.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                dataDict.MessageError = "No hay datos";
                dataDict.Text = ServiceState.Aborted.ToString();
            }
            return dataDict;
        }
    }
}