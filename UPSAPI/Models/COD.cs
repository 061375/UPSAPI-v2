using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class COD
    {
        [JsonProperty(PropertyName = "CODFundsCode")]
        public string CODFundsCode { get; set; }
        [JsonProperty(PropertyName = "CODAmount")]
        public CODAmount CODAmount { get; set; }
    }
}
