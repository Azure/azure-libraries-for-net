// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine.
    /// </summary>
    public interface IVirtualMachineBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the type of Managed Service Identity used for the virtual machine.
        /// </summary>
        Models.ResourceIdentityType? ManagedServiceIdentityType { get; }

        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory service principal ID assigned
        /// to the virtual machine.
        /// </summary>
        string ManagedServiceIdentityPrincipalId { get; }

        /// <summary>
        /// Gets true if Managed Service Identity is enabled for the virtual machine scale set.
        /// </summary>
        bool IsManagedServiceIdentityEnabled { get; }

        /// <summary>
        /// Gets the Managed Service Identity specific Active Directory tenant ID assigned to the
        /// virtual machine.
        /// </summary>
        string ManagedServiceIdentityTenantId { get; }

        /// <summary>
        /// Gets the availability zones assigned to the virtual machine.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.ResourceManager.Fluent.Core.AvailabilityZoneId> AvailabilityZones { get; }
  }
}