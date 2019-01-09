// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition;
    using Microsoft.Azure.Management.Redis.Fluent.RedisCache.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RedisCacheImpl 
    {
        /// <summary>
        /// Gets Firewall Rules in the Redis Cache, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.IRedisFirewallRule> Microsoft.Azure.Management.Redis.Fluent.IRedisCacheBeta.FirewallRules
        {
            get
            {
                return this.FirewallRules();
            }
        }

        /// <summary>
        /// Gets the hostName value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.HostName
        {
            get
            {
                return this.HostName();
            }
        }

        /// <summary>
        /// Gets returns true if current Redis Cache instance has Premium Sku.
        /// </summary>
        bool Microsoft.Azure.Management.Redis.Fluent.IRedisCache.IsPremium
        {
            get
            {
                return this.IsPremium();
            }
        }

        /// <summary>
        /// Gets a Redis Cache's access keys. This operation requires write permission to the Cache resource.
        /// </summary>
        Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys Microsoft.Azure.Management.Redis.Fluent.IRedisCache.Keys
        {
            get
            {
                return this.Keys();
            }
        }

        /// <summary>
        /// Gets the minimum TLS version (or higher) that clients require to use.
        /// </summary>
        Models.TlsVersion Microsoft.Azure.Management.Redis.Fluent.IRedisCacheBeta.MinimumTlsVersion
        {
            get
            {
                return this.MinimumTlsVersion();
            }
        }

        /// <summary>
        /// Gets true if non SSL port is enabled, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Redis.Fluent.IRedisCache.NonSslPort
        {
            get
            {
                return this.NonSslPort();
            }
        }

        /// <summary>
        /// Gets List of patch schedules for current Redis Cache.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ScheduleEntry> Microsoft.Azure.Management.Redis.Fluent.IRedisCacheBeta.PatchSchedules
        {
            get
            {
                return this.PatchSchedules();
            }
        }

        /// <summary>
        /// Gets the port value.
        /// </summary>
        int Microsoft.Azure.Management.Redis.Fluent.IRedisCache.Port
        {
            get
            {
                return this.Port();
            }
        }

        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the Redis configuration value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RedisConfiguration
        {
            get
            {
                return this.RedisConfiguration();
            }
        }

        /// <summary>
        /// Gets the Redis version value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RedisVersion
        {
            get
            {
                return this.RedisVersion();
            }
        }

        /// <summary>
        /// Gets the shardCount value.
        /// </summary>
        int Microsoft.Azure.Management.Redis.Fluent.IRedisCache.ShardCount
        {
            get
            {
                return this.ShardCount();
            }
        }

        /// <summary>
        /// Gets the sku value.
        /// </summary>
        Models.Sku Microsoft.Azure.Management.Redis.Fluent.IRedisCache.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets the sslPort value.
        /// </summary>
        int Microsoft.Azure.Management.Redis.Fluent.IRedisCache.SslPort
        {
            get
            {
                return this.SslPort();
            }
        }

        /// <summary>
        /// Gets the staticIP value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.StaticIP
        {
            get
            {
                return this.StaticIP();
            }
        }

        /// <summary>
        /// Gets the subnetId value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCache.SubnetId
        {
            get
            {
                return this.SubnetId();
            }
        }

        /// <summary>
        /// Adds a linked server to the current Redis cache instance.
        /// </summary>
        /// <param name="linkedRedisCacheId">The resource Id of the Redis instance to link with.</param>
        /// <param name="linkedServerLocation">The location of the linked Redis instance.</param>
        /// <param name="role">The role of the linked server.</param>
        /// <return>Name of the linked server.</return>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.AddLinkedServer(string linkedRedisCacheId, string linkedServerLocation, ReplicationRole role)
        {
            return this.AddLinkedServer(linkedRedisCacheId, linkedServerLocation, role);
        }

        /// <summary>
        /// Adds a linked server to the current Redis cache instance.
        /// </summary>
        /// <param name="linkedRedisCacheId">The resource Id of the Redis instance to link with.</param>
        /// <param name="linkedServerLocation">The location of the linked Redis instance.</param>
        /// <param name="role">The role of the linked server.</param>
        /// <return>Name of the linked server.</return>
        async Task<string> Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.AddLinkedServerAsync(string linkedRedisCacheId, string linkedServerLocation, ReplicationRole role, CancellationToken cancellationToken)
        {
            return await this.AddLinkedServerAsync(linkedRedisCacheId, linkedServerLocation, role, cancellationToken);
        }
        /// <return>Exposes features available only to Premium Sku Redis Cache instances.</return>
        Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium Microsoft.Azure.Management.Redis.Fluent.IRedisCache.AsPremium()
        {
            return this.AsPremium();
        }

        /// <summary>
        /// Deletes the patching schedule for Redis Cache.
        /// </summary>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.DeletePatchSchedule()
        {
 
            this.DeletePatchSchedule();
        }

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">Container name to export to.</param>
        /// <param name="prefix">Prefix to use for exported files.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ExportData(string containerSASUrl, string prefix)
        {
 
            this.ExportData(containerSASUrl, prefix);
        }

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">Container name to export to.</param>
        /// <param name="prefix">Prefix to use for exported files.</param>
        /// <param name="fileFormat">Specifies file format.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ExportData(string containerSASUrl, string prefix, string fileFormat)
        {
 
            this.ExportData(containerSASUrl, prefix, fileFormat);
        }

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">
        /// Specifies which Redis node(s) to reboot. Depending on this value data loss is
        /// possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.
        /// </param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCache.ForceReboot(string rebootType)
        {
 
            this.ForceReboot(rebootType);
        }

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">
        /// Specifies which Redis node(s) to reboot. Depending on this value data loss is
        /// possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.
        /// </param>
        /// <param name="shardId">In case of cluster cache, this specifies shard id which should be rebooted.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ForceReboot(string rebootType, int shardId)
        {
 
            this.ForceReboot(rebootType, shardId);
        }

        /// <return>A Redis Cache's access keys. This operation requires write permission to the Cache resource.</return>
        Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys Microsoft.Azure.Management.Redis.Fluent.IRedisCache.GetKeys()
        {
            return this.GetKeys();
        }

        /// <summary>
        /// Gets the role for the linked server of the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        /// <return>The role of the linked server.</return>
        Models.ReplicationRole Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.GetLinkedServerRole(string linkedServerName)
        {
            return this.GetLinkedServerRole(linkedServerName);
        }

        /// <summary>
        /// Gets the role for the linked server of the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        /// <return>The role of the linked server.</return>
        async Task<Models.ReplicationRole> Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.GetLinkedServerRoleAsync(string linkedServerName, CancellationToken cancellationToken)
        {
            return await this.GetLinkedServerRoleAsync(linkedServerName, cancellationToken);
        }

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">Files to import.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ImportData(IList<string> files)
        {
 
            this.ImportData(files);
        }

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">Files to import.</param>
        /// <param name="fileFormat">Specifies file format.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ImportData(IList<string> files, string fileFormat)
        {
 
            this.ImportData(files, fileFormat);
        }

        /// <summary>
        /// Gets the list of linked servers associated with this redis cache.
        /// </summary>
        /// <return>The Roles of the linked servers, indexed by name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.ReplicationRole> Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.ListLinkedServers()
        {
            return this.ListLinkedServers();
        }

        /// <summary>
        /// Gets the list of linked servers associated with this redis cache.
        /// </summary>
        /// <return>The Roles of the linked servers, indexed by name.</return>
        async Task<System.Collections.Generic.IReadOnlyDictionary<string, Models.ReplicationRole>> Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.ListLinkedServersAsync(CancellationToken cancellationToken)
        {
            return await this.ListLinkedServersAsync(cancellationToken);
        }
        /// <summary>
        /// Gets the patching schedule for Redis Cache.
        /// </summary>
        /// <return>List of patch schedules for current Redis Cache.</return>
        System.Collections.Generic.IReadOnlyList<Models.ScheduleEntry> Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremium.ListPatchSchedules()
        {
            return this.ListPatchSchedules();
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this Redis Cache.
        /// </summary>
        /// <return>The access keys for this Redis Cache.</return>
        Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RefreshKeys()
        {
            return this.RefreshKeys();
        }

        /// <summary>
        /// Regenerates the access keys for this Redis Cache.
        /// </summary>
        /// <param name="keyType">Key type to regenerate.</param>
        /// <return>The generated access keys for this Redis Cache.</return>
        Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys Microsoft.Azure.Management.Redis.Fluent.IRedisCache.RegenerateKey(RedisKeyType keyType)
        {
            return this.RegenerateKey(keyType);
        }

        /// <summary>
        /// Removes the linked server from the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        void Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.RemoveLinkedServer(string linkedServerName)
        {
 
            this.RemoveLinkedServer(linkedServerName);
        }

        /// <summary>
        /// Removes the linked server from the current Redis cache instance.
        /// </summary>
        /// <param name="linkedServerName">The name of the linked server.</param>
        async Task Microsoft.Azure.Management.Redis.Fluent.IRedisCachePremiumBeta.RemoveLinkedServerAsync(string linkedServerName, CancellationToken cancellationToken)
        {

            await this.RemoveLinkedServerAsync(linkedServerName, cancellationToken);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        RedisCache.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<RedisCache.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Updates Redis Cache to Basic sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithBasicSku(int capacity)
        {
            return this.WithBasicSku(capacity);
        }

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithBasicSku()
        {
            return this.WithBasicSku();
        }

        /// <summary>
        /// Specifies the Basic sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Basic sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithBasicSku(int capacity)
        {
            return this.WithBasicSku(capacity);
        }

        /// <summary>
        /// Creates Redis cache firewall rule with range of IP addresses permitted to connect to the cache.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        /// <param name="lowestIp">Lowest IP address included in the range.</param>
        /// <param name="highestIp">Highest IP address included in the range.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreateBeta.WithFirewallRule(string name, string lowestIp, string highestIp)
        {
            return this.WithFirewallRule(name, lowestIp, highestIp);
        }

        /// <summary>
        /// Creates Redis cache firewall rule with range of IP addresses permitted to connect to the cache.
        /// </summary>
        /// <param name="rule">Firewall rule that specifies name, lowest and highest IP address included in the range of permitted IP addresses.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreateBeta.WithFirewallRule(IRedisFirewallRule rule)
        {
            return this.WithFirewallRule(rule);
        }

        /// <summary>
        /// Creates or updates Redis cache firewall rule with range of IP addresses permitted to connect to the cache.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        /// <param name="lowestIp">Lowest IP address included in the range.</param>
        /// <param name="highestIp">Highest IP address included in the range.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdateBeta.WithFirewallRule(string name, string lowestIp, string highestIp)
        {
            return this.WithFirewallRule(name, lowestIp, highestIp);
        }

        /// <summary>
        /// Creates or updates Redis cache firewall rule with range of IP addresses permitted to connect to the cache.
        /// </summary>
        /// <param name="rule">Firewall rule that specifies name, lowest and highest IP address included in the range of permitted IP addresses.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdateBeta.WithFirewallRule(IRedisFirewallRule rule)
        {
            return this.WithFirewallRule(rule);
        }

        /// <summary>
        /// Requires clients to use a specified TLS version (or higher) to connect (e,g, '1.0', '1.1', '1.2').
        /// </summary>
        /// <param name="tlsVersion">Minimum TLS version.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreateBeta.WithMinimumTlsVersion(TlsVersion tlsVersion)
        {
            return this.WithMinimumTlsVersion(tlsVersion);
        }

        /// <summary>
        /// Requires clients to use a specified TLS version (or higher) to connect (e,g, '1.0', '1.1', '1.2').
        /// </summary>
        /// <param name="tlsVersion">Minimum TLS version.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdateBeta.WithMinimumTlsVersion(TlsVersion tlsVersion)
        {
            return this.WithMinimumTlsVersion(tlsVersion);
        }

        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithNonSslPort()
        {
            return this.WithNonSslPort();
        }

        /// <summary>
        /// Enables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithNonSslPort.WithNonSslPort()
        {
            return this.WithNonSslPort();
        }

        /// <summary>
        /// Deletes a single firewall rule in the current Redis cache instance.
        /// </summary>
        /// <param name="name">Name of the rule.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdateBeta.WithoutFirewallRule(string name)
        {
            return this.WithoutFirewallRule(name);
        }

        /// <summary>
        /// Removes the requirement for clients minimum TLS version.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdateBeta.WithoutMinimumTlsVersion()
        {
            return this.WithoutMinimumTlsVersion();
        }

        /// <summary>
        /// Disables non-ssl Redis server port (6379).
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithNonSslPort.WithoutNonSslPort()
        {
            return this.WithoutNonSslPort();
        }

        /// <summary>
        /// Removes all Patch schedules from the current Premium Cluster Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdateBeta.WithoutPatchSchedule()
        {
            return this.WithoutPatchSchedule();
        }

        /// <summary>
        /// Cleans all the configuration settings being set on Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithoutRedisConfiguration()
        {
            return this.WithoutRedisConfiguration();
        }

        /// <summary>
        /// Removes specified Redis Cache configuration setting.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithoutRedisConfiguration(string key)
        {
            return this.WithoutRedisConfiguration(key);
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc);
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc, TimeSpan maintenanceWindow)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc, maintenanceWindow);
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">List of patch schedule entries for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithPatchSchedule(IList<Models.ScheduleEntry> scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry);
        }

        /// <summary>
        /// Patch schedule on a Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">Patch schedule entry for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithPatchSchedule(ScheduleEntry scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry);
        }

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc);
        }

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="dayOfWeek">Day of week when cache can be patched.</param>
        /// <param name="startHourUtc">Start hour after which cache patching can start.</param>
        /// <param name="maintenanceWindow">ISO8601 timespan specifying how much time cache patching can take.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc, TimeSpan maintenanceWindow)
        {
            return this.WithPatchSchedule(dayOfWeek, startHourUtc, maintenanceWindow);
        }

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">List of patch schedule entries for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(IList<Models.ScheduleEntry> scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry);
        }

        /// <summary>
        /// Adds Patch schedule to the current Premium Cluster Cache.
        /// </summary>
        /// <param name="scheduleEntry">Patch schedule entry for Premium Redis Cache.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithPatchSchedule(ScheduleEntry scheduleEntry)
        {
            return this.WithPatchSchedule(scheduleEntry);
        }

        /// <summary>
        /// Updates Redis Cache to Premium sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithPremiumSku()
        {
            return this.WithPremiumSku();
        }

        /// <summary>
        /// Updates Redis Cache to Premium sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Premium sku with P family (1, 2, 3, 4).</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithPremiumSku(int capacity)
        {
            return this.WithPremiumSku(capacity);
        }

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithSku.WithPremiumSku()
        {
            return this.WithPremiumSku();
        }

        /// <summary>
        /// Specifies the Premium sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Standard sku with P family (1, 2, 3, 4).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithSku.WithPremiumSku(int capacity)
        {
            return this.WithPremiumSku(capacity);
        }

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">Configuration of Redis Cache as a map indexed by configuration name.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithRedisConfiguration(IDictionary<string,string> redisConfiguration)
        {
            return this.WithRedisConfiguration(redisConfiguration);
        }

        /// <summary>
        /// Specifies Redis Setting.
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="key">Redis configuration name.</param>
        /// <param name="value">Redis configuration value.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithCreate.WithRedisConfiguration(string key, string value)
        {
            return this.WithRedisConfiguration(key, value);
        }

        /// <summary>
        /// All Redis Settings. Few possible keys:
        /// rdb-backup-enabled, rdb-storage-connection-string, rdb-backup-frequency, maxmemory-delta, maxmemory-policy,
        /// notify-keyspace-events, maxmemory-samples, slowlog-log-slower-than, slowlog-max-len, list-max-ziplist-entries,
        /// list-max-ziplist-value, hash-max-ziplist-entries, hash-max-ziplist-value, set -max-intset-entries,
        /// zset-max-ziplist-entries, zset-max-ziplist-value etc.
        /// </summary>
        /// <param name="redisConfiguration">Configuration of Redis Cache as a map indexed by configuration name.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithRedisConfiguration(IDictionary<string,string> redisConfiguration)
        {
            return this.WithRedisConfiguration(redisConfiguration);
        }

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
        RedisCache.Update.IUpdate RedisCache.Update.IWithRedisConfiguration.WithRedisConfiguration(string key, string value)
        {
            return this.WithRedisConfiguration(key, value);
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">The shard count value to set.</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IUpdate.WithShardCount(int shardCount)
        {
            return this.WithShardCount(shardCount);
        }

        /// <summary>
        /// The number of shards to be created on a Premium Cluster Cache.
        /// </summary>
        /// <param name="shardCount">The shard count value to set.</param>
        /// <return>The next stage of Redis Cache with Premium SKU definition.</return>
        RedisCache.Definition.IWithPremiumSkuCreate RedisCache.Definition.IWithPremiumSkuCreate.WithShardCount(int shardCount)
        {
            return this.WithShardCount(shardCount);
        }

        /// <summary>
        /// Updates Redis Cache to Standard sku.
        /// </summary>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithStandardSku()
        {
            return this.WithStandardSku();
        }

        /// <summary>
        /// Updates Redis Cache to Standard sku with new capacity.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to update to for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache update.</return>
        RedisCache.Update.IUpdate RedisCache.Update.IWithSku.WithStandardSku(int capacity)
        {
            return this.WithStandardSku(capacity);
        }

        /// <summary>
        /// Specifies the Standard Sku of the Redis Cache.
        /// </summary>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithStandardSku()
        {
            return this.WithStandardSku();
        }

        /// <summary>
        /// Specifies the Standard sku of the Redis Cache.
        /// </summary>
        /// <param name="capacity">Specifies what size of Redis Cache to deploy for Standard sku with C family (0, 1, 2, 3, 4, 5, 6).</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithSku.WithStandardSku(int capacity)
        {
            return this.WithStandardSku(capacity);
        }

        /// <summary>
        /// Sets Redis Cache static IP. Required when deploying a Redis Cache inside an existing Azure Virtual Network.
        /// </summary>
        /// <param name="staticIP">The static IP value to set.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithPremiumSkuCreateBeta.WithStaticIP(string staticIP)
        {
            return this.WithStaticIP(staticIP);
        }

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="network">Instance of Network object.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithPremiumSkuCreateBeta.WithSubnet(IHasId network, string subnetName)
        {
            return this.WithSubnet(network, subnetName);
        }

        /// <summary>
        /// Assigns the specified subnet to this instance of Redis Cache.
        /// </summary>
        /// <param name="subnetId">Resource id of subnet.</param>
        /// <return>The next stage of Redis Cache definition.</return>
        RedisCache.Definition.IWithCreate RedisCache.Definition.IWithPremiumSkuCreateBeta.WithSubnet(string subnetId)
        {
            return this.WithSubnet(subnetId);
        }
    }
}