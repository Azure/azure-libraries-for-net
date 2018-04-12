// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.SqlFirewallRuleDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleOperationsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Implementation for SqlFirewallRule.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxGaXJld2FsbFJ1bGVJbXBs
    internal partial class SqlFirewallRuleImpl  :
        ChildResource<
            Models.FirewallRuleInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer>,
        ISqlFirewallRule,
        ISqlFirewallRuleDefinition<SqlServer.Definition.IWithCreate>,
        IUpdate,
        ISqlFirewallRuleOperationsDefinition
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private readonly string name;

        string IExternalChildResource<ISqlFirewallRule, ISqlServer>.Id => this.Id();

        string ICreatable<ISqlFirewallRule>.Name => this.Name();

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:FBD2653CF03CDE7024099A670DE9C740:FC8025F8B79091C30C130C9AAECEC55E
        internal SqlFirewallRuleImpl(string name, SqlServerImpl parent, FirewallRuleInner innerObject, ISqlManager sqlServerManager)
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
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:98175C6855AA8B2080D04920E0A82153:38F5303BD24DCCFCF927664812C8523C
        internal SqlFirewallRuleImpl(string resourceGroupName, string sqlServerName, string name, FirewallRuleInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="sqlServerManager">Reference to the SQL server manager that accesses firewall rule operations.</param>
        ///GENMHASH:E45662683A7C9870BC41CEA0BE7F6F74:968B76841C5C84C8B755ABCB990B620A
        internal SqlFirewallRuleImpl(string name, FirewallRuleInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, null)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:CB9DB57843AB6E4303AAE390868D1BAC:5C7A723A6F64FCFB9140B05B06F70115
        public SqlFirewallRuleImpl WithIPAddressRange(string startIPAddress, string endIPAddress)
        {
            this.Inner.StartIpAddress = startIPAddress;
            this.Inner.EndIpAddress = endIPAddress;
            return this;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:F4658130CC69EFC4BCEC371A932CA322:E8EBD41FC317E2B3715907DDA546F071
        public SqlFirewallRuleImpl WithExistingSqlServerId(string sqlServerId)
        {
            if (sqlServerId == null)
            {
                throw new ArgumentNullException(sqlServerId);
            }
            var resourceId = ResourceId.FromString(sqlServerId);
            this.resourceGroupName = resourceId.ResourceGroupName;
            this.sqlServerName = resourceId.Parent.Name;
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

        ///GENMHASH:0BA2C0DAE27266D79653208FF06A9B80:99EDD7AD8CCAED9BC095807A7E85DE17
        public SqlFirewallRuleImpl WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            return this;
        }

        ///GENMHASH:A0EEAA3D4BFB322B5036FE92D9F0F641:29B0399E75CADE64EBE14362E52E6A76
        public SqlFirewallRuleImpl WithExistingSqlServer(ISqlServer sqlServer)
        {
            if (sqlServer == null)
            {
                throw new ArgumentNullException("sqlServer");
            }
            this.resourceGroupName = sqlServer.ResourceGroupName;
            this.sqlServerName = sqlServer.Name;
            return this;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:FF9561965B2D28AAEC739E970ABAF8A6
        public SqlFirewallRuleImpl Update()
        {
            // This is the beginning of the update flow
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:95BA1017B6D636BB0934427C9B74AB8D
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteResourceAsync(cancellationToken);
        }

        ///GENMHASH:944BF1730016EB109BA8A7D6EE074FD9:1072F4F290D556553749A7EA2370D9F0
        public SqlFirewallRuleImpl WithIPAddress(string ipAddress)
        {
            this.Inner.StartIpAddress = ipAddress;
            this.Inner.EndIpAddress = ipAddress;
            return this;
        }

        ///GENMHASH:C1E3413669867747034C02C2329DD39B:E2EB90CF1BFD48AF581DD19E19A48783
        public string StartIPAddress()
        {
            return this.Inner.StartIpAddress;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:6475F0E6B085A35B081FA09FFCBDDBF8
        public Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.Inner.Location);
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:BF44555315B4D8F7DE5B31B09438FA0A
        public string ParentId()
        {
            var resourceId = ResourceId.FromString(this.Id());
            return resourceId?.Parent?.Id;
        }

        ///GENMHASH:7241C302E05E6362ED84F83841897A2B:C413F63A68B9B21773832133B73FB030
        public SqlFirewallRuleImpl WithStartIPAddress(string startIPAddress)
        {
            this.Inner.StartIpAddress = startIPAddress;
            return this;
        }

        ///GENMHASH:0C5E39F302A53FC29B8AFC7645FA0F96:0E617A4FA7C8B0429E44FA81A0CA93AE
        public string EndIPAddress()
        {
            return this.Inner.EndIpAddress;
        }

        ///GENMHASH:62BB0F8B019F6D9645BBDD77CCB80904:4995E806CCF68C324CE286E4AE18FE58
        public SqlFirewallRuleImpl WithEndIPAddress(string endIPAddress)
        {
            this.Inner.EndIpAddress = endIPAddress;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:DC89C61DA7F39844028024C6079D3A9A
        public SqlServerImpl Attach()
        {
            return Parent;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:549639F830E0137C746BE5751A23BCB6
        protected async Task<Models.FirewallRuleInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.FirewallRules
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:8988F7617ACF68410043B18AFD435468
        public void Delete()
        {
            Extensions.Synchronize(() => this.DeleteAsync());
        }

        ///GENMHASH:E24A9768E91CD60E963E43F00AA1FDFE:4B2CFB36E952F3DE1A0D0F78ECCDBBE5
        public async Task DeleteResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.FirewallRules
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.Name(), cancellationToken);
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:E5EB92EEBCF487ABD197EC50965C296B
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:E5EB92EEBCF487ABD197EC50965C296B
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlFirewallRule> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.sqlServerManager.Inner.FirewallRules
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Name(), this.Inner, cancellationToken);
            this.SetInner(inner);
            return inner != null ? this : null;
        }

        public ISqlFirewallRule Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        public async Task<ISqlFirewallRule> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }

        public ISqlFirewallRule Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ISqlFirewallRule> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlFirewallRule Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        public async Task<ISqlFirewallRule> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.CreateResourceAsync(cancellationToken);
        }
    }
}