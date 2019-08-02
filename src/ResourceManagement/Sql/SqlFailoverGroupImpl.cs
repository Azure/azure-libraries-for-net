// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroup.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFailoverGroupOperations.SqlFailoverGroupOperationsDefinition;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for SqlFailoverGroup.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxGYWlsb3Zlckdyb3VwSW1wbA==
    internal partial class SqlFailoverGroupImpl :
        ChildResource<
            Models.FailoverGroupInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlFailoverGroup,
        IUpdate,
        ISqlFailoverGroupOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        protected string sqlServerLocation;
        private string name;

        string ICreatable<ISqlFailoverGroup>.Name => this.Name();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses failover group operations.</param>
        ///GENMHASH:10321C7CB3A1E7C461BBEBEAA7FCEB2A:D04715006C36394109746FEBD7928CCE
        internal SqlFailoverGroupImpl(string name, SqlServerImpl parent, FailoverGroupInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName;
            this.sqlServerName = parent.Name;
            this.sqlServerLocation = parent.RegionName;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses failover group operations.</param>
        ///GENMHASH:2FFBF1911C3D11A4A0D6DB160D9678D8:A6FEE4EFEDACA027A0C59D9323BFCAC7
        internal SqlFailoverGroupImpl(string resourceGroupName, string sqlServerName, string sqlServerLocation, string name, FailoverGroupInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerLocation = sqlServerLocation;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses failover group operations.</param>
        ///GENMHASH:FFACBC94C1D9864074BFA5694BF5256F:8A4C506BC6C1E988E601BB237AB86255
        internal SqlFailoverGroupImpl(string name, FailoverGroupInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            if (innerObject != null && innerObject.Id != null)
            {
                if (innerObject.Id != null)
                {
                    ResourceId resourceId = ResourceId.FromString(innerObject.Id);
                    this.resourceGroupName = resourceId.ResourceGroupName;
                    this.sqlServerName = resourceId.Parent.Name;
                    this.sqlServerLocation = innerObject.Location;
                }
            }
        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:59D8987F7EC078423F8247D1F7D40FBD:D2670680EF14BA9058384CB186AA4289
        public string ReplicationState()
        {
            return this.Inner.ReplicationState;
        }

        ///GENMHASH:C73D1F1D079CEECCF50424619696E723:2AA531F593D8FD511740FF63460BAB25
        public SqlFailoverGroupImpl WithDatabaseIds(params string[] ids)
        {
            this.Inner.Databases = new List<String>();
            foreach(var id in ids)
            {
                this.Inner.Databases.Add(id);
            }

            return this;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return this.Inner.Location;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:ECB4548536225101A4FBA7DFDB22FE6D
        public SqlFailoverGroupImpl Update()
        {
            // This is the beginning of the update flow
            return this;
        }

        ///GENMHASH:0F77D8DDF25E08872FE274A3A166ADE5:6C95377B4560A9605FABA3A3ABEA3DD7
        public SqlFailoverGroupImpl WithReadOnlyEndpointPolicyEnabled()
        {
            if (this.Inner.ReadOnlyEndpoint == null)
            {
                this.Inner.ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint();
            }
            this.Inner.ReadOnlyEndpoint.FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Enabled;

            return this;
        }

        ///GENMHASH:96605E96D2B00E4658FBEC921BFDAEDB:890AE0BD0FB219762BA5213F6C979CED
        public SqlFailoverGroupImpl WithAutomaticReadWriteEndpointPolicyAndDataLossGracePeriod(int gracePeriodInMinutes)
        {
            if (this.Inner.ReadWriteEndpoint == null)
            {
                this.Inner.ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint();
            }
            this.Inner.ReadWriteEndpoint.FailoverPolicy = ReadWriteEndpointFailoverPolicy.Automatic;
            this.Inner.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = gracePeriodInMinutes;
            return this;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:B061CBC11BB55C3C2C792B41D582EF90
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:30CAC49BAB6546B97833BEE6FBF589B0
        protected async Task<Models.FailoverGroupInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.FailoverGroups
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:A4C5627076EA958957EDF76AFF379813:3360AEDBB627D649CA421A9FD4E7987C
        public SqlFailoverGroupImpl WithManualReadWriteEndpointPolicy()
        {
            if (this.Inner.ReadWriteEndpoint == null)
            {
                this.Inner.ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint();
            }
            this.Inner.ReadWriteEndpoint.FailoverPolicy = ReadWriteEndpointFailoverPolicy.Manual;
            this.Inner.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = null;
            return this;
        }

        ///GENMHASH:B24A79172321D553084B735FBB0E7713:DF6A01D48A9534BC9AC582CF0EEDF4ED
        public SqlFailoverGroupImpl WithNewDatabaseId(string id)
        {
            return this.WithDatabaseId(id);
        }

        ///GENMHASH:02E62DCF3FCAA41C259D744B0174DC48:396C9E3144E9E77A131581AAEBCF990D
        public FailoverGroupReplicationRole ReplicationRole()
        {
            return this.Inner.ReplicationRole;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:E462F242E1761228E205CEE8F760EDF9
        public SqlFailoverGroupImpl WithTags(IDictionary<string,string> tags)
        {
            this.Inner.Tags = new Dictionary<string,string>(tags);
            return this;
        }

        ///GENMHASH:20379C1CF9C8A8BD14B895EC33C6ABAF:9D9A4A7AA91755F446D78C73DA17C23B
        public IReadOnlyList<Models.PartnerInfo> PartnerServers()
        {
            List<Models.PartnerInfo> result = new List<PartnerInfo>();
            if (this.Inner.PartnerServers != null)
            {
                result.AddRange(this.Inner.PartnerServers);
            }
            return result.AsReadOnly();
        }

        ///GENMHASH:66F8434BF34E8FA8C73DB8696A7EEB2C:A7C977C528FF94419AB1543C350B4DE1
        public SqlFailoverGroupImpl WithReadOnlyEndpointPolicyDisabled()
        {
            if (this.Inner.ReadOnlyEndpoint == null)
            {
                this.Inner.ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint();
            }
            this.Inner.ReadOnlyEndpoint.FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Disabled;
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:35FBF194AC594444C9765ECADC1188F7:691378AE1888BF331479823D2FB2B948
        public int ReadWriteEndpointDataLossGracePeriodMinutes()
        {
            return this.Inner.ReadWriteEndpoint != null ? this.Inner.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes.GetValueOrDefault(0) : 0;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:16AD01F8BDD93611BB283CC787483C90
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:A3C80C2E1D3C644B36853F85D52AB3A1
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFailoverGroup> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ SqlFailoverGroupImpl self = this;
            if (this.Inner.Location == null)
            {
                this.Inner.Location = this.sqlServerLocation;
            }
            var failoverGroupInner = await this.sqlServerManager.Inner.FailoverGroups
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), this.Inner, cancellationToken);
            this.SetInner(failoverGroupInner);
            return this;
        }

        ///GENMHASH:24DCA35ADCDF86A8A58340A3C0947F91:C0E448625A6CEF0869254B602F9C3284
        public ReadWriteEndpointFailoverPolicy ReadWriteEndpointPolicy()
        {
            return this.Inner.ReadWriteEndpoint?.FailoverPolicy;
        }

        ///GENMHASH:DF46C62E0E8998CD0340B3F8A136F135:A2E155D6CABB052D1DD1A6832C1DAA75
        public IReadOnlyList<string> Databases()
        {
            List<string> result = new List<string>();
            if (this.Inner.Databases != null)
            {
                result.AddRange(this.Inner.Databases);
            }
            return result.AsReadOnly();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:D6AE50211DB2EC346F816A0DDC4845EA
        public SqlFailoverGroupImpl WithoutTag(string key)
        {
            if (this.Inner.Tags != null) {
                this.Inner.Tags.Remove(key);
            }
            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:546F275F5C716DBA4B4E3ED283223400:C9AFE281174DD8EB14C99E6BBD807BF6
        public SqlFailoverGroupImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName, string sqlServerLocation)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerLocation = sqlServerLocation;
            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:29E97F88060ECB7FAB4757A4A7DF3007
        public SqlFailoverGroupImpl WithExistingSqlServer(ISqlServer sqlServer)
        {
            this.resourceGroupName = sqlServer.ResourceGroupName;
            this.sqlServerName = sqlServer.Name;
            this.sqlServerLocation = sqlServer.RegionName;
            return this;
        }

        ///GENMHASH:4C8578EFF3D217B6EA41794FE6A88D90:6B0C5C338A1A92F53A398DAF56A562D3
        public SqlFailoverGroupImpl WithDatabaseId(string id)
        {
            if (this.Inner.Databases == null)
            {
                this.Inner.Databases = new List<string>();
            }
            this.Inner.Databases.Add(id);
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:2DC6B3BEB4C8A428A0339820143BFEB3
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:3E9F81F446FDF2A19095DC13C7608416
        public IReadOnlyDictionary<string,string> Tags()
        {
            return (Dictionary<string, string>)this.Inner.Tags;
        }

        ///GENMHASH:611FC8A9A0FAF341CC4E6B86DEC5706D:582413C777F5A88C5E3C9F9E04423F02
        public SqlFailoverGroupImpl WithoutDatabaseId(string id)
        {
            if (this.Inner.Databases != null)
            {
                this.Inner.Databases.Remove(id);
            }
            return this;
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:763203E811F074BDB99DB2C358722526
        public SqlFailoverGroupImpl WithTag(string key, string value)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }
            Inner.Tags[key] = value;
            return this;
        }

        ///GENMHASH:4F39D9594546CC718D25003EDD94C8D2:BA490544FC6653B09C582938721E6C2A
        public ReadOnlyEndpointFailoverPolicy ReadOnlyEndpointPolicy()
        {
            return this.Inner.ReadOnlyEndpoint?.FailoverPolicy;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:72DE68F02B89E29132C1E5F2740CF122
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.FailoverGroups
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:6475F0E6B085A35B081FA09FFCBDDBF8
        public Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.Inner.Location);
        }

        ///GENMHASH:E298356333CE068A7E11D11B4BD192D2:61A9A437F28382C465CD3D2A914CA8EA
        public SqlFailoverGroupImpl WithPartnerServerId(string id)
        {
            this.Inner.PartnerServers = new List<PartnerInfo>();
            this.Inner.PartnerServers.Add(new PartnerInfo(){ Id = id });
            return this;
        }

        public ISqlFailoverGroup Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlFailoverGroup> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlFailoverGroup Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlFailoverGroup> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }

        public ISqlFailoverGroup Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlFailoverGroup> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }
    }
}