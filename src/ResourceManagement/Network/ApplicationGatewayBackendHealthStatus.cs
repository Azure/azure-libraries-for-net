// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayBackendHealthStatus : ExpandableStringEnum<ApplicationGatewayBackendHealthStatus>
    {
        public static readonly ApplicationGatewayBackendHealthStatus Unknown = Parse(ApplicationGatewayBackendHealthServerHealth.Unknown.ToString());
        public static readonly ApplicationGatewayBackendHealthStatus Up = Parse(ApplicationGatewayBackendHealthServerHealth.Up.ToString());
        public static readonly ApplicationGatewayBackendHealthStatus Down = Parse(ApplicationGatewayBackendHealthServerHealth.Down.ToString());
        public static readonly ApplicationGatewayBackendHealthStatus Partial = Parse(ApplicationGatewayBackendHealthServerHealth.Partial.ToString());
        public static readonly ApplicationGatewayBackendHealthStatus Draining = Parse(ApplicationGatewayBackendHealthServerHealth.Draining.ToString());
        public static readonly ApplicationGatewayBackendHealthStatus Unhealthy = Parse("Unhealthy");
    }
}
