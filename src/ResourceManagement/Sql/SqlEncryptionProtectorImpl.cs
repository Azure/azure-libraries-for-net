// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtector.Update;

    /// <summary>
    /// Implementation for SqlEncryptionProtector interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbmNyeXB0aW9uUHJvdGVjdG9ySW1wbA==
    internal partial class SqlEncryptionProtectorImpl :
        ChildResource<
            Models.EncryptionProtectorInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlEncryptionProtector,
        IUpdate
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private string serverKeyName;

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:037B6E72FFBB7224CDF82D509814DF07:925E12E2AB778ADEA6FAE0AE9F9184C7
        internal SqlEncryptionProtectorImpl(SqlServerImpl parent, EncryptionProtectorInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName;
            this.sqlServerName = parent.Name;
            this.serverKeyName = innerObject?.Name;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:B9BEF73056A0E29FFD8BF2E062D7BC15:43162FE085CFEAFDA76E5D4BC4A00355
        internal SqlEncryptionProtectorImpl(string resourceGroupName, string sqlServerName, EncryptionProtectorInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.serverKeyName = innerObject?.Name;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:4DD6445361F09E0B185DE0E8D24170D3:81D0EDB620000F6B86DC1403C1548E6A
        internal SqlEncryptionProtectorImpl(EncryptionProtectorInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.sqlServerManager = sqlServerManager;
            if (innerObject?.Id != null)
            {
                ResourceId resourceId = ResourceId.FromString(innerObject.Id);
                this.resourceGroupName = resourceId.ResourceGroupName;
                this.sqlServerName = resourceId.Parent.Name;
            }
            this.serverKeyName = innerObject?.Name;
        }

        public override string Name()
        {
            return this.Inner?.Name;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:6485A67119B54B835368ADA812A96C10:EEFF62BBC201203BB09A9D9FE63B14EC
        public string ServerKeyName()
        {
            return this.Inner.ServerKeyName;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:03B7E74B9CEC907229FC7E3E3FC8EFC4
        public string SqlServerName()
        {
            return this.serverKeyName;
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

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:40A980295F5EA8FF8304DA8C06E899BF
        public SqlEncryptionProtectorImpl Update()
        {
            return this;
        }

        ///GENMHASH:39E79EEEBE800C0263D7785D2CDD0C8F:AA25005E7A9BAF367EA281FE0DB49192
        public string Uri()
        {
            return this.Inner.Uri;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:2EA6F22A1E9075415416C51D51B2ED7C
        protected async Task<Models.EncryptionProtectorInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.EncryptionProtectors
                .GetAsync(this.resourceGroupName, this.sqlServerName, cancellationToken);
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

        ///GENMHASH:2688473C4BAFA54B9FD7ABA11C3C5F8B:D566CA13B0B70C2E92E17CAEA81BBA31
        public SqlEncryptionProtectorImpl WithServiceManagedServerKey()
        {
            this.Inner.ServerKeyName = "ServiceManaged";
            this.Inner.ServerKeyType = Models.ServerKeyType.ServiceManaged;
            return this;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:AC7D8FFF4C733C02A85F39DEEAB80B76
        public Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException("Operation not supported");
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:BF5A6EF11B034B3808270F4EF75EB5E0:12F32780E905DD94F4F7DE7FBFB88FCE
        public SqlEncryptionProtectorImpl WithAzureKeyVaultServerKey(string serverKeyName)
        {
            this.Inner.ServerKeyName = serverKeyName;
            this.Inner.ServerKeyType = Models.ServerKeyType.AzureKeyVault;
            return this;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:6475F0E6B085A35B081FA09FFCBDDBF8
        public Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.Inner.Location);
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:4C4C4336C86119672D7AD1E0D4BD29CB
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:06F8F4D881AC3D94F49CECB6153B5A83
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var encryptionProtectorInner = await this.sqlServerManager.Inner.EncryptionProtectors
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Inner, cancellationToken);
            this.SetInner(encryptionProtectorInner);
            return this;
        }

        public ISqlEncryptionProtector Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlEncryptionProtector> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlEncryptionProtector Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlEncryptionProtector> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }
    }
}