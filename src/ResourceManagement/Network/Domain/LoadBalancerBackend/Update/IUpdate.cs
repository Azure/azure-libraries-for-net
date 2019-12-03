// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a load balancer backend update as part of a load balancer update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        IWithVirtualMachines
    {
    }

    /// <summary>
    /// The stage of a load balancer backend definition allowing to select a set of virtual machines to load balance
    /// the network traffic among.
    /// </summary>
    public interface IWithVirtualMachines
    {
        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this back end address pool.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with this back end.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update.IUpdate WithExistingVirtualMachines(params IHasNetworkInterfaces[] vms);

        /// <summary>
        /// Adds the specified set of virtual machines, assuming they are from the same
        /// availability set, to this backend address pool.
        /// This will add references to the primary IP configurations of the primary network interfaces of
        /// the provided set of virtual machines.
        /// If the virtual machines are not in the same availability set, they will not be associated with this back end.
        /// Only those virtual machines will be associated with the load balancer that already have an existing
        /// network interface. Virtual machines without a network interface will be skipped.
        /// </summary>
        /// <param name="vms">Existing virtual machines.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update.IUpdate WithExistingVirtualMachines(ICollection<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms);

        /// <summary>
        /// Removes the specified set of virtual machines from this backend address pool.
        /// </summary>
        /// <param name="vms">Existing virtual machines to be removed from this backend.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update.IUpdate WithoutExistingVirtualMachines(params IHasNetworkInterfaces[] vms);

        /// <summary>
        /// Removes the specified set of virtual machines from this backend address pool.
        /// </summary>
        /// <param name="vms">Existing virtual machines to be removed from this backend.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update.IUpdate WithoutExistingVirtualMachines(IEnumerable<Microsoft.Azure.Management.Network.Fluent.IHasNetworkInterfaces> vms);
    }
}