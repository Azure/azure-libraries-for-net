// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the connection monitor definition allowing to add or update tags.
    /// </summary>
    public interface IWithTags 
    {

        /// <summary>
        /// Removes a tag from the connection monitor.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithCreate WithoutTag(string key);

        /// <summary>
        /// Adds a tag to the connection monitor.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithCreate WithTag(string key, string value);

        /// <summary>
        /// Specifies tags for the connection monitor.
        /// </summary>
        /// <param name="tags">Tags indexed by name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithCreate WithTags(IDictionary<string,string> tags);
    }

    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IConnectionMonitor>,
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithSourcePort,
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithAutoStart,
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithMonitoringInterval,
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithTags
    {

    }

    /// <summary>
    /// Sets the destination port used by connection monitor.
    /// </summary>
    public interface IWithDestinationPort 
    {

        /// <param name="port">The ID of the resource used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithCreate WithDestinationPort(int port);
    }

    /// <summary>
    /// Sets the source property.
    /// </summary>
    public interface IWithSource 
    {

        /// <param name="vm">Virtual machine used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestination WithSource(IHasNetworkInterfaces vm);

        /// <param name="resourceId">The ID of the resource used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestination WithSourceId(string resourceId);
    }

    /// <summary>
    /// Sets the source port used by connection monitor.
    /// </summary>
    public interface IWithSourcePort 
    {

        /// <param name="port">Source port used by connection monitor.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestination WithSourcePort(int port);
    }

    /// <summary>
    /// Sets monitoring interval in seconds.
    /// </summary>
    public interface IWithMonitoringInterval 
    {

        /// <param name="seconds">Monitoring interval in seconds.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithCreate WithMonitoringInterval(int seconds);
    }

    /// <summary>
    /// Determines if the connection monitor will start automatically once
    /// created. By default it is started automatically.
    /// </summary>
    public interface IWithAutoStart 
    {

        /// <summary>
        /// Disable auto start.
        /// </summary>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithCreate WithoutAutoStart();
    }

    /// <summary>
    /// Sets the destination.
    /// </summary>
    public interface IWithDestination 
    {

        /// <param name="vm">Virtual machine used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestinationPort WithDestination(IHasNetworkInterfaces vm);

        /// <param name="address">Address of the connection monitor destination (IP or domain name).</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestinationPort WithDestinationAddress(string address);

        /// <param name="resourceId">The ID of the resource used as the source by connection monitor.</param>
        /// <return>Next definition stage.</return>
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestinationPort WithDestinationId(string resourceId);
    }

    /// <summary>
    /// The entirety of the connection monitor definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithSource,
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestination,
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithDestinationPort,
        Microsoft.Azure.Management.Network.Fluent.ConnectionMonitor.Definition.IWithCreate
    {

    }
}