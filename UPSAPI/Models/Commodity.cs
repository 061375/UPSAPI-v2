using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Commodity
    {
        [JsonProperty(PropertyName = "FreightClass")]
        public string FreightClass { get; set; }
        [JsonProperty(PropertyName = "NMFC")]
        public NMFC NMFC { get; set; }
    }
}
