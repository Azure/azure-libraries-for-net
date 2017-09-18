// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// The state of the virtual network peering.
    /// </summary>
    public class NetworkPeeringState : ExpandableStringEnum<NetworkPeeringState>
    {
        public static readonly NetworkPeeringState Initiated = Parse("Initiated");
        public static readonly NetworkPeeringState Connected = Parse("Connected");
        public static readonly NetworkPeeringState Disconnected = Parse("Disconnected");
    }
}
