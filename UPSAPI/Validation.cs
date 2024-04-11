using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2
{
    internal class Validation
    {
        public static void DumpValid(Dictionary<string, string> dict)
        {
            Console.WriteLine("Valid values:");
            foreach(KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine("     " + kvp.Key + ": " + kvp.Value);
            }
            Console.WriteLine();
        }
        public static void DumpValid(List<string> list)
        {
            Console.WriteLine("Valid values:");
            foreach(string str in list)
            {
                Console.WriteLine("    " + str);
            }
            Console.WriteLine();
        }
        public static void DumpValid(List<int> data)
        {
            Console.Write("Valid values: ");
            foreach (int i in data)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        public static void DumpValid(Dictionary<string, List<int>> data)
        {
            Console.WriteLine("Valid values:");
            foreach(KeyValuePair<string, List<int>> kvp in data)
            {
                Console.Write(kvp.Key + ": ");
                foreach(int i in kvp.Value)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
        }
        public static readonly Dictionary<string, string> UPSServices = new Dictionary<string, string>()
        {
            {"01","Next Day Air"},
            {"02","2nd Day Air"},
            {"03","Ground"},
            {"07","Express"},
            {"08","Expedited"},
            {"11","UPS Standard"},
            {"12","3 Day Select"},
            {"13","Next Day Air Saver"},
            {"14","UPS Next Day Air® Early"},
            {"17","UPS Worldwide Economy DDU"},
            {"54","Express Plus"},
            {"59","2nd Day Air A.M."},
            {"65","UPS Saver"},
            {"M2","First Class Mail"},
            {"M3","Priority Mail"},
            {"M4","Expedited MaiI Innovations"},
            {"M5","Priority Mail Innovations"},
            {"M6","Economy Mail Innovations"},
            {"M7","MaiI Innovations (MI) Returns"},
            {"70","UPS Access Point™ Economy"},
            {"71","UPS Worldwide Express Freight Midday"},
            {"72","UPS Worldwide Economy DDP"},
            {"74","UPS Express®12:00"},
            {"75","UPS Heavy Goods"},
            {"82","UPS Today Standard"},
            {"83","UPS Today Dedicated Courier"},
            {"84","UPS Today Intercity"},
            {"85","UPS Today Express"},
            {"86","UPS Today Express Saver"},
            {"96","UPS Worldwide Express Freight"}
        };
        public static readonly Dictionary<string, string> PackagingType = new Dictionary<string, string>()
        {
            {"01","UPS Letter"},
            {"02","Customer Supplied Package"},
            {"03","Tube"},
            {"04","PAK"},
            {"21","UPS Express Box"},
            {"24","UPS 25KG Box"},
            {"25","UPS 10KG Box"},
            {"30","Pallet"},
            {"2a","Small Express Box"},
            {"2b","Medium Express Box"},
            {"2c","Large Express Box"},
            {"56","Flats"},
            {"57","Parcels"},
            {"58","BPM"},
            {"59","First Class"},
            {"60","Priority"},
            {"61","Machineables"},
            {"62","Irregulars"},
            {"63","Parcel Post"},
            {"64","BPM Parcel"},
            {"65","Media Mail"},
            {"66","BPM Flat"},
            {"67","Standard Flat"}
        };
        public static readonly Dictionary<string, string> CreditCardTypes = new Dictionary<string, string>()
        {
            {"01","American Express"},
            {"03","Discover"},
            {"04","MasterCard"},
            {"05","Optima"},
            {"06","VISA"},
            {"07","Bravo"},
            {"08","Diners Club"},
            {"13","Dankort"},
            {"14","Hipercard"},
            {"15","JCB"},
            {"17","Postepay"},
            {"18","UnionPay/ExpressPay"},
            {"19","Visa Electron"},
            {"20","VPAY"},
            {"21","Carte Bleue"}
        };
        public static readonly Dictionary<string, string> AlternatePayMethods = new Dictionary<string, string>()
        {
            {"01","PayPal"}
        };
        public static readonly Dictionary<string, string> FOBTypes = new Dictionary<string, string>()
        {
            {"01","Prepaid"},
            {"02","FreightCollect"},
            {"03","ThirdParty"}
        };
        public static readonly Dictionary<string, string> UnitOfWeightMeasurement = new Dictionary<string, string>()
        {
            {"LBS","Pounds"},
            {"KGS","Kilograms"}
        };
        public static readonly Dictionary<string, string> UnitOfLengthMeasurement = new Dictionary<string, string>()
        {
            {"IN","Inches"},
            {"CM","Centimeters"},
            {"00","Metric Units Of Measurement"},
            {"01","English Units of Measurement"}
        };
        public static readonly Dictionary<string, List<int>> VUnitOfLengthMeasurement = new Dictionary<string, List<int>>()
        {
            {"IN",new List<int>() {0, 108} },
            {"CM",new List<int>() {0, 270} },
            {"00",new List<int>() {0, 108} },
            {"01",new List<int>() {0, 270} }
        };
        public static readonly List<int> MaximumCandidateListSize = new List<int>() { 0, 50 };
        public static readonly Dictionary<string, string> SimpleRate = new Dictionary<string, string>()
        {
            {"XS","Extra Small"},
            {"S","Small"},
            {"M","Medium"},
            {"L","Large"},
            {"XL","Extra Large"}
        };
        public static readonly Dictionary<string, string> UPSPremier = new Dictionary<string, string>()
        {
            {"01","UPS Premier Silver"},
            {"02","UPS Premier Gold"},
            {"03","UPS Premier Platinum"}
        };
        public static readonly Dictionary<string, string> DCISType = new Dictionary<string, string>()
        {
            {"1","Unsupported"},
            {"2","Delivery Confirmation Signature Required"},
            {"3","Delivery Confirmation Adult Signature Required"}
        };
        public static readonly Dictionary<string, string> DeclaredValue = new Dictionary<string, string>()
        {
            {"01","EVS"},
            {"02","DVS"}
        };
        public static readonly Dictionary<string, string> AccessPointCOD = new Dictionary<string, string>()
        {
            {"01","Hold For Pickup At UPS Access Point"}
        };
        public static readonly Dictionary<string, string> NotificationCode = new Dictionary<string, string>()
        {
            {"3","Receiver Return Notification "},
            {"6","QV Email Notification "},
            {"7","QV Exception Notification "},
            {"8","QV Delivery Notification For Mail Innovations forward shipments, QV Email Notifications are allowed for First Class, Priority Mail, and Expedited Mail Innovation services"}
        };
        public static readonly Dictionary<string, string> EmailSubjectCode = new Dictionary<string, string>()
        {
            {"01","Shipment Reference Number 1"},
            {"02","Shipment Reference Number 2"},
            {"03","package Reference Number 1"},
            {"04","package Reference Number 2"},
            {"05","package Reference Number 3"},
            {"06","package Reference Number 4"},
            {"07","package Reference Number 5"},
            {"08","Subject Text (Return Notification only)"}
        };
        public static readonly Dictionary<string, string> aDRPackingGroupLetter = new Dictionary<string, string>()
        {
            {"1","|"},
            {"2","||"},
            {"3","|||"},
            {"",""}
        };
        public static readonly Dictionary<string, string> CommodityRegulatedLevelCode = new Dictionary<string, string>()
        {
            {"FR","Fully Regulated"},
            {"LQ","Limited Quantity"},
            {"EQ","Excepted Quantity"},
            {"LR","Lightly Regulated"}
        };
        public static readonly Dictionary<string, string> HazMatTransportationMode = new Dictionary<string, string>()
        {
            {"Highway","Highway"},
            {"Ground","Ground"},
            {"PAX","Passenger Aircraft Passenger"},
            {"Aircraft","Passenger Aircraft"},
            {"CAO","Cargo Aircraft Only"},
            {"Cargo Aircraft Only","Cargo Aircraft Only"}
        };
        public static readonly List<string> HazMatTransportCategory = new List<string>()
        {
            "0","1","2","3","4"
        };
        public static readonly List<string> LabelImageFormat = new List<string>()
        {
            "GIF","ZPL","SPL","EPL","EPL2"
        };
        public static readonly Dictionary<string, string> DryIceRegulationSet = new Dictionary<string, string>()
        {
            {"IATA","Worldwide Air movement"},
            {"CFR","HazMat regulated by US Dept. of Transportation within the U.S. or ground shipments to Canada"}
        };
        public static readonly Dictionary<string, string> LabelInstructions = new Dictionary<string, string>()
        {
            {"01","EXCHANGE-LIKE ITEM ONLY"},
            {"02","EXCHANGE-DRIVER INSTRUCTIONS INSIDE"}
        };
        public static readonly Dictionary<string, string> LabelCharacterSet = new Dictionary<string, string>()
        {
            {"nld","Dutch (Latin-1)"},
            {"fin","Finnish (Latin-1)"},
            {"fra","French (Latin-1)"},
            {"deu","German (Latin-1)"},
            {"dan","Danish (Latin-1)"},
            {"itl","Italian (Latin-1)"},
            {"nor","Norwegian (Latin-1)"},
            {"pol","Polish (Latin-2)"},
            {"por","Poruguese (Latin-1)"},
            {"spa","Spanish (Latin-1)"},
            {"swe","Swedish (Latin-1)"},
            {"ces","Czech (Latin-2)"},
            {"hun","Hungarian (Latin-2)"},
            {"slk","Slovak (Latin-2)"},
            {"rus","Russian (Cyrillic)"},
            {"tur","Turkish (Latin-5)"},
            {"ron","Romanian (Latin-2)"},
            {"bul","Bulgarian (Latin-2)"},
            {"est","Estonian (Latin-2)"},
            {"ell","Greek (Latin-2)"},
            {"lav","Latvian (Latin-2)"},
            {"lit","Lithuanian (Latin-2)"},
            {"eng","English (Latin-1)"}
        };
        public static readonly List<string> ReceiptImageFormat = new List<string>()
        {
            "HTML","ZPL","SPL","EPL"
        };
        public static readonly Dictionary<string, string> LanguageCode = new Dictionary<string, string>()
        {
            {"eng","English"},
            {"spa","Spanish"},
            {"ita","Italian"},
            {"fra","French"},
            {"deu","German"},
            {"por","Portuguese"},
            {"nld","Dutch"},
            {"dan","Danish"},
            {"fin","Finnish"},
            {"swe","Swedish"},
            {"nor","Norwegian"}
        };
        public static readonly Dictionary<string, string> DialectCode = new Dictionary<string, string>()
        {
            {"CA","Canada"},
            {"GB","Great Britain"},
            {"US","United States"},
            {"97","Not Applicable"}
        };
    }
}
