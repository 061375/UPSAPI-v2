using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UPSAPIv2.Models;
using UPSAPIv2.Models.Properties;

namespace UPSAPIv2.api
{
    public class AddressValidation
    {
        private Models._Root root = new Models._Root();
        private Models.XAVRequest XAVRequest = new Models.XAVRequest();

        public List<Dictionary<string, string>> Candidates = new List<Dictionary<string, string>>();
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
        public bool Create(AddressValid properties)
        {
            // validate
            if (!Helpers.MinMaxValid(properties.Properties.MaximumCandidateListSize,
                Validation.MaximumCandidateListSize,Messages.Errors["minmax"],
                "MaximumCandidateListSize")) return false;
            // ! validate
            if (string.IsNullOrEmpty(properties.Properties.CountryCode)) properties.Properties.CountryCode = Params.DefaultCountry;

            XAVRequest.Request = new Models.Request();
            switch(properties.Properties.RequestOption.ToString())
            {
                case "Validation":
                    XAVRequest.Request.RequestOption = "1";
                    break;
                case "Classification":
                    XAVRequest.Request.RequestOption = "2";
                    break;
                case "ValidationAndClassification":
                    XAVRequest.Request.RequestOption = "3";
                    break;
            }
            XAVRequest.Request.TransactionReference = new TransactionReference();
            XAVRequest.Request.TransactionReference.CustomerContext = properties.Properties.TransactionReference;
            XAVRequest.RegionalRequestIndicator = properties.Properties.RegionalRequestIndicator;
            XAVRequest.MaximumCandidateListSize = properties.Properties.MaximumCandidateListSize.ToString();
            XAVRequest.AddressKeyFormat = new Models.AddressKeyFormat();
            XAVRequest.AddressKeyFormat.ConsigneeName = properties.Properties.ConsigneeName;
            XAVRequest.AddressKeyFormat.AttentionName = properties.Properties.AttentionName;
            XAVRequest.AddressKeyFormat.AddressLine = properties.Properties.AddressLine;
            XAVRequest.AddressKeyFormat.Region = properties.Properties.Region;
            XAVRequest.AddressKeyFormat.PoliticalDivision2 = properties.Properties.City;
            XAVRequest.AddressKeyFormat.PoliticalDivision1 = properties.Properties.State;
            XAVRequest.AddressKeyFormat.PostcodePrimaryLow = properties.Properties.Zip.ToString();
            XAVRequest.AddressKeyFormat.PostcodeExtendedLow = properties.Properties.ZipExt.ToString();
            XAVRequest.AddressKeyFormat.Urbanization = properties.Properties.Urbanization;
            XAVRequest.AddressKeyFormat.CountryCode = properties.Properties.CountryCode;

            root.XAVRequest = XAVRequest;

            return true;

        }
        public bool Create(Dictionary<string,string> Data)
        {
            // validate
            if (!Helpers.isset(Data, "RequestOption", Messages.Errors["required"], "RequestOption")) return false;
            // ! validate
            Helpers.InitDict(ref Data, Models.Columns.Address.Validation);
            AddressValid properties = new AddressValid();
            properties.Properties.RequestOption = new Models.Properties.AddressRequestOptions();
            switch (Data["RequestOption"])
            {
                case "Validation":
                    properties.Properties.RequestOption = AddressRequestOptions.Validation;
                    break;
                case "Classification":
                    properties.Properties.RequestOption = AddressRequestOptions.Classification;
                    break;
                case "ValidationAndClassification":
                    properties.Properties.RequestOption = AddressRequestOptions.ValidationAndClassification;
                    break;
                default:
                    // error
                    Helpers.RecordError(Messages.Errors["notrec"], "Validation","RequestOption", "Classification", "ValidationAndClassification");
                    return false;
            }
            properties.Properties.TransactionReference = Data["TransactionReference"];
            properties.Properties.MaximumCandidateListSize = Libs.Helpers.GetToInt32(Data["MaximumCandidateListSize"], "15");
            properties.Properties.ConsigneeName = Data["ConsigneeName"];
            properties.Properties.AttentionName = Data["AttentionName"];
            properties.Properties.AddressLine = new List<string>
            {
                Data["AddressLine1"],
                Data["AddressLine2"],
                Data["AddressLine3"]
            };
            properties.Properties.Region = Data["Region"];
            properties.Properties.City = Data["City"];
            properties.Properties.State = Data["State"];
            properties.Properties.Zip = Libs.Helpers.GetToInt32(Data["Zip"]);
            properties.Properties.ZipExt = Libs.Helpers.GetToInt32(Data["ZipExt"]);
            properties.Properties.CountryCode = Libs.Helpers.isset(Data, "CountryCode",Params.DefaultCountry);

            return Create(properties);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public AddressValidation GetResponse(string json)
        {
            Libs.Helpers.LogMethod();
            Candidates.Clear();

            if (!Response.Parse(json))
            {
                Libs.Helpers.WriteLog("Unable to get response from JSON");
                return this;
            }
            root = Response.Get();
            
            foreach (Models.Candidate p in root.XAVResponse.Candidate)
            {
                Dictionary<string, string> tmp = new Dictionary<string, string>();
                tmp["Urbanization"] = p.AddressKeyFormat.Urbanization;
                tmp["Region"] = p.AddressKeyFormat.Region;
                tmp["State"] = p.AddressKeyFormat.PoliticalDivision1;
                tmp["City"] = p.AddressKeyFormat.PoliticalDivision2;
                tmp["AttentionName"] = p.AddressKeyFormat.AttentionName;
                tmp["ConsigneeName"] = p.AddressKeyFormat.ConsigneeName;
                tmp["Zip"] = p.AddressKeyFormat.PostcodePrimaryLow;
                tmp["ZipExt"] = p.AddressKeyFormat.PostcodeExtendedLow;
                int i = 1;
                foreach (string a in p.AddressKeyFormat.AddressLine)
                {
                    tmp[$"AddressLine{i++}"] = a;
                }
                Candidates.Add(tmp);
            }
            return this;
        }
    }
}
