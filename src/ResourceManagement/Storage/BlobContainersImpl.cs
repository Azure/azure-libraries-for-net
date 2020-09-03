// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.BlobContainer.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ImmutabilityPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System;
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
            this.manager = manager;
        }

        private async Task<ImmutabilityPolicyInner> GetImmutabilityPolicyInnerUsingBlobContainersInnerAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            string resourceGroupName = ResourceUtils.GetValueFromIdByName(id, "resourceGroups");
            string accountName = ResourceUtils.GetValueFromIdByName(id, "storageAccounts");
            string containerName = ResourceUtils.GetValueFromIdByName(id, "containers");
            IBlobContainersOperations client = this.Inner;
            return await client.GetImmutabilityPolicyAsync(resourceGroupName, accountName, containerName);
        }

        private BlobContainerImpl WrapBlobContainerModel(BlobContainerInner inner)
        {
            return new BlobContainerImpl(inner, this.manager);
        }

        private BlobContainerImpl WrapContainerModel(string name)
        {
            return new BlobContainerImpl(name, this.manager);
    }

        private ImmutabilityPolicyImpl WrapImmutabilityPolicyModel(string name)
        {
            return new ImmutabilityPolicyImpl(name, this.manager);
        }

        private ImmutabilityPolicyImpl WrapImmutabilityPolicyModel(ImmutabilityPolicyInner inner)
        {
            return new ImmutabilityPolicyImpl(inner, this.manager);
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> ClearLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            LegalHoldInner legalHoldInner = await client.ClearLegalHoldAsync(resourceGroupName, accountName, containerName, tags);
            return new LegalHoldImpl(legalHoldInner, this.manager);
        }

        public BlobContainerImpl DefineContainer(string name)
        {
            return WrapContainerModel(name);
        }

        public ImmutabilityPolicyImpl DefineImmutabilityPolicy(string name)
        {
            return WrapImmutabilityPolicyModel(name);
        }

        public async Task DeleteAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            await client.DeleteAsync(resourceGroupName, accountName, containerName);
        }

        public async Task DeleteImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            await client.DeleteImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch);
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> ExtendImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, int immutabilityPeriodSinceCreationInDays, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            ImmutabilityPolicyInner immutabilityPolicyInner = await client.ExtendImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch, immutabilityPeriodSinceCreationInDays);
            return new ImmutabilityPolicyImpl(immutabilityPolicyInner, this.manager);
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IBlobContainer> GetAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            BlobContainerInner blobContainerInner = await client.GetAsync(resourceGroupName, accountName, containerName);
            return new BlobContainerImpl(blobContainerInner, this.manager);
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> GetImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            ImmutabilityPolicyInner immutabilityPolicyInner = await client.GetImmutabilityPolicyAsync(resourceGroupName, accountName, containerName);
            return WrapImmutabilityPolicyModel(immutabilityPolicyInner);
        }

        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IListContainerItems>> ListAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            ListContainerItemsInner listContainerItemsInner = await client.ListAsync(resourceGroupName, accountName);

            Func<CancellationToken, Task<IEnumerable<ListContainerItemsInner>>> func = async (cancellation) =>
            {
                List<ListContainerItemsInner> listContainerItemsInners = new List<ListContainerItemsInner>();
                listContainerItemsInners.Add((await client.ListWithHttpMessagesAsync(resourceGroupName, accountName, null, cancellation)).Body);
                return listContainerItemsInners;
            };
            return await PagedCollection<IListContainerItems, ListContainerItemsInner>.LoadPage(
                func,
                inner => new ListContainerItemsImpl(inner, this.manager),
                cancellationToken);
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.IImmutabilityPolicy> LockImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            ImmutabilityPolicyInner immutabilityPolicyInner = await client.LockImmutabilityPolicyAsync(resourceGroupName, accountName, containerName, ifMatch);
            return new ImmutabilityPolicyImpl(immutabilityPolicyInner, this.manager);
        }

        public StorageManager Manager()
        {
            return this.manager;
        }

        public async Task<Microsoft.Azure.Management.Storage.Fluent.ILegalHold> SetLegalHoldAsync(string resourceGroupName, string accountName, string containerName, IList<string> tags, CancellationToken cancellationToken = default(CancellationToken))
        {
            IBlobContainersOperations client = this.Inner;
            LegalHoldInner legalHoldInner = await client.SetLegalHoldAsync(resourceGroupName, accountName, containerName, tags);
            return new LegalHoldImpl(legalHoldInner, this.manager);
        }
    }
}