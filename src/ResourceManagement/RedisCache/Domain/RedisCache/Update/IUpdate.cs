// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The template for a Redis Cache update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate>,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IWithSku,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IWithNonSslPort,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IWithRedisConfiguration,
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdateBeta
    {

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek dayOfWeek, int startHourUtc);

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek dayOfWeek, int startHourUtc, TimeSpan maintenanceWindow);

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">Patch schedule entry for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(ScheduleEntry scheduleEntry);

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">List of patch schedule entries for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPatchSchedule(IList<Microsoft.Azure.Management.Redis.Fluent.Models.ScheduleEntry> scheduleEntry);

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">The shard count value to set.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithShardCount(int shardCount);
    }

    /// <summary>
    /// A Redis Cache update allowing Redis configuration to be modified.
    /// </summary>
    public interface IWithRedisConfiguration 
    {

        /// <summary>
        /// Cleans all the configuration settings being set on Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutRedisConfiguration();

        /// <summary>
        /// Removes specified Redis Cache configuration setting.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutRedisConfiguration(string key);

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">Configuration of Redis Cache as a map indexed by configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithRedisConfiguration(IDictionary<string,string> redisConfiguration);

        /// <summary>
        /// Specifies Redis Setting.
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <param name="value">Redis configuration value.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithRedisConfiguration(string key, string value);
    }

    /// <summary>
    /// A Redis Cache update stage allowing to change the parameters.
    /// </summary>
    public interface IWithSku 
    {

        /// <summary>
        /// Updates Redis Cache to Basic sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithBasicSku(int capacity);

        /// <summary>
        /// Updates Redis Cache to Premium sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPremiumSku();

        /// <summary>
        /// Updates Redis Cache to Premium sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Premium sku with P family (1, 2, 3, 4).</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithPremiumSku(int capacity);

        /// <summary>
        /// Updates Redis Cache to Standard sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithStandardSku();

        /// <summary>
        /// Updates Redis Cache to Standard sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithStandardSku(int capacity);
    }

    /// <summary>
    /// A Redis Cache update allowing non SSL port to be enabled or disabled.
    /// </summary>
    public interface IWithNonSslPort 
    {

        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithNonSslPort();

        /// <summary>
        /// Disables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutNonSslPort();
    }

    /// <summary>
    /// The template for a Redis Cache update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdateBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Creates or updates Redis cache firewall rule with range of IP addresses permitted to connect to the cache.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        /// <param name="lowestIp">Lowest IP address included in the range.</param>
        /// <param name="highestIp">Highest IP address included in the range.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithFirewallRule(string name, string lowestIp, string highestIp);

        /// <summary>
        /// Creates or updates Redis cache firewall rule with range of IP addresses permitted to connect to the cache.
        /// </summary>
        /// <param name="rule">Firewall rule that specifies name, lowest and highest IP address included in the range of permitted IP addresses.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithFirewallRule(IRedisFirewallRule rule);

        /// <summary>
        /// Requires clients to use a specified TLS version (or higher) to connect (e,g, '1.0', '1.1', '1.2').
        /// </summary>
        /// <param name="tlsVersion">Minimum TLS version.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithMinimumTlsVersion(TlsVersion tlsVersion);

        /// <summary>
        /// Deletes a single firewall rule in the current Redis cache instance.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        /// <return>The next stage of Redis Cache update.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutFirewallRule(string name);

        /// <summary>
        /// Removes the requirement for clients minimum TLS version.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutMinimumTlsVersion();

        /// <summary>
        /// Removes all Patch schedules from the current Premium Cluster Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update.IUpdate WithoutPatchSchedule();
    }
}