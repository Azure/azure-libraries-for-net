// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.Topology.Definition
{
    public interface IWithExecuteAndSubnet  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.ITopology>,
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithTargetSubnet
    {

    }

    /// <summary>
    /// The entirety of topology parameters definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithTargetResourceGroup,
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithExecute,
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithExecuteAndSubnet
    {

    }

    /// <summary>
    /// Sets the target virtual network.
    /// </summary>
    public interface IWithTargetNetwork 
    {

        /// <summary>
        /// Set the target virtual network.
        /// </summary>
        /// <param name="networkId">The target network id value to set.</param>
        /// <return>The Topology object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithExecuteAndSubnet WithTargetNetwork(string networkId);
    }

    /// <summary>
    /// Sets the target subnet.
    /// </summary>
    public interface IWithTargetSubnet 
    {

        /// <summary>
        /// Set the subnetName value.
        /// </summary>
        /// <param name="subnetName">The destinationIPAddress value to set.</param>
        /// <return>The Topology object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithExecute WithTargetSubnet(string subnetName);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for execution, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.ITopology>,
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithTargetNetwork
    {

    }

    /// <summary>
    /// The first stage of topology parameters definition.
    /// </summary>
    public interface IWithTargetResourceGroup 
    {

        /// <summary>
        /// Set the targetResourceId value.
        /// </summary>
        /// <param name="resourceGroupName">The name of the target resource group to perform getTopology on.</param>
        /// <return>The Topology object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.Topology.Definition.IWithExecute WithTargetResourceGroup(string resourceGroupName);
    }
}