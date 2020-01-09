// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;

    public interface IPrivateLinkServiceConnection
    {
        /// <summary>
        /// Gets the provisioning state of the private link service connection
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the resource id of private link service.
        /// </summary>
        string PrivateLinkServiceId { get; }

        /// <summary>
        /// Gets the ID(s) of the group(s) obtained from the remote
        /// resource that this private endpoint should connect to.
        /// </summary>
        IReadOnlyList<string> GroupIds { get; }

        /// <summary>
        /// Gets a message passed to the owner of the remote resource
        /// with this connection request. Restricted to 140 chars.
        /// </summary>
        string RequestMessage { get; }

        /// <summary>
        /// Gets a collection of read-only information about the state
        /// of the connection to the remote resource.
        /// </summary>
        PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; }

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
