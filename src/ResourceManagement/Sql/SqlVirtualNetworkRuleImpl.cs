// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.SqlVirtualNetworkRuleDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for SQL Virtual Network Rule interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxWaXJ0dWFsTmV0d29ya1J1bGVJbXBs
    internal partial class SqlVirtualNetworkRuleImpl  :
        ChildResource<
            Models.VirtualNetworkRuleInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlVirtualNetworkRule,
        ISqlVirtualNetworkRuleDefinition<SqlServer.Definition.IWithCreate>,
        IUpdate,
        ISqlVirtualNetworkRuleOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private readonly string name;

        string IExternalChildResource<ISqlVirtualNetworkRule, ISqlServer>.Id => this.Id();

        string ICreatable<ISqlVirtualNetworkRule>.Name => this.Name();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses virtual network rule operations.</param>
        ///GENMHASH:CA7A55F651B9410EBED64BE12665922C:FC8025F8B79091C30C130C9AAECEC55E
        internal SqlVirtualNetworkRuleImpl(string name, SqlServerImpl parent, VirtualNetworkRuleInner innerObject, ISqlManager sqlServerManager)
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
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses virtual network rule operations.</param>
        ///GENMHASH:15D09AA40D1E49BAFFA483194CA7F8F9:38F5303BD24DCCFCF927664812C8523C
        internal SqlVirtualNetworkRuleImpl(string resourceGroupName, string sqlServerName, string name, VirtualNetworkRuleInner innerObject, ISqlManager sqlServerManager)
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
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses virtual network rule operations.</param>
        ///GENMHASH:C3506602CF08EAFA0BE1B56C9336CFEB:968B76841C5C84C8B755ABCB990B620A
        internal SqlVirtualNetworkRuleImpl(string name, VirtualNetworkRuleInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager;
        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:A46525F44B70758E2EDBD761F1C43440:92EB9A708763B9D5C63468FF0C600A35
        public string SubnetId()
        {
            return this.Inner.VirtualNetworkSubnetId;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:F4658130CC69EFC4BCEC371A932CA322:93FFFDCDC68A9A454B56689F7777C24E
        public SqlVirtualNetworkRuleImpl WithExistingSqlServerId(string sqlServerId)
        {
            ResourceId resourceId = ResourceId.FromString(sqlServerId);
            this.resourceGroupName = resourceId.ResourceGroupName;
            this.sqlServerName = resourceId.Name;
            return this;
        }

        ///GENMHASH:9047F7688B1B60794F60BC930616198C:69B21479BF96015C28CC0274593A13EB
        public SqlVirtualNetworkRuleImpl WithSubnet(string networkId, string subnetName)
        {
            this.Inner.VirtualNetworkSubnetId = $"{networkId}/subnets/{subnetName}";
            this.Inner.IgnoreMissingVnetServiceEndpoint = false;
            return this;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:0BA2C0DAE27266D79653208FF06A9B80:99EDD7AD8CCAED9BC095807A7E85DE17
        public SqlVirtualNetworkRuleImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:29B0399E75CADE64EBE14362E52E6A76
        public SqlVirtualNetworkRuleImpl WithExistingSqlServer(ISqlServer sqlServer)
        {
            this.resourceGroupName = sqlServer.ResourceGroupName;
            this.sqlServerName = sqlServer.Name;
            return this;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:FF9561965B2D28AAEC739E970ABAF8A6
        public SqlVirtualNetworkRuleImpl Update()
        {
            // This is the beginning of the update flow
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:F0A86F6F081E686B62AB24EECDB2648B
        protected async Task<Models.VirtualNetworkRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.VirtualNetworkRules
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:8988F7617ACF68410043B18AFD435468
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:BF44555315B4D8F7DE5B31B09438FA0A
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:5C88D57DEF9030E526427BA1169297A1:2C197CFAF15BFB7C44324342140CAD7E
        public SqlVirtualNetworkRuleImpl IgnoreMissingSqlServiceEndpoint()
        {
            this.Inner.IgnoreMissingVnetServiceEndpoint = true;
            return this;
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:6AA54A9FAF0D796CAD9E217D342BCCBD
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.VirtualNetworkRules
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:DE00F46E354F87702D166797DDFD33DE
        public string State()
        {
            return this.Inner.State.ToString();
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:DC89C61DA7F39844028024C6079D3A9A
        public SqlServerImpl Attach()
        {
            return Parent;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:16AD01F8BDD93611BB283CC787483C90
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync();
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:F1A8DA4C647F18C83178DFA99107C526
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlVirtualNetworkRule> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var virtualNetworkRuleInner = await this.sqlServerManager.Inner.VirtualNetworkRules
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), this.Inner, cancellationToken);
            this.SetInner(virtualNetworkRuleInner);
            return this;
        }

        public ISqlVirtualNetworkRule Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlVirtualNetworkRule> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlVirtualNetworkRule Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlVirtualNetworkRule> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        public ISqlVirtualNetworkRule Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlVirtualNetworkRule> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }
    }
}