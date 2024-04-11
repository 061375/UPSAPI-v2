using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPSAPIv2.Models;
using UPSAPIv2;
using System.Runtime.InteropServices;

namespace UPSAPIv2.Models.Properties
{
    public struct ShipTo
    {
        public string Name;
        public string AttentionName;
        public string Phone;
        public string FaxNumber;
        public string Address1;
        public string Address2;
        public string Address3;
        public string City;
        public string State;
        public string Zip;
        public string Country;
    }
    public struct ShipFrom
    {
        public string Name;
        public string AttentionName;
        public string Phone;
        public string FaxNumber;
        public string Address1;
        public string Address2;
        public string Address3;
        public string City;
        public string State;
        public string Zip;
        public string Country;
    }
    public struct Packages
    {
        public string Description;
        public string PalletDescription;
        public int NumOfPieces;
        public decimal UnitPrice;
        public string PackagingType;
        public string PackagingDescription;
        public string UnitOfLengthMeasurement;
        public string UnitOfMeasurementDescription;
        public int DimensionsLength;
        public int DimensionsWidth;
        public int DimensionsHeight;
        public string UnitOfWeightMeasurement;
        public decimal DimWeight;
        public string PackageWeightUnitOfMeasurement;
        public double PackageWeight;
        public string LargePackageIndicator;
        public string OversizeIndicator;
        public string MinimumBillableWeightIndicator;
        public string AdditionalHandlingIndicator;
        public string ReferenceNumber;
        public string BarCodeIndicator;
        public string SimpleRate;
        public string UPSPremier;
        public string UPSPremierSensorID;
        public string UPSPremierHandlingInstructions;
        public string PackageServiceOptions;
        public string DeliveryConfirmation;
        public string DCISType;
        public string DCISNumber;
        public string DeclaredValue;
        public string DeclaredValueCode;
        public string DeclaredValuePrice;
        public string COD;
        public string CODFundsCode;
        public string CODCurrencyCode;
        public string CODPrice;
        public string AccessPointCOD;
        public string AccessPointCODCode;
        public string AccessPointCODPrice;
        public string ShipperReleaseIndicator;
        public string Notification;
        public string NotificationCode;
        public string EmailSubjectCode;
        public string EmailAddress;
        public string EmailSubject;
        public string FromEMailAddress;
        public string FromEMailName;
        public string UndeliverableEMailAddress;
        public string EMailMemo;
        public string HazMat;
        public string HazMatQty;
        public string HazMatID1;
        public string HazMatID2;
        public string HazMatID3;
        public string HazMatSubRiskClass;
        public string HazMataDRItemNumber;
        public string HazMatPackingGroup;
        public string HazMatTechnicalName;
        public string HazMatHazardLabelRequired;
        public string HazMatClassDivisionNumber;
        public string HazMatReferenceNumber;
        public string HazMatQuantity;
        public string UOM;
        public string HazMatPackagingType;
        public string IDNumber;
        public string HazMatProperShippingName;
        public string HazMatAdditionalDescription;
        public string HazMatEmergencyPhone;
        public string HazMatEmergencyContact;
        public string HazMatReportableQuantity;
        public string HazMatRegulationSet;
        public string HazMatTransportationMode;
        public string HazMatCommodityRegulatedLevelCode;
        public string HazMatTransportCategory;
        public string HazMatTunnelRestrictionCode;
        public string HazMatChemicalRecordIdentifier;
        public string HazMatLocalTechnicalName;
        public string HazMatLocalProperShippingName;
        public string DryIce;
        public string DryIceRegulationSet;
        public string DryIceUnitOfWeightMeasurement;
        public decimal DryIceWeight;
        public string DryIceMedicalUseIndicator;
        public string UPSPremiumCareIndicator;
        public string ProactiveIndicator;
        public string PackageIdentifier;
        public string ClinicalTrialsID;
        public string RefrigerationIndicator;
        public string Commodity;
        public string PrimeCode;
        public string FreightClass;
        public string NMFCPrimeCode;
        public string NMFCSubCode;
        public string HazMatPackageInformation;
        public string HazMatAllPackedInOneIndicator;
        public string HazMatOverPackedIndicator;
        public string HazMatQValue;
        public string HazMatOuterPackagingType;
        public int NumHazMatPackages;
    }
    public struct ShipmentCharges
    {
        public string Type;
        public string ConsigneeBilledIndicator;
        public string BillShipper;
        public string AlternatePaymentMethod;
        public string AccountNumber;
        public string CreditCard;
        public string CreditCardType;
        public string CreditCardNumber;
        public string CreditCardSecurityCode;
        public string CreditCardBillingAddress;
        public string BillReceiver;
        public string BillReceiverAddress1;
        public string BillReceiverAddress2;
        public string BillReceiverAddress3;
        public string BillThirdParty;
        public string CertifiedElectronicMail;
        public string InterchangeSystemCode;
        public string BillThirdPartyAddress1;
        public string BillThirdPartyAddress2;
        public string BillThirdPartyAddress3;
    }
    public struct LabelParameters
    {
        public string LabelSpecification;
        public string LabelImageFormatCode;
        public string HTTPUserAgent;
        public string LabelHeight;
        public string LabelWidth;
        public string LabelInstructionCode;
        public string LabelParametersDescription;
        public string LabelCharacterSet;
    }
    public struct ReceiptParameters
    {
        public string ReceiptSpecification;
        public string ReceiptImageFormatCode;
        public string ReceiptParametersDescription;
    }
}
