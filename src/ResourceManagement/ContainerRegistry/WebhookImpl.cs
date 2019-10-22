// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateDefinition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.UpdateResource;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Webhook.WebhookDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for Webhook.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLldlYmhvb2tJbXBs
    internal partial class WebhookImpl :
        ExternalChildResource<
            Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook,
            Models.WebhookInner,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryImpl>,
        IWebhook,
        IWebhookDefinition<Registry.Definition.IWithCreate>,
        IUpdateDefinition<Registry.Update.IUpdate>,
        IUpdateResource<Registry.Update.IUpdate>,
        Webhook.Update.IUpdate
    {
        private WebhookCreateParametersInner webhookCreateParametersInner;
        private WebhookUpdateParametersInner webhookUpdateParametersInner;
        private IDictionary<string, string> tags;
        private IDictionary<string, string> customHeaders;
        private string serviceUri;
        private bool isInCreateMode;
        private IRegistryManager containerRegistryManager;
        private string resourceGroupName;
        private string registryName;

        string IExternalChildResource<IWebhook, IRegistry>.Id => this.Id();

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:77206C78102EC83DD7453FBE49543A2C:3446C7EFFC541A4FDC5DBFECC9E09C1B
        public string ServiceUri()
        {
            return this.serviceUri;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return this.Inner.Location;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:E33B754A9A9CD4E144011EFCD75AA27C
        public Region Region()
        {
            return Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Create(this.RegionName());
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:6DF51B5AA1483DABEBB258065F31C4E3:583A4480ED95E6B58B0ADDD8D194BD8C
        public string Scope()
        {
            return this.Inner.Scope;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:3F2076D33F84FDFAB700A1F0C8C41647:ADB99219D8075191B55DA96FF6F313DA
        public bool IsEnabled()
        {
            return this.Inner.Status.Equals(WebhookStatus.Enabled);
        }

        ///GENMHASH:1BD17ED6E008660CB5ED1B3272383D1F:FB9B99F320A1212F6F2B2DF6A1A060F3
        public IReadOnlyDictionary<string, string> CustomHeaders()
        {
            return new ReadOnlyDictionary<string, string>(this.customHeaders);
        }

        ///GENMHASH:7A0398C4BB6EBF42CC817EE638D40E9C:BF44555315B4D8F7DE5B31B09438FA0A
        public string ParentId()
        {
            return ResourceUtils.ParentResourcePathFromResourceId(this.Inner.Id);
        }

        ///GENMHASH:CF43B75427195BB791A48081A8790F94:54140795E29A583A495FE9766B6B5DAD
        public IReadOnlyCollection<string> Triggers()
        {
            return new ReadOnlyCollection<string>(this.Inner.Actions);
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:497CEBB37227D75C20D80EC55C7C4F14
        public IReadOnlyDictionary<string, string> Tags()
        {
            return new ReadOnlyDictionary<string, string>(this.Inner.Tags != null ? this.Inner.Tags : new Dictionary<string, string>());
        }

        ///GENMHASH:BFA458E6B7DB31C66B1C81B1BDBE609C:D70B9F4CBC472FC5B5D0AAEB72616601
        public void Enable()
        {
            this.Update()
                .Enabled(true)
                .Apply();
        }

        ///GENMHASH:7E8E5736DC6F3DBB7CDEDF699BA1CC44:D3915916BCE589B1149DA78CCEC9037B
        public async Task EnableAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Update()
                .Enabled(true)
                .ApplyAsync(cancellationToken);
        }

        ///GENMHASH:B545B04F3A152B85F06242FCFA2F6E22:D37C86A13B85AF7108D67DE627F89CAB
        public void Disable()
        {
            this.Update()
                .Enabled(false)
                .Apply();
        }

        ///GENMHASH:F6077E9B1E4F9C40387B5286EE23F11C:5E5942A8A5F1680E9DD1B18F65BF9EB0
        public async Task DisableAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Update()
                .Enabled(false)
                .ApplyAsync(cancellationToken);
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:8B308B68B153B7394B7194CC06CC4869
        public override async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.containerRegistryManager.Inner.Webhooks.DeleteAsync(this.resourceGroupName, this.registryName, this.Name(), cancellationToken);
        }

        ///GENMHASH:A22F7851AD3AA8578A117E009AD50E0A:2F25E45CC83871A65BB02EF5584BC44C
        public IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookEventInfo> ListEvents()
        {
            return Extensions.Synchronize(() => this.ListEventsAsync());
        }

        ///GENMHASH:A91A1DB40C76E6076B557587B06BB0B5:7AED94F591415C9C87F2BFA27165CA94
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhookEventInfo>> ListEventsAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IWebhookEventInfo, Models.EventModel>.LoadPage(
                async (cancellation) => await this.containerRegistryManager.Inner.Webhooks.ListEventsAsync(this.resourceGroupName, this.registryName, this.Name(), cancellation),
                async (nextLink, cancellation) => await this.containerRegistryManager.Inner.Webhooks.ListEventsNextAsync(nextLink, cancellation),
                WrapEventModel, loadAllPages, cancellationToken);
        }

        protected IWebhookEventInfo WrapEventModel(Models.EventModel inner)
        {
            return (inner != null) ? new WebhookEventInfoImpl(inner) : null;
        }


        ///GENMHASH:3B5A3C0099DB40DB9C5AE11027B12826:9CA72ECA490E9D6E6175F84ACADFA803
        public string Ping()
        {
            return Extensions.Synchronize(() => this.PingAsync());
        }

        ///GENMHASH:814F76329E806586FFAC1B314EDD5117:2853A1BE16A50EFFEB6731464C438C82
        public async Task<string> PingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var eventInfoInner = await this.containerRegistryManager.Inner.Webhooks.PingAsync(this.resourceGroupName, this.registryName, this.Name(), cancellationToken);
            return eventInfoInner.Id;
        }


        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="parent">Reference to the parent of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="containerRegistryManager">Reference to the container registry manager that accesses web hook operations.</param>
        ///GENMHASH:A02845D0393045D983B12D9853197178:8FC0F03D2574AA46828F939572035BF5
        internal WebhookImpl(string name, RegistryImpl parent, WebhookInner innerObject, IRegistryManager containerRegistryManager) : base(name, parent, innerObject)
        {
            this.containerRegistryManager = containerRegistryManager;
            if (parent != null)
            {
                this.resourceGroupName = parent.ResourceGroupName;
                this.registryName = parent.Name;
            }
            this.InitCreateUpdateParams();
        }

        /// <summary>
        /// Creates an instance of external child resource in-memory.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="name">The name of this external child resource.</param>
        /// <param name="innerObject">Reference to the inner object representing this external child resource.</param>
        /// <param name="containerRegistryManager">Reference to the container registry manager that accesses web hook operations.</param>
        ///GENMHASH:A21B1A64BBD5DE45FE96382827594FDE:C13877D7A53C23149EEDA94679AF13A2
        internal WebhookImpl(string resourceGroupName, string registryName, string name, WebhookInner innerObject, IRegistryManager containerRegistryManager) : base(name, null, innerObject)
        {
            this.containerRegistryManager = containerRegistryManager;
            this.resourceGroupName = resourceGroupName;
            this.registryName = registryName;

            this.InitCreateUpdateParams();
        }

        ///GENMHASH:E7AAF256E9CC8691E6CFA53D12A53D12:9E8F9D28CC2F3928B63541088D2694B6
        private void InitCreateUpdateParams()
        {
            this.webhookCreateParametersInner = null;
            this.webhookUpdateParametersInner = null;
            this.isInCreateMode = false;
        }

        ///GENMHASH:E9B0051D0DD6106A8989C116CC9BEE98:CF80ED2CD0162E0C6B129B46A88A28A2
        private WebhookCreateParametersInner EnsureWebhookCreateParametersInner()
        {
            if (this.webhookCreateParametersInner == null && this.Parent != null)
            {
                this.webhookCreateParametersInner = new WebhookCreateParametersInner();
                this.webhookCreateParametersInner.Location = this.Parent.RegionName;
            }

            return this.webhookCreateParametersInner;
        }

        ///GENMHASH:93D5CC1104D8649B1FB7E4CD245D6F98:8D4C9BA51F65EC1B9B920DCC25338225
        private WebhookUpdateParametersInner EnsureWebhookUpdateParametersInner()
        {
            if (this.webhookUpdateParametersInner == null && this.Parent != null)
            {
                this.webhookUpdateParametersInner = new WebhookUpdateParametersInner();
            }
            return this.webhookUpdateParametersInner;
        }

        ///GENMHASH:DC8849A1EE9037D5A131ADB0DBBFCC6F:8A41D5BCA6E829A6DFA3B9FCD3527E24
        private IDictionary<string, string> EnsureValidCustomHeaders()
        {
            if (this.customHeaders == null)
            {
                this.customHeaders = new Dictionary<string, string>();
                if (this.isInCreateMode)
                {
                    this.EnsureWebhookCreateParametersInner().CustomHeaders = this.customHeaders;
                }
                else
                {
                    this.EnsureWebhookUpdateParametersInner().CustomHeaders = this.customHeaders;
                }
            }
            return this.customHeaders;
        }

        ///GENMHASH:D0A535A11AD15BD13E493050AA14D8F1:CEF1F331960E44F7F5A7B0B30ADD3DF5
        private IDictionary<string, string> EnsureValidTags()
        {
            if (this.tags == null)
            {
                this.tags = new Dictionary<string, string>();
                if (this.isInCreateMode)
                {
                    this.EnsureWebhookCreateParametersInner().Tags = this.tags;
                }
                else
                {
                    this.EnsureWebhookUpdateParametersInner().Tags = this.tags;
                }
            }
            return this.tags;
        }

        ///GENMHASH:B58B273FF83F20A68F1BCD8877E605BD:F3A832A85F678D84390F9DCE365FE01B
        internal WebhookImpl SetCallbackConfig(CallbackConfigInner callbackConfigInner)
        {
            this.serviceUri = callbackConfigInner.ServiceUri;
            this.customHeaders = callbackConfigInner.CustomHeaders;
            if (this.customHeaders == null)
            {
                this.customHeaders = new Dictionary<string, string>();
            }

            return this;
        }

        ///GENMHASH:4CF93B8598189238029EE96B230688D7:D1F023130EF7CFEFFCA424CC9CC68ADB
        internal async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> SetCallbackConfigAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var callbackConfigInner = await this.containerRegistryManager.Inner.Webhooks.GetCallbackConfigAsync(this.resourceGroupName, this.registryName, this.Name(), cancellationToken);

            return this.SetCallbackConfig(callbackConfigInner);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:302E4693660679E722E57DEA2E6BF407
        protected override async Task<Models.WebhookInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.containerRegistryManager.Inner.Webhooks.GetAsync(this.resourceGroupName, this.registryName, this.Name(), cancellationToken);
            this.SetInner(inner);
            var callbackConfigInner = await this.containerRegistryManager.Inner.Webhooks.GetCallbackConfigAsync(this.resourceGroupName, this.registryName, this.Name(), cancellationToken);
            this.SetCallbackConfig(callbackConfigInner);

            return inner;
        }

        public new IWebhook Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async override Task<IWebhook> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var webhookInner = await this.containerRegistryManager.Inner.Webhooks.GetAsync(resourceGroupName, registryName, this.Name(), cancellationToken);
            this.SetInner(webhookInner);

            return await this.SetCallbackConfigAsync(cancellationToken);
        }

        ///GENMHASH:C7411892ADD1501285936C38C3908C6E:B20350505CDDC4E85CF8603EFBAE05DD
        internal WebhookImpl SetCreateMode(bool isInCreateMode)
        {
            this.isInCreateMode = isInCreateMode;
            if (this.isInCreateMode && this.Parent != null)
            {
                this.webhookCreateParametersInner = new WebhookCreateParametersInner();
                this.webhookCreateParametersInner.Location = this.Parent.RegionName;
            }
            else
            {
                this.webhookUpdateParametersInner = new WebhookUpdateParametersInner();
            }

            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:A62132E545823DC9E82C26DAF9535F16
        public override async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.webhookCreateParametersInner != null)
            {
                var webhookInner = await this.containerRegistryManager.Inner.Webhooks.CreateAsync(this.resourceGroupName, this.registryName, this.Name(), this.webhookCreateParametersInner, cancellationToken);
                this.SetInner(webhookInner);
                return await this.SetCallbackConfigAsync(cancellationToken);
            }

            return null;
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:A10BADEAD458ACF1D84F9333ADD8F07E
        public override async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.webhookUpdateParametersInner != null)
            {
                var webhookInner = await this.containerRegistryManager.Inner.Webhooks.UpdateAsync(this.resourceGroupName, this.registryName, this.Name(), this.webhookUpdateParametersInner, cancellationToken);
                this.SetInner(webhookInner);
                return await this.SetCallbackConfigAsync(cancellationToken);
            }

            return this;
        }

        ///GENMHASH:7A26D184347EA91F532899FC93DA3E8B:4DCBBC7A68AC87C60BAB31C86F86FB9B
        public IWebhook Apply()
        {
            return Extensions.Synchronize(() => this.ApplyAsync());
        }

        ///GENMHASH:93F5525F475C77754B229151C3005F4B:5878C559477F785E1D692AF0CE648A08
        public Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IWebhook> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateAsync();
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:8FF06E289719BB519BDB4F57C1488F6F
        public RegistryImpl Attach()
        {
            return this.Parent;
        }

        IUpdate ISettable<IUpdate>.Parent()
        {
            return this.Parent;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:250E2014F4A90653AC4AEA17F2B200C5
        public WebhookImpl Update()
        {
            this.SetCreateMode(false);

            return this;
        }

        ///GENMHASH:4D104111C03769E8F99FBB654622D65F:BE55B686C73B3BE69EFDFC1A7051AF9C
        public WebhookImpl WithTriggerWhen(params string[] webhookActions)
        {
            if (webhookActions != null)
            {
                if (this.isInCreateMode)
                {
                    this.EnsureWebhookCreateParametersInner().Actions = webhookActions;
                }
                else
                {
                    this.EnsureWebhookUpdateParametersInner().Actions = webhookActions;
                }
            }

            return this;
        }

        ///GENMHASH:3746C6721E2789BB5751153115B6482C:A8492403084C9D363548B3164332A86C
        public WebhookImpl WithServiceUri(string serviceUri)
        {
            if (serviceUri != null)
            {
                if (this.isInCreateMode)
                {
                    this.EnsureWebhookCreateParametersInner().ServiceUri = serviceUri;
                }
                else
                {
                    this.EnsureWebhookUpdateParametersInner().ServiceUri = serviceUri;
                }
            }

            return this;
        }

        ///GENMHASH:34A7CE261F2345F9D209D9459A4CDDB0:1B5B4C625B0880FCDFF2EA072E874B92
        public WebhookImpl WithCustomHeader(string name, string value)
        {
            if (name != null && value != null)
            {
                this.EnsureValidCustomHeaders().Add(name, value);
            }

            return this;
        }

        ///GENMHASH:FBED542973C356DBE51F1E6253120C71:1315291114757784AFB4FE83B7EA4F35
        public WebhookImpl WithCustomHeaders(IDictionary<string, string> customHeaders)
        {
            this.customHeaders = customHeaders;
            if (this.isInCreateMode)
            {
                this.EnsureWebhookCreateParametersInner().CustomHeaders = this.customHeaders;
            }
            else
            {
                this.EnsureWebhookUpdateParametersInner().CustomHeaders = this.customHeaders;
            }

            return this;
        }

        ///GENMHASH:19272252837967E13FB229561D298B15:C34A192BE7A23804C405CDAC4D786CAA
        public WebhookImpl WithRepositoriesScope(string repositoriesScope)
        {
            if (repositoriesScope != null)
            {
                if (this.isInCreateMode)
                {
                    this.EnsureWebhookCreateParametersInner().Scope = repositoriesScope;
                }
                else
                {
                    this.EnsureWebhookUpdateParametersInner().Scope = repositoriesScope;
                }
            }

            return this;
        }

        ///GENMHASH:8C9F881326E70A5C6A308398BDDACE72:B2EA7E96E2D5ECF27290058C5A1B3E60
        public WebhookImpl Enabled(bool defaultStatus)
        {
            string status = defaultStatus ? WebhookStatus.Enabled : WebhookStatus.Disabled;
            if (this.isInCreateMode)
            {
                this.EnsureWebhookCreateParametersInner().Status = status;
            }
            else
            {
                this.EnsureWebhookUpdateParametersInner().Status = status;
            }

            return this;
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:ADF6158E0BD084081912CE99A59CD733
        public WebhookImpl WithTags(IDictionary<string, string> tags)
        {
            this.tags = tags;
            if (this.isInCreateMode)
            {
                this.EnsureWebhookCreateParametersInner().Tags = this.tags;
            }
            else
            {
                this.EnsureWebhookUpdateParametersInner().Tags = this.tags;
            }

            return this;
        }

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:89BB57EE1882BB6659C263E10265E476
        public WebhookImpl WithoutTag(string key)
        {
            if (key != null && this.tags != null)
            {
                this.tags.Remove(key);
            }

            return this;
        }

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:A027199BFB6042E2A13252A0827E0C3C
        public WebhookImpl WithTag(string key, string value)
        {
            if (key != null && value != null)
            {
                this.EnsureValidTags()[key] = value;
            }

            return this;
        }
    }
}