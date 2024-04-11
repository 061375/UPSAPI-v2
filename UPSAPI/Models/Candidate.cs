using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Candidate
    {
        [JsonProperty(PropertyName = "AddressKeyFormat")]
        public AddressKeyFormat AddressKeyFormat { get; set; }
    }
}
