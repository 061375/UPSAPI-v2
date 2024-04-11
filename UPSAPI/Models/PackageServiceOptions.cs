using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class PackageServiceOptions
    {
        [JsonProperty(PropertyName = "DeliveryConfirmation")]
        public DeliveryConfirmation DeliveryConfirmation { get; set; }
        [JsonProperty(PropertyName = "DeclaredValue")]
        public DeclaredValue DeclaredValue { get; set; }
        [JsonProperty(PropertyName = "COD")]
        public COD COD { get; set; }
        [JsonProperty(PropertyName = "AccessPointCOD")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public AccessPointCOD AccessPointCOD { get; set; }
        [JsonProperty(PropertyName = "ShipperReleaseIndicator")]
        public string ShipperReleaseIndicator { get; set; }
        [JsonProperty(PropertyName = "Notification")]
        public Notification Notification { get; set; }
        [JsonProperty(PropertyName = "HazMat")]
        public List<HazMat> HazMat { get; set; }
        [JsonProperty(PropertyName = "DryIce")]
        public DryIce DryIce { get; set; }
        [JsonProperty(PropertyName = "UPSPremiumCareIndicator")]
        public string UPSPremiumCareIndicator { get; set; }
        [JsonProperty(PropertyName = "ProactiveIndicator")]
        public string ProactiveIndicator { get; set; }
        [JsonProperty(PropertyName = "PackageIdentifier")]
        public string PackageIdentifier { get; set; }
        [JsonProperty(PropertyName = "ClinicalTrialsID")]
        public string ClinicalTrialsID { get; set; }
        [JsonProperty(PropertyName = "RefrigerationIndicator")]
        public string RefrigerationIndicator { get; set; }
    }
}
