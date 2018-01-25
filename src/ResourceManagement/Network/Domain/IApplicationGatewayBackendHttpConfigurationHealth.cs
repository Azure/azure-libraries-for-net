// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of the health information of an application gateway backend HTTP settings configuration.
    /// </summary>
    public interface IApplicationGatewayBackendHttpConfigurationHealth :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayBackendHealthHttpSettings>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHealth>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName
    {
        /// <summary>
        /// Gets the associated application gateway backend HTTP configuration settings this health information pertains to.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration BackendHttpConfiguration { get; }

        /// <summary>
        /// Gets information about the health of each backend server, indexed by the server's IP address.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendServerHealth> ServerHealths { get; }
    }
}