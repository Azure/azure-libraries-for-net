// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent;
    using System;
    using System.Collections.ObjectModel;
    using Rest.Azure;

    /// <summary>
    /// Implementation for Redis Cache and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzQ2FjaGVJbXBs
    internal partial class RedisCacheImpl :
        GroupableResource<IRedisCache, RedisResourceInner,
            RedisCacheImpl, IRedisManager,
            RedisCache.Definition.IWithGroup,
            RedisCache.Definition.IWithSku,
            RedisCache.Definition.IWithCreate,
            RedisCache.Update.IUpdate>,
        IRedisCache,
        IRedisCachePremium,
        RedisCache.Definition.IDefinition,
        RedisCache.Update.IUpdate
    {
        private IRedisAccessKeys cachedAccessKeys;
        private RedisCreateParametersInner createParameters;
        private RedisFirewallRulesImpl firewallRules;
        private bool patchScheduleAdded;
        private RedisPatchSchedulesImpl patchSchedules;
        private RedisUpdateParametersInner updateParameters;

        ///GENMHASH:EAC4B1AFA987B876CF30E9B42752EF01:6B972A3D8296EA8EC0C87FC918F68FD1
        internal RedisCacheImpl(
            string name,
            RedisResourceInner innerModel,
            IRedisManager redisManager)
            : base(name, innerModel, redisManager)
        {
            this.createParameters = new RedisCreateParametersInner();
            this.patchSchedules = new RedisPatchSchedulesImpl(this);
            this.firewallRules = new RedisFirewallRulesImpl(this);
            this.patchScheduleAdded = false;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:99632CA21DB061E4F5C58504D762DF23
        protected override async Task<RedisResourceInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Redis.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:76A2D10D5E76A25A6A9353EC8DA14C51:3AF62FAEC73DB2510F1598C12DAC9DB2
        public string AddLinkedServer(string linkedRedisCacheId, string linkedServerLocation, ReplicationRole role)
        {
            return Extensions.Synchronize(() => this.AddLinkedServerAsync(linkedRedisCacheId, linkedServerLocation, role, default(CancellationToken)));
        }

        public async Task<string> AddLinkedServerAsync(string linkedRedisCacheId, string linkedServerLocation, ReplicationRole role, CancellationToken cancellationToken)
        {
            var linkedRedisName = ResourceUtils.NameFromResourceId(linkedRedisCacheId);
            var linkParams = new RedisLinkedServerCreateParametersInner
            {
                LinkedRedisCacheId = linkedRedisCacheId,
                LinkedRedisCacheLocation = linkedServerLocation,
                ServerRole = role
            };

            var linkedServerInner = await this.Manager.Inner.LinkedServer.CreateAsync(
                this.ResourceGroupName,
                this.Name,
                linkedRedisName,
                linkParams,
                cancellationToken);

            return linkedServerInner.Name;
        }

        ///GENMHASH:A4D7300B7F198955D626D528C3191C0D:7D05859155D538EA8AAA13A7171F55B2
        public IRedisCachePremium AsPremium()
        {
            if (this.IsPremium())
            {
                return (IRedisCachePremium) this;
            }
            return null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:2CC95DA2D798C6EF07E41FBEC0E626D1
        public async override Task<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                createParameters.Location = this.RegionName;
                createParameters.Tags = this.Inner.Tags;
                this.patchScheduleAdded = false;
                var inner = await Manager.Inner.Redis.CreateAsync(ResourceGroupName, Name, createParameters, cancellationToken);
                SetInner(inner);
                await firewallRules.CommitAndGetAllAsync(cancellationToken);
                await patchSchedules.CommitAndGetAllAsync(cancellationToken);
                return this;
            }
            else
            {
                return await UpdateResourceAsync(cancellationToken);
            }
        }

        ///GENMHASH:3D7C4113A3F55E3E31A8AB77D2A98BC2:E643704D760CED098185123C4FD327DC
        public void DeletePatchSchedule()
        {
            this.patchSchedules.RemovePatchSchedule();
            this.patchSchedules.Refresh();
        }

        ///GENMHASH:E3A7804FB0FA9098FEB1BBC27C0AC302:C6D8B86600A0CD64D5868E2237339BA0
        public async Task ExportDataAsync(string containerSASUrl, string prefix, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new ExportRDBParametersInner
            {
                Container = containerSASUrl,
                Prefix = prefix
            };
            await Manager.Inner.Redis.ExportDataAsync(this.ResourceGroupName, this.Name, parameters, cancellationToken);
        }

        ///GENMHASH:D36720446E1DFBFE86C7D6259BB131A7:370BF4DADCBA5A9771685B3CE72B376E
        public async Task ExportDataAsync(string containerSASUrl, string prefix, string fileFormat, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new ExportRDBParametersInner
            {
                Container = containerSASUrl,
                Prefix = prefix,
                Format = fileFormat
            };
            await Manager.Inner.Redis.ExportDataAsync(this.ResourceGroupName, this.Name, parameters, cancellationToken);
        }

        ///GENMHASH:7DDEADFB2FB27BEC42C0B993AB65C3CB:6A8029DE3E32822B9E27C545EDF0262B
        public IReadOnlyDictionary<string,Models.IRedisFirewallRule> FirewallRules()
        {
            return this.firewallRules.RulesAsMap();
        }

        ///GENMHASH:00B3FC5713723EC459E8D0BBE862C56F:88360B7A9DAB61BC202D94798DD5342C
        public async Task ForceRebootAsync(string rebootType, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new RedisRebootParametersInner
            {
                RebootType = rebootType
            };
            await Manager.Inner.Redis.ForceRebootAsync(ResourceGroupName, Name, parameters, cancellationToken);
        }

        ///GENMHASH:9514189731558B5E71CF90933A631027:72C74F485ED62F66960400667E25D4F8
        public async Task ForceRebootAsync(string rebootType, int shardId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new RedisRebootParametersInner
            {
                RebootType = rebootType,
                ShardId = shardId
            };

            await Manager.Inner.Redis.ForceRebootAsync(ResourceGroupName, Name, parameters, cancellationToken);
        }

        ///GENMHASH:E4DFA7EA15F8324FB60C810D0C96D2FF:12CA2F259CAE4DC282485B719F9D79DE
        public async Task<IRedisAccessKeys> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO: Either this or keys() is redundant, but this was added for parity between Java and .NEt without breaking compat. In V2.0, this needs to be cleaned up.
            if (cachedAccessKeys == null)
            {
                cachedAccessKeys = await RefreshKeysAsync(cancellationToken);
            }
            return cachedAccessKeys;
        }

        ///GENMHASH:EAC569235A2E2BDE75A95902A73BBCEE:F0F74136BF0320AD0A1B0E268B66CC3E
        public ReplicationRole GetLinkedServerRole(string linkedServerName)
        {
            return Extensions.Synchronize(() => this.GetLinkedServerRoleAsync(linkedServerName, default(CancellationToken)));
        }

        public async Task<ReplicationRole> GetLinkedServerRoleAsync(string linkedServerName, CancellationToken cancellationToken)
        {
            var linkedServer = await this.Manager.Inner.LinkedServer.GetAsync(
                this.ResourceGroupName,
                this.Name,
                linkedServerName,
                cancellationToken);

            if (linkedServer == null)
            {
                throw new ArgumentException($"Server returned `null` value for Linked Server '{linkedServerName}' for Redis Cache '{this.Name}' in Resource Group '{this.ResourceGroupName}'.");
            }
            return linkedServer.ServerRole;
        }

        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:1130E1FDC5A612FAE78D6B24DD71D43E
        public string HostName()
        {
            return Inner.HostName;
        }

        ///GENMHASH:7EA43FE4B5DC6873C3A15AE9AF9FD9A2:2F9BD3581615AA60DA606F29885C93BD
        public async Task ImportDataAsync(IList<string> files, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new ImportRDBParametersInner
            {
                Files = files
            };
            await Manager.Inner.Redis.ImportDataAsync(this.ResourceGroupName, this.Name, parameters, cancellationToken);
        }

        ///GENMHASH:797BE61D54080982DA71A130D2628D30:1665E22D97D648DD9B6C906F6F2F9DAA
        public async Task ImportDataAsync(IList<string> files, string fileFormat, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new ImportRDBParametersInner
            {
                Files = files,
                Format = fileFormat
            };
            await Manager.Inner.Redis.ImportDataAsync(this.ResourceGroupName, this.Name, parameters, cancellationToken);
        }

        ///GENMHASH:1593AB443F94D260A2681DBAC7A504E4:D07F31B79AEB480685C5B24199EEE067
        public bool IsPremium()
        {
            if (this.Sku() != null && 
                SkuName.Premium.Equals(this.Sku().Name, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        ///GENMHASH:6EE61FA0DE4D0297160B059C5B56D12A:FCE23512A2C31EB7F68F7065799142F4
        public IRedisAccessKeys Keys()
        {
            return Extensions.Synchronize(() => GetKeysAsync());
        }

        ///GENMHASH:0B47AAC4088E9F14FF99E1610AFE93CC:700F3E4C226CA1266A82D817906EA1F7
        public IReadOnlyDictionary<string,Models.ReplicationRole> ListLinkedServers()
        {
            return Extensions.Synchronize(() => this.ListLinkedServersAsync(default(CancellationToken)));
        }
        public async Task<IReadOnlyDictionary<string, Models.ReplicationRole>> ListLinkedServersAsync(CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, ReplicationRole>();
            var pagedCollection = await PagedCollection<RedisLinkedServerWithPropertiesInner, RedisLinkedServerWithPropertiesInner>.LoadPage(
                (ct) => this.Manager.Inner.LinkedServer.ListAsync(
                    this.ResourceGroupName,
                    this.Name,
                    ct),
                this.Manager.Inner.LinkedServer.ListNextAsync,
                wrapModel: (inner) => inner,
                loadAllPages: true,
                cancellationToken: cancellationToken);

            foreach(var ls in pagedCollection)
            {
                result.Add(ls.Name, ls.ServerRole);
            }
            return result;
        }

        ///GENMHASH:CC99BC6F0FDDE008E581A6EB944FE764:2F561CD7250F8DA4909525E84A8A91F0
        public IReadOnlyList<Models.ScheduleEntry> ListPatchSchedules()
        {
            // for backward compatibility this method should return Null when there is no records for Patch Schedule
            RedisPatchScheduleImpl patchSchedule = this.patchSchedules.GetPatchSchedule();
            if (patchSchedule == null) 
            {
                return null;
            }
            return patchSchedule.ScheduleEntries();
        }

        ///GENMHASH:BA9FE1A345F36511B9799F44C9F3C739:9D27A7D6C296B69955557E8EA784238E
        public TlsVersion MinimumTlsVersion()
        {
            return TlsVersion.Parse(this.Inner.MinimumTlsVersion);
        }

        ///GENMHASH:6D1D6050A5B64D726B268700D1D5B76A:B617C9AF570BA31ABDF18E43D8A277EA
        public bool NonSslPort()
        {
            return (Inner.EnableNonSslPort.HasValue) ?
                Inner.EnableNonSslPort.Value : false;
        }

        ///GENMHASH:B99C181F2372E8A9AC28C8E7024F6ABD:4992C0D1E9DE06E14F14B6C38F5D33A4
        public IReadOnlyList<Models.ScheduleEntry> PatchSchedules()
        {
            var patchSchedules = ListPatchSchedules();
            if (patchSchedules == null)
            {
                return new List<ScheduleEntry>();
            }
            return patchSchedules;
        }

        ///GENMHASH:BF1200B4E784F046AF04467F35BAC1C4:F0090A6ECB1B91C3BCFD966232A4C1D4
        public int Port()
        {
            return (Inner.Port.HasValue) ?
                Inner.Port.Value : 0;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:2E1D3DC7648ABF799C342550EC7A37CA
        public string ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:83D353023D85D6E91BB9A3E8AC689039:DF02D821D2252D83CC2CDE0D9667F24E
        public IReadOnlyDictionary<string, string> RedisConfiguration()
        {
            return new ReadOnlyDictionary<string, string>(Inner.RedisConfiguration);
        }

        ///GENMHASH:0DEA6EED7C42496EBE4A5F0A6169F305:DB027AD772BBD41451F9E589A68B87F8
        public string RedisVersion()
        {
            return Inner.RedisVersion;
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:56A3157B284370C2F13CB40D1F2322C2
        public override async Task<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var retValue = await base.RefreshAsync(cancellationToken);
            this.firewallRules.Refresh();
            this.patchSchedules.Refresh();

            return retValue;
        }

        ///GENMHASH:36C3CA891B448CCCA6D3BB4C29A31470:222A26931EAF5A1984B63F0B88A1D104
        public async Task<IRedisAccessKeys> RefreshKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await Manager.Inner.Redis.ListKeysAsync(this.ResourceGroupName, this.Name, cancellationToken);
            cachedAccessKeys = new RedisAccessKeysImpl(response);
            return cachedAccessKeys;
        }

        ///GENMHASH:861E02F6BBA5773E9337D78B346B0D6B:1E017460FECC66E20EB360CE96692158
        public async Task<IRedisAccessKeys> RegenerateKeyAsync(RedisKeyType keyType, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await Manager.Inner.Redis.RegenerateKeyAsync(ResourceGroupName, Name, keyType, cancellationToken);
            cachedAccessKeys = new RedisAccessKeysImpl(response);
            return cachedAccessKeys;
        }

        ///GENMHASH:4706FC08DDF504157EE5A8DFB2A05FB6:63EA72E3845AC8C40B7D58EBD805D33E
        public void RemoveLinkedServer(string linkedServerName)
        {
            Extensions.Synchronize(() => this.RemoveLinkedServerAsync(linkedServerName, default(CancellationToken)));
        }

        public async Task RemoveLinkedServerAsync(string linkedServerName, CancellationToken cancellationToken)
        {
            var linkedServer = await this.Manager.Inner.LinkedServer.GetAsync(
                this.ResourceGroupName, 
                this.Name, 
                linkedServerName, 
                cancellationToken);

            await this.Manager.Inner.LinkedServer.DeleteAsync(
                this.ResourceGroupName,
                this.Name,
                linkedServerName,
                cancellationToken);

            RedisResourceInner innerLinkedResource = null;
            RedisResourceInner innerResource = null;
            while (innerLinkedResource == null ||
                !(StringComparer.OrdinalIgnoreCase.Equals(innerLinkedResource.ProvisioningState, "Succeeded")) || 
                innerResource == null ||
                !(StringComparer.OrdinalIgnoreCase.Equals(innerResource.ProvisioningState, "Succeeded"))) 
                {
                    await SdkContext.DelayProvider.DelayAsync(30 * 1000, cancellationToken);

                    innerLinkedResource = await this.Manager.Inner.Redis.GetAsync(
                        ResourceUtils.GroupFromResourceId(linkedServer.Id),
                        ResourceUtils.NameFromResourceId(linkedServer.Id),
                        cancellationToken);

                innerResource = await this.Manager.Inner.Redis.GetAsync(this.ResourceGroupName, this.Name);
            }

        }

        ///GENMHASH:246CCD739A2C2D6763D6C1A7A4C3F1B3:FCB76FD3E14B5306E0C0D9C582A496EF
        public int ShardCount()
        {
            return (Inner.ShardCount.HasValue) ?
                Inner.ShardCount.Value : 0;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
        public Sku Sku()
        {
            return Inner.Sku;
        }

        ///GENMHASH:8E06C1A19EE798AB8D863FD70174E162:EB25F0BF011FB476ED48A193129040E2
        public int SslPort()
        {
            return (Inner.SslPort.HasValue) ?
                Inner.SslPort.Value : 0;
        }

        ///GENMHASH:8939689DC27B99614145E6616DB6A0BF:60428C770DA47B41ED0FE8196801C941
        public string StaticIP()
        {
            return Inner.StaticIP;
        }

        ///GENMHASH:A46525F44B70758E2EDBD761F1C43440:CDCB954FF16DBA73112F76E0FBD05F88
        public string SubnetId()
        {
            return Inner.SubnetId;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:F39AFF5EE4AEBB3FA71187079E863BD0
        public override RedisCache.Update.IUpdate Update()
        {
            this.updateParameters = new RedisUpdateParametersInner();
            return base.Update();
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:2C6605A1B9906DB2844B193FD45B59DC
        public async Task<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.Redis.UpdateAsync(this.ResourceGroupName, this.Name, this.updateParameters, cancellationToken);

            this.patchScheduleAdded = false;
            await this.patchSchedules.CommitAndGetAllAsync(cancellationToken);
            await this.firewallRules.CommitAndGetAllAsync(cancellationToken);
            
            while (!inner.ProvisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase) &&
                            !cancellationToken.IsCancellationRequested)
            {
                await SdkContext.DelayProvider.DelayAsync(30 * 1000, cancellationToken);
                inner = await Manager.Inner.Redis.GetAsync(ResourceGroupName, Name, cancellationToken);
            }
            SetInner(inner);

            return this;
        }

        ///GENMHASH:8D7485C72B719CA5E190D69B6FF75F54:EF1EAF9D3B229FCBEC276D19464D4B8C
        public RedisCacheImpl WithBasicSku()
        {
            var newSku = new Sku
            {
                Name = SkuName.Basic,
                Family = SkuFamily.C
            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        ///GENMHASH:3A939C892B9542A7F3B2D43CFB7641C7:3D66186DDF06CB5C03B9666F446517A0
        public RedisCacheImpl WithBasicSku(int capacity)
        {
            var newSku = new Sku
            {
                Name = SkuName.Basic,
                Family = SkuFamily.C,
                Capacity = capacity

            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        ///GENMHASH:27444C4877ED2027D36DD096AFCEC975:208D24B219CB244B8E7E15C1C233BB71
        public RedisCacheImpl WithFirewallRule(string name, string lowestIp, string highestIp)
        {
            var rule = this.firewallRules.DefineInlineFirewallRule(name);
            rule.Inner.StartIP = lowestIp;
            rule.Inner.EndIP = highestIp;
            return this.WithFirewallRule(rule);
        }

        ///GENMHASH:9DD7CA9AD381ABB5D1493DAAF3F96082:03D221A25EEED0FA04EEC682976034E4
        public RedisCacheImpl WithFirewallRule(IRedisFirewallRule rule)
        {
            this.firewallRules.AddRule((RedisFirewallRuleImpl) rule);
            return this;
        }

        ///GENMHASH:BE6BA1183F3D45C65CDAC63F14746F24:D778A193C0BD265A4FDFF6A32CB536EE
        public RedisCacheImpl WithMinimumTlsVersion(TlsVersion tlsVersion)
        {
            if (this.IsInCreateMode)
            {
                createParameters.MinimumTlsVersion = tlsVersion.ToString();
            }
            else
            {
                updateParameters.MinimumTlsVersion = tlsVersion.ToString();
            }

            return this;
        }

        ///GENMHASH:DA29E6CF75B7755D5158B0C9AAA9D5A0:A3EDD15A99413A6F39B0B8A0338713D9
        public RedisCacheImpl WithNonSslPort()
        {
            if (IsInCreateMode)
            {
                createParameters.EnableNonSslPort = true;
            }
            else
            {
                updateParameters.EnableNonSslPort = true;
            }
            return this;
        }

        ///GENMHASH:D14E9D120B5AE20CBE29EEDB19E51726:3F066B8EB25ED4C3056B3D5932415436
        public RedisCacheImpl WithoutFirewallRule(string name)
        {
            this.firewallRules.RemoveRule(name);
            return this;
        }

        ///GENMHASH:8C4CA2E024576158A5143BDC2DE7DE06:85171B31CB90B5F24479806B7FAB77E4
        public RedisCacheImpl WithoutMinimumTlsVersion()
        {
            updateParameters.MinimumTlsVersion = null;
            return this;
        }

        ///GENMHASH:09C8C6B57BAA375B863AFE579BB6807D:91AAC365E5F79518CF38951EBEE910D6
        public RedisCacheImpl WithoutNonSslPort()
        {
            if (!IsInCreateMode)
            {
                updateParameters.EnableNonSslPort = false;
            }
            return this;
        }
        
        ///GENMHASH:34437085ECDFE7A297C3DF96BE3FEEA5:7200AAC806BEBBFC459708D2C4E3E393
        public RedisCacheImpl WithoutPatchSchedule()
        {
            if (!this.patchSchedules.PatchSchedulesAsMap().Any())
            {
                return this;
            }
            else
            {
                this.patchSchedules.DeleteInlinePatchSchedule();
            }
            return this;
        }

        ///GENMHASH:4F64337819291292917CAEDDE1BA957C:61DFF56DF837BA3A7526DB4C6FB3A760
        public RedisCacheImpl WithoutRedisConfiguration()
        {
            if(updateParameters.RedisConfiguration != null)
            {
                updateParameters.RedisConfiguration.Clear();
            }
            return this;
        }
        
        ///GENMHASH:EE0340B2F8356DEF7F1B64D128A2B48C:D28521C5DD147C307414B1CB76E973D0
        public RedisCacheImpl WithoutRedisConfiguration(string key)
        {
            if (updateParameters.RedisConfiguration != null &&
                updateParameters.RedisConfiguration.ContainsKey(key))
            {
                updateParameters.RedisConfiguration.Remove(key);
            }

            return this;
        }

        ///GENMHASH:C2110F8F251298226638BAFE08EB2503:90FDAC2D7F671EE3AF491F69172F0D7E
        public RedisCacheImpl WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc)
        {
            return this.WithPatchSchedule(
                new ScheduleEntry(
                    new ScheduleEntryInner(dayOfWeek, startHourUtc, null)));
        }

        ///GENMHASH:2B41019E00D6558C5F5C529D3296C590:5848DBA8C0AAE4C5977BD3956E8379ED
        public RedisCacheImpl WithPatchSchedule(Models.DayOfWeek dayOfWeek, int startHourUtc, System.TimeSpan? maintenanceWindow)
        {
            return this.WithPatchSchedule(
                new ScheduleEntry(
                    new ScheduleEntryInner(dayOfWeek, startHourUtc, maintenanceWindow)));
        }

        ///GENMHASH:4DC611DFE1B12D88B1FBC380172484A4:37E898C983257376AD7BAA07B4E657C5
        public RedisCacheImpl WithPatchSchedule(IList<Models.ScheduleEntry> scheduleEntries)
        {
            this.patchSchedules.Clear();
            foreach (var entry in scheduleEntries)
            {
                this.WithPatchSchedule(entry);
            }
            return this;
        }

        ///GENMHASH:C11AE4C223D196AB7A57470F94A0CDC6:8297A81A7146CC702F9E8049568353EE
        public RedisCacheImpl WithPatchSchedule(ScheduleEntry scheduleEntry)
        {
            RedisPatchScheduleImpl psch = null;
            if (!this.patchSchedules.PatchSchedulesAsMap().Any())
            {
                psch = this.patchSchedules.DefineInlinePatchSchedule();
                this.patchScheduleAdded = true;
                psch.Inner.ScheduleEntries = new List<ScheduleEntryInner>();
                this.patchSchedules.AddPatchSchedule(psch);
            }
            else if (!this.patchScheduleAdded)
            {
                psch = this.patchSchedules.UpdateInlinePatchSchedule();
            }
            else
            {
                psch = this.patchSchedules.GetPatchSchedule();
            }
            psch.Inner.ScheduleEntries.Add(scheduleEntry.Inner);
            return this;
        }

        ///GENMHASH:30CB47385D9AC0E9818336B698BEF529:4EF4FC902E838999361E1A71DDDF1772
        public RedisCacheImpl WithPremiumSku()
        {
            return this.WithPremiumSku(1);
        }

        ///GENMHASH:5237FB6E7BCD5E52462CBB82E15EE73E:BB67358C305B16CB80D9D59DEDDC11E9
        public RedisCacheImpl WithPremiumSku(int capacity)
        {
            var newSku = new Sku
            {
                Name = SkuName.Premium,
                Family = SkuFamily.P,
                Capacity = capacity
            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        ///GENMHASH:F7A196D3735B12867C5D8141F3638249:ACD54F2F69ECDD6A123AB39BF9034EB6
        public RedisCacheImpl WithRedisConfiguration(IDictionary<string, string> redisConfiguration)
        {
            if (IsInCreateMode)
            {
                createParameters.RedisConfiguration = redisConfiguration;
            }
            else
            {
                updateParameters.RedisConfiguration = redisConfiguration;
            }
            return this;
        }

        ///GENMHASH:BEAAB097144934E76ACF615386D481B3:4375CEA991BF92F46A862A930235B943
        public RedisCacheImpl WithRedisConfiguration(string key, string value)
        {
            if (IsInCreateMode)
            {
                if (createParameters.RedisConfiguration == null)
                {
                    createParameters.RedisConfiguration = new Dictionary<string, string>();
                }
                createParameters.RedisConfiguration[key] = value;
            }
            else
            {
                if (updateParameters.RedisConfiguration == null)
                {
                    updateParameters.RedisConfiguration = new Dictionary<string, string>();
                }
                updateParameters.RedisConfiguration[key] = value;
            }
            return this;
        }

        ///GENMHASH:9456FDB06E5A3C49F9A7BFDDA1938013:A5E2F06B6C6C37916FED3F7329DBBE32
        public RedisCacheImpl WithShardCount(int shardCount)
        {
            if (IsInCreateMode)
            {
                createParameters.ShardCount = shardCount;
            }
            else
            {
                updateParameters.ShardCount = shardCount;
            }

            return this;
        }

        ///GENMHASH:D24D0D518EC4AAB3671622B0122F4207:2884FF302CBD610FA22D475BDC8EBC01
        public RedisCacheImpl WithStandardSku()
        {
            var newSku = new Sku
            {
                Name = SkuName.Standard,
                Family = SkuFamily.C
            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        ///GENMHASH:85220C2FDADE8DCD78F313C8C1D645BE:B3B4FEA837D2E04D13A5DAE50007103A
        public RedisCacheImpl WithStandardSku(int capacity)
        {
            var newSku = new Sku
            {
                Name = SkuName.Standard,
                Family = SkuFamily.C,
                Capacity = capacity

            };

            if (IsInCreateMode)
            {
                createParameters.Sku = newSku;
            }
            else
            {
                updateParameters.Sku = newSku;
            }

            return this;
        }

        ///GENMHASH:1F68C56BDE6C18A1D69F2A7E56996F24:99279A7BDB9BA1C51C8FF600882EB4D1
        public RedisCacheImpl WithStaticIP(string staticIP)
        {
            if (IsInCreateMode)
            {
                createParameters.StaticIP = staticIP;
            }
            else
            {
                throw new NotSupportedException("Static IP cannot be modified during update operation.");
            }

            return this;
        }

        ///GENMHASH:8B23B5F12477BA18288CA205432B241C:594E31A6DAFC9C9C05CCC06A3902C7E0
        public RedisCacheImpl WithSubnet(IHasId networkResource, string subnetName)
        {
            if (networkResource != null)
            {
                var subnetId = networkResource.Id + "/subnets/" + subnetName;
                if (IsInCreateMode)
                {
                    createParameters.SubnetId = subnetId;
                }
                else
                {
                    throw new NotSupportedException("Subnet cannot be modified during update operation.");
                }
            }

            return this;
        }

        ///GENMHASH:0FBBECB150CBC82F165D8BA614AB135A:56529187F77D48847569F37FE5DFB40C
        public RedisCacheImpl WithSubnet(string subnetId)
        {
            if (subnetId != null)
            {
                if (this.IsInCreateMode)
                {
                    createParameters.SubnetId = subnetId;
                }
                else
                {
                    throw new NotSupportedException("Subnet cannot be modified during update operation.");
                }
            }

            return this;
        }


        internal void ExportData(string containerSASUrl, string prefix)
        {
            Extensions.Synchronize(() => ExportDataAsync(containerSASUrl, prefix));
        }

        internal void ExportData(string containerSASUrl, string prefix, string fileFormat)
        {
            Extensions.Synchronize(() => ExportDataAsync(containerSASUrl, prefix, fileFormat));
        }

        internal void ForceReboot(string rebootType)
        {
            Extensions.Synchronize(() => ForceRebootAsync(rebootType));
        }

        internal void ForceReboot(string rebootType, int shardId)
        {
            Extensions.Synchronize(() => ForceRebootAsync(rebootType, shardId));
        }

        internal IRedisAccessKeys GetKeys()
        {
            return Extensions.Synchronize(() => GetKeysAsync());
        }

        internal void ImportData(IList<string> files)
        {
            Extensions.Synchronize(() => ImportDataAsync(files));
        }

        internal void ImportData(IList<string> files, string fileFormat)
        {
            Extensions.Synchronize(() => ImportDataAsync(files, fileFormat));
        }        
        
        internal IRedisAccessKeys RefreshKeys()
        {
            return Extensions.Synchronize(() => RefreshKeysAsync());
        }

        internal IRedisAccessKeys RegenerateKey(RedisKeyType keyType)
        {
            return Extensions.Synchronize(() => RegenerateKeyAsync(keyType));
        }
    }
}
