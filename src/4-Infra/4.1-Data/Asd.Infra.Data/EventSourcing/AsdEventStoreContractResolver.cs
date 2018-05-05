namespace Asd.Infra.Data.EventSourcing
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Reflection;

    public class AsdEventStoreContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            var property = base.CreateProperty(member, memberSerialization);
            var propertyType = property.PropertyType;

            if (propertyType == typeof(bool) ||
                propertyType == typeof(byte) ||
                propertyType == typeof(DateTime) ||
                propertyType == typeof(decimal) ||
                propertyType == typeof(double) ||
                propertyType == typeof(float) ||
                propertyType == typeof(Guid) ||
                propertyType == typeof(int) ||
                propertyType == typeof(Int16) ||
                propertyType == typeof(Int32) ||
                propertyType == typeof(Int64) ||
                propertyType == typeof(sbyte) ||
                propertyType == typeof(SByte) ||
                propertyType == typeof(string) ||
                propertyType == typeof(String) ||
                propertyType == typeof(TimeSpan))
                property.Ignored = false;
            else
                property.Ignored = true;

            return property;
        }
    }
}