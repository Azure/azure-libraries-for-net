// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupActionsDefinition;
    using System;

    /// <summary>
    /// Implementation for SQL Sync Group operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTeW5jR3JvdXBPcGVyYXRpb25zSW1wbA==
    internal partial class SqlSyncGroupOperationsImpl  :
        ISqlSyncGroupOperations,
        ISqlSyncGroupActionsDefinition
    {
        protected ISqlManager sqlServerManager;
        protected string resourceGroupName;
        protected string sqlServerName;
        protected string sqlDatabaseName;
        protected SqlDatabaseImpl sqlDatabase;

        ///GENMHASH:3FC4629A94EA4CFEC41549C1F3C77668:8133340974DB918052A51C4316313E0B
        internal SqlSyncGroupOperationsImpl(SqlDatabaseImpl parent, ISqlManager sqlServerManager)
        {
            this.sqlDatabase = parent;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName();
            this.sqlServerName = parent.SqlServerName();
            this.sqlDatabaseName = parent.Name();
        }

        ///GENMHASH:9C2A175D65B3AA9BD179F1242A5E83B1:B9438CBADF67F717E9124756C880E7E3
        internal SqlSyncGroupOperationsImpl(ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager;
        }

        ///GENMHASH:B2B2B8F5736EAA955B6B55C297214E20:7A83944268F46EC175944AA700D1EF68
        public async Task<IEnumerable<string>> ListSyncDatabaseIdsAsync(string locationName, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<string> syncDatabaseIdProperties = new List<string>();
            var syncDatabaseIdPropertiesInners = await this.sqlServerManager.Inner.SyncGroups
                .ListSyncDatabaseIdsAsync(locationName, cancellationToken: cancellationToken);
            if (syncDatabaseIdPropertiesInners != null)
            {
                foreach (var syncDatabaseIdPropertiesInner in syncDatabaseIdPropertiesInners)
                {
                    syncDatabaseIdProperties.Add(syncDatabaseIdPropertiesInner.Id);
                }
            }
            return syncDatabaseIdProperties.AsReadOnly();
        }

        ///GENMHASH:3CD1F7482E9E8D57064F7FFA885C9443:262DD8CDE3B60A8F793BC3FBC13997AF
        public async Task<IEnumerable<string>> ListSyncDatabaseIdsAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListSyncDatabaseIdsAsync(region.Name, cancellationToken);
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:3EFE936B2516F1A1DC72FD223B7C5857
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            await this.sqlServerManager.Inner.SyncGroups
                .DeleteAsync(resourceId.ResourceGroupName, resourceId.Parent.Parent.Name, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:1BEF321A7DF2B0978C4F56E3EAE72F1D
        public async Task DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlDatabase == null)
            {
                return;
            }
            await this.sqlServerManager.Inner.SyncGroups
                .DeleteAsync(this.sqlDatabase.ResourceGroupName(), this.sqlDatabase.SqlServerName(), this.sqlDatabase.Name(), name, cancellationToken);
        }

        ///GENMHASH:AF8385463FD062B3C56A3F22F51DFEE4:1B42309E30131D730BB11A008DC5155B
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> GetAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlDatabase == null)
            {
                return null;
            }
            return await this.GetBySqlServerAsync(this.sqlDatabase.ResourceGroupName(), this.sqlDatabase.SqlServerName(), this.sqlDatabase.Name(), name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:82CB51D9E702504B0BB2055AB2FE5C2E
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> List()
        {
            return Extensions.Synchronize(() => this.ListAsync());
        }

        ///GENMHASH:72B167BB049FE51DB5B8083E64CB40DC:EB53EBC03053F0CE299B82EBA3750086
        public IEnumerable<string> ListSyncDatabaseIds(string locationName)
        {
            return Extensions.Synchronize(() => this.ListSyncDatabaseIdsAsync(locationName));
        }

        ///GENMHASH:DEE1795636C121ED4A09DB3E168AD680:6855193ED00ADA0BF5C781DBF6E8B5B2
        public IEnumerable<string> ListSyncDatabaseIds(Region region)
        {
            return Extensions.Synchronize(() => this.ListSyncDatabaseIdsAsync(region.Name));
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:2B77326A14C3E8373051D77E2DDE3136
        public void Delete(string name)
        {
            Extensions.Synchronize(() => this.DeleteAsync(name));
        }

        ///GENMHASH:634DD8CD411508E79BD0EE40A623FCA3:7EB51BE3FE7CCB3478933AF6B330F607
        public ISqlSyncGroup GetBySqlServer(string resourceGroupName, string sqlServerName, string databaseName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, databaseName, name));
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:102DA0863A9F7ADA031615BC8A7EEB38
        public ISqlSyncGroup GetById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            return this.GetBySqlServer(resourceId.ResourceGroupName,
                resourceId.Parent.Parent.Name,
                resourceId.Parent.Name,
                resourceId.Name);
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:87595AD99EF4B1BE16FAF71135180FA9
        public ISqlSyncGroup Get(string name)
        {
            if (this.sqlDatabase == null) {
                return null;
            }
            return this.GetBySqlServer(this.sqlDatabase.ResourceGroupName(), this.sqlDatabase.SqlServerName(), this.sqlDatabase.Name(), name);
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:2514AD4015276121B15CE4CC444256B6
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            return await this.GetBySqlServerAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Parent.Name,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:02608B45CAA81355380819DD3EAA1DFB:34B2990F9E19C36265E12F2621574371
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string databaseName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var syncGroupInner = await this.sqlServerManager.Inner.SyncGroups
                .GetAsync(resourceGroupName, sqlServerName, databaseName, name, cancellationToken);
            return syncGroupInner != null ? new SqlSyncGroupImpl(resourceGroupName, sqlServerName, databaseName, name, syncGroupInner, sqlServerManager) : null;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AAFB116D45DCF8ADB3D006750373417E
        public SqlSyncGroupImpl Define(string name)
        {
            SqlSyncGroupImpl result = new SqlSyncGroupImpl(name, new Models.SyncGroupInner(), this.sqlServerManager);
            return (this.sqlDatabase != null) ? result.WithExistingSqlDatabase(this.sqlDatabase) : result;
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:00B47599BF2DE4AD280FC21725DD6888
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => this.DeleteByIdAsync(id));
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:6E8560C4CFD45325BAB666227553CDAE
        public async Task<IReadOnlyList<ISqlSyncGroup>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlSyncGroup> syncGroups = new List<ISqlSyncGroup>();
            if (this.sqlDatabase != null)
            {
                var syncGroupInners = await this.sqlServerManager.Inner.SyncGroups
                    .ListByDatabaseAsync(this.sqlDatabase.ResourceGroupName(), this.sqlDatabase.SqlServerName(), this.sqlDatabase.Name(), cancellationToken);
                if (syncGroupInners != null)
                {
                    foreach (var syncGroupInner in syncGroupInners)
                    {
                        syncGroups.Add(new SqlSyncGroupImpl(syncGroupInner.Name, this.sqlDatabase, syncGroupInner, this.sqlServerManager));
                    }
                }
            }
            return syncGroups.AsReadOnly();
        }
    }
}