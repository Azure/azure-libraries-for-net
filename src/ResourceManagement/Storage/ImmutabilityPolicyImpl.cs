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

        StorageManager IHasManager<StorageManager>.Manager => throw new System.NotImplementedException();

        internal  ImmutabilityPolicyImpl(string name, StorageManager manager) : base(name, new ImmutabilityPolicyInner())
        {
            //$ super(name, new ImmutabilityPolicyInner());
            //$ this.manager = manager;
            //$ // Set resource name
            //$ this.containerName = name;
            //$ //
            //$ }

        }

                internal  ImmutabilityPolicyImpl(ImmutabilityPolicyInner inner, StorageManager manager) : base(inner.Name, inner)
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

                protected override async Task<ImmutabilityPolicyInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.manager().Inner().BlobContainers();
            //$ return client.GetImmutabilityPolicyAsync(this.resourceGroupName, this.accountName, this.containerName);

            return null;
        }

                public override async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.manager().Inner().BlobContainers();
            //$ return client.CreateOrUpdateImmutabilityPolicyAsync(this.resourceGroupName, this.accountName, this.containerName, this.cimmutabilityPeriodSinceCreationInDays, this.cifMatch)
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public string Etag()
        {
            //$ return this.Inner().Etag();

            return null;
        }

                public string Id()
        {
            //$ return this.Inner().Id();

            return null;
        }

                public int ImmutabilityPeriodSinceCreationInDays()
        {
            //$ return this.Inner().ImmutabilityPeriodSinceCreationInDays();

            return 0;
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

                public string State()
        {
            //$ return this.Inner().State();

            return null;
        }

                public string Type()
        {
            //$ return this.Inner().Type();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.manager().Inner().BlobContainers();
            //$ return client.CreateOrUpdateImmutabilityPolicyAsync(this.resourceGroupName, this.accountName, this.containerName, this.uimmutabilityPeriodSinceCreationInDays, this.uifMatch)
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public ImmutabilityPolicyImpl WithExistingContainer(string resourceGroupName, string accountName, string containerName)
        {
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.accountName = accountName;
            //$ this.containerName = containerName;
            //$ return this;

            return this;
        }

                public ImmutabilityPolicyImpl WithIfMatch(string ifMatch)
        {
            //$ if (isInCreateMode()) {
            //$ this.cifMatch = ifMatch;
            //$ } else {
            //$ this.uifMatch = ifMatch;
            //$ }
            //$ return this;

            return this;
        }

                public ImmutabilityPolicyImpl WithImmutabilityPeriodSinceCreationInDays(int immutabilityPeriodSinceCreationInDays)
        {
            //$ if (isInCreateMode()) {
            //$ this.cimmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            //$ } else {
            //$ this.uimmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            //$ }
            //$ return this;

            return this;
        }
    }
}