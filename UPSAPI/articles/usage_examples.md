
# Suggested Usage Examples
These are minimum examples to create a shipment and retrieve a label. 

### Shipments :: Object Oriented
    UPSAPIv2.api.Shipments Shipments = new UPSAPIv2.api.Shipments();
    UPSAPIv2.ShipmentProperties shipmentProperties = new UPSAPIv2.ShipmentProperties();
    shipmentProperties.RefNumber = "1234567";
    shipmentProperties.Service = "01";
    shipmentProperties.ShipTo = new UPSAPIv2.Models.Properties.ShipTo();
    shipmentProperties.ShipTo.Name = "Jim Worm";
    shipmentProperties.ShipTo.AttentionName = "Earth";
    shipmentProperties.ShipTo.Address1 = "123 test street";
    shipmentProperties.ShipTo.Address2 = "Suite 42";
    shipmentProperties.ShipTo.Phone = "9511234567";
    shipmentProperties.ShipTo.City = "Temecula";
    shipmentProperties.ShipTo.State = "CA";
    shipmentProperties.ShipTo.Zip = "92590";

    shipmentProperties.ShipmentCharges = new List<UPSAPIv2.Models.Properties.ShipmentCharges>();
    UPSAPIv2.Models.Properties.ShipmentCharges shipmentCharge = new UPSAPIv2.Models.Properties.ShipmentCharges
    {
        Type = "01",
        BillShipper = "Y",
        AccountNumber = "[UPS ACCT NUMBER]"
    };
    shipmentProperties.ShipmentCharges.Add(shipmentCharge);

    shipmentProperties.Packages = new List<UPSAPIv2.Models.Properties.Packages>
    {
        new UPSAPIv2.Models.Properties.Packages
        {
            PackagingType = "02",
            UnitOfLengthMeasurement = "IN",
            DimensionsLength = 10,
            DimensionsWidth = 10,
            DimensionsHeight = 10,
            UnitOfWeightMeasurement = "LBS",
            PackageWeight = 28.4
        }
    };
    if (!Shipments.CreateShipment(shipmentProperties))
    {
        foreach (string e in UPSAPIv2.Public.Errors)
        {
            Console.WriteLine(e);
        }
        Console.ReadKey();
        System.Environment.Exit(1);
    }
    string json = Shipments.GetJson();
    // -------
    // pass the JSON to the REST API
    // -------

### Shipments :: Functional
This method can be useful when data is pulled from database using raw SQL where the local data types are not known i.e. data types all converted to strings and placed in a list of dictionaries.
Also see Normalizations.

    UPSAPIv2.api.Shipments Shipments = new UPSAPIv2.api.Shipments();
    UPSAPIv2.ShipmentParams ShipmentParams = new UPSAPIv2.ShipmentParams();
    ShipmentParams.Service = "01";
    ShipmentParams.ShipTo = new Dictionary<string, string>()
    {
        {"Name","Bob Vlla" },
        {"AttentionName","AttentionName" },
        {"Address1","123 Test Street" },
        {"Address2","Suite 123" },
        {"Phone","9518051234" },
        {"City","Test City" },
        {"State","CA" },
        {"Zip","92590" }
    };
    ShipmentParams.ShipmentCharges = new List<Dictionary<string, string>>();
    Dictionary<string, string> shipcharge = new Dictionary<string, string>();
    shipcharge["Type"] = "01";
    shipcharge["BillShipper"] = "Y";
    shipcharge["AccountNumber"] = "[UPS ACCT NUMBER]";
    ShipmentParams.ShipmentCharges.Add(shipcharge);
    ShipmentParams.Packages = new List<Dictionary<string, string>>();
    Dictionary<string,string> package = new Dictionary<string, string>()
    {
        {"PackagingType","02"},
        {"UnitOfLengthMeasurement","IN"},
        {"DimensionsLength","10"},
        {"DimensionsWidth","20"},
        {"DimensionsHeight","30"},
        {"UnitOfWeightMeasurement","LBS"},
        {"PackageWeight","20.0"}
    };
    ShipmentParams.Packages.Add(package);
    // create the request
    if (!Shipments.CreateShipment(ShipmentParams))
    {
        foreach(string e in UPSAPIv2.Public.Errors)
        {
            Console.WriteLine(e);
        }
        Console.ReadKey();
        System.Environment.Exit(1);
    }
    string json = Shipments.GetJson();
    // -------
    // pass the JSON to the REST API
    // -------
  
  ### Retrieve Labels
  After the API call run this to get labels and tracking numbers from the request.
  
      UPSAPIv2.api.Label Label = new UPSAPIv2.api.Label();
      if (_l.GetProcessLabelResponse(result))
            {
                // loop all the tracking numbers
                foreach(string l in Label.TrackingNumbers)
                {
                    Console.WriteLine($"{l}");
                }
                // loop all the labels
                foreach (string l in Label.Labels)
                {
                    Console.WriteLine($"{l}");
                }
            }
            else
            {
                foreach(string e in UPSAPIv2.Public.Errors)
                {
                    Console.WriteLine($"{e}");
                }
            }
            
  
### Address Validation :: Object Oriented

### Address Validation :: Functional

### Normalizations
  These will map a typical data structure in a 3rd-party application to the UPS schema for a transaction where possible. This reducing the need for aliasing in the SQL query.
#### IQMS
      // real
      UPSAPIv2.Normalize.IQMS.Normalize Normalize = new UPSAPIv2.Normalize.IQMS.Normalize();

      // pseudo code
      string sql = "select * from ship_to where id = :ship_to_id";
      Dictionary<string, string> data = Your.Database.Abstraction.Get(sql, columns, ship_to_id);
      ...

      // real
      Normalize.ShipTo(ref data);
      ...
      // call Shipments.CreateShipment() using the "Functional" method above





  