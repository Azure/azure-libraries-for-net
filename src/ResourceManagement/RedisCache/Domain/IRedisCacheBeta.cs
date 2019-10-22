// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Redis Cache.
    /// </summary>
    public interface IRedisCacheBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets Firewall Rules in the Redis Cache, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.IRedisFirewallRule> FirewallRules { get; }

        /// <summary>
        /// Gets the minimum TLS version (or higher) that clients require to use.
        /// </summary>
        Models.TlsVersion MinimumTlsVersion { get; }

        /// <summary>
        /// Gets List of patch schedules for current Redis Cache.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ScheduleEntry> PatchSchedules { get; }
    }
}