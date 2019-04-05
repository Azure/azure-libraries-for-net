// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.BlobServiceProperties.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BlobServicePropertiesImpl  :
        CreatableUpdatable<
            Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties,
            BlobServicePropertiesInner,
            Microsoft.Azure.Management.Storage.Fluent.BlobServicePropertiesImpl,
            IHasId,
            IUpdate>,
        IBlobServiceProperties,
        IDefinition,
        IUpdate
    {
        private string accountName;
        private StorageManager manager;
        private string resourceGroupName;

        string IHasId.Id => Inner.Id;

        StorageManager IHasManager<StorageManager>.Manager => this.manager;

        internal  BlobServicePropertiesImpl(string name, StorageManager manager) : base(name, new BlobServicePropertiesInner())
        {
            //$ super(name, new BlobServicePropertiesInner());
            //$ this.manager = manager;
            //$ // Set resource name
            //$ this.accountName = name;
            //$ //
            //$ }

        }

                internal  BlobServicePropertiesImpl(BlobServicePropertiesInner inner, StorageManager manager) : base(inner.Name, inner)
        {
            //$ super(inner.Name(), inner);
            //$ this.manager = manager;
            //$ // Set resource name
            //$ this.accountName = inner.Name();
            //$ // set resource ancestor and positional variables
            //$ this.resourceGroupName = IdParsingUtils.GetValueFromIdByName(inner.Id(), "resourceGroups");
            //$ this.accountName = IdParsingUtils.GetValueFromIdByName(inner.Id(), "storageAccounts");
            //$ //
            //$ }

        }

                protected override async Task<BlobServicePropertiesInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobServicesInner client = this.manager().Inner().BlobServices();
            //$ return client.GetServicePropertiesAsync(this.resourceGroupName, this.accountName);

            return null;
        }

                public CorsRules Cors()
        {
            //$ return this.Inner().Cors();

            return null;
        }

                public override async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobServicesInner client = this.manager().Inner().BlobServices();
            //$ return client.SetServicePropertiesAsync(this.resourceGroupName, this.accountName, this.Inner())
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public string DefaultServiceVersion()
        {
            //$ return this.Inner().DefaultServiceVersion();

            return null;
        }

                public DeleteRetentionPolicy DeleteRetentionPolicy()
        {
            //$ return this.Inner().DeleteRetentionPolicy();

            return null;
        }

                public string Id()
        {
            //$ return this.Inner().Id();

            return null;
        }

                public bool IsInCreateMode()
        {
            //$ return this.Inner().Id() == null;

            return false;
        }

                public StorageManager Manager()
        {
            //$ return this.manager;

            return null;
        }

                public string Name()
        {
            //$ return this.Inner().Name();

            return null;
        }

                public string Type()
        {
            //$ return this.Inner().Type();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobServicesInner client = this.manager().Inner().BlobServices();
            //$ return client.SetServicePropertiesAsync(this.resourceGroupName, this.accountName, this.Inner())
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public BlobServicePropertiesImpl WithCORSRule(CorsRule corsRule)
        {
            //$ CorsRules corsRules = this.Inner().Cors();
            //$ if (corsRules == null) {
            //$ List<CorsRule> firstCorsRule = new ArrayList<>();
            //$ firstCorsRule.Add(corsRule);
            //$ this.Inner().WithCors(new CorsRules().WithCorsRules(firstCorsRule));
            //$ } else {
            //$ List<CorsRule> currentCorsRules = corsRules.CorsRules();
            //$ currentCorsRules.Add(corsRule);
            //$ this.Inner().WithCors(corsRules.WithCorsRules(currentCorsRules));
            //$ }
            //$ return this;

            return this;
        }

                public BlobServicePropertiesImpl WithCORSRules(IList<CorsRule> corsRules)
        {
            //$ this.Inner().WithCors(new CorsRules().WithCorsRules(corsRules));
            //$ return this;

            return this;
        }

                public BlobServicePropertiesImpl WithDefaultServiceVersion(string defaultServiceVersion)
        {
            //$ this.Inner().WithDefaultServiceVersion(defaultServiceVersion);
            //$ return this;

            return this;
        }

                public BlobServicePropertiesImpl WithDeleteRetentionPolicy(DeleteRetentionPolicy deleteRetentionPolicy)
        {
            //$ this.Inner().WithDeleteRetentionPolicy(deleteRetentionPolicy);
            //$ return this;

            return this;
        }

                public BlobServicePropertiesImpl WithDeleteRetentionPolicyDisabled()
        {
            //$ this.Inner().WithDeleteRetentionPolicy(new DeleteRetentionPolicy().WithEnabled(false));
            //$ return this;

            return this;
        }

                public BlobServicePropertiesImpl WithDeleteRetentionPolicyEnabled(int numDaysEnabled)
        {
            //$ this.Inner().WithDeleteRetentionPolicy(new DeleteRetentionPolicy().WithEnabled(true).WithDays(numDaysEnabled));
            //$ return this;

            return this;
        }

                public BlobServicePropertiesImpl WithExistingStorageAccount(string resourceGroupName, string accountName)
        {
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.accountName = accountName;
            //$ return this;

            return this;
        }
    }
}