// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroup.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncMemberOperations.SqlSyncMemberActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for SqlSyncGroup.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTeW5jR3JvdXBJbXBs
    internal partial class SqlSyncGroupImpl :
        ChildResource<
            Models.SyncGroupInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        ISqlSyncGroup,
        IUpdate,
        ISqlSyncGroupOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private string sqlDatabaseName;
        private ISqlSyncMemberActionsDefinition syncMemberOps;
        private string name;

        string ICreatable<ISqlSyncGroup>.Name => this.Name();

        string IExternalChildResource<ISqlSyncGroup, ISqlDatabase>.Id => this.Id();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:1B84E5430DBD759F48B80D4C7F8781CC:63DD15F38F429D8D42EAECC53ABE710A
        internal SqlSyncGroupImpl(string name, SqlDatabaseImpl parent, SyncGroupInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName();
            this.sqlServerName = parent.SqlServerName();
            this.sqlDatabaseName = parent.Name();
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="sqlDatabaseName">The parent SQL Database name.</param>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:93B2CDB9BD4EC90C1E3E6788282EF80D:46ED0A0EFDCFB4A8C02A54C6267EEAB9
        internal SqlSyncGroupImpl(string resourceGroupName, string sqlServerName, string sqlDatabaseName, string name, SyncGroupInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlDatabaseName = sqlDatabaseName;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:2593A87C1076A6D668BDFE33052F341C:E7C65DE6BF45CF0BA29C2A32A669F3CF
        internal SqlSyncGroupImpl(string name, SyncGroupInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            if (innerObject?.Id != null)
            {
                ResourceId resourceId = ResourceId.FromString(innerObject.Id);
                this.resourceGroupName = resourceId?.ResourceGroupName;
                this.sqlServerName = resourceId?.Parent?.Parent?.Name;
                this.sqlDatabaseName = resourceId?.Parent?.Name;
                this.name = resourceId.Name;
            }
        }

        public override string Name()
        {
            return this.name != null ? this.name : this.Inner?.Name;
        }

        ///GENMHASH:4A9B469E8AC69CFBE633A2CDDBBFF0B6:2C58C44E68EFE99239099F6627E0B617
        public SyncGroupSchema Schema()
        {
            return this.Inner.Schema;
        }

        ///GENMHASH:934AF6E9DF38A2FD2509546B20DD4408:330BF56BBF2BD403AE2CC42709DED28D
        public DateTime? LastSyncTime()
        {
            return this.Inner.LastSyncTime;
        }

        ///GENMHASH:B79D508F0CE2784F617BD91DC5C7AB33:6DF46AD25F6065736A7C1CD8E452BCD8
        public SqlSyncGroupImpl WithSyncDatabaseId(string syncDatabaseId)
        {
            this.Inner.SyncDatabaseId = syncDatabaseId;
            return this;
        }

        ///GENMHASH:691A3310F6A70FA4B372698CC1C9AFAD:FBEC208534C694781C05FF5675FEAC7C
        public ISqlSyncMemberActionsDefinition SyncMembers()
        {
            if (this.syncMemberOps == null)
            {
                this.syncMemberOps = new SqlSyncMemberOperationsImpl(this, this.sqlServerManager);
            }
            return this.syncMemberOps;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:3322885CA35DEA7D7DD9EDDD0C44CF4C
        public IUpdate Update()
        {
            return this;
        }

        ///GENMHASH:D917033A76A6F8C9C699B9C317AE8783:3B49D6AEF0B3B5F681FBACE5301592E6
        public async Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty>> ListLogsAsync(string startTime, string endTime, Models.Type type, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlSyncGroupLogProperty> syncGroupLogProperties = new List<ISqlSyncGroupLogProperty>();
            var syncGroupLogPropertiesInners = await this.sqlServerManager.Inner.SyncGroups
                .ListLogsAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), startTime, endTime, type, cancellationToken:cancellationToken);
            if (syncGroupLogPropertiesInners != null)
            {
                foreach (var syncGroupLogPropertiesInner in syncGroupLogPropertiesInners)
                {
                    syncGroupLogProperties.Add(new SqlSyncGroupLogPropertyImpl(syncGroupLogPropertiesInner));
                }
            }
            return syncGroupLogProperties.AsReadOnly();
        }

        ///GENMHASH:C842205CEEB1B7840FA37E184CA45707:B5B203221698B5E13EC510A3D1B834EC
        public SqlSyncGroupImpl WithSchema(SyncGroupSchema schema)
        {
            this.Inner.Schema = schema;
            return this;
        }

        ///GENMHASH:713ABD12F3B57295638CA2A087364DEF:99F15626364EDC7EB6EE2C010E6FFDD0
        public Models.SyncConflictResolutionPolicy ConflictResolutionPolicy()
        {
            return this.Inner.ConflictResolutionPolicy;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:5B7B8614011A187532AB15035EAEC8A9
        protected async Task<Models.SyncGroupInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.SyncGroups
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), cancellationToken);
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:9B397C5C375300B1CA52BC6BED945424
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:87FD3E99199742259A641022D79363E3:32AB1B56A4D14AB82237D2F6A98D286B
        public string DatabaseUserName()
        {
            return this.Inner.HubDatabaseUserName;
        }

        ///GENMHASH:8414FE72599249183B9C969B46AE2CDA:11C8814437754CFE63567E4BB352C26F
        public SqlSyncGroupImpl WithExistingDatabaseName(string databaseName)
        {
            this.sqlDatabaseName = databaseName;
            return this;
        }

        ///GENMHASH:EB5E854F04C680C3B25636C636BFBCF1:D7FEA359228E78B9AFD189F4BD46C028
        public void CancelSynchronization()
        {
            Extensions.Synchronize(() => this.CancelSynchronizationAsync());
        }

        ///GENMHASH:1C2712CAC29D68767E649695EEE41D80:1FAF8A2C20129E22A81E69C0A5019C62
        public SqlSyncGroupImpl WithConflictResolutionPolicyMemberWins()
        {
            this.Inner.ConflictResolutionPolicy = SyncConflictResolutionPolicy.MemberWin;
            return this;
        }

        ///GENMHASH:09606982B270FE7A7E87AD9150617B8A:6E2F4E36C342F6406D207BC5B6532C8B
        public SqlSyncGroupImpl WithDatabasePassword(string password)
        {
            this.Inner.HubDatabasePassword = password;
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:A65B90C88E8128DB63BF1A01B0E16F04:36953C172383FDC30638D774F43DBB19
        public async Task<IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty>> ListHubSchemasAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<ISqlSyncFullSchemaProperty> syncFullSchemaProperties = new List<ISqlSyncFullSchemaProperty>();
            var syncFullSchemaPropertiesInners = await this.sqlServerManager.Inner.SyncGroups
                .ListHubSchemasAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), cancellationToken: cancellationToken);
            if (syncFullSchemaPropertiesInners != null)
            {
                foreach (var syncFullSchemaPropertiesInner in syncFullSchemaPropertiesInners)
                {
                    syncFullSchemaProperties.Add(new SqlSyncFullSchemaPropertyImpl(syncFullSchemaPropertiesInner));
                }
            }
            return syncFullSchemaProperties.AsReadOnly();
        }

        ///GENMHASH:31B4643F5F463F208B884A3A5CC24E72:FCD5CB554CA014F6FEB6B98FC5423481
        public IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroupLogProperty> ListLogs(string startTime, string endTime, Models.Type type)
        {
            return Extensions.Synchronize(() => this.ListLogsAsync(startTime, endTime, type));
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:4C4C4336C86119672D7AD1E0D4BD29CB
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:F11898DB963C110C7C2F7915997C0F78
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncGroup> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var syncGroupInner = await this.sqlServerManager.Inner.SyncGroups
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), this.Inner, cancellationToken);
            this.SetInner(syncGroupInner);
            return this;
        }

        ///GENMHASH:F5DF463BFB600D75CFA79414D2FC98DE:332A6CC6D0AF92381CE6F733EE2F3CA8
        public async Task TriggerSynchronizationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.SyncGroups
                .TriggerSyncAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), cancellationToken);
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:F4B650283C5C9500CA6B44A28C955015:56002A1A0283C06012B616195740E70B
        public string SyncDatabaseId()
        {
            return this.Inner.SyncDatabaseId;
        }

        ///GENMHASH:E4273E03082A26302980B58DD0C5A684:530AA180606C95FC6F78E17BB72D8E06
        public SqlSyncGroupImpl WithInterval(int interval)
        {
            this.Inner.Interval = interval;
            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:0BA2C0DAE27266D79653208FF06A9B80:99EDD7AD8CCAED9BC095807A7E85DE17
        public SqlSyncGroupImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            return this;
        }

        ///GENMHASH:74CC786A12BD16E99274FDA4312C231B:8CBE6D07DEC2431D8F827589DF59CAAD
        public Models.SyncGroupState SyncState()
        {
            return this.Inner.SyncState;
        }

        ///GENMHASH:FF806DC146C0EFDED16019E747383C54:FA7DFC0883EEEA36FC422EA1F4E41203
        public IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISqlSyncFullSchemaProperty> ListHubSchemas()
        {
            return Extensions.Synchronize(() => this.ListHubSchemasAsync());
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:A9EFCAEAE324F591C1A7C0D35031618E:5E6E8D634B1216CFBCD513C4E7991980
        public async Task RefreshHubSchemaAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.SyncGroups
                .RefreshHubSchemaAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), cancellationToken);
        }

        ///GENMHASH:1B4F57885724814055710D3A2508E281:44A7781CC434A4FF0962FCEE21E3451B
        public SqlSyncGroupImpl WithDatabaseUserName(string userName)
        {
            this.Inner.HubDatabaseUserName = userName;
            return this;
        }

        ///GENMHASH:E27FF56BE6087C2995B3750D57DF922E:A6DB664201785B3A134ED16B070CE73F
        public SqlSyncGroupImpl WithExistingSqlDatabase(ISqlDatabase sqlDatabase)
        {
            this.resourceGroupName = sqlDatabase.ResourceGroupName;
            this.sqlServerName = sqlDatabase.SqlServerName;
            this.sqlDatabaseName = sqlDatabase.Name;
            return this;
        }

        ///GENMHASH:61BB66C84794C2D99CB5E4B7E4D928DD:F878ECBAEA6B57D222B1502D8176179C
        public void RefreshHubSchema()
        {
            Extensions.Synchronize(() => this.RefreshHubSchemaAsync());
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:2DC6B3BEB4C8A428A0339820143BFEB3
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:0BD27749B738152A07CC90C69E2C67EB:0982D9CB434F550FF89770F2FFA23003
        public SqlSyncGroupImpl WithConflictResolutionPolicyHubWins()
        {
            this.Inner.ConflictResolutionPolicy = SyncConflictResolutionPolicy.HubWin;
            return this;
        }

        ///GENMHASH:FEF385199472BEFD992CA38A76841CC1:8FB2844CD47A5D069501E5C2E9F28038
        public void TriggerSynchronization()
        {
            Extensions.Synchronize(() => this.TriggerSynchronizationAsync());
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:CBBF27B5244BF3EE06B3234118D62FAC
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.SyncGroups
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), cancellationToken);
        }

        ///GENMHASH:7B4E91C7245DC969553F3F08B7869BCA:AE45972958C95CA7CB516F025E503393
        public int Interval()
        {
            return this.Inner.Interval.GetValueOrDefault(0);
        }

        ///GENMHASH:975CFB2E2076677C0B3809B900A8B22E:81D4625030F31F3802DFC9934445ECD0
        public string SqlDatabaseName()
        {
            return this.sqlDatabaseName;
        }

        ///GENMHASH:FA16CE37DE1A4C3C3862211F242DA2D0:E99C24C698D03BAB4501757E7B071341
        public async Task CancelSynchronizationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.SyncGroups
                .CancelSyncAsync(this.resourceGroupName, this.sqlServerName, this.sqlDatabaseName, this.Name(), cancellationToken);
        }

        public ISqlSyncGroup Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlSyncGroup> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlSyncGroup Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlSyncGroup> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }

        public ISqlSyncGroup Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlSyncGroup> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }
    }
}