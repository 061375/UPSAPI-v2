using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ShipmentCharge
    {
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "SplitDutyVATIndicator")]
        public string SplitDutyVATIndicator { get; set; }
        [JsonProperty(PropertyName = "BillShipper")]
        public BillShipper BillShipper { get; set; }
        [JsonProperty(PropertyName = "BillReceiver")]
        public BillReceiver BillReceiver { get; set; }
        [JsonProperty(PropertyName = "BillThirdParty")]
        public BillThirdParty BillThirdParty { get; set; }
        [JsonProperty(PropertyName = "ConsigneeBilledIndicator")]
        public string ConsigneeBilledIndicator { get; set; }
    }
}
