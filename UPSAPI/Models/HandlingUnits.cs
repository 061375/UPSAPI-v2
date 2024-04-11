using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class HandlingUnits
    {
        [JsonProperty(PropertyName = "Quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public Type Type { get; set; }
        [JsonProperty(PropertyName = "Dimensions")]
        public Dimensions Dimensions { get; set; }
    }
}
