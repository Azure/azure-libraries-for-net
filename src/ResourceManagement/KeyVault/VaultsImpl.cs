// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Graph.RBAC.Fluent;
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation of Vaults and its parent interfaces.
    /// </summary>
    internal partial class VaultsImpl  :
        TopLevelModifiableResources<IVault, VaultImpl, VaultInner, IVaultsOperations, IKeyVaultManager>,
        IVaults
    {
        private IGraphRbacManager graphRbacManager;
        private string tenantId;

        ///GENMHASH:B150A08031FE64095583576847133217:8935634111618393DD8A78F9B6DBDFBA
        internal VaultsImpl(IKeyVaultManager keyVaultManager, IGraphRbacManager graphRbacManager, string tenantId)
            : base(keyVaultManager.Inner.Vaults, keyVaultManager)
        {
            this.graphRbacManager = graphRbacManager;
            this.tenantId = tenantId;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        protected async override Task<IPage<VaultInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            var innerResources = await Inner.ListAsync(cancellationToken: cancellationToken);

            var results = innerResources
                .Select(r => ResourceId.FromString(r.Id))
                .Select(async resourceId => await GetInnerByGroupAsync(resourceId.ResourceGroupName, resourceId.Name, cancellationToken))
                .ToList()
                .Select(t => t.Result);

            return new VaultInnerPage(results, innerResources.NextPageLink);
        }

        protected async override Task<IPage<VaultInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            var innerResources = await Inner.ListNextAsync(nextLink, cancellationToken: cancellationToken);

            var results = innerResources
                .Select(r => ResourceId.FromString(r.Id))
                .Select(async resourceId => await GetInnerByGroupAsync(resourceId.ResourceGroupName, resourceId.Name, cancellationToken))
                .ToList()
                .Select(t => t.Result);

            return new VaultInnerPage(results, innerResources.NextPageLink);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:BDFF4CB61E8A8D975417EA5FC914921A
        protected async override Task<IPage<VaultInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken: cancellationToken);
        }

        protected async override Task<IPage<VaultInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<VaultInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:913702868132D01F4C836BBF3499B8CE
        public VaultImpl Define(string name)
        {
            return WrapModel(name)
                .WithSku(SkuName.Standard)
                .WithEmptyAccessPolicy();
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:15E2E01BC88FA6B06E6CBBCFC1371788
        protected override VaultImpl WrapModel(string name)
        {
            VaultInner inner = new VaultInner()
            {
                Properties = new VaultProperties()
                {
                    TenantId = Guid.Parse(tenantId)
                }
            };
            return new VaultImpl(
                name,
                inner,
                Manager,
                graphRbacManager);
        }

        ///GENMHASH:CA260E89048F01F05DD7D13D870D6A8F:E833FC60B5F2BCB0CBB9985629CBA229
        protected override IVault WrapModel(VaultInner vaultInner)
        {
            return new VaultImpl(
                vaultInner.Name,
                vaultInner,
                Manager,
                graphRbacManager);
        }

    }

    class VaultInnerPage : IPage<VaultInner>
    {
        private readonly IEnumerable<VaultInner> vaultInnerList;
        private readonly string nextLink;

        public VaultInnerPage(IEnumerable<VaultInner> vaultInnerList, string nextLink)
        {
            this.vaultInnerList = vaultInnerList;
            this.nextLink = nextLink;

        }

        public string NextPageLink => nextLink;

        public IEnumerator<VaultInner> GetEnumerator()
        {
            return vaultInnerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}