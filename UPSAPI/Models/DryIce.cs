using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class DryIce
    {
        [JsonProperty(PropertyName = "RegulationSet")]
        public string RegulationSet { get; set; }
        [JsonProperty(PropertyName = "DryIceWeight")]
        public DryIceWeight DryIceWeight { get; set; }
        [JsonProperty(PropertyName = "MedicalUseIndicator")]
        public string MedicalUseIndicator { get; set; }
    }
}
