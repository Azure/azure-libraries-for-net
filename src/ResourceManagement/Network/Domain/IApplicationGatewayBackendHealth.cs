// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation of the health information of an application gateway backend.
    /// </summary>
    public interface IApplicationGatewayBackendHealth :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayBackendHealthPool>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>
    {
        /// <summary>
        /// Gets the health information about each associated backend HTTP settings configuration, indexed by its name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationHealth> HttpConfigurationHealths { get; }

        /// <summary>
        /// Gets the application gateway backend address pool that is health information pertains to.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend Backend { get; }
    }
}