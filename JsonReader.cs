using DSharpPlus.Net.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidlunnia_tushi_discord
{
    internal class JsonReader
    {


        public string token { get; set; }
        public string prefix { get; set; }
        public async Task ReadJSON()
        {
            using (StreamReader sr = new StreamReader("config.json"))
            {
                string Json = await sr.ReadToEndAsync();
                JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(Json);

                this.token = data.token;
                this.prefix = data.prefix;
            }
        }
    }    
        internal sealed class JSONStructure
        {
            public string token { get; set; }
            public string prefix { get; set; }
        }
    
}

