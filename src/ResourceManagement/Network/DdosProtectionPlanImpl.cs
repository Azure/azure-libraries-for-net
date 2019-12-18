// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Network.Fluent.DdosProtectionPlan.Definition;
    using Microsoft.Azure.Management.Network.Fluent.DdosProtectionPlan.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for DdosProtectionPlan and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uRGRvc1Byb3RlY3Rpb25QbGFuSW1wbA==
    internal partial class DdosProtectionPlanImpl :
        GroupableResource<
            IDdosProtectionPlan,
            DdosProtectionPlanInner,
            DdosProtectionPlanImpl,
            INetworkManager,
            IWithGroup,
            IWithCreate,
            IWithCreate,
            IUpdate
        >,
        IDdosProtectionPlan,
        IDefinition,
        IUpdate
    {

        ///GENMHASH:E52830CE33021C0590F8EB7F2BC65054:3881994DCADCE14215F82F0CC81BDD88
        internal DdosProtectionPlanImpl(string name, DdosProtectionPlanInner innerModel, INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:F88CDC218B58DCAFF2A2BB5A932BD196
        protected override async Task<Models.DdosProtectionPlanInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DdosProtectionPlans.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:575791C5B65702BB0207EBB86C505DCF
        public override async Task<Microsoft.Azure.Management.Network.Fluent.IDdosProtectionPlan> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetInner(await this.Manager.Inner.DdosProtectionPlans.CreateOrUpdateAsync(ResourceGroupName, Name, Inner));
            return this;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:DAB8B84E516B09FDD9E8DC791B6A53CF:F89E32D41886BEB25B27A5222FC7F025
        public string ResourceGuid()
        {
            return Inner.ResourceGuid;
        }

        ///GENMHASH:3432D5F9AA6D1AC31DF96CB75325C37A:A14ACA04E5E1D457B8AC97821B48DDD6
        public IReadOnlyList<SubResource> VirtualNetworks()
        {
            return Inner.VirtualNetworks.ToList();
        }
    }
}