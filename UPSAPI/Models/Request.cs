using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Request
    {
        [JsonProperty(PropertyName = "SubVersion")]
        public string SubVersion { get; set; }
        [JsonProperty(PropertyName = "RequestOption")]
        public string RequestOption { get; set; }
        [JsonProperty(PropertyName = "TransactionReference")]
        public TransactionReference TransactionReference { get; set; }
        [JsonProperty(PropertyName = "LabelSpecification")]
        public LabelSpecification LabelSpecification { get; set; }
        [JsonProperty(PropertyName = "LabelDelivery")]
        public LabelDelivery LabelDelivery { get; set; }
        [JsonProperty(PropertyName = "TrackingNumber")]
        public string TrackingNumber { get; set; }
    }
}
