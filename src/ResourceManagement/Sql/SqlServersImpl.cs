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
        private ISqlElasticPoolOperations elasticPools;
        private ISqlDatabaseOperations databases;

        ///GENMHASH:CD99F9712BCAD6B97E57591564CBC327:E4EB5400B898EAB4E389857A2249916F
        public SqlServersImpl(ISqlManager manager)
            : base(manager.Inner.Servers, manager)
        {
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
        public ISqlServer Define(string name)
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