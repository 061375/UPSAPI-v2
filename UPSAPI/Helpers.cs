using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2
{
    internal class Helpers
    {
        /// <summary>
        /// Test if a type implements IList of T, and if so, determine T.
        /// </summary>
        public static bool TryListOfWhat(Type type, out Type innerType)
        {
            Contract.Requires(type != null);

            var interfaceTest = new Func<Type, Type>(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>) ? i.GetGenericArguments().Single() : null);

            innerType = interfaceTest(type);
            if (innerType != null)
            {
                return true;
            }

            foreach (var i in type.GetInterfaces())
            {
                innerType = interfaceTest(i);
                if (innerType != null)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool isnull(string test, string error, params string[] _else)
        {
            string[] __else = new string[_else.Length + 1];
            __else[0] = test;
            for (int i = 0; i < _else.Length; i++)
            {
                __else[i] = _else[i];
            }
            for (int i = 0; i < __else.Length; i++)
                if (!string.IsNullOrEmpty(__else[i]))
                {
                    return true;
                }
            Helpers.RecordError(error, __else);
            return false;
        }
        public static string isnullelse(string test, string _else = "")
        {
            return string.IsNullOrEmpty(test) ? _else : test;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="_key"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool isset(Dictionary<string, string> data, string _key, string error, string _parent = null, bool list = false)
        {
            string __key = _key;
            string[] _else = new string[2];
            _else[0] = _key;
            if (null != _parent) _else[1] = _parent;
            //__key = _parent + " -> " + _key;

            if (!data.ContainsKey(_key))
            {
                if (list) Validation.DumpValid(data);
                Helpers.RecordError(error, _else);
                return false;
            }
            if (string.IsNullOrEmpty(data[_key]))
            {
                if (list) Validation.DumpValid(data);
                Helpers.RecordError(error, _else);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="_key"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool required(string data, string _key)
        {
            if (string.IsNullOrEmpty(data))
            {
                Helpers.RecordError(Messages.Errors["required"], _key);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="error"></param>
        /// <param name="_params"></param>
        /// <returns></returns>
        public static bool issetif(Dictionary<string, string> data, string error, params string[] _params)
        {
            if (!data.ContainsKey(_params[0]))
            {
                Helpers.RecordError(error, _params);
                return false;
            }
            if (string.IsNullOrEmpty(data[_params[0]]))
            {
                Helpers.RecordError(error, _params);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="error"></param>
        /// <param name="_params"></param>
        /// <returns></returns>
        public static bool Contains(List<string> data, string error, params string[] _params)
        {
            if (!data.Contains(_params[0]))
            {
                Helpers.RecordError(error, _params);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="_params"></param>
        /// <returns></returns>
        public static string RecordError(string message, params string[] _params)
        {
            if (Public.Errors.Count == 0)
                Public.Errors.Add("ERROR: ");
            for (int i = 0; i < _params.Length; i++)
            {
                message = message.Replace("{" + i + "}", _params[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                message = message.Replace("{" + i + "}", "");
            }
            Libs.Helpers.WriteLog(message);
            Public.Errors.Add(message);
            return message;
        }
        public static bool MinMaxValid(int val, List<int> minmax, string error = null, params string[] _params)
        {
            bool _return = true;
            if (val <= minmax[0]) _return = false;
            if (val >= minmax[1]) _return = false;
            if (!_return && !string.IsNullOrEmpty(error))
            {
                Console.WriteLine($"Valid min:{minmax[0]} max:{minmax[1]}");
                Helpers.RecordError(error, _params);
            }
            return _return;
        }
        public static void InitDict(ref Dictionary<string, string> data, List<string> _keys)
        {
            foreach (string k in _keys)
            {
                if (!data.ContainsKey(k)) { data[k] = ""; }
            }
        }
    }
}
