// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for SQL Failover Group operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxGYWlsb3Zlckdyb3VwT3BlcmF0aW9uc0ltcGw=
    internal partial class SqlFailoverGroupOperationsImpl  :
        SqlChildrenOperationsImpl<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>,
        ISqlFailoverGroupOperations,
        ISqlFailoverGroupActionsDefinition
    {

        ///GENMHASH:F5D1FB9D1986373C9555B0A8E544A59B:07F7C2DF9F0EC6B655D1EDFA013AF942
        internal SqlFailoverGroupOperationsImpl(ISqlServer parent, ISqlManager sqlServerManager)
            : base(parent, sqlServerManager)
        {
        }

        ///GENMHASH:5BFE5FEF9D979EF6BECEF100F728DE48:2840EFBD91320D6FB3161709B5736129
        internal SqlFailoverGroupOperationsImpl(ISqlManager sqlServerManager)
            : base(null, sqlServerManager)
        {
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:F63029C2E87619B3ACBDD64A4EA4684F
        public override IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:48B8354F9A8656B355FBB651D3743037:A6F49EBB38B6F52BA6FC6481B8D76E5B
        public override IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> ListBySqlServer(ISqlServer sqlServer)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(sqlServer));
        }

        ///GENMHASH:085A39F3A5363188CE15983CDB8719CA:C8F7B1896D351C9480C2C27D827F0526
        public ISqlFailoverGroup ForceFailoverAllowDataLoss(string failoverGroupName)
        {
            return Extensions.Synchronize(() => this.ForceFailoverAllowDataLossAsync(failoverGroupName));
        }

        ///GENMHASH:7AD84CEA72D50932CAC0C4ABDF4DDE99:373FB05F06A89E8A1017CAAD3F154086
        public ISqlFailoverGroup ForceFailoverAllowDataLoss(string resourceGroupName, string serverName, string failoverGroupName)
        {
            return Extensions.Synchronize(() => this.ForceFailoverAllowDataLossAsync(resourceGroupName, serverName, failoverGroupName));
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:432116A6B7AD604AA46B3E9305E65D9B
        public override ISqlFailoverGroup GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:3B0B15606AA6CA4AD0624C5561BF19C5:B87C42B708F5EF6B528BE38FAB4FE874
        public override ISqlFailoverGroup GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(sqlServer, name));
        }

        ///GENMHASH:7BD5581333BDF8A0EEFAF838D1C32E11:F8EF763EEE2C9A7F1F49C85FC21018FD
        public override async Task DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.FailoverGroups.DeleteAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        ///GENMHASH:90DDF31DBCC18A1CCF68558A7E8449CD:B0BCFA4BEDA326480E4231F9DCB40011
        public override async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlFailoverGroup> failoverGroups = new List<ISqlFailoverGroup>();
            var failoverGroupInners = await this.sqlServerManager.Inner.FailoverGroups
                .ListByServerAsync(resourceGroupName, sqlServerName, cancellationToken);
            if (failoverGroupInners != null)
            {
                foreach (var failoverGroupInner in failoverGroupInners)
                {
                    failoverGroups.Add(new SqlFailoverGroupImpl(failoverGroupInner.Name, failoverGroupInner, this.sqlServerManager));
                }
            }
            return failoverGroups.AsReadOnly();
        }

        ///GENMHASH:2EA8D9073369A6E1267C1FB74F86952A:545E74078F888E568F7CB68CABDF4D4C
        public override async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlFailoverGroup> failoverGroups = new List<ISqlFailoverGroup>();
            var failoverGroupInners = await sqlServer.Manager.Inner.FailoverGroups
                .ListByServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            if (failoverGroupInners != null)
            {
                foreach (var failoverGroupInner in failoverGroupInners)
                {
                    failoverGroups.Add(new SqlFailoverGroupImpl(failoverGroupInner.Name, (SqlServerImpl)sqlServer, failoverGroupInner, sqlServer.Manager));
                }
            }
            return failoverGroups.AsReadOnly();
        }

        ///GENMHASH:13ABA4A4BF5D93EA980EDEC1BE3C22BB:A72078B391E7D07D6D121CB9A7260942
        public ISqlFailoverGroup Failover(string failoverGroupName)
        {
            return Extensions.Synchronize(() => this.FailoverAsync(failoverGroupName));
        }

        ///GENMHASH:823449E60E2B09230DA3D74B236C615B:5F93B83707ECCDE94FCF586684005C40
        public ISqlFailoverGroup Failover(string resourceGroupName, string serverName, string failoverGroupName)
        {
            return Extensions.Synchronize(() => this.FailoverAsync(resourceGroupName, serverName, failoverGroupName));
        }

        ///GENMHASH:B0505ACC9703B1DAF3E898E14CB1E9D0:A8E12D7F0BA2F34E2A1E53C3E463663C
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> ForceFailoverAllowDataLossAsync(string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var failoverGroupInner = await sqlServer.Manager.Inner.FailoverGroups
                .ForceFailoverAllowDataLossAsync(sqlServer.ResourceGroupName, sqlServer.Name, failoverGroupName, cancellationToken);
            return failoverGroupInner != null ? new SqlFailoverGroupImpl(failoverGroupInner.Name, (SqlServerImpl)sqlServer, failoverGroupInner, sqlServer.Manager) : null;
        }

        ///GENMHASH:61F96ECC4742CFA0B0A4C40977361599:DF3FB4274740E34FC4B4B192B82254AF
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> ForceFailoverAllowDataLossAsync(string resourceGroupName, string serverName, string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var failoverGroupInner = await this.sqlServerManager.Inner.FailoverGroups
                .ForceFailoverAllowDataLossAsync(resourceGroupName, serverName, failoverGroupName, cancellationToken);
            return failoverGroupInner != null ? new SqlFailoverGroupImpl(failoverGroupInner.Name, failoverGroupInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:6EF7D1DAC2987EC782225ED16069D311:CEC6BB28AAC268A12152AA1CC6F01028
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> FailoverAsync(string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var failoverGroupInner = await sqlServer.Manager.Inner.FailoverGroups
                .FailoverAsync(sqlServer.ResourceGroupName, sqlServer.Name, failoverGroupName, cancellationToken);
            return failoverGroupInner != null ? new SqlFailoverGroupImpl(failoverGroupInner.Name, (SqlServerImpl)sqlServer, failoverGroupInner, sqlServer.Manager) : null;
        }

        ///GENMHASH:62DF5F0EA8A41EAEC7C10F363C15A70D:359E301F2DBC600DE71CFD7551FAF5DA
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> FailoverAsync(string resourceGroupName, string serverName, string failoverGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var failoverGroupInner = await this.sqlServerManager.Inner.FailoverGroups
                .FailoverAsync(resourceGroupName, serverName, failoverGroupName, cancellationToken);
            return failoverGroupInner != null ? new SqlFailoverGroupImpl(failoverGroupInner.Name, failoverGroupInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:2A6462AE45E430A3F53D2BC369D967B4:BB73ECE81B37A07BEBFA849EB287D976
        public override async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var failoverGroupInner = await this.sqlServerManager.Inner.FailoverGroups
                .GetAsync(resourceGroupName, sqlServerName, name, cancellationToken);
            return failoverGroupInner != null ? new SqlFailoverGroupImpl(name, failoverGroupInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:48BA5938680939720DEA90858B8FC7E4:8C71C3FB84C5E4418326630DD51BD36D
        public override async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var failoverGroupInner = await sqlServer.Manager.Inner.FailoverGroups
                .GetAsync(sqlServer.ResourceGroupName, sqlServer.Name, name, cancellationToken);
            return failoverGroupInner != null ? new SqlFailoverGroupImpl(name, (SqlServerImpl)sqlServer, failoverGroupInner, sqlServer.Manager) : null;
        }

        ///GENMHASH:4ABAEC77990815B01AA39D981ECF5CA5:EF8B0782DB7978FCEB2038667CAE68ED
        public override void DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            Extensions.Synchronize(() => this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:7848595CD25BCD6EECF9E6FEBD0A3A0B
        public SqlFailoverGroupImpl Define(string name)
        {
            SqlFailoverGroupImpl result = new SqlFailoverGroupImpl(name, new Models.FailoverGroupInner(), this.sqlServerManager);
            return (this.sqlServer != null) ? result.WithExistingSqlServer(this.sqlServer) : result;
        }
    }
}