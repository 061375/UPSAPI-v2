using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2
{
    // default settings that can be changed
    internal class Params
    {
        public static string RequestSubversion = "1801";
        public static string RequestOption = "nonvalidate";
        public static string ShipmentDescription = "Customer Shipment";
        public static string ShipperName = "Aquamor, LLC";
        public static string ShipperAttentionName = "Aquamor, LLC";
        public static string ShipperTaxIdentificationNumber = " ";
        public static string ShipperPhone = "951-541-9517";
        public static string ShipperNumber = "914RE3";
        public static string ShipperFaxNumber = "951-296-1050";
        public static List<string> ShipperAddress = new List<string>(){ "42188 Rio Nedo" };
        public static string ShipperCity = "Temecula";
        public static string ShipperState = "CA";
        public static string ShipperZip = "92590";
        public static string ShipperCountry = "US";
        public static string ShipmentChargeType = "01";
        public static string UnitOfLengthMeasurement = "IN";
        public static string UnitOfWeightMeasurement = "LBS";
        public static string DefaultCountry = "US";

    }
}
