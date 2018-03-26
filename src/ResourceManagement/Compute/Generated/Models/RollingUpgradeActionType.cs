// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for RollingUpgradeActionType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RollingUpgradeActionType
    {
        [EnumMember(Value = "Start")]
        Start,
        [EnumMember(Value = "Cancel")]
        Cancel
    }
    internal static class RollingUpgradeActionTypeEnumExtension
    {
        internal static string ToSerializedValue(this RollingUpgradeActionType? value)
        {
            return value == null ? null : ((RollingUpgradeActionType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this RollingUpgradeActionType value)
        {
            switch( value )
            {
                case RollingUpgradeActionType.Start:
                    return "Start";
                case RollingUpgradeActionType.Cancel:
                    return "Cancel";
            }
            return null;
        }

        internal static RollingUpgradeActionType? ParseRollingUpgradeActionType(this string value)
        {
            switch( value )
            {
                case "Start":
                    return RollingUpgradeActionType.Start;
                case "Cancel":
                    return RollingUpgradeActionType.Cancel;
            }
            return null;
        }
    }
}
