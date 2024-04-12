using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ShipmentResults
    {
        [JsonProperty(PropertyName = "ShipmentCharges")]
        public ShipmentCharges ShipmentCharges { get; set; }
        [JsonProperty(PropertyName = "ShipmentIdentificationNumber")]
        public string ShipmentIdentificationNumber { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<PackageResults>))]
        [JsonProperty(PropertyName = "PackageResults")]
        public List<PackageResults> PackageResults { get; set; }


    }
}
