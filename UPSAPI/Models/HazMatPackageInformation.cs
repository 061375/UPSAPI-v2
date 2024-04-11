using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class HazMatPackageInformation
    {
        [JsonProperty(PropertyName = "AllPackedInOneIndicator")]
        public string AllPackedInOneIndicator { get; set; }
        [JsonProperty(PropertyName = "OverPackedIndicator")]
        public string OverPackedIndicator { get; set; }
        [JsonProperty(PropertyName = "QValue")]
        public string QValue { get; set; }
        [JsonProperty(PropertyName = "OuterPackagingType")]
        public string OuterPackagingType { get; set; }
    }
}
