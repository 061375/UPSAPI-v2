using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Address
    {
        [JsonProperty(PropertyName = "AddressLine")]
        public List<string> AddressLine { get; set; }
        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "StateProvinceCode")]
        public string StateProvinceCode { get; set; }
        [JsonProperty(PropertyName = "PostalCode")]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "CountryCode")]
        public string CountryCode { get; set; }
    }
}
