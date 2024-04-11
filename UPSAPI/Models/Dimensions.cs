using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Dimensions
    {
        [JsonProperty(PropertyName = "UnitOfMeasurement")]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        [JsonProperty(PropertyName = "Length")]
        public string Length { get; set; }
        [JsonProperty(PropertyName = "Width")]
        public string Width { get; set; }
        [JsonProperty(PropertyName = "Height")]
        public string Height { get; set; }
    }
}
