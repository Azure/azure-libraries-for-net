// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{

    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class BlobContainerImpl  :
        CreatableUpdatable<
            Microsoft.Azure.Management.Storage.Fluent.IBlobContainer, 
            BlobContainerInner, 
            Microsoft.Azure.Management.Storage.Fluent.BlobContainerImpl, 
            IHasId, 
            IUpdate>,
        IBlobContainer,
        IDefinition,
        IUpdate
    {
        private string accountName;
        private Dictionary<string,string> cmetadata;
        private string containerName;
        private PublicAccess cpublicAccess;
        private StorageManager manager;
        private string resourceGroupName;
        private Dictionary<string,string> umetadata;
        private PublicAccess upublicAccess;

        StorageManager IHasManager<StorageManager>.Manager => this.manager;

        string IHasId.Id => Inner.Id;

        internal  BlobContainerImpl(string name, StorageManager manager) : base(name, new BlobContainerInner())
        {
            //$ super(name, new BlobContainerInner());
            //$ this.manager = manager;
            //$ // Set resource name
            //$ this.containerName = name;
            //$ //
            //$ }

        }

                internal  BlobContainerImpl(BlobContainerInner inner, StorageManager manager) : base(inner.Name, inner)
        {
            //$ super(inner.Name(), inner);
            //$ this.manager = manager;
            //$ // Set resource name
            //$ this.containerName = inner.Name();
            //$ // set resource ancestor and positional variables
            //$ this.resourceGroupName = IdParsingUtils.GetValueFromIdByName(inner.Id(), "resourceGroups");
            //$ this.accountName = IdParsingUtils.GetValueFromIdByName(inner.Id(), "storageAccounts");
            //$ this.containerName = IdParsingUtils.GetValueFromIdByName(inner.Id(), "containers");
            //$ //
            //$ }

        }

                protected async override Task<BlobContainerInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.manager().Inner().BlobContainers();
            //$ return null; // NOP getInnerAsync implementation as get is not supported

            return null;
        }

                public async override Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.manager().Inner().BlobContainers();
            //$ return client.CreateAsync(this.resourceGroupName, this.accountName, this.containerName, this.cpublicAccess, this.cmetadata)
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public string Etag()
        {
            //$ return this.Inner().Etag();

            return null;
        }

                public bool HasImmutabilityPolicy()
        {
            //$ return this.Inner().HasImmutabilityPolicy();

            return false;
        }

                public bool HasLegalHold()
        {
            //$ return this.Inner().HasLegalHold();

            return false;
        }

                public string Id()
        {
            //$ return this.Inner().Id();

            return null;
        }

                public ImmutabilityPolicyProperties ImmutabilityPolicy()
        {
            //$ return this.Inner().ImmutabilityPolicy();

            return null;
        }

                public bool IsInCreateMode()
        {
            //$ return this.Inner().Id() == null;

            return false;
        }

                public DateTime LastModifiedTime()
        {
            //$ return this.Inner().LastModifiedTime();

            return DateTime.Now;
        }

                public String LeaseDuration()
        {
            //$ return this.Inner().LeaseDuration();

            return null;
        }

                public String LeaseState()
        {
            //$ return this.Inner().LeaseState();

            return null;
        }

                public String LeaseStatus()
        {
            //$ return this.Inner().LeaseStatus();

            return null;
        }

                public LegalHoldProperties LegalHold()
        {
            //$ return this.Inner().LegalHold();

            return null;
        }

                public StorageManager Manager()
        {
            //$ return this.manager;

            return null;
        }

                public IReadOnlyDictionary<string,string> Metadata()
        {
            //$ return this.Inner().Metadata();

            return null;
        }

                public string Name()
        {
            //$ return this.Inner().Name();

            return null;
        }

                public PublicAccess? PublicAccess()
        {
            //$ return this.Inner().PublicAccess();

            return this.Inner.PublicAccess;
        }

                public string Type()
        {
            //$ return this.Inner().Type();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.manager().Inner().BlobContainers();
            //$ return client.UpdateAsync(this.resourceGroupName, this.accountName, this.containerName, this.upublicAccess, this.umetadata)
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public BlobContainerImpl WithExistingBlobService(string resourceGroupName, string accountName)
        {
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.accountName = accountName;
            //$ return this;

            return this;
        }

                public BlobContainerImpl WithMetadata(IDictionary<string,string> metadata)
        {
            //$ if (isInCreateMode()) {
            //$ this.cmetadata = metadata;
            //$ } else {
            //$ this.umetadata = metadata;
            //$ }
            //$ return this;

            return this;
        }

                public BlobContainerImpl WithMetadata(string name, string value)
        {
            //$ if (isInCreateMode()) {
            //$ if (this.cmetadata == null) {
            //$ this.cmetadata = new HashMap<>();
            //$ }
            //$ this.cmetadata.Put(name, value);
            //$ } else {
            //$ if (this.umetadata == null) {
            //$ this.umetadata = new HashMap<>();
            //$ }
            //$ this.umetadata.Put(name, value);
            //$ }
            //$ return this;

            return this;
        }

                public BlobContainerImpl WithPublicAccess(PublicAccess publicAccess)
        {
            //$ if (isInCreateMode()) {
            //$ this.cpublicAccess = publicAccess;
            //$ } else {
            //$ this.upublicAccess = publicAccess;
            //$ }
            //$ return this;

            return this;
        }
    }
}