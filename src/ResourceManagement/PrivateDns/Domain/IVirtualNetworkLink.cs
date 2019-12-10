// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a virtual network link in Azure Private DNS Zone.
    /// </summary>
    public interface IVirtualNetworkLink :
        IExternalChildResource<IVirtualNetworkLink, IPrivateDnsZone>,
        IHasInner<VirtualNetworkLinkInner>
    {
        /// <summary>
        /// Gets the etag associated with the virtual network link.
        /// </summary>
        string ETag { get; }

        /// <summary>
        /// Gets the ID of referenced virtual network.
        /// </summary>
        string ReferencedVirtualNetworkId { get; }

        /// <summary>
        /// Gets the flag whether auto-registration of virtual machine records in the
        /// virtual network in the Private DNS zone is enabled.
        /// </summary>
        bool IsAutoRegistrationEnabled { get; }

        /// <summary>
        /// Gets the status of the virtual network link to the Private DNS zone.
        /// </summary>
        VirtualNetworkLinkState VirtualNetworkLinkState { get; }

        /// <summary>
        /// Gets the provisioning state of the virtual network link.
        /// </summary>
        ProvisioningState ProvisioningState { get; }
    }
}
