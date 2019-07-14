// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    public interface IProximityPlacementGroup : ResourceManager.Fluent.Core.IHasInner<ProximityPlacementGroupInner>
    {
        /// <summary>
        /// Get specifies the type of the proximity placement group. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Standard** &lt;br&gt;&lt;br&gt; **Ultra**. Possible values include: 'Standard', 'Ultra'.
        /// </summary>
        ProximityPlacementGroupType ProximityPlacementGroupType { get; }

        /// <summary>
        /// Get a list of references to all virtual machines in the proximity placement group.
        /// </summary>
        System.Collections.Generic.IList<string> VirtualMachineIds { get; }

        /// <summary>
        /// Get a list of references to all virtual machine scale sets in the proximity placement group.
        /// </summary>
        System.Collections.Generic.IList<string> VirtualMachineScaleSetIds { get; }

        /// <summary>
        /// Get a list of references to all availability sets in the proximity placement group.
        /// </summary>
        System.Collections.Generic.IList<string> AvailabilitySetIds { get; }
    }
}
