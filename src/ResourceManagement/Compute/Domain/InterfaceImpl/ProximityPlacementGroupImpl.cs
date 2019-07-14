// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class ProximityPlacementGroupImpl
    {
        ProximityPlacementGroupType IProximityPlacementGroup.ProximityPlacementGroupType
        {
            get
            {
                return this.ProximityPlacementGroupType();
            }
        }


        IList<string> IProximityPlacementGroup.VirtualMachineIds
        {
            get
            {
                return this.VirtualMachineIds();
            }
        }

        IList<string> IProximityPlacementGroup.VirtualMachineScaleSetIds
        {
            get
            {
                return this.VirtualMachineIds();
            }
        }

        IList<string> IProximityPlacementGroup.AvailabilitySetIds
        {
            get
            {
                return this.AvailabilitySetIds();
            }
        }

        string IProximityPlacementGroup.Location
        {
            get
            {
                return this.Location();
            }
        }

        string IProximityPlacementGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        string IProximityPlacementGroup.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}