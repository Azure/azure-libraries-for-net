// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a Redis firewall rules collection associated with a Redis cache instance.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzRmlyZXdhbGxSdWxlc0ltcGw=
    internal partial class RedisFirewallRulesImpl :
        ExternalChildResourcesCached<RedisFirewallRuleImpl,
            IRedisFirewallRule,
            RedisFirewallRuleInner,
            IRedisCache,
            RedisCacheImpl>
    {

        ///GENMHASH:CF7DEFD9A0DD88B635298C8054BB9A9D:900B06C0BDB2F9E97263BC2F6BA64005
        internal  RedisFirewallRulesImpl(RedisCacheImpl parent)
            : base(parent, "FirewallRule")
        {
            if (parent.Id != null)
            {
                this.CacheCollection();
            }
        }

        ///GENMHASH:18F41687B348B9E09418C6DEC090073F:5974B25E6707EE399CE4603A77A8DD19
        internal IReadOnlyDictionary<string,Models.IRedisFirewallRule> RulesAsMap()
        {
            var result = new Dictionary<string, IRedisFirewallRule>();
            foreach (var entry in this.Collection)
            {
                RedisFirewallRuleImpl rule = entry.Value;
                result.Add(entry.Key, rule);
            }

            return result;
        }

        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:B2EF9DC85A673D83563D798E70C105D6
        protected override IList<Microsoft.Azure.Management.Redis.Fluent.RedisFirewallRuleImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => this.Parent.Manager.Inner.FirewallRules.ListByRedisResourceAsync(this.Parent.ResourceGroupName, this.Parent.Name))
                    .AsContinuousCollection(link => Extensions.Synchronize(() => this.Parent.Manager.Inner.FirewallRules.ListByRedisResourceNextAsync(link)))
                    .Select(inner => new RedisFirewallRuleImpl(inner.Name, this.Parent, inner))
                    .ToList();
        }

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:00C2146FC143579EAAD7721FF8E88C31
        protected override RedisFirewallRuleImpl NewChildResource(string name)
        {
            return new RedisFirewallRuleImpl(name, this.Parent, new RedisFirewallRuleInner());
        }

        ///GENMHASH:1B44F74595D2DBB80C90026635B00A49:70E5536409B659240A6A4A092BE18779
        public void AddRule(RedisFirewallRuleImpl rule)
        {
            this.AddChildResource(rule);
        }

        ///GENMHASH:518F7642AE4D538C71F91882E33728D8:A59D5C2CB7E0AA07FC4CDB2EDF076F7F
        public RedisFirewallRuleImpl DefineInlineFirewallRule(string name)
        {
            return this.PrepareDefine(name);
        }

        ///GENMHASH:99C9A9B66AEE720319DFED03F8C8B705:DEE0D182874CA32644574B6F9CB541D8
        public void RemoveRule(string name)
        {
            this.PrepareRemove(name);
        }
    }
}