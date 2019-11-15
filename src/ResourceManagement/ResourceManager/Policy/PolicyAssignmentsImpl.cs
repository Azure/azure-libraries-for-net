// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.PolicyAssignment.Definition;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PolicyAssignmentsImpl :
        CreatableWrappers<IPolicyAssignment, PolicyAssignmentImpl, PolicyAssignmentInner>,
        IPolicyAssignments
    {
        private readonly IPolicyAssignmentsOperations client;

        internal PolicyAssignmentsImpl(IPolicyAssignmentsOperations client)
        {
            this.client = client;
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, CancellationToken.None));
        }

        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteByIdAsync(id, cancellationToken);
        }

        public IPolicyAssignment GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id, CancellationToken.None)); 
        }

        public async Task<IPolicyAssignment> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await client.GetByIdAsync(id, cancellationToken);
            return null == inner ? null : WrapModel(inner);
        }

        public IEnumerable<IPolicyAssignment> List()
        {
            return Extensions.Synchronize(() => ListAsync(cancellationToken: CancellationToken.None));
        }

        public async Task<IPagedCollection<IPolicyAssignment>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPolicyAssignment, PolicyAssignmentInner>.LoadPage(
                    async (cancellation) => await client.ListAsync(cancellationToken: cancellation),
                    client.ListNextAsync, 
                    WrapModel, 
                    loadAllPages, 
                    cancellationToken
                );
        }

        public IEnumerable<IPolicyAssignment> ListByResource(string resourceId)
        {
            return Extensions.Synchronize(() => ListByResourceAsync(resourceId, CancellationToken.None));
        }

        public async Task<IPagedCollection<IPolicyAssignment>> ListByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPolicyAssignment, PolicyAssignmentInner>.LoadPage(
                    async (cancellation) => await client.ListForResourceAsync(
                        resourceGroupName: ResourceUtils.GroupFromResourceId(resourceId),
                        resourceProviderNamespace: ResourceUtils.ResourceProviderFromResourceId(resourceId),
                        parentResourcePath: ResourceUtils.ParentResourcePathFromResourceId(resourceId),
                        resourceType: ResourceUtils.ResourceTypeFromResourceId(resourceId),
                        resourceName: ResourceUtils.NameFromResourceId(resourceId),
                        cancellationToken: cancellation
                        ),
                    WrapModel,
                    cancellationToken
                );
        }

        public IEnumerable<IPolicyAssignment> ListByResourceGroup(string resourceGroupName)
        {
            return Extensions.Synchronize(() => ListByResourceGroupAsync(resourceGroupName, cancellationToken: CancellationToken.None));
        }

        public async Task<IPagedCollection<IPolicyAssignment>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPolicyAssignment, PolicyAssignmentInner>.LoadPage(
                    async (cancellation) => await client.ListForResourceGroupAsync(
                        resourceGroupName,
                        cancellationToken: cancellation),
                    client.ListForResourceGroupNextAsync,
                    WrapModel,
                    loadAllPages,
                    cancellationToken
                );
        }

        protected override PolicyAssignmentImpl WrapModel(string name)
        {
            return new PolicyAssignmentImpl(new PolicyAssignmentInner(name: name), client);
        }

        protected override IPolicyAssignment WrapModel(PolicyAssignmentInner inner)
        {
            return new PolicyAssignmentImpl(inner, client);
        }
    }
}
