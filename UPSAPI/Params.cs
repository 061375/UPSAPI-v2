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
        public static string ShipmentDescription = "[** SHORT DESCRIPTION **]";
        public static string ShipperName = "[** SHIPPER NAME **]";
        public static string ShipperAttentionName = "[** ATTENTION NAME**]";
        public static string ShipperTaxIdentificationNumber = " ";
        public static string ShipperPhone = "";
        public static string ShipperNumber = "";
        public static string ShipperFaxNumber = "";
        public static List<string> ShipperAddress = new List<string>(){ "","","" };
        public static string ShipperCity = "";
        public static string ShipperState = "";
        public static string ShipperZip = "";
        public static string ShipperCountry = "US";
        public static string ShipmentChargeType = "01";
        public static string UnitOfLengthMeasurement = "IN";
        public static string UnitOfWeightMeasurement = "LBS";
        public static string DefaultCountry = "US";

    }
}
