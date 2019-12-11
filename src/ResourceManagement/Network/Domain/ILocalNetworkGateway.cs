// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.LocalNetworkGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for Local Network Gateway management API in Azure.
    /// </summary>
    public interface ILocalNetworkGateway :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager, Models.LocalNetworkGatewayInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<LocalNetworkGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.IUpdatableWithTags<Microsoft.Azure.Management.Network.Fluent.ILocalNetworkGateway>
    {
        /// <summary>
        /// Gets local network site address spaces.
        /// </summary>
        System.Collections.Generic.ISet<string> AddressSpaces { get; }

        /// <summary>
        /// Gets IP address of local network gateway.
        /// </summary>
        string IPAddress { get; }

        /// <summary>
        /// Gets local network gateway's BGP speaker settings.
        /// </summary>
        Models.BgpSettings BgpSettings { get; }

        /// <summary>
        /// Gets the provisioning state of the LocalNetworkGateway resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }
    }
}