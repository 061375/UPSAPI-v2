using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class BillThirdParty
    {

        [JsonProperty(PropertyName = "AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "CertifiedElectronicMail")]
        public string CertifiedElectronicMail { get; set; }

        [JsonProperty(PropertyName = "InterchangeSystemCode")]
        public string InterchangeSystemCode { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public Address Address { get; set; }
    }
}
