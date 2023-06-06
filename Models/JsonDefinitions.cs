using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Prueba_tecnica_Summit_Systems.Models.JsonDefinitions;

namespace Prueba_tecnica_Summit_Systems.Models
{
    //[JSON].[0].meanings.[0].definitions
    public class JsonDefinitions
    {
        //public class JsonDefinition
        //{
        public string word { get; set; }
        public Phonetics[] phonetics { get; set; }
        public class Phonetics
        {
            public string sourceUrl { get; set; }
        }
        public Meanings[] meanings { get; set; }

        public class Meanings
        {
            public string partOfSpeech { get; set; }
            public List<Definitions> definitions { get; set; }
        }
        public class Definitions
        {
            public string definition { get; set; }
        }


        //}
        //public List<JsonDefinition> jsonDefinitions { get; set; }


    }
}
