// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.SqlDatabaseActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPool.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlElasticPoolOperations.SqlElasticPoolActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRuleOperations.SqlFirewallRuleActionsDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.Sql.Fluent.SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition;

    /// <summary>
    /// Implementation for SqlServer and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJJbXBs
    internal partial class SqlServerImpl  :
        GroupableResource<
            Microsoft.Azure.Management.Sql.Fluent.ISqlServer,
            Models.ServerInner,
            Microsoft.Azure.Management.Sql.Fluent.SqlServerImpl,
            Microsoft.Azure.Management.Sql.Fluent.ISqlManager,
            SqlServer.Definition.IWithGroup,
            SqlServer.Definition.IWithAdministratorLogin,
            IWithCreate,
            IUpdate>,
        ISqlServer,
        IDefinition,
        IUpdate
    {
        private ServerAzureADAdministratorInner sqlADAdminObject = null;
        private bool allowAzureServicesAccess = true;

        private List<SqlFirewallRuleImpl> sqlFirewallRulesToCreateOrUpdate = new List<SqlFirewallRuleImpl>();
        private List<string> sqlFirewallRulesToDelete = new List<string>();

        private List<SqlVirtualNetworkRuleImpl> sqlVirtualNetworkRulesToCreateOrUpdate = new List<SqlVirtualNetworkRuleImpl>();

        private List<SqlElasticPoolImpl> sqlElasticPoolsToCreateOrUpdate = new List<SqlElasticPoolImpl>();
        private List<string> sqlElasticPoolsToDelete = new List<string>();

        private List<SqlDatabaseImpl> sqlDatabasesToCreateOrUpdate = new List<SqlDatabaseImpl>();
        private List<SqlDatabaseImpl> sqlDatabasesWithElasticPoolToCreateOrUpdate = new List<SqlDatabaseImpl>();
        private List<string> sqlDatabasesToDelete = new List<string>();

        private ISqlDatabaseActionsDefinition databases;
        private ISqlElasticPoolActionsDefinition elasticPools;
        private ISqlFirewallRuleActionsDefinition firewallRules;
        private SqlVirtualNetworkRuleOperations.SqlVirtualNetworkRuleActionsDefinition.ISqlVirtualNetworkRuleActionsDefinition virtualNetworkRules;
        private SqlServerKeyOperations.SqlServerKeyActionsDefinition.ISqlServerKeyActionsDefinition serverKeys;
        private SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition.ISqlServerDnsAliasActionsDefinition dnsAliases;
        private SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition failoverGroups;
        private SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition.ISqlEncryptionProtectorActionsDefinition sqlEncryptionProtectorsOperations;


        ///GENMHASH:FED6CA0448AFD6EE7D63F8D84B7C6C26:4E9D1D31C4E764F2191FF855F590821F
        public SqlServerImpl(string name, ServerInner innerObject, ISqlManager manager) : base(name, innerObject, manager)
        {
            this.sqlADAdminObject = null;
            this.allowAzureServicesAccess = true;
        }

        ///GENMHASH:D14E9D120B5AE20CBE29EEDB19E51726:57C4C54E78144683A9963F2DF6825C68
        public SqlServerImpl WithoutFirewallRule(string firewallRuleName)
        {
            sqlFirewallRulesToDelete.Add(firewallRuleName);
            return this;
        }

        ///GENMHASH:76CA3DF47AE2173C7DD2F7771FDD2AD0:B347DF5D92EFFF6EC992D5C6C59BB49E
        public string AdministratorLogin()
        {
            return this.Inner.AdministratorLogin;
        }

        ///GENMHASH:376C162D9E950FA8A14B198790B45E34:643DE26992E791AEFF298AA2807A12E4
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> ListUsageMetrics()
        {
            List<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> serverMetrics = new List<IServerMetric>();
            var usageMetricsInners = Extensions.Synchronize(() => this.Manager.Inner.ServerUsages
                .ListByServerAsync(this.ResourceGroupName, this.Name));
            if (usageMetricsInners != null)
            {
                foreach (var serverUsageInner in usageMetricsInners)
                {
                    serverMetrics.Add(new ServerMetricImpl(serverUsageInner));
                }
            }
            return serverMetrics.AsReadOnly();
        }

        ///GENMHASH:C11535A65C2F85653353000F3BCCBABE:BA3E680F4190F2624FB5865D26163516
        public SqlFirewallRuleImpl DefineFirewallRule(string name)
        {
            var firewallRule = new SqlFirewallRuleImpl(name, this, new FirewallRuleInner(), this.Manager);
            this.sqlFirewallRulesToCreateOrUpdate.Add(firewallRule);
            return firewallRule;
        }

        ///GENMHASH:E7847943ABDC87B73F83616D49AA0FC4:6758DFDDEB9847CA500BC889138460F3
        public SqlVirtualNetworkRule.Definition.IBlank<SqlServer.Definition.IWithCreate> DefineVirtualNetworkRule(string virtualNetworkRuleName)
        {
            var vnetRule = new SqlVirtualNetworkRuleImpl(virtualNetworkRuleName, this, new Models.VirtualNetworkRuleInner(), this.Manager);
            this.sqlVirtualNetworkRulesToCreateOrUpdate.Add(vnetRule);
            return vnetRule;
        }

        ///GENMHASH:ED2CFE8848802E73EC1E094FD7531ECC:C4FC288CE09C0A0767F6161FA8C70470
        public ISqlVirtualNetworkRuleActionsDefinition VirtualNetworkRules()
        {
            if (this.virtualNetworkRules == null)
            {
                this.virtualNetworkRules = new SqlVirtualNetworkRuleOperationsImpl(this, this.Manager);
            }
            return this.virtualNetworkRules;
        }

        ///GENMHASH:1EF63C8C02FD01147851B5DFEA2E69BD:E0C9B95CE87F77B3DB92C5A544CDFAA2
        public SqlServerKeyOperations.SqlServerKeyActionsDefinition.ISqlServerKeyActionsDefinition ServerKeys()
        {
            if (this.serverKeys == null)
            {
                this.serverKeys = new SqlServerKeyOperationsImpl(this, this.Manager);
            }
            return this.serverKeys;
        }

        ///GENMHASH:7F723CF72B72C34A91B63032AF06AECB:4555DA4DF1C311015A284E0D283CF71D
        public SqlServerImpl WithSystemAssignedManagedServiceIdentity()
        {
            this.Inner.Identity = new ResourceIdentity();
            this.Inner.Identity.Type = IdentityType.SystemAssigned;
            return this;
        }

        ///GENMHASH:28F05A97A27982A7F92482B99325EBF3:83F9F65DE9FB35F8FDB098A59B0374A4
        public string SystemAssignedManagedServiceIdentityTenantId()
        {
            return this.Inner.Identity?.TenantId?.ToString();
        }

        ///GENMHASH:BC4103A90A606609FAB346997701A4DE:B857B0EEB8AF84B4C965D7D896F13006
        public IdentityType ManagedServiceIdentityType()
        {
            return this.Inner.Identity?.Type;
        }

        ///GENMHASH:2A59E18DA93663D485FB24124FE696D7:5D4984EAFAEDA4C174C8D71531DE2856
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective> ListServiceObjectives()
        {
            List<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective> serviceObjectives = new List<IServiceObjective>();
            var serviceObjectiveInners = Extensions.Synchronize(() => this.Manager.Inner.ServiceObjectives
                .ListByServerAsync(this.ResourceGroupName, this.Name));
            if (serviceObjectiveInners != null)
            {
                foreach (var serviceObjectiveInner in serviceObjectiveInners)
                {
                    serviceObjectives.Add(new ServiceObjectiveImpl(serviceObjectiveInner, this));
                }
            }
            return serviceObjectives.AsReadOnly();
        }

        ///GENMHASH:95ECB09CB6FA7BA92B573DFF1B47DAEF:AC52250D4168EB0417344212078F23E1
        public SqlActiveDirectoryAdministratorImpl GetActiveDirectoryAdministrator()
        {
            try
            {
                var serverAzureADAdministratorInner = Extensions.Synchronize(() => this.Manager.Inner.ServerAzureADAdministrators.GetAsync(this.ResourceGroupName, this.Name));
                return serverAzureADAdministratorInner != null ? new SqlActiveDirectoryAdministratorImpl(serverAzureADAdministratorInner) : null;
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

        ///GENMHASH:485F4A0DF47C41F174B382433B167D0F:94BB6E93CBB57046850D373DA9AB1CD7
        public SqlActiveDirectoryAdministratorImpl SetActiveDirectoryAdministrator(string userLogin, string objectId)
        {
            var serverAzureADAdministratorInner = new ServerAzureADAdministratorInner()
            {
                Login = userLogin,
                Sid = Guid.Parse(objectId),
                TenantId = Guid.Parse(this.Manager.TenantId)
            };
            var createResult = Extensions.Synchronize(() => this.Manager.Inner.ServerAzureADAdministrators.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, serverAzureADAdministratorInner));
            return createResult != null ? new SqlActiveDirectoryAdministratorImpl(createResult) : null;
        }

        ///GENMHASH:0FB19BD71D35E8BAC2D116947E61A25B:E179DA2275FB13CD950B71504BBC5FBA
        public SqlServerImpl WithoutAccessFromAzureServices()
        {
            allowAzureServicesAccess = false;
            return this;
        }

        ///GENMHASH:9019C44FB9C28F62603D9972D45A9522:A1032E9F64FFB6493467A3DB97A0116C
        public bool IsManagedServiceIdentityEnabled()
        {
            return this.Inner.Identity != null && this.Inner.Identity.Type != null && this.Inner.Identity.Type.Equals(IdentityType.SystemAssigned);
        }

        ///GENMHASH:2F58B86CF4C09A3821196E375EB636F4:AA91D65BA65D340B46D6B88D4467855D
        public SqlServerImpl WithAdministratorLogin(string administratorLogin)
        {
            this.Inner.AdministratorLogin = administratorLogin;
            return this;
        }

        ///GENMHASH:618686B3EE435187E4F949C115EFA823:983FBE57E91E1FA947BEA694720011F0
        public SqlServerImpl WithAdministratorPassword(string administratorLoginPassword)
        {
            this.Inner.AdministratorLoginPassword = administratorLoginPassword;
            return this;
        }

        ///GENMHASH:A35FDCFAF0B4252668DF8A64517A10A7:E00C39EDE1568124FF586B54427C9393
        public SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition.ISqlEncryptionProtectorActionsDefinition EncryptionProtectors()
        {
            if (this.sqlEncryptionProtectorsOperations == null)
            {
                this.sqlEncryptionProtectorsOperations = new SqlEncryptionProtectorOperationsImpl(this, this.Manager);
            }
            return this.sqlEncryptionProtectorsOperations;
        }

        ///GENMHASH:1FE0A47E23B755CDB471E95CFF0DB53B:5D0403E58B037C71B8C4BB957D912EBE
        public SqlFailoverGroupOperations.SqlFailoverGroupActionsDefinition.ISqlFailoverGroupActionsDefinition FailoverGroups()
        {
            if (this.failoverGroups == null)
            {
                this.failoverGroups = new SqlFailoverGroupOperationsImpl(this, this.Manager);
            }
            return this.failoverGroups;
        }

        ///GENMHASH:42238C96020583EAD41C40C184F554ED:4DCE841EF0A7240735E632B7BE9A261D
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> ListRecommendedElasticPools()
        {
            Dictionary<string, Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> recommendedElasticPoolMap = new Dictionary<string, IRecommendedElasticPool>();
            //$ Map<String, RecommendedElasticPool> recommendedElasticPoolMap = new HashMap<>();
            var recommendedElasticPoolInners = Extensions.Synchronize(() => this.Manager.Inner.RecommendedElasticPools
                .ListByServerAsync(this.ResourceGroupName, this.Name));
            if (recommendedElasticPoolInners != null)
            {
                foreach (var inner in recommendedElasticPoolInners)
                {
                    recommendedElasticPoolMap.Add(inner.Name, new RecommendedElasticPoolImpl(inner, this));
                }
            }
            return recommendedElasticPoolMap;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:F31B0F3D0CD1A4C57DB28EB70C9E094A
        public string State()
        {
            return this.Inner.State;
        }

        ///GENMHASH:4693BD7957E2D51A8D0B8B0AFDDA3A22:053C528D1658BA9F774BF38FF3DDB425
        public SqlServerImpl WithNewFirewallRule(string ipAddress)
        {
            return this.WithNewFirewallRule(ipAddress, ipAddress);
        }

        ///GENMHASH:B586503226700C805360D5B6E3725EF6:2CF4AB6732EA56C1D3EB4598632963FD
        public SqlServerImpl WithNewFirewallRule(string startIPAddress, string endIPAddress)
        {
            return this.WithNewFirewallRule(startIPAddress, endIPAddress, SdkContext.RandomResourceName("firewall_", 15));
        }

        ///GENMHASH:69FD06084D43219AA18CD7D3D99C1279:7D1773A8567ECFFC0A4621517C19EF47
        public SqlServerImpl WithNewFirewallRule(string startIPAddress, string endIPAddress, string firewallRuleName)
        {
            var sqlFirewallRule = new SqlFirewallRuleImpl(firewallRuleName, this, new FirewallRuleInner(), this.Manager);
            sqlFirewallRule.WithStartIPAddress(startIPAddress);
            sqlFirewallRule.WithEndIPAddress(endIPAddress);
            this.sqlFirewallRulesToCreateOrUpdate.Add(sqlFirewallRule);

            return this;
        }

        ///GENMHASH:AD959A66C4DBDA49C4C0DA1EC29F8FC4:6C08A0EC4BEBAF6C92531AE8ED818D15
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase>> ListRestorableDroppedDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase> restorableDroppedDatabases = new List<ISqlRestorableDroppedDatabase>();
            var droppedDatabasesInners = await this.Manager.Inner.RestorableDroppedDatabases
                .ListByServerAsync(this.ResourceGroupName, this.Name, cancellationToken);
            if (droppedDatabasesInners != null)
            {
                foreach (var restorableDroppedDatabaseInner in droppedDatabasesInners)
                {
                    restorableDroppedDatabases.Add(new SqlRestorableDroppedDatabaseImpl(this.ResourceGroupName, this.Name, restorableDroppedDatabaseInner, this.Manager));
                }
            }
            return restorableDroppedDatabases.AsReadOnly();
        }

        ///GENMHASH:DF46C62E0E8998CD0340B3F8A136F135:02BE7356BA27A5AA002198DE62969F52
        public ISqlDatabaseActionsDefinition Databases()
        {
            if (this.databases == null)
            {
                this.databases = new SqlDatabaseOperationsImpl(this, this.Manager);
            }
            return this.databases;
        }

        ///GENMHASH:39211D199FB6D28F49ADF0BA2BA3CF1E:C61C684B45B07539B0E5FEFC139FEDDC
        public SqlServerImpl WithoutDatabase(string databaseName)
        {
            this.sqlDatabasesToDelete.Add(databaseName);
            return this;
        }

        ///GENMHASH:42E970DCB01F51542CCDD026AE4BD947:5D5AB82F7992CFD43224D3F1360B4D51
        public SqlServerDnsAliasOperations.SqlServerDnsAliasActionsDefinition.ISqlServerDnsAliasActionsDefinition DnsAliases()
        {
            if (this.dnsAliases == null)
            {
                this.dnsAliases = new SqlServerDnsAliasOperationsImpl(this, this.Manager);
            }
            return this.dnsAliases;
        }

        ///GENMHASH:1130C7B9E2673D9024ACFFC4705A8B49:182C479ECA149DB94974EDE6D0E58994
        public void RemoveActiveDirectoryAdministrator()
        {
            Extensions.Synchronize(() => this.Manager.Inner.ServerAzureADAdministrators.DeleteAsync(this.ResourceGroupName, this.Name));
        }

        ///GENMHASH:0E666BFDFC9A666CA31FD735D7839414:C74F9E346B86B0AEA8A20EC90542DA1B
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IServerMetric> ListUsages()
        {
            return this.ListUsageMetrics();
        }

        ///GENMHASH:207CF59627452C607A1B799233F875B9:24C6C69C18977BD264EC783E32744339
        public string FullyQualifiedDomainName()
        {
            return this.Inner.FullyQualifiedDomainName;
        }

        ///GENMHASH:C4C0D4751CA4E1904C31CE6DF0B02AC3:B30E59DD4D927FB508DCE8588A7B6C5E
        public string Kind()
        {
            return this.Inner.Kind;
        }

        ///GENMHASH:BCD2990368F775C17F7832CE8193853C:D54AB1B5041A802D63BEA19C00F47CA5
        public void RemoveAccessFromAzureServices()
        {
            ISqlFirewallRule firewallRule = this.Manager.SqlServers.FirewallRules.GetBySqlServer(this, "AllowAllWindowsAzureIps");
            if (firewallRule != null)
            {
                firewallRule.Delete();
            }
        }

        ///GENMHASH:5C8C07A67780BE308E299F4C61976FFB:7E3228F52C5EA7764537D9FA0750DC8E
        public ISqlServerAutomaticTuning GetServerAutomaticTuning()
        {
            var serverAutomaticTuningInner = Extensions.Synchronize(() => this.Manager.Inner.ServerAutomaticTuning
                .GetAsync(this.ResourceGroupName, this.Name));
            return serverAutomaticTuningInner != null ? new SqlServerAutomaticTuningImpl(this, serverAutomaticTuningInner) : null;
        }

        ///GENMHASH:22ED13819FBF2CA919B55726AC1FB656:2D4BB539678CAB8C520F10044E2C7968
        public ISqlElasticPoolActionsDefinition ElasticPools()
        {
            if (this.elasticPools == null)
            {
                this.elasticPools = new SqlElasticPoolOperationsImpl(this, this.Manager);
            }
            return this.elasticPools;
        }

        ///GENMHASH:15C6DE336A70D5E1EDFAC74C3066EED7:9C29DD32907A6122759FBE531E3E19EA
        public SqlServerImpl WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition)
        {
            var elasticPoolItem = new SqlElasticPoolImpl(elasticPoolName, this, new ElasticPoolInner(), this.Manager);
            elasticPoolItem.WithEdition(elasticPoolEdition);
            this.sqlElasticPoolsToCreateOrUpdate.Add(elasticPoolItem);
            return this;
        }

        ///GENMHASH:7D636B43F636D47A310AB1AF99E3C582:AE9A1BF8CECF2027ED24BE1BBDE1CD93
        public SqlServerImpl WithNewElasticPool(string elasticPoolName, ElasticPoolEdition elasticPoolEdition, params string[] databaseNames)
        {
            this.WithNewElasticPool(elasticPoolName, elasticPoolEdition);
            foreach (var dbName in databaseNames)
            {
                var dbItem = new SqlDatabaseImpl(dbName, this, new DatabaseInner(), this.Manager);
                dbItem.WithExistingElasticPool(elasticPoolName);
                this.sqlDatabasesWithElasticPoolToCreateOrUpdate.Add(dbItem);
            }
            return this;
        }

        ///GENMHASH:4A64D79C205DE76E07E6A3581CF5E14B:D4B4008CD0FC6AC7097FB9303C5C92E3
        public SqlElasticPoolImpl DefineElasticPool(string name)
        {
            var elasticPoolItem = new SqlElasticPoolImpl(name, this, new ElasticPoolInner(), this.Manager);
            this.sqlElasticPoolsToCreateOrUpdate.Add(elasticPoolItem);
            return elasticPoolItem;
        }

        ///GENMHASH:D50E5343B7C7C1B41E095AD98B40D4AD:5517706AAC27788C4749AAF1BF4416DC
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase> ListRestorableDroppedDatabases()
        {
            return Extensions.Synchronize(() => this.ListRestorableDroppedDatabasesAsync());
        }

        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:583937857C93CEEDEFD65D6B38E46ADD
        public string Version()
        {
            return this.Inner.Version;
        }

        ///GENMHASH:1EBEB339569DE78AA557F27D165310BC:A2BCC5B0F32B0E3A66520AC36CE66D24
        public SqlDatabaseImpl DefineDatabase(string name)
        {
            var dbItem = new SqlDatabaseImpl(name, this, new DatabaseInner(), this.Manager);
            this.sqlDatabasesToCreateOrUpdate.Add(dbItem);
            return dbItem;
        }

        ///GENMHASH:D7949083DDCDE361387E2A975A1A1DE5:8A9E3DEC81E694085872797F0F4B9D17
        public SqlServerImpl WithNewDatabase(string databaseName)
        {
            var dbItem = new SqlDatabaseImpl(databaseName, this, new DatabaseInner(), this.Manager);
            dbItem.WithStandardEdition(SqlDatabaseStandardServiceObjective.S0);
            this.sqlDatabasesToCreateOrUpdate.Add(dbItem);
            return this;
        }

        ///GENMHASH:32076B0182F921179C1E78728F749DBF:0D9BD431A75197BE6CFABBBF154897D8
        public IServiceObjective GetServiceObjective(string serviceObjectiveName)
        {
            try
            {
                var innerResult = Extensions.Synchronize(() => this.Manager.Inner.ServiceObjectives
                    .GetAsync(this.ResourceGroupName, this.Name, serviceObjectiveName));
                return (innerResult != null) ? new ServiceObjectiveImpl(innerResult, this) : null;
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

        ///GENMHASH:87673CC4832F4C7743B7F31A22932B78:503077D37D02B80A1D14F95781AD6F24
        public string SystemAssignedManagedServiceIdentityPrincipalId()
        {
            return this.Inner.Identity?.PrincipalId?.ToString();
        }

        ///GENMHASH:D1A254F5015CA208E094ACEC31626CE3:68467397F577EB08788291BD38EF9B4E
        public ISqlFirewallRule EnableAccessFromAzureServices()
        {
            ISqlFirewallRule firewallRule = this.Manager.SqlServers.FirewallRules
                .GetBySqlServer(this.ResourceGroupName, this.Name, "AllowAllWindowsAzureIps");
            if (firewallRule == null)
            {
                firewallRule = this.Manager.SqlServers.FirewallRules
                    .Define("AllowAllWindowsAzureIps")
                    .WithExistingSqlServer(this.ResourceGroupName, this.Name)
                    .WithIPAddress("0.0.0.0")
                    .Create();
            }
            return firewallRule;
        }

        ///GENMHASH:16B9C6819B9C7B3C705BAABCD3F0D40E:8A7D594156E3F5B870F17F382CD26DF9
        public SqlServerImpl WithoutElasticPool(string elasticPoolName)
        {
            this.sqlElasticPoolsToDelete.Add(elasticPoolName);
            return this;
        }

        ///GENMHASH:3DE2C94FB1F0FC3946A6F562B7B60F99:74849820BB90CF98C7B9A424B90B1577
        public IWithCreate WithActiveDirectoryAdministrator(string userLogin, string objectId)
        {
            this.sqlADAdminObject = new ServerAzureADAdministratorInner()
            {
                Login = userLogin,
                Sid = Guid.Parse(objectId),
                TenantId = Guid.Parse(this.Manager.TenantId)
            };
            return this;
        }

        ///GENMHASH:7DDEADFB2FB27BEC42C0B993AB65C3CB:514904B05756E018F32C6B8219C69559
        public ISqlFirewallRuleActionsDefinition FirewallRules()
        {
            if (this.firewallRules == null)
            {
                this.firewallRules = new SqlFirewallRuleOperationsImpl(this, this.Manager);
            }
            return this.firewallRules;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:1A74F5AF3A99B90A121C907190687B02
        protected async override Task<Models.ServerInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.Servers.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:9557699E7EE892CCCC89A074E0915333:FA4A38A563B9469CAA6DFA06B860491B
        public async Task BeforeGroupCreateOrUpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.IsInCreateMode)
            {
                if (allowAzureServicesAccess)
                {
                    var sqlFirewallRule = new SqlFirewallRuleImpl("AllowAllWindowsAzureIps", this, new FirewallRuleInner(), this.Manager);
                    sqlFirewallRule.WithStartIPAddress("0.0.0.0");
                    sqlFirewallRule.WithEndIPAddress("0.0.0.0");
                    this.sqlFirewallRulesToCreateOrUpdate.Add(sqlFirewallRule);
                }
            }
            // validate the new/updated elastic pool items are not in the delete list
            // elastic pools will be deleted in the AfterPostRunAsync() since they depend on databases being deleted first
            foreach (var epName in this.sqlElasticPoolsToDelete)
            {
                foreach (var epItem in this.sqlElasticPoolsToCreateOrUpdate)
                {
                    if (epItem.Name() == epName)
                    {
                        throw new InvalidOperationException($"{epName} is created and removed in the same operation");
                    }
                }
            }

            // populate the "delete" worker and validate the new/updated items are not in the delete list
            var deleteWorkers = this.sqlDatabasesToDelete.Select(async dbName =>
                {
                    if (this.sqlDatabasesToCreateOrUpdate.Any(dbItem => dbItem.Name().Equals(dbName, StringComparison.OrdinalIgnoreCase)) ||
                        this.sqlDatabasesWithElasticPoolToCreateOrUpdate.Any(dbItem => dbItem.Name().Equals(dbName, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException($"{dbName} is created and removed in the same operation");
                    }
                    await this.Manager.Inner.Databases.DeleteAsync(this.ResourceGroupName, this.Name, dbName, cancellationToken);
                })
                .Union(this.sqlFirewallRulesToDelete.Select(async firewallRuleName =>
                {
                    if (this.sqlFirewallRulesToCreateOrUpdate.Any(firewallRuleItem => firewallRuleItem.Name().Equals(firewallRuleName, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException($"{firewallRuleName} is created and removed in the same operation");
                    }
                    await this.Manager.Inner.FirewallRules.DeleteAsync(this.ResourceGroupName, this.Name, firewallRuleName, cancellationToken);
                }));
            await Task.WhenAll(deleteWorkers);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:6A580BEA5FE973647B1C647B0BCDE194
        public async override Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServer> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await BeforeGroupCreateOrUpdateAsync(cancellationToken);
            this.SetInner(await this.Manager.Inner.Servers.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken));
            await AfterPostRunAsync(false, cancellationToken);
            return this;
        }

        ///GENMHASH:AC7CC07C6D6A5043B63254841EEBA63A:00D6A455C1397EAEFDE583FBC8D53FCC
        public async Task AfterPostRunAsync(bool isGroupFaulted, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (sqlADAdminObject != null)
            {
                await this.Manager.Inner.ServerAzureADAdministrators.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, sqlADAdminObject);
            }
            //split the create/update databases into those with elastic pool (which will be scheduled later) and those without
            var allTasks = sqlDatabasesToCreateOrUpdate.Where(dbItem => dbItem.ElasticPoolName() == null)
                .Select(async dbItem => await dbItem.CreateResourceAsync(cancellationToken))
                // delete all elastic pools marked as to be deleted
                .Union(this.sqlElasticPoolsToDelete
                    .Select(async epName => await this.Manager.Inner.ElasticPools.DeleteAsync(this.ResourceGroupName, this.Name, epName, cancellationToken)))
                // create/update all elastic pools marked as to be created/updated
                .Union(this.sqlElasticPoolsToCreateOrUpdate
                    .Select(async epItem => await epItem.CreateResourceAsync(cancellationToken)))
                // create/update all firewall rules marked as to be created/updated
                .Union(this.sqlFirewallRulesToCreateOrUpdate
                    .Select(async firewallRuleItem => await firewallRuleItem.CreateResourceAsync(cancellationToken)))
                // create/update all virtual network rules marked as to be created/updated
                .Union(this.sqlVirtualNetworkRulesToCreateOrUpdate
                    .Select(async vnetRuleItem => await vnetRuleItem.CreateResourceAsync(cancellationToken)));
            await Task.WhenAll(allTasks);

            foreach (var db in this.sqlDatabasesToCreateOrUpdate.Where(dbItem => dbItem.ElasticPoolName() != null))
            {
                this.sqlDatabasesWithElasticPoolToCreateOrUpdate.Add(db);
            }

            // create/update databases with elastic pools
            await Task.WhenAll(this.sqlDatabasesWithElasticPoolToCreateOrUpdate.Select( async dbItem => await dbItem.CreateResourceAsync(cancellationToken)));        

            this.sqlADAdminObject = null;
            this.sqlVirtualNetworkRulesToCreateOrUpdate.Clear();
            this.sqlFirewallRulesToCreateOrUpdate.Clear();
            this.sqlFirewallRulesToDelete.Clear();
            this.sqlElasticPoolsToCreateOrUpdate.Clear();
            this.sqlElasticPoolsToDelete.Clear();
            this.sqlDatabasesToCreateOrUpdate.Clear();
            this.sqlDatabasesWithElasticPoolToCreateOrUpdate.Clear();
            this.sqlDatabasesToDelete.Clear();
        }
    }
}