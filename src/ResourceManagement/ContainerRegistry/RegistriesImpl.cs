// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registries.WebhooksClient;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;
    using Microsoft.Rest.Azure;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for Registries.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJpZXNJbXBs
    internal partial class RegistriesImpl :
        TopLevelModifiableResources<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryImpl,
            Models.RegistryInner,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistriesOperations,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryManager>,
        IRegistries
    {
        private IStorageManager storageManager;

        ///GENMHASH:91EB57F0F0EABB9E5AD90862F5808BBF:AB90169CC45B775EE0DDF8D3A5F7276D
        internal RegistriesImpl(IRegistryManager manager, IStorageManager storageManager) : base(manager.Inner.Registries, manager)
        {
            this.storageManager = storageManager;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public RegistryImpl Define(string name)
        {
            return this.WrapModel(name);
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:B34D88DBA264C6A9F48ACB209ACCC8A3
        protected override RegistryImpl WrapModel(string name)
        {
            return new RegistryImpl(name, new RegistryInner(), this.Manager, this.storageManager);
        }

        ///GENMHASH:63C386BA40937CF7E2E581AAB775A0F9:5D61EA0E4E05BC51211966B6410F3D6B
        protected override IRegistry WrapModel(RegistryInner containerRegistryInner)
        {
            return (containerRegistryInner != null) ?
                new RegistryImpl(containerRegistryInner.Name, containerRegistryInner, this.Manager, this.storageManager) :
                null;
        }

        ///GENMHASH:C4C74C5CA23BE3B4CAFEFD0EF23149A0:AF6C14B13CF0B80FB518B6FF3E8D963A
        public ICheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            return new CheckNameAvailabilityResultImpl(Extensions.Synchronize(() => this.Inner.CheckNameAvailabilityAsync(name)));
        }

        ///GENMHASH:42E0B61F5AA4A1130D7B90CCBAAE3A5D:129745278249D5C7481B30AFF3716534
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new CheckNameAvailabilityResultImpl(await this.Inner.CheckNameAvailabilityAsync(name, cancellationToken));
        }

        ///GENMHASH:2337D202BD29421F3BFB9293858A69DD:07EC3D428E0C9F552B589816F6AA128A
        public IReadOnlyCollection<Models.RegistryUsage> ListQuotaUsages(string resourceGroupName, string registryName)
        {
            var registryUsageListResultInner = Extensions.Synchronize(() => this.Inner.ListUsagesAsync(resourceGroupName, registryName));
            if (registryUsageListResultInner != null)
            {
                return new ReadOnlyCollection<Models.RegistryUsage>(registryUsageListResultInner.Value);
            }
            else
            {
                return new List<RegistryUsage>().AsReadOnly();
            }
        }

        ///GENMHASH:CB30AC7B9ED01655BDAFC504C752C36B:3BA76E0C8296F6CDA0AB13C8919C2265
        public async Task<IReadOnlyCollection<Models.RegistryUsage>> ListQuotaUsagesAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var registryUsageListResultInner = await this.Inner.ListUsagesAsync(resourceGroupName, registryName, cancellationToken);
            if (registryUsageListResultInner != null)
            {
                return new ReadOnlyCollection<Models.RegistryUsage>(registryUsageListResultInner.Value);
            }
            else
            {
                return new List<RegistryUsage>().AsReadOnly();
            }
        }

        ///GENMHASH:601511CD9B176CC455F825E8F050ED1E:B8E6D924E302EBC698D644CC87321B9F
        public IRegistryCredentials GetCredentials(string resourceGroupName, string registryName)
        {
            return new RegistryCredentialsImpl(Extensions.Synchronize(() => this.Inner.ListCredentialsAsync(resourceGroupName, registryName)));
        }

        ///GENMHASH:2B15DD784A432B193101991B2A395D8E:F1E4CE445A91F87D1EAE7E4DC4FE5EF5
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> GetCredentialsAsync(string resourceGroupName, string registryName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new RegistryCredentialsImpl(await this.Inner.ListCredentialsAsync(resourceGroupName, registryName, cancellationToken));
        }

        ///GENMHASH:9901FC42F194D4C02E5A4EF45224492B:B1F8C403ADAD3A5658412B1A5E6AFFD8
        public IRegistryCredentials RegenerateCredential(string resourceGroupName, string registryName, AccessKeyType accessKeyType)
        {
            return new RegistryCredentialsImpl(Extensions.Synchronize(() => this.Inner.RegenerateCredentialAsync(resourceGroupName, registryName, accessKeyType.ToPasswordName())));
        }

        ///GENMHASH:5B0E9060E6A010D9AEC0DEE8C817853F:81A8B8E3661A768A3015CC178EFC3516
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> RegenerateCredentialAsync(string resourceGroupName, string registryName, AccessKeyType accessKeyType, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new RegistryCredentialsImpl(await this.Inner.RegenerateCredentialAsync(resourceGroupName, registryName, accessKeyType.ToPasswordName(), cancellationToken));
        }

        ///GENMHASH:33AB8152BAD8DC92B90BBF1EE75AA2E4:6B2A22FE2735E021977722837B52DF1E
        public IWebhooksClient Webhooks()
        {
            return new WebhooksClientImpl(this.Manager, null);
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:4593F1A2996AA2D0219FCEB42EA28D41
        protected Task<Models.RegistryInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Inner.GetAsync(resourceGroupName, name, cancellationToken);
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:FBFA0902403A234112A18515EE78DB0D
        protected Task DeleteInnerAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected override Task<RegistryInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return this.GetInnerAsync(groupName, name, cancellationToken);
        }

        protected override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return this.Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected override Task<IPage<RegistryInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return this.Manager.Inner.Registries.ListAsync(cancellationToken);
        }

        protected override Task<IPage<RegistryInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.Registries.ListNextAsync(link, cancellationToken: cancellationToken);
        }

        protected override Task<IPage<RegistryInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.Registries.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected override Task<IPage<RegistryInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return this.Manager.Inner.Registries.ListByResourceGroupNextAsync(link, cancellationToken: cancellationToken);
        }

        ///GENMHASH:5506F8122B26409DBE3F54DBAAF24C98:8BB9BEFA47265B8959D682B8516FD65E
        public ISourceUploadDefinition GetBuildSourceUploadUrl(string rgName, string acrName)
        {
            return Extensions.Synchronize(() => this.GetBuildSourceUploadUrlAsync(rgName, acrName));
        }

        ///GENMHASH:034921EB1C4DD98E6705855EB7BDFAD7:67B8CBC296802144ECA22AADE9C60B74
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition> GetBuildSourceUploadUrlAsync(string rgName, string acrName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var sourceUploadDefinitionInner = await this.Manager.Inner.Registries.GetBuildSourceUploadUrlAsync(rgName, acrName, cancellationToken);
            return new SourceUploadDefinitionImpl(sourceUploadDefinitionInner);
        }
    }
}