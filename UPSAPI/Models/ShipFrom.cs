using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ShipFrom
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "AttentionName")]
        public string AttentionName { get; set; }
        [JsonProperty(PropertyName = "Phone")]
        public Phone Phone { get; set; }
        [JsonProperty(PropertyName = "FaxNumber")]
        public string FaxNumber { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public Address Address { get; set; }
    }
}
