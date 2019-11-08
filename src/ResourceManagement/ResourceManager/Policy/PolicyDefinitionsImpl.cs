// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.PolicyDefinition.Definition;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    class PolicyDefinitionsImpl :
        CreatableWrappers<IPolicyDefinition, PolicyDefinitionImpl, PolicyDefinitionInner>,
        IPolicyDefinitions
    {
        private readonly IPolicyDefinitionsOperations client;

        internal PolicyDefinitionsImpl(IPolicyDefinitionsOperations client)
        {
            this.client = client;
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public override void DeleteById(string id)
        {
            throw new System.NotSupportedException();
        }

        public override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotSupportedException();
        }

        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name, CancellationToken.None));
        }

        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await client.DeleteAsync(name, cancellationToken);
        }

        public IPolicyDefinition GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name, CancellationToken.None));
        }

        public async Task<IPolicyDefinition> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await client.GetAsync(name, cancellationToken);
            return null == inner ? null : WrapModel(inner);
        }

        public IEnumerable<IPolicyDefinition> List()
        {
            return Extensions.Synchronize(() => ListAsync(cancellationToken: CancellationToken.None));
        }

        public async Task<IPagedCollection<IPolicyDefinition>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPolicyDefinition, PolicyDefinitionInner>.LoadPage(
                    async (cancellation) => await client.ListAsync(cancellation),
                    client.ListNextAsync,
                    WrapModel,
                    loadAllPages,
                    cancellationToken
                );
        }

        protected override PolicyDefinitionImpl WrapModel(string name)
        {
            return new PolicyDefinitionImpl(new PolicyDefinitionInner(name: name), client);
        }

        protected override IPolicyDefinition WrapModel(PolicyDefinitionInner inner)
        {
            return new PolicyDefinitionImpl(inner, client);
        }
    }
}
