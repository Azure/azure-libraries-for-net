// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.BatchAI;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VmPriority.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VmPriority
    {
        [EnumMember(Value = "dedicated")]
        Dedicated,
        [EnumMember(Value = "lowpriority")]
        Lowpriority
    }
    internal static class VmPriorityEnumExtension
    {
        internal static string ToSerializedValue(this VmPriority? value)
        {
            return value == null ? null : ((VmPriority)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this VmPriority value)
        {
            switch( value )
            {
                case VmPriority.Dedicated:
                    return "dedicated";
                case VmPriority.Lowpriority:
                    return "lowpriority";
            }
            return null;
        }

        internal static VmPriority? ParseVmPriority(this string value)
        {
            switch( value )
            {
                case "dedicated":
                    return VmPriority.Dedicated;
                case "lowpriority":
                    return VmPriority.Lowpriority;
            }
            return null;
        }
    }
}