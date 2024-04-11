using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Translate
    {
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "DialectCode")]
        public string DialectCode { get; set; }
        [JsonProperty(PropertyName = "LanguageCode")]
        public string LanguageCode { get; set; }
    }
}
