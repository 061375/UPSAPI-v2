using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Models.Columns
{
    internal class Address
    {
        public static List<string> Validation = new List<string>()
        {
            "TransactionReference",
            "MaximumCandidateListSize",
            "ConsigneeName",
            "AttentionName",
            "AddressLine1",
            "AddressLine2",
            "AddressLine3",
            "Region",
            "City",
            "State",
            "Zip",
            "ZipExt",
            "CountryCode"
        };
    }
}
