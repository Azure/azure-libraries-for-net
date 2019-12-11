// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

    internal partial class DdosProtectionPlanImpl
    {
        /// <summary>
        /// Gets the provisioning state of the DDoS protection plan resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Network.Fluent.IDdosProtectionPlan.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the resource GUID property of the DDoS protection plan resource.
        /// It uniquely identifies a resource, even if the user changes its name or
        /// migrate the resource across subscriptions or resource groups.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IDdosProtectionPlan.ResourceGuid
        {
            get
            {
                return this.ResourceGuid();
            }
        }

        /// <summary>
        /// Gets the list of virtual networks associated with the DDoS protection plan resource. This list is read-only.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<SubResource> Microsoft.Azure.Management.Network.Fluent.IDdosProtectionPlan.VirtualNetworks
        {
            get
            {
                return this.VirtualNetworks();
            }
        }
    }
}