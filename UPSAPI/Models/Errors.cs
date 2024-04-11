using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Errors
    {
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }
    }
}
