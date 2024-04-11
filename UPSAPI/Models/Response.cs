using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Response
    {
        [JsonProperty(PropertyName = "ResponseStatus")]
        public ResponseStatus ResponseStatus { get; set; }

        [JsonProperty(PropertyName = "TransactionReference")]
        public TransactionReference TransactionReference { get; set; }

        [JsonProperty(PropertyName = "Errors")]
        public List<Errors> Errors { get; set; }

    }
}
