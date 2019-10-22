// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class NetworkSecurityRuleImpl
    {
        /// <summary>
        /// Gets the type of access the rule enforces.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Access
        {
            get
            {
                return this.Access();
            }
        }

        /// <summary>
        /// Gets the user-defined description of the security rule.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets the destination address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",
        /// and "" means "any".
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationAddressPrefix
        {
            get
            {
                return this.DestinationAddressPrefix();
            }
        }

        /// <summary>
        /// Gets the list of destination address prefixes the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",
        /// and "" means "any", or IP addresses.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationAddressPrefixes
        {
            get
            {
                return this.DestinationAddressPrefixes();
            }
        }

        /// <summary>
        /// Gets list of application security group ids specified as destination.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationApplicationSecurityGroupIds
        {
            get
            {
                return this.DestinationApplicationSecurityGroupIds();
            }
        }

        /// <summary>
        /// Gets the destination port range that the rule applies to, in the format "##-##", where "" means any.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationPortRange
        {
            get
            {
                return this.DestinationPortRange();
            }
        }

        /// <summary>
        /// Gets the destination port ranges that the rule applies to, in the format "##-##", where "" means any.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.DestinationPortRanges
        {
            get
            {
                return this.DestinationPortRanges();
            }
        }

        /// <summary>
        /// Gets the direction of the network traffic that the network security rule applies to.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Direction
        {
            get
            {
                return this.Direction();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the priority number of this rule based on which this rule will be applied relative to the priority numbers of any other rules specified
        /// for this network security group.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Priority
        {
            get
            {
                return this.Priority();
            }
        }

        /// <summary>
        /// Gets the network protocol the rule applies to.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.Protocol
        {
            get
            {
                return this.Protocol();
            }
        }

        /// <summary>
        /// Gets the source address prefix the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",
        /// and "" means "any".
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourceAddressPrefix
        {
            get
            {
                return this.SourceAddressPrefix();
            }
        }

        /// <summary>
        /// Gets the list of source address prefixes the rule applies to, expressed using the CIDR notation in the format: "###.###.###.###/##",
        /// and "" means "any", or IP addresses.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourceAddressPrefixes
        {
            get
            {
                return this.SourceAddressPrefixes();
            }
        }

        /// <summary>
        /// Gets list of application security group ids specified as source.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourceApplicationSecurityGroupIds
        {
            get
            {
                return this.SourceApplicationSecurityGroupIds();
            }
        }

        /// <summary>
        /// Gets the source port range that the rule applies to, in the format "##-##", where "" means "any".
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourcePortRange
        {
            get
            {
                return this.SourcePortRange();
            }
        }

        /// <summary>
        /// Gets the source port ranges that the rule applies to, in the format "##-##", where "" means "any".
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.INetworkSecurityRule.SourcePortRanges
        {
            get
            {
                return this.SourcePortRanges();
            }
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.AllowInbound()
        {
            return this.AllowInbound();
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.AllowInbound()
        {
            return this.AllowInbound();
        }

        /// <summary>
        /// Allows inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.AllowInbound()
        {
            return this.AllowInbound();
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.AllowOutbound()
        {
            return this.AllowOutbound();
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.AllowOutbound()
        {
            return this.AllowOutbound();
        }

        /// <summary>
        /// Allows outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.AllowOutbound()
        {
            return this.AllowOutbound();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        NetworkSecurityGroup.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<NetworkSecurityGroup.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        NetworkSecurityGroup.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<NetworkSecurityGroup.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.DenyInbound()
        {
            return this.DenyInbound();
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.DenyInbound()
        {
            return this.DenyInbound();
        }

        /// <summary>
        /// Blocks inbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.DenyInbound()
        {
            return this.DenyInbound();
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDirectionAccess<NetworkSecurityGroup.Definition.IWithCreate>.DenyOutbound()
        {
            return this.DenyOutbound();
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDirectionAccess<NetworkSecurityGroup.Update.IUpdate>.DenyOutbound()
        {
            return this.DenyOutbound();
        }

        /// <summary>
        /// Blocks outbound traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDirectionAccess.DenyOutbound()
        {
            return this.DenyOutbound();
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.FromAddress(string cidr)
        {
            return this.FromAddress(cidr);
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.FromAddress(string cidr)
        {
            return this.FromAddress(cidr);
        }

        /// <summary>
        /// Specifies the traffic source address prefix to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address prefix expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddressOrSecurityGroup.FromAddress(string cidr)
        {
            return this.FromAddress(cidr);
        }

        /// <summary>
        /// Specifies the traffic source address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.FromAddresses(params string[] addresses)
        {
            return this.FromAddresses(addresses);
        }

        /// <summary>
        /// Specifies the traffic source address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.FromAddresses(params string[] addresses)
        {
            return this.FromAddresses(addresses);
        }

        /// <summary>
        /// Specifies the traffic source address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddressOrSecurityGroup.FromAddresses(params string[] addresses)
        {
            return this.FromAddresses(addresses);
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.FromAnyAddress()
        {
            return this.FromAnyAddress();
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.FromAnyAddress()
        {
            return this.FromAnyAddress();
        }

        /// <summary>
        /// Specifies that the rule applies to any traffic source address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddressOrSecurityGroup.FromAnyAddress()
        {
            return this.FromAnyAddress();
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromAnyPort()
        {
            return this.FromAnyPort();
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>.FromAnyPort()
        {
            return this.FromAnyPort();
        }

        /// <summary>
        /// Makes this rule apply to any source port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromAnyPort()
        {
            return this.FromAnyPort();
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromPort(int port)
        {
            return this.FromPort(port);
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>.FromPort(int port)
        {
            return this.FromPort(port);
        }

        /// <summary>
        /// Specifies the source port to which this rule applies.
        /// </summary>
        /// <param name="port">The source port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromPort(int port)
        {
            return this.FromPort(port);
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to);
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to);
        }

        /// <summary>
        /// Specifies the source port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromPortRange(int from, int to)
        {
            return this.FromPortRange(from, to);
        }

        /// <summary>
        /// Specifies the source port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The starting port ranges.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourcePort.FromPortRanges(params string[] ranges)
        {
            return this.FromPortRanges(ranges);
        }

        /// <summary>
        /// Specifies the source port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The starting port ranges.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate>.FromPortRanges(params string[] ranges)
        {
            return this.FromPortRanges(ranges);
        }

        /// <summary>
        /// Specifies the source port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The starting port ranges.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate>.FromPortRanges(params string[] ranges)
        {
            return this.FromPortRanges(ranges);
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        /// <return>The next stage of the update.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddressOrSecurityGroup.ToAddress(string cidr)
        {
            return this.ToAddress(cidr);
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.ToAddress(string cidr)
        {
            return this.ToAddress(cidr);
        }

        /// <summary>
        /// Specifies the traffic destination address range to which this rule applies.
        /// </summary>
        /// <param name="cidr">An IP address range expressed in the CIDR notation.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.ToAddress(string cidr)
        {
            return this.ToAddress(cidr);
        }

        /// <summary>
        /// Specifies the traffic destination address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddressOrSecurityGroup.ToAddresses(params string[] addresses)
        {
            return this.ToAddresses(addresses);
        }

        /// <summary>
        /// Specifies the traffic destination address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.ToAddresses(params string[] addresses)
        {
            return this.ToAddresses(addresses);
        }

        /// <summary>
        /// Specifies the traffic destination address prefixes to which this rule applies.
        /// </summary>
        /// <param name="addresses">IP address prefixes in CIDR notation or IP addresses.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.ToAddresses(params string[] addresses)
        {
            return this.ToAddresses(addresses);
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddressOrSecurityGroup.ToAnyAddress()
        {
            return this.ToAnyAddress();
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.ToAnyAddress()
        {
            return this.ToAnyAddress();
        }

        /// <summary>
        /// Makes the rule apply to any traffic destination address.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.ToAnyAddress()
        {
            return this.ToAnyAddress();
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>.ToAnyPort()
        {
            return this.ToAnyPort();
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToAnyPort()
        {
            return this.ToAnyPort();
        }

        /// <summary>
        /// Makes this rule apply to any destination port.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToAnyPort()
        {
            return this.ToAnyPort();
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>.ToPort(int port)
        {
            return this.ToPort(port);
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToPort(int port)
        {
            return this.ToPort(port);
        }

        /// <summary>
        /// Specifies the destination port to which this rule applies.
        /// </summary>
        /// <param name="port">The destination port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToPort(int port)
        {
            return this.ToPort(port);
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to);
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to);
        }

        /// <summary>
        /// Specifies the destination port range to which this rule applies.
        /// </summary>
        /// <param name="from">The starting port number.</param>
        /// <param name="to">The ending port number.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToPortRange(int from, int to)
        {
            return this.ToPortRange(from, to);
        }

        /// <summary>
        /// Specifies the destination port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The destination port ranges.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate>.ToPortRanges(params string[] ranges)
        {
            return this.ToPortRanges(ranges);
        }

        /// <summary>
        /// Specifies the destination port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The destination port ranges.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate>.ToPortRanges(params string[] ranges)
        {
            return this.ToPortRanges(ranges);
        }

        /// <summary>
        /// Specifies the destination port ranges to which this rule applies.
        /// </summary>
        /// <param name="ranges">The destination port ranges.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationPort.ToPortRanges(params string[] ranges)
        {
            return this.ToPortRanges(ranges);
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate>.WithAnyProtocol()
        {
            return this.WithAnyProtocol();
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>.WithAnyProtocol()
        {
            return this.WithAnyProtocol();
        }

        /// <summary>
        /// Makes this rule apply to any supported protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithProtocol.WithAnyProtocol()
        {
            return this.WithAnyProtocol();
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="descrtiption">A text description to associate with the security rule.</param>
        /// <return>The next stage.</return>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>.WithDescription(string descrtiption)
        {
            return this.WithDescription(descrtiption);
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">The text description to associate with this security rule.</param>
        /// <return>The next stage.</return>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDescription<NetworkSecurityGroup.Definition.IWithCreate>.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Specifies a description for this security rule.
        /// </summary>
        /// <param name="description">A text description to associate with this security rule.</param>
        /// <return>The next stage.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IUpdate.WithDescription(string description)
        {
            return this.WithDescription(description);
        }

        /// <summary>
        /// Sets the application security group specified as destination.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the update.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithDestinationAddressOrSecurityGroup.WithDestinationApplicationSecurityGroup(string id)
        {
            return this.WithDestinationApplicationSecurityGroup(id);
        }

        /// <summary>
        /// Sets the application security group specified as destination.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithDestinationPort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.WithDestinationApplicationSecurityGroup(string id)
        {
            return this.WithDestinationApplicationSecurityGroup(id);
        }

        /// <summary>
        /// Sets the application security group specified as destination.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithDestinationPort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithDestinationAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.WithDestinationApplicationSecurityGroup(string id)
        {
            return this.WithDestinationApplicationSecurityGroup(id);
        }

        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        /// <return>The next stage of the update.</return>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate>.WithPriority(int priority)
        {
            return this.WithPriority(priority);
        }

        /// <summary>
        /// Specifies the priority to assign to this rule.
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        /// <return>The next stage.</return>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithPriority<NetworkSecurityGroup.Definition.IWithCreate>.WithPriority(int priority)
        {
            return this.WithPriority(priority);
        }

        /// <summary>
        /// Specifies the priority to assign to this security rule.
        /// Security rules are applied in the order of their assigned priority.
        /// </summary>
        /// <param name="priority">The priority number in the range 100 to 4096.</param>
        /// <return>The next stage of the update.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IUpdate.WithPriority(int priority)
        {
            return this.WithPriority(priority);
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithAttach<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithProtocol<NetworkSecurityGroup.Definition.IWithCreate>.WithProtocol(SecurityRuleProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.UpdateDefinition.IWithAttach<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithProtocol<NetworkSecurityGroup.Update.IUpdate>.WithProtocol(SecurityRuleProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Specifies the protocol that this rule applies to.
        /// </summary>
        /// <param name="protocol">One of the supported protocols.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithProtocol.WithProtocol(SecurityRuleProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Sets the application security group specified as source.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the definition.</return>
        NetworkSecurityRule.Definition.IWithSourcePort<NetworkSecurityGroup.Definition.IWithCreate> NetworkSecurityRule.Definition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Definition.IWithCreate>.WithSourceApplicationSecurityGroup(string id)
        {
            return this.WithSourceApplicationSecurityGroup(id);
        }

        /// <summary>
        /// Sets the application security group specified as source.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the update.</return>
        NetworkSecurityRule.UpdateDefinition.IWithSourcePort<NetworkSecurityGroup.Update.IUpdate> NetworkSecurityRule.UpdateDefinition.IWithSourceAddressOrSecurityGroup<NetworkSecurityGroup.Update.IUpdate>.WithSourceApplicationSecurityGroup(string id)
        {
            return this.WithSourceApplicationSecurityGroup(id);
        }

        /// <summary>
        /// Sets the application security group specified as source.
        /// </summary>
        /// <param name="id">Application security group id.</param>
        /// <return>The next stage of the update.</return>
        NetworkSecurityRule.Update.IUpdate NetworkSecurityRule.Update.IWithSourceAddressOrSecurityGroup.WithSourceApplicationSecurityGroup(string id)
        {
            return this.WithSourceApplicationSecurityGroup(id);
        }
    }
}