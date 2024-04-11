using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class PackageResults
    {
        [JsonProperty(PropertyName = "TrackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty(PropertyName = "BaseServiceCharge")]
        public BaseServiceCharge BaseServiceCharge { get; set; }

        [JsonProperty(PropertyName = "ServiceOptionsCharges")]
        public ServiceOptionsCharges ServiceOptionsCharges { get; set; }

        [JsonProperty(PropertyName = "ShippingLabel")]
        public ShippingLabel ShippingLabel { get; set; }

        [JsonProperty(PropertyName = "ItemizedCharges")]
        public List<ItemizedCharges> ItemizedCharges { get; set; }

    }
}
