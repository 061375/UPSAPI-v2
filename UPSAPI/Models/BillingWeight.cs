using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class BillingWeight
    {
        [JsonProperty(PropertyName = "UnitOfMeasurement")]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        [JsonProperty(PropertyName = "Weight")]
        public decimal Weight { get; set; }
    }
}
