// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlChildrenOperations.SqlChildrenActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberActionsDefinition;
    using System.Collections.Generic;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for SQL Sync Member operations.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTeW5jTWVtYmVyT3BlcmF0aW9uc0ltcGw=
    internal partial class SqlSyncMemberOperationsImpl  :
        ISqlSyncMemberOperations,
        ISqlSyncMemberActionsDefinition
    {
        protected ISqlManager sqlServerManager;
        protected string resourceGroupName;
        protected string sqlServerName;
        protected string sqlDatabaseName;
        protected string sqlSyncGroupName;
        protected SqlSyncGroupImpl sqlSyncGroup;

        ///GENMHASH:ACC9C133F34D0F418579A9E96E6FA97A:424D49E5DB6926D2DCED05C34EFBEA53
        internal SqlSyncMemberOperationsImpl(SqlSyncGroupImpl parent, ISqlManager sqlServerManager)
        {
            this.sqlSyncGroup = parent;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName();
            this.sqlServerName = parent.SqlServerName();
            this.sqlDatabaseName = parent.SqlDatabaseName();
            this.sqlSyncGroupName = parent.Name();
        }

        ///GENMHASH:23D74019CC661748BA0FA613C6E68332:B9438CBADF67F717E9124756C880E7E3
        internal SqlSyncMemberOperationsImpl(ISqlManager sqlServerManager)
        {
            this.sqlServerManager = sqlServerManager;
        }


        ///GENMHASH:4D33A73A344E127F784620E76B686786:4A0B32E6454052B1626A31B4D67C6E3D
        public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
            {
                throw new ArgumentNullException(id);
            }
            var resourceId = ResourceId.FromString(id);
            await this.sqlServerManager.Inner.SyncMembers
                .DeleteAsync(resourceId.ResourceGroupName, resourceId.Parent.Parent.Parent.Name, resourceId.Parent.Parent.Name, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:1A21AD9713607C3B5E7193961360CB6D
        public async Task DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlSyncGroup == null)
            {
                return;
            }
            await this.sqlServerManager.Inner.SyncMembers
                .DeleteAsync(this.sqlSyncGroup.ResourceGroupName(), this.sqlSyncGroup.SqlServerName(), this.sqlSyncGroup.SqlDatabaseName(), this.sqlSyncGroup.Name(), name, cancellationToken);
        }

        ///GENMHASH:AF8385463FD062B3C56A3F22F51DFEE4:0E00A8352429145A92A366F784D0DE5A
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> GetAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.sqlSyncGroup == null)
            {
                return null;
            }
            return await this.GetBySqlServerAsync(this.sqlSyncGroup.ResourceGroupName(), this.sqlSyncGroup.SqlServerName(), this.sqlSyncGroup.SqlDatabaseName(), this.sqlSyncGroup.Name(), name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:84537AC8DF442484DD0BF1E0A49B8C79
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> List()
        {
            return Extensions.Synchronize(() => this.ListAsync());
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:163580BAF8975AFF93AFB02D453DAEEF
        public void Delete(string name)
        {
            Extensions.Synchronize(() => this.DeleteAsync(name));
        }

        ///GENMHASH:0C6002DE0CC67086ACE76C9FD6FC9E1C:865021A03D528859628D8E5EAB65FD83
        public ISqlSyncMember GetBySqlServer(string resourceGroupName, string sqlServerName, string databaseName, string syncGroupName, string name)
        {
            return Extensions.Synchronize(() => this.GetBySqlServerAsync(resourceGroupName, sqlServerName, databaseName, syncGroupName, name));
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:C2856B98C62EF4FE70F5B0F8D2ECA74A
        public ISqlSyncMember GetById(string id)
        {
            return Extensions.Synchronize(() => this.GetByIdAsync(id));
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:A9E8EF3BF41161B9A9ECA7CFD3DF50EF
        public ISqlSyncMember Get(string name)
        {
            return Extensions.Synchronize(() => this.GetAsync(name));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:88398B5E7135AFC72C8611D5BE5529F8
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resourceId = ResourceId.FromString(id);
            return await this.GetBySqlServerAsync(resourceId.ResourceGroupName,
                resourceId.Parent.Parent.Parent.Name,
                resourceId.Parent.Parent.Name,
                resourceId.Parent.Name,
                resourceId.Name,
                cancellationToken);
        }

        ///GENMHASH:A4252703D0A590C31AAD57D794FE5BB6:8EB78C2F7C38928FA26753DF5CABD0B6
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, string databaseName, string syncGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var syncMemberInner = await this.sqlServerManager.Inner.SyncMembers
                .GetAsync(resourceGroupName, sqlServerName, databaseName, syncGroupName, name, cancellationToken);
            return syncMemberInner != null ? new SqlSyncMemberImpl(resourceGroupName, sqlServerName, databaseName, syncGroupName, name, syncMemberInner, sqlServerManager) : null;
        }

        ///GENMHASH:CFA8F482B43AF8D63CC08E2DEC651ED3:B9D03022E72B7DC5B099BAFDABEC7442
        public void DeleteById(string id)
        {
            Extensions.Synchronize(() => this.DeleteByIdAsync(id));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:3C1AD7F2E7350250AEFC92048B000C72
        public SqlSyncMemberImpl Define(string syncMemberName)
        {
            SqlSyncMemberImpl result = new SqlSyncMemberImpl(syncMemberName, new Models.SyncMemberInner(), this.sqlServerManager);
            return (this.sqlSyncGroup != null) ? result.WithExistingSyncGroup(this.sqlSyncGroup) : result;
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:7385C0002F875B0C788050E2BE7D4E25
        public async Task<IReadOnlyList<ISqlSyncMember>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlSyncMember> syncMembers = new List<ISqlSyncMember>();
            var syncMemberInners = await this.sqlServerManager.Inner.SyncMembers
                .ListBySyncGroupAsync(this.sqlSyncGroup.ResourceGroupName(), this.sqlSyncGroup.SqlServerName(), this.sqlSyncGroup.SqlDatabaseName(), this.sqlSyncGroup.Name(), cancellationToken: cancellationToken);
            if (syncMemberInners != null)
            {
                foreach (var syncMemberInner in syncMemberInners)
                {
                    syncMembers.Add(new SqlSyncMemberImpl(syncMemberInner.Name, this.sqlSyncGroup, syncMemberInner, this.sqlServerManager));
                }
            }
            return syncMembers.AsReadOnly();
        }
    }
}