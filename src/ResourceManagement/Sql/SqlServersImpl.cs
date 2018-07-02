// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for SqlServers and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJzSW1wbA==
    internal partial class SqlServersImpl :
        TopLevelModifiableResources<ISqlServer, SqlServerImpl, ServerInner, IServersOperations, ISqlManager>,
        //        TopLevelModifiableResourcesImpl<Microsoft.Azure.Management.Sql.Fluent.ISqlServer,Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,Models.ServerInner,Microsoft.Azure.Management.Sql.Fluent.IServersOperations,Microsoft.Azure.Management.Sql.Fluent.ISqlManager>,
        ISqlServers
    {
        private ISqlFirewallRuleOperations firewallRules;
        private ISqlVirtualNetworkRuleOperations virtualNetworkRules;
        private ISqlElasticPoolOperations elasticPools;
        private ISqlDatabaseOperations databases;
        private ISqlFailoverGroupOperations failoverGroups;
        private ISqlServerKeyOperations serverKeys;
        private ISqlServerDnsAliasOperations dnsAliases;
        private ISqlEncryptionProtectorOperations sqlEncryptionProtectors;
        private ISqlSyncGroupOperations sqlSyncGroups;
        private ISqlSyncMemberOperations sqlSyncMembers;


        ///GENMHASH:CD99F9712BCAD6B97E57591564CBC327:E4EB5400B898EAB4E389857A2249916F
        public SqlServersImpl(ISqlManager manager)
            : base(manager.Inner.Servers, manager)
        {
        }

        ///GENMHASH:42E0B61F5AA4A1130D7B90CCBAAE3A5D:39C0A2E756B1F8A638A75BD8777F2C5B
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var checkNameAvailabilityResponseInner = await this.Inner.CheckNameAvailabilityAsync(name, cancellationToken);
            return checkNameAvailabilityResponseInner != null ? new CheckNameAvailabilityResultImpl(checkNameAvailabilityResponseInner) : null;
        }

        ///GENMHASH:42E970DCB01F51542CCDD026AE4BD947:E8DF9A98A7F6A518BDF891255FF6DC7D
        public ISqlServerDnsAliasOperations DnsAliases()
        {
            if (this.dnsAliases == null)
            {
                this.dnsAliases = new SqlServerDnsAliasOperationsImpl(this.Manager);
            }
            return this.dnsAliases;
        }

        ///GENMHASH:DF46C62E0E8998CD0340B3F8A136F135:11837351BC2EEC12842F1B5C5B26ED07
        public ISqlDatabaseOperations Databases()
        {
            if (databases == null)
            {
                this.databases = new SqlDatabaseOperationsImpl(this.Manager);
            }
            return this.databases;
        }

        ///GENMHASH:FAB8FC88C4E33B74177DED5C8A8B25D3:F9AB7A164C0C6A57198BFDB3EB2FC20D
        public IRegionCapabilities GetCapabilitiesByRegion(Region region)
        {
            return Extensions.Synchronize(() => this.GetCapabilitiesByRegionAsync(region));
        }

        ///GENMHASH:6EA19E59A2E4108A873A0F3D172C1084:45E77F9F0AC4DA681B8DE3A0973B5D81
        public async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric>> ListUsageByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            var subscriptionUsageList = new List<ISqlSubscriptionUsageMetric>();
            var subscriptionUsageInners = await this.Manager.Inner.SubscriptionUsages
                .ListByLocationAsync(region.Name, cancellationToken);
            foreach (var subscriptionInner in subscriptionUsageInners)
            {
                subscriptionUsageList.Add(new SqlSubscriptionUsageMetricImpl(region.Name, subscriptionInner, this.Manager));
            }

            return subscriptionUsageList.AsReadOnly();
        }

        ///GENMHASH:22ED13819FBF2CA919B55726AC1FB656:CA298AE187015BA1255E73AC78A0A0E0
        public ISqlElasticPoolOperations ElasticPools()
        {
            if (elasticPools == null)
            {
                this.elasticPools = new SqlElasticPoolOperationsImpl(this.Manager);
            }
            return this.elasticPools;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public SqlServerImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:7DDEADFB2FB27BEC42C0B993AB65C3CB:18521E15B275AC00B93CBE6E0FD799F2
        public ISqlFirewallRuleOperations FirewallRules()
        {
            if (firewallRules == null)
            {
                this.firewallRules = new SqlFirewallRuleOperationsImpl(this.Manager);
            }
            return this.firewallRules;
        }

        ///GENMHASH:ED2CFE8848802E73EC1E094FD7531ECC:5FF987C0087FAAF3ED6751692F6CCBD8
        public ISqlVirtualNetworkRuleOperations VirtualNetworkRules()
        {
            if (this.virtualNetworkRules == null)
            {
                this.virtualNetworkRules = new SqlVirtualNetworkRuleOperationsImpl(this.Manager);
            }
            return this.virtualNetworkRules;
        }

        ///GENMHASH:1EF63C8C02FD01147851B5DFEA2E69BD:82A745A0A229923F4C8D17588C2B9423
        public ISqlServerKeyOperations ServerKeys()
        {
            if (this.serverKeys == null)
            {
                this.serverKeys = new SqlServerKeyOperationsImpl(this.Manager);
            }
            return this.serverKeys;
        }

        ///GENMHASH:4F7CA6A5E46AEAEE98786B149781D99D:6E53937D408BBE066C5B4777792F4CCD
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSubscriptionUsageMetric> ListUsageByRegion(Region region)
        {
            return Extensions.Synchronize(() => this.ListUsageByRegionAsync(region));
        }

        ///GENMHASH:C4C74C5CA23BE3B4CAFEFD0EF23149A0:AF6C14B13CF0B80FB518B6FF3E8D963A
        public ICheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return Extensions.Synchronize(() => this.CheckNameAvailabilityAsync(name));
        }

        ///GENMHASH:1FE0A47E23B755CDB471E95CFF0DB53B:F727D3815E2699BD6270EC8796F2D08C
        public ISqlFailoverGroupOperations FailoverGroups()
        {
            if (this.failoverGroups == null)
            {
                this.failoverGroups = new SqlFailoverGroupOperationsImpl(this.Manager);
            }
            return this.failoverGroups;
        }

        ///GENMHASH:A35FDCFAF0B4252668DF8A64517A10A7:B1CCC878A1CDD9D3F57BBFE9048EB8AC
        public ISqlEncryptionProtectorOperations EncryptionProtectors()
        {
            if (this.sqlEncryptionProtectors == null) {
                this.sqlEncryptionProtectors = new SqlEncryptionProtectorOperationsImpl(this.Manager);
            }
            return this.sqlEncryptionProtectors;
        }

        ///GENMHASH:2AEEDA573EC9A50B62216BE3C228E186:F7C2697357E2248BD05827E37DA0EBEE
        public ISqlSyncGroupOperations SyncGroups()
        {
            if (this.sqlSyncGroups == null)
            {
                this.sqlSyncGroups = new SqlSyncGroupOperationsImpl(this.Manager);
            }
            return this.sqlSyncGroups;
        }

        ///GENMHASH:691A3310F6A70FA4B372698CC1C9AFAD:398E750211561F092D8C273738EF899F
        public ISqlSyncMemberOperations SyncMembers()
        {
            if (this.sqlSyncMembers == null)
            {
                this.sqlSyncMembers = new SqlSyncMemberOperationsImpl(this.Manager);
            }
            return this.sqlSyncMembers;
        }

        ///GENMHASH:0B0968A0B36C8F64E70BD2B0368E05D6:0BCCBE8A491142FDC3A6BE9B95AA1AC9
        public async Task<Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities> GetCapabilitiesByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            var capabilitiesInner = await this.Manager.Inner.Capabilities
                .ListByLocationAsync(region.Name, cancellationToken);
            return capabilitiesInner != null ? new RegionCapabilitiesImpl(capabilitiesInner) : null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:9E3AAE2EBAEFB292B77161CC09036F00
        protected override SqlServerImpl WrapModel(string name)
        {
            ServerInner inner = new ServerInner();
            return new SqlServerImpl(name, inner, this.Manager);
        }

        ///GENMHASH:14929760F9002214878530515584D731:5A0307D2185B2239D36C696C06B0D168
        protected override ISqlServer WrapModel(ServerInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            return new SqlServerImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:92EAC0C15F6E0EE83B7B356CD097B0A0
        protected async override Task<ServerInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected async override Task<IPage<ServerInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return ConvertToPage(await Inner.ListAsync(cancellationToken));
        }

        protected async override Task<IPage<ServerInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ServerInner>>(null);
        }

        protected async override Task<IPage<ServerInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return ConvertToPage(await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken));
        }

        protected async override Task<IPage<ServerInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ServerInner>>(null);
        }
    }
}