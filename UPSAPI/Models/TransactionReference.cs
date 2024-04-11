using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class TransactionReference
    {
        [JsonProperty(PropertyName = "CustomerContext")]
        public string CustomerContext { get; set; }

        [JsonProperty(PropertyName = "TransactionIdentifier")]
        public string TransactionIdentifier { get; set; }
    }
}
