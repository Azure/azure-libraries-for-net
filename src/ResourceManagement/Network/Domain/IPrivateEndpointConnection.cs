// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// Entry point for private endpoint connection management API in Azure.
    /// </summary>
    public interface IPrivateEndpointConnection
    {
        /// <summary>
        /// Gets the resource of private end point.
        /// </summary>
        IPrivateEndpoint PrivateEndpoint { get; }

        /// <summary>
        /// Gets a collection of information about the state of the
        /// connection between service consumer and provider.
        /// </summary>
        PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; }

        /// <summary>
        /// Gets the provisioning state of the private endpoint connection
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the consumer link id.
        /// </summary>
        string LinkIdentifier { get; }

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
