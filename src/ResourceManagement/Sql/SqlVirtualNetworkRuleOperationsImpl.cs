// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition;
    using System.Collections.Generic;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System.Linq;

    /// <summary>
    /// Implementation for SQL Virtual Network Rule operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxWaXJ0dWFsTmV0d29ya1J1bGVPcGVyYXRpb25zSW1wbA==
    internal partial class SqlVirtualNetworkRuleOperationsImpl  :
        ISqlVirtualNetworkRuleOperations,
        ISqlVirtualNetworkRuleActionsDefinition
    {
        private ISqlManager sqlServerManager;
        private ISqlServer sqlServer;

        ///GENMHASH:FADADB5A45CA913DB3D82883282DED5F:172DFD0C55F9647DA063B9F8DD99B72F
        internal SqlVirtualNetworkRuleOperationsImpl(ISqlServer parent, ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.sqlServer = parent ?? throw new ArgumentNullException("sqlServer");
        }

        ///GENMHASH:3B357D747B8FE8DBA395FCE2B790551E:A7BF2E821587BBA77FF79ADAEDD68B33
        internal SqlVirtualNetworkRuleOperationsImpl(ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:97F2B64C1F4F5E00F59C6275948CB70B
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:48B8354F9A8656B355FBB651D3743037:E8808166908D9271E78AE127C6784184
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> ListBySqlServer(ISqlServer sqlServer)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(sqlServer));
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:5E8AB510C9E69E6DA4A2656F368BB053
        public ISqlVirtualNetworkRule GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:3B0B15606AA6CA4AD0624C5561BF19C5:A9C66147B7BF3C2731755FE9E322E0A2
        public ISqlVirtualNetworkRule GetBySqlServer(ISqlServer sqlServer, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, name));
        }

        ///GENMHASH:7BD5581333BDF8A0EEFAF838D1C32E11:9DE50B8CDDC51DC39E2104E80E2ABD94
        public async Task DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.VirtualNetworkRules
                .DeleteAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        ///GENMHASH:90DDF31DBCC18A1CCF68558A7E8449CD:E9F96A74ED2DA7AD58934E5EB6F473D1
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlVirtualNetworkRule> virtualNetworkRules = new List<ISqlVirtualNetworkRule>();
            var virtualNetworkRuleInners = await this.sqlServerManager.Inner.VirtualNetworkRules.ListByServerAsync(resourceGroupName, sqlServerName, cancellationToken);
            if (virtualNetworkRuleInners != null)
            {
                foreach (var vnetInner in virtualNetworkRuleInners)
                {
                    virtualNetworkRules.Add(new SqlVirtualNetworkRuleImpl(resourceGroupName, sqlServerName, vnetInner.Name, vnetInner, sqlServerManager));
                }
            }
            return virtualNetworkRules.AsReadOnly();
        }

        ///GENMHASH:2EA8D9073369A6E1267C1FB74F86952A:72066CB6329F9723DD915945A2B73E0E
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlVirtualNetworkRule> virtualNetworkRules = new List<ISqlVirtualNetworkRule>();
            var virtualNetworkRuleInners = await sqlServer.Manager.Inner.VirtualNetworkRules.ListByServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            if (virtualNetworkRuleInners != null)
            {
                foreach (var vnetInner in virtualNetworkRuleInners)
                {
                    virtualNetworkRules.Add(new SqlVirtualNetworkRuleImpl(vnetInner.Name, (SqlServerImpl) sqlServer, vnetInner, sqlServerManager));
                }
            }
            return virtualNetworkRules.AsReadOnly();
        }

        ///GENMHASH:2A6462AE45E430A3F53D2BC369D967B4:2ACB5605EFFBF7FE1BA6DAD207415243
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var vnetInner = await this.sqlServerManager.Inner.VirtualNetworkRules
                    .GetAsync(resourceGroupName, sqlServerName, name, cancellationToken);
                return vnetInner != null ? new SqlVirtualNetworkRuleImpl(resourceGroupName, sqlServerName, vnetInner.Name, vnetInner, sqlServerManager) : null;
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

        ///GENMHASH:48BA5938680939720DEA90858B8FC7E4:7B0BE68814CDBEBD16BFB8FD8569FD09
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var vnetInner = await sqlServer.Manager.Inner.VirtualNetworkRules
                    .GetAsync(sqlServer.ResourceGroupName, sqlServer.Name, name, cancellationToken);
                return vnetInner != null ? new SqlVirtualNetworkRuleImpl(vnetInner.Name, (SqlServerImpl)sqlServer, vnetInner, sqlServerManager) : null;
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

        ///GENMHASH:4ABAEC77990815B01AA39D981ECF5CA5:5BC2CE295A48AC2AB6D73BB441883E14
        public void DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            Extensions.Synchronize(() => this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:97EADFA6DB9288740DDD782E3253A18B
        public SqlVirtualNetworkRuleImpl Define(string name)
        {
            SqlVirtualNetworkRuleImpl result = new SqlVirtualNetworkRuleImpl(name, new Models.VirtualNetworkRuleInner(), this.sqlServerManager);
            return (this.sqlServer != null) ? result.WithExistingSqlServer(this.sqlServer) : result;
        }

        public ISqlVirtualNetworkRule GetById(string id)
        {
            return Extensions.Synchronize(() => this.GetByIdAsync(id));
        }

        public async Task<ISqlVirtualNetworkRule> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            return await this.GetBySqlServerAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => this.DeleteByIdAsync(id));
        }

        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            await this.DeleteBySqlServerAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        public ISqlVirtualNetworkRule Get(string name)
        {
            return Extensions.Synchronize(() => this.GetAsync(name));
        }

        public async Task DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return;
            }
            await this.DeleteBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name, cancellationToken);
        }

        public async Task<ISqlVirtualNetworkRule> GetAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return null;
            }
            return await this.GetBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name, cancellationToken);
        }

        public IReadOnlyList<ISqlVirtualNetworkRule> List()
        {
            if (sqlServer == null)
            {
                return null;
            }
            return Extensions.Synchronize(() => this.ListAsync());
        }

        public void Delete(string name)
        {
            if (sqlServer != null)
            {
                Extensions.Synchronize(() => this.DeleteAsync(name));
            }
        }

        public async Task<IReadOnlyList<ISqlVirtualNetworkRule>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlServer == null)
            {
                return null;
            }
            return await this.ListBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, cancellationToken);
        }
    }
}