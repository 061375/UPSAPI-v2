using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Normalize.IQMS.Models
{
    internal class Service
    {
        /** 
            select 
                f.descrip,
                f.service_code,
                f.scac_iata_code
            from freight f,shipments s where s.freight_id = f.id;
        */
        public static readonly Dictionary<string, string> Data = new Dictionary<string, string>()
        {
            {"service_code","Service"},
            {"scac_iata_code","Scac"},
            {"descrip","Descrip"}
        };
    }
}
