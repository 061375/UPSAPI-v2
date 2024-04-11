using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class NMFC
    {
        [JsonProperty(PropertyName = "PrimeCode")]
        public string PrimeCode { get; set; }
        [JsonProperty(PropertyName = "SubCode")]
        public string SubCode { get; set; }
    }
}
