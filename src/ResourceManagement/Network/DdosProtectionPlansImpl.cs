// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.DdosProtectionPlan.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Implementation for DdosProtectionPlans.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uRGRvc1Byb3RlY3Rpb25QbGFuc0ltcGw=
    internal partial class DdosProtectionPlansImpl  :
        TopLevelModifiableResources<
            Microsoft.Azure.Management.Network.Fluent.IDdosProtectionPlan,
            Microsoft.Azure.Management.Network.Fluent.DdosProtectionPlanImpl,
            Models.DdosProtectionPlanInner,
            IDdosProtectionPlansOperations,
            Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        IDdosProtectionPlans
    {
        ///GENMHASH:D62CD590771BE3C6C78E0465A3B0776B:6013A88F9FCAE22958CBB7AA59AFC636
        internal DdosProtectionPlansImpl(INetworkManager networkManager) : base(networkManager.Inner.DdosProtectionPlans, networkManager)
        {
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:3DCC69EC8D38EE3DACD3F2692DFE39AD
        protected override DdosProtectionPlanImpl WrapModel(string name)
        {
            DdosProtectionPlanInner inner = new DdosProtectionPlanInner();
            return new DdosProtectionPlanImpl(name, inner, Manager);
        }

        ///GENMHASH:7AC73E1BD7706C421FC8A2630503FE26:7DA5B1DD2B65AB8ED9049EFDA7288A64
        protected override IDdosProtectionPlan WrapModel(DdosProtectionPlanInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new DdosProtectionPlanImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public DdosProtectionPlanImpl Define(string name)
        {
            return WrapModel(name);
        }


        protected override async Task<DdosProtectionPlanInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected override async Task<IPage<DdosProtectionPlanInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected override async Task<IPage<DdosProtectionPlanInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<IPage<DdosProtectionPlanInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken: cancellationToken);
        }

        protected override async Task<IPage<DdosProtectionPlanInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }
    }
}