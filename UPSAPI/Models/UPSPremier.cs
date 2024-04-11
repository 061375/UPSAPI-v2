using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class UPSPremier
    {
        [JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }
        [JsonProperty(PropertyName = "SensorID")]
        public string SensorID { get; set; }
        [JsonProperty(PropertyName = "HandlingInstructions")]
        public HandlingInstructions HandlingInstructions { get; set; }
    }
}
