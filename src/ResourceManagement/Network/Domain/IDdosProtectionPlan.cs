// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Network.Fluent.DdosProtectionPlan.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// DDoS protection plan.
    /// </summary>
    public interface IDdosProtectionPlan :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager, Models.DdosProtectionPlanInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IDdosProtectionPlan>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<DdosProtectionPlan.Update.IUpdate>
    {

        /// <summary>
        /// Gets the provisioning state of the DDoS protection plan resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the resource GUID property of the DDoS protection plan resource.
        /// It uniquely identifies a resource, even if the user changes its name or
        /// migrate the resource across subscriptions or resource groups.
        /// </summary>
        string ResourceGuid { get; }

        /// <summary>
        /// Gets the list of virtual networks associated with the DDoS protection plan resource. This list is read-only.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<SubResource> VirtualNetworks { get; }
    }
}