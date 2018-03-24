// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyActionsDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for SQL Server Key operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJLZXlPcGVyYXRpb25zSW1wbA==
    internal partial class SqlServerKeyOperationsImpl  :
        SqlChildrenOperationsImpl<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>,
        ISqlServerKeyOperations,
        ISqlServerKeyActionsDefinition
    {

        ///GENMHASH:3B9C4A60F970D3C8FC510783A5213A79:07F7C2DF9F0EC6B655D1EDFA013AF942
        internal SqlServerKeyOperationsImpl(ISqlServer parent, ISqlManager sqlServerManager) : base(parent, sqlServerManager)
        {
        }

        ///GENMHASH:DF01C8D3D615FCE02CF6035344918A57:2840EFBD91320D6FB3161709B5736129
        internal SqlServerKeyOperationsImpl(ISqlManager sqlServerManager) : base(null, sqlServerManager)
        {
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:390ACF4585412E461695F4810A90857C
        public override IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:48B8354F9A8656B355FBB651D3743037:03604623FE12CF63C7CD4756453C5CF5
        public override IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> ListBySqlServer(ISqlServer sqlServer)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(sqlServer));
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:7A8A06CD91337797B03D4892327A4B4A
        public override ISqlServerKey GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:3B0B15606AA6CA4AD0624C5561BF19C5:CC329F73E8BC0F035C0C2766A5BD7D7F
        public override ISqlServerKey GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(sqlServer, name));
        }

        ///GENMHASH:7BD5581333BDF8A0EEFAF838D1C32E11:A48CB95E3624EB9ABF5348FA6921347E
        public async override Task DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ServerKeys.DeleteAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        ///GENMHASH:90DDF31DBCC18A1CCF68558A7E8449CD:3D093FDBF5050E1F5C54B8849D5460C4
        public async override Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlServerKey> sqlServerKeyList = new List<ISqlServerKey>();
            var serverKeyInnerPage = await this.sqlServerManager.Inner.ServerKeys
                .ListByServerAsync(resourceGroupName, sqlServerName, cancellationToken);
            if (serverKeyInnerPage != null)
            {
                foreach (var serverKeyInner in serverKeyInnerPage)
                {
                    sqlServerKeyList.Add(new SqlServerKeyImpl(resourceGroupName, sqlServerName, serverKeyInner.Name, serverKeyInner, this.sqlServerManager));
                }
            }
            return sqlServerKeyList.AsReadOnly();
        }

        ///GENMHASH:2EA8D9073369A6E1267C1FB74F86952A:73CA3152673871CDB386E1B943379091
        public async override Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlServerKey> sqlServerKeyList = new List<ISqlServerKey>();
            var serverKeyInnerPage = await sqlServer.Manager.Inner.ServerKeys
                .ListByServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            if (serverKeyInnerPage != null)
            {
                foreach (var serverKeyInner in serverKeyInnerPage)
                {
                    sqlServerKeyList.Add(new SqlServerKeyImpl(serverKeyInner.Name, (SqlServerImpl)sqlServer, serverKeyInner, sqlServer.Manager));
                }
            }
            return sqlServerKeyList.AsReadOnly();
        }

        ///GENMHASH:2A6462AE45E430A3F53D2BC369D967B4:2786E87F5886BD9B12FDBB691AFF1F6C
        public async override Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverKeyInner = await this.sqlServerManager.Inner.ServerKeys
                .GetAsync(resourceGroupName, sqlServerName, name, cancellationToken);
            return (serverKeyInner != null) ? new SqlServerKeyImpl(resourceGroupName, sqlServerName, name, serverKeyInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:48BA5938680939720DEA90858B8FC7E4:C772E92274E4ABB2291769EF57929AED
        public async override Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverKeyInner = await sqlServer.Manager.Inner.ServerKeys
                .GetAsync(sqlServer.ResourceGroupName, sqlServer.Name, name, cancellationToken);
            return (serverKeyInner != null) ? new SqlServerKeyImpl(name, (SqlServerImpl)sqlServer, serverKeyInner, sqlServer.Manager) : null;
        }

        ///GENMHASH:4ABAEC77990815B01AA39D981ECF5CA5:E43CCEB20F8F2112E3994F264ED48B36
        public override void DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            Extensions.Synchronize(() => this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:AFEFF82278E961D2DC4EAEB4F242C488:883216D93D61DA13A3116566BE1BEAF7
        public SqlServerKeyImpl Define()
        {
            SqlServerKeyImpl result = new SqlServerKeyImpl("", new Models.ServerKeyInner(), this.sqlServerManager);
            return (this.sqlServer != null) ? result.WithExistingSqlServer(this.sqlServer) : result;
        }
    }
}