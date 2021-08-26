// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.GenericResource.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class GenericResourcesImpl :
        TopLevelModifiableResources<IGenericResource, GenericResourceImpl, GenericResourceInner, IResourcesOperations, IResourceManager>,
        IGenericResources
    {
        internal static ConcurrentDictionary<string, string> cachedApiVersions = new ConcurrentDictionary<string, string>();

        internal GenericResourcesImpl(IResourceManager resourceManager) : base(resourceManager.Inner.Resources, resourceManager)
        {
        }

        public bool CheckExistence(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion = default(string))
        {
            return Extensions.Synchronize(() => CheckExistenceAsync(
               resourceGroupName,
               resourceProviderNamespace,
               parentResourcePath,
               resourceType,
               resourceName,
               apiVersion));
        }

        public async Task<bool> CheckExistenceAsync(
            string resourceGroupName,
            string resourceProviderNamespace,
            string parentResourcePath,
            string resourceType,
            string resourceName,
            string apiVersion = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                string resourceId = ResourceUtils.ConstructResourceId(Manager.Inner.SubscriptionId, resourceGroupName, resourceProviderNamespace, resourceType, resourceName, parentResourcePath);
                apiVersion = await GetApiVersionAsync(resourceId, Manager, cancellationToken);
            }
            return await Inner.CheckExistenceAsync(
                resourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                apiVersion,
                cancellationToken);
        }

        public IBlank Define(string name)
        {
            return new GenericResourceImpl(name, new GenericResourceInner(), Manager);
        }

        public void Delete(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion = default(string))
        {
            Extensions.Synchronize(() => DeleteAsync(resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, apiVersion));
        }

        public async Task DeleteAsync(
            string resourceGroupName,
            string resourceProviderNamespace,
            string parentResourcePath,
            string resourceType,
            string resourceName,
            string apiVersion = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                string resourceId = ResourceUtils.ConstructResourceId(Manager.Inner.SubscriptionId, resourceGroupName, resourceProviderNamespace, resourceType, resourceName, parentResourcePath);
                apiVersion = await GetApiVersionAsync(resourceId, Manager, cancellationToken);
            }
            await Inner.DeleteAsync(
                resourceGroupName,
                resourceProviderNamespace,
                parentResourcePath,
                resourceType,
                resourceName,
                apiVersion,
                cancellationToken);
        }

        public void DeleteById(string id, string apiVersion = default(string))
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, apiVersion, CancellationToken.None));
        }

        public async Task DeleteByIdAsync(string id, string apiVersion = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                apiVersion = await GetApiVersionAsync(id, Manager, cancellationToken);
            }
            await DeleteAsync(
                ResourceUtils.GroupFromResourceId(id),
                ResourceUtils.ResourceProviderFromResourceId(id),
                ResourceUtils.ParentResourcePathFromResourceId(id),
                ResourceUtils.ResourceTypeFromResourceId(id),
                ResourceUtils.NameFromResourceId(id),
                apiVersion,
                cancellationToken);
        }

        public IGenericResource Get(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion = default(string))
        {
            return Extensions.Synchronize(() => GetAsync(
                    resourceGroupName,
                    resourceProviderNamespace,
                    parentResourcePath,
                    resourceType,
                    resourceName,
                    apiVersion));            
        }

        public async Task<IGenericResource> GetAsync(string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            // Correct for auto-gen'd API's treatment parent path as required even though it makes sense only for child resources
            if (string.IsNullOrEmpty(parentResourcePath))
            {
                parentResourcePath = "";
            }
            if (string.IsNullOrEmpty(apiVersion))
            {
                string resourceId = ResourceUtils.ConstructResourceId(Manager.Inner.SubscriptionId, resourceGroupName, resourceProviderNamespace, resourceType, resourceName, parentResourcePath);
                apiVersion = await GetApiVersionAsync(resourceId, Manager, cancellationToken);
            }
            var inner = await Inner.GetAsync(
                    resourceGroupName,
                    resourceProviderNamespace,
                    parentResourcePath,
                    resourceType,
                    resourceName,
                    apiVersion);
            return WrapModelWithApiVersion(inner, apiVersion);
        }

        public IGenericResource GetById(string id, string apiVersion = default(string))
        {
            return Extensions.Synchronize(() => GetByIdAsync(id, apiVersion, CancellationToken.None));
        }

        public async Task<IGenericResource> GetByIdAsync(string id, string apiVersion = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                apiVersion = await GetApiVersionAsync(id, Manager, cancellationToken);
            }
            var inner = await Inner.GetByIdAsync(id, apiVersion, cancellationToken);
            return WrapModelWithApiVersion(inner, apiVersion);
        }

        protected override Task<GenericResourceInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellation)
        {
            throw new NotSupportedException("Get just by resource group and name is not supported. Please use other overloads.");
        }

        public void MoveResources(string sourceResourceGroupName, IResourceGroup targetResourceGroup, IList<string> resources)
        {
            Extensions.Synchronize(() => MoveResourcesAsync(sourceResourceGroupName, targetResourceGroup, resources));
        }

        public async Task MoveResourcesAsync(
            string sourceResourceGroupName,
            IResourceGroup targetResourceGroup,
            IList<string> resources,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourcesMoveInfo moveInfo = new ResourcesMoveInfo()
            {
                TargetResourceGroup = targetResourceGroup.Id,
                Resources = resources,
            };
            await Inner.MoveResourcesAsync(sourceResourceGroupName, moveInfo, cancellationToken);
        }

        protected override IGenericResource WrapModel(GenericResourceInner inner)
        {
            IGenericResource model = (IGenericResource)new GenericResourceImpl(inner.Id, inner, Manager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(inner.Id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(inner.Id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(inner.Id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(inner.Id));
            return model;
        }

        protected override GenericResourceImpl WrapModel(string id)
        {
            GenericResourceImpl model = (GenericResourceImpl)new GenericResourceImpl(id, new GenericResourceInner(), Manager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(id)
            }.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(id));
            return model;
        }

        protected override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("Delete just by resource group and name is not supported. Please use other overloads.");
        }

        public async override Task<IPagedCollection<IGenericResource>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IGenericResource, GenericResourceExpanded>.LoadPage(
                async (cancellation) => await Manager.Inner.Resources.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellation),
                Manager.Inner.Resources.ListByResourceGroupNextAsync, WrapModel, loadAllPages, cancellationToken);
        }

        private class CastedPage<T, S> : IPage<T> where S : T
        {
            private readonly IPage<S> inner;

            internal CastedPage(IPage<S> inner)
            {
                this.inner = inner;
            }

            string IPage<T>.NextPageLink => inner.NextPageLink;

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return new CastedEnumerator<T, S>(inner.GetEnumerator());
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return inner.GetEnumerator();
            }
        }

        private class CastedEnumerator<T, S> : IEnumerator<T> where S : T
        {
            private readonly IEnumerator<S> inner;

            internal CastedEnumerator(IEnumerator<S> inner)
            {
                this.inner = inner;
            }

            T IEnumerator<T>.Current => inner.Current;

            object IEnumerator.Current => inner.Current;

            void IDisposable.Dispose()
            {
                inner.Dispose();
            }

            bool IEnumerator.MoveNext()
            {
                return inner.MoveNext();
            }

            void IEnumerator.Reset()
            {
                inner.Reset();
            }
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return new CastedPage<GenericResourceInner, GenericResourceExpanded>(await this.Inner.ListAsync(cancellationToken: cancellationToken));
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerNextAsync(string link, CancellationToken cancellationToken)
        {
            return new CastedPage<GenericResourceInner, GenericResourceExpanded>(await this.Inner.ListNextAsync(link, cancellationToken));
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return new CastedPage<GenericResourceInner, GenericResourceExpanded>(await Manager.Inner.Resources.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken));
        }

        protected async override Task<IPage<GenericResourceInner>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken)
        {
            return new CastedPage<GenericResourceInner, GenericResourceExpanded>(await Manager.Inner.Resources.ListByResourceGroupNextAsync(link, cancellationToken));
        }

        public IEnumerable<IGenericResource> ListByTag(string resourceGroupName, string tagName, string tagValue)
        {
            return WrapList(Extensions.Synchronize(() => Manager.Inner.Resources.ListByResourceGroupAsync(
                    resourceGroupName, ResourceUtils.CreateODataFilterForTags(tagName, tagValue)))
                    .AsContinuousCollection((nextLink) => Extensions.Synchronize(() => Manager.Inner.Resources.ListByResourceGroupNextAsync(nextLink))));
        }

        public async Task<IPagedCollection<IGenericResource>> ListByTagAsync(string resourceGroupName, string tagName, string tagValue, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IGenericResource, GenericResourceExpanded>.LoadPage(
                async (cancellation) => await Manager.Inner.Resources.ListByResourceGroupAsync(
                    resourceGroupName, ResourceUtils.CreateODataFilterForTags(tagName, tagValue), cancellationToken: cancellation),
                Manager.Inner.Resources.ListByResourceGroupNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        internal static async Task<string> GetApiVersionAsync(string id, IResourceManager resourceManager, CancellationToken cancellationToken)
        {
            string resourceProvider = ResourceUtils.ResourceProviderFromResourceId(id);
            string resourceType = ResourceUtils.ResourceTypeForApiVersion(id);
            string apiVersionKey = resourceProvider + "/" + resourceType;
            cachedApiVersions.TryGetValue(apiVersionKey, out string apiVersionValue);
            if (string.IsNullOrEmpty(apiVersionValue))
            {
                apiVersionValue = ResourceUtils.DefaultApiVersionFromResourceId(
                    id,
                    await resourceManager.Providers.GetByNameAsync(resourceProvider, cancellationToken));
                if (string.IsNullOrEmpty(apiVersionValue))
                {
                    throw new InvalidOperationException(string.Format("{0} is not a supported resource type in provider {1}", resourceType, resourceProvider));
                }
                cachedApiVersions.TryAdd(apiVersionKey, apiVersionValue);
            }
            return await Task.FromResult(apiVersionValue);
        }

        internal static string GetApiVersion(string id, IResourceManager resourceManager)
        {
            return Extensions.Synchronize(() => GetApiVersionAsync(id, resourceManager, CancellationToken.None));
        }

        protected IGenericResource WrapModelWithApiVersion(GenericResourceInner inner, string apiVersion)
        {
            if (inner == null)
            {
                return null;
            }
            GenericResourceImpl resource = new GenericResourceImpl(
                    inner.Name,
                    inner,
                    Manager)
            {
                resourceProviderNamespace = ResourceUtils.ResourceProviderFromResourceId(inner.Id),
                parentResourceId = ResourceUtils.ParentResourcePathFromResourceId(inner.Id),
                resourceType = ResourceUtils.ResourceTypeFromResourceId(inner.Id),
                apiVersion = apiVersion
            };
            return resource;
        }
    }
}
