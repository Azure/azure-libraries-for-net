// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RedisFirewallRuleImpl 
    {
        /// <summary>
        /// Gets the endIP value.
        /// </summary>
        /// <summary>
        /// Gets the endIP value.
        /// </summary>
        string Models.IRedisFirewallRule.EndIP
        {
            get
            {
                return this.EndIP();
            }
        }

        /// <summary>
        /// Gets the startIP value.
        /// </summary>
        /// <summary>
        /// Gets the startIP value.
        /// </summary>
        string Models.IRedisFirewallRule.StartIP
        {
            get
            {
                return this.StartIP();
            }
        }
    }
}