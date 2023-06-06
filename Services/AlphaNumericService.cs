using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Prueba_tecnica_Summit_Systems.BussinesLayer;
using Prueba_tecnica_Summit_Systems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_tecnica_Summit_Systems.Services
{
    public class AlphaNumericService:DataService
    {
        internal DataDict Process(string valorIngresado)
        {
            DataDict dataDict = new DataDict();
            try
            {
                ExternalServices externalServices = new ExternalServices();

                string Definition = externalServices.Definition(valorIngresado);
                string Resultado = string.Empty;
                if (Definition != null)
                {
                    List<JsonDefinitions> jsonDefinitions = JsonConvert.DeserializeObject<List<JsonDefinitions>>(Definition);
                    if (jsonDefinitions != null && jsonDefinitions.Count > 0)
                    {
                        Resultado = jsonDefinitions[0].meanings[0].definitions[0].definition.ToString();
                    }
                    dataDict.MessageError = "";
                    dataDict.Text = ServiceState.Accepted + "-" + Resultado;
                }
                else
                {
                    dataDict.MessageError = "No hay texto";
                    dataDict.Text = ServiceState.Rejected.ToString();
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