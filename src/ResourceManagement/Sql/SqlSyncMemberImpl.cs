// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMember.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for SqlSyncMember.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTeW5jTWVtYmVySW1wbA==
    internal partial class SqlSyncMemberImpl :
        ChildResource<
            Models.SyncMemberInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup>,
        ISqlSyncMember,
        IUpdate,
        ISqlSyncMemberOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private string sqlDatabaseName;
        private string sqlSyncGroupName;
        private string name;

        string IExternalChildResource<ISqlSyncMember, ISqlSyncGroup>.Id => this.Id();

        string ICreatable<ISqlSyncMember>.Name => this.Name();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:CCE195E09193EDC4383029CD5CB1C628:2B6C79416FE1C7672196779693AE2D14
        internal SqlSyncMemberImpl(string name, SqlSyncGroupImpl parent, SyncMemberInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName();
            this.sqlServerName = parent.SqlServerName();
            this.sqlDatabaseName = parent.SqlDatabaseName();
            this.sqlSyncGroupName = parent.Name();
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="sqlDatabaseName">The parent SQL Database name.</param>
        /// <param name="sqlSyncGroupName">The parent SQL Sync Group name.</param>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:8F51618C600342C2ED2950C13B0FBCBA:94FDB59ED889413CE8D45C337B683C50
        internal SqlSyncMemberImpl(string resourceGroupName, string sqlServerName, string sqlDatabaseName, string sqlSyncGroupName, string name, SyncMemberInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlDatabaseName = sqlDatabaseName;
            this.sqlSyncGroupName = sqlSyncGroupName;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:DE04C9A4A480ADDBCD794C715F4CCE5C:657722CF28579ADFAAA5E7E0CF6B5310
        internal SqlSyncMemberImpl(string name, SyncMemberInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            if (innerObject?.Id != null)
            {
                ResourceId resourceId = ResourceId.FromString(innerObject.Id);
                this.resourceGroupName = resourceId?.ResourceGroupName;
                this.sqlServerName = resourceId?.Parent?.Parent?.Parent?.Name;
                this.sqlDatabaseName = resourceId?.Parent?.Parent?.Name;
                this.sqlSyncGroupName = resourceId?.Parent?.Name;
                this.name = resourceId?.Name;
            }
        }

        public override string Name()
        {
            return this.name != null ? this.name : this.Inner?.Name;
        }

        ///GENMHASH:4406FF130E0497422AB31764F93B67AF:2CB2314804E457C9AD1B8E50E30A4F25
        public string SqlServerDatabaseId()
        {
            return this.Inner.SqlServerDatabaseId?.ToString();
        }

        ///GENMHASH:19BDEFC584B241587C4709ED25967CE0:42CA41F2097F28B6EEE58BD9D20EE6E0
        public SqlSyncMemberImpl WithExistingSyncGroupName(string syncGroupName)
        {
            this.sqlSyncGroupName = syncGroupName;
            return this;
        }

        ///GENMHASH:3B89742D1355B6B50FE928002B887FA2:55F0618BF6BD745C131C2BBD910CE4A0
        public string MemberServerName()
        {
            return this.Inner.ServerName;
        }

        ///GENMHASH:8085A7265EABA1790A728BA058BF34C6:BBC4EB2C23A13FF787D5322550E0EB4B
        public SqlSyncMemberImpl WithMemberDatabaseType(SyncMemberDbType databaseType)
        {
            this.Inner.DatabaseType = databaseType;
            return this;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:3322885CA35DEA7D7DD9EDDD0C44CF4C
        public IUpdate Update()
        {
            return this;
        }

        ///GENMHASH:25076928AAC27A4AEF5E24263CA3A83E:BB65DCC91137A34835DD213F6DE86BBC
        public async Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty>> ListMemberSchemasAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlSyncFullSchemaProperty> syncFullSchemaProperties = new List<ISqlSyncFullSchemaProperty>();
            var syncFullSchemaPropertiesInners = await this.sqlServerManager.Inner.SyncMembers
                .ListMemberSchemasAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.sqlSyncGroupName, this.Name(), cancellationToken);
            if (syncFullSchemaPropertiesInners != null)
            {
                foreach(var syncFullSchemaPropertiesInner in syncFullSchemaPropertiesInners)
                {
                    syncFullSchemaProperties.Add(new SqlSyncFullSchemaPropertyImpl(syncFullSchemaPropertiesInner));
                }
            }
            return syncFullSchemaProperties.AsReadOnly();
        }

        ///GENMHASH:875F3540BA3FFB0A7D4F8D040D5A538D:E7F94FDE664937F65EA0A83B5F814E68
        public SqlSyncMemberImpl WithDatabaseType(SyncDirection syncDirection)
        {
            this.Inner.SyncDirection = syncDirection;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:99137EC72E3EC025058CD00310C87AAC
        protected async Task<Models.SyncMemberInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.SyncMembers
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.sqlSyncGroupName, this.Name(), cancellationToken);
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:AA95D6FDB4843CF4994807B6D0B0BDD1
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:AD9CBE3ED55BCB7F75ECA04BEF92EF94:C6A660CBF70DBA9C3C4C09B0129FC86B
        public string SyncAgentId()
        {
            return this.Inner.SyncAgentId;
        }

        ///GENMHASH:8414FE72599249183B9C969B46AE2CDA:11C8814437754CFE63567E4BB352C26F
        public SqlSyncMemberImpl WithExistingDatabaseName(string databaseName)
        {
            this.sqlDatabaseName = databaseName;
            return this;
        }

        ///GENMHASH:FB979A042C59037777BE6C82A7D9F3D6:A1BBA0ABD8BFAFE0F17713B473FF93EE
        public SqlSyncMemberImpl WithExistingSyncGroup(ISqlSyncGroup sqlSyncGroup)
        {
            this.resourceGroupName = sqlSyncGroup.ResourceGroupName;
            this.sqlServerName = sqlSyncGroup.SqlServerName;
            this.sqlDatabaseName = sqlSyncGroup.SqlDatabaseName;
            this.sqlSyncGroupName = sqlSyncGroup.Name;
            return this;
        }

        ///GENMHASH:F22B4F7A39FEC67896EBC5CEC1D19089:DC262CD404279EC6A778CBAABE7F0797
        public void RefreshMemberSchema()
        {
            Extensions.Synchronize(() => this.RefreshMemberSchemaAsync());
        }

        ///GENMHASH:436F7850C246C7C576AE519E5EBB4FB9:E0FF69255451FAEFFAD90954D3EC0E83
        public async Task RefreshMemberSchemaAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.SyncMembers
                .RefreshMemberSchemaAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.sqlSyncGroupName, this.Name(), cancellationToken);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:4C4C4336C86119672D7AD1E0D4BD29CB
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:5B9DE3DA00858077FEA3C153D30668E6:8892D33C89EB45AB71456048E4189668
        public SqlSyncMemberImpl WithMemberPassword(string password)
        {
            this.Inner.Password = password;
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:275C0EFF6801962F56817CC44AF6A1E6
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncMember> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var syncMemberInner = await this.sqlServerManager.Inner.SyncMembers
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.sqlSyncGroupName, this.Name(), this.Inner, cancellationToken);
            this.SetInner(syncMemberInner);
            return this;
        }

        ///GENMHASH:5B280DE182C5D2EEE8C64386C4189509:5410FC47FF345DF1DE37D0895E5DCAB0
        public SqlSyncMemberImpl WithMemberUserName(string userName)
        {
            this.Inner.UserName = userName;
            return this;
        }

        ///GENMHASH:7BF54DCB43A8F83CAF5BA49CA6152E2D:56A31ED1F97C814F0A1E5485E213758D
        public SqlSyncMemberImpl WithMemberSqlServerName(string sqlServerName)
        {
            this.Inner.ServerName = sqlServerName;
            return this;
        }

        ///GENMHASH:D55C0BC6C1896D10050A2A45B9F1E6FC:2D29DF7CB31893427EBF0651FBEE3AD4
        public SqlSyncMemberImpl WithMemberSqlDatabase(ISqlDatabase sqlDatabase)
        {
            this.Inner.ServerName = sqlDatabase.SqlServerName;
            this.Inner.DatabaseName = sqlDatabase.Name;
            return this;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:3A4DD77C2E8D817499C6F60417AB3596:44F5F71CD9996FE437F3FF8F3E8E46F9
        public string MemberDatabaseName()
        {
            return this.Inner.DatabaseName;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:0BA2C0DAE27266D79653208FF06A9B80:99EDD7AD8CCAED9BC095807A7E85DE17
        public SqlSyncMemberImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            return this;
        }

        ///GENMHASH:74CC786A12BD16E99274FDA4312C231B:8CBE6D07DEC2431D8F827589DF59CAAD
        public SyncMemberState SyncState()
        {
            return this.Inner.SyncState;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:A3379C409FDEA374F81BA23D717740E8:1911A6A619CB13C7EE098F82118AC819
        public string UserName()
        {
            return this.Inner.UserName;
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:2DC6B3BEB4C8A428A0339820143BFEB3
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:AF40DAB933F8B3F7B0F9B5DF8CA667F7:BDB25FFB52E063698BA7165F98332656
        public SqlSyncMemberImpl WithMemberSqlDatabaseName(string sqlDatabaseName)
        {
            this.Inner.DatabaseName = sqlDatabaseName;
            return this;
        }

        ///GENMHASH:34645F7AAC85BDB9B4B2319A8E8A5AD6:DEB5F8EF5229ECF71C1EE408DFDD3674
        public SyncMemberDbType DatabaseType()
        {
            return this.Inner.DatabaseType;
        }

        ///GENMHASH:0A8C95E7BCF012420BB9CA8540401D0F:BD7BB32481D5B7E613BD35E4E7DB5CBF
        public SyncDirection SyncDirection()
        {
            return this.Inner.SyncDirection;
        }

        ///GENMHASH:6059E1A9D3915C813F3878D0DB9E0819:31BC00949A75A3F86A2BE328DDB25175
        public IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty> ListMemberSchemas()
        {
            return Extensions.Synchronize(() => this.ListMemberSchemasAsync());
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:5F4B36E6AB2C7F6F3128E769FD2DE126
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.SyncMembers
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.sqlSyncGroupName, this.Name(), cancellationToken);
        }

        ///GENMHASH:D6F2CA9FCB582F6890064D6BF0DD0F7D:9C4EE3FA82BE9069D73452E4AE656294
        public string SqlSyncGroupName()
        {
            return this.sqlSyncGroupName;
        }

        ///GENMHASH:975CFB2E2076677C0B3809B900A8B22E:81D4625030F31F3802DFC9934445ECD0
        public string SqlDatabaseName()
        {
            return this.sqlDatabaseName;
        }

        public ISqlSyncMember Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlSyncMember> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlSyncMember Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlSyncMember> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }

        public ISqlSyncMember Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlSyncMember> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }
    }
}