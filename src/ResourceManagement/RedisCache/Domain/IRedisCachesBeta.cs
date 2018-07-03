// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for Redis Cache management API.
    /// </summary>
    public interface IRedisCachesBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Lists all of the available Redis REST API operations.
        /// </summary>
        /// <return>List of available Redis REST operations.</return>
        System.Collections.Generic.IEnumerable<Models.Operation> ListOperations();

        /// <summary>
        /// Lists all of the available Redis REST API operations.
        /// </summary>
        /// <return>A representation of the future computation of this call.</return>
        Task<System.Collections.Generic.IEnumerable<Models.Operation>> ListOperationsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}