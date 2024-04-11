using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ShipmentCharges
    {
        [JsonProperty(PropertyName = "TransportationCharges")]
        public TransportationCharges TransportationCharges { get; set; }
        [JsonProperty(PropertyName = "ServiceOptionsCharges")]
        public ServiceOptionsCharges ServiceOptionsCharges { get; set; }
        [JsonProperty(PropertyName = "TotalCharges")]
        public TotalCharges TotalCharges { get; set; }
    }
}
