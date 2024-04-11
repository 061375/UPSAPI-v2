using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class LabelDelivery
    {
        [JsonProperty(PropertyName = "LabelLinkIndicator")]
        public string LabelLinkIndicator { get; set; }
        [JsonProperty(PropertyName = "ResendEmailIndicator")]
        public string ResendEmailIndicator { get; set; }
    }
}
