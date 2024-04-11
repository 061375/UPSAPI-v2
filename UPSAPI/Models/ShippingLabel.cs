using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ShippingLabel
    {
        [JsonProperty(PropertyName = "ImageFormat")]
        public ImageFormat ImageFormat { get; set; }
        [JsonProperty(PropertyName = "GraphicImage")]
        public string GraphicImage { get; set; }
    }
}
