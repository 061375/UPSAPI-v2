using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class _Root
    {
        [JsonProperty(PropertyName = "ShipmentRequest")]
        public ShipmentRequest ShipmentRequest { get; set; }
        [JsonProperty(PropertyName = "XAVRequest")]
        public XAVRequest XAVRequest { get; set; }
        [JsonProperty(PropertyName = "XAVResponse")]
        public XAVResponse XAVResponse { get; set; }
        [JsonProperty(PropertyName = "ShipmentResponse")]
        public ShipmentResponse ShipmentResponse { get; set; }
        [JsonProperty(PropertyName = "Response")]
        public Response Response { get; set; }
    }
}
