// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The SQL Firewall Rule definition to set the IP address range for the parent SQL Server.
    /// </summary>
    public interface IWithIPAddressRange<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the starting IP address of SQL server's Firewall Rule.
        /// </summary>
        /// <param name="startIPAddress">Starting IP address in IPv4 format.</param>
        /// <param name="endIPAddress">Starting IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithAttach<ParentT> WithIPAddressRange(string startIPAddress, string endIPAddress);
    }

    /// <summary>
    /// The final stage of the SQL Firewall Rule definition.
    /// At this stage, any remaining optional settings can be specified, or the SQL Firewall Rule definition
    /// can be attached to the parent SQL Server definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The first stage of the SQL Server Firewall Rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithIPAddressRange<ParentT>,
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithIPAddress<ParentT>
    {
    }

    /// <summary>
    /// The SQL Firewall Rule definition to set the IP address for the parent SQL Server.
    /// </summary>
    public interface IWithIPAddress<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the ending IP address of SQL server's Firewall Rule.
        /// </summary>
        /// <param name="ipAddress">IP address in IPv4 format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlFirewallRule.Definition.IWithAttach<ParentT> WithIPAddress(string ipAddress);
    }
}