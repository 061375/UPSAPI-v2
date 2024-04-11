using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class IgnoreEmptyObjectContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        // Check if the property type is a class (but not string, since it's a special case) and set ShouldSerialize
        if (property.PropertyType != typeof(string) && property.PropertyType.IsClass)
        {
            property.ShouldSerialize = instance =>
            {
                var value = property.ValueProvider.GetValue(instance);
                if (value == null)
                {
                    return false;
                }

                // Check if the object has any non-null or non-default values
                var type = value.GetType();
                var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                // Adjusted to pass PropertyInfo to IsDefaultValue correctly
                return properties.Any(prop => {
                    var propValue = prop.GetValue(value);
                    return propValue != null && !IsDefaultValue(prop, propValue);
                });
            };
        }

        return property;
    }

    private bool IsDefaultValue(PropertyInfo prop, object value)
    {
        // Check if the value is the default for its type
        var defaultValue = prop.PropertyType.IsValueType ? Activator.CreateInstance(prop.PropertyType) : null;
        return Equals(value, defaultValue);
    }
}
