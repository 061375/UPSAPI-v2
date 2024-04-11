using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class BillShipper
    {
        [JsonProperty(PropertyName = "AccountNumber")]
        public string AccountNumber { get; set; }
        [JsonProperty(PropertyName = "CreditCard")]
        public CreditCard CreditCard { get; set; }
        [JsonProperty(PropertyName = "AlternatePaymentMethod")]
        public string AlternatePaymentMethod { get; set; }
    }
}
