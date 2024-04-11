using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class FreightShipmentInformation
    {
        [JsonProperty(PropertyName = "FreightDensityInfo")]
        public FreightDensityInfo FreightDensityInfo { get; set; }
        [JsonProperty(PropertyName = "DensityEligibleIndicator")]
        public string DensityEligibleIndicator { get; set; }
    }
}
