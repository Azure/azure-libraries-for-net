// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.SqlElasticPoolDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlElasticPool.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbGFzdGljUG9vbEltcGw=
    internal partial class SqlElasticPoolImpl  :
        ChildResource<
            Models.ElasticPoolInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlElasticPool,
        ISqlElasticPoolDefinition<SqlServer.Definition.IWithCreate>,
        SqlElasticPoolOperations.Definition.IWithCreate,
        IUpdate,
        ISqlElasticPoolOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private string sqlServerLocation;
        private readonly string name;
        private List<SqlDatabaseImpl> dbToCreateOrUpdate = new List<SqlDatabaseImpl>();
        private List<String> dbToUpdate = new List<String>();
        private List<String> dbToDelete = new List<String>();

        string IExternalChildResource<ISqlElasticPool, ISqlServer>.Id => this.Id();

        string ICreatable<ISqlElasticPool>.Name => this.Name();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:4E0B0BB60E793FAAF65A4FB06FF40ED6:688BEBCD488B587FB73DE2900EB69ACC
        internal SqlElasticPoolImpl(string name, SqlServerImpl parent, ElasticPoolInner innerObject, ISqlManager sqlServerManager)
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
        ///GENMHASH:57B1BE3864897C5290648EFC4CB9F4CF:1F19069E738766C2410CE5F937A12B8B
        internal SqlElasticPoolImpl(string resourceGroupName, string sqlServerName, string sqlServerLocation, string name, ElasticPoolInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerLocation = sqlServerLocation;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:D5251BF5145F14511372289648C6C18A:82E880B3031837A885AD54F15B3735CF
        internal SqlElasticPoolImpl(string name, ElasticPoolInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:7B8C2123973B40EFE9E128DA887E66D8:9DD15E41F17FBA3A26DFC77E7F5EBFD4
        public ISqlDatabase RemoveDatabase(string databaseName)
        {
            return this.GetDatabase(databaseName)
                .Update()
                .WithoutElasticPool()
                .WithStandardEdition(SqlDatabaseStandardServiceObjective.S0)
                .Apply();
        }

        ///GENMHASH:C183D7089E5DF699C59758CC103308DF:1B2FB97C80790D7946CED6F2F8D5DD23
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity> ListActivities()
        {
            return Extensions.Synchronize(() => this.ListActivitiesAsync());
        }

        ///GENMHASH:F69F9A86EEB56FF0B2A2B78C4CF114C2:7153ECB87E832139279F3EC9F68639FD
        public SqlElasticPoolImpl WithStandardPool()
        {
            this.Inner.Edition = ElasticPoolEdition.Standard;
            return this;
        }

        ///GENMHASH:F018FD6E531156DFCBAA9FAE7F4D8519:F548C4892951BC9F8563B941B288836A
        public int DatabaseDtuMax()
        {
            return this.Inner.DatabaseDtuMax.GetValueOrDefault();
        }

        ///GENMHASH:CE6E5E981686AB8CE8A830CF9AB6387F:D3C554B6F628CA009F2AB5D1A90A12F8
        public SqlElasticPoolImpl WithEdition(ElasticPoolEdition edition)
        {
            this.Inner.Edition = edition;
            return this;
        }

        ///GENMHASH:DEB77E33ECE966C507F45288C041CC34:1842FBFCA53FAC4590EFEAB67395FAC6
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity>> ListActivitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolActivity> epActivities = new List<IElasticPoolActivity>();
            var elasticPoolActivityInners = await this.sqlServerManager.Inner.ElasticPoolActivities
                .ListByElasticPoolAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (elasticPoolActivityInners != null)
            {
                foreach (var elasticPoolActivityInner in elasticPoolActivityInners)
                {
                    epActivities.Add(new ElasticPoolActivityImpl(elasticPoolActivityInner));
                }
            }
            return epActivities.AsReadOnly();
        }

        ///GENMHASH:82950C798CC6991658642EDBCBD92E5B:4E8DA28B26E404EF73C23230E63E7137
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> ListDatabaseMetrics(string filter)
        {
            return Extensions.Synchronize(() => this.ListDatabaseMetricsAsync(filter));
        }

        ///GENMHASH:5AD4BED8CF2346B6D40F11D14D91854E:DF850590D9C93BFBF3C7222561137EEB
        public int DatabaseDtuMin()
        {
            return this.Inner.DatabaseDtuMin.GetValueOrDefault();
        }

        ///GENMHASH:B88CB61BDAE447E93768AB406D02A57B:1CB6FC69A751F766B66625EAE4D84A82
        public SqlElasticPoolImpl WithExistingDatabase(string databaseName)
        {
            this.dbToUpdate.Add(databaseName);
            return this;
        }

        ///GENMHASH:C10E7F9E5F3E5F8EEC698AD28741D89A:0454FD3045F9A358E1A29CC12E29E6FD
        public SqlElasticPoolImpl WithExistingDatabase(ISqlDatabase database)
        {
            return this.WithExistingDatabase(database.Name);
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:0A35F4FBFC584D98FAACCA25325781E8
        public SqlElasticPoolImpl WithTags(IDictionary<string,string> tags)
        {
            this.Inner.Tags = new Dictionary<string, string>(tags);
            return this;
        }

        ///GENMHASH:016100CEB0E9F110178E8596490E49A8:0E66B8D26FA308EEA30C5C21D8774924
        public SqlElasticPoolImpl WithReservedDtu(SqlElasticPoolBasicEDTUs eDTU)
        {
            this.Inner.Dtu = (int)eDTU;
            return this;
        }

        ///GENMHASH:287E5247F6F2638E06FDC66A496B867D:0E66B8D26FA308EEA30C5C21D8774924
        public SqlElasticPoolImpl WithReservedDtu(SqlElasticPoolStandardEDTUs eDTU)
        {
            this.Inner.Dtu = (int)eDTU;
            return this;
        }

        ///GENMHASH:A7AFFC0C08A06739A4DEF4B29E68ED36:0E66B8D26FA308EEA30C5C21D8774924
        public SqlElasticPoolImpl WithReservedDtu(SqlElasticPoolPremiumEDTUs eDTU)
        {
            this.Inner.Dtu = (int) eDTU;
            return this;
        }

        ///GENMHASH:AB6797A1C273AA0DDF55180EC1D670F8:B78563A72181F28E0CEAA5D3F1441FC1
        public SqlElasticPoolImpl WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs eDTU)
        {
            this.Inner.DatabaseDtuMax = (int) eDTU;
            return this;
        }

        ///GENMHASH:53CB11FAC9F1E9F1BF7F513315192637:B78563A72181F28E0CEAA5D3F1441FC1
        public SqlElasticPoolImpl WithDatabaseDtuMax(SqlElasticPoolStandardMaxEDTUs eDTU)
        {
            this.Inner.DatabaseDtuMax = (int) eDTU;
            return this;
        }

        ///GENMHASH:873CBDCF636F4F9AE569C54D834964DD:B78563A72181F28E0CEAA5D3F1441FC1
        public SqlElasticPoolImpl WithDatabaseDtuMax(SqlElasticPoolPremiumMaxEDTUs eDTU)
        {
            this.Inner.DatabaseDtuMax = (int) eDTU;
            return this;
        }

        ///GENMHASH:BE89876FF9AA93145223609370F06FD8:FBCF393F261D9724E5F8A4C1DD0CEF0D
        public SqlElasticPoolImpl WithDatabaseDtuMax(int databaseDtuMax)
        {
            this.Inner.DatabaseDtuMax = databaseDtuMax;
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:F31B0F3D0CD1A4C57DB28EB70C9E094A
        public ElasticPoolState State()
        {
            return this.Inner.State;
        }

        ///GENMHASH:28E298A957739902B050C54C3A0D9998:BDD807ACB56AC25C0B9992ABAFB94604
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity>> ListDatabaseActivitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> epDatabaseActivities = new List<IElasticPoolDatabaseActivity>();
            var elasticPoolDatabaseActivityInners = await this.sqlServerManager.Inner.ElasticPoolDatabaseActivities
                .ListByElasticPoolAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (elasticPoolDatabaseActivityInners != null)
            {
                foreach (var elasticPoolDatabaseActivityInner in elasticPoolDatabaseActivityInners)
                {
                    epDatabaseActivities.Add(new ElasticPoolDatabaseActivityImpl(elasticPoolDatabaseActivityInner));
                }
            }
            return epDatabaseActivities.AsReadOnly();
        }

        // Future reference when enabling the proper framework which will track dependencies 
        /////GENMHASH:7A9E1ACC5D9B5ED3EF93A2ABFD978F14:1F4B6D4F1D6BA088BF475B965981DC9B
        //internal void AddParentDependency(IHasTaskGroup parentDependency)
        //{
        //    //$ this.AddDependency(parentDependency);
        //    //$ }

        //}

        ///GENMHASH:97CD39A6DC806326650B01A4E0BE675A:6729F7814D666C60EC365023C4CC1717
        public SqlElasticPoolImpl WithBasicPool()
        {
            this.Inner.Edition = ElasticPoolEdition.Basic;
            return this;
        }

        ///GENMHASH:546F275F5C716DBA4B4E3ED283223400:20C4C1F2718851798082D52E4164D7EB
        public SqlElasticPoolImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName, string location)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerLocation = location;
            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:15E17DBDB47A985AB1AF09E1670BD606
        public SqlElasticPoolImpl WithExistingSqlServer(ISqlServer sqlServer)
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

        ///GENMHASH:02F27DA6A925785D5A07E2DC5982702A:22EC24984E8319C6ED4EE03CBB19BAE4
        public int StorageCapacityInMB()
        {
            return this.Inner.StorageMB.GetValueOrDefault();
        }

        ///GENMHASH:29AF482561F540D08CF2A859C007C920:9113B025D3F2A0B7AA9DEF0C3FD5A61B
        public SqlElasticPoolImpl WithPremiumPool()
        {
            this.Inner.Edition = ElasticPoolEdition.Premium;
            return this;
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime CreationDate()
        {
            return this.Inner.CreationDate.GetValueOrDefault();
        }

        ///GENMHASH:4E1A950ED91B50CD58D51B39EC6E0C6F:002F2896AB10CDE9722ED9CF30116334
        public ISqlDatabase AddExistingDatabase(string databaseName)
        {
            return this.GetDatabase(databaseName)
                .Update()
                .WithExistingElasticPool(this)
                .Apply();
        }

        ///GENMHASH:1EBE935317F60FA68F721CC479412692:6FB795033CA9840988DF51037F5F9950
        public ISqlDatabase AddExistingDatabase(ISqlDatabase database)
        {
            return database
                .Update()
                .WithExistingElasticPool(this)
                .Apply();
        }

        ///GENMHASH:17E6AB9D56173E1A13C2EABA7B6A670A:A55BF70A2FC842A9F5F740870CFDBAB6
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>> ListDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> dbList = new List<ISqlDatabase>();
            var dbInners = await this.sqlServerManager.Inner.Databases
                .ListByElasticPoolAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (dbInners != null)
            {
                foreach (var databaseInner in dbInners)
                {
                    dbList.Add(new SqlDatabaseImpl(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation, databaseInner.Name, databaseInner, this.sqlServerManager));
                }
            }

            return dbList.AsReadOnly();
        }

        ///GENMHASH:1EBEB339569DE78AA557F27D165310BC:7F19D8DCDBB046068E9936D9AB0160D4
        public SqlDatabaseForElasticPoolImpl DefineDatabase(string databaseName)
        {
            var db = new SqlDatabaseImpl(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation, databaseName, new Models.DatabaseInner(), this.sqlServerManager);
            db.Inner.Location = this.sqlServerLocation;
            db.Inner.ElasticPoolName = this.Name();
            db.Inner.Edition = null;
            db.Inner.RequestedServiceObjectiveId = null;
            db.Inner.RequestedServiceObjectiveName = null;
            dbToCreateOrUpdate.Add(db);

            return new SqlDatabaseForElasticPoolImpl(this, db);
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:E70E0F84833F74462C0831B3C84D4A03
        public SqlElasticPoolImpl WithTag(string key, string value)
        {
            if (this.Inner.Tags == null)
            {
                this.Inner.Tags = new Dictionary<string, string>();
            }
            this.Inner.Tags[key] = value;
            return this;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:E33B754A9A9CD4E144011EFCD75AA27C
        public Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.RegionName());
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:AFD764C0EADBA0A1257E76094EA22AEE
        public string RegionName()
        {
            return this.sqlServerLocation;
        }

        ///GENMHASH:CD775E31F43CBA6304D6EEA9E01682A1:D833F9FDED3F098A72F676F1700C6624
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListDatabases()
        {
            return Extensions.Synchronize(() => this.ListDatabasesAsync());
        }

        ///GENMHASH:F5BFC9500AE4C04846BAAD2CC50792B3:DA87C4AB3EEB9D4BA746DF610E8BC39F
        public ElasticPoolEdition Edition()
        {
            return this.Inner.Edition;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:ECB4548536225101A4FBA7DFDB22FE6D
        public SqlElasticPoolImpl Update()
        {
            // Future reference when enabling the proper framework which will track dependencies
            // This is the beginning of the update flow
            //$ super.PrepareUpdate();
            return this;
        }

        ///GENMHASH:522508080971F7C62ABCDD82B73B7958:C0C6FD0F9328FBE71BE0CA2FC2BE387C
        public ISqlDatabase AddNewDatabase(string databaseName)
        {
            return this.sqlServerManager.SqlServers.Databases
                .Define(databaseName)
                .WithExistingSqlServer(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation)
                .WithExistingElasticPool(this)
                .Create();
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:379E136E5A42BFD01E1A9EB17A980D88
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteResourceAsync());
        }

        ///GENMHASH:43A1DBA6A9FD1592456F5F0F061B66AB:B1FBD3918DA5E9E55A96D763EEFABFE7
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric>> ListDatabaseMetricsAsync(string filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetric> databaseMetrics = new List<ISqlDatabaseMetric>();
            var metricInners = await this.sqlServerManager.Inner.ElasticPools.ListMetricsAsync(this.resourceGroupName, this.sqlServerName, this.Name(), filter, cancellationToken);
            if (metricInners != null)
            {
                foreach (var metricInner in metricInners)
                {
                    databaseMetrics.Add(new SqlDatabaseMetricImpl(metricInner));
                }
            }
            return databaseMetrics.AsReadOnly();
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:DC89C61DA7F39844028024C6079D3A9A
        public SqlServerImpl Attach()
        {
            return this.Parent;
        }

        ///GENMHASH:ADBA306EFFDD56AD4F8EFBD9057E1EAF:27B2CC85FAA243FA66F22CA2837DDCBD
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> ListDatabaseMetricDefinitions()
        {
            return Extensions.Synchronize(() => this.ListDatabaseMetricDefinitionsAsync());
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:88F495E6170B34BE98D7ECF345A40578:945958DE33096D51BB9DD38A7F3CDAD0
        public int Dtu()
        {
            return this.Inner.Dtu.GetValueOrDefault();
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:250EC2907300FFA6125F7205F03A3E7F
        public SqlElasticPoolImpl WithoutTag(string key)
        {
            if (this.Inner.Tags != null)
            {
                this.Inner.Tags.Remove(key);
            }
            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:BF44555315B4D8F7DE5B31B09438FA0A
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:A296C030F953834589B997CFB9481F12:97721984B93FE6B03E26EFE24F31773A
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition>> ListDatabaseMetricDefinitionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseMetricDefinition> dbMetricsDefinitions = new List<ISqlDatabaseMetricDefinition>();
            var innerMetrics = await this.sqlServerManager.Inner.ElasticPools.ListMetricDefinitionsAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            if (innerMetrics != null)
            {
                foreach (var metricDefinitionInner in innerMetrics)
                {
                    dbMetricsDefinitions.Add(new SqlDatabaseMetricDefinitionImpl(metricDefinitionInner));
                }
            }
            return dbMetricsDefinitions.AsReadOnly();
        }

        private void SetElasticPoolForDatabaseInner(Models.DatabaseInner inner)
        {
            inner.Location = this.sqlServerLocation;
            inner.ElasticPoolName = this.Name();
            inner.Edition = null;
            inner.RequestedServiceObjectiveId = null;
            inner.RequestedServiceObjectiveName = null;
        }

        ///GENMHASH:D7949083DDCDE361387E2A975A1A1DE5:0EB97FA79ED404AB1B206D140AF775CA
        public SqlElasticPoolImpl WithNewDatabase(string databaseName)
        {
            var db = new SqlDatabaseImpl(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation, databaseName, new Models.DatabaseInner(), this.sqlServerManager);
            SetElasticPoolForDatabaseInner(db.Inner);
            dbToCreateOrUpdate.Add(db);
            return this;
        }

        ///GENMHASH:DA730BE4F3BEA4D8DCD1631C079435CB:AFDEF6B8993C33A8E723612D6EAD48B5
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> ListDatabaseActivities()
        {
            return Extensions.Synchronize(() => this.ListDatabaseActivitiesAsync());
        }

        ///GENMHASH:1C25D7B8D9084176A24655682A78634D:8E193D1268EA25434555A7B24DDEB33B
        public ISqlDatabase GetDatabase(string databaseName)
        {
            var databaseInner = Extensions.Synchronize(() => this.sqlServerManager.Inner.Databases.GetAsync(this.resourceGroupName, this.sqlServerName, databaseName));
            return databaseInner != null ? new SqlDatabaseImpl(this.resourceGroupName, this.sqlServerName, this.sqlServerLocation, databaseName, databaseInner, this.sqlServerManager) : null;
        }

        ///GENMHASH:58F0F991960D193A83633DD3EFF3BBA9:A2B4817DDEAC96BD99C2363FE5F1E557
        public SqlElasticPoolImpl WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs eDTU)
        {
            this.Inner.DatabaseDtuMin = (int)eDTU;
            return this;
        }

        ///GENMHASH:238D14C741300C8F3F85D3693AF9E389:A2B4817DDEAC96BD99C2363FE5F1E557
        public SqlElasticPoolImpl WithDatabaseDtuMin(SqlElasticPoolStandardMinEDTUs eDTU)
        {
            this.Inner.DatabaseDtuMin = (int)eDTU;
            return this;
        }

        ///GENMHASH:CD960E929365F3472B6056B6E4728E44:A2B4817DDEAC96BD99C2363FE5F1E557
        public SqlElasticPoolImpl WithDatabaseDtuMin(SqlElasticPoolPremiumMinEDTUs eDTU)
        {
            this.Inner.DatabaseDtuMin = (int)eDTU;
            return this;
        }

        ///GENMHASH:52F9B4107BF3F85A991B429161CF5EB8:41FD2D9003985AE2BA9F4027A8AE05F9
        public SqlElasticPoolImpl WithDatabaseDtuMin(int databaseDtuMin)
        {
            this.Inner.DatabaseDtuMin = databaseDtuMin;
            return this;
        }

        ///GENMHASH:FB97B6A01BB44DE1679EAB5070CAB853:22EC24984E8319C6ED4EE03CBB19BAE4
        public int StorageMB()
        {
            return this.Inner.StorageMB.GetValueOrDefault();
        }

        ///GENMHASH:D7704568C142F68F7A15BF85145157D7:874ADE93123FF580FDC855E273311E48
        public SqlElasticPoolImpl WithStorageCapacity(SqlElasticPoolStandardStorage storageCapacity)
        {
            long capacityInMB = (long)storageCapacity / (1024 * 1024);
            this.Inner.StorageMB = (int)capacityInMB;
            return this;
        }

        ///GENMHASH:CB542E2EF61540C0531F6875AE9754E0:874ADE93123FF580FDC855E273311E48
        public SqlElasticPoolImpl WithStorageCapacity(SqlElasticPoolPremiumSorage storageCapacity)
        {
            long capacityInMB = (long)storageCapacity / (1024 * 1024);
            this.Inner.StorageMB = (int)capacityInMB;
            return this;
        }

        ///GENMHASH:5219D4DB320BF9F9DA49E9B44C0088EE:3721F7B0F159C1617BDBEA9251EA81E6
        public SqlElasticPoolImpl WithStorageCapacity(int storageMB)
        {
            this.Inner.StorageMB = storageMB;
            return this;
        }

        ///GENMHASH:E293D352B4C8ABEA82BF928E8B1ADC36:E89B91984CA129C2BAB11F8710EC7526
        public SqlElasticPoolImpl WithDtu(int dtu)
        {
            this.Inner.Dtu = dtu;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:EC2756D92EC1B3A1B42D6E6ECC46A901
        protected async Task<Models.ElasticPoolInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.ElasticPools
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        private async Task BeforeGroupCreateOrUpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(this.dbToDelete.Select(db => this.sqlServerManager.Inner.Databases
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, db, cancellationToken)));
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:795EF73D531CCC27D2428DA33B861EA4
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.BeforeGroupCreateOrUpdateAsync(cancellationToken);
            this.Inner.Location = this.sqlServerLocation;
            var innerObject = await this.sqlServerManager.Inner.ElasticPools
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), this.Inner, cancellationToken);
            this.SetInner(innerObject);
            await this.AfterPostRunAsync(false, cancellationToken);

            return this;
        }

        ///GENMHASH:AC7CC07C6D6A5043B63254841EEBA63A:76CFB8C3FCDB36FCCFC150AF5507CBD0
        public async Task AfterPostRunAsync(bool isGroupFaulted, CancellationToken cancellationToken = default(CancellationToken))
        {
            var dbTasks = this.dbToUpdate.Select(async dbName =>
                {
                    var db = await this.sqlServerManager.SqlServers.Databases.GetBySqlServerAsync(this.resourceGroupName, this.sqlServerName, dbName, cancellationToken);
                    this.SetElasticPoolForDatabaseInner(db.Inner);
                    return await ((SqlDatabaseImpl)db).UpdateResourceAsync(cancellationToken);
                })
                .Union(this.dbToCreateOrUpdate.Select(async db => await db.CreateResourceAsync(cancellationToken)));

            await Task.WhenAll(dbTasks);
            this.dbToCreateOrUpdate.Clear();
            this.dbToUpdate.Clear();
            this.dbToDelete.Clear();
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:3D9EADC4B650CD53979890348EE63A3C
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:7D2A8AE9584F641341C5CB5E5F4C1224
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ElasticPools
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        public ISqlElasticPool Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlElasticPool> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlElasticPool Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlElasticPool> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        public ISqlElasticPool Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlElasticPool> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }
    }
}