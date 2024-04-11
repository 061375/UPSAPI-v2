using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class PaymentInformation
    {
        [JsonProperty(PropertyName = "ShipmentCharge")]
        public List<ShipmentCharge> ShipmentCharge { get; set; }
    }
}
