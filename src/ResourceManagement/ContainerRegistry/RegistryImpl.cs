// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Registry and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5SW1wbA==
    internal partial class RegistryImpl :
        GroupableResource<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry,
            Models.RegistryInner,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryImpl,
            Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryManager,
            IWithGroup,
            Registry.Definition.IWithSku,
            IWithCreate,
            IUpdate>,
        IRegistry,
        IDefinition,
        IUpdate
    {
        private RegistryUpdateParametersInner updateParameters;
        private IStorageManager storageManager;
        private string storageAccountId;
        private string creatableStorageAccountKey;
        private WebhooksImpl webhooks;


        ///GENMHASH:D18EDD2A0D462DC25F8E338158E130F1:92497F2001C42DEB1C90E3A01204233E
        internal RegistryImpl(string name, RegistryInner innerObject, IRegistryManager manager, IStorageManager storageManager) : base(name, innerObject, manager)
        {
            this.storageManager = storageManager;

            this.storageAccountId = null;
            this.webhooks = new WebhooksImpl(this, "Webhook");
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
        public Sku Sku()
        {
            return this.Inner.Sku;
        }

        ///GENMHASH:A9C6533082CF5AB1FCAEBA7DD38D0459:5AD2CED1B809DFB36A87883488364707
        public string LoginServerUrl()
        {
            return this.Inner.LoginServer;
        }

        ///GENMHASH:FD8ECACF00949BD4087A4104E8B18EA6:EB37D5E3404086C3016025E764C666B1
        public string StorageAccountId()
        {
            if (this.Inner.StorageAccount == null)
            {
                return null;
            }
            return this.Inner.StorageAccount.Id;
        }

        ///GENMHASH:EABF1199DB5B07E75BF22EB6EBE44F5B:AD4E54CC9F19471D3AB5DFE508985B8B
        public bool AdminUserEnabled()
        {
            return this.Inner.AdminUserEnabled.Value;
        }

        ///GENMHASH:4FD41262DBAA243E68D9C32C7AAD4DDB:BC26AFA0FF028C2A40210BDA22876B25
        public string StorageAccountName()
        {
            if (this.Inner.StorageAccount == null)
            {
                return null;
            }

            return ResourceUtils.NameFromResourceId(this.Inner.StorageAccount.Id);
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime CreationDate()
        {
            return this.Inner.CreationDate.Value;
        }

        ///GENMHASH:33AB8152BAD8DC92B90BBF1EE75AA2E4:9D53DAD19C7BE13BB6309C1281F08C6C
        public IWebhookOperations Webhooks()
        {
            return new WebhookOperationsImpl(this);
        }

        ///GENMHASH:54624E29F5506B6EF6B903A696B62D23:8BC21AD343E5A38FDC81F61EA6720B0D
        public IRegistryCredentials GetCredentials()
        {
            return Extensions.Synchronize(() => this.GetCredentialsAsync());
        }

        ///GENMHASH:17546B8A9E0A687BE4EC60E4686515A0:4AF2C6748C28CD5443CE8CEF05E47955
        public Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> GetCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Manager.ContainerRegistries.GetCredentialsAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:84211DE98EABA50A1893179A99F829BF:3B19415E680286BF7BE6455D09E3E76D
        public IRegistryCredentials RegenerateCredential(AccessKeyType accessKeyType)
        {
            return Extensions.Synchronize(() => this.RegenerateCredentialAsync(accessKeyType));
        }

        ///GENMHASH:2174CAA91FF57DF106B853211C422772:2D6D6BBDF119ED38C01A18861C7D5699
        public Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryCredentials> RegenerateCredentialAsync(AccessKeyType accessKeyType, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Manager.ContainerRegistries.RegenerateCredentialAsync(this.ResourceGroupName, this.Name, accessKeyType, cancellationToken);
        }

        ///GENMHASH:1FF09F84F47B1424B14D7C169D1A59C6:3ABD076ED3162E6FAE08B80AC4D00F46
        public IReadOnlyCollection<Models.RegistryUsage> ListQuotaUsages()
        {
            return Extensions.Synchronize(() => this.ListQuotaUsagesAsync());
        }

        ///GENMHASH:5F9E03CF4D4E27AAF0427B1377B983E9:C7773E788A550788FE4CD76DC857A54F
        public Task<IReadOnlyCollection<Models.RegistryUsage>> ListQuotaUsagesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Manager.ContainerRegistries.ListQuotaUsagesAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }


        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:1F3B7DE9E8C64BB113C876629C3657C2
        protected override Task<Models.RegistryInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Manager.Inner.Registries.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:82803CC7B92AB9DAB1E6ADA17D4D4332
        public override async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                if (this.creatableStorageAccountKey != null)
                {
                    var storageAccount = this.CreatedResource(this.creatableStorageAccountKey);
                    this.Inner.StorageAccount = new StorageAccountProperties() { Id = storageAccount.Id };
                }
                else
                {
                    if (this.storageAccountId != null)
                    {
                        this.Inner.StorageAccount = new StorageAccountProperties() { Id = this.storageAccountId };
                    }
                    else
                    {
                        this.Inner.StorageAccount = null;
                    }
                }

                var registryInner = await this.Manager.Inner.Registries.CreateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken);
                this.SetInner(registryInner);
            }
            else
            {
                this.EnsureUpdateParameters().Tags = this.Inner.Tags;
                var updatedRegistryInner = await this.Manager.Inner.Registries.UpdateAsync(this.ResourceGroupName, this.Name, this.updateParameters, cancellationToken);
                this.SetInner(updatedRegistryInner);
            }
            var webhooks = await this.webhooks.CommitAndGetAllAsync(cancellationToken);

            return this;
        }

        ///GENMHASH:1FAD99B53D32CA4EAADFD2A40B2ECBE8:313C19541A3CDD8054118F300CC2776F
        public WebhookImpl DefineWebhook(string name)
        {
            return this.webhooks.DefineWebhook(name);
        }

        private RegistryUpdateParametersInner EnsureUpdateParameters()
        {
            if (this.updateParameters == null)
            {
                this.updateParameters = new RegistryUpdateParametersInner();
            }

            return this.updateParameters;
        }

        ///GENMHASH:D6DC9836E611D8D27E39E7F8E45F48B2:D076CBABFD3AA156254FAE3F06668868
        public RegistryImpl WithClassicSku()
        {
            if (this.IsInCreateMode)
            {
                this.Inner.Sku = new Sku() { Name = SkuName.Classic };
                this.Inner.StorageAccount = new StorageAccountProperties();
            }

            return this;
        }

        ///GENMHASH:8D7485C72B719CA5E190D69B6FF75F54:15B3938930A616FC5EBBEF9332370719
        public RegistryImpl WithBasicSku()
        {
            return this.SetManagedSku(new Models.Sku() { Name = SkuName.Basic });
        }

        ///GENMHASH:D24D0D518EC4AAB3671622B0122F4207:A8F2311E17660AF3730E9D034859D60D
        public RegistryImpl WithStandardSku()
        {
            return this.SetManagedSku(new Models.Sku() { Name = SkuName.Standard });
        }

        ///GENMHASH:30CB47385D9AC0E9818336B698BEF529:31FD4181AACC20196F3D65A7E3E6B57C
        public RegistryImpl WithPremiumSku()
        {
            return this.SetManagedSku(new Models.Sku() { Name = SkuName.Premium });
        }

        ///GENMHASH:C9ABCD745FD5815D7823B269C03C7AB4:CE2770F2BC988316146252F091FB0B79
        private RegistryImpl SetManagedSku(Sku sku)
        {
            if (this.IsInCreateMode)
            {
                this.Inner.Sku = sku;
                this.Inner.StorageAccount = null;
            }
            else
            {
                this.EnsureUpdateParameters().Sku = sku;
                this.EnsureUpdateParameters().StorageAccount = null;
            }

            return this;
        }

        ///GENMHASH:5880487AA9218E8DF536932A49A0ACDD:4E3E6D33B7218084E27F2DBFE09715EB
        public RegistryImpl WithNewStorageAccount(string storageAccountName)
        {
            this.storageAccountId = null;

            var definitionWithGroup = this.storageManager
                .StorageAccounts
                .Define(storageAccountName)
                .WithRegion(this.Region);

            return WithNewStorageAccount(this.newGroup != null ?
                definitionWithGroup.WithNewResourceGroup(this.newGroup) :
                definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName));
        }

        ///GENMHASH:2DC51FEC3C45675856B4AC1D97BECBFD:F0FED789DCEA709580CD60BDAEC0A234
        public RegistryImpl WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            this.storageAccountId = null;

            if (this.creatableStorageAccountKey == null)
            {
                this.creatableStorageAccountKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            }

            return this;
        }

        ///GENMHASH:8CB9B7EEE4A4226A6F5BBB2958CC5E81:A5DB8C5CC4173DD7B7333E0B749757C9
        public RegistryImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.storageAccountId = storageAccount.Id;

            return this;
        }

        ///GENMHASH:E5ABD3832D46195E777C4B09BAA6344A:B11DDAB738A78654AEC28D2AE39406AC
        public RegistryImpl WithExistingStorageAccount(string id)
        {
            this.storageAccountId = id;

            return this;
        }

        ///GENMHASH:52D8C3217138C9CD0EC523378B637477:23526AF41A05F8CA932B23E6116FDD65
        public RegistryImpl WithRegistryNameAsAdminUser()
        {
            if (this.IsInCreateMode)
            {
                this.Inner.AdminUserEnabled = true;
            }
            else
            {
                this.EnsureUpdateParameters().AdminUserEnabled = true;
            }

            return this;
        }

        ///GENMHASH:403FF78955CDF94E31DDEFD44252CCBC:27A6F4C5457DBC53C783A2812214D2CF
        public RegistryImpl WithoutRegistryNameAsAdminUser()
        {
            if (this.IsInCreateMode)
            {
                this.Inner.AdminUserEnabled = false;
            }
            else
            {
                this.EnsureUpdateParameters().AdminUserEnabled = false;
            }

            return this;
        }

        ///GENMHASH:79DBD9E75BB562E15605F68076AB0D69:67557CA169F7D5519E08B937D022F510
        public RegistryImpl WithoutWebhook(string name)
        {
            webhooks.WithoutWebhook(name);
            return this;
        }

        ///GENMHASH:0A63DA53100999E7C2D128BF82427B20:9FD44D7137AFDDAA278F9F9DF25455E1
        public WebhookImpl UpdateWebhook(string name)
        {
            return webhooks.UpdateWebhook(name);
        }

        ///GENMHASH:80C260FB405ADDF9A777405F2C9DA241:0045F06F45851F271FCB18FF55CC5F81
        public ISourceUploadDefinition GetBuildSourceUploadUrl()
        {
            return Extensions.Synchronize(() => this.GetBuildSourceUploadUrlAsync());
        }

        ///GENMHASH:FD799E82F6191CFB1384F4C3622C755D:351AAD868F1F2CA6E74074ABB0AA20A6
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.ISourceUploadDefinition> GetBuildSourceUploadUrlAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var sourceUploadDefinitionInner = await this.Manager.Inner.Registries.GetBuildSourceUploadUrlAsync(this.ResourceGroupName, this.Name, cancellationToken);
            return new SourceUploadDefinitionImpl(sourceUploadDefinitionInner);
        }

        ///GENMHASH:697DA3A2AFA39E4F1F646DF4F73DE4A6:96D7481BD3ADDDE1F66F52CE500EE36F
        public RegistryTaskRun.Definition.IBlankFromRegistry ScheduleRun()
        {
            return new RegistryTaskRunImpl(this.Manager, new RunInner()).WithExistingRegistry(this.ResourceGroupName, this.Name);
        }
    }
}