using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ReferenceNumber
    {
        [JsonProperty(PropertyName = "BarCodeIndicator")]
        public string BarCodeIndicator { get; set; }
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }
    }
}
