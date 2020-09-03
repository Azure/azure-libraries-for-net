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
    using System;

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
            this.manager = manager;
            // Set resource name
            this.accountName = name;
        }

        internal  BlobServicePropertiesImpl(BlobServicePropertiesInner inner, StorageManager manager) : base(inner.Name, inner)
        {
            this.manager = manager;
            // Set resource name
            this.accountName = inner.Name;
            // set resource ancestor and positional variables
            this.resourceGroupName = ResourceUtils.GetValueFromIdByName(inner.Id, "resourceGroups");
            this.accountName = ResourceUtils.GetValueFromIdByName(inner.Id, "storageAccounts");

        }

       protected override async Task<BlobServicePropertiesInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobServicesOperations client = this.manager.Inner.BlobServices;
            return await client.GetServicePropertiesAsync(this.resourceGroupName, this.accountName);
        }

        public CorsRules Cors()
        {
            return this.Inner.Cors;
        }

        public override async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobServicesOperations client = this.manager.Inner.BlobServices;
            BlobServicePropertiesInner blobServicePropertiesInner = await client.SetServicePropertiesAsync(this.resourceGroupName, this.accountName, this.Inner);
            this.SetInner(blobServicePropertiesInner);
            return this;
        }

        public string DefaultServiceVersion()
        {
            return this.Inner.DefaultServiceVersion;
        }

        public DeleteRetentionPolicy DeleteRetentionPolicy()
        {
            return this.Inner.DeleteRetentionPolicy;
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public bool IsInCreateMode()
        {
            return this.Inner.Id == null;
        }

        public StorageManager Manager()
        {
            return this.manager;
        }

        public string Name()
        {
            return this.Inner.Name;
        }

        public string Type()
        {
            return this.Inner.Type;
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobServiceProperties> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobServicesOperations client = this.manager.Inner.BlobServices;
            BlobServicePropertiesInner blobServicePropertiesInner = await client.SetServicePropertiesAsync(this.resourceGroupName, this.accountName, this.Inner);
            return new BlobServicePropertiesImpl(blobServicePropertiesInner, this.manager);
        }

        public BlobServicePropertiesImpl WithCORSRule(CorsRule corsRule)
        {
            CorsRules corsRules = this.Inner.Cors;
            if (corsRules == null)
            {
                List<CorsRule> firstCorsRule = new List<CorsRule>();
                firstCorsRule.Add(corsRule);
                this.Inner.Cors = new CorsRules(firstCorsRule);
            }
            else
            {
                List<CorsRule> currentCorsRules = corsRules.CorsRulesProperty as List<CorsRule>;
                currentCorsRules.Add(corsRule);
                this.Inner.Cors = new CorsRules(currentCorsRules);
            }
            return this;
        }

        public BlobServicePropertiesImpl WithCORSRules(IList<CorsRule> corsRules)
        {
            this.Inner.Cors = new CorsRules(corsRules);
            return this;
        }

        public BlobServicePropertiesImpl WithDefaultServiceVersion(string defaultServiceVersion)
        {
            this.Inner.DefaultServiceVersion = defaultServiceVersion;
            return this;
        }

        public BlobServicePropertiesImpl WithDeleteRetentionPolicy(DeleteRetentionPolicy deleteRetentionPolicy)
        {
            this.Inner.DeleteRetentionPolicy = deleteRetentionPolicy;
            return this;
        }

        public BlobServicePropertiesImpl WithDeleteRetentionPolicyDisabled()
        {
            this.Inner.DeleteRetentionPolicy = new DeleteRetentionPolicy(false);
            return this;
        }

        public BlobServicePropertiesImpl WithDeleteRetentionPolicyEnabled(int numDaysEnabled)
        {
            this.Inner.DeleteRetentionPolicy = new DeleteRetentionPolicy(true, numDaysEnabled);
            return this;
        }

        public BlobServicePropertiesImpl WithExistingStorageAccount(string resourceGroupName, string accountName)
        {
            this.resourceGroupName = resourceGroupName;
            this.accountName = accountName;
            return this;
        }
    }
}