// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using FunctionDeploymentSlot.Definition;
    using FunctionDeploymentSlot.Update;
    using Models;
    using ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for FunctionDeploymentSlot.
    /// </summary>
    internal partial class FunctionDeploymentSlotImpl :
        WebAppBaseImpl<
            IFunctionDeploymentSlot,
            FunctionDeploymentSlotImpl,
            object,
            object,
            FunctionDeploymentSlot.Update.IUpdate>,
        IFunctionDeploymentSlot,
        FunctionDeploymentSlot.Definition.IDefinition,
        FunctionDeploymentSlot.Update.IUpdate
    {
        private FunctionAppImpl parent;
        private string name;

        internal async override Task<SiteInner> CreateOrUpdateInnerAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSlotAsync(ResourceGroupName, parent.Name, site, Name(), cancellationToken: cancellationToken);
        }

        public override void Stop()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.StopSlotAsync(ResourceGroupName, parent.Name, Name()));
        }

        internal async override Task<SiteSourceControlInner> CreateOrUpdateSourceControlAsync(SiteSourceControlInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateSourceControlSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> UpdateAppSettingsAsync(StringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        private void CopyConfigurations(SiteConfigResourceInner configInner, IList<Microsoft.Azure.Management.AppService.Fluent.IAppSetting> appSettings, IList<Microsoft.Azure.Management.AppService.Fluent.IConnectionString> connectionStrings)
        {
            this.SiteConfig = configInner;
            // app settings
            foreach (var appSetting in appSettings)
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
            // connection strings
            foreach (var connectionString in connectionStrings)
            {
                if (connectionString.Sticky)
                {
                    WithStickyConnectionString(connectionString.Name, connectionString.Value, connectionString.Type);
                }
                else
                {
                    WithConnectionString(connectionString.Name, connectionString.Value, connectionString.Type);
                }
            }
        }

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.StringDictionaryInner> ListAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListApplicationSettingsSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> ListSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListSlotConfigurationNamesAsync(ResourceGroupName, parent.Name);
        }

        internal async override Task DeleteSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteSourceControlSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        public FunctionDeploymentSlotImpl WithConfigurationFromFunctionApp(IFunctionApp app)
        {
            CopyConfigurations(((FunctionAppImpl)app).SiteConfig, app.AppSettings.Values.ToList(), app.ConnectionStrings.Values.ToList());
            return this;
        }

        public FunctionDeploymentSlotImpl WithBrandNewConfiguration()
        {
            Inner.SiteConfig = new Models.SiteConfig();

            return this;
        }

        public async override Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            IdentifierInner identifierInner = new IdentifierInner()
            {
                IdentifierId = domainVerificationToken
            };

            await Manager.Inner.WebApps.CreateOrUpdateDomainOwnershipIdentifierSlotAsync(ResourceGroupName, parent.Name, Name(), identifierInner, certificateOrderName, cancellationToken);
        }

        new public string Name()
        {
            return name;
        }

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteConfigResourceInner> CreateOrUpdateSiteConfigAsync(SiteConfigResourceInner siteConfig, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.CreateOrUpdateConfigurationSlotAsync(ResourceGroupName, parent.Name, siteConfig, Name(), cancellationToken);
        }

        public override void ResetSlotConfigurations()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.ResetSlotConfigurationSlotAsync(ResourceGroupName, parent.Name, Name()));
        }

        public override void Restart()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.RestartSlotAsync(ResourceGroupName, parent.Name, Name()));
        }

        public override IPublishingProfile GetPublishingProfile()
        {
            Stream stream = Extensions.Synchronize(() => Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlotAsync(ResourceGroupName, Parent().Name, new CsmPublishingProfileOptionsInner(), Name()));
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SlotConfigNamesResourceInner> UpdateSlotConfigurationsAsync(SlotConfigNamesResourceInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateSlotConfigurationNamesAsync(ResourceGroupName, parent.Name, inner, cancellationToken);
        }

        public override void ApplySlotConfigurations(string slotName)
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.ApplySlotConfigurationSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name()));
            Refresh();
        }

        public FunctionAppImpl Parent()
        {
            return parent;
        }

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.ListConnectionStringsSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        internal async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringDictionaryInner> UpdateConnectionStringsAsync(ConnectionStringDictionaryInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateConnectionStringsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        
        internal FunctionDeploymentSlotImpl(
            string name,
            SiteInner innerObject,
            SiteConfigResourceInner configObject,
            FunctionAppImpl parent,
            IAppServiceManager manager)
                    : base(Regex.Replace(name, ".*/", ""), innerObject, configObject, manager)
        {
            this.name = Regex.Replace(name, ".*/", "");
            this.parent = parent;
            Inner.ServerFarmId = parent.AppServicePlanId();
        }

        internal async override Task<SiteConfigResourceInner> GetConfigInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetConfigurationSlotAsync(ResourceGroupName, parent.Name, Name());
        }

        public override IReadOnlyDictionary<string, Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings()
        {
            var collectionInner = Extensions.Synchronize(() => Manager.Inner.WebApps.ListHostNameBindingsSlotAsync(ResourceGroupName, parent.Name, Name()));
            return collectionInner.ToDictionary(input => input.Name.Replace(Name() + "/", ""),
                inner => (IHostNameBinding)new HostNameBindingImpl<IFunctionDeploymentSlot, FunctionDeploymentSlotImpl, object, object, IUpdate>(
                    inner,
                    this));
        }

        public override void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
            VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        public override IWebAppSourceControl GetSourceControl()
        {
            var siteSourceControlInner = Extensions.Synchronize(() => Manager.Inner.WebApps.GetSourceControlSlotAsync(ResourceGroupName, parent.Name, Name()));
            return new WebAppSourceControlImpl<IFunctionDeploymentSlot, FunctionDeploymentSlotImpl, object, object, IUpdate>(
                siteSourceControlInner,
                this);
        }

        protected async override Task<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner> GetSiteAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
        }

        public override void Start()
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.StartSlotAsync(ResourceGroupName, parent.Name, Name()));
        }

        public FunctionDeploymentSlotImpl WithConfigurationFromParent()
        {
            return WithConfigurationFromFunctionApp(parent);
        }

        public override void Swap(string slotName)
        {
            Extensions.Synchronize(() => Manager.Inner.WebApps.SwapSlotSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner()
            {
                TargetSlot = slotName
            }, Name()));

            Refresh();
        }

        public FunctionDeploymentSlotImpl WithConfigurationFromDeploymentSlot(IFunctionDeploymentSlot slot)
        {
            CopyConfigurations(((FunctionDeploymentSlotImpl) slot).SiteConfig, slot.AppSettings.Values.ToList(), slot.ConnectionStrings.Values.ToList());
            return this;
        }

        internal async override Task DeleteHostNameBindingAsync(string hostname, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.DeleteHostNameBindingSlotAsync(ResourceGroupName, parent.Name, Name(), hostname, cancellationToken);
        }

        public async override Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ApplySlotConfigurationSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            }, Name() , cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StopSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task<IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            Stream stream = await Manager.Inner.WebApps.ListPublishingProfileXmlWithSecretsSlotAsync(ResourceGroupName, parent.Name, new CsmPublishingProfileOptionsInner(), Name(), cancellationToken);
            StreamReader reader = new StreamReader(stream);
            string xml = reader.ReadToEnd();
            return new PublishingProfileImpl(xml);
        }

        public async override Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.RestartSlotAsync(ResourceGroupName, parent.Name, Name(), null, null, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task<IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new WebAppSourceControlImpl<IFunctionDeploymentSlot, FunctionDeploymentSlotImpl, object, object, IUpdate>
                (await Manager.Inner.WebApps.GetSourceControlSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken), this);
        }

        protected async override Task<SiteInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.GetSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
        }

        internal async override Task<SiteAuthSettingsInner> GetAuthenticationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.GetAuthSettingsSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
        }

        internal async override Task<SiteAuthSettingsInner> UpdateAuthenticationAsync(SiteAuthSettingsInner inner, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.WebApps.UpdateAuthSettingsSlotAsync(ResourceGroupName, parent.Name, inner, Name(), cancellationToken);
        }

        public async override Task<IReadOnlyDictionary<string, IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var bindingsList = await PagedCollection<IHostNameBinding, HostNameBindingInner>.LoadPage(
                async (cancellation) => await Manager.Inner.WebApps.ListHostNameBindingsSlotAsync(ResourceGroupName, parent.Name, Name(), cancellation),
                Manager.Inner.WebApps.ListHostNameBindingsSlotNextAsync,
                (inner) => new HostNameBindingImpl<IFunctionDeploymentSlot, FunctionDeploymentSlotImpl, object, object, IUpdate>(inner, this),
                true, cancellationToken);
            return bindingsList.ToDictionary(binding => binding.Name.Replace(this.Name() + "/", ""));
        }

        public async override Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.StartSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.SwapSlotSlotAsync(ResourceGroupName, parent.Name, new CsmSlotEntityInner
            {
                TargetSlot = slotName
            }, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public async override Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.WebApps.ResetSlotConfigurationSlotAsync(ResourceGroupName, parent.Name, Name(), cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        internal override async Task<MSDeployStatusInner> CreateMSDeploy(MSDeployInner msDeployInner, CancellationToken cancellationToken)
        {
            return await Manager.Inner.WebApps.CreateMSDeployOperationSlotAsync(ResourceGroupName, parent.Name, Name(), msDeployInner, cancellationToken);
        }
    }
}
