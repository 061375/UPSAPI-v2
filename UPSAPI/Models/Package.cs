using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Package
    {
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "PalletDescription")]
        public string PalletDescription { get; set; }
        [JsonProperty(PropertyName = "NumOfPieces")]
        public string NumOfPieces { get; set; }
        [JsonProperty(PropertyName = "UnitPrice")]
        public string UnitPrice { get; set; }
        [JsonProperty(PropertyName = "Packaging")]
        public Packaging Packaging { get; set; }
        [JsonProperty(PropertyName = "Dimensions")]
        public Dimensions Dimensions { get; set; }
        [JsonProperty(PropertyName = "DimWeight")]
        public DimWeight DimWeight { get; set; }
        [JsonProperty(PropertyName = "PackageWeight")]
        public PackageWeight PackageWeight { get; set; }
        [JsonProperty(PropertyName = "LargePackageIndicator")]
        public string LargePackageIndicator { get; set; }
        [JsonProperty(PropertyName = "OversizeIndicator")]
        public string OversizeIndicator { get; set; }
        [JsonProperty(PropertyName = "MinimumBillableWeightIndicator")]
        public string MinimumBillableWeightIndicator { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<ReferenceNumber>))]
        [JsonProperty(PropertyName = "ReferenceNumber")]
        public List<ReferenceNumber> ReferenceNumber { get; set; }
        [JsonProperty(PropertyName = "AdditionalHandlingIndicator")]
        public string AdditionalHandlingIndicator { get; set; }
        [JsonProperty(PropertyName = "SimpleRate")]
        public SimpleRate SimpleRate { get; set; }
        [JsonProperty(PropertyName = "UPSPremier")]
        public UPSPremier UPSPremier { get; set; }
        [JsonProperty(PropertyName = "PackageServiceOptions")]
        public PackageServiceOptions PackageServiceOptions { get; set; }
        [JsonProperty(PropertyName = "Commodity")]
        public Commodity Commodity { get; set; }
        [JsonProperty(PropertyName = "HazMatPackageInformation")]
        public HazMatPackageInformation HazMatPackageInformation { get; set; }
    }
}
