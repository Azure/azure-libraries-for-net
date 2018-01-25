// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.AppService.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.AppService;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for HostingEnvironmentStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HostingEnvironmentStatus
    {
        [EnumMember(Value = "Preparing")]
        Preparing,
        [EnumMember(Value = "Ready")]
        Ready,
        [EnumMember(Value = "Scaling")]
        Scaling,
        [EnumMember(Value = "Deleting")]
        Deleting
    }
    internal static class HostingEnvironmentStatusEnumExtension
    {
        internal static string ToSerializedValue(this HostingEnvironmentStatus? value) =>
            value == null ? null : ((HostingEnvironmentStatus)value).ToSerializedValue();

        internal static string ToSerializedValue(this HostingEnvironmentStatus value)
        {
            switch (value)
            {
                case HostingEnvironmentStatus.Preparing:
                    return "Preparing";
                case HostingEnvironmentStatus.Ready:
                    return "Ready";
                case HostingEnvironmentStatus.Scaling:
                    return "Scaling";
                case HostingEnvironmentStatus.Deleting:
                    return "Deleting";
            }
            return null;
        }

        internal static HostingEnvironmentStatus? ParseHostingEnvironmentStatus(this string value)
        {
            switch (value)
            {
                case "Preparing":
                    return HostingEnvironmentStatus.Preparing;
                case "Ready":
                    return HostingEnvironmentStatus.Ready;
                case "Scaling":
                    return HostingEnvironmentStatus.Scaling;
                case "Deleting":
                    return HostingEnvironmentStatus.Deleting;
            }
            return null;
        }
    }
}
