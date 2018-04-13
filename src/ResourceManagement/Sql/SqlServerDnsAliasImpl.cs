// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerDnsAliasOperations.SqlServerDnsAliasOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Implementation for SqlServerDnsAlias.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJEbnNBbGlhc0ltcGw=
    internal partial class SqlServerDnsAliasImpl :
        ChildResource<
            Models.ServerDnsAliasInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlServerDnsAlias,
        ISqlServerDnsAliasOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private string name;

        string ICreatable<ISqlServerDnsAlias>.Name => this.Name();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:6EB3A0B36FAECA791EFBB40C3F76F7E2:FC8025F8B79091C30C130C9AAECEC55E
        internal SqlServerDnsAliasImpl(string name, SqlServerImpl parent, ServerDnsAliasInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = parent.ResourceGroupName;
            this.sqlServerName = parent.Name;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:F6E88B09AC6260EB63A570307518001D:38F5303BD24DCCFCF927664812C8523C
        internal SqlServerDnsAliasImpl(string resourceGroupName, string sqlServerName, string name, ServerDnsAliasInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses DNS alias operations.</param>
        ///GENMHASH:288BB2F1178A7F50CBD9A307E67BDFB9:394B41296E95933E362FA2C6FB5E1428
        internal SqlServerDnsAliasImpl(string name, ServerDnsAliasInner innerObject, ISqlManager sqlServerManager)
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
                }
            }
        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:F4658130CC69EFC4BCEC371A932CA322:93FFFDCDC68A9A454B56689F7777C24E
        public SqlServerDnsAliasImpl WithExistingSqlServerId(string sqlServerId)
        {
            ResourceId resourceId = ResourceId.FromString(sqlServerId);
            this.resourceGroupName = resourceId.ResourceGroupName;
            this.sqlServerName = resourceId.Name;
            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:0BA2C0DAE27266D79653208FF06A9B80:99EDD7AD8CCAED9BC095807A7E85DE17
        public SqlServerDnsAliasImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:303BB606C8439FAB777DDCE1767E86E9
        public SqlServerDnsAliasImpl WithExistingSqlServer(ISqlServer sqlServer)
        {
            this.resourceGroupName = sqlServer.ResourceGroupName;
            this.sqlServerName = sqlServer.Name;
            return this;
        }

        ///GENMHASH:481C5BD52B28860819AE7BB31A646B75:9D385BED2B37376E10BD9B753B53CA59
        public string AzureDnsRecord()
        {
            return this.Inner.AzureDnsRecord;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:DDDB0698C2ABADC0443C1F8E57C83AD8
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:83CA15F39854FC167786AB594BA5E27A
        protected async Task<Models.ServerDnsAliasInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.ServerDnsAliases
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:2DC6B3BEB4C8A428A0339820143BFEB3
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:9E5F63F5A2A804B72CFD1E2E0B23C31A
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ServerDnsAliases
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:16AD01F8BDD93611BB283CC787483C90
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:986A9A19092BED34F1F296126196EE63
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerDnsAlias> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverDnsAliasInner = await this.sqlServerManager.Inner.ServerDnsAliases
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
            this.SetInner(serverDnsAliasInner);
            return this;
        }

        public ISqlServerDnsAlias Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlServerDnsAlias> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlServerDnsAlias Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlServerDnsAlias> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }
    }
}