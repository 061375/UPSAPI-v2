using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class XAVRequest
    {
        [JsonProperty(PropertyName = "Request")]
        public Request Request { get; set; }
        [JsonProperty(PropertyName = "RegionalRequestIndicator")]
        public string RegionalRequestIndicator { get; set; }
        [JsonProperty(PropertyName = "MaximumCandidateListSize")]
        public string MaximumCandidateListSize { get; set; }
        [JsonProperty(PropertyName = "AddressKeyFormat")]
        public AddressKeyFormat AddressKeyFormat { get; set; }
    }
}
