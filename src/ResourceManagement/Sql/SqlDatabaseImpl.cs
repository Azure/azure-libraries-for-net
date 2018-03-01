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
    using System.Threading;
    using System.Threading.Tasks;

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
        SqlDatabase.Definition.IWithRestorePointDatabaseAfterElasticPool<SqlServer.Definition.IWithCreate>,
        IUpdate,
        SqlDatabaseOperations.Definition.IWithExistingDatabaseAfterElasticPool,
        SqlDatabaseOperations.Definition.IWithStorageKeyAfterElasticPool,
        SqlDatabaseOperations.Definition.IWithAuthenticationAfterElasticPool,
        SqlDatabaseOperations.Definition.IWithRestorePointDatabaseAfterElasticPool,
        IWithCreateAfterElasticPoolOptions,
        ISqlDatabaseOperationsDefinition
    {
        protected ISqlManager sqlServerManager;
        protected string resourceGroupName;
        protected string sqlServerName;
        protected string sqlServerLocation;
        private bool isPatchUpdate;
        private ImportRequestInner importRequestInner;
        private readonly string name;

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
            //$ super(name, parent, innerObject);
            //$ 
            //$ Objects.RequireNonNull(parent);
            //$ Objects.RequireNonNull(sqlServerManager);
            //$ this.sqlServerManager = sqlServerManager;
            //$ this.resourceGroupName = parent.ResourceGroupName();
            //$ this.sqlServerName = parent.Name();
            //$ this.sqlServerLocation = parent.RegionName();
            //$ 
            //$ this.sqlElasticPools = null;
            //$ this.parentSqlElasticPool = null;
            //$ this.isPatchUpdate = false;
            //$ this.importRequestInner = null;
            //$ }

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
            //$ super(name, null, innerObject);
            //$ Objects.RequireNonNull(sqlServerManager);
            //$ this.sqlServerManager = sqlServerManager;
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.sqlServerName = sqlServerName;
            //$ this.sqlServerLocation = sqlServerLocation;
            //$ 
            //$ this.sqlElasticPools = new SqlElasticPoolsAsExternalChildResourcesImpl(this.sqlServerManager, "SqlElasticPool");
            //$ this.parentSqlElasticPool = null;
            //$ this.isPatchUpdate = false;
            //$ this.importRequestInner = null;
            //$ }

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
            //$ super(name, null, innerObject);
            //$ Objects.RequireNonNull(sqlServerManager);
            //$ this.sqlServerManager = sqlServerManager;
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.sqlServerName = sqlServerName;
            //$ this.sqlServerLocation = sqlServerLocation;
            //$ 
            //$ this.sqlElasticPools = new SqlElasticPoolsAsExternalChildResourcesImpl(this.sqlServerManager, "SqlElasticPool");
            //$ this.parentSqlElasticPool = null;
            //$ this.isPatchUpdate = false;
            //$ this.importRequestInner = null;
            //$ }

        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:A2A1505BCC6291F30BC2E2AC16639B19:5AFDD1B9912D08695516C8D33256ADB0
        public SqlDatabaseImpl WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective)
        {
            //$ return this.WithPremiumEdition(serviceObjective, SqlDatabasePremiumStorage.MAX_500_GB);

            return this;
        }

        ///GENMHASH:1B972C3D30942C7A2ABCC1A07A2FEE9C:BDE01F035BE7DAE356DF439B25414644
        public SqlDatabaseImpl WithPremiumEdition(SqlDatabasePremiumServiceObjective serviceObjective, SqlDatabasePremiumStorage maxStorageCapacity)
        {
            //$ this.Inner.WithEdition(DatabaseEditions.PREMIUM);
            //$ this.WithServiceObjective(ServiceObjectiveName.FromString(serviceObjective.ToString()));
            //$ this.Inner.WithMaxSizeBytes(Long.ToString(maxStorageCapacity.Capacity()));
            //$ return this;

            return this;
        }

        ///GENMHASH:C3E676C1E567606631528A28B60C9771:7EF1FF4D17AF9E55D4E99109A0950D18
        public SqlDatabaseImpl WithEdition(string edition)
        {
            //$ this.Inner.WithElasticPoolName(null);
            //$ this.Inner.WithRequestedServiceObjectiveId(null);
            //$ this.Inner.WithEdition(edition);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:D2C5B9B5EC8B12A40F6CC3A999383810:AA70F16BA24A6FB5F01832A54902603A
        public Guid CurrentServiceObjectiveId()
        {
            //$ return this.Inner.CurrentServiceObjectiveId();

            return Guid.NewGuid();
        }

        ///GENMHASH:7EF1D1197B665941F65A1D87438FFF51:B4F8E60F3A870A52FB2020A6241D9F0F
        public SqlDatabaseImpl WithExistingElasticPool(string elasticPoolName)
        {
            //$ this.Inner.WithEdition(null);
            //$ this.Inner.WithRequestedServiceObjectiveId(null);
            //$ this.Inner.WithRequestedServiceObjectiveName(null);
            //$ this.Inner.WithElasticPoolName(elasticPoolName);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:3BDABC5AAC07959FD1C78BEA74FD8712:BA30DB47040BBC492DFC164A6C968F85
        public SqlDatabaseImpl WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            //$ Objects.RequireNonNull(sqlElasticPool);
            //$ this.Inner.WithEdition(null);
            //$ this.Inner.WithRequestedServiceObjectiveId(null);
            //$ this.Inner.WithRequestedServiceObjectiveName(null);
            //$ this.Inner.WithElasticPoolName(sqlElasticPool.Name());
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:0A35F4FBFC584D98FAACCA25325781E8
        public SqlDatabaseImpl WithTags(IDictionary<string,string> tags)
        {
            //$ this.Inner.WithTags(tags);
            //$ return this;

            return this;
        }

        ///GENMHASH:FCE70A9CD34B8C168EB1F63E6F207D42:BC43C8FF17726D8A07EA586F3B17608B
        public SqlDatabaseImpl WithActiveDirectoryLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            //$ this.importRequestInner.WithAuthenticationType(AuthenticationType.ADPASSWORD);
            //$ this.importRequestInner.WithAdministratorLogin(administratorLogin);
            //$ this.importRequestInner.WithAdministratorLoginPassword(administratorPassword);
            //$ return this;

            return this;
        }

        ///GENMHASH:68AE3BBF06B3A5F31F06F3A6A3469188:CF334608A3F1A8CD53872D1D3F94B016
        public string DefaultSecondaryLocation()
        {
            //$ return this.Inner.DefaultSecondaryLocation();

            return null;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            //$ return this.Inner.Id();

            return null;
        }

        ///GENMHASH:09F37EE7E8975407273D6FA4FB12441D:5B750DDCC180A5B0F60DE4E3840E3CCB
        public string Collation()
        {
            //$ return this.Inner.Collation();

            return null;
        }

        ///GENMHASH:69A889F45F764B3E541DF980DABD1473:0C2A7DB4ABEFF325916B1EFB94934EC8
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition>> ListMetricDefinitionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.sqlServerManager.Inner.Databases()
            //$ .ListMetricDefinitionsAsync(this.resourceGroupName, this.sqlServerName, this.Name())
            //$ .FlatMap(new Func1<List<MetricDefinitionInner>, Observable<MetricDefinitionInner>>() {
            //$ @Override
            //$ public Observable<MetricDefinitionInner> call(List<MetricDefinitionInner> metricDefinitionInners) {
            //$ return Observable.From(metricDefinitionInners);
            //$ }
            //$ })
            //$ .Map(new Func1<MetricDefinitionInner, SqlDatabaseMetricDefinition>() {
            //$ @Override
            //$ public SqlDatabaseMetricDefinition call(MetricDefinitionInner metricDefinitionInner) {
            //$ return new SqlDatabaseMetricDefinitionImpl(metricDefinitionInner);
            //$ }
            //$ });

            return null;
        }

        /////GENMHASH:7A9E1ACC5D9B5ED3EF93A2ABFD978F14:1F4B6D4F1D6BA088BF475B965981DC9B
        //internal void AddParentDependency(IHasTaskGroup parentDependency)
        //{
        //    //$ this.AddDependency(parentDependency);
        //    //$ }

        //}

        ///GENMHASH:FA6C4C8AE7729C6D128F00A0883B7A82:050D474227760B6267EFCEC6085DD2B2
        public DateTime EarliestRestoreDate()
        {
            //$ return this.Inner.EarliestRestoreDate();

            return DateTime.Now;
        }

        ///GENMHASH:DF623B844EDAA9403C7ADB3E4D089ADD:1E1FA9AB1DCE4AD9527CF761EC52F4BC
        public string RequestedServiceObjectiveName()
        {
            //$ return this.Inner.RequestedServiceObjectiveName();

            return null;
        }

        ///GENMHASH:94274C9965DC54702B64A387A19F1F2B:B539D8C79F7F64123BCB4A6F10EDBD92
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks()
        {
            //$ Map<String, ReplicationLink> replicationLinkMap = new HashMap<>();
            //$ List<ReplicationLinkInner> replicationLinkInners = this.sqlServerManager.Inner
            //$ .ReplicationLinks().ListByDatabase(this.resourceGroupName, this.sqlServerName, this.Name());
            //$ if (replicationLinkInners != null) {
            //$ foreach(var inner in replicationLinkInners) {
            //$ replicationLinkMap.Put(inner.Name(), new ReplicationLinkImpl(this.resourceGroupName, this.sqlServerName, inner, this.sqlServerManager));
            //$ }
            //$ }
            //$ return Collections.UnmodifiableMap(replicationLinkMap);

            return null;
        }

        ///GENMHASH:9557699E7EE892CCCC89A074E0915333:A55D3CBCED3C2D7241CB8E96C4D3F217
        public void BeforeGroupCreateOrUpdate()
        {
            //$ if (parentSqlElasticPool != null) {
            //$ this.AddParentDependency(parentSqlElasticPool);
            //$ }
            //$ if (this.importRequestInner != null && this.ElasticPoolName() != null) {
            //$ SqlDatabaseImpl self = this;
            //$ String epName = this.ElasticPoolName();
            //$ this.AddPostRunDependent(new FunctionalTaskItem() {
            //$ @Override
            //$ public Observable<Indexable> call( Context context) {
            //$ self.ImportRequestInner = null;
            //$ self.WithExistingElasticPool(epName);
            //$ return self.CreateResourceAsync()
            //$ .FlatMap(new Func1<SqlDatabase, Observable<Indexable>>() {
            //$ @Override
            //$ public Observable<Indexable> call(SqlDatabase sqlDatabase) {
            //$ return context.VoidObservable();
            //$ }
            //$ });
            //$ }
            //$ });
            //$ }

        }

        ///GENMHASH:36003534781597C965476F5DF65AFAE0:5676358725D0EA511E36276932C4EE49
        public SqlDatabaseImpl WithCollation(string collation)
        {
            //$ this.Inner.WithCollation(collation);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:0E666BFDFC9A666CA31FD735D7839414:6A8302C4C1400F1CDCE2686A7C6C8E41
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages()
        {
            //$ // This method was deprecated in favor of the other database metric related methods
            //$ return Collections.UnmodifiableList(new ArrayList<DatabaseMetric>());

            return null;
        }

        ///GENMHASH:546F275F5C716DBA4B4E3ED283223400:0FDEDB5D39B9E6DEB193A84687780CDA
        public SqlDatabaseImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName, string sqlServerLocation)
        {
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.sqlServerName = sqlServerName;
            //$ this.sqlServerLocation = sqlServerLocation;
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:1913C8F57081FC6BA71CCA1646434B22
        public SqlDatabaseImpl WithExistingSqlServer(ISqlServer sqlServer)
        {
            //$ Objects.RequireNonNull(sqlServer);
            //$ this.resourceGroupName = sqlServer.ResourceGroupName();
            //$ this.sqlServerName = sqlServer.Name();
            //$ this.sqlServerLocation = sqlServer.RegionName();
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:B132DF15A736F615C9C36B19E938DF9E:65F2784364791089D5368B99F0100E95
        public SqlDatabaseImpl WithStorageAccessKey(string storageAccessKey)
        {
            //$ this.importRequestInner.WithStorageKeyType(StorageKeyType.STORAGE_ACCESS_KEY);
            //$ this.importRequestInner.WithStorageKey(storageAccessKey);
            //$ return this;

            return this;
        }

        ///GENMHASH:4A64D79C205DE76E07E6A3581CF5E14B:1A9338236EC82827DA9F8F8293BE39FE
        public SqlElasticPoolForDatabaseImpl DefineElasticPool(string elasticPoolName)
        {
            //$ if (this.sqlElasticPools == null) {
            //$ this.sqlElasticPools = new SqlElasticPoolsAsExternalChildResourcesImpl(this.TaskGroup(), this.sqlServerManager, "SqlElasticPool");
            //$ }
            //$ this.Inner.WithEdition(null);
            //$ this.Inner.WithRequestedServiceObjectiveId(null);
            //$ this.Inner.WithRequestedServiceObjectiveName(null);
            //$ this.Inner.WithElasticPoolName(elasticPoolName);
            //$ 
            //$ return new SqlElasticPoolForDatabaseImpl(this, this.sqlElasticPools
            //$ .DefineIndependentElasticPool(elasticPoolName).WithExistingSqlServer(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation));

            return null;
        }

        ///GENMHASH:37206883074CEB63F8267ADE2545CF11:4C107A9D0C8600BD4F989BA7EE78EE0C
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints()
        {
            //$ List<RestorePoint> restorePoints = new ArrayList<>();
            //$ List<RestorePointInner> restorePointInners = this.sqlServerManager.Inner
            //$ .RestorePoints().ListByDatabase(this.resourceGroupName, this.sqlServerName, this.Name());
            //$ if (restorePointInners != null) {
            //$ foreach(var inner in restorePointInners) {
            //$ restorePoints.Add(new RestorePointImpl(this.resourceGroupName, this.sqlServerName, inner));
            //$ }
            //$ }
            //$ return Collections.UnmodifiableList(restorePoints);

            return null;
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime CreationDate()
        {
            //$ return this.Inner.CreationDate();

            return DateTime.Now;
        }

        ///GENMHASH:E1492A9309184FBF3CAF8F7F48E93B50:2131053C84548A7E9082276BD7E11BA6
        public SqlDatabaseImpl WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective)
        {
            //$ return this.WithStandardEdition(serviceObjective, SqlDatabaseStandardStorage.MAX_250_GB);

            return this;
        }

        ///GENMHASH:49E7BA88A31F5FA05707D7827931435B:83BE97DAEF89A7A6D0C78658DFEFCDE4
        public SqlDatabaseImpl WithStandardEdition(SqlDatabaseStandardServiceObjective serviceObjective, SqlDatabaseStandardStorage maxStorageCapacity)
        {
            //$ this.Inner.WithEdition(DatabaseEditions.STANDARD);
            //$ this.WithServiceObjective(ServiceObjectiveName.FromString(serviceObjective.ToString()));
            //$ this.Inner.WithMaxSizeBytes(Long.ToString(maxStorageCapacity.Capacity()));
            //$ return this;

            return this;
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:E70E0F84833F74462C0831B3C84D4A03
        public SqlDatabaseImpl WithTag(string key, string value)
        {
            //$ this.Inner.GetTags().Put(key, value);
            //$ return this;

            return this;
        }

        ///GENMHASH:411E9B7C553E0F8FE64EB33DF4872E6A:A0F10EC124D07E925E3BE6285203F7E0
        public string ServiceLevelObjective()
        {
            //$ return this.Inner.ServiceLevelObjective();

            return null;
        }

        ///GENMHASH:6440992F4CBC2FF2069B36419334D933:F5264B18EE7543F8EA9233154894DE3C
        private void InitializeImportRequestInner()
        {
            //$ this.importRequestInner = new ImportRequestInner();
            //$ if (this.ElasticPoolName() != null) {
            //$ this.importRequestInner.WithEdition(DatabaseEditions.BASIC);
            //$ this.importRequestInner.WithServiceObjectiveName(ServiceObjectiveName.BASIC);
            //$ this.importRequestInner.WithMaxSizeBytes(Long.ToString(SqlDatabaseBasicStorage.MAX_2_GB.Capacity()));
            //$ } else {
            //$ this.WithStandardEdition(SqlDatabaseStandardServiceObjective.S0);
            //$ }
            //$ }

        }

        ///GENMHASH:7B6933FD706B12808B9D39A178094149:931378847EFB66ED97F43D824F04A3A3
        public ISqlWarehouse AsWarehouse()
        {
            //$ if (this.IsDataWarehouse()) {
            //$ if (this.Parent() != null) {
            //$ return new SqlWarehouseImpl(this.Name(), this.Parent(), this.Inner, this.sqlServerManager);
            //$ } else {
            //$ return new SqlWarehouseImpl(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation, this.Name(), this.Inner, this.sqlServerManager);
            //$ }
            //$ }
            //$ 
            //$ return null;

            return null;
        }

        ///GENMHASH:39034E92B8596ED5F36CD108B4CEBBC8:A785C9F7D890C95E8D7E8BE08BA1DB7D
        public ISqlDatabaseThreatDetectionPolicy DefineThreatDetectionPolicy(string policyName)
        {
            //$ return new SqlDatabaseThreatDetectionPolicyImpl(policyName, this, new DatabaseSecurityAlertPolicyInner(), this.sqlServerManager);

            return null;
        }

        ///GENMHASH:F5717DCDC59DCEC39989A49248CA5245:C44735502B6EFAF1B34E5E521F088541
        public SqlDatabaseImpl WithoutElasticPool()
        {
            //$ this.Inner.WithElasticPoolName(null);
            //$ this.Inner.WithRequestedServiceObjectiveId(null);
            //$ this.Inner.WithRequestedServiceObjectiveName(ServiceObjectiveName.S0);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:547C5E4F79BCDF43D68C1D68B8233E56:0417368F07CF88E0DF418E9E5F74D9AE
        public bool IsDataWarehouse()
        {
            //$ return this.Inner.Edition().ToString().EqualsIgnoreCase(DatabaseEditions.DATA_WAREHOUSE.ToString());

            return false;
        }

        ///GENMHASH:8380741288B285433B6443AF2F466E6D:A0411F0E7FF3C97800E30DDE842787ED
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>> ListServiceTierAdvisorsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SqlDatabaseImpl self = this;
            //$ return this.sqlServerManager.Inner
            //$ .ServiceTierAdvisors().ListByDatabaseAsync(this.resourceGroupName, this.sqlServerName, this.Name())
            //$ .FlatMap(new Func1<List<ServiceTierAdvisorInner>, Observable<ServiceTierAdvisorInner>>() {
            //$ @Override
            //$ public Observable<ServiceTierAdvisorInner> call(List<ServiceTierAdvisorInner> serviceTierAdvisorInners) {
            //$ return Observable.From(serviceTierAdvisorInners);
            //$ }
            //$ })
            //$ .Map(new Func1<ServiceTierAdvisorInner, ServiceTierAdvisor>() {
            //$ @Override
            //$ public ServiceTierAdvisor call(ServiceTierAdvisorInner serviceTierAdvisorInner) {
            //$ return new ServiceTierAdvisorImpl(self.ResourceGroupName, self.SqlServerName, serviceTierAdvisorInner, self.SqlServerManager);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:E33B754A9A9CD4E144011EFCD75AA27C
        public Region Region()
        {
            //$ return Region.FindByLabelOrName(this.RegionName());

            return null;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public string Status()
        {
            //$ return this.Inner.Status();

            return null;
        }

        ///GENMHASH:957BA7B4E61C9B91983ED17E2B61DBD7:9549FCCFE13908133153A6585989F147
        public string ElasticPoolName()
        {
            //$ return this.Inner.ElasticPoolName();

            return null;
        }

        ///GENMHASH:0D23B35B24D1777140585D16F513A57E:7924D48B71636A56E44F69FD03C4DFA9
        internal SqlDatabaseImpl WithPatchUpdate()
        {
            //$ this.isPatchUpdate = true;
            //$ return this;
            //$ }

            return this;
        }

        ///GENMHASH:396EF11BF84C5A5AEDE59746D18EF7FA:DFA427061784001F9E768D7BEB7A5E43
        public SqlDatabaseImpl WithServiceObjective(string serviceLevelObjective)
        {
            //$ this.Inner.WithElasticPoolName(null);
            //$ this.Inner.WithRequestedServiceObjectiveId(null);
            //$ this.Inner.WithRequestedServiceObjectiveName(serviceLevelObjective);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:645835BFC7B3F763E704B19D0547F1DE:CD2A5AB12BE2F4D02FD565EE2DEA70FE
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>> ListReplicationLinksAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SqlDatabaseImpl self = this;
            //$ return this.sqlServerManager.Inner
            //$ .ReplicationLinks().ListByDatabaseAsync(this.resourceGroupName, this.sqlServerName, this.Name())
            //$ .FlatMap(new Func1<List<ReplicationLinkInner>, Observable<ReplicationLinkInner>>() {
            //$ @Override
            //$ public Observable<ReplicationLinkInner> call(List<ReplicationLinkInner> replicationLinkInners) {
            //$ return Observable.From(replicationLinkInners);
            //$ }
            //$ })
            //$ .Map(new Func1<ReplicationLinkInner, ReplicationLink>() {
            //$ @Override
            //$ public ReplicationLink call(ReplicationLinkInner replicationLinkInner) {
            //$ return new ReplicationLinkImpl(self.ResourceGroupName, self.SqlServerName, replicationLinkInner, self.SqlServerManager);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            //$ return this.Inner.Location();

            return null;
        }

        ///GENMHASH:F5BFC9500AE4C04846BAAD2CC50792B3:DA87C4AB3EEB9D4BA746DF610E8BC39F
        public string Edition()
        {
            //$ return this.Inner.Edition();

            return null;
        }

        ///GENMHASH:1A8677F2439B3D7CABE292785BD60427:5F04DB72C29FE210E63C4F7C53799BA7
        public SqlDatabaseImpl ImportFrom(string storageUri)
        {
            //$ this.InitializeImportRequestInner();
            //$ this.importRequestInner.WithStorageUri(storageUri);
            //$ return this;

            return this;
        }

        ///GENMHASH:7373E32C16A40BA46FE99D3C43267A6D:51DAE7A41E58631741DFE52C7C67E106
        public SqlDatabaseImpl ImportFrom(IStorageAccount storageAccount, string containerName, string fileName)
        {
            //$ SqlDatabaseImpl self = this;
            //$ Objects.RequireNonNull(storageAccount);
            //$ this.InitializeImportRequestInner();
            //$ this.AddDependency(new FunctionalTaskItem() {
            //$ @Override
            //$ public Observable<Indexable> call( Context context) {
            //$ return storageAccount.GetKeysAsync()
            //$ .FlatMap(new Func1<List<StorageAccountKey>, Observable<StorageAccountKey>>() {
            //$ @Override
            //$ public Observable<StorageAccountKey> call(List<StorageAccountKey> storageAccountKeys) {
            //$ return Observable.From(storageAccountKeys).First();
            //$ }
            //$ })
            //$ .FlatMap(new Func1<StorageAccountKey, Observable<Indexable>>() {
            //$ @Override
            //$ public Observable<Indexable> call(StorageAccountKey storageAccountKey) {
            //$ self.ImportRequestInner.WithStorageUri(String.Format("%s%s/%s", storageAccount.EndPoints().Primary().Blob(), containerName, fileName));
            //$ self.ImportRequestInner.WithStorageKeyType(StorageKeyType.STORAGE_ACCESS_KEY);
            //$ self.ImportRequestInner.WithStorageKey(storageAccountKey.Value());
            //$ return context.VoidObservable();
            //$ }
            //$ });
            //$ }
            //$ });
            //$ return this;

            return this;
        }

        ///GENMHASH:C8BF6EB45120AB5638A39B9E6F246F48:88685B211625AC25043E56EF15C881D0
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption> GetTransparentDataEncryptionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SqlDatabaseImpl self = this;
            //$ return this.sqlServerManager.Inner
            //$ .TransparentDataEncryptions().GetAsync(this.resourceGroupName, this.sqlServerName, this.Name())
            //$ .Map(new Func1<TransparentDataEncryptionInner, TransparentDataEncryption>() {
            //$ @Override
            //$ public TransparentDataEncryption call(TransparentDataEncryptionInner transparentDataEncryptionInner) {
            //$ return new TransparentDataEncryptionImpl(self.ResourceGroupName, self.SqlServerName, transparentDataEncryptionInner, self.SqlServerManager);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:B23645FC2F779DBC6F44B880C488B561:EEF0AD33D842F97FF9BE1E629E1C03EE
        public SqlDatabaseImpl WithMaxSizeBytes(long maxSizeBytes)
        {
            //$ this.Inner.WithMaxSizeBytes(Long.ToString(maxSizeBytes));
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:2E256CC1ACCA4253233F61C79F9D712E:9790D012FA64E47343F12DB13F0AA212
        public IUpgradeHintInterface GetUpgradeHint()
        {
            //$ return null;

            return null;
        }

        ///GENMHASH:A26C8D278B6519B28BA17D3966024017:A4AA33E1BB3D9FE5155733094177C7C2
        public long MaxSizeBytes()
        {
            //$ return Long.ValueOf(this.Inner.MaxSizeBytes());

            return 0;
        }

        ///GENMHASH:A1DBAE6CBFB56230E32A4169F4FC18B2:75E99B1B89E418875225D1E0E9BECAAE
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> ListMetrics(string filter)
        {
            //$ List<SqlDatabaseMetric> sqlDatabaseMetrics = new ArrayList<>();
            //$ List<MetricInner> metricInners = this.sqlServerManager.Inner.Databases()
            //$ .ListMetrics(this.resourceGroupName, this.sqlServerName, this.Name(), filter);
            //$ if (metricInners != null) {
            //$ foreach(var metricInner in metricInners) {
            //$ sqlDatabaseMetrics.Add(new SqlDatabaseMetricImpl(metricInner));
            //$ }
            //$ }
            //$ return Collections.UnmodifiableList(sqlDatabaseMetrics);

            return null;
        }

        ///GENMHASH:FB41F80AEFA7E12022C9196F41BF8921:ED8B3A06AA34CEDC5610A3DEF09E3EEE
        public SqlDatabaseImpl WithBasicEdition()
        {
            //$ return this.WithBasicEdition(SqlDatabaseBasicStorage.MAX_2_GB);

            return this;
        }

        ///GENMHASH:F7B4B7D42B00968BBE7591CAAB07FB08:D7C7D124B191508D782E83C2EA9D3650
        public SqlDatabaseImpl WithBasicEdition(SqlDatabaseBasicStorage maxStorageCapacity)
        {
            //$ this.Inner.WithEdition(DatabaseEditions.BASIC);
            //$ this.WithServiceObjective(ServiceObjectiveName.BASIC);
            //$ this.Inner.WithMaxSizeBytes(Long.ToString(maxStorageCapacity.Capacity()));
            //$ return this;

            return this;
        }

        ///GENMHASH:E79C534DFF1FD292BF3629BFBDD6B6B9:96B4434F4DABBF823E846088675F0311
        public SqlDatabaseImportRequestImpl ImportBacpac(string storageUri)
        {
            //$ return new SqlDatabaseImportRequestImpl(this, this.sqlServerManager)
            //$ .ImportFrom(storageUri);

            return null;
        }

        ///GENMHASH:E67F1FD4894329ACCDFF54905A1E694E:7EE85AF9D02D1E0432372E41F59DAC1E
        public SqlDatabaseImportRequestImpl ImportBacpac(IStorageAccount storageAccount, string containerName, string fileName)
        {
            //$ Objects.RequireNonNull(storageAccount);
            //$ return new SqlDatabaseImportRequestImpl(this, this.sqlServerManager)
            //$ .ImportFrom(storageAccount, containerName, fileName);

            return null;
        }

        ///GENMHASH:41180B8AE28244EF8581E555D8B35D2B:59963B0DFB54839D345581B895AFA980
        public string DatabaseId()
        {
            //$ return this.Inner.DatabaseId().ToString();

            return null;
        }

        ///GENMHASH:498D3951D3EB5A31E765F1E9A24A877E:6992EC71A319B4CAEF905C374DF6F78C
        public SqlDatabaseImpl WithSharedAccessKey(string sharedAccessKey)
        {
            //$ this.importRequestInner.WithStorageKeyType(StorageKeyType.SHARED_ACCESS_KEY);
            //$ this.importRequestInner.WithStorageKey(sharedAccessKey);
            //$ return this;

            return this;
        }

        ///GENMHASH:CA0DDA4D9821F262B350AF8BD2FD3D72:90A235C564BCEA582EA7E8E169017608
        public ISqlDatabaseThreatDetectionPolicy GetThreatDetectionPolicy()
        {
            //$ DatabaseSecurityAlertPolicyInner policyInner = this.sqlServerManager.Inner.DatabaseThreatDetectionPolicies()
            //$ .Get(this.resourceGroupName, this.sqlServerName, this.Name());
            //$ return policyInner != null ? new SqlDatabaseThreatDetectionPolicyImpl(policyInner.Name(), this, policyInner, this.sqlServerManager) : null;

            return null;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            //$ return this.resourceGroupName;

            return null;
        }

        ///GENMHASH:A521981B274EF2B3D621C0705EFAA811:5E9BEFBB11C2769CA5132E0CF9CCABB2
        public SqlDatabaseImpl WithMode(string createMode)
        {
            //$ this.Inner.WithCreateMode(createMode);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:250EC2907300FFA6125F7205F03A3E7F
        public SqlDatabaseImpl WithoutTag(string key)
        {
            //$ this.Inner.GetTags().Remove(key);
            //$ return this;

            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            //$ return this.sqlServerName;

            return null;
        }

        ///GENMHASH:E181EA037CDEB6D9DCE12CA92D1526C7:0D2A486B784948E9672C737F8A7624D2
        public SqlDatabaseImpl FromSample(SampleName sampleName)
        {
            //$ this.Inner.WithSampleName(sampleName);
            //$ return this;

            return this;
        }

        ///GENMHASH:F558A35AAC7463E4988A0A5E052953DD:BFCA5ABF1F9698290D6F011B01A4BC1F
        public ITransparentDataEncryption GetTransparentDataEncryption()
        {
            //$ TransparentDataEncryptionInner transparentDataEncryptionInner = this.sqlServerManager.Inner
            //$ .TransparentDataEncryptions().Get(this.resourceGroupName, this.sqlServerName, this.Name());
            //$ return new TransparentDataEncryptionImpl(this.resourceGroupName, this.sqlServerName, transparentDataEncryptionInner, this.sqlServerManager);

            return null;
        }

        ///GENMHASH:86135EF83A124C4DC11F0F4D3932D96D:D2635043C832D0ED57B4C7331890CFBC
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric>> ListMetricsAsync(string filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.sqlServerManager.Inner.Databases()
            //$ .ListMetricsAsync(this.resourceGroupName, this.sqlServerName, this.Name(), filter)
            //$ .FlatMap(new Func1<List<MetricInner>, Observable<MetricInner>>() {
            //$ @Override
            //$ public Observable<MetricInner> call(List<MetricInner> metricInners) {
            //$ return Observable.From(metricInners);
            //$ }
            //$ })
            //$ .Map(new Func1<MetricInner, SqlDatabaseMetric>() {
            //$ @Override
            //$ public SqlDatabaseMetric call(MetricInner metricInner) {
            //$ return new SqlDatabaseMetricImpl(metricInner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:495111B1D55D7AA3C4EA4E49042FA05A:018B4F53394EF9D955345603E5AF968D
        public SqlDatabaseImpl WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool)
        {
            //$ Objects.RequireNonNull(sqlElasticPool);
            //$ this.Inner.WithEdition(null);
            //$ this.Inner.WithRequestedServiceObjectiveId(null);
            //$ this.Inner.WithRequestedServiceObjectiveName(null);
            //$ this.Inner.WithElasticPoolName(sqlElasticPool.Name());
            //$ this.AddDependency(sqlElasticPool);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:F5DF37BD82C1C590C56B4F013C07DABC:8C97E5D1BC323EC4701C62A50021CBF3
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> ListMetricDefinitions()
        {
            //$ List<SqlDatabaseMetricDefinition> sqlDatabaseMetricDefinitions = new ArrayList<>();
            //$ List<MetricDefinitionInner> metricDefinitionInners = this.sqlServerManager.Inner.Databases()
            //$ .ListMetricDefinitions(this.resourceGroupName, this.sqlServerName, this.Name());
            //$ if (metricDefinitionInners != null) {
            //$ foreach(var metricDefinitionInner in metricDefinitionInners) {
            //$ sqlDatabaseMetricDefinitions.Add(new SqlDatabaseMetricDefinitionImpl(metricDefinitionInner));
            //$ }
            //$ }
            //$ 
            //$ return Collections.UnmodifiableList(sqlDatabaseMetricDefinitions);

            return null;
        }

        ///GENMHASH:85FBE37563F3ADEA0037149593562508:FFD4FFA925AA8688B4B8288DE2CD55F3
        public SqlDatabaseImpl FromRestorableDroppedDatabase(ISqlRestorableDroppedDatabase restorableDroppedDatabase)
        {
            //$ Objects.RequireNonNull(restorableDroppedDatabase);
            //$ return this.WithSourceDatabase(restorableDroppedDatabase.Id())
            //$ .WithMode(CreateMode.RESTORE);

            return this;
        }

        ///GENMHASH:F6C12109AEE137840B60E059E6708A02:3802C120362CEFDF42D356C4A1BB4C0B
        public SqlDatabaseImpl FromRestorePoint(IRestorePoint restorePoint)
        {
            //$ Objects.RequireNonNull(restorePoint);
            //$ this.Inner.WithRestorePointInTime(restorePoint.EarliestRestoreDate());
            //$ return this.WithSourceDatabase(restorePoint.DatabaseId())
            //$ .WithMode(CreateMode.POINT_IN_TIME_RESTORE);

            return this;
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:BF44555315B4D8F7DE5B31B09438FA0A
        public string ParentId()
        {
            //$ return ResourceUtils.ParentResourceIdFromResourceId(this.Id());

            return null;
        }

        ///GENMHASH:7E720FDC940A2922809B9D27EFCACBCD:47BE206E881D06DAD00CE167DAE60229
        public SqlDatabaseImpl WithSqlAdministratorLoginAndPassword(string administratorLogin, string administratorPassword)
        {
            //$ this.importRequestInner.WithAuthenticationType(AuthenticationType.SQL);
            //$ this.importRequestInner.WithAdministratorLogin(administratorLogin);
            //$ this.importRequestInner.WithAdministratorLoginPassword(administratorPassword);
            //$ return this;

            return this;
        }

        ///GENMHASH:212A2F2F92E2D462C22479742BC730A3:A93678FA285496CB5F325AF4DC1B281C
        public SqlDatabaseExportRequestImpl ExportTo(string storageUri)
        {
            //$ return new SqlDatabaseExportRequestImpl(this, this.sqlServerManager)
            //$ .ExportTo(storageUri);

            return null;
        }

        ///GENMHASH:86E7BAA14B4627C99B23DD5E99D3E137:E50A2EC6A3EE3A525FA469BD438C0871
        public SqlDatabaseExportRequestImpl ExportTo(IStorageAccount storageAccount, string containerName, string fileName)
        {
            //$ Objects.RequireNonNull(storageAccount);
            //$ return new SqlDatabaseExportRequestImpl(this, this.sqlServerManager)
            //$ .ExportTo(storageAccount, containerName, fileName);

            return null;
        }

        ///GENMHASH:1F5324043331585B2120A5C89F84F5DB:C885DEE02CF75EE1A4A387AAA0D8A760
        public SqlDatabaseExportRequestImpl ExportTo(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName, string fileName)
        {
            //$ Objects.RequireNonNull(storageAccountCreatable);
            //$ return new SqlDatabaseExportRequestImpl(this, this.sqlServerManager)
            //$ .ExportTo(storageAccountCreatable, containerName, fileName);

            return null;
        }

        ///GENMHASH:B1D3E971A2C4574ED03F74E5745E8301:B5D8E6907D7456C71BFBDDD84D4CAF3D
        public Guid RequestedServiceObjectiveId()
        {
            //$ return this.Inner.RequestedServiceObjectiveId();

            return Guid.NewGuid();
        }

        ///GENMHASH:EB950732E887990C7D61B74EBA2E3E50:573BDC9A38C91E0EA3771EF31E937127
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint>> ListRestorePointsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SqlDatabaseImpl self = this;
            //$ return this.sqlServerManager.Inner
            //$ .RestorePoints().ListByDatabaseAsync(this.resourceGroupName, this.sqlServerName, this.Name())
            //$ .FlatMap(new Func1<List<RestorePointInner>, Observable<RestorePointInner>>() {
            //$ @Override
            //$ public Observable<RestorePointInner> call(List<RestorePointInner> restorePointInners) {
            //$ return Observable.From(restorePointInners);
            //$ }
            //$ })
            //$ .Map(new Func1<RestorePointInner, RestorePoint>() {
            //$ @Override
            //$ public RestorePoint call(RestorePointInner restorePointInner) {
            //$ return new RestorePointImpl(self.ResourceGroupName, self.SqlServerName, restorePointInner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:F8954D151717AC497C4A3B76321952A6:5BEB5EA8B9F53B7F9AA00D61AB0B2853
        public SqlDatabaseImpl WithSourceDatabase(string sourceDatabaseId)
        {
            //$ this.Inner.WithSourceDatabaseId(sourceDatabaseId);
            //$ 
            //$ return this;

            return this;
        }

        ///GENMHASH:642F972C91F9E70B14E53881C1FCA8F9:F069850B2BE457D02CB713E8708DE59C
        public SqlDatabaseImpl WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            //$ return this.WithSourceDatabase(sourceDatabase.Id());

            return this;
        }

        ///GENMHASH:6F25566A2BEBF8E935396FF70D7412F6:CFB98BD6B2251258A7E6ED7109B50D5A
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> ListServiceTierAdvisors()
        {
            //$ Map<String, ServiceTierAdvisor> serviceTierAdvisorMap = new HashMap<>();
            //$ List<ServiceTierAdvisorInner> serviceTierAdvisorInners = this.sqlServerManager.Inner
            //$ .ServiceTierAdvisors().ListByDatabase(this.resourceGroupName, this.sqlServerName, this.Name());
            //$ if (serviceTierAdvisorInners != null) {
            //$ foreach(var serviceTierAdvisorInner in serviceTierAdvisorInners) {
            //$ serviceTierAdvisorMap.Put(serviceTierAdvisorInner.Name(),
            //$ new ServiceTierAdvisorImpl(this.resourceGroupName, this.sqlServerName, serviceTierAdvisorInner, this.sqlServerManager));
            //$ }
            //$ }
            //$ return Collections.UnmodifiableMap(serviceTierAdvisorMap);

            return null;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AA78F52D96EC68C22A95FE39F9EB7071
        protected async Task<Models.DatabaseInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.sqlServerManager.Inner.Databases().GetAsync(this.resourceGroupName, this.sqlServerName, this.Name());

            return null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:4E95DB8FD4DE0A3758B25CB7991A2C2A
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SqlDatabaseImpl self = this;
            //$ this.Inner.WithLocation(this.sqlServerLocation);
            //$ if (this.importRequestInner != null) {
            //$ this.importRequestInner.WithDatabaseName(this.Name());
            //$ if (this.importRequestInner.Edition() == null) {
            //$ this.importRequestInner.WithEdition(this.Inner.Edition());
            //$ }
            //$ if (this.importRequestInner.ServiceObjectiveName() == null) {
            //$ this.importRequestInner.WithServiceObjectiveName((this.Inner.RequestedServiceObjectiveName()));
            //$ }
            //$ if (this.importRequestInner.MaxSizeBytes() == null) {
            //$ this.importRequestInner.WithMaxSizeBytes(this.Inner.MaxSizeBytes());
            //$ }
            //$ 
            //$ return this.sqlServerManager.Inner.Databases()
            //$ .ImportMethodAsync(this.resourceGroupName, this.sqlServerName, this.importRequestInner)
            //$ .FlatMap(new Func1<ImportExportResponseInner, Observable<SqlDatabase>>() {
            //$ @Override
            //$ public Observable<SqlDatabase> call(ImportExportResponseInner importExportResponseInner) {
            //$ if (self.ElasticPoolName() != null) {
            //$ self.ImportRequestInner = null;
            //$ return self.WithExistingElasticPool(self.ElasticPoolName()).WithPatchUpdate().UpdateResourceAsync();
            //$ } else {
            //$ return self.RefreshAsync();
            //$ }
            //$ }
            //$ });
            //$ } else {
            //$ return this.sqlServerManager.Inner.Databases()
            //$ .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), this.Inner)
            //$ .Map(new Func1<DatabaseInner, SqlDatabase>() {
            //$ @Override
            //$ public SqlDatabase call(DatabaseInner inner) {
            //$ self.SetInner(inner);
            //$ return self;
            //$ }
            //$ });
            //$ }

            return null;
        }

        ///GENMHASH:AC7CC07C6D6A5043B63254841EEBA63A:7F7F8CAB431C433CEC91CF27F54FEFFD
        public async Task AfterPostRunAsync(bool isGroupFaulted, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (this.sqlElasticPools != null) {
            //$ this.sqlElasticPools.Clear();
            //$ }
            //$ this.importRequestInner = null;
            //$ 
            //$ return Completable.Complete();

            return;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:6BCBA570417EAC0D10DCE422CAB270A5
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (this.isPatchUpdate) {
            //$ SqlDatabaseImpl self = this;
            //$ DatabaseUpdateInner databaseUpdateInner = new DatabaseUpdateInner()
            //$ .WithTags(self.Inner.GetTags())
            //$ .WithCollation(self.Inner.Collation())
            //$ .WithSourceDatabaseId(self.Inner.SourceDatabaseId())
            //$ .WithCreateMode(self.Inner.CreateMode())
            //$ .WithEdition(self.Inner.Edition())
            //$ .WithRequestedServiceObjectiveName(this.Inner.RequestedServiceObjectiveName())
            //$ .WithMaxSizeBytes(this.Inner.MaxSizeBytes())
            //$ .WithElasticPoolName(this.Inner.ElasticPoolName());
            //$ databaseUpdateInner.WithLocation(self.Inner.Location());
            //$ return this.sqlServerManager.Inner.Databases()
            //$ .UpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), databaseUpdateInner)
            //$ .Map(new Func1<DatabaseInner, SqlDatabase>() {
            //$ @Override
            //$ public SqlDatabase call(DatabaseInner inner) {
            //$ self.SetInner(inner);
            //$ self.IsPatchUpdate = false;
            //$ return self;
            //$ }
            //$ });
            //$ 
            //$ } else {
            //$ return this.CreateResourceAsync();
            //$ }

            return null;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:8FF06E289719BB519BDB4F57C1488F6F
        public SqlServerImpl Attach()
        {
            //$ return this.Parent();

            return null;
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:B8443F1744F97B6579E4964E67592EFB
        public void Delete()
        {
            //$ this.sqlServerManager.Inner.Databases().Delete(this.resourceGroupName, this.sqlServerName, this.Name());

        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.DeleteResourceAsync().ToCompletable();

            return;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:774D147C034A0076F237A117323E70D7
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.sqlServerManager.Inner.Databases().DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name());

            return;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:ECB4548536225101A4FBA7DFDB22FE6D
        public SqlDatabaseImpl Update()
        {
            //$ super.PrepareUpdate();
            //$ return this;

            return this;
        }

        public ISqlDatabase Apply()
        {
            throw new NotImplementedException();
        }

        public Task<ISqlDatabase> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            throw new NotImplementedException();
        }

        public ISqlDatabase Create()
        {
            throw new NotImplementedException();
        }

        public Task<ISqlDatabase> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            throw new NotImplementedException();
        }

        public ISqlDatabase Refresh()
        {
            throw new NotImplementedException();
        }

        public Task<ISqlDatabase> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}