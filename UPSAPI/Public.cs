using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UPSAPIv2.Models;

namespace UPSAPIv2
{
    public struct AddressValid
    {
        public Models.Properties.AddressValidation Properties;
    }
    public struct ShipmentParams
    {
        public Dictionary<string, string> ShipTo;
        public List<Dictionary<string, string>> Packages;
        public List<Dictionary<string, string>> ShipmentCharges;
        public Dictionary<string, string> ShipFrom;
        public Dictionary<string, string> LabelParameters;
        public Dictionary<string, string> ReceiptParameters;
        public string RefNumber;
        public string Service;
    }
    public struct ShipmentProperties
    {
        public Models.Properties.ShipTo ShipTo;
        public List<Models.Properties.Packages> Packages;
        public List<Models.Properties.ShipmentCharges> ShipmentCharges;
        public Models.Properties.ShipFrom ShipFrom;
        public Models.Properties.LabelParameters LabelParameters;
        public Models.Properties.ReceiptParameters ReceiptParameters;
        public string RefNumber;
        public string Service;
    }
    public struct LabelParams
    {
        public string SubVersion;
        public string RequestOption;
        public string CustomerContext;
        public string HTTPUserAgent;
        public bool LabelImageFormat;
        public string LabelImageFormat_Code;
        public string LabelImageFormat_Description;
        public bool LabelStockSize;
        public int LabelStockSize_Height;
        public int LabelStockSize_Width;
        public bool Translate;
        public string Translate_LanguageCode;
        public string Translate_DialectCode;
        public string Translate_Code;
        public string LabelDelivery_LabelLinkIndicator;
        public string LabelDelivery_ResendEMailIndicator;
        public string TrackingNumber;
        public string MailInnovationsTrackingNumber;
        public bool ReferenceValues;
        public string ReferenceValues_ReferenceNumber_Value;
        public string ShipperNumber;
        public string Locale;
        public bool UPSPremiumCareForm;
        public string UPSPremiumCareForm_PageSize;
        public string UPSPremiumCareForm_PrintType;
    }
    public class Public
    {
        public static List<string> Errors = new List<string>();
    }
        
    internal class Libs
    {
        public static readonly AQHelpers.Helpers Helpers = new AQHelpers.Helpers(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
    }
}
