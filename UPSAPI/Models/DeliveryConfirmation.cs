using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class DeliveryConfirmation
    {
        [JsonProperty(PropertyName = "DCISType")]
        public string DCISType { get; set; }
        [JsonProperty(PropertyName = "DCISNumber")]
        public string DCISNumber { get; set; }
    }
}
