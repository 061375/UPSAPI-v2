using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models.Properties
{
    public struct AddressValidation
    {
        public string TransactionReference;
        public AddressRequestOptions RequestOption;
        public string RegionalRequestIndicator;
        public int MaximumCandidateListSize;
        public string ConsigneeName;
        public string AttentionName;
        public List<string> AddressLine;
        public string Region;
        public string City;
        public string State;
        public int Zip;
        public int ZipExt;
        public string Urbanization;
        public string CountryCode;
    }
    public enum AddressRequestOptions
    {
        Validation = 1,
        Classification = 2,
        ValidationAndClassification = 3
    }
}
