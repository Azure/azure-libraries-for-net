// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyOperationsDefinition;
    using System;

    /// <summary>
    /// Implementation for SQL Server Key interface.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJLZXlJbXBs
    internal partial class SqlServerKeyImpl  :
        ChildResource<
            Models.ServerKeyInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlServerKey,
        IUpdate,
        ISqlServerKeyOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private string serverKeyName;

        string ICreatable<ISqlServerKey>.Name => this.Name();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="serverKeyName">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:8DC05BF94897E82ED9B14D4ACE761E71:385B5B4D5CE77CC6BDE66FA1392BE5E2
        internal SqlServerKeyImpl(string serverKeyName, SqlServerImpl parent, ServerKeyInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            this.serverKeyName = serverKeyName;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName;
            this.sqlServerName = parent.Name;
            if (innerObject != null && innerObject.Name != null)
            {
                this.serverKeyName = innerObject.Name;
            }
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="serverKeyName">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:6B050084A46B8D60E8F4584F8E20045C:B9627F8810194331D0435FC3AC3F61E2
        internal SqlServerKeyImpl(string resourceGroupName, string sqlServerName, string serverKeyName, ServerKeyInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.serverKeyName = serverKeyName;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            if (innerObject != null && innerObject.Name != null)
            {
                this.serverKeyName = innerObject.Name;
            }
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="serverKeyName">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:137DAACD2261698E82334933A0868D1A:889083AF977CA8FF77804D3045E866B0
        internal SqlServerKeyImpl(string serverKeyName, ServerKeyInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.serverKeyName = serverKeyName;
            this.sqlServerManager = sqlServerManager;
            if (innerObject != null && innerObject.Id != null)
            {
                if (innerObject.Id != null)
                {
                    ResourceId resourceId = ResourceId.FromString(innerObject.Id);
                    this.resourceGroupName = resourceId.ResourceGroupName;
                    this.sqlServerName = resourceId.Parent.Name;
                }
            }
            if (innerObject != null && innerObject.Name != null)
            {
                this.serverKeyName = innerObject.Name;
            }
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:03B7E74B9CEC907229FC7E3E3FC8EFC4
        public override string Name()
        {
            return this.serverKeyName;
        }

        ///GENMHASH:69682825EBBC81814AD1914F79080C3A:842E861459B1C0CB42302534E5479B32
        public SqlServerKeyImpl WithCreationDate(DateTime creationDate)
        {
            this.Inner.CreationDate = creationDate;
            return this;
        }

        ///GENMHASH:C608B2A3A894C122878626FA09D94406:BE33F46EDC996DB65B7F46EC68568C24
        public SqlServerKeyImpl WithAzureKeyVaultKey(string uri)
        {
            this.Inner.ServerKeyType = Models.ServerKeyType.AzureKeyVault;
            this.Inner.Uri = uri;
            // If the key URI is "https://YourVaultName.Vault.Azure.Net/keys/YourKeyName/01234567890123456789012345678901",
            // then the Server Key Name should be formatted as: "YourVaultName_YourKeyName_01234567890123456789012345678901"
            string[] items = uri.Split('/');
            string vaultName = items[2].Split('.')[0];
            string keyName = items[4];
            string keyVersion = items[5];
            this.serverKeyName = $"{vaultName}_{keyName}_{keyVersion}";
            return this;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:F4658130CC69EFC4BCEC371A932CA322:93FFFDCDC68A9A454B56689F7777C24E
        public SqlServerKeyImpl WithExistingSqlServerId(string sqlServerId)
        {
            ResourceId resourceId = ResourceId.FromString(sqlServerId);
            this.resourceGroupName = resourceId.ResourceGroupName;
            this.sqlServerName = resourceId.Name;
            return this;
        }

        ///GENMHASH:0BA2C0DAE27266D79653208FF06A9B80:99EDD7AD8CCAED9BC095807A7E85DE17
        public SqlServerKeyImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:303BB606C8439FAB777DDCE1767E86E9
        public SqlServerKeyImpl WithExistingSqlServer(ISqlServer sqlServer)
        {
            this.resourceGroupName = sqlServer.ResourceGroupName;
            this.sqlServerName = sqlServer.Name;
            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:C4C0D4751CA4E1904C31CE6DF0B02AC3:B30E59DD4D927FB508DCE8588A7B6C5E
        public string Kind()
        {
            return this.Inner.Kind;
        }

        ///GENMHASH:8F04665E49050E6C5BD8AE7B8E51D285:48C470FF98C85D0D802E5FBBD537EFBE
        public string Thumbprint()
        {
            return this.Inner.Thumbprint;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:ECB4548536225101A4FBA7DFDB22FE6D
        public IUpdate Update()
        {
            // This is the beginning of the update flow
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime? CreationDate()
        {
            return this.Inner.CreationDate;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:3786FB00D889F65D2C5CF68F149417EF
        protected async Task<Models.ServerKeyInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.ServerKeys
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:39E79EEEBE800C0263D7785D2CDD0C8F:AA25005E7A9BAF367EA281FE0DB49192
        public string Uri()
        {
            return this.Inner.Uri;
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:726B0151F14FA259F60B23BB30BA58ED
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:2DC6B3BEB4C8A428A0339820143BFEB3
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:6A5C79A9C5D9A772C2F79EEC7408E4A4:13FE8C3F53ABBA3F908A2B33CEEFD2C4
        public Models.ServerKeyType ServerKeyType()
        {
            return this.Inner.ServerKeyType;
        }

        ///GENMHASH:C328A6C57E45D555550A2B8B142E5726:47A589BC17554904E71921D34179D9C3
        public SqlServerKeyImpl WithThumbprint(string thumbprint)
        {
            this.Inner.Thumbprint = thumbprint;
            return this;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:CF8EB77E38A9B0B910211F0DE0E3B050
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ServerKeys
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:16AD01F8BDD93611BB283CC787483C90
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:6475F0E6B085A35B081FA09FFCBDDBF8
        public Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region()
        {
            return this.Inner.Location != null ? Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.Inner.Location) : null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:9C622B7760E8AA499BCF909CBA2DEBA0
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverKeyInner = await this.sqlServerManager.Inner.ServerKeys
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.serverKeyName, this.Inner, cancellationToken);
            this.SetInner(serverKeyInner);
            return this;
        }

        public ISqlServerKey Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlServerKey> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlServerKey Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlServerKey> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }

        public ISqlServerKey Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlServerKey> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }
    }
}