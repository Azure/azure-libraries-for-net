// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BlobContainersImpl  :
        Wrapper<IBlobContainersOperations>,
        IBlobContainers
    {
        private StorageManager manager;

                internal  BlobContainersImpl(StorageManager manager) : base(manager.Inner.BlobContainers)
        {
            //$ super(manager.Inner().BlobContainers());
            //$ this.manager = manager;
            //$ }

        }

                private async Task<ImmutabilityPolicyInner> GetImmutabilityPolicyInnerUsingBlobContainersInnerAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ String resourceGroupName = IdParsingUtils.GetValueFromIdByName(id, "resourceGroups");
            //$ String accountName = IdParsingUtils.GetValueFromIdByName(id, "storageAccounts");
            //$ String containerName = IdParsingUtils.GetValueFromIdByName(id, "containers");
            //$ BlobContainersInner client = this.Inner();
            //$ return client.GetImmutabilityPolicyAsync(resourceGroupName, accountName, containerName);
            //$ }

            return null;
        }

                private BlobContainerImpl WrapBlobContainerModel(BlobContainerInner inner)
        {
            //$ return  new BlobContainerImpl(inner, manager());
            //$ }

            return null;
        }

                private BlobContainerImpl WrapContainerModel(string name)
        {
            //$ return new BlobContainerImpl(name, this.manager());
            //$ }

            return null;
        }

                private ImmutabilityPolicyImpl WrapImmutabilityPolicyModel(string name)
        {
            //$ return new ImmutabilityPolicyImpl(name, this.manager());
            //$ }

            return null;
        }

                private ImmutabilityPolicyImpl WrapImmutabilityPolicyModel(ImmutabilityPolicyInner inner)
        {
            //$ return  new ImmutabilityPolicyImpl(inner, manager());
            //$ }

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> ClearLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.ClearLegalHoldAsync(resourceGroupName, accountName, containerName, tags)
            //$ .Map(new Func1<LegalHoldInner, LegalHold>() {
            //$ @Override
            //$ public LegalHold call(LegalHoldInner inner) {
            //$ return new LegalHoldImpl(inner, manager());
            //$ }
            //$ });

            return null;
        }

                public BlobContainerImpl DefineContainer(string name)
        {
            //$ return wrapContainerModel(name);

            return null;
        }

                public ImmutabilityPolicyImpl DefineImmutabilityPolicy(string name)
        {
            //$ return wrapImmutabilityPolicyModel(name);

            return null;
        }

                public async Task DeleteAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.DeleteAsync(resourceGroupName, accountName, containerName).ToCompletable();

        }

                public async Task DeleteImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.DeleteImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch).ToCompletable();
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> ExtendImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, int immutabilityPeriodSinceCreationInDays, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.ExtendImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch, immutabilityPeriodSinceCreationInDays)
            //$ .Map(new Func1<ImmutabilityPolicyInner, ImmutabilityPolicy>() {
            //$ @Override
            //$ public ImmutabilityPolicy call(ImmutabilityPolicyInner inner) {
            //$ return new ImmutabilityPolicyImpl(inner, manager());
            //$ }
            //$ });

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> GetAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.GetAsync(resourceGroupName, accountName, containerName)
            //$ .Map(new Func1<BlobContainerInner, BlobContainer>() {
            //$ @Override
            //$ public BlobContainer call(BlobContainerInner inner) {
            //$ return new BlobContainerImpl(inner, manager());
            //$ }
            //$ });

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> GetImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.GetImmutabilityPolicyAsync(resourceGroupName, accountName, containerName)
            //$ .Map(new Func1<ImmutabilityPolicyInner, ImmutabilityPolicy>() {
            //$ @Override
            //$ public ImmutabilityPolicy call(ImmutabilityPolicyInner inner) {
            //$ return wrapImmutabilityPolicyModel(inner);
            //$ }
            //$ });

            return null;
        }

                public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IListContainerItems>> ListAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.ListAsync(resourceGroupName, accountName)
            //$ .Map(new Func1<ListContainerItemsInner, ListContainerItems>() {
            //$ @Override
            //$ public ListContainerItems call(ListContainerItemsInner inner) {
            //$ return new ListContainerItemsImpl(inner, manager());
            //$ }
            //$ });

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> LockImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.LockImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch)
            //$ .Map(new Func1<ImmutabilityPolicyInner, ImmutabilityPolicy>() {
            //$ @Override
            //$ public ImmutabilityPolicy call(ImmutabilityPolicyInner inner) {
            //$ return new ImmutabilityPolicyImpl(inner, manager());
            //$ }
            //$ });

            return null;
        }

                public StorageManager Manager()
        {
            //$ return this.manager;
            //$ }

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> SetLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ BlobContainersInner client = this.Inner();
            //$ return client.SetLegalHoldAsync(resourceGroupName, accountName, containerName, tags)
            //$ .Map(new Func1<LegalHoldInner, LegalHold>() {
            //$ @Override
            //$ public LegalHold call(LegalHoldInner inner) {
            //$ return new LegalHoldImpl(inner, manager());
            //$ }
            //$ });

            return null;
        }
    }
}