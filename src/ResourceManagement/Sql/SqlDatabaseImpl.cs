// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.SqlDatabaseDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseExportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImportRequest.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.SqlDatabaseOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.Sql.Fluent.SqlSyncGroupOperations.SqlSyncGroupActionsDefinition;

    /// <summary>
    /// Implementation for SqlDatabase and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZUltcGw=
    internal partial class SqlDatabaseImpl  :
        ChildResource<
            Models.DatabaseInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlDatabase,
        ISqlDatabaseDefinition<SqlServer.Definition.IWithCreate>,
        SqlDatabase.Definition.IWithExistingDatabaseAfterElasticPool<SqlServer.Definition.IWithCreate>,
        SqlDatabase.Definition.IWithStorageKeyAfterElasticPool<SqlServer.Definition.IWithCreate>,
        SqlDatabase.Definition.IWithAuthenticationAfterElasticPool<SqlServer.Definition.IWithCreate>,
        IUpdate,
        SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool,
        SqlDatabaseOperations.Definition.IWithStorageKeyAfterElasticPool,
        SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool,
        IWithCreateAfterElasticPoolOptions,
        ISqlDatabaseOperationsDefinition
    {
        internal ISqlManager sqlServerManager;
        internal string resourceGroupName;
        internal string sqlServerName;
        internal string sqlServerLocation;
        private SqlElasticPoolImpl parentSqlElasticPool;
        ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPoolCreatable;
        private bool isPatchUpdate;
        private ImportRequest importRequestInner;
        private IStorageAccount storageAccount;
        private readonly string name;

        private SqlSyncGroupOperationsImpl syncGroupOps;

        string ICreatable<ISqlDatabase>.Name => this.Name();

        string IExternalChildResource<ISqlDatabase, ISqlServer>.Id => this.Id();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:A35E7EC57FEC5C249FB11AEB50216560:C7DB22944BBAB9F9EBF4DC3ECB3D4098
        internal SqlDatabaseImpl(string name, SqlServerImpl parent, DatabaseInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.resourceGroupName = parent.ResourceGroupName;
            this.sqlServerName = parent.Name;
            this.sqlServerLocation = parent.RegionName;

            this.isPatchUpdate = false;
            this.importRequestInner = null;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="sqlServerLocation">The parent SQL server location.</param>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:F958650D21263F491EB84C4B1B980363:F9DB363750091A34604F0E5CF4D066EE
        internal SqlDatabaseImpl(string resourceGroupName, string sqlServerName, string sqlServerLocation, string name, DatabaseInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerLocation = sqlServerLocation;

            this.isPatchUpdate = false;
            this.importRequestInner = null;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:F958650D21263F491EB84C4B1B980363:F9DB363750091A34604F0E5CF4D066EE
        internal SqlDatabaseImpl(string name, DatabaseInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");

            this.isPatchUpdate = false;
            this.importRequestInner = null;
        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:2AEEDA573EC9A50B62216BE3C228E186:9AC714CB5012CC7E3C25F0728F8230EB
        public ISqlSyncGroupActionsDefinition SyncGroups()
        {
            if (this.syncGroupOps == null)
            {
                this.syncGroupOps = new SqlSyncGroupOperationsImpl(this, this.sqlServerManager);
            }
            return this.syncGroupOps;
        }

        ///GENMHASH:A2A1505BCC6291F30BC2E2AC16639B19:5AFDD1B9912D08695516C8D33256ADB0
        public SqlDatabaseImpl WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective)
        {
            return this.WithPremiumEdition(serviceObjective, SqlDatabasePremiumStorage.Max500Gb);
        }

        ///GENMHASH:1B972C3D30942C7A2ABCC1A07A2FEE9C:BDE01F035BE7DAE356DF439B25414644
        public SqlDatabaseImpl WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective, SqlDatabasePremiumStorage maxStorageCapacity)
        {
            this.Inner.Edition = DatabaseEdition.Premium;
            this.WithServiceObjective(ServiceObjectiveName.Parse(serviceObjective.Value));
            this.Inner.MaxSizeBytes = $"{(long)maxStorageCapacity}";
            return this;
        }

        ///GENMHASH:C3E676C1E567606631528A28B60C9771:7EF1FF4D17AF9E55D4E99109A0950D18
        public SqlDatabaseImpl WithEdition(DatabaseEdition edition)
        {
            this.Inner.ElasticPoolName = null;
            this.Inner.RequestedServiceObjectiveId = null;
            this.Inner.Edition = edition;

            return this;
        }

        ///GENMHASH:376C162D9E950FA8A14B198790B45E34:5BF104F4489A5E42BAC27A2492EFC800
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric> ListUsageMetrics()
        {
            return Extensions.Synchronize(() => this.ListUsageMetricsAsync());
        }

        ///GENMHASH:D2C5B9B5EC8B12A40F6CC3A999383810:AA70F16BA24A6FB5F01832A54902603A
        public Guid? CurrentServiceObjectiveId()
        {
            return this.Inner.CurrentServiceObjectiveId;
        }

        ///GENMHASH:7EF1D1197B665941F65A1D87438FFF51:B4F8E60F3A870A52FB2020A6241D9F0F
        public SqlDatabaseImpl WithExistingElasticPool(string elasticPoolName)
        {
            this.Inner.Edition = null;
            this.Inner.RequestedServiceObjectiveId = null;
            this.Inner.RequestedServiceObjectiveName = null;
            this.Inner.ElasticPoolName = elasticPoolName;
            return this;
        }

        ///GENMHASH:3BDABC5AAC07959FD1C78BEA74FD8712:BA30DB47040BBC492DFC164A6C968F85
        public SqlDatabaseImpl WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            if (sqlElasticPool == null)
            {
                throw new ArgumentNullException("sqlElasticPool");
            }
            return this.WithExistingElasticPool(sqlElasticPool.Name);
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:0A35F4FBFC584D98FAACCA25325781E8
        public SqlDatabaseImpl WithTags(IDictionary<string,string> tags)
        {
            this.Inner.Tags = new Dictionary<string,string>(tags);
            return this;
        }

        ///GENMHASH:FCE70A9CD34B8C168EB1F63E6F207D42:BC43C8FF17726D8A07EA586F3B17608B
        public SqlDatabaseImpl WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            if (this.importRequestInner == null)
            {
                this.InitializeImportRequestInner();
            }
            this.importRequestInner.AuthenticationType = AuthenticationType.ADPassword;
            this.importRequestInner.AdministratorLogin = administratorLogin;
            this.importRequestInner.AdministratorLoginPassword = administratorPassword;
            return this;
        }

        ///GENMHASH:B793713C1E6696E957FDFDD58A692C32:6F6FD3F1EE6142188DD9CD51E89E8125
        public ISqlDatabaseAutomaticTuning GetDatabaseAutomaticTuning()
        {
            var databaseAutomaticTuningInner = Extensions.Synchronize(() => this.sqlServerManager.Inner.DatabaseAutomaticTuning
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name()));
            return databaseAutomaticTuningInner != null ? new SqlDatabaseAutomaticTuningImpl(this, databaseAutomaticTuningInner) : null;
        }

        ///GENMHASH:68AE3BBF06B3A5F31F06F3A6A3469188:CF334608A3F1A8CD53872D1D3F94B016
        public string DefaultSecondaryLocation()
        {
            return this.Inner.DefaultSecondaryLocation;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        public IReadOnlyDictionary<string, string> Tags()
        {
            return (Dictionary<string, string>) this.Inner.Tags;
        }

        ///GENMHASH:09F37EE7E8975407273D6FA4FB12441D:5B750DDCC180A5B0F60DE4E3840E3CCB
        public string Collation()
        {
            return this.Inner.Collation;
        }
        
        ///GENMHASH:69A889F45F764B3E541DF980DABD1473:0C2A7DB4ABEFF325916B1EFB94934EC8
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition>> ListMetricDefinitionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> databaseMetricDefinitions = new List<ISqlDatabaseMetricDefinition>();
            var metricDefinitionInners = await this.sqlServerManager.Inner.Databases
                .ListMetricDefinitionsAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (metricDefinitionInners != null)
            {
                foreach (var metricDefinitionInner in metricDefinitionInners)
                {
                    databaseMetricDefinitions.Add(new SqlDatabaseMetricDefinitionImpl(metricDefinitionInner));
                }
            }
            return databaseMetricDefinitions;
        }

        // Future reference when enabling the proper framework which will track dependencies 
        /////GENMHASH:7A9E1ACC5D9B5ED3EF93A2ABFD978F14:1F4B6D4F1D6BA088BF475B965981DC9B
        //internal void AddParentDependency(IHasTaskGroup parentDependency)
        //{
        //    this.AddDependency(parentDependency);
        //}

        ///GENMHASH:FA6C4C8AE7729C6D128F00A0883B7A82:050D474227760B6267EFCEC6085DD2B2
        public DateTime? EarliestRestoreDate()
        {
            return this.Inner.EarliestRestoreDate;
        }

        ///GENMHASH:DF623B844EDAA9403C7ADB3E4D089ADD:1E1FA9AB1DCE4AD9527CF761EC52F4BC
        public ServiceObjectiveName RequestedServiceObjectiveName()
        {
            return this.Inner.RequestedServiceObjectiveName;
        }

        ///GENMHASH:94274C9965DC54702B64A387A19F1F2B:B539D8C79F7F64123BCB4A6F10EDBD92
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks()
        {
            return Extensions.Synchronize(() => this.ListReplicationLinksAsync());
        }

        ///GENMHASH:36003534781597C965476F5DF65AFAE0:5676358725D0EA511E36276932C4EE49
        public SqlDatabaseImpl WithCollation(string collation)
        {
            this.Inner.Collation = collation;

            return this;
        }

        ///GENMHASH:0E666BFDFC9A666CA31FD735D7839414:6A8302C4C1400F1CDCE2686A7C6C8E41
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages()
        {
            // This method was deprecated in favor of the other database metric related methods
            return new List<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric>().AsReadOnly();
        }

        ///GENMHASH:546F275F5C716DBA4B4E3ED283223400:0FDEDB5D39B9E6DEB193A84687780CDA
        public SqlDatabaseImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName, string sqlServerLocation)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerLocation = sqlServerLocation;

            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:1913C8F57081FC6BA71CCA1646434B22
        public SqlDatabaseImpl WithExistingSqlServer(ISqlServer sqlServer)
        {
            if (sqlServer == null)
            {
                throw new ArgumentNullException("sqlServer");
            }
            this.resourceGroupName = sqlServer.ResourceGroupName;
            this.sqlServerName = sqlServer.Name;
            this.sqlServerLocation = sqlServer.RegionName;
            return this;
        }

        ///GENMHASH:B132DF15A736F615C9C36B19E938DF9E:65F2784364791089D5368B99F0100E95
        public SqlDatabaseImpl WithStorageAccessKey(string storageAccessKey)
        {
            if (this.importRequestInner == null)
            {
                this.InitializeImportRequestInner();
            }
            this.importRequestInner.StorageKeyType = StorageKeyType.StorageAccessKey;
            this.importRequestInner.StorageKey = storageAccessKey;
            return this;
        }

        ///GENMHASH:4A64D79C205DE76E07E6A3581CF5E14B:1A9338236EC82827DA9F8F8293BE39FE
        public SqlElasticPoolForDatabaseImpl DefineElasticPool(string elasticPoolName)
        {
            this.parentSqlElasticPool = new SqlElasticPoolImpl(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation, elasticPoolName, new ElasticPoolInner(), this.sqlServerManager);
            this.sqlElasticPoolCreatable = this.parentSqlElasticPool;
            this.Inner.Edition = null;
            this.Inner.RequestedServiceObjectiveId = null;
            this.Inner.RequestedServiceObjectiveName = null;
            this.Inner.ElasticPoolName = elasticPoolName;
            return new SqlElasticPoolForDatabaseImpl(this, this.parentSqlElasticPool);
        }

        ///GENMHASH:37206883074CEB63F8267ADE2545CF11:4C107A9D0C8600BD4F989BA7EE78EE0C
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints()
        {
            return Extensions.Synchronize(() => this.ListRestorePointsAsync());
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime? CreationDate()
        {
            return this.Inner.CreationDate;
        }

        ///GENMHASH:E1492A9309184FBF3CAF8F7F48E93B50:2131053C84548A7E9082276BD7E11BA6
        public SqlDatabaseImpl WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective)
        {
            return this.WithStandardEdition(serviceObjective, SqlDatabaseStandardStorage.Max250Gb);
        }

        ///GENMHASH:49E7BA88A31F5FA05707D7827931435B:83BE97DAEF89A7A6D0C78658DFEFCDE4
        public SqlDatabaseImpl WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective, SqlDatabaseStandardStorage maxStorageCapacity)
        {
            this.Inner.Edition = DatabaseEdition.Standard;
            this.WithServiceObjective(ServiceObjectiveName.Parse(serviceObjective.Value));
            this.Inner.MaxSizeBytes = $"{(long)maxStorageCapacity}";
            return this;
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:E70E0F84833F74462C0831B3C84D4A03
        public SqlDatabaseImpl WithTag(string key, string value)
        {
            if (this.Inner.Tags == null)
            {
                this.Inner.Tags = new Dictionary<string, string>();
            }
            this.Inner.Tags[key] = value;
            return this;
        }

        ///GENMHASH:411E9B7C553E0F8FE64EB33DF4872E6A:A0F10EC124D07E925E3BE6285203F7E0
        public ServiceObjectiveName ServiceLevelObjective()
        {
            return this.Inner.ServiceLevelObjective;
        }

        ///GENMHASH:6440992F4CBC2FF2069B36419334D933:F5264B18EE7543F8EA9233154894DE3C
        private void InitializeImportRequestInner()
        {
            this.importRequestInner = new ImportRequest();
            if (this.ElasticPoolName() != null)
            {
                this.importRequestInner.Edition = DatabaseEdition.Standard;
                this.importRequestInner.ServiceObjectiveName = ServiceObjectiveName.S0;
                this.importRequestInner.MaxSizeBytes = $"{(long)SqlDatabaseStandardStorage.Max250Gb}";
            }
            else
            {
                this.WithStandardEdition(SqlDatabaseStandardServiceObjective.S0);
            }
        }

        ///GENMHASH:7B6933FD706B12808B9D39A178094149:931378847EFB66ED97F43D824F04A3A3
        public ISqlWarehouse AsWarehouse()
        {
            if (this.IsDataWarehouse())
            {
                if (this.Parent != null)
                {
                    return new SqlWarehouseImpl(this.Name(), this.Parent, this.Inner, this.sqlServerManager);
                }
                else
                {
                    return new SqlWarehouseImpl(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation, this.Name(), this.Inner, this.sqlServerManager);
                }
            }
            return null;
        }

        ///GENMHASH:39034E92B8596ED5F36CD108B4CEBBC8:A785C9F7D890C95E8D7E8BE08BA1DB7D
        public SqlDatabaseThreatDetectionPolicyImpl DefineThreatDetectionPolicy(string policyName)
        {
            return new SqlDatabaseThreatDetectionPolicyImpl(policyName, this, new DatabaseSecurityAlertPolicyInner(), this.sqlServerManager);
        }

        ///GENMHASH:F5717DCDC59DCEC39989A49248CA5245:C44735502B6EFAF1B34E5E521F088541
        public SqlDatabaseImpl WithoutElasticPool()
        {
            this.Inner.ElasticPoolName = null;
            this.Inner.RequestedServiceObjectiveId = null;
            this.Inner.RequestedServiceObjectiveName = null;
            return this;
        }

        ///GENMHASH:547C5E4F79BCDF43D68C1D68B8233E56:0417368F07CF88E0DF418E9E5F74D9AE
        public bool IsDataWarehouse()
        {
            return this.Inner.Edition != null ? this.Inner.Edition.Equals(DatabaseEdition.DataWarehouse) : false;
        }

        ///GENMHASH:8380741288B285433B6443AF2F466E6D:A0411F0E7FF3C97800E30DDE842787ED
        public async Task<IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>> ListServiceTierAdvisorsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> serviceTierAdvisors = new Dictionary<string, IServiceTierAdvisor>();
            var serviceTierAdvisorInners = await this.sqlServerManager.Inner.ServiceTierAdvisors
                .ListByDatabaseAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (serviceTierAdvisorInners != null)
            {
                foreach (var serviceTierAdvisorInner in serviceTierAdvisorInners)
                {
                    serviceTierAdvisors.Add(serviceTierAdvisorInner.Name, new ServiceTierAdvisorImpl(this.resourceGroupName, this.sqlServerName, serviceTierAdvisorInner, this.sqlServerManager));
                }
            }
            return serviceTierAdvisors;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:E33B754A9A9CD4E144011EFCD75AA27C
        public Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.RegionName());
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public string Status()
        {
            return this.Inner.Status;
        }

        ///GENMHASH:957BA7B4E61C9B91983ED17E2B61DBD7:9549FCCFE13908133153A6585989F147
        public string ElasticPoolName()
        {
            return this.Inner.ElasticPoolName;
        }

        ///GENMHASH:0D23B35B24D1777140585D16F513A57E:7924D48B71636A56E44F69FD03C4DFA9
        internal SqlDatabaseImpl WithPatchUpdate()
        {
            this.isPatchUpdate = true;
            return this;
        }

        ///GENMHASH:396EF11BF84C5A5AEDE59746D18EF7FA:DFA427061784001F9E768D7BEB7A5E43
        public SqlDatabaseImpl WithServiceObjective(ServiceObjectiveName serviceLevelObjective)
        {
            this.Inner.ElasticPoolName = null;
            this.Inner.RequestedServiceObjectiveId = null;
            this.Inner.RequestedServiceObjectiveName = serviceLevelObjective;
            return this;
        }

        ///GENMHASH:645835BFC7B3F763E704B19D0547F1DE:CD2A5AB12BE2F4D02FD565EE2DEA70FE
        public async Task<IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>> ListReplicationLinksAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> replicationLinks = new Dictionary<string, IReplicationLink>();
            var replicationLinkInners = await this.sqlServerManager.Inner.ReplicationLinks
                .ListByDatabaseAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (replicationLinkInners != null)
            {
                foreach (var replicationLinkInner in replicationLinkInners)
                {
                    replicationLinks.Add(replicationLinkInner.Name, new ReplicationLinkImpl(this.resourceGroupName, this.sqlServerName, replicationLinkInner, this.sqlServerManager));
                }
            }

            return replicationLinks;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return this.Inner.Location;
        }

        ///GENMHASH:F5BFC9500AE4C04846BAAD2CC50792B3:DA87C4AB3EEB9D4BA746DF610E8BC39F
        public DatabaseEdition Edition()
        {
            return this.Inner.Edition;
        }

        ///GENMHASH:1A8677F2439B3D7CABE292785BD60427:5F04DB72C29FE210E63C4F7C53799BA7
        public SqlDatabaseImpl ImportFrom(string storageUri)
        {
            this.InitializeImportRequestInner();
            this.importRequestInner.StorageUri = storageUri;
            return this;
        }

        ///GENMHASH:7373E32C16A40BA46FE99D3C43267A6D:51DAE7A41E58631741DFE52C7C67E106
        public SqlDatabaseImpl ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            if (storageAccount == null)
            {
                throw new ArgumentNullException("storageAccount");
            }
            if (containerName == null)
            {
                throw new ArgumentNullException("containerName");
            }
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            this.InitializeImportRequestInner();
            this.storageAccount = storageAccount;
            this.importRequestInner.StorageUri = $"{containerName}/{fileName}";
            return this;
        }

        ///GENMHASH:C8BF6EB45120AB5638A39B9E6F246F48:88685B211625AC25043E56EF15C881D0
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption> GetTransparentDataEncryptionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var transparentDataEncryptionInner = await this.sqlServerManager.Inner.TransparentDataEncryptions
                    .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
                return transparentDataEncryptionInner != null ? new TransparentDataEncryptionImpl(this.resourceGroupName, this.sqlServerName, transparentDataEncryptionInner, this.sqlServerManager) : null;
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

        ///GENMHASH:B23645FC2F779DBC6F44B880C488B561:EEF0AD33D842F97FF9BE1E629E1C03EE
        public SqlDatabaseImpl WithMaxSizeBytes(long maxSizeBytes)
        {
            this.Inner.MaxSizeBytes = $"{maxSizeBytes}";
            return this;
        }

        ///GENMHASH:A26C8D278B6519B28BA17D3966024017:A4AA33E1BB3D9FE5155733094177C7C2
        public long MaxSizeBytes()
        {
            return Convert.ToInt64(this.Inner.MaxSizeBytes ?? "0");
        }

        ///GENMHASH:A1DBAE6CBFB56230E32A4169F4FC18B2:75E99B1B89E418875225D1E0E9BECAAE
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> ListMetrics(string filter)
        {
            return Extensions.Synchronize(() => this.ListMetricsAsync(filter));
        }

        ///GENMHASH:FB41F80AEFA7E12022C9196F41BF8921:ED8B3A06AA34CEDC5610A3DEF09E3EEE
        public SqlDatabaseImpl WithBasicEdition()
        {
            return this.WithBasicEdition(SqlDatabaseBasicStorage.Max2Gb);
        }

        ///GENMHASH:F7B4B7D42B00968BBE7591CAAB07FB08:D7C7D124B191508D782E83C2EA9D3650
        public SqlDatabaseImpl WithBasicEdition(SqlDatabaseBasicStorage maxStorageCapacity)
        {
            this.Inner.Edition = DatabaseEdition.Basic;
            this.WithServiceObjective(ServiceObjectiveName.Basic);
            this.WithMaxSizeBytes((long)maxStorageCapacity);
            return this;
        }

        ///GENMHASH:E79C534DFF1FD292BF3629BFBDD6B6B9:96B4434F4DABBF823E846088675F0311
        public SqlDatabaseImportRequestImpl ImportBacpac(string storageUri)
        {
            if (storageUri == null)
            {
                throw new ArgumentNullException("storageUri");
            }
            return new SqlDatabaseImportRequestImpl(this, this.sqlServerManager)
                .ImportFrom(storageUri);
        }

        ///GENMHASH:E67F1FD4894329ACCDFF54905A1E694E:7EE85AF9D02D1E0432372E41F59DAC1E
        public SqlDatabaseImportRequestImpl ImportBacpac(IStorageAccount storageAccount, string containerName, string fileName)
        {
            if (storageAccount == null)
            {
                throw new ArgumentNullException("storageAccount");
            }
            if (containerName == null)
            {
                throw new ArgumentNullException("containerName");
            }
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            return new SqlDatabaseImportRequestImpl(this, this.sqlServerManager)
                .ImportFrom(storageAccount, containerName, fileName);
        }

        ///GENMHASH:D07614EC964723EC7E563278F8FD0BE6:9903ECC9F8F5837D63A44DAA11F79C8E
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric>> ListUsageMetricsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseUsageMetric> usageMetricList = new List<ISqlDatabaseUsageMetric>();
            var databaseUsageInners = await this.sqlServerManager.Inner.DatabaseUsages
                .ListByDatabaseAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (databaseUsageInners != null)
            {
                foreach (var databaseUsageInner in databaseUsageInners)
                {
                    usageMetricList.Add(new SqlDatabaseUsageMetricImpl(databaseUsageInner));
                }
            }
            return usageMetricList.AsReadOnly();
        }

        ///GENMHASH:41180B8AE28244EF8581E555D8B35D2B:59963B0DFB54839D345581B895AFA980
        public string DatabaseId()
        {
            return this.Inner.DatabaseId.ToString();
        }

        ///GENMHASH:498D3951D3EB5A31E765F1E9A24A877E:6992EC71A319B4CAEF905C374DF6F78C
        public SqlDatabaseImpl WithSharedAccessKey(string sharedAccessKey)
        {
            if (this.importRequestInner == null)
            {
                this.InitializeImportRequestInner();
            }
            this.importRequestInner.StorageKeyType = StorageKeyType.SharedAccessKey;
            this.importRequestInner.StorageKey = sharedAccessKey;
            return this;
        }

        ///GENMHASH:CA0DDA4D9821F262B350AF8BD2FD3D72:90A235C564BCEA582EA7E8E169017608
        public ISqlDatabaseThreatDetectionPolicy GetThreatDetectionPolicy()
        {
            try
            {
                var policyInner = Extensions.Synchronize(() => this.sqlServerManager.Inner.DatabaseThreatDetectionPolicies
                   .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name()));
                return policyInner != null ? new SqlDatabaseThreatDetectionPolicyImpl(policyInner.Name, this, policyInner, this.sqlServerManager) : null;
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

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:A521981B274EF2B3D621C0705EFAA811:5E9BEFBB11C2769CA5132E0CF9CCABB2
        public SqlDatabaseImpl WithMode(CreateMode createMode)
        {
            this.Inner.CreateMode = createMode;
            return this;
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:250EC2907300FFA6125F7205F03A3E7F
        public SqlDatabaseImpl WithoutTag(string key)
        {
            this.Inner.Tags.Remove(key);
            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:E181EA037CDEB6D9DCE12CA92D1526C7:0D2A486B784948E9672C737F8A7624D2
        public SqlDatabaseImpl FromSample(SampleName sampleName)
        {
            this.Inner.SampleName = SampleName.Parse(sampleName.Value);
            return this;
        }

        ///GENMHASH:F558A35AAC7463E4988A0A5E052953DD:BFCA5ABF1F9698290D6F011B01A4BC1F
        public ITransparentDataEncryption GetTransparentDataEncryption()
        {
            return Extensions.Synchronize(() => this.GetTransparentDataEncryptionAsync());
        }

        ///GENMHASH:86135EF83A124C4DC11F0F4D3932D96D:D2635043C832D0ED57B4C7331890CFBC
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric>> ListMetricsAsync(string filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> dbMetrics = new List<ISqlDatabaseMetric>();
            var metricInners = await this.sqlServerManager.Inner.Databases
                .ListMetricsAsync(this.resourceGroupName, this.sqlServerName, this.Name(), filter, cancellationToken);
            if (metricInners != null)
            {
                foreach (var metricInner in metricInners)
                {
                    dbMetrics.Add(new SqlDatabaseMetricImpl(metricInner));
                }
            }
            return dbMetrics.AsReadOnly();
        }

        ///GENMHASH:495111B1D55D7AA3C4EA4E49042FA05A:018B4F53394EF9D955345603E5AF968D
        public SqlDatabaseImpl WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool)
        {
            if (sqlElasticPool == null)
            {
                throw new ArgumentNullException("sqlElasticPool");
            }
            this.sqlElasticPoolCreatable = sqlElasticPool;
            this.parentSqlElasticPool = (SqlElasticPoolImpl)sqlElasticPool;
            this.Inner.Edition = null;
            this.Inner.RequestedServiceObjectiveId = null;
            this.Inner.RequestedServiceObjectiveName = null;
            this.Inner.ElasticPoolName = parentSqlElasticPool.Name();

            // Future dependency tracking note
            // this.AddDependency(sqlElasticPool);

            return this;
        }

        ///GENMHASH:F5DF37BD82C1C590C56B4F013C07DABC:8C97E5D1BC323EC4701C62A50021CBF3
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> ListMetricDefinitions()
        {
            return Extensions.Synchronize(() => this.ListMetricDefinitionsAsync());
        }

        ///GENMHASH:E5ABDAE624DDFF518B3732327DAE080E:4F48A6821129951A21572526EC7AD923
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> RenameAsync(string newDatabaseName, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(this.Id());
            String newId = $"{resourceId.Parent.Id}/databases/{newDatabaseName}";
            await this.sqlServerManager.Inner.Databases
                .RenameAsync(this.resourceGroupName, this.sqlServerName, this.Name(), newId, cancellationToken);
            return await this.sqlServerManager.SqlServers.Databases
                .GetBySqlServerAsync(this.resourceGroupName, this.sqlServerName, newDatabaseName, cancellationToken);
        }

        ///GENMHASH:85FBE37563F3ADEA0037149593562508:FFD4FFA925AA8688B4B8288DE2CD55F3
        public SqlDatabaseImpl FromRestorableDroppedDatabase(ISqlRestorableDroppedDatabase restorableDroppedDatabase)
        {
            if (restorableDroppedDatabase == null)
            {
                throw new ArgumentNullException("restorableDroppedDatabase");
            }
            return this.WithSourceDatabase(restorableDroppedDatabase.Id)
                .WithMode(CreateMode.Restore);
        }

        ///GENMHASH:F6C12109AEE137840B60E059E6708A02:3802C120362CEFDF42D356C4A1BB4C0B
        public SqlDatabaseImpl FromRestorePoint(IRestorePoint restorePoint)
        {
            if (restorePoint == null)
            {
                throw new ArgumentNullException("restorePoint");
            }
            this.Inner.RestorePointInTime = restorePoint.EarliestRestoreDate;
            return this.WithSourceDatabase(restorePoint.DatabaseId)
                .WithMode(CreateMode.PointInTimeRestore);
        }

        ///GENMHASH:65DFD5CF3EED2BB07512CC188E7D8F8A:668E0DBB00202029F024E9733E6C0BD2
        public SqlDatabaseImpl FromRestorePoint(IRestorePoint restorePoint, DateTime restorePointDateTime)
        {
            this.Inner.RestorePointInTime = restorePointDateTime;
            return this.WithSourceDatabase(restorePoint.DatabaseId)
                .WithMode(CreateMode.PointInTimeRestore);
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:BF44555315B4D8F7DE5B31B09438FA0A
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:75380AC1C8F8C473AF028534126AA5D4:25C18B002519A132E6FD1BDD0AAEAC82
        public ISqlDatabase Rename(string newDatabaseName)
        {
            return Extensions.Synchronize(() => this.RenameAsync(newDatabaseName));
        }

        ///GENMHASH:7E720FDC940A2922809B9D27EFCACBCD:47BE206E881D06DAD00CE167DAE60229
        public SqlDatabaseImpl WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            if (this.importRequestInner == null)
            {
                this.InitializeImportRequestInner();
            }
            this.importRequestInner.AuthenticationType = AuthenticationType.SQL;
            this.importRequestInner.AdministratorLogin = administratorLogin;
            this.importRequestInner.AdministratorLoginPassword = administratorPassword;
            return this;
        }

        ///GENMHASH:212A2F2F92E2D462C22479742BC730A3:A93678FA285496CB5F325AF4DC1B281C
        public SqlDatabaseExportRequestImpl ExportTo(string storageUri)
        {
            return new SqlDatabaseExportRequestImpl(this, this.sqlServerManager)
                .ExportTo(storageUri);
        }

        ///GENMHASH:86E7BAA14B4627C99B23DD5E99D3E137:E50A2EC6A3EE3A525FA469BD438C0871
        public SqlDatabaseExportRequestImpl ExportTo(IStorageAccount storageAccount, string containerName, string fileName)
        {
            if (storageAccount == null)
            {
                throw new ArgumentNullException("storageAccount");
            }
            if (containerName == null)
            {
                throw new ArgumentNullException("containerName");
            }
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            return new SqlDatabaseExportRequestImpl(this, this.sqlServerManager)
                .ExportTo(storageAccount, containerName, fileName);
        }

        ///GENMHASH:1F5324043331585B2120A5C89F84F5DB:C885DEE02CF75EE1A4A387AAA0D8A760
        public SqlDatabaseExportRequestImpl ExportTo(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName, string fileName)
        {
            if (storageAccountCreatable == null)
            {
                throw new ArgumentNullException("storageAccountCreatable");
            }
            if (containerName == null)
            {
                throw new ArgumentNullException("containerName");
            }
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            return new SqlDatabaseExportRequestImpl(this, this.sqlServerManager)
                .ExportTo(storageAccountCreatable, containerName, fileName);
        }

        ///GENMHASH:B1D3E971A2C4574ED03F74E5745E8301:B5D8E6907D7456C71BFBDDD84D4CAF3D
        public Guid? RequestedServiceObjectiveId()
        {
            return this.Inner.RequestedServiceObjectiveId;
        }

        ///GENMHASH:EB950732E887990C7D61B74EBA2E3E50:573BDC9A38C91E0EA3771EF31E937127
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint>> ListRestorePointsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> restorePoints = new List<IRestorePoint>();
            var restorePointInners = await this.sqlServerManager.Inner.RestorePoints
                .ListByDatabaseAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (restorePointInners != null)
            {
                foreach (var restorePointInner in restorePointInners)
                {
                    restorePoints.Add(new RestorePointImpl(this.resourceGroupName, this.sqlServerName, restorePointInner));
                }
            }
            return restorePoints.AsReadOnly();
        }

        ///GENMHASH:F8954D151717AC497C4A3B76321952A6:5BEB5EA8B9F53B7F9AA00D61AB0B2853
        public SqlDatabaseImpl WithSourceDatabase(string sourceDatabaseId)
        {
            this.Inner.SourceDatabaseId = sourceDatabaseId;
            return this;
        }

        ///GENMHASH:642F972C91F9E70B14E53881C1FCA8F9:F069850B2BE457D02CB713E8708DE59C
        public SqlDatabaseImpl WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            if (sourceDatabase == null)
            {
                throw new ArgumentNullException("sourcedatabase");
            }
            return this.WithSourceDatabase(sourceDatabase.Id);
        }

        ///GENMHASH:6F25566A2BEBF8E935396FF70D7412F6:CFB98BD6B2251258A7E6ED7109B50D5A
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> ListServiceTierAdvisors()
        {
            return Extensions.Synchronize(() => this.ListServiceTierAdvisorsAsync());
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AA78F52D96EC68C22A95FE39F9EB7071
        protected async Task<Models.DatabaseInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.Databases.GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken: cancellationToken);
        }

        ///GENMHASH:9557699E7EE892CCCC89A074E0915333:A55D3CBCED3C2D7241CB8E96C4D3F217
        public async Task BeforeGroupCreateOrUpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.importRequestInner != null && this.storageAccount != null)
            {
                var storageKeys = await storageAccount.GetKeysAsync(cancellationToken);
                if (storageKeys == null || storageKeys.Count == 0)
                {
                    throw new Exception("Failed to retrieve Storage Account Keys");
                }
                var storageAccountKey = storageKeys[0].Value;
                this.importRequestInner.StorageUri = $"{this.storageAccount?.EndPoints?.Primary?.Blob}{this.importRequestInner.StorageUri}";
                this.importRequestInner.StorageKeyType = StorageKeyType.StorageAccessKey;
                this.importRequestInner.StorageKey = storageAccountKey;
            }

            if (this.sqlElasticPoolCreatable != null)
            {
                this.parentSqlElasticPool = (SqlElasticPoolImpl)await this.sqlElasticPoolCreatable.CreateAsync(cancellationToken);
            }
            else if (this.Inner.ElasticPoolName != null && this.importRequestInner != null)
            {
                this.parentSqlElasticPool = (SqlElasticPoolImpl) await this.sqlServerManager.SqlServers.ElasticPools
                    .GetBySqlServerAsync(this.resourceGroupName, this.sqlServerName, this.Inner.ElasticPoolName, cancellationToken);
            }
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:4E95DB8FD4DE0A3758B25CB7991A2C2A
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await BeforeGroupCreateOrUpdateAsync(cancellationToken);
            this.Inner.Location = this.sqlServerLocation;
            if (this.importRequestInner != null)
            {
                this.importRequestInner.DatabaseName = this.Name();
                if (this.importRequestInner.Edition == null)
                {
                    this.importRequestInner.Edition = this.Inner.Edition;
                }
                if (this.importRequestInner.ServiceObjectiveName == null)
                {
                    this.importRequestInner.ServiceObjectiveName = this.Inner.RequestedServiceObjectiveName;
                }
                if (this.importRequestInner.MaxSizeBytes == null)
                {
                    this.importRequestInner.MaxSizeBytes = this.Inner.MaxSizeBytes;
                }
                var dbInner = this.sqlServerManager.Inner.Databases
                    .ImportAsync(this.resourceGroupName, this.sqlServerName, this.importRequestInner, cancellationToken);
                if (this.Inner.ElasticPoolName == null)
                {
                    return await this.RefreshAsync(cancellationToken);
                }
                return this;
            }
            else
            {
                var dbInner = await this.sqlServerManager.Inner.Databases
                    .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), this.Inner, cancellationToken);
                this.SetInner(dbInner);
                return this;
            }
            await AfterPostRunAsync(cancellationToken);
        }

        ///GENMHASH:AC7CC07C6D6A5043B63254841EEBA63A:7F7F8CAB431C433CEC91CF27F54FEFFD
        public async Task AfterPostRunAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.importRequestInner != null && this.parentSqlElasticPool != null)
            {
                this.isPatchUpdate = true;
                await this.UpdateResourceAsync(cancellationToken);
            }
            this.isPatchUpdate = false;
            this.importRequestInner = null;
            this.storageAccount = null;
            this.sqlElasticPoolCreatable = null;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:6BCBA570417EAC0D10DCE422CAB270A5
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.isPatchUpdate)
            {
                DatabaseUpdateInner databaseUpdateInner = new DatabaseUpdateInner()
                {
                    Tags = this.Inner.Tags,
                    Collation = this.Inner.Collation,
                    SourceDatabaseId = this.Inner.SourceDatabaseId,
                    CreateMode = this.Inner.CreateMode,
                    Edition = this.Inner.Edition,
                    RequestedServiceObjectiveName = this.Inner.RequestedServiceObjectiveName,
                    MaxSizeBytes = this.Inner.MaxSizeBytes,
                    ElasticPoolName = this.Inner.ElasticPoolName,
                    Location = this.sqlServerLocation
                };
                await this.sqlServerManager.Inner.Databases.UpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), databaseUpdateInner, cancellationToken);
                await this.RefreshAsync(cancellationToken);
                return this;
            }
            else
            {
                return await this.CreateResourceAsync(cancellationToken);
            }
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:8FF06E289719BB519BDB4F57C1488F6F
        public SqlServerImpl Attach()
        {
            return Parent;
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:B8443F1744F97B6579E4964E67592EFB
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:774D147C034A0076F237A117323E70D7
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.Databases
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:ECB4548536225101A4FBA7DFDB22FE6D
        public SqlDatabaseImpl Update()
        {
            // Future reference when enabling the proper framework which will track dependencies 
            // This is the beginning of the update flow
            // super.PrepareUpdate();
            return this;
        }

        public ISqlDatabase Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlDatabase> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }

        public ISqlDatabase Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlDatabase> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        public ISqlDatabase Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlDatabase> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }
    }
}