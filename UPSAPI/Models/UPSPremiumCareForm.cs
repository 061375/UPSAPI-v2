using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class UPSPremiumCareForm
    {
        [JsonProperty(PropertyName = "PageSize")]
        public string PageSize { get; set; }
        [JsonProperty(PropertyName = "PrintType")]
        public string PrintType { get; set; }
    }
}
