using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models
{
    internal class Shipment
    {
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Shipper")]
        public Shipper Shipper { get; set; }
        [JsonProperty(PropertyName = "ShipTo")]
        public ShipTo ShipTo { get; set; }
        [JsonProperty(PropertyName = "ShipFrom")]
        public ShipFrom ShipFrom { get; set; }
        [JsonProperty(PropertyName = "PaymentInformation")]
        public PaymentInformation PaymentInformation { get; set; }
        [JsonProperty(PropertyName = "GoodsNotInFreeCirculationIndicator")]
        public string GoodsNotInFreeCirculationIndicator { get; set; }
        [JsonProperty(PropertyName = "PromotionalDiscountInformation")]
        public PromotionalDiscountInformation PromotionalDiscountInformation { get; set; }
        [JsonProperty(PropertyName = "DGSignatoryInfo")]
        public DGSignatoryInfo DGSignatoryInfo { get; set; }
        [JsonProperty(PropertyName = "ShipmentRatingOptions")]
        public ShipmentRatingOptions ShipmentRatingOptions { get; set; }
        [JsonProperty(PropertyName = "MovementReferenceNumber")]
        public string MovementReferenceNumber { get; set; }
        [JsonProperty(PropertyName = "ReferenceNumber")]
        public List<ReferenceNumber> ReferenceNumber { get; set; }
        [JsonProperty(PropertyName = "Service")]
        public Service Service { get; set; }
        [JsonProperty(PropertyName = "InvoiceLineTotal")]
        public List<InvoiceLineTotal> InvoiceLineTotal { get; set; }
        [JsonProperty(PropertyName = "NumOfPiecesInShipment")]
        public string NumOfPiecesInShipment { get; set; }
        [JsonProperty(PropertyName = "USPSEndorsement")]
        public string USPSEndorsement { get; set; }
        [JsonProperty(PropertyName = "MILabelCN22Indicator")]
        public string MILabelCN22Indicator { get; set; }
        [JsonProperty(PropertyName = "SubClassification")]
        public string SubClassification { get; set; }
        [JsonProperty(PropertyName = "CostCenter")]
        public string CostCenter { get; set; }
        [JsonProperty(PropertyName = "CostCenterBarcodeIndicator")]
        public string CostCenterBarcodeIndicator { get; set; }
        [JsonProperty(PropertyName = "PackageID")]
        public string PackageID { get; set; }
        [JsonProperty(PropertyName = "PackageIDBarcodeIndicator")]
        public string PackageIDBarcodeIndicator { get; set; }
        [JsonProperty(PropertyName = "IrregularIndicator")]
        public string IrregularIndicator { get; set; }
        [JsonProperty(PropertyName = "ShipmentIndicationType")]
        public ShipmentIndicationType ShipmentIndicationType { get; set; }
        [JsonProperty(PropertyName = "MIDualReturnShipmentKey")]
        public string MIDualReturnShipmentKey { get; set; }
        [JsonProperty(PropertyName = "MIDualReturnShipmentIndicator")]
        public string MIDualReturnShipmentIndicator { get; set; }
        [JsonProperty(PropertyName = "RatingMethodRequestedIndicator")]
        public string RatingMethodRequestedIndicator { get; set; }
        [JsonProperty(PropertyName = "TaxInformationIndicator")]
        public string TaxInformationIndicator { get; set; }
        [JsonProperty(PropertyName = "ShipmentServiceOptions")]
        public ShipmentServiceOptions ShipmentServiceOptions { get; set; }
        [JsonProperty(PropertyName = "Locale")]
        public string Locale { get; set; }
        [JsonProperty(PropertyName = "ShipmentValueThresholdCode")]
        public string ShipmentValueThresholdCode { get; set; }
        [JsonProperty(PropertyName = "MasterCartonID")]
        public string MasterCartonID { get; set; }
        [JsonProperty(PropertyName = "MasterCartonIndicator")]
        public string MasterCartonIndicator { get; set; }
        [JsonProperty(PropertyName = "ShipmentDate")]
        public string ShipmentDate { get; set; }
        [JsonProperty(PropertyName = "Package")]
        public List<Package> Package { get; set; }
        [JsonProperty(PropertyName = "LabelSpecification")]
        public List<LabelSpecification> LabelSpecification { get; set; }
        [JsonProperty(PropertyName = "ReceiptSpecification")]
        public List<ReceiptSpecification> ReceiptSpecification { get; set; }
    }
}
