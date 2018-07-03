// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayBackendHttpConfigurationHealthImpl
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHealth Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHealth>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets information about the health of each backend server, indexed by the server's IP address.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendServerHealth> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationHealth.ServerHealths
        {
            get
            {
                return this.ServerHealths();
            }
        }

        /// <summary>
        /// Gets the associated application gateway backend HTTP configuration settings this health information pertains to.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationHealth.BackendHttpConfiguration
        {
            get
            {
                return this.BackendHttpConfiguration();
            }
        }
    }
}