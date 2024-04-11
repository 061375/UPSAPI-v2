using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class DeclaredValue
    {
        [JsonProperty(PropertyName = "Type")]
        public Type Type { get; set; }
        [JsonProperty(PropertyName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "MonetaryValue")]
        public string MonetaryValue { get; set; }
    }
}
