using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class FreightDensityInfo
    {
        [JsonProperty(PropertyName = "AdjustedHeightIndicator")]
        public string AdjustedHeightIndicator { get; set; }
    }
}
