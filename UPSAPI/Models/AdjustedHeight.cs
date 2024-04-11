using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class AdjustedHeight
    {
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }
    }
}
