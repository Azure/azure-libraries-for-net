// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolActionsDefinition;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SQL Elastic Pool operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbGFzdGljUG9vbE9wZXJhdGlvbnNJbXBs
    internal partial class SqlElasticPoolOperationsImpl  :
        ISqlElasticPoolOperations,
        ISqlElasticPoolActionsDefinition
    {
        private ISqlManager sqlServerManager;
        private SqlServerImpl sqlServer;

        ///GENMHASH:6EF40C7088F4AB95634491B66D895ECF:8CB8DB077ED47691080FA22BD4C3C522
        internal  SqlElasticPoolOperationsImpl(SqlServerImpl sqlServer, ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.sqlServer = sqlServer ?? throw new ArgumentNullException("sqlServer");
        }

        ///GENMHASH:CD63FC8E4DA9B124B90210C6433EAE54:231D56D4249EEBB55918FF09074F26AC
        internal  SqlElasticPoolOperationsImpl(ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:5C3E0E7E1CF165D67A5D6B44C259B469
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
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
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> GetAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return null;
            }
            return await this.GetBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:D9367CF505E6A69115B40CBDC7433935
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> List()
        {
            if (sqlServer == null)
            {
                return null;
            }
            return this.ListBySqlServer(this.sqlServer.ResourceGroupName, this.sqlServer.Name);
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:5D57EEFD6EE8022130D22097C5816EB9
        public void Delete(string name)
        {
            if (sqlServer != null)
            {
                this.DeleteBySqlServer(this.sqlServer.ResourceGroupName, this.sqlServer.Name, name);
            }
        }

        ///GENMHASH:16CEA22B57032A6757D8EFC1BF423794:DA8A70BB6AEAB69543D2F6330867BC49
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(resourceGroupName, sqlServerName));
        }

        ///GENMHASH:48B8354F9A8656B355FBB651D3743037:9B64F0495229B6EEBD7A8DDEE5326556
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> ListBySqlServer(ISqlServer sqlServer)
        {
            if (sqlServer == null)
            {
                throw new ArgumentNullException("sqlServer");
            }
            return Extensions.Synchronize(() => this.ListBySqlServerAsync(sqlServer.ResourceGroupName, sqlServer.Name));
        }

        ///GENMHASH:03C6F391A16F96A5127D98827B5423FA:BE16A3B886DD568226C830440DC2DAA7
        public ISqlElasticPool GetBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:3B0B15606AA6CA4AD0624C5561BF19C5:A9E9AB4B017262AAA3EFB145E51AE47B
        public ISqlElasticPool GetBySqlServer(ISqlServer sqlServer, string name)
        {
            if (sqlServer == null)
            {
                throw new ArgumentNullException("sqlServer");
            }
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, name));
        }

        ///GENMHASH:7BD5581333BDF8A0EEFAF838D1C32E11:BA5794CF4BCD05AA113819FD3914116D
        public async Task DeleteBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ElasticPools.DeleteAsync(resourceGroupName, sqlServerName, name, cancellationToken);
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:DFB9811D4C0F33590C78A6AF9E912994
        public ISqlElasticPool GetById(string id)
        {
            return Extensions.Synchronize(() => this.GetByIdAsync(id));
        }

        ///GENMHASH:90DDF31DBCC18A1CCF68558A7E8449CD:E71AB16059419D3000A6A59F8158CEA7
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> epResult = new List<ISqlElasticPool>();
            var epInners = await this.sqlServerManager.Inner.ElasticPools
                .ListByServerAsync(resourceGroupName, sqlServerName, cancellationToken);
            if (epInners != null)
            {
                foreach (var inner in epInners)
                {
                    epResult.Add(new SqlElasticPoolImpl(resourceGroupName, sqlServerName, inner.Location, inner.Name, inner, sqlServerManager));
                }
            }
            return epResult.AsReadOnly();
        }

        ///GENMHASH:2EA8D9073369A6E1267C1FB74F86952A:3FA6AF4D257E45CE5540FB3347D737E9
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> epResult = new List<ISqlElasticPool>();
            var epInners = await sqlServer.Manager.Inner.ElasticPools
                .ListByServerAsync(sqlServer.ResourceGroupName, sqlServer.Name, cancellationToken);
            if (epInners != null)
            {
                foreach (var inner in epInners)
                {
                    epResult.Add(new SqlElasticPoolImpl(inner.Name, (SqlServerImpl)sqlServer, inner, sqlServer.Manager));
                }
            }
            return epResult.AsReadOnly();
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:FA828C83F50D26DFD2153BD3CCEFC82D
        public ISqlElasticPool Get(string name)
        {
            return Extensions.Synchronize(() => this.GetAsync(name));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:487BF38141DB6ADDAB135D4A077E5776
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            var resourceId = ResourceId.FromString(id);
            return await this.GetBySqlServerAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        ///GENMHASH:2A6462AE45E430A3F53D2BC369D967B4:1C85BDC510E5705073594C45003A1F75
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var inner = await this.sqlServerManager.Inner.ElasticPools
                    .GetAsync(resourceGroupName, sqlServerName, name, cancellationToken);
                return inner != null ? new SqlElasticPoolImpl(resourceGroupName, sqlServerName, inner.Location, inner.Name, inner, sqlServerManager) : null;
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

        ///GENMHASH:48BA5938680939720DEA90858B8FC7E4:E9FF7173291C37BB90131AFD98056DFB
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> GetBySqlServerAsync(ISqlServer sqlServer, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var inner = await sqlServer.Manager.Inner.ElasticPools
                    .GetAsync(sqlServer.ResourceGroupName, sqlServer.Name, name, cancellationToken);
                return inner != null ? new SqlElasticPoolImpl(inner.Name, (SqlServerImpl)sqlServer, inner, sqlServer.Manager) : null;
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

        ///GENMHASH:4ABAEC77990815B01AA39D981ECF5CA5:7B4C873AD96DDB70439BE31E3C123A72
        public void DeleteBySqlServer(string resourceGroupName, string sqlServerName, string name)
        {
            Extensions.Synchronize(() => this.DeleteBySqlServerAsync(resourceGroupName, sqlServerName, name));
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:DCEEEF4375DAE606E6DAD8A9FDADD8F9
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => this.DeleteByIdAsync(id));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:CEB5A71557A5E0E3652D4FFCD5033B00
        public SqlElasticPoolImpl Define(string name)
        {
            SqlElasticPoolImpl result = new SqlElasticPoolImpl(name, new Models.ElasticPoolInner(), this.sqlServerManager);
            return (this.sqlServer != null) ? result.WithExistingSqlServer(this.sqlServer) : result;
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:70CAAAFCFE4094EE282365E141022A3D
        public async Task<IReadOnlyList<ISqlElasticPool>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlServer == null)
            {
                return null;
            }
            return await this.ListBySqlServerAsync(this.sqlServer.ResourceGroupName, this.sqlServer.Name, cancellationToken);
        }
    }
}