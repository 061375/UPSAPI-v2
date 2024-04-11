using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class LabelSpecification
    {
        [JsonProperty(PropertyName = "LabelImageFormat")]
        public LabelImageFormat LabelImageFormat { get; set; }
        [JsonProperty(PropertyName = "HTTPUserAgent")]
        public string HTTPUserAgent { get; set; }
        [JsonProperty(PropertyName = "LabelStockSize")]
        public LabelStockSize LabelStockSize { get; set; }
        [JsonProperty(PropertyName = "Instruction")]
        public Instruction Instruction { get; set; }
        [JsonProperty(PropertyName = "CharacterSet")]
        public string CharacterSet { get; set; }
    }
}
