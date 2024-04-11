using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class EMail
    {
        [JsonProperty(PropertyName = "Subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "SubjectCode")]
        public string SubjectCode { get; set; }
        [JsonProperty(PropertyName = "EMailAddress")]
        public string EMailAddress { get; set; }
        [JsonProperty(PropertyName = "UndeliverableEMailAddress")]
        public string UndeliverableEMailAddress { get; set; }
        [JsonProperty(PropertyName = "FromEMailAddress")]
        public string FromEMailAddress { get; set; }
        [JsonProperty(PropertyName = "FromName")]
        public string FromName { get; set; }
        [JsonProperty(PropertyName = "Memo")]
        public string Memo { get; set; }
    }
}
