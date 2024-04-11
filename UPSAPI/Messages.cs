using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2
{
    internal class Messages
    {
        public static readonly Dictionary<string, string> Errors = new Dictionary<string, string>()
        {
            {"required","{1} is a required field : value(s) = {0} {2} {3}" },
            {"requiredif","{0} {2} {3} is a required field if {1} is present" },
            {"notrec","{1} is not recognized as a valid value : value(s) = {0} {2} {3}" },
            {"service","{0} is not a recognized UPS service" },
            {"minmax","min or max values of {0} exceeded" },
            {"simplerate","{0} is not a recognized UPS Simple rate" },
            {"upspremier","{0} is not a recognized UPS Premier rate" },
            {"delivconf","{0} is not a recognized UPS Delivery Confirmation DCISType" },
            {"declareval","{0} is not a recognized UPS Declared Value Code" },
            {"noticecode","{0} is not a recognized UPS Notification Code or Subject Code" },
            {"unknown","An unknown error occured" }
        };
    }
    
}