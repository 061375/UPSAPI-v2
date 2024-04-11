﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class ItemizedCharges
    {
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "MonetaryValue")]
        public decimal MonetaryValue { get; set; }
    }
}
