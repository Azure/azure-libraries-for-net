// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for private endpoint management API in Azure.
    /// </summary>
    public interface IPrivateEndpoint
    {
        /// <summary>
        /// Gets the ID of the subnet from which the private IP will be allocated.
        /// </summary>
        string SubnetId { get; }

        /// <summary>
        /// Gets an array of references to the network interfaces created for this private endpoint.
        /// </summary>
        IReadOnlyList<INetworkInterface> NetworkInterfaces { get; }

        /// <summary>
        /// Gets the provisioning state of the private endpoint resource.
        /// Possible values include: 'Succeeded', 'Updating', 'Deleting',
        /// 'Failed'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets a grouping of information about the connection to the remote resource.
        /// </summary>
        IReadOnlyList<IPrivateLinkServiceConnection> PrivateLinkServiceConnections { get; }

        /// <summary>
        /// Gets a grouping of information about the connection to the
        /// remote resource. Used when the network admin does not have access
        /// to approve connections to the remote resource.
        /// </summary>
        IReadOnlyList<IPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get; }

        /// <summary>
        /// Gets the name of the resource that is unique within a
        /// resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        string Etag { get; }

        /// <summary>
        /// Gets ID of the resource.
        /// </summary>
        string Id { get; }
    }
}
