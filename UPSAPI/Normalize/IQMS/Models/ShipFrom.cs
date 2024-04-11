using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Normalize.IQMS.Models
{
    internal class ShipFrom
    {
        /** 
            select 
                company,
                company as company_attn,
                phone,
                fax,
                address1,
                address2,
                address3,
                city,
                state,
                zip,
                country
            from company;
        **/
        public static readonly Dictionary<string, string> Data = new Dictionary<string, string>()
        {
            {"company","Name"},
            {"company_attn","AttentionName"},
            {"phone","Phone"},
            {"fax","FaxNumber"},
            {"address1","Address1"},
            {"address2","Address2"},
            {"address3","Address3"},
            {"city","City"},
            {"state","State"},
            {"zip","Zip"},
            {"country","Country"}
        };
    }
}
