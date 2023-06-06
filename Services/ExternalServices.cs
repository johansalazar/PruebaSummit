using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace Prueba_tecnica_Summit_Systems.Services
{
    public class ExternalServices
    {

        public string rates() {

            string responseBody=null;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            var request = (HttpWebRequest)WebRequest.Create("https://api.coinbase.com/v2/exchange-rates?currency=USD");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                             responseBody = objReader.ReadToEnd();
                            //string ResponseJson = JsonConvert.DeserializeObject(responseBody);
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
               
            }
            return responseBody;
        }

        public string Definition(string Word)
        {

            string responseBody = null;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            var request = (HttpWebRequest)WebRequest.Create(string.Format("https://api.dictionaryapi.dev/api/v2/entries/en/{0}", Word));
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                            //string ResponseJson = JsonConvert.DeserializeObject(responseBody);
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {

            }
            return responseBody;
        }
    }
}