// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class ApplicationGatewayBackendServerHealthImpl
    {
        /// <summary>
        /// Gets the IP configuration of the network interface this health information pertains to.
        /// </summary>
        /// <return>A network interface IP configuration.</return>
        Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendServerHealth.GetNetworkInterfaceIPConfiguration()
        {
            return this.GetNetworkInterfaceIPConfiguration();
        }

        /// <summary>
        /// Gets the health status of the server.
        /// </summary>
        Models.ApplicationGatewayBackendHealthStatus Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendServerHealth.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets IP address of the server this health information pertains to.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendServerHealth.IPAddress
        {
            get
            {
                return this.IPAddress();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationHealth Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationHealth>.Parent
        {
            get
            {
                return this.Parent();
            }
        }
    }
}