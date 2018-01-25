// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation of the health information of an application gateway backend server.
    /// </summary>
    public interface IApplicationGatewayBackendServerHealth :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayBackendHealthServer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationHealth>
    {
        /// <summary>
        /// Gets the IP configuration of the network interface this health information pertains to.
        /// </summary>
        /// <return>A network interface IP configuration.</return>
        Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration GetNetworkInterfaceIPConfiguration();

        /// <summary>
        /// Gets IP address of the server this health information pertains to.
        /// </summary>
        string IPAddress { get; }

        /// <summary>
        /// Gets the health status of the server.
        /// </summary>
        Models.ApplicationGatewayBackendHealthStatus Status { get; }
    }
}