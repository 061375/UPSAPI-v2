using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Normalize.IQMS.Models
{
    internal class Package
    {
        /** 
            select 
                c.pono,
                sp.service_code,
                sp.box_count,
                sp.package_code,
                sp.weight_uom,
                sp.dimension_uom,
                sp.length,
                sp.width,
                sp.height,
                sp.actual_weight
            from c_ship_hist c, shipment_packages sp
            where c.shipments_id = sp.shipments_id;
        */
        public static readonly Dictionary<string, string> Data = new Dictionary<string, string>()
        {
            {"service_code","Description"},
            {"box_count","NumOfPieces"},
            {"package_code","PackagingType"},
            {"weight_uom","UnitOfWeightMeasurement"},
            {"dimension_uom","UnitOfLengthMeasurement"},
            {"length","DimensionsLength"},
            {"width","DimensionsWidth"},
            {"height","DimensionsHeight"},
            {"actual_weight","DimWeight"},
            {"billable_weight","PackageWeight"},
            {"pono","ReferenceNumber"}
        };
    }
}
