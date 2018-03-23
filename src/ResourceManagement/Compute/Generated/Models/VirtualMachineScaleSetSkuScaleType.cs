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
    /// Defines values for VirtualMachineScaleSetSkuScaleType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VirtualMachineScaleSetSkuScaleType
    {
        [EnumMember(Value = "Automatic")]
        Automatic,
        [EnumMember(Value = "None")]
        None
    }
    internal static class VirtualMachineScaleSetSkuScaleTypeEnumExtension
    {
        internal static string ToSerializedValue(this VirtualMachineScaleSetSkuScaleType? value)
        {
            return value == null ? null : ((VirtualMachineScaleSetSkuScaleType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this VirtualMachineScaleSetSkuScaleType value)
        {
            switch (value)
            {
                case VirtualMachineScaleSetSkuScaleType.Automatic:
                    return "Automatic";
                case VirtualMachineScaleSetSkuScaleType.None:
                    return "None";
            }
            return null;
        }

        internal static VirtualMachineScaleSetSkuScaleType? ParseVirtualMachineScaleSetSkuScaleType(this string value)
        {
            switch (value)
            {
                case "Automatic":
                    return VirtualMachineScaleSetSkuScaleType.Automatic;
                case "None":
                    return VirtualMachineScaleSetSkuScaleType.None;
            }
            return null;
        }
    }
}
