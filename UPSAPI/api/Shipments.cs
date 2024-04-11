using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPSAPIv2.Models;
using System.Runtime.InteropServices;
using UPSAPIv2.Models.Properties;

namespace UPSAPIv2.api
{
    public class Shipments
    {
        private Models._Root root = new Models._Root();
        private Models.ShipmentRequest request = new Models.ShipmentRequest();
        private bool bLabelParameters = false;
        private bool bReceiptParameters = false;

        /// <summary>
        /// convert the shipmentsd request into a JSON string
        /// </summary>
        /// <returns>string</returns>
        public string GetJson()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new IgnoreEmptyObjectContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(root, settings);
        }
        public bool CreateShipment(ShipmentProperties shipmentProperies)
        {
            try
            {
                string RefNumber = shipmentProperies.RefNumber;
                string Service = shipmentProperies.Service;

                // validate
                if (string.IsNullOrEmpty(shipmentProperies.Service)) { Helpers.RecordError(Messages.Errors["required"], "Service"); return false; }
                if (!ValidateShipment(shipmentProperies.ShipTo)) return false;
                if (!ValidateShipmentCharges(shipmentProperies.ShipmentCharges)) return false;
                if (!ValidatePackages(shipmentProperies.Packages)) return false;
                if (!ValidateLabelParameters(shipmentProperies.LabelParameters)) return false;
                if (!ValidateReceiptParameters(shipmentProperies.ReceiptParameters)) return false;
                // * validate


                // build shipment
                GetRequest();
                GetShipment();
                GetShipper();
                GetShipTo(shipmentProperies.ShipTo);
                GetShipFrom(shipmentProperies.ShipFrom);
                if (!GetPackages(shipmentProperies.Packages)) return false;
                if (!GetService(shipmentProperies.Service)) return false;
                if (!GetShipmentCharges(shipmentProperies.ShipmentCharges)) return false;
                if (!GetLabelSpecification(shipmentProperies.LabelParameters)) return false;
                if (!GetReceiptSpecification(shipmentProperies.ReceiptParameters)) return false;

                root.ShipmentRequest = request;

                return true;
            }
            catch (Exception e)
            {
                Libs.Helpers.LogError(e.ToString());
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipmentParams"></param>
        /// <returns></returns>
        public bool CreateShipment(ShipmentParams shipmentParams)
        {
            try
            {
                // validate
                if (!Helpers.isnull(shipmentParams.Service, Messages.Errors["required"], "shipmentParams.Service")) return false;
                if(null == shipmentParams.ShipTo)
                {
                    Helpers.RecordError(Messages.Errors["required"], "shipmentParams.ShipTo");
                    return false;
                }
                if (null == shipmentParams.Packages)
                {
                    Helpers.RecordError(Messages.Errors["required"], "shipmentParams.Packages");
                    return false;
                }
                if (null == shipmentParams.ShipmentCharges)
                {
                    Helpers.RecordError(Messages.Errors["required"], "shipmentParams.ShipmentCharges");
                    return false;
                }

                // !validate

                Helpers.InitDict(ref shipmentParams.ShipTo,Models.Columns.Shipments.ShipToFrom);
                ShipmentProperties shipmentProperies = new ShipmentProperties();
                shipmentProperies.Service = shipmentParams.Service;
                shipmentProperies.ShipTo.Name = shipmentParams.ShipTo["Name"];
                shipmentProperies.ShipTo.AttentionName = shipmentParams.ShipTo["AttentionName"];
                shipmentProperies.ShipTo.Phone = shipmentParams.ShipTo["Phone"];
                shipmentProperies.ShipTo.FaxNumber = shipmentParams.ShipTo["FaxNumber"];
                shipmentProperies.ShipTo.Address1 = shipmentParams.ShipTo["Address1"];
                shipmentProperies.ShipTo.Address2 = shipmentParams.ShipTo["Address2"];
                shipmentProperies.ShipTo.Address3 = shipmentParams.ShipTo["Address3"];
                shipmentProperies.ShipTo.City = shipmentParams.ShipTo["City"];
                shipmentProperies.ShipTo.State = shipmentParams.ShipTo["State"];
                shipmentProperies.ShipTo.Zip = shipmentParams.ShipTo["Zip"];
                shipmentProperies.ShipTo.Country = Libs.Helpers.isset(shipmentParams.ShipTo, "Country", Params.DefaultCountry);
                
                if (null != shipmentParams.ShipFrom)
                {
                    Helpers.InitDict(ref shipmentParams.ShipFrom, Models.Columns.Shipments.ShipToFrom);
                    shipmentProperies.ShipFrom.Name = shipmentParams.ShipFrom["Name"];
                    shipmentProperies.ShipFrom.AttentionName = shipmentParams.ShipFrom["AttentionName"];
                    shipmentProperies.ShipFrom.Phone = shipmentParams.ShipFrom["Phone"];
                    shipmentProperies.ShipFrom.FaxNumber = shipmentParams.ShipFrom["FaxNumber"];
                    shipmentProperies.ShipFrom.Address1 = shipmentParams.ShipFrom["Address1"];
                    shipmentProperies.ShipFrom.Address2 = shipmentParams.ShipFrom["Address2"];
                    shipmentProperies.ShipFrom.Address3 = shipmentParams.ShipFrom["Address3"];
                    shipmentProperies.ShipFrom.City = shipmentParams.ShipFrom["City"];
                    shipmentProperies.ShipFrom.State = shipmentParams.ShipFrom["State"];
                    shipmentProperies.ShipFrom.Zip = shipmentParams.ShipFrom["Zip"];
                    shipmentProperies.ShipFrom.Country = Libs.Helpers.isset(shipmentParams.ShipFrom, "Country",Params.DefaultCountry);
                }
                shipmentProperies.Packages = new List<Models.Properties.Packages>();
                foreach (Dictionary<string, string> Package in shipmentParams.Packages)
                {
                    Dictionary<string, string> tmpPackage = Package;
                    Helpers.InitDict(ref tmpPackage, Models.Columns.Shipments.Package);
                    Models.Properties.Packages tmp = new Models.Properties.Packages();
                    tmp.Description = tmpPackage["Description"];
                    tmp.PalletDescription = tmpPackage["PalletDescription"];
                    tmp.NumOfPieces = Libs.Helpers.GetToInt32(tmpPackage["NumOfPieces"]);
                    tmp.UnitPrice = Libs.Helpers.GetToInt32(tmpPackage["UnitPrice"]);
                    tmp.PackagingType = tmpPackage["PackagingType"];
                    tmp.PackagingDescription = tmpPackage["PackagingDescription"];
                    tmp.UnitOfLengthMeasurement = tmpPackage["UnitOfLengthMeasurement"];
                    tmp.UnitOfMeasurementDescription = tmpPackage["UnitOfMeasurementDescription"];
                    tmp.DimensionsLength = Libs.Helpers.GetToInt32(tmpPackage["DimensionsLength"]);
                    tmp.DimensionsWidth = Libs.Helpers.GetToInt32(tmpPackage["DimensionsWidth"]);
                    tmp.DimensionsHeight = Libs.Helpers.GetToInt32(tmpPackage["DimensionsHeight"]);
                    tmp.UnitOfWeightMeasurement = tmpPackage["UnitOfWeightMeasurement"];
                    tmp.DimWeight = Libs.Helpers.GetToDecimal(tmpPackage["DimWeight"]);
                    tmp.PackageWeightUnitOfMeasurement = tmpPackage["PackageWeightUnitOfMeasurement"];
                    tmp.PackageWeight = Libs.Helpers.GetToDouble(tmpPackage["PackageWeight"]);
                    tmp.LargePackageIndicator = tmpPackage["LargePackageIndicator"];
                    tmp.OversizeIndicator = tmpPackage["OversizeIndicator"];
                    tmp.MinimumBillableWeightIndicator = tmpPackage["MinimumBillableWeightIndicator"];
                    tmp.AdditionalHandlingIndicator = tmpPackage["AdditionalHandlingIndicator"];
                    tmp.ReferenceNumber = tmpPackage["ReferenceNumber"];
                    tmp.BarCodeIndicator = tmpPackage["BarCodeIndicator"];
                    tmp.SimpleRate = tmpPackage["SimpleRate"];
                    tmp.UPSPremier = tmpPackage["UPSPremier"];
                    tmp.UPSPremierSensorID = tmpPackage["UPSPremierSensorID"];
                    tmp.UPSPremierHandlingInstructions = tmpPackage["UPSPremierHandlingInstructions"];
                    tmp.PackageServiceOptions = tmpPackage["PackageServiceOptions"];
                    tmp.DeliveryConfirmation = tmpPackage["DeliveryConfirmation"];
                    tmp.DCISType = tmpPackage["DCISType"];
                    tmp.DCISNumber = tmpPackage["DCISNumber"];
                    tmp.DeclaredValue = tmpPackage["DeclaredValue"];
                    tmp.DeclaredValueCode = tmpPackage["DeclaredValueCode"];
                    tmp.DeclaredValuePrice = tmpPackage["DeclaredValuePrice"];
                    tmp.COD = tmpPackage["COD"];
                    tmp.CODFundsCode = tmpPackage["CODFundsCode"];
                    tmp.CODCurrencyCode = tmpPackage["CODCurrencyCode"];
                    tmp.CODPrice = tmpPackage["CODPrice"];
                    tmp.AccessPointCOD = tmpPackage["AccessPointCOD"];
                    tmp.AccessPointCODCode = tmpPackage["AccessPointCODCode"];
                    tmp.AccessPointCODPrice = tmpPackage["AccessPointCODPrice"];
                    tmp.ShipperReleaseIndicator = tmpPackage["ShipperReleaseIndicator"];
                    tmp.Notification = tmpPackage["Notification"];
                    tmp.NotificationCode = tmpPackage["NotificationCode"];
                    tmp.EmailSubjectCode = tmpPackage["EmailSubjectCode"];
                    tmp.EmailAddress = tmpPackage["EmailAddress"];
                    tmp.EmailSubject = tmpPackage["EmailSubject"];
                    tmp.FromEMailAddress = tmpPackage["FromEMailAddress"];
                    tmp.FromEMailName = tmpPackage["FromEMailName"];
                    tmp.UndeliverableEMailAddress = tmpPackage["UndeliverableEMailAddress"];
                    tmp.EMailMemo = tmpPackage["EMailMemo"];
                    tmp.HazMat = tmpPackage["HazMat"];
                    tmp.HazMatQty = tmpPackage["HazMatQty"];
                    tmp.HazMatID1 = tmpPackage["HazMatID1"];
                    tmp.HazMatID2 = tmpPackage["HazMatID2"];
                    tmp.HazMatID3 = tmpPackage["HazMatID3"];
                    tmp.NumHazMatPackages = Libs.Helpers.GetToInt32(tmpPackage["NumHazMatPackages"]);
                    tmp.HazMatSubRiskClass = tmpPackage["HazMatSubRiskClass"];
                    tmp.HazMataDRItemNumber = tmpPackage["HazMataDRItemNumber"];
                    tmp.HazMatPackingGroup = tmpPackage["HazMatPackingGroup"];
                    tmp.HazMatTechnicalName = tmpPackage["HazMatTechnicalName"];
                    tmp.HazMatHazardLabelRequired = tmpPackage["HazMatHazardLabelRequired"];
                    tmp.HazMatClassDivisionNumber = tmpPackage["HazMatClassDivisionNumber"];
                    tmp.HazMatReferenceNumber = tmpPackage["HazMatReferenceNumber"];
                    tmp.HazMatQuantity = tmpPackage["HazMatQuantity"];
                    tmp.UOM = tmpPackage["UOM"];
                    tmp.HazMatPackagingType = tmpPackage["HazMatPackagingType"];
                    tmp.IDNumber = tmpPackage["IDNumber"];
                    tmp.HazMatProperShippingName = tmpPackage["HazMatProperShippingName"];
                    tmp.HazMatAdditionalDescription = tmpPackage["HazMatAdditionalDescription"];
                    tmp.HazMatEmergencyPhone = tmpPackage["HazMatEmergencyPhone"];
                    tmp.HazMatEmergencyContact = tmpPackage["HazMatEmergencyContact"];
                    tmp.HazMatReportableQuantity = tmpPackage["HazMatReportableQuantity"];
                    tmp.HazMatRegulationSet = tmpPackage["HazMatRegulationSet"];
                    tmp.HazMatTransportationMode = tmpPackage["HazMatTransportationMode"];
                    tmp.HazMatCommodityRegulatedLevelCode = tmpPackage["HazMatCommodityRegulatedLevelCode"];
                    tmp.HazMatTransportCategory = tmpPackage["HazMatTransportCategory"];
                    tmp.HazMatTunnelRestrictionCode = tmpPackage["HazMatTunnelRestrictionCode"];
                    tmp.HazMatChemicalRecordIdentifier = tmpPackage["ChemicalRecordIdentifier"];
                    tmp.HazMatLocalTechnicalName = tmpPackage["LocalTechnicalName"];
                    tmp.HazMatLocalProperShippingName = tmpPackage["LocalProperShippingName"];
                    tmp.DryIce = tmpPackage["DryIce"];
                    tmp.DryIceRegulationSet = tmpPackage["DryIceRegulationSet"];
                    tmp.DryIceUnitOfWeightMeasurement = tmpPackage["DryIceUnitOfWeightMeasurement"];
                    tmp.DryIceWeight = Libs.Helpers.GetToDecimal(tmpPackage["DryIceWeight"]);
                    tmp.DryIceMedicalUseIndicator = tmpPackage["DryIceMedicalUseIndicator"];
                    tmp.UPSPremiumCareIndicator = tmpPackage["UPSPremiumCareIndicator"];
                    tmp.ProactiveIndicator = tmpPackage["ProactiveIndicator"];
                    tmp.PackageIdentifier = tmpPackage["PackageIdentifier"];
                    tmp.ClinicalTrialsID = tmpPackage["ClinicalTrialsID"];
                    tmp.RefrigerationIndicator = tmpPackage["RefrigerationIndicator"];
                    tmp.Commodity = tmpPackage["Commodity"];
                    tmp.PrimeCode = tmpPackage["PrimeCode"];
                    tmp.FreightClass = tmpPackage["FreightClass"];
                    tmp.NMFCPrimeCode = tmpPackage["NMFCSubCode"];
                    tmp.NMFCSubCode = tmpPackage["NMFCSubCode"];
                    tmp.HazMatPackageInformation = tmpPackage["HazMatPackageInformation"];
                    tmp.HazMatAllPackedInOneIndicator = tmpPackage["HazMatAllPackedInOneIndicator"];
                    tmp.HazMatOverPackedIndicator = tmpPackage["HazMatOverPackedIndicator"];
                    tmp.HazMatQValue = tmpPackage["HazMatQValue"];
                    tmp.HazMatOuterPackagingType = tmpPackage["HazMatOuterPackagingType"];
                    shipmentProperies.Packages.Add(tmp);
                }
                if (null != shipmentParams.LabelParameters)
                {
                    Helpers.InitDict(ref shipmentParams.LabelParameters, Models.Columns.Shipments.LabelParameters);
                    shipmentProperies.LabelParameters.LabelSpecification = shipmentParams.LabelParameters["LabelSpecification"];
                    shipmentProperies.LabelParameters.LabelParametersDescription = shipmentParams.LabelParameters["LabelParametersDescription"];
                    shipmentProperies.LabelParameters.LabelCharacterSet = shipmentParams.LabelParameters["LabelCharacterSet"];
                    shipmentProperies.LabelParameters.LabelWidth = shipmentParams.LabelParameters["LabelWidth"];
                    shipmentProperies.LabelParameters.LabelHeight = shipmentParams.LabelParameters["LabelHeight"];
                    shipmentProperies.LabelParameters.LabelInstructionCode = shipmentParams.LabelParameters["LabelInstructionCode"];
                    shipmentProperies.LabelParameters.LabelImageFormatCode = shipmentParams.LabelParameters["LabelImageFormatCode"];
                }
                if (null != shipmentParams.LabelParameters) { 
                    shipmentProperies.ReceiptParameters.ReceiptSpecification = Libs.Helpers.isset(shipmentParams.ReceiptParameters, "ReceiptSpecification");
                    shipmentProperies.ReceiptParameters.ReceiptParametersDescription = Libs.Helpers.isset(shipmentParams.ReceiptParameters, "ReceiptParametersDescription");
                    shipmentProperies.ReceiptParameters.ReceiptImageFormatCode = Libs.Helpers.isset(shipmentParams.ReceiptParameters, "ReceiptImageFormatCode");
                }
                shipmentProperies.ShipmentCharges = new List<Models.Properties.ShipmentCharges>();
                foreach (Dictionary<string, string> ShipmentCharge in shipmentParams.ShipmentCharges)
                {
                    Dictionary<string, string> tmpShipmentCharge = ShipmentCharge;
                    Helpers.InitDict(ref tmpShipmentCharge, Models.Columns.Shipments.ShipmentCharge);
                    Models.Properties.ShipmentCharges tmp = new Models.Properties.ShipmentCharges();
                    tmp.Type = tmpShipmentCharge["Type"];
                    tmp.AccountNumber = tmpShipmentCharge["AccountNumber"];
                    tmp.AlternatePaymentMethod = tmpShipmentCharge["AlternatePaymentMethod"];
                    tmp.BillShipper = tmpShipmentCharge["BillShipper"];
                    tmp.BillThirdParty = tmpShipmentCharge["BillThirdParty"];
                    tmp.BillReceiver = tmpShipmentCharge["BillReceiver"];
                    tmp.BillReceiverAddress1 = tmpShipmentCharge["BillReceiverAddress1"];
                    tmp.BillReceiverAddress2 = tmpShipmentCharge["BillReceiverAddress2"];
                    tmp.BillReceiverAddress3 = tmpShipmentCharge["BillReceiverAddress3"];
                    tmp.BillThirdPartyAddress1 = tmpShipmentCharge["BillThirdPartyAddress1"];
                    tmp.BillThirdPartyAddress2 = tmpShipmentCharge["BillThirdPartyAddress1"];
                    tmp.BillThirdPartyAddress1 = tmpShipmentCharge["BillThirdPartyAddress1"];
                    tmp.CertifiedElectronicMail = tmpShipmentCharge["CertifiedElectronicMail"];
                    tmp.ConsigneeBilledIndicator = tmpShipmentCharge["ConsigneeBilledIndicator"];
                    tmp.CreditCard = tmpShipmentCharge["CreditCard"];
                    tmp.CreditCardBillingAddress = tmpShipmentCharge["CreditCardBillingAddress"];
                    tmp.CreditCardSecurityCode = tmpShipmentCharge["CreditCardSecurityCode"];
                    tmp.CreditCardType = tmpShipmentCharge["CreditCardType"];
                    tmp.InterchangeSystemCode = tmpShipmentCharge["InterchangeSystemCode"];
                    shipmentProperies.ShipmentCharges.Add(tmp);
                }
                
                
                return CreateShipment(shipmentProperies);
            }
            catch (Exception e)
            {
                Libs.Helpers.LogError(e.ToString());
                return false;
            }
        }
        ///
        /// 
        /// VALIDATION ------------------------------- >
        /// 
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShipTo"></param>
        /// <returns></returns>
        private bool ValidateShipment(Models.Properties.ShipTo _ShipTo)
        {
            bool _return = true;

            if (!Helpers.required(_ShipTo.Name, "Name")) _return = false;
            if (!Helpers.required(_ShipTo.Address1, "Address1")) _return = false;
            if (!Helpers.required(_ShipTo.City, "City")) _return = false;
            if (!Helpers.required(_ShipTo.State, "State")) _return = false;
            if (!Helpers.required(_ShipTo.Zip, "Zip")) _return = false;

            return _return;
        }
        private bool ValidateShipment(Dictionary<string, string> ShipTo)
        {
            if (null == ShipTo)
            {
                Helpers.RecordError(Messages.Errors["required"], "ShipTo");
                return false;
            }
            bool _return = true;
            if (!Helpers.isset(ShipTo, "Name", Messages.Errors["required"], "ShipTo")) _return = false;
            if (!Helpers.isset(ShipTo, "Address1", Messages.Errors["required"], "ShipTo")) _return = false;
            if (!Helpers.isset(ShipTo, "City", Messages.Errors["required"], "ShipTo")) _return = false;
            if (!Helpers.isset(ShipTo, "State", Messages.Errors["required"], "ShipTo")) _return = false;
            if (!Helpers.isset(ShipTo, "Zip", Messages.Errors["required"], "ShipTo")) _return = false;
            return _return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Packages"></param>
        /// <returns></returns>
        private bool ValidatePackages(List<Models.Properties.Packages> Packages)
        {
            if (null == Packages || Packages.Count == 0)
            {
                Helpers.RecordError(Messages.Errors["required"], "Packages");
                return false;
            }
            return true;
        }
        private bool ValidateShipmentCharges(List<Models.Properties.ShipmentCharges> ShipmentCharges)
        {
            if(null == ShipmentCharges || ShipmentCharges.Count == 0)
            {
                Helpers.RecordError(Messages.Errors["required"], "ShipmentCharges");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LabelParameters"></param>
        /// <returns></returns>
        private bool ValidateLabelParameters(Models.Properties.LabelParameters LabelParameters)
        {
            if (string.IsNullOrEmpty(LabelParameters.LabelSpecification)) return true;
            if (!Helpers.isnull(LabelParameters.LabelImageFormatCode, Messages.Errors["requiredif"], "LabelImageFormatCode")) return false;
            if (!Helpers.Contains(Validation.LabelImageFormat, Messages.Errors["requiredif"],LabelParameters.LabelImageFormatCode, 
                "LabelImageFormatCode", "LabelParameters")) return false;
            if (!Helpers.isnull(LabelParameters.LabelHeight, Messages.Errors["requiredif"], "LabelHeight")) return false;
            if (!Helpers.isnull(LabelParameters.LabelWidth, Messages.Errors["requiredif"], "LabelWidth")) return false;
            if (!Helpers.isnull(LabelParameters.LabelInstructionCode, Messages.Errors["requiredif"], "LabelInstructionCode")) return false;
            if (!Helpers.issetif(Validation.LabelInstructions, Messages.Errors["requiredif"], LabelParameters.LabelInstructionCode, "LabelParameters", "LabelInstructionCode")) return false;
            if(!string.IsNullOrEmpty(LabelParameters.LabelCharacterSet))
                if (!Helpers.issetif(Validation.LabelCharacterSet, Messages.Errors["requiredif"], LabelParameters.LabelCharacterSet, "LabelParameters", "LabelCharacterSet")) return false;


            // if true then I don't need to validate again
            bLabelParameters = true;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReceiptParameters"></param>
        /// <returns></returns>
        private bool ValidateReceiptParameters(Models.Properties.ReceiptParameters ReceiptParameters)
        {
            if (string.IsNullOrEmpty(ReceiptParameters.ReceiptSpecification)) return true;
            if (!Helpers.Contains(Validation.ReceiptImageFormat, Messages.Errors["requiredif"], 
                ReceiptParameters.ReceiptImageFormatCode,
                "ReceiptImageFormatCode", "ReceiptParameters")) return false;
            bReceiptParameters = true;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool ValidateCC(Models.Properties.ShipmentCharges data)
        {
            if (!Helpers.isnull(data.CreditCardType, Messages.Errors["required"], "CreditCardType")) return false;
            if (!Helpers.isnull(data.CreditCardNumber, Messages.Errors["required"], "CreditCardNumber")) return false;
            if (!Helpers.isnull(data.CreditCardSecurityCode, Messages.Errors["required"], "CreditCardSecurityCode")) return false;
            if (!Helpers.isnull(data.CreditCardBillingAddress, Messages.Errors["required"], "CreditCardBillingAddress")) return false;
            if (!Helpers.isnull(data.CreditCardType, Messages.Errors["notrec"], "CreditCardType")) return false;
            return true;
        }
        ///
        /// 
        /// END VALIDATION < ----------------------------
        /// 
        /// 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LabelParameters"></param>
        /// <returns></returns>
        private bool GetLabelSpecification(Models.Properties.LabelParameters LabelParameters)
        {
            if (!bLabelParameters) return true;
            request.Shipment.LabelSpecification = new List<LabelSpecification>();
            LabelSpecification tmp = new LabelSpecification();
            tmp.LabelImageFormat.Code = LabelParameters.LabelImageFormatCode;
            tmp.HTTPUserAgent = LabelParameters.HTTPUserAgent;
            tmp.LabelStockSize = new LabelStockSize();
            tmp.LabelStockSize.Height = LabelParameters.LabelHeight.ToString();
            tmp.LabelStockSize.Width = LabelParameters.LabelWidth.ToString();
            tmp.Instruction = new Instruction();
            tmp.Instruction.Code = LabelParameters.LabelInstructionCode;
            tmp.Instruction.Description = LabelParameters.LabelParametersDescription;
            tmp.CharacterSet = LabelParameters.LabelCharacterSet;
            request.Shipment.LabelSpecification.Add(tmp);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReceiptParameters"></param>
        /// <returns></returns>
        private bool GetReceiptSpecification(Models.Properties.ReceiptParameters ReceiptParameters)
        {
            if (!bReceiptParameters) return true;
            request.Shipment.ReceiptSpecification = new List<ReceiptSpecification>();
            ReceiptSpecification tmp = new ReceiptSpecification();
            tmp.ImageFormat = new ImageFormat();
            tmp.ImageFormat.Code = ReceiptParameters.ReceiptImageFormatCode;
            tmp.ImageFormat.Description = ReceiptParameters.ReceiptParametersDescription;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Packages"></param>
        /// <returns></returns>
        private bool GetPackages(List<Models.Properties.Packages> Packages)
        {
            request.Shipment.Package = new List<Package>();
            int NumHazMatPackages = 0;
            bool HazMatPackageInformation = false;
            foreach (Models.Properties.Packages p in Packages)
            {
                // validate
                if (!Helpers.isnull(p.PackagingType, Messages.Errors["required"])) return false;
                if (!Helpers.isset(Validation.PackagingType, p.PackagingType, Messages.Errors["notrec"], "PackagingType", true)) return false;
                string UnitOfLengthMeasurement = Helpers.isnullelse(p.UnitOfLengthMeasurement, Params.UnitOfLengthMeasurement);
                if (!Helpers.isset(Validation.UnitOfLengthMeasurement, p.UnitOfLengthMeasurement, Messages.Errors["required"], "UnitOfLengthMeasurement", true)) return false;
                double PackageWeight = p.PackageWeight;
                if(PackageWeight <= 0)
                {
                    Helpers.RecordError(Messages.Errors["minmax"], "0", "PackageWeight");
                    return false;
                }
                List<int> minmax = Validation.VUnitOfLengthMeasurement[UnitOfLengthMeasurement];
                int Length = p.DimensionsLength;
                if (!Helpers.MinMaxValid(Length, minmax,Messages.Errors["minmax"], "DimensionsLength"))return false;
                int Width = p.DimensionsWidth;
                if (!Helpers.MinMaxValid(Width, minmax, Messages.Errors["minmax"], "DimensionsWidth"))return false;
                int Height = p.DimensionsHeight;
                if (!Helpers.MinMaxValid(Height, minmax,Messages.Errors["minmax"], "DimensionsHeight"))return false;
                string UnitOfWeightMeasurement = Helpers.isnullelse(p.UnitOfWeightMeasurement.ToString(), Params.UnitOfWeightMeasurement);
                if (!Helpers.isset(Validation.UnitOfWeightMeasurement, UnitOfWeightMeasurement, Messages.Errors["notrec"], "UnitOfWeightMeasurement", true)) return false;

                if (!string.IsNullOrEmpty(p.HazMat))
                {
                    if(p.NumHazMatPackages == 0)
                    {
                        Helpers.RecordError(Messages.Errors["requiredif"], "NumHazMatPackages", "HazMat"); return false;
                    }
                }
                // * validate

                
                Package tmp = new Package();
                tmp.Description = Helpers.isnullelse(p.Description);
                tmp.PalletDescription = Helpers.isnullelse(p.PalletDescription);
                tmp.NumOfPieces = Helpers.isnullelse(p.NumOfPieces.ToString());
                tmp.UnitPrice = p.UnitPrice.ToString();
                tmp.Packaging = new Packaging();
                tmp.Packaging.Code = p.PackagingType;
                tmp.Packaging.Description = Libs.Helpers.isset(Validation.PackagingType, p.PackagingType);
                tmp.Dimensions = new Dimensions();
                tmp.Dimensions.UnitOfMeasurement = new UnitOfMeasurement();
                tmp.Dimensions.UnitOfMeasurement.Code = UnitOfLengthMeasurement;
                tmp.Dimensions.UnitOfMeasurement.Description = Libs.Helpers.isset(Validation.UnitOfLengthMeasurement,UnitOfLengthMeasurement);
                tmp.Dimensions.Length = Length.ToString();
                tmp.Dimensions.Width = Width.ToString();
                tmp.Dimensions.Height = Height.ToString();
                tmp.DimWeight = new DimWeight();
                tmp.DimWeight.UnitOfMeasurement = new UnitOfMeasurement();
                tmp.DimWeight.UnitOfMeasurement.Code = UnitOfWeightMeasurement;
                tmp.DimWeight.Weight = p.DimWeight.ToString();
                tmp.PackageWeight = new PackageWeight();
                tmp.PackageWeight.UnitOfMeasurement = new UnitOfMeasurement();
                tmp.PackageWeight.UnitOfMeasurement.Code = UnitOfWeightMeasurement;
                tmp.PackageWeight.Weight = PackageWeight.ToString();

                // the doc says if these are SET with anything then that is a bool TRUE
                if (!string.IsNullOrEmpty(p.LargePackageIndicator))
                    tmp.LargePackageIndicator = "Y";
                if (!string.IsNullOrEmpty(p.OversizeIndicator))
                    tmp.OversizeIndicator = "Y";
                if (!string.IsNullOrEmpty(p.MinimumBillableWeightIndicator))
                    tmp.MinimumBillableWeightIndicator = "Y";
                if (!string.IsNullOrEmpty(p.AdditionalHandlingIndicator))
                    tmp.AdditionalHandlingIndicator = "Y";

                // currently only supporting 1 reference number @version 1.0.0.0
                if (!string.IsNullOrEmpty(p.ReferenceNumber))
                {
                    tmp.ReferenceNumber = new List<ReferenceNumber>();
                    ReferenceNumber tmpReferenceNumber = new ReferenceNumber();
                    if (!string.IsNullOrEmpty(p.BarCodeIndicator))
                        tmpReferenceNumber.BarCodeIndicator = "";
                    tmpReferenceNumber.Code = "";
                    tmpReferenceNumber.Value = p.ReferenceNumber;
                }
                if (!string.IsNullOrEmpty(p.SimpleRate))
                {
                    // validate
                    if (!Helpers.isset(Validation.SimpleRate, p.SimpleRate, Messages.Errors["simplerate"])) return false;
                    tmp.SimpleRate = new SimpleRate();
                    tmp.SimpleRate.Code = p.SimpleRate;
                }
                if (!string.IsNullOrEmpty(p.UPSPremier))
                {
                    // validate
                    if (!Helpers.isset(Validation.UPSPremier, p.UPSPremier, Messages.Errors["upspremier"])) return false;
                    if (!Helpers.isnull(p.UPSPremierSensorID,Messages.Errors["required"], "UPSPremierSensorID")) return false;
                    if (!Helpers.isnull(p.UPSPremierHandlingInstructions, Messages.Errors["required"], "UPSPremierHandlingInstructions")) return false;
                    // * validate
                    tmp.UPSPremier = new UPSPremier();
                    tmp.UPSPremier.Category = p.UPSPremier;
                    tmp.UPSPremier.SensorID = p.UPSPremierSensorID;
                    tmp.UPSPremier.HandlingInstructions = new HandlingInstructions();
                    tmp.UPSPremier.HandlingInstructions.Instruction = p.UPSPremierHandlingInstructions;
                }
                if (!string.IsNullOrEmpty(p.PackageServiceOptions))
                {
                    tmp.PackageServiceOptions = new PackageServiceOptions();
                    if (!string.IsNullOrEmpty(p.DeliveryConfirmation))
                    {
                        // validate
                        if (!Helpers.isset(Validation.DCISType, p.DCISType, Messages.Errors["delivconf"])) return false;
                        tmp.PackageServiceOptions.DeliveryConfirmation = new DeliveryConfirmation();
                        tmp.PackageServiceOptions.DeliveryConfirmation.DCISType = p.DCISType;
                        tmp.PackageServiceOptions.DeliveryConfirmation.DCISNumber = p.DCISNumber;
                    }
                    if (!string.IsNullOrEmpty(p.DeclaredValue))
                    {
                        // validate
                        if (!Helpers.isset(Validation.DeclaredValue, p.DeclaredValueCode, Messages.Errors["declareval"])) return false;
                        tmp.PackageServiceOptions.DeclaredValue = new DeclaredValue();
                        tmp.PackageServiceOptions.DeclaredValue.Type = new Models.Type();
                        tmp.PackageServiceOptions.DeclaredValue.Type.Code = p.DeclaredValueCode;
                        tmp.PackageServiceOptions.DeclaredValue.MonetaryValue = p.DeclaredValuePrice.ToString();
                    }
                    if (!string.IsNullOrEmpty(p.COD))
                    {
                        tmp.PackageServiceOptions.COD = new COD();
                        tmp.PackageServiceOptions.COD.CODFundsCode = p.CODFundsCode;
                        tmp.PackageServiceOptions.COD.CODAmount = new CODAmount();
                        tmp.PackageServiceOptions.COD.CODAmount.CurrencyCode = p.CODCurrencyCode;
                        tmp.PackageServiceOptions.COD.CODAmount.MonetaryValue = p.CODPrice;
                    }
                    if (!string.IsNullOrEmpty(p.AccessPointCOD))
                    {
                        // validate
                        if (!Helpers.isnull(p.AccessPointCODCode, Messages.Errors["required"], "AccessPointCODCode")) return false;
                        if (!Helpers.isnull(p.AccessPointCODPrice, Messages.Errors["required"], "AccessPointCODPrice")) return false;
                        if (!Helpers.isset(Validation.AccessPointCOD, p.AccessPointCODCode, Messages.Errors["notrec"])) return false;
                        // * validate
                        tmp.PackageServiceOptions.AccessPointCOD = new AccessPointCOD();
                        tmp.PackageServiceOptions.AccessPointCOD.CurrencyCode = p.AccessPointCODCode;
                        tmp.PackageServiceOptions.AccessPointCOD.MonetaryValue = p.AccessPointCODPrice;
                    }
                    if (!string.IsNullOrEmpty(p.ShipperReleaseIndicator))
                    {
                        tmp.PackageServiceOptions.ShipperReleaseIndicator = "Y";
                    }
                    if (!string.IsNullOrEmpty(p.Notification))
                    {
                        // validate
                        if (!Helpers.isset(Validation.NotificationCode, p.NotificationCode, Messages.Errors["noticecode"])) return false;
                        if (!Helpers.isset(Validation.EmailSubjectCode, p.EmailSubjectCode, Messages.Errors["noticecode"])) return false;
                        if (!Helpers.isnull(p.EmailAddress, Messages.Errors["required"], "EmailAddress")) return false;
                        // * validate
                        tmp.PackageServiceOptions.Notification = new Notification();
                        tmp.PackageServiceOptions.Notification.NotificationCode = p.Notification;
                        tmp.PackageServiceOptions.Notification.EMail = new EMail();
                        tmp.PackageServiceOptions.Notification.EMail.Subject = Helpers.isnullelse(p.EmailSubject," ");
                        tmp.PackageServiceOptions.Notification.EMail.SubjectCode = Helpers.isnullelse(p.EmailSubjectCode," ");
                        tmp.PackageServiceOptions.Notification.EMail.EMailAddress = p.EmailAddress;
                        tmp.PackageServiceOptions.Notification.EMail.UndeliverableEMailAddress = Helpers.isnullelse(p.UndeliverableEMailAddress, " ");
                        tmp.PackageServiceOptions.Notification.EMail.FromEMailAddress = Helpers.isnullelse(p.FromEMailAddress, " ");
                        tmp.PackageServiceOptions.Notification.EMail.FromName = Helpers.isnullelse(p.FromEMailName, " ");
                        tmp.PackageServiceOptions.Notification.EMail.Memo = Helpers.isnullelse(p.EMailMemo, " ");
                    }
                    // only supports 1 Hazmat @version 1.0.0.0
                    if (!string.IsNullOrEmpty(p.HazMat))
                    {
                        // validate
                        if (!Helpers.isnull(p.HazMatPackingGroup,Messages.Errors["required"], "HazMatPackingGroup")) return false;
                        if (!Helpers.isset(Validation.aDRPackingGroupLetter, p.HazMatPackingGroup, Messages.Errors["notrec"])) return false;
                        if (!Helpers.isnull(p.HazMatProperShippingName, Messages.Errors["required"], "HazMatProperShippingName")) return false;
                        if (!Helpers.isnull(p.HazMatRegulationSet, Messages.Errors["required"], "HazMatRegulationSet")) return false;
                        if (!Helpers.isnull(p.HazMatTransportationMode, Messages.Errors["required"], "HazMatTransportationMode")) return false;
                        if (!Helpers.isset(Validation.HazMatTransportationMode, p.HazMatTransportationMode, Messages.Errors["notrec"])) return false;
                        if (!Helpers.Contains(Validation.HazMatTransportCategory, Messages.Errors["notrec"], Helpers.isnullelse(p.HazMatTransportCategory, " "))) return false;
                        // * validate
                        tmp.PackageServiceOptions.HazMat = new List<HazMat>() { new HazMat() };
                        tmp.PackageServiceOptions.HazMat[0].PackagingTypeQuantity = p.HazMatQty.ToString();
                        tmp.PackageServiceOptions.HazMat[0].RecordIdentifier1 = p.HazMatID1;
                        tmp.PackageServiceOptions.HazMat[0].RecordIdentifier2 = p.HazMatID2;
                        tmp.PackageServiceOptions.HazMat[0].RecordIdentifier3 = p.HazMatID3;
                        tmp.PackageServiceOptions.HazMat[0].SubRiskClass = p.HazMatSubRiskClass;
                        tmp.PackageServiceOptions.HazMat[0].aDRItemNumber = p.HazMataDRItemNumber;
                        tmp.PackageServiceOptions.HazMat[0].aDRPackingGroupLetter = p.HazMatPackingGroup;
                        tmp.PackageServiceOptions.HazMat[0].TechnicalName = p.HazMatTechnicalName;
                        tmp.PackageServiceOptions.HazMat[0].HazardLabelRequired = p.HazMatHazardLabelRequired;
                        tmp.PackageServiceOptions.HazMat[0].ClassDivisionNumber = p.HazMatClassDivisionNumber;
                        tmp.PackageServiceOptions.HazMat[0].ReferenceNumber = p.HazMatReferenceNumber;
                        tmp.PackageServiceOptions.HazMat[0].Quantity = p.HazMatQuantity.ToString();
                        tmp.PackageServiceOptions.HazMat[0].UOM = p.UOM;
                        tmp.PackageServiceOptions.HazMat[0].PackagingType = p.HazMatPackagingType;
                        tmp.PackageServiceOptions.HazMat[0].IDNumber = p.IDNumber;
                        tmp.PackageServiceOptions.HazMat[0].ProperShippingName = p.HazMatProperShippingName;
                        tmp.PackageServiceOptions.HazMat[0].AdditionalDescription = p.HazMatAdditionalDescription;
                        tmp.PackageServiceOptions.HazMat[0].PackagingGroupType = p.HazMatPackingGroup;
                        tmp.PackageServiceOptions.HazMat[0].EmergencyPhone = p.HazMatEmergencyPhone;
                        tmp.PackageServiceOptions.HazMat[0].EmergencyContact = p.HazMatEmergencyContact;
                        tmp.PackageServiceOptions.HazMat[0].ReportableQuantity = p.HazMatReportableQuantity;
                        tmp.PackageServiceOptions.HazMat[0].RegulationSet = p.HazMatRegulationSet;
                        tmp.PackageServiceOptions.HazMat[0].TransportationMode = p.HazMatTransportationMode;
                        tmp.PackageServiceOptions.HazMat[0].CommodityRegulatedLevelCode = p.HazMatCommodityRegulatedLevelCode;
                        tmp.PackageServiceOptions.HazMat[0].TransportCategory = p.HazMatTransportCategory;
                        tmp.PackageServiceOptions.HazMat[0].TunnelRestrictionCode = p.HazMatTunnelRestrictionCode;
                        tmp.PackageServiceOptions.HazMat[0].ChemicalRecordIdentifier = p.HazMatChemicalRecordIdentifier;
                        tmp.PackageServiceOptions.HazMat[0].LocalTechnicalName = p.HazMatLocalTechnicalName;
                        tmp.PackageServiceOptions.HazMat[0].LocalProperShippingName = p.HazMatLocalProperShippingName;
                    }
                    if (!string.IsNullOrEmpty(p.DryIce))
                    {
                        // validate
                        if (!Helpers.isnull(p.DryIceRegulationSet, Messages.Errors["required"], "DryIceRegulationSet")) return false;
                        if (!Helpers.isset(Validation.DryIceRegulationSet, p.DryIceRegulationSet, Messages.Errors["notrec"])) return false;
                        // * validate

                        tmp.PackageServiceOptions.DryIce = new DryIce();
                        tmp.PackageServiceOptions.DryIce.RegulationSet = p.DryIceRegulationSet;
                        tmp.PackageServiceOptions.DryIce.DryIceWeight = new DryIceWeight();
                        tmp.PackageServiceOptions.DryIce.DryIceWeight.UnitOfMeasurement.Code = p.UnitOfWeightMeasurement.ToString();
                        tmp.PackageServiceOptions.DryIce.DryIceWeight.Weight = p.DryIceWeight.ToString();
                        if (!string.IsNullOrEmpty(p.DryIceMedicalUseIndicator))
                            tmp.PackageServiceOptions.DryIce.MedicalUseIndicator = "Y";
                    }
                    if (!string.IsNullOrEmpty(p.UPSPremiumCareIndicator)) tmp.PackageServiceOptions.UPSPremiumCareIndicator = "Y";
                    if (!string.IsNullOrEmpty(p.ProactiveIndicator)) tmp.PackageServiceOptions.ProactiveIndicator = "Y";
                    if (!string.IsNullOrEmpty(p.PackageIdentifier)) tmp.PackageServiceOptions.PackageIdentifier = p.PackageIdentifier;
                    if (!string.IsNullOrEmpty(p.ClinicalTrialsID)) tmp.PackageServiceOptions.ClinicalTrialsID = p.ClinicalTrialsID;
                    if (!string.IsNullOrEmpty(p.RefrigerationIndicator)) tmp.PackageServiceOptions.RefrigerationIndicator = "Y";
                }
                if (!string.IsNullOrEmpty(p.Commodity))
                {
                    // validate
                    if (!Helpers.isnull(p.PrimeCode, Messages.Errors["required"], "PrimeCode")) return false;
                    if (!Helpers.isnull(p.FreightClass, Messages.Errors["required"], "FreightClass")) return false;
                    // * validate

                    tmp.Commodity.FreightClass = p.FreightClass;
                    tmp.Commodity.NMFC = new NMFC();
                    tmp.Commodity.NMFC.PrimeCode = p.NMFCPrimeCode;
                    tmp.Commodity.NMFC.SubCode = p.NMFCSubCode;
                }
                if (!string.IsNullOrEmpty(p.HazMatPackageInformation))
                {
                    /** as per the documentation...
                     * 
                     * Required when number of hazmat containers in a package is greater than 1. 
                     * It indicates whether all the hazmat materials are kept in a single box or multiple boxes. 
                     * Required when number of hazmat container in a package is greater than 1.
                     * */
                    // this only needs to be added once for all the packages
                    if(NumHazMatPackages > 1 && HazMatPackageInformation == false)
                    {
                        tmp.HazMatPackageInformation = new HazMatPackageInformation();
                        if (!string.IsNullOrEmpty(p.HazMatAllPackedInOneIndicator))
                            tmp.HazMatPackageInformation.AllPackedInOneIndicator = p.HazMatAllPackedInOneIndicator;
                        if (!string.IsNullOrEmpty(p.HazMatOverPackedIndicator))
                        {
                            tmp.HazMatPackageInformation.OverPackedIndicator = p.HazMatOverPackedIndicator;
                            tmp.HazMatPackageInformation.QValue = p.HazMatQValue;
                        }
                        tmp.HazMatPackageInformation.OuterPackagingType = p.HazMatOuterPackagingType;
                        HazMatPackageInformation = true;
                    }
                }


                    // done
                    request.Shipment.Package.Add(tmp); // add the package to the list

            } // END package loop
            
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Service"></param>
        /// <returns></returns>
        private bool GetService(string Service)
        {
            if (!Helpers.isset(Validation.UPSServices, Service, Messages.Errors["service"]))
            {
                Validation.DumpValid(Validation.UPSServices);
                return false;
            }
            request.Shipment.Service = new Service();
            Service tmp = new Service();
            tmp.Code = Service;
            tmp.Description = Validation.UPSServices[Service];
            request.Shipment.Service = tmp;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>this may be able to be broken out into another class if it needs reusability and to reduce repeated actions</remarks>
        /// <param name="ShipmentCharges"></param>
        /// <returns></returns>
        private bool GetShipmentCharges(List<Models.Properties.ShipmentCharges> ShipmentCharges)
        {
            Models.PaymentInformation paymentInformation = new Models.PaymentInformation();
            paymentInformation.ShipmentCharge = new List<ShipmentCharge>();
            foreach (Models.Properties.ShipmentCharges charge in ShipmentCharges)
            {
                ShipmentCharge tmp = new ShipmentCharge();
                if (!Helpers.isnull(charge.Type, Messages.Errors["required"], "Type")) return false;
                tmp.Type = charge.Type;

                if (!string.IsNullOrEmpty(charge.ConsigneeBilledIndicator))
                {
                    tmp.ConsigneeBilledIndicator = "Y";
                }

                if (!string.IsNullOrEmpty(charge.BillShipper))
                {
                    tmp.BillShipper = new BillShipper();
                    // this has to be first as it should contain one of the two payment methods
                    if (!string.IsNullOrEmpty(charge.AlternatePaymentMethod))
                    {
                        tmp.BillShipper.AlternatePaymentMethod = charge.AlternatePaymentMethod;
                    }
                    if (!string.IsNullOrEmpty(charge.AccountNumber))
                    {
                        tmp.BillShipper.AccountNumber = charge.AccountNumber;
                        paymentInformation.ShipmentCharge.Add(tmp);
                        continue;
                    }
                    if (!string.IsNullOrEmpty(charge.CreditCard))
                    {
                        if (!ValidateCC(charge))
                            return false;
                        tmp.BillShipper.CreditCard = new CreditCard();
                        tmp.BillShipper.CreditCard.Type = charge.CreditCardType;
                        tmp.BillShipper.CreditCard.Number = charge.CreditCardNumber.ToString();
                        tmp.BillShipper.CreditCard.SecurityCode = charge.CreditCardSecurityCode;
                        tmp.BillShipper.CreditCard.Address = charge.CreditCardBillingAddress;
                        paymentInformation.ShipmentCharge.Add(tmp);
                        continue;
                    }
                }
                if (!string.IsNullOrEmpty(charge.BillReceiver))
                {
                    if (Helpers.isnull(charge.AccountNumber, Messages.Errors["required"], "AccountNumber")) return false;
                    tmp.BillReceiver = new BillReceiver();
                    tmp.BillReceiver.AccountNumber = charge.AccountNumber;
                    if (!string.IsNullOrEmpty(charge.BillReceiverAddress1))
                    {
                        tmp.BillReceiver.Address = new Address();
                        tmp.BillReceiver.Address.AddressLine = new List<string>
                        {
                            charge.BillReceiverAddress1,
                            charge.BillReceiverAddress2,
                            charge.BillReceiverAddress3
                        };
                    }
                    paymentInformation.ShipmentCharge.Add(tmp);
                    continue;
                }
                if (!string.IsNullOrEmpty(charge.BillThirdParty))
                {
                    if (Helpers.isnull(charge.AccountNumber, Messages.Errors["required"], "AccountNumber")) return false;
                    tmp.BillThirdParty = new BillThirdParty();
                    tmp.BillReceiver.AccountNumber = charge.AccountNumber;
                    tmp.BillThirdParty.CertifiedElectronicMail = charge.CertifiedElectronicMail;
                    tmp.BillThirdParty.InterchangeSystemCode = charge.InterchangeSystemCode;
                    if (!string.IsNullOrEmpty(charge.BillThirdPartyAddress1))
                    {
                        tmp.BillThirdParty.Address = new Address();
                        tmp.BillThirdParty.Address.AddressLine = new List<string>
                        {
                            charge.BillThirdPartyAddress1,
                            charge.BillThirdPartyAddress2,
                            charge.BillThirdPartyAddress3
                        };
                    }
                    paymentInformation.ShipmentCharge.Add(tmp);
                    continue;
                }
            }

            request.Shipment.PaymentInformation = paymentInformation;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShipFrom"></param>
        private void GetShipFrom(Models.Properties.ShipFrom ShipFrom)
        {
            Models.ShipFrom ShiPfrom = new Models.ShipFrom();
            ShiPfrom.Name = Helpers.isnullelse(ShipFrom.Name, Params.ShipperName);
            ShiPfrom.AttentionName = Helpers.isnullelse(ShipFrom.AttentionName, Params.ShipperAttentionName);
            ShiPfrom.Phone = new Models.Phone();
            ShiPfrom.Phone.Number = Helpers.isnullelse(ShipFrom.Phone, Params.ShipperPhone);
            ShiPfrom.FaxNumber = Helpers.isnullelse(ShipFrom.FaxNumber, Params.ShipperFaxNumber);
            ShiPfrom.Address = new Models.Address();
            string addr1 = Helpers.isnullelse(ShipFrom.Address1, Params.ShipperAddress.Count > 0 ? Params.ShipperAddress[0] : "");
            if (string.IsNullOrEmpty(addr1))
            {
                ShiPfrom.Address.AddressLine = Params.ShipperAddress;
            }
            else
            {
                ShiPfrom.Address.AddressLine = new List<string>
                {
                    Helpers.isnullelse(ShipFrom.Address1, Params.ShipperAddress.Count > 0 ? Params.ShipperAddress[0] : ""),
                    Helpers.isnullelse(ShipFrom.Address2, Params.ShipperAddress.Count > 1 ? Params.ShipperAddress[1] : ""),
                    Helpers.isnullelse(ShipFrom.Address3, Params.ShipperAddress.Count > 2 ? Params.ShipperAddress[2] : "")
                };
            }
            ShiPfrom.Address.City = Helpers.isnullelse(ShipFrom.City, Params.ShipperCity);
            ShiPfrom.Address.StateProvinceCode = Helpers.isnullelse(ShipFrom.State, Params.ShipperState);
            ShiPfrom.Address.PostalCode = Helpers.isnullelse(ShipFrom.Zip, Params.ShipperZip);
            ShiPfrom.Address.CountryCode = Helpers.isnullelse(ShipFrom.Country, "US");
            request.Shipment.ShipFrom = ShiPfrom;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShipFrom"></param>
        private void GetShipFrom(Dictionary<string, string> ShipFrom)
        {
            if(null == ShipFrom) ShipFrom = new Dictionary<string, string>();
            Models.ShipFrom ShiPfrom = new Models.ShipFrom();
            ShiPfrom.Name = Libs.Helpers.isset(ShipFrom, "Name", Params.ShipperName);
            ShiPfrom.AttentionName = Libs.Helpers.isset(ShipFrom, "AttentionName", Params.ShipperAttentionName);
            ShiPfrom.Phone = new Models.Phone();
            ShiPfrom.Phone.Number = Libs.Helpers.isset(ShipFrom, "Phone", Params.ShipperPhone);
            ShiPfrom.FaxNumber = Libs.Helpers.isset(ShipFrom, "FaxNumber", Params.ShipperFaxNumber);
            ShiPfrom.Address = new Models.Address();
            string addr1 = Libs.Helpers.isset(ShipFrom, "Address1", Params.ShipperAddress.Count > 0 ? Params.ShipperAddress[0] : "");
            if (string.IsNullOrEmpty(addr1))
            {
                ShiPfrom.Address.AddressLine = Params.ShipperAddress;
            }
            else
            {
                ShiPfrom.Address.AddressLine = new List<string>
                {
                    Libs.Helpers.isset(ShipFrom, "Address1", Params.ShipperAddress.Count > 0 ? Params.ShipperAddress[0] : ""),
                    Libs.Helpers.isset(ShipFrom, "Address2", Params.ShipperAddress.Count > 1 ? Params.ShipperAddress[1] : ""),
                    Libs.Helpers.isset(ShipFrom, "Address3", Params.ShipperAddress.Count > 2 ? Params.ShipperAddress[2] : "")
                };
            }
            ShiPfrom.Address.City = Libs.Helpers.isset(ShipFrom, "City", Params.ShipperCity);
            ShiPfrom.Address.StateProvinceCode = Libs.Helpers.isset(ShipFrom, "State", Params.ShipperState);
            ShiPfrom.Address.PostalCode = Libs.Helpers.isset(ShipFrom,"Zip", Params.ShipperZip);
            ShiPfrom.Address.CountryCode = Libs.Helpers.isset(ShipFrom, "Country", "US");
            request.Shipment.ShipFrom = ShiPfrom;
        }
        /// <summary>

        /// </summary>
        /// <param name="ShipTo"></param>
        private void GetShipTo(Models.Properties.ShipTo ShipTo)
        {
            Models.ShipTo shipTo = new Models.ShipTo();
            shipTo.Name = ShipTo.Name;
            shipTo.AttentionName = ShipTo.AttentionName;
            shipTo.Phone = new Models.Phone();
            shipTo.Phone.Number = ShipTo.Phone;
            shipTo.FaxNumber = ShipTo.FaxNumber;
            shipTo.Address = new Models.Address();
            shipTo.Address.AddressLine = new List<string>
            {
                ShipTo.Address1,
                Helpers.isnullelse(ShipTo.Address2),
                Helpers.isnullelse(ShipTo.Address3)
            };
            shipTo.Address.City = ShipTo.City;
            shipTo.Address.StateProvinceCode = ShipTo.State;
            shipTo.Address.PostalCode = ShipTo.Zip;
            shipTo.Address.CountryCode = Helpers.isnullelse(ShipTo.Country,Params.DefaultCountry);
            request.Shipment.ShipTo = shipTo;
        }
        /// <summary>
        /// 
        /// </summary>
        private void GetShipper()
        {
            Models.Shipper shipper = new Models.Shipper();
            shipper.Name = Params.ShipperName;
            shipper.AttentionName = Params.ShipperAttentionName;
            shipper.TaxIdentificationNumber = Params.ShipperTaxIdentificationNumber;
            shipper.Phone = new Models.Phone();
            shipper.Phone.Number = Params.ShipperPhone;
            shipper.ShipperNumber = Params.ShipperNumber;
            shipper.FaxNumber = Params.ShipperFaxNumber;
            shipper.Address = new Models.Address();
            shipper.Address.AddressLine = Params.ShipperAddress;
            shipper.Address.City = Params.ShipperCity;
            shipper.Address.StateProvinceCode = Params.ShipperState;
            shipper.Address.PostalCode = Params.ShipperZip;
            shipper.Address.CountryCode = Params.ShipperCountry;
            request.Shipment.Shipper = shipper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void GetShipment()
        {
            Models.Shipment shipment = new Models.Shipment();
            shipment.Description = Params.ShipmentDescription;
            request.Shipment = shipment;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void GetRequest()
        {
            Models.Request _return = new Models.Request();
            _return.SubVersion = Params.RequestSubversion;
            _return.RequestOption = Params.RequestOption;
            request.Request = _return;
        }
        
    }
    
}
