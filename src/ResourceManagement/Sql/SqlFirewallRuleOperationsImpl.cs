// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition;
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;
    using System.Linq;

    /// <summary>
    /// Implementation for SQL Firewall Rule operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxGaXJld2FsbFJ1bGVPcGVyYXRpb25zSW1wbA==
    internal partial class SqlFirewallRuleOperationsImpl  :
        ISqlFirewallRuleOperations,
        ISqlFirewallRuleActionsDefinition
    {
        private ISqlManager sqlServerManager;
        private ISqlServer sqlServer;
        ///GENMHASH:AD32A6F74A551E763332E8032D916730:329DC5E0778C1CD930146B1FA58434F1
        internal  SqlFirewallRuleOperationsImpl(ISqlServer parent, ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.sqlServer = parent ?? throw new ArgumentNullException("sqlServer");
        }

        ///GENMHASH:AD669FCACFFAEED680323AE7E70B7CE5:CDC93817549196F6D3DF3557216D5A8C
        internal  SqlFirewallRuleOperationsImpl(ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:5C3E0E7E1CF165D67A5D6B44C259B469
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            await this.DeleteBySqlServerAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:4852DA9B652321803EDBD8042FBCC6C2
        public async Task DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return;
            }
            await this.DeleteBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name, cancellationToken);
        }

        ///GENMHASH:AF8385463FD062B3C56A3F22F51DFEE4:89F947B2F8BC04689D6FAA14323B1C30
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> GetAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return null;
            }
            return await this.GetBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name,cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:D9367CF505E6A69115B40CBDC7433935
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> List()
        {
            if (sqlServer == null)
            {
                return null;
            }
            return Extensions.Synchronize(() => this.ListAsync());
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:5D57EEFD6EE8022130D22097C5816EB9
        public void Delete(string name)
        {
            if (sqlServer != null)
            {
                Extensions.Synchronize(() => this.DeleteAsync(name));
            }
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:D9F8D3E9ED7DAB13983F54ACF33544C9
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:48B8354F9A8656B355FBB651D3743037:AA3470C4F60CB578231D1D7ECE187239
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> ListBySqlServer(ISqlServer sqlServer)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(sqlServer.ResourceGroupName, sqlServer.Name));
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:F6E83293778C47BA5986DFEE8A40CF89
        public ISqlFirewallRule GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:3B0B15606AA6CA4AD0624C5561BF19C5:CE0B4456EB218526FB4F9D5ADD10809F
        public ISqlFirewallRule GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, name));
        }

        ///GENMHASH:7BD5581333BDF8A0EEFAF838D1C32E11:EBFCFC11F4FD6CB85E94F21B09A4BBE2
        public async Task DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.FirewallRules
                .DeleteAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:DFB9811D4C0F33590C78A6AF9E912994
        public ISqlFirewallRule GetById(string id)
        {
            return Extensions.Synchronize(() => this.GetByIdAsync(id));
        }

        ///GENMHASH:90DDF31DBCC18A1CCF68558A7E8449CD:8BFA54A78B9CC30FC87DEFDC8F50C6FF
        public async Task<IReadOnlyList<ISqlFirewallRule>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlFirewallRule> firewallRules = new List<ISqlFirewallRule>();
            var firewallRuleInners = await this.sqlServerManager.Inner.FirewallRules.ListByServerAsync(resourceGroupName, sqlServerName, cancellationToken);
            if (firewallRuleInners != null)
            {
                foreach (var firewallInner in firewallRuleInners)
                {
                    firewallRules.Add(new SqlFirewallRuleImpl(resourceGroupName, sqlServerName, firewallInner.Name, firewallInner, sqlServerManager));
                }
            }
            return firewallRules.AsReadOnly();
        }

        ///GENMHASH:2EA8D9073369A6E1267C1FB74F86952A:D8E0F4DFFB7F05F6B24DE7D662D8D81E
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlFirewallRule> firewallRules = new List<ISqlFirewallRule>();
            var firewallRuleInners = await sqlServer.Manager.Inner.FirewallRules.ListByServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            if (firewallRuleInners != null)
            {
                foreach (var firewallInner in firewallRuleInners)
                {
                    firewallRules.Add(new SqlFirewallRuleImpl(firewallInner.Name, (SqlServerImpl)sqlServer, firewallInner, sqlServer.Manager));
                }
            }
            return firewallRules.AsReadOnly();
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:FA828C83F50D26DFD2153BD3CCEFC82D
        public ISqlFirewallRule Get(string name)
        {
            return Extensions.Synchronize(() => this.GetAsync(name));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:487BF38141DB6ADDAB135D4A077E5776
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            return await this.GetBySqlServerAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        ///GENMHASH:2A6462AE45E430A3F53D2BC369D967B4:D094667796CF6867B147E7AA29FF0EB6
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var firewallRuleInner = await this.sqlServerManager.Inner.FirewallRules
                    .GetAsync(resourceGroupName, sqlServerName, name, cancellationToken);
                return firewallRuleInner != null ? new SqlFirewallRuleImpl(resourceGroupName, sqlServerName, firewallRuleInner.Name, firewallRuleInner, sqlServerManager) : null;
            }
            catch (CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (AggregateException ex)
            {
                if(ex.InnerExceptions != null)
                {
                    var cloudEx = (CloudException) ex.InnerExceptions.FirstOrDefault(e => e is CloudException);
                    if(cloudEx != null &&
                       cloudEx.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }

                throw ex;
            }
        }

        ///GENMHASH:48BA5938680939720DEA90858B8FC7E4:88B8D4CD3199DE6F67E88AD534A75856
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var firewallRuleInner = await sqlServer.Manager.Inner.FirewallRules
                    .GetAsync(sqlServer.ResourceGroupName, sqlServer.Name, name, cancellationToken);
                return firewallRuleInner != null ? new SqlFirewallRuleImpl(firewallRuleInner.Name, (SqlServerImpl)sqlServer, firewallRuleInner, sqlServer.Manager) : null;
            }
            catch (CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (AggregateException ex)
            {
                if(ex.InnerExceptions != null)
                {
                    var cloudEx = (CloudException) ex.InnerExceptions.FirstOrDefault(e => e is CloudException);
                    if(cloudEx != null &&
                       cloudEx.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }

                throw ex;
            }
        }

        ///GENMHASH:4ABAEC77990815B01AA39D981ECF5CA5:90B9C7BD61D57577CF56639A14C1BBC0
        public void DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            Extensions.Synchronize(() => this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:DCEEEF4375DAE606E6DAD8A9FDADD8F9
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => this.DeleteByIdAsync(id));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:307943992410821E8848C28E10217FEC
        public SqlFirewallRuleImpl Define(string name)
        {
            SqlFirewallRuleImpl result = new SqlFirewallRuleImpl(name, new Models.FirewallRuleInner(), this.sqlServerManager);
            return (this.sqlServer != null) ? result.WithExistingSqlServer(this.sqlServer) : result;
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:70CAAAFCFE4094EE282365E141022A3D
        public async Task<IReadOnlyList<ISqlFirewallRule>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlServer == null)
            {
                return null;
            }
            return await this.ListBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, cancellationToken);
        }
    }
}