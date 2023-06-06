using Newtonsoft.Json;
using Prueba_tecnica_Summit_Systems.BussinesLayer;
using Prueba_tecnica_Summit_Systems.Models;
using Prueba_tecnica_Summit_Systems.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Prueba_tecnica_Summit_Systems.Models.JsonDefinitions;

namespace Prueba_tecnica_Summit_Systems.Controllers
{
    public class TestController : ApiController
    {
        // POST api/Test/5
        public DataDict TextService(DataDict input)
        {
            DataDict dataDict = new DataDict();
            try
            {
                DataService dataService = new DataService();
                dataDict = dataService.StartService(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return dataDict;
        }
    }
}
