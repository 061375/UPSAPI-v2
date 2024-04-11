using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2.Normalize.IQMS
{
    /**
     * Normalize common IQMS data columns that will be used in this code to minimize aliasing when building queries to pull data
     * 
     * @usage example:
     * 
     *          UPSAPI.Normalize.IQMS.Normalize Normalize = new UPSAPI.Normalize.IQMS.Normalize();
     *          Normalize.ShipTo(data);
     * 
     * 
     * */
    public class Normalize
    {
        public void Package(ref Dictionary<string, string> data)
        {
            Run(ref data, Models.Package.Data);
        }
        public void Service(ref Dictionary<string, string> data)
        {
            Run(ref data, Models.Service.Data);
        }
        public void ShipTo(ref Dictionary<string, string> data)
        {
            Run(ref data, Models.ShipTo.Data);
        }
        public void ShipFrom(ref Dictionary<string, string> data)
        {
            Run(ref data, Models.ShipFrom.Data);
        }
        public void All(ref Dictionary<string, string> data)
        {
            Service(ref data);
            ShipTo(ref data);
            ShipFrom(ref data);
        }
        private void Run(ref Dictionary<string, string> data, Dictionary<string, string> model)
        {
            foreach(KeyValuePair<string, string> kvp in model)
            {
                if(data.ContainsKey(kvp.Key))
                {
                    if(!string.IsNullOrEmpty(kvp.Value))
                        data[kvp.Value] = data[kvp.Key];
                }
            }
        }
    }
}
