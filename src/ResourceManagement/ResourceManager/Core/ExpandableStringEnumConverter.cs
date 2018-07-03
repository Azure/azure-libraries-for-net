// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// Json converter for expandable enums.
    /// </summary>
    public class ExpandableStringEnumConverter<T> : JsonConverter where T : ExpandableStringEnum<T>, new()
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            T target = ExpandableStringEnum<T>.Parse(reader.Value as string);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null || !(value is T))
            {
                writer.WriteNull();
            }
            writer.WriteValue(((T) value).Value);
        }
    }
}