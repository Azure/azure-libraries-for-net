// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for SQL Server DNS alias operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJEbnNBbGlhc09wZXJhdGlvbnNJbXBs
    internal partial class SqlServerDnsAliasOperationsImpl  :
        SqlChildrenOperationsImpl<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>,
        ISqlServerDnsAliasOperations,
        ISqlServerDnsAliasActionsDefinition
    {
        private readonly string DNS_ALIASES = "/dnsAliases/";


        ///GENMHASH:9B6902091CDDD80A47F4290463289D50:07F7C2DF9F0EC6B655D1EDFA013AF942
        internal SqlServerDnsAliasOperationsImpl(ISqlServer parent, ISqlManager sqlServerManager)
            : base(parent, sqlServerManager)
        {
        }

        ///GENMHASH:D2A540AE68B71EE9874B32962AD75BE6:2840EFBD91320D6FB3161709B5736129
        internal SqlServerDnsAliasOperationsImpl(ISqlManager sqlServerManager)
            : base(null, sqlServerManager)
        {
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:13C705E8EEE3DC872B384F882B38438C
        public override IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:48B8354F9A8656B355FBB651D3743037:F74D38042AEDCA68B2A29B8BD37EC2BA
        public override IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> ListBySqlServer(ISqlServer sqlServer)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(sqlServer));
        }

        ///GENMHASH:E5F03C2027CD19EC15C7606CFD57D3C4:C9D2576E3C4227E912C7910BDC8D4F44
        public async Task AcquireAsync(string resourceGroupName, string serverName, string dnsAliasName, string sqlServerId, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ServerDnsAliases
                .AcquireAsync(resourceGroupName, serverName, dnsAliasName, sqlServerId + DNS_ALIASES + dnsAliasName, cancellationToken);
        }

        ///GENMHASH:7E5F7B494C48C5A8645482E4ED1A99D2:C922CDC307B85118563E7417B7BC5B2B
        public async Task AcquireAsync(string dnsAliasName, string oldSqlServerId, string newSqlServerId, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(oldSqlServerId);
            await this.sqlServerManager.Inner.ServerDnsAliases
                .AcquireAsync(resourceId.ResourceGroupName, resourceId.Name, dnsAliasName, newSqlServerId + DNS_ALIASES + dnsAliasName, cancellationToken);
        }

        ///GENMHASH:6296EBA2A3987F54D7F72FBAD6479C42:43BF008A6256BDEA0A296AB514FC7683
        public async Task AcquireAsync(string dnsAliasName, string sqlServerId, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.AcquireAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, dnsAliasName, sqlServerId, cancellationToken);
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:634F4EA35A79279119891B659AC7FCD5
        public override ISqlServerDnsAlias GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:3B0B15606AA6CA4AD0624C5561BF19C5:A28F63A433A6A83D807ECBC5EFF7606B
        public override ISqlServerDnsAlias GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(sqlServer, name));
        }

        ///GENMHASH:7BD5581333BDF8A0EEFAF838D1C32E11:46B53A706274A00E44E2F6D8C72624F5
        public override async Task DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ServerDnsAliases.DeleteAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        ///GENMHASH:90DDF31DBCC18A1CCF68558A7E8449CD:D43E46DBBCA332DE50B05CC58B108138
        public override async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> serverDnsAliasList = new List<ISqlServerDnsAlias>();
            var serverDnsAliasInnerPage = await this.sqlServerManager.Inner.ServerDnsAliases
                .ListByServerAsync(resourceGroupName, sqlServerName, cancellationToken);
            if (serverDnsAliasInnerPage != null)
            {
                foreach (var serverDnsAliasInner in serverDnsAliasInnerPage)
                {
                    serverDnsAliasList.Add(new SqlServerDnsAliasImpl(resourceGroupName, sqlServerName, serverDnsAliasInner.Name, serverDnsAliasInner, this.sqlServerManager));
                }
            }
            return serverDnsAliasList.AsReadOnly();
        }

        ///GENMHASH:2EA8D9073369A6E1267C1FB74F86952A:01782704D7D035FA4E390B7E3A925C27
        public override async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> serverDnsAliasList = new List<ISqlServerDnsAlias>();
            var serverDnsAliasInnerPage = await sqlServer.Manager.Inner.ServerDnsAliases
                .ListByServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            if (serverDnsAliasInnerPage != null)
            {
                foreach (var serverDnsAliasInner in serverDnsAliasInnerPage)
                {
                    serverDnsAliasList.Add(new SqlServerDnsAliasImpl(serverDnsAliasInner.Name, (SqlServerImpl)sqlServer, serverDnsAliasInner, sqlServer.Manager));
                }
            }
            return serverDnsAliasList.AsReadOnly();
        }

        ///GENMHASH:2A6462AE45E430A3F53D2BC369D967B4:8AD4B3257BC794C1CCBC03CDC07693F6
        public override async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverDnsAliasInner = await this.sqlServerManager.Inner.ServerDnsAliases
                .GetAsync(resourceGroupName, sqlServerName, name, cancellationToken);
            return (serverDnsAliasInner != null) ? new SqlServerDnsAliasImpl(resourceGroupName, sqlServerName, name, serverDnsAliasInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:48BA5938680939720DEA90858B8FC7E4:5FDAFAF14AABA3B8F8A9ED136CFA0015
        public override async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverDnsAliasInner = await sqlServer.Manager.Inner.ServerDnsAliases
                .GetAsync(sqlServer.ResourceGroupName, sqlServer.Name, name, cancellationToken);
            return (serverDnsAliasInner != null) ? new SqlServerDnsAliasImpl(name, (SqlServerImpl)sqlServer, serverDnsAliasInner, sqlServer.Manager) : null;
        }

        ///GENMHASH:4ABAEC77990815B01AA39D981ECF5CA5:772B5622EF85A0D5167ED0E00E1E6418
        public override void DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            Extensions.Synchronize(() => this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name));

        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:70C5F07BF0A46AC165061C550864E275
        public SqlServerDnsAliasImpl Define(string name)
        {
            SqlServerDnsAliasImpl result = new SqlServerDnsAliasImpl(name, new Models.ServerDnsAliasInner(), this.sqlServerManager);
            return (this.sqlServer != null) ? result.WithExistingSqlServer(this.sqlServer) : result;
        }

        ///GENMHASH:E529638939130E2CBBFA6D4A4BA8B73D:8C34C66EF8013A611B1FBEEA85FF4C92
        public void Acquire(string resourceGroupName, string serverName, string dnsAliasName, string sqlServerId)
        {
            Extensions.Synchronize(() => this.AcquireAsync(serverName, dnsAliasName, sqlServerId + DNS_ALIASES + dnsAliasName));
        }

        ///GENMHASH:BE46A0F41ADFB1B37FE0CAC942E07E0B:9162DD9F1CFFA555C799DA458F2A405D
        public void Acquire(string dnsAliasName, string oldSqlServerId, string newSqlServerId)
        {
            ResourceId resourceId = ResourceId.FromString(oldSqlServerId);
            Extensions.Synchronize(() => this.AcquireAsync(resourceId.ResourceGroupName, resourceId.Name, dnsAliasName, newSqlServerId + DNS_ALIASES + dnsAliasName));
        }

        ///GENMHASH:2D4F5D4A3554B71CDC5A6F6378C89997:9665B941C0E8CB19DE03916B88D4F719
        public void Acquire(string dnsAliasName, string sqlServerId)
        {
            Extensions.Synchronize(() => this.AcquireAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, dnsAliasName, sqlServerId));
        }
    }
}