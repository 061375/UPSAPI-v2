using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPSAPIv2.Models;

namespace UPSAPIv2
{
    internal class Response
    {
        private static Models._Root _Response { get; set; }
        public static bool Parse(string json)
        {
            Public.Errors.Clear();
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    Public.Errors.Add(Messages.Errors["unknown"]);
                    return false;
                }
                _Response = JsonConvert.DeserializeObject<Models._Root>(json);
                if (
                       _Response?.ShipmentResponse != null
                    || _Response?.XAVResponse != null)
                {
                    return true;
                }
                if (_Response?.Response == null)
                {
                    Public.Errors.Add(Messages.Errors["unknown"]);
                    return false;
                }
                // currently the documentation appears to only use Response for error BUt that might not always be the case so if Response does not contain the Errors section we'll assume it's good
                if (_Response?.Response.Errors == null)
                {
                    return true;
                }
                foreach (Errors error in _Response.Response.Errors)
                {
                    Public.Errors.Add(error.Message);
                }
                return false;
            }
            catch (Exception e)
            {
                Libs.Helpers.LogError(e.ToString());
                return false;
            }
        }
        public static Models._Root Get()
        {
            return _Response;
        }
    }
}