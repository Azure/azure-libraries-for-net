// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Models;

namespace Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of the security rule definition allowing the protocol that the rule applies to to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ParentT>
    {
        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithAnyProtocol();

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithProtocol(SecurityRuleProtocol protocol);
    }

    /// <summary>
    /// The entirety of a network security rule definition as part of a network security group update.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT>
    {

    }

        /// <summary>
    /// The stage of the network rule description allowing the direction and the access type to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDirectionAccess<ParentT>
    {
        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<ParentT> AllowInbound();

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<ParentT> AllowOutbound();

    /// <summary>
        /// Blocks inbound traffic.
    /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<ParentT> DenyInbound();

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<ParentT> DenyOutbound();
    }

        /// <summary>
    /// The stage of the network rule definition allowing the destination address to be specified.
    /// Note: network security rule must specify a non empty value for exactly one of:
    /// DestinationAddressPrefixes, DestinationAddressPrefix, DestinationApplicationSecurityGroups.
        /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDestinationAddressOrSecurityGroup<ParentT>
    {

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<ParentT> ToAddress(string cidr);

        /// <summary>
        /// Specifies the traffic destination address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<ParentT> ToAddresses(params string[] addresses);

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<ParentT> ToAnyAddress();

    /// <summary>
        /// Sets the application security group specified as destination.
    /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<ParentT> WithDestinationApplicationSecurityGroup(string id);
    }

    /// <summary>
    /// The stage of the network rule definition allowing the source port(s) to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSourcePort<ParentT>
    {
        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<ParentT> FromAnyPort();

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<ParentT> FromPort(int port);

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<ParentT> FromPortRange(int from, int to);

        /// <summary>
        /// Specifies the source port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The starting port ranges.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<ParentT> FromPortRanges(params string[] ranges);
    }

    /// <summary>
    /// The first stage of a security rule description as part of an update of a networking security group.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<ParentT>
    {

    }

    /// <summary>
    /// The stage of the network rule definition allowing the destination port(s) to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDestinationPort<ParentT>
    {

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT> ToAnyPort();

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT> ToPort(int port);

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT> ToPortRange(int from, int to);

        /// <summary>
        /// Specifies the destination port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The destination port ranges.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithProtocol<ParentT> ToPortRanges(params string[] ranges);
    }

        /// <summary>
    /// The stage of the network rule definition allowing the source address to be specified.
    /// Note: network security rule must specify a non empty value for exactly one of:
    /// SourceAddressPrefixes, SourceAddressPrefix, SourceApplicationSecurityGroups.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSourceAddressOrSecurityGroup<ParentT>
    {

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<ParentT> FromAddress(string cidr);

        /// <summary>
        /// Specifies the traffic source address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<ParentT> FromAddresses(params string[] addresses);

    /// <summary>
        /// Specifies that the rule applies to any traffic source address.
    /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<ParentT> FromAnyAddress();

        /// <summary>
        /// Sets the application security group specified as source.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithSourcePort<ParentT> WithSourceApplicationSecurityGroup(string id);
    }

        /// <summary>
    /// The final stage of the security rule definition.
    /// At this stage, any remaining optional settings can be specified, or the security rule definition
    /// can be attached to the parent network security group definition using  WithAttach.attach().
        /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="descrtiption">A text description to associate with the security rule.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithDescription(string descrtiption);

    /// <summary>
        /// Specifies the priority to assign to this rule.
        /// Security rules are applied in the order of their assigned priority.
    /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition.IWithAttach<ParentT> WithPriority(int priority);
    }
}