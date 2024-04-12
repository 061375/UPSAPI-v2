using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class XAVResponse
    {
        [JsonProperty(PropertyName = "Response")]
        public Response Response { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Candidate>))]
        [JsonProperty(PropertyName = "Candidate")]
        public List<Candidate> Candidate { get; set; }
    }
}
