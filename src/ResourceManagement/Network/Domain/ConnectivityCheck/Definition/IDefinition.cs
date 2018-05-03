// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Sets the source property.
    /// </summary>
    public interface IFromSourceVirtualMachine
    {
        /// <param name="resourceId">The ID of the virtual machine from which a connectivity check will be initiated.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IWithExecute FromSourceVirtualMachine(string resourceId);

        /// <param name="vm">Virtual machine from which a connectivity check will be initiated.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IWithExecute FromSourceVirtualMachine(IHasNetworkInterfaces vm);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for execution, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IConnectivityCheck>,
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IFromSourcePort,
    Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IWithExecute,Microsoft.Azure.Management.Network.Fluent.Models.Protocol>
    {
    }

    /// <summary>
    /// The entirety of connectivity check parameters definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IToDestination,
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IToDestinationPort,
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IFromSourceVirtualMachine,
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IWithExecute
    {
    }

    /// <summary>
    /// Sets the source port from which a connectivity check will be performed.
    /// </summary>
    public interface IFromSourcePort
    {
        /// <param name="port">Source port.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IWithExecute FromSourcePort(int port);
    }

    /// <summary>
    /// Sets the destination property.
    /// </summary>
    public interface IToDestination
    {
        /// <param name="resourceId">The ID of the resource to which a connection attempt will be made.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IToDestinationPort ToDestinationResourceId(string resourceId);

        /// <param name="address">The IP address or URI the resource to which a connection attempt will be made.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IToDestinationPort ToDestinationAddress(string address);
    }

    /// <summary>
    /// Sets the destination port on which check connectivity will be performed.
    /// </summary>
    public interface IToDestinationPort
    {
        /// <param name="port">Destination port.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectivityCheck.Definition.IFromSourceVirtualMachine ToDestinationPort(int port);
    }
}