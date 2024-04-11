using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Shipper
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "AttentionName")]
        public string AttentionName { get; set; }
        [JsonProperty(PropertyName = "TaxIdentificationNumber")]
        public string TaxIdentificationNumber { get; set; }
        [JsonProperty(PropertyName = "Phone")]
        public Phone Phone { get; set; }
        [JsonProperty(PropertyName = "ShipperNumber")]
        public string ShipperNumber { get; set; }
        [JsonProperty(PropertyName = "FaxNumber")]
        public string FaxNumber { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public Address Address { get; set; }
    }
}
