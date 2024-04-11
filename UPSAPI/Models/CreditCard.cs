using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class CreditCard
    {
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }
        [JsonProperty(PropertyName = "ExpirationDate")]
        public string ExpirationDate { get; set; }
        [JsonProperty(PropertyName = "SecurityCode")]
        public string SecurityCode { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }

    }
}
