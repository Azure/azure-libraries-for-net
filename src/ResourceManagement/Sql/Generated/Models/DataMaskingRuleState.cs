// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for DataMaskingRuleState.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataMaskingRuleState
    {
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "Enabled")]
        Enabled
    }
    internal static class DataMaskingRuleStateEnumExtension
    {
        internal static string ToSerializedValue(this DataMaskingRuleState? value)
        {
            return value == null ? null : ((DataMaskingRuleState)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this DataMaskingRuleState value)
        {
            switch( value )
            {
                case DataMaskingRuleState.Disabled:
                    return "Disabled";
                case DataMaskingRuleState.Enabled:
                    return "Enabled";
            }
            return null;
        }

        internal static DataMaskingRuleState? ParseDataMaskingRuleState(this string value)
        {
            switch( value )
            {
                case "Disabled":
                    return DataMaskingRuleState.Disabled;
                case "Enabled":
                    return DataMaskingRuleState.Enabled;
            }
            return null;
        }
    }
}
