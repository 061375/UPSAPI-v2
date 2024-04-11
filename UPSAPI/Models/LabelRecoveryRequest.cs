using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class LabelRecoveryRequest
    {
        [JsonProperty(PropertyName = "LabelDelivery")]
        public LabelDelivery LabelDelivery { get; set; }
        [JsonProperty(PropertyName = "LabelSpecification")]
        public LabelSpecification LabelSpecification { get; set; }
        [JsonProperty(PropertyName = "LabelStockSize")]
        public LabelStockSize LabelStockSize { get; set; }
        [JsonProperty(PropertyName = "Translate")]
        public Translate Translate { get; set; }
        [JsonProperty(PropertyName = "Request")]
        public Request Request { get; set; }
        [JsonProperty(PropertyName = "TrackingNumber")]
        public string TrackingNumber { get; set; }
        [JsonProperty(PropertyName = "MailInnovationsTrackingNumber")]
        public string MailInnovationsTrackingNumber { get; set; }
        [JsonProperty(PropertyName = "ReferenceValues")]
        public ReferenceValues ReferenceValues { get; set; }
        [JsonProperty(PropertyName = "Locale")]
        public string Locale { get; set; }
        [JsonProperty(PropertyName = "UPSPremiumCareForm")]
        public UPSPremiumCareForm UPSPremiumCareForm { get; set; }
        
    }
}
