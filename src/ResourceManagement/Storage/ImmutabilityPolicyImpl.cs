// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;
    using System;

    public partial class ImmutabilityPolicyImpl  :
        CreatableUpdatable<
            Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy,
            ImmutabilityPolicyInner,
            Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicyImpl,
            IHasId,
            IUpdate>,
        IImmutabilityPolicy,
        IDefinition,
        IUpdate
    {
        private string accountName;
        private string cifMatch;
        private int cimmutabilityPeriodSinceCreationInDays;
        private string containerName;
        private StorageManager manager;
        private string resourceGroupName;
        private string uifMatch;
        private int uimmutabilityPeriodSinceCreationInDays;

        string IHasId.Id => Inner.Id;

        StorageManager IHasManager<StorageManager>.Manager => this.manager;

        internal  ImmutabilityPolicyImpl(string name, StorageManager manager) : base(name, new ImmutabilityPolicyInner())
        {
            this.manager = manager;
            // Set resource name
            this.containerName = name;

        }

        internal  ImmutabilityPolicyImpl(ImmutabilityPolicyInner inner, StorageManager manager) : base(inner.Name, inner)
        {
            this.manager = manager;
            // Set resource name
            this.containerName = inner.Name;
            // set resource ancestor and positional variables
            this.resourceGroupName = ResourceUtils.GetValueFromIdByName(inner.Id, "resourceGroups");
            this.accountName = ResourceUtils.GetValueFromIdByName(inner.Id, "storageAccounts");
            this.containerName = ResourceUtils.GetValueFromIdByName(inner.Id, "containers");

        }

        protected override async Task<ImmutabilityPolicyInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.manager.Inner.BlobContainers;
            return await client.GetImmutabilityPolicyAsync(this.resourceGroupName, this.accountName, this.containerName);
        }

        public override async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.manager.Inner.BlobContainers;
            ImmutabilityPolicyInner immutabilityPolicyInner = await client.CreateOrUpdateImmutabilityPolicyAsync(this.resourceGroupName, this.accountName, this.containerName, this.cimmutabilityPeriodSinceCreationInDays, this.cifMatch);
            this.SetInner(immutabilityPolicyInner);
            return this;
        }

        public string Etag()
        {
            return this.Inner.Etag;
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public int ImmutabilityPeriodSinceCreationInDays()
        {
            return this.Inner.ImmutabilityPeriodSinceCreationInDays;
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

        public ImmutabilityPolicyState State()
        {
            return this.Inner.State;
        }

        public string Type()
        {
            return this.Inner.Type;
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.manager.Inner.BlobContainers;
            ImmutabilityPolicyInner immutabilityPolicyInner = await client.CreateOrUpdateImmutabilityPolicyAsync(this.resourceGroupName, this.accountName, this.containerName, this.uimmutabilityPeriodSinceCreationInDays, this.uifMatch);
            this.SetInner(immutabilityPolicyInner);
            return this;
        }

        public ImmutabilityPolicyImpl WithExistingContainer(string resourceGroupName, string accountName, string containerName)
        {
            this.resourceGroupName = resourceGroupName;
            this.accountName = accountName;
            this.containerName = containerName;
            return this;
        }

        public ImmutabilityPolicyImpl WithIfMatch(string ifMatch)
        {
            if (IsInCreateMode())
            {
                this.cifMatch = ifMatch;
            }
            else
            {
                this.uifMatch = ifMatch;
            }
            return this;
        }

        public ImmutabilityPolicyImpl WithImmutabilityPeriodSinceCreationInDays(int immutabilityPeriodSinceCreationInDays)
        {
            if (IsInCreateMode())
            {
                this.cimmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            }
            else
            {
                this.uimmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            }
            return this;
        }
    }
}