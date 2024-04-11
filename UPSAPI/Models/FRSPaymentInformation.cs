using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class FRSPaymentInformation
    {
        [JsonProperty(PropertyName = "Type")]
        public Type Type { get; set; }
        [JsonProperty(PropertyName = "AccountNumber")]
        public string AccountNumber { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public Address Address { get; set; }
    }
}
