using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class AddressKeyFormat
    {
        [JsonProperty(PropertyName = "ConsigneeName")]
        public string ConsigneeName { get; set; }
        [JsonProperty(PropertyName = "AttentionName")]
        public string AttentionName { get; set; }
        [JsonProperty(PropertyName = "AddressLine")]
        public List<string> AddressLine { get; set; }
        [JsonProperty(PropertyName = "Region")]
        public string Region { get; set; }
        [JsonProperty(PropertyName = "PoliticalDivision2")]
        public string PoliticalDivision2 { get; set; }
        [JsonProperty(PropertyName = "PoliticalDivision1")]
        public string PoliticalDivision1 { get; set; }
        [JsonProperty(PropertyName = "PostcodePrimaryLow")]
        public string PostcodePrimaryLow { get; set; }
        [JsonProperty(PropertyName = "PostcodeExtendedLow")]
        public string PostcodeExtendedLow { get; set; }
        [JsonProperty(PropertyName = "Urbanization")]
        public string Urbanization { get; set; }
        [JsonProperty(PropertyName = "CountryCode")]
        public string CountryCode { get; set; }
    }
}
