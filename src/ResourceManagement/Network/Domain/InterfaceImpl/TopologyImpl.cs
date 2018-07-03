// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.Topology.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class TopologyImpl
    {
        /// <summary>
        /// Gets the datetime when the topology was initially created for the resource
        /// group.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Network.Fluent.ITopology.CreatedTime
        {
            get
            {
                return this.CreatedTime();
            }
        }

        /// <summary>
        /// Gets GUID representing the id.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.ITopology.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the datetime when the topology was last modified.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Network.Fluent.ITopology.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets The resources in this topology.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Models.TopologyResource> Microsoft.Azure.Management.Network.Fluent.ITopology.Resources
        {
            get
            {
                return this.Resources();
            }
        }

        /// <summary>
        /// Gets parameters used to query this topology.
        /// </summary>
        Models.TopologyParameters Microsoft.Azure.Management.Network.Fluent.ITopology.TopologyParameters
        {
            get
            {
                return this.TopologyParameters();
            }
        }

        /// <summary>
        /// Set the target virtual network.
        /// </summary>
        /// <param name="networkId">The target network id value to set.</param>
        /// <return>The Topology object itself.</return>
        Topology.Definition.IWithExecuteAndSubnet Topology.Definition.IWithTargetNetwork.WithTargetNetwork(string networkId)
        {
            return this.WithTargetNetwork(networkId);
        }

        /// <summary>
        /// Set the targetResourceId value.
        /// </summary>
        /// <param name="resourceGroupName">The name of the target resource group to perform getTopology on.</param>
        /// <return>The Topology object itself.</return>
        Topology.Definition.IWithExecute Topology.Definition.IWithTargetResourceGroup.WithTargetResourceGroup(string resourceGroupName)
        {
            return this.WithTargetResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Set the subnetName value.
        /// </summary>
        /// <param name="subnetName">The destinationIPAddress value to set.</param>
        /// <return>The Topology object itself.</return>
        Topology.Definition.IWithExecute Topology.Definition.IWithTargetSubnet.WithTargetSubnet(string subnetName)
        {
            return this.WithTargetSubnet(subnetName);
        }
    }
}