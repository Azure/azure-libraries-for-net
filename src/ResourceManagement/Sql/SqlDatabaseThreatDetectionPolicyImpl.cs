// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.SqlDatabaseThreatDetectionPolicyDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update;

    /// <summary>
    /// Implementation for SQL database threat detection policy.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZVRocmVhdERldGVjdGlvblBvbGljeUltcGw=
    internal partial class SqlDatabaseThreatDetectionPolicyImpl  :
        ChildResource<
            Models.DatabaseSecurityAlertPolicyInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        ISqlDatabaseThreatDetectionPolicy,
        ISqlDatabaseThreatDetectionPolicyDefinition,
        IUpdate
    {
        private ISqlManager sqlServerManager;
        private string resourceGroupName;
        private string sqlServerName;
        private readonly string name;

        string ICreatable<ISqlDatabaseThreatDetectionPolicy>.Name => this.Name();

        string IExternalChildResource<ISqlDatabaseThreatDetectionPolicy, ISqlDatabase>.Id => this.Id();

        ///GENMHASH:8C0F9272C19DF7D7DC0E56025F2253DB:0FC663881AA56E17333FD4B5C3288CB4
        public SqlDatabaseThreatDetectionPolicyImpl(string name, SqlDatabaseImpl parent, DatabaseSecurityAlertPolicyInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject, parent)
        {
            this.name = name;
            this.sqlServerManager = sqlServerManager ?? throw new ArgumentNullException("sqlServerManager");
            this.resourceGroupName = parent.ResourceGroupName();
            this.sqlServerName = parent.SqlServerName();
            this.Inner.Location = parent.RegionName();
        }

        public override string Name()
        {
            return this.name;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:66D153D24EDDD15E42A3CBB960F112C5
        protected async Task<Models.DatabaseSecurityAlertPolicyInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.DatabaseThreatDetectionPolicies
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.Parent.Name(), cancellationToken);
        }

        public async Task<ISqlDatabaseThreatDetectionPolicy> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await CreateResourceAsync(cancellationToken);
        }

        public ISqlDatabaseThreatDetectionPolicy Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync());
        }

        public async Task<ISqlDatabaseThreatDetectionPolicy> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await GetInnerAsync(cancellationToken));
            return this;
        }

        public ISqlDatabaseThreatDetectionPolicy Create()
        {
            return Extensions.Synchronize(() => CreateAsync());
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:ECB4548536225101A4FBA7DFDB22FE6D
        public SqlDatabaseThreatDetectionPolicyImpl Update()
        {
            // This is the beginning of the update flow
            return this;
        }

        public ISqlDatabaseThreatDetectionPolicy Apply()
        {
            return Extensions.Synchronize(() => ApplyAsync());
        }

        public async Task<ISqlDatabaseThreatDetectionPolicy> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            return await this.UpdateResourceAsync(cancellationToken);
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:4C4C4336C86119672D7AD1E0D4BD29CB
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await CreateResourceAsync(cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:5463608543545841B01F4CC38FD3ED2F
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var innerResult = await this.sqlServerManager.Inner.DatabaseThreatDetectionPolicies
                .CreateOrUpdateAsync(this.resourceGroupName, this.sqlServerName, this.Parent.Name(), this.Inner, cancellationToken);
            this.SetInner(innerResult);
            return this;
        }

        ///GENMHASH:850B3E0E04CD0AAEDFED91415D881204:90F57A5386EA23B61460BB4D16797DF5
        public SqlDatabaseThreatDetectionPolicyImpl WithRetentionDays(int retentionDays)
        {
            this.Inner.RetentionDays = retentionDays;
            return this;
        }

        ///GENMHASH:3E8B0CC5171559AE65A2F7F53ECB0B58:DD3C93D4FF0304D39E0366249039B7D2
        public SqlDatabaseThreatDetectionPolicyImpl WithDefaultSecurityAlertPolicy()
        {
            this.Inner.UseServerDefault = SecurityAlertPolicyUseServerDefault.Enabled;
            return this;
        }

        ///GENMHASH:DE79EC0ABE125335FAF1EAD311946E27:73339C0D07683D9EF203114A4DF999F7
        public string DisabledAlerts()
        {
            return this.Inner.DisabledAlerts;
        }

        ///GENMHASH:3F8B943B539AA3FED800BB3514CA47DA:1A2FDCDA47929D251D5FEC57FA5FCE30
        public SqlDatabaseThreatDetectionPolicyImpl WithPolicyNew()
        {
            this.Inner.UseServerDefault = SecurityAlertPolicyUseServerDefault.Disabled;
            this.Inner.State = SecurityAlertPolicyState.New;
            return this;
        }

        ///GENMHASH:4A5895003C259D1D5B0026DEB6F6A14C:CCEAC01DAEC73CDAEC0F44F318CA39D6
        public SqlDatabaseThreatDetectionPolicyImpl WithoutEmailToAccountAdmins()
        {
            this.Inner.EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Disabled;
            return this;
        }

        ///GENMHASH:B9573D75ABAB60A04E4BBE2E2689BFD8:A0E01C0EB2C00F0B2EE870A93E85018A
        public string EmailAddresses()
        {
            return this.Inner.EmailAddresses;
        }

        ///GENMHASH:07AF9F940CE3DFB3A10677B53AE6C972:3B8085F17D7BC9CD9E4EDEE126451CEA
        public int RetentionDays()
        {
            return this.Inner.RetentionDays.GetValueOrDefault();
        }

        ///GENMHASH:FF7FF17479CE5841E23D74581D3F4BE5:3E1BC44276C33E698562A25B4E1164F9
        public string StorageAccountAccessKey()
        {
            return this.Inner.StorageAccountAccessKey;
        }

        ///GENMHASH:F00B47C9CEB3B766E322322749884715:EBF77126771AECE4DF1E32678DEA5747
        public SqlDatabaseThreatDetectionPolicyImpl WithPolicyEnabled()
        {
            this.Inner.UseServerDefault = SecurityAlertPolicyUseServerDefault.Disabled;
            this.Inner.State = SecurityAlertPolicyState.Enabled;
            return this;
        }

        ///GENMHASH:B538B15A44978B33049F9DA6693BEBB7:8450D73CA6F2536F92661BB4CE231E42
        public SqlDatabaseThreatDetectionPolicyImpl WithEmailToAccountAdmins()
        {
            this.Inner.EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled;
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:5A154CCC7058E223BEEDB254847B6586:5F410682E9715698A3B62385063A6790
        public SqlDatabaseThreatDetectionPolicyImpl WithStorageAccountAccessKey(string storageAccountAccessKey)
        {
            this.Inner.StorageAccountAccessKey = storageAccountAccessKey;
            return this;
        }

        ///GENMHASH:18862BC89C7DCE179708D92884B10619:855B8BD955C17E9F34B0D117C8184E27
        public string StorageEndpoint()
        {
            return this.Inner.StorageEndpoint;
        }

        ///GENMHASH:A000256A1200D4576308596D35758CF7:9E4AA9F229B5B9EAC1F1CBBE7BF80901
        public bool IsDefaultSecurityAlertPolicy()
        {
            return this.Inner.UseServerDefault.Equals(SecurityAlertPolicyUseServerDefault.Enabled);
        }

        ///GENMHASH:4FE97B506DB9494B2909314080D2A9F3:C5A403E7C9EAC606ABCD1F3F29273042
        public SqlDatabaseThreatDetectionPolicyImpl WithPolicyDisabled()
        {
            this.Inner.UseServerDefault = SecurityAlertPolicyUseServerDefault.Disabled;
            this.Inner.State = SecurityAlertPolicyState.Disabled;
            return this;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:751A712BBAA24C34B5397982957947CF:2A469136A56E1E630D54AE6191EDBE73
        public bool EmailAccountAdmins()
        {
            return this.Inner.EmailAccountAdmins.Equals(SecurityAlertPolicyEmailAccountAdmins.Enabled);
        }

        ///GENMHASH:C4C0D4751CA4E1904C31CE6DF0B02AC3:B30E59DD4D927FB508DCE8588A7B6C5E
        public string Kind()
        {
            return this.Inner.Kind;
        }

        ///GENMHASH:26D5C2955D0B114A7D27F8E955353A8F:72FB32AA19C2C6E0A37DF0F97BF9CBC3
        public SqlDatabaseThreatDetectionPolicyImpl WithAlertsFilter(string alertsFilter)
        {
            this.Inner.DisabledAlerts = alertsFilter;
            return this;
        }

        ///GENMHASH:FEA777AB11D7E802212299AC62704BA2:7A8C9381A5878ED5BC7146248224AC73
        public SqlDatabaseThreatDetectionPolicyImpl WithStorageEndpoint(string storageEndpoint)
        {
            this.Inner.StorageEndpoint = storageEndpoint;
            return this;
        }

        ///GENMHASH:AE2BCF935604153C88D9AF2AC46AAAF9:823F4491C852270829C62742025C335E
        public SqlDatabaseThreatDetectionPolicyImpl WithEmailAddresses(string addresses)
        {
            this.Inner.EmailAddresses = addresses;
            return this;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:6475F0E6B085A35B081FA09FFCBDDBF8
        public Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.Inner.Location);
        }

        ///GENMHASH:F7E7F8726E962DEA3AB0FE85F77F29C3:F31B0F3D0CD1A4C57DB28EB70C9E094A
        public SecurityAlertPolicyState CurrentState()
        {
            return this.Inner.State;
        }
    }
}