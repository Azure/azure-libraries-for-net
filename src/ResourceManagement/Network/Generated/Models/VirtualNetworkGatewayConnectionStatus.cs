// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for VirtualNetworkGatewayConnectionStatus.
    /// </summary>
    public class VirtualNetworkGatewayConnectionStatus : ExpandableStringEnum<VirtualNetworkGatewayConnectionStatus>
    {
        public static readonly VirtualNetworkGatewayConnectionStatus Unknown = Parse("Unknown");
        public static readonly VirtualNetworkGatewayConnectionStatus Connecting = Parse("Connecting");
        public static readonly VirtualNetworkGatewayConnectionStatus Connected = Parse("Connected");
        public static readonly VirtualNetworkGatewayConnectionStatus NotConnected = Parse("NotConnected");
    }
}
