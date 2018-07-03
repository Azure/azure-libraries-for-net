// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent.Models
{
    using Microsoft.Azure.Management.Redis.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The Azure Redis Firewall rule entries are of type RedisFirewallRule.
    /// </summary>
    public interface IRedisFirewallRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Redis.Fluent.Models.IRedisFirewallRule,Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Redis.Fluent.Models.RedisFirewallRuleInner>
    {
        /// <summary>
        /// Gets the endIP value.
        /// </summary>
        /// <summary>
        /// Gets the endIP value.
        /// </summary>
        string EndIP { get; }

        /// <summary>
        /// Gets the startIP value.
        /// </summary>
        /// <summary>
        /// Gets the startIP value.
        /// </summary>
        string StartIP { get; }
    }
}