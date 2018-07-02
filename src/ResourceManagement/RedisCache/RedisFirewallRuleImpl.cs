// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Azure  RedisFirewallRule wrapper class implementation.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzRmlyZXdhbGxSdWxlSW1wbA==
    internal partial class RedisFirewallRuleImpl :
        ExternalChildResource<IRedisFirewallRule, RedisFirewallRuleInner, IRedisCache, RedisCacheImpl>,
        IRedisFirewallRule
    {
        string IExternalChildResource<IRedisFirewallRule, IRedisCache>.Id => this.Id();

        ///GENMHASH:34040AC696DA924042721A60BDE443D1:95CDFB0CE611CB49B83B558A1D6C0C28
        internal  RedisFirewallRuleImpl(string name, RedisCacheImpl parent, RedisFirewallRuleInner innerObject)
            : base(GetChildName(name, parent.Name), parent, innerObject)
        {
        }

        ///GENMHASH:7B91F973B41CF71CC40E247891C84C41:E4D43A6E96E7C87C1AF10B462EF6EBD1
        private static string GetChildName(string name, string parentName)
        {
            if (name != null && name.IndexOf("/") != -1)
            {
                // rule name consist of "parent/child" name syntax but delete/update/get should be called only on child name
                return name.Substring(parentName.Length + 1);

            }
            return name;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:9173CAD5C20D0FE8E533CCFC4AD76F00
        protected async override Task<Models.RedisFirewallRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Parent.Manager.Inner.FirewallRules.GetAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:DDFC98F9FF0E3FBFE660C327A14278F6
        public async Task<Models.IRedisFirewallRule> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new RedisFirewallRuleCreateParametersInner
                {
                    StartIP = this.StartIP(),
                    EndIP = this.EndIP()
                };
            var inner = await this.Parent.Manager.Inner.FirewallRules.CreateOrUpdateAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                parameters,
                cancellationToken);
            this.SetInner(inner);

            return this;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:F0E8761B587413D44BC7829228C59639
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Parent.Manager.Inner.FirewallRules.DeleteAsync(
                resourceGroupName: this.Parent.ResourceGroupName,
                cacheName: this.Parent.Name,
                ruleName: this.Name(),
                cancellationToken: cancellationToken);
        }

        ///GENMHASH:CD7049B3E4C84FDFC44A3FBCEBE46085:8984B82FDB80ED1EF4A20D58D6D1A6AF
        public string EndIP()
        {
            return this.Inner.EndIP;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:E352C9BBEA1A53BC845A684ED59AF1E5:410296D8DB82CE8FB9AFAF7AFCBA8481
        public string StartIP()
        {
            return this.Inner.StartIP;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:16AD01F8BDD93611BB283CC787483C90
        public async Task<Models.IRedisFirewallRule> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        // Catch-up methods
        public async override Task<IRedisFirewallRule> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        public async override Task<IRedisFirewallRule> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }
    }
}