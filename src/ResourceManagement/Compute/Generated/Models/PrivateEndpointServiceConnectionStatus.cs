// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Management.ResourceManager;
    using Management.ResourceManager.Fluent;
    using Management.ResourceManager.Fluent.Core;

    using Newtonsoft.Json;
    /// <summary>
    /// Defines values for PrivateEndpointServiceConnectionStatus.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(Management.ResourceManager.Fluent.Core.ExpandableStringEnumConverter<PrivateEndpointServiceConnectionStatus>))]
    public class PrivateEndpointServiceConnectionStatus : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<PrivateEndpointServiceConnectionStatus>
    {
        public static readonly PrivateEndpointServiceConnectionStatus Pending = Parse("Pending");
        public static readonly PrivateEndpointServiceConnectionStatus Approved = Parse("Approved");
        public static readonly PrivateEndpointServiceConnectionStatus Rejected = Parse("Rejected");
    }
}
