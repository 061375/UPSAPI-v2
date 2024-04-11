using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class HazMat
    {
        [JsonProperty(PropertyName = "PackagingTypeQuantity")]
        public string PackagingTypeQuantity { get; set; }
        [JsonProperty(PropertyName = "RecordIdentifier1")]
        public string RecordIdentifier1 { get; set; }
        [JsonProperty(PropertyName = "RecordIdentifier2")]
        public string RecordIdentifier2 { get; set; }
        [JsonProperty(PropertyName = "RecordIdentifier3")]
        public string RecordIdentifier3 { get; set; }
        [JsonProperty(PropertyName = "SubRiskClass")]
        public string SubRiskClass { get; set; }
        [JsonProperty(PropertyName = "aDRItemNumber")]
        public string aDRItemNumber { get; set; }
        [JsonProperty(PropertyName = "aDRPackingGroupLetter")]
        public string aDRPackingGroupLetter { get; set; }
        [JsonProperty(PropertyName = "TechnicalName")]
        public string TechnicalName { get; set; }
        [JsonProperty(PropertyName = "HazardLabelRequired")]
        public string HazardLabelRequired { get; set; }
        [JsonProperty(PropertyName = "ClassDivisionNumber")]
        public string ClassDivisionNumber { get; set; }
        [JsonProperty(PropertyName = "ReferenceNumber")]
        public string ReferenceNumber { get; set; }
        [JsonProperty(PropertyName = "Quantity")]
        public string Quantity { get; set; }
        [JsonProperty(PropertyName = "UOM")]
        public string UOM { get; set; }
        [JsonProperty(PropertyName = "PackagingType")]
        public string PackagingType { get; set; }
        [JsonProperty(PropertyName = "IDNumber")]
        public string IDNumber { get; set; }
        [JsonProperty(PropertyName = "ProperShippingName")]
        public string ProperShippingName { get; set; }
        [JsonProperty(PropertyName = "AdditionalDescription")]
        public string AdditionalDescription { get; set; }
        [JsonProperty(PropertyName = "PackagingGroupType")]
        public string PackagingGroupType { get; set; }
        [JsonProperty(PropertyName = "PackagingInstructionCode")]
        public string PackagingInstructionCode { get; set; }
        [JsonProperty(PropertyName = "EmergencyPhone")]
        public string EmergencyPhone { get; set; }
        [JsonProperty(PropertyName = "EmergencyContact")]
        public string EmergencyContact { get; set; }
        [JsonProperty(PropertyName = "ReportableQuantity")]
        public string ReportableQuantity { get; set; }
        [JsonProperty(PropertyName = "RegulationSet")]
        public string RegulationSet { get; set; }
        [JsonProperty(PropertyName = "TransportationMode")]
        public string TransportationMode { get; set; }
        [JsonProperty(PropertyName = "CommodityRegulatedLevelCode")]
        public string CommodityRegulatedLevelCode { get; set; }
        [JsonProperty(PropertyName = "TransportCategory")]
        public string TransportCategory { get; set; }
        [JsonProperty(PropertyName = "TunnelRestrictionCode")]
        public string TunnelRestrictionCode { get; set; }
        [JsonProperty(PropertyName = "ChemicalRecordIdentifier")]
        public string ChemicalRecordIdentifier { get; set; }
        [JsonProperty(PropertyName = "LocalTechnicalName")]
        public string LocalTechnicalName { get; set; }
        [JsonProperty(PropertyName = "LocalProperShippingName")]
        public string LocalProperShippingName { get; set; }

    }
}
