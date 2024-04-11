using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ReferenceValues
    {
        [JsonProperty(PropertyName = "ReferenceNumber")]
        public ReferenceNumber ReferenceNumber { get; set; }
        [JsonProperty(PropertyName = "ShipperNumber")]
        public string ShipperNumber { get; set; }
    }
}
