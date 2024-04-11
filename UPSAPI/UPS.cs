using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2
{
    // Specialty API Tech Support: 800-247-9035 ( opt 3 twice )
    public class UPS
    {
        public api.Shipments Shipments { get; set; }
        public api.Label Label { get; set; }
        public api.AddressValidation AddressValidation { get; set; }
        public static void SetRequestSubversion(string s){ Params.RequestSubversion = s;}
        public static void SetRequestOption(string s) { Params.RequestOption = s;}
        public static void SetShipmentDescription(string s) { Params.ShipmentDescription = s;}
        public static void SetShipperName(string s) { Params.ShipperName = s;}
        public static void SetShipperAttentionName(string s) { Params.ShipperAttentionName = s;}
        public static void SetShipperTaxIdentificationNumber(string s) { Params.ShipperTaxIdentificationNumber = s; }
        public static void SetShipperPhone(string s) { Params.ShipperPhone = s; }
        public static void SetShipperNumber(string s) { Params.ShipperNumber = s; }
        public static void SetShipperCity(string s) { Params.ShipperCity = s; }
        public static void SetShipperState(string s) { Params.ShipperState = s; }
        public static void SetShipperZip(string s) { Params.ShipperZip = s; }
        public static void SetShipperCountry(string s) { Params.ShipperCountry = s; }
        public static void SetShipmentChargeType(string s) { Params.ShipmentChargeType = s; }
        public static void SetShipmentChargeType(List<string> s) { Params.ShipperAddress = s; }
        public static void SetUnitOfLengthMeasurement(string s) { Params.UnitOfLengthMeasurement = s; }
        public static void SetUnitOfWeightMeasurement(string s) { Params.UnitOfWeightMeasurement = s; }
        public static void SetTesting(bool t){Libs.Helpers.SetIsTesting(t);}
        public static void SetLog(bool t) { Libs.Helpers.SetLog(t); }
    }
}
