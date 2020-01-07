// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for Azure firewall NAT rule collection management API in Azure.
    /// </summary>
    public interface IAzureFirewallNatRuleCollection
    {
        /// <summary>
        /// Gets priority of the NAT rule collection resource.
        /// </summary>
        int? Priority { get; }

        /// <summary>
        /// Gets the action type of a NAT rule collection.
        /// </summary>
        AzureFirewallNatRCAction Action { get; }

        /// <summary>
        /// Gets collection of rules used by a NAT rule collection.
        /// </summary>
        IReadOnlyList<AzureFirewallNatRule> Rules { get; }

        /// <summary>
        /// Gets the provisioning state of the Azure firewall IP configuration
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets name of the resource.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        string Etag { get; }

        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        string Id { get; }
    }
}
