using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Normalize.IQMS.Models
{
    internal class ShipTo
    {
        /** 
            select 
                st.attn,
                s.ship_to_attn,
                s.ship_to_phone_number,
                s.ship_to_fax,
                s.ship_to_addr1,
                s.ship_to_addr2,
                s.ship_to_addr3,
                s.ship_to_city,
                s.ship_to_state,
                s.ship_to_zip,
                s.ship_to_country
             from ship_to st,shipments s where s.ship_to_id = st.id;
        */
        public static readonly Dictionary<string, string> Data = new Dictionary<string, string>()
        {
            {"attn","Name"},
            {"ship_to_attn","AttentionName"},
            {"ship_to_phone_number","Phone"},
            {"ship_to_fax","FaxNumber"},
            {"ship_to_addr1","Address1" },
            {"ship_to_addr2","Address2" },
            {"ship_to_addr3","Address3" },
            {"ship_to_city","City" },
            {"ship_to_state","State" },
            {"ship_to_zip","Zip" },
            {"ship_to_country","Country"},
            {"phone_number","Phone"},
            {"fax","FaxNumber"},
            {"addr1","Address1" },
            {"addr2","Address2" },
            {"addr3","Address3" },
            {"city","City" },
            {"state","State" },
            {"zip","Zip" },
            {"country","Country" }
        };
    }
}
