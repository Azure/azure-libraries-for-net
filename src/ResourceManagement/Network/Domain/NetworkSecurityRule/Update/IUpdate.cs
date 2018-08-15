// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Models;

namespace Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update
{
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of the network rule description allowing the destination address to be specified.
    /// Note: network security rule must specify a non empty value for exactly one of:
    /// DestinationAddressPrefixes, DestinationAddressPrefix, DestinationApplicationSecurityGroups.
        /// </summary>
    public interface IWithDestinationAddressOrSecurityGroup
    {

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToAddress(string cidr);

        /// <summary>
        /// Specifies the traffic destination address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToAddresses(params string[] addresses);

    /// <summary>
        /// Makes the rule apply to any traffic destination address.
    /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToAnyAddress();

        /// <summary>
        /// Sets the application security group specified as destination.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithDestinationApplicationSecurityGroup(string id);
    }

    /// <summary>
    /// The stage of the network rule description allowing the destination port(s) to be specified.
    /// </summary>
    public interface IWithDestinationPort
    {

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToAnyPort();

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToPort(int port);

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToPortRange(int from, int to);

        /// <summary>
        /// Specifies the destination port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The destination port ranges.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate ToPortRanges(params string[] ranges);
    }

        /// <summary>
    /// The stage of the network rule description allowing the direction and the access type to be specified.
    /// </summary>
    public interface IWithDirectionAccess
    {

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate AllowInbound();

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate AllowOutbound();

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate DenyInbound();

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate DenyOutbound();
    }

    /// <summary>
    /// The stage of the security rule description allowing the protocol that the rule applies to to be specified.
    /// </summary>
    public interface IWithProtocol
    {
        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithAnyProtocol();

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithProtocol(SecurityRuleProtocol protocol);
    }

    /// <summary>
    /// The stage of the network rule description allowing the source port(s) to be specified.
    /// </summary>
    public interface IWithSourcePort
    {
        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromAnyPort();

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromPort(int port);

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromPortRange(int from, int to);

        /// <summary>
        /// Specifies the source port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The starting port ranges.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromPortRanges(params string[] ranges);
    }

    /// <summary>
    /// The stage of the network rule description allowing the source address to be specified.
    /// Note: network security rule must specify a non empty value for exactly one of:
    /// SourceAddressPrefixes, SourceAddressPrefix, SourceApplicationSecurityGroups.
    /// </summary>
    public interface IWithSourceAddressOrSecurityGroup
    {
        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromAddress(string cidr);

        /// <summary>
        /// Specifies the traffic source address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromAddresses(params string[] addresses);

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate FromAnyAddress();

    /// <summary>
        /// Sets the application security group specified as source.
    /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithSourceApplicationSecurityGroup(string id);
    }

        /// <summary>
    /// The entirety of a security rule update as part of a network security group update.
        /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDirectionAccess,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithSourceAddressOrSecurityGroup,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithSourcePort,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDestinationAddressOrSecurityGroup,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithDestinationPort,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IWithProtocol,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update.IUpdate>
    {

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">A text description to associate with this security rule.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithDescription(string description);

        /// <summary>
        /// Specifies the priority to assign to this security rule.
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update.IUpdate WithPriority(int priority);
    }
}