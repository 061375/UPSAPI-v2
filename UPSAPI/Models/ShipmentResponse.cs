using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ShipmentResponse
    {
        [JsonProperty(PropertyName = "Response")]
        public Response Response { get; set; }

        [JsonProperty(PropertyName = "ShipmentResults")]
        public ShipmentResults ShipmentResults { get; set; }
        
    }
}
