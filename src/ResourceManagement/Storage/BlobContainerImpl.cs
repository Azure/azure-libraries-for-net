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
    using System.Collections.ObjectModel;

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
        private IDictionary<string,string> cmetadata;
        private string containerName;
        private PublicAccess cpublicAccess;
        private StorageManager manager;
        private string resourceGroupName;
        private IDictionary<string,string> umetadata;
        private PublicAccess upublicAccess;

        StorageManager IHasManager<StorageManager>.Manager => this.manager;

        string IHasId.Id => Inner.Id;

        internal BlobContainerImpl(string name, StorageManager manager) : base(name, new BlobContainerInner())
        {
            this.manager = manager;
            // Set resource name
            this.containerName = name;
        }


        internal  BlobContainerImpl(BlobContainerInner inner, StorageManager manager) : base(inner.Name, inner)
        {
            this.manager = manager;
            // Set resource name
            this.containerName = inner.Name;
            // set resource ancestor and positional variables
            this.resourceGroupName = ResourceUtils.GetValueFromIdByName(inner.Id, "resourceGroups");
            this.accountName = ResourceUtils.GetValueFromIdByName(inner.Id, "storageAccounts");
            this.containerName = ResourceUtils.GetValueFromIdByName(inner.Id, "containers");
        }

        protected async override Task<BlobContainerInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.manager.Inner.BlobContainers;
            return null; // NOP getInnerAsync implementation as get is not supported
        }

        public async override Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode())
            {
                IBlobContainersOperations client = this.manager.Inner.BlobContainers;
                var blobContainerInner = await client.CreateAsync(this.resourceGroupName, this.accountName, this.containerName, this.cpublicAccess, this.cmetadata);
                this.SetInner(blobContainerInner);
                return this;
            } else
            {
                await UpdateResourceAsync(cancellationToken);
                return this;
            }
        }

        public string Etag()
        {
            return this.Inner.Etag;
        }

        public bool? HasImmutabilityPolicy()
        {
           return this.Inner.HasImmutabilityPolicy;
        }

        public bool? HasLegalHold()
        {
            return this.Inner.HasLegalHold;
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public ImmutabilityPolicyProperties ImmutabilityPolicy()
        {
            return this.Inner.ImmutabilityPolicy;
        }

        public bool IsInCreateMode()
        {
            return this.Inner.Id == null;
        }

        public DateTime? LastModifiedTime()
        {
            return this.Inner.LastModifiedTime;
        }

        public LeaseDuration LeaseDuration()
        {
            return this.Inner.LeaseDuration;
        }

        public LeaseState LeaseState()
        {
            return this.Inner.LeaseState;
        }

        public LeaseStatus LeaseStatus()
        {
            return this.Inner.LeaseStatus;
        }

        public LegalHoldProperties LegalHold()
        {
            return this.Inner.LegalHold;
        }

        public StorageManager Manager()
        {
            return this.manager;
        }

        public IReadOnlyDictionary<string,string> Metadata()
        {
            return new ReadOnlyDictionary<string, string>(this.Inner.Metadata);
        }

        public string Name()
        {
            return this.Inner.Name;
        }

        public PublicAccess? PublicAccess()
        {
            return this.Inner.PublicAccess;
        }

        public string Type()
        {
            return this.Inner.Type;
        }

        private async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.manager.Inner.BlobContainers;
            var blobContainerInner = await client.UpdateAsync(this.resourceGroupName, this.accountName, this.containerName, this.upublicAccess, this.umetadata);
            this.SetInner(blobContainerInner);
            return this;
        }

        public BlobContainerImpl WithExistingBlobService(string resourceGroupName, string accountName)
        {
            this.resourceGroupName = resourceGroupName;
            this.accountName = accountName;
            return this;

        }

        public BlobContainerImpl WithMetadata(IDictionary<string,string> metadata)
        {
            if (IsInCreateMode())
            {
                this.cmetadata = metadata;
            }
            else
            {
                this.umetadata = metadata;
            }
            return this;
        }

        public BlobContainerImpl WithMetadata(string name, string value)
        {
            if (IsInCreateMode())
            {
                if (this.cmetadata == null)
                {
                    this.cmetadata = new Dictionary<string, string>();
                }
                this.cmetadata.Add(name, value);
            }
            else
            {
                if (this.umetadata == null)
                    {
                    this.umetadata = new Dictionary<string, string>();
                    }
                this.umetadata.Add(name, value);
            }
            return this;
        }

        public BlobContainerImpl WithPublicAccess(PublicAccess publicAccess)
        {
            if (IsInCreateMode())
            {
                this.cpublicAccess = publicAccess;
            }
            else
            {
                this.upublicAccess = publicAccess;
            }
            return this;
        }
    }
}