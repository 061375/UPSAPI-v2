using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ShipmentRequest
    {
        [JsonProperty(PropertyName = "Request")]
        public Request Request { get; set; }
        [JsonProperty(PropertyName = "Shipment")]
        public Shipment Shipment { get; set; }
    }
}
