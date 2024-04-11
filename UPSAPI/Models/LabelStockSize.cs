using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class LabelStockSize
    {
        [JsonProperty(PropertyName = "Height")]
        public string Height { get; set; }
        [JsonProperty(PropertyName = "Width")]
        public string Width { get; set; }
    }
}
