// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;

    /// <summary>
    /// The implementation for DeploymentSlot.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRGVwbG95bWVudFNsb3RCYXNlSW1wbA==
    internal partial class DeploymentSlotBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT, ParentT, ParentImplT, ParentWithCreateT, ParentDefAfterRegionT, ParentDefAfterGroupT, ParentUpdateT>  :
        WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>
        where FluentImplT : DeploymentSlotBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT, ParentT, ParentImplT, ParentWithCreateT, ParentDefAfterRegionT, ParentDefAfterGroupT, ParentUpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where ParentImplT : AppServiceBaseImpl<ParentT, ParentImplT, ParentWithCreateT, ParentDefAfterRegionT, ParentDefAfterGroupT, ParentUpdateT>, ParentT
        where ParentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where ParentWithCreateT: class
        where ParentDefAfterGroupT: class
        where ParentDefAfterRegionT: class
        where UpdateT : class, WebAppBase.Update.IUpdate<FluentT>
        where ParentUpdateT : class, WebAppBase.Update.IUpdate<ParentT>
    {
        private ParentImplT parent;
        private string name;
        internal IWebAppBase configurationSource;

        ///GENMHASH:A8A7ED895B55687EE960176ECD2570B6:A1DEA977D740E0ACAD3D94D991CA9F7F
        internal override async Task<Models.SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateConfigurationSlotAsync(ResourceGroupName, this.parent.Name, siteConfig, Name, cancellationToken);
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:80F5862E3CF492064E2DDA45507B09B8
        public ParentImplT Parent()
        {
            return this.parent;
        }

        ///GENMHASH:924482EE7AA6A01820720743C2A59A72:E50B17913B8A65047092DD2C6D6AFE8C
        public override void ApplySlotConfigurations(string slotName)
        {
            Extensions.Synchronize(() => ApplySlotConfigurationsAsync(slotName));
        }

        ///GENMHASH:620993DCE6DF78140D8125DD97478452:897C9FB93A39950E97CA9111CAE33AAD
        internal override async Task<Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
        }

        ///GENMHASH:FEB63CBC1CA7D22A121F19D94AB44052:4EE46F34B076F4B43C1E61C5E9ADD07C
        public override async Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.RestartSlotAsync(ResourceGroupName, parent.Name, Name, null, null, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:62F8B201D885123D1E906E306D144662:88BEE6CEAD1A9FC39C629C20B3DA3F56
        internal override async Task<Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateSlotConfigurationNamesAsync(ResourceGroupName, parent.Name, inner, cancellationToken);
        }

        ///GENMHASH:88806945F575AAA522C2E09EBC366CC0:648365CFF3D36F6215B51C13E63240EA
        internal override async Task<Models.SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSourceControlSlotAsync(ResourceGroupName, parent.Name, inner, Name, cancellationToken);
        }

        ///GENMHASH:1AD5C303B4B7C1709305A18733B506B2:0BA6545E2E5A5E654CE278DD5968E11F
        public override void ResetSlotConfigurations()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.ResetSlotConfigurationSlotAsync(ResourceGroupName, parent.Name, Name));
        }

        ///GENMHASH:FCAC8C2F8D6E12CB6F5D7787A2837016:8A3C0887B28AA9A7371C1C4B64C83BCF
        internal override async Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteHostNameBindingSlotAsync(ResourceGroupName, parent.Name, Name, hostname, cancellationToken);
        }

        ///GENMHASH:AE14C7C2170289895AEFF07E3516A2FC:0A62D57A2A28811F577B31E7B80922B8
        public override async Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ResetSlotConfigurationSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:CB483EFD6E3479A51A8504AF23852854:6313AA480AD6478F672504A1348DE17E
        internal override async Task<Models.SiteInner> SubmitAppSettingsAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (configurationSource == null || !IsInCreateMode)
            {
                return await base.SubmitAppSettingsAsync(site, cancellationToken);
            }

            foreach (IAppSetting appSetting in (await configurationSource.GetAppSettingsAsync(cancellationToken)).Values)
            {
                if (appSetting.Sticky)
                {
                    WithStickyAppSetting(appSetting.Key, appSetting.Value);
                }
                else
                {
                    WithAppSetting(appSetting.Key, appSetting.Value);
                }
            }
            return await base.SubmitAppSettingsAsync(Inner, cancellationToken);
        }

        ///GENMHASH:D9CEBC2EF6EA60751F2BFE78FE5E22B3:86C919F4CA67F8BA602AC70FD7CCC9E0
        internal override async Task<Models.SiteInner> SubmitConnectionStringsAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (configurationSource == null || !IsInCreateMode)
            {
                return await base.SubmitConnectionStringsAsync(site, cancellationToken);
            }

            foreach (IConnectionString conn in (await configurationSource.GetConnectionStringsAsync(cancellationToken)).Values)
            {
                if (conn.Sticky)
                {
                    WithStickyConnectionString(conn.Name, conn.Value, conn.Type);
                }
                else
                {
                    WithConnectionString(conn.Name, conn.Value, conn.Type);
                }
            }
            return await base.SubmitConnectionStringsAsync(Inner, cancellationToken);
        }

        ///GENMHASH:07FBC6D492A2E1E463B39D4D7FFC40E9:6015327ABEB713972CA126D7A0F3C232
        internal override async Task<Models.SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSlotAsync(ResourceGroupName, parent.Name, site, Name, cancellationToken: cancellationToken);
        }

        internal async override Task<SiteInner> UpdateInnerAsync(SitePatchResource siteUpdate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateSlotAsync(ResourceGroupName, parent.Name, siteUpdate, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:21FDAEDB996672BE017C01C5DD8758D4:42826DB217BC1AEE5AAA977944F4318D
        internal override async Task<Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateConnectionStringsSlotAsync(ResourceGroupName, parent.Name, inner, Name, cancellationToken);
        }

        ///GENMHASH:8E71F8927E941B28152FA821CDDF0634:FE3484EE3177CF2A5BBF1D4825D24686
        internal override async Task<Models.SiteAuthSettingsInner> GetAuthenticationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetAuthSettingsSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
        }

        ///GENMHASH:4F0DD1E3F09332DAEE78A7163765E0EA:DC09185D93597A9B3912ED6CC825299E
        public override async Task<Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var stream = await Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlotAsync(ResourceGroupName, parent.Name, new CsmPublishingProfileOptions(), Name, cancellationToken))
            {
                using (var reader = new StreamReader(stream))
                {
                    string xml = reader.ReadToEnd();
                    return new PublishingProfileImpl(xml);
                }
            }
        }

        ///GENMHASH:21D1748197F7ECC1EFA9660DF579B414:5C0A7336725B7FB6E200C1ED27F5CB4C
        internal override async Task<Models.SiteAuthSettingsInner> UpdateAuthenticationAsync(SiteAuthSettingsInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateAuthSettingsSlotAsync(ResourceGroupName, parent.Name, inner, Name, cancellationToken);
        }

        ///GENMHASH:256905D5B839C64BFE9830503CB5607B:2A8EC434FA469B509BF4B734F95469CD
        internal override async Task<Models.SiteConfigResourceInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetConfigurationSlotAsync(ResourceGroupName, parent.Name, Name);
        }

        ///GENMHASH:D6FBED7FC7CBF34940541851FF5C3CC1:06F0D66A362CC364C51A49E48E7CA53B
        public override async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StopSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:8C5F8B18192B4F8FD7D43AB4D318EA69:3D9AAF779EB9D14F1D1CEB4D1C1D5CA2
        public override IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings()
        {
            return Extensions.Synchronize(() => GetHostNameBindingsAsync());
        }

        ///GENMHASH:3F0152723C985A22C1032733AB942C96:6FCE951A1B9813960CE8873DF107297F
        public override IPublishingProfile GetPublishingProfile()
        {
            using (var stream = Extensions.Synchronize(() => Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlotAsync(ResourceGroupName, Parent().Name, new CsmPublishingProfileOptions(), Name)))
            {
                using (var reader = new StreamReader(stream))
                {
                    string xml = reader.ReadToEnd();
                    return new PublishingProfileImpl(xml);
                }
            }
        }

        ///GENMHASH:2BE74359D5F3E0281DC4391F52057FEB:1D9B01843585E3C1B592B91174E4A646
        public override async Task<Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>
                (await Manager.Inner.WebApps.GetSourceControlSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken), this);
        }

        ///GENMHASH:F04F63AA4669C2004D2264538A4A983F:ADB565DFC93401B12355B173EF0CC06A
        public FluentImplT WithBrandNewConfiguration()
        {
            Inner.SiteConfig = new Models.SiteConfig();

            Inner.SiteConfig.AppSettings = new List<NameValuePair>();

            return (FluentImplT) this;
        }

        ///GENMHASH:DEC174D8970BF9488F3C635245A48467:C2605F11054FC66A805BECBAE7DAAB1F
        public override async Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ApplySlotConfigurationSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntity
            {
                TargetSlot = slotName
            }, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:44C76716F153B9042AE98C1BCBC503F2
        public override void Restart()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.RestartSlotAsync(ResourceGroupName, parent.Name, Name));
        }

        ///GENMHASH:DFC52755A97E7B13EB10FA2EB9538E4A:31BC86C370122E939BA1BA0EC17B6967
        public override void Swap(string slotName)
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.SwapSlotSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntity()
            {
                TargetSlot = slotName
            }, Name));

            Refresh();
        }

        ///GENMHASH:E7F5C40042323022AA5171FA979A6E79:3FE2818FBB1E53B61C9410D539937251
        public override async Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.SwapSlotSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntity
            {
                TargetSlot = slotName
            }, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:01DA6136E32014808DDE7F0C637CF668
        public override void Start()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.StartSlotAsync(ResourceGroupName, parent.Name, Name));

        }

        ///GENMHASH:62A0C790E618C837459BE1A5103CA0E5:DADE97E21BF8291BE266AB1DFA8E92FC
        internal override async Task<Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListSlotConfigurationNamesAsync(ResourceGroupName, parent.Name);
        }

        ///GENMHASH:D647EE2A3382CA78239A9DE35E508B8A:60DB075E48E5852A5A1AA4AFA0D83FD3
        internal DeploymentSlotBaseImpl(
            string name,
            SiteInner innerObject,
            SiteConfigResourceInner configObject,
            SiteLogsConfigInner logConfig,
            ParentImplT parent,
            IAppServiceManager manager)
                    : base(Regex.Replace(name, ".*/", ""), innerObject, configObject, logConfig, manager)
        {
            this.name = Regex.Replace(name, ".*/", "");
            this.parent = parent;
            Inner.ServerFarmId = parent.AppServicePlanId();
        }

        ///GENMHASH:E10A5B0FD0E95947B1A669D51E6BD5C9:D7D427883C2027A865C8AF45F16D7348
        public override async Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var bindingsList = await PagedCollection<IHostNameBinding, HostNameBindingInner>.LoadPage(
                async (cancellation) => await Manager.Inner.WebApps.ListHostNameBindingsSlotAsync(ResourceGroupName, parent.Name, Name, cancellation),
                Manager.Inner.WebApps.ListHostNameBindingsSlotNextAsync,
                (inner) => new HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(inner, (FluentImplT) this),
                true, cancellationToken);
            return bindingsList.ToDictionary(binding => binding.Name.Replace(this.Name + "/", ""));
        }

        ///GENMHASH:D5AD274A3026D80CDF6A0DD97D9F20D4:4895185A183470C4839F69A47A61C826
        public override async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StartSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:807E62B6346803DB90804D0DEBD2FCA6:3660A2CDB06ACF2E101AA99CFACF48CD
        internal override async Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteSourceControlSlotAsync(ResourceGroupName, parent.Name, Name);
        }

        ///GENMHASH:0FE78F842439357DA0333AABD3B95D59:93410E420C7CA4E29C47B730671408CF
        internal override async Task<Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListConnectionStringsSlotAsync(ResourceGroupName, parent.Name, Name);
        }

        ///GENMHASH:CC6E0592F0BCD4CD83D832B40167E562:BBBE3BCF158566C63DBA770C071B146A
        public override async Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            IdentifierInner identifierInner = new IdentifierInner()
            {
                Value = domainVerificationToken
            };

            await Manager.Inner.WebApps.CreateOrUpdateDomainOwnershipIdentifierSlotAsync(ResourceGroupName, parent.Name, Name, identifierInner, certificateOrderName, cancellationToken);
        }

        ///GENMHASH:6779D3D3C7AB7AAAE805BA0ABEE95C51:53A4EABE2126D220941754E8D00A25CF
        internal override async Task<Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, inner, Name, cancellationToken);
        }

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:E08F92567FBEC84BEB0BF3AD4DF89EDC
        public override void Stop()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.StopSlotAsync(ResourceGroupName, parent.Name, Name));
        }

        ///GENMHASH:81C5A75C912A5059487CAA454304B8FC:E174ECD1F459D4BCFB76BF0692F555C9
        public FluentImplT WithConfigurationFromDeploymentSlot(FluentT slot)
        {
            this.SiteConfig = ((WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>) (IWebAppBase) slot).SiteConfig;
            configurationSource = slot;
            return (FluentImplT)this;
        }

        ///GENMHASH:BC96AA8FDB678157AC1E6F0AA511AB65:55CBEA763E5EA0A02A785BC1273C63B0
        public override IWebAppSourceControl GetSourceControl()
        {
            var siteSourceControlInner = Extensions.Synchronize(() => Manager.Inner.WebApps.GetSourceControlSlotAsync(ResourceGroupName, parent.Name, Name));
            return new WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>(
                siteSourceControlInner,
                (FluentImplT) this);
        }

        ///GENMHASH:EB8C33DACE377CBB07C354F38C5BEA32:40B9A5AF5E2BAAC912A2E077A8B03C22
        public override void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            Extensions.Synchronize(() => VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken));

        }

        ///GENMHASH:9EC0529BA0D08B75AD65E98A4BA01D5D:88C44586E83A2B7A08C556A1E66B6647
        protected override async Task<Models.SiteInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
        }

        protected override async Task<SiteInner> GetSiteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
        }

        ///GENMHASH:4CF9E06F6C91A994117750A7F3E4F685:9456AE1AC3A256E704A9E044A478312E
        internal override async Task<MSDeployStatusInner> CreateMSDeploy(MSDeploy msDeployInner, CancellationToken cancellationToken)
        {
            return await parent.Manager.Inner.WebApps.CreateMSDeployOperationSlotAsync(parent.ResourceGroupName, parent.Name, Name, msDeployInner, cancellationToken);
        }

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override Stream GetContainerLogs()
        {
            return Extensions.Synchronize(() => GetContainerLogsAsync());
        }

        public override async Task<Stream> GetContainerLogsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetWebSiteContainerLogsSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
        }

        public override Stream GetContainerLogsZip()
        {
            return Extensions.Synchronize(() => GetContainerLogsZipAsync());
        }

        public override async Task<Stream> GetContainerLogsZipAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetContainerLogsZipSlotAsync(ResourceGroupName, parent.Name, Name, cancellationToken);
        }

        internal override async Task<Models.SiteLogsConfigInner> UpdateDiagnosticLogsConfigAsync(SiteLogsConfigInner siteLogConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateDiagnosticLogsConfigSlotAsync(ResourceGroupName, parent.Name, siteLogConfig, Name, cancellationToken);
        }
    }
}