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
    /// Defines values for TransparentDataEncryptionState.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransparentDataEncryptionState
    {
        [EnumMember(Value = "Enabled")]
        Enabled,
        [EnumMember(Value = "Disabled")]
        Disabled
    }
    internal static class TransparentDataEncryptionStatusEnumExtension
    {
        internal static string ToSerializedValue(this TransparentDataEncryptionState? value)
        {
            return value == null ? null : ((TransparentDataEncryptionState)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this TransparentDataEncryptionState value)
        {
            switch( value )
            {
                case TransparentDataEncryptionState.Enabled:
                    return "Enabled";
                case TransparentDataEncryptionState.Disabled:
                    return "Disabled";
            }
            return null;
        }

        internal static TransparentDataEncryptionState? ParseTransparentDataEncryptionStatus(this string value)
        {
            switch( value )
            {
                case "Enabled":
                    return TransparentDataEncryptionState.Enabled;
                case "Disabled":
                    return TransparentDataEncryptionState.Disabled;
            }
            return null;
        }
    }
}
