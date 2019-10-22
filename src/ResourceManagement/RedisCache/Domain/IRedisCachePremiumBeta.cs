// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure Redis cache with Premium SKU.
    /// </summary>
    public interface IRedisCachePremiumBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Adds a linked server to the current Redis cache instance.
        /// </summary>
        /// <param name="linkedRedisCacheId">The resource Id of the Redis instance to link with.</param>
        /// <param name="linkedServerLocation">The location of the linked Redis instance.</param>
        /// <param name="role">The role of the linked server.</param>
        /// <return>Name of the linked server.</return>
        string AddLinkedServer(string linkedRedisCacheId, string linkedServerLocation, ReplicationRole role);

        /// <summary>
        /// Adds a linked server to the current Redis cache instance.
        /// </summary>
        /// <param name="linkedRedisCacheId">The resource Id of the Redis instance to link with.</param>
        /// <param name="linkedServerLocation">The location of the linked Redis instance.</param>
        /// <param name="role">The role of the linked server.</param>
        /// <return>Name of the linked server.</return>
        Task<string> AddLinkedServerAsync(string linkedRedisCacheId, string linkedServerLocation, ReplicationRole role, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the role for the linked server of the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        /// <return>The role of the linked server.</return>
        Models.ReplicationRole GetLinkedServerRole(string linkedServerName);

        /// <summary>
        /// Gets the role for the linked server of the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        /// <return>The role of the linked server.</return>
        Task<Models.ReplicationRole> GetLinkedServerRoleAsync(string linkedServerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of linked servers associated with this redis cache.
        /// </summary>
        /// <return>The Roles of the linked servers, indexed by name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.ReplicationRole> ListLinkedServers();

        /// <summary>
        /// Gets the list of linked servers associated with this redis cache.
        /// </summary>
        /// <return>The Roles of the linked servers, indexed by name.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string, Models.ReplicationRole>> ListLinkedServersAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes the linked server from the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        void RemoveLinkedServer(string linkedServerName);

        /// <summary>
        /// Removes the linked server from the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        Task RemoveLinkedServerAsync(string linkedServerName, CancellationToken cancellationToken = default(CancellationToken));
    }
}