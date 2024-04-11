using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Notification
    {
        [JsonProperty(PropertyName = "NotificationCode")]
        public string NotificationCode { get; set; }
        [JsonProperty(PropertyName = "EMail")]
        public EMail EMail { get; set; }
    }
}
