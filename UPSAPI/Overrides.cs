using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSAPIv2
{
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            else if (token.Type == JTokenType.Object)
            {
                List<T> singleObjectList = new List<T> { token.ToObject<T>() };
                return singleObjectList;
            }
            throw new JsonSerializationException("Unexpected token type: " + token.Type.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<T> list = value as List<T>;
            if (list != null && list.Count == 1)
            {
                // Optional: handle serialization of a single item to an object
                value = list[0];
            }
            serializer.Serialize(writer, value);
        }

        public override bool CanWrite => false; // Set to false if you only need to customize deserialization
    }
}
