// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    internal partial class ProximityPlacementGroupImpl : IProximityPlacementGroup
    {
        private readonly ProximityPlacementGroupInner inner;

        ProximityPlacementGroupInner ResourceManager.Fluent.Core.IHasInner<ProximityPlacementGroupInner>.Inner => this.Inner();

        public ProximityPlacementGroupImpl(ProximityPlacementGroupInner inner)
        {
            this.inner = inner;
        }

        public ProximityPlacementGroupInner Inner()
        {
            return this.inner;
        }
        public ProximityPlacementGroupType ProximityPlacementGroupType()
        {
            return this.inner.ProximityPlacementGroupType;
        }

        public IList<string> VirtualMachineIds()
        {
            return this.inner.VirtualMachines.Select(vm => vm.Id).ToList();
        }

        public IList<string> VirtualMachineScaleSetIds()
        {
            return this.inner.VirtualMachineScaleSets.Select(vmss => vmss.Id).ToList();
        }

        public IList<string> AvailabilitySetIds()
        {
            return this.inner.AvailabilitySets.Select(availSet => availSet.Id).ToList();
        }

        public string Location()
        {
            return this.inner.Location;
        }

        public string ResourceGroupName()
        {
            return ResourceManager.Fluent.Core.ResourceId.FromString(this.Id()).ResourceGroupName;
        }

        public string Id()
        {
            return this.inner.Id;
        }
    }
}
