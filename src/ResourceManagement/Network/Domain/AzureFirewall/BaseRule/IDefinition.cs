// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.AzureFirewall.BaseRule
{
    using System.Collections.Generic;

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify description in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDescription<ParentT>
    {
        /// <summary>
        /// Sets the description of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="description">The value of description.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDescription(string description);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify source addresses in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSourceAddress<ParentT>
    {
        /// <summary>
        /// Sets the source address of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="sourceAddress">The value of source address.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithSourceAddress(string sourceAddress);

        /// <summary>
        /// Sets the source addresses of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="sourceAddresses">The value of source addresses.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithSourceAddresses(IList<string> sourceAddresses);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify source addresses in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithApplicationRuleProtocol<ParentT>
    {
        /// <summary>
        /// Sets the Http protocol of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="port">The value of port.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithHttpProtocol(int? port = null);

        /// <summary>
        /// Sets the Https protocol of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="port">The value of port.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithHttpsProtocol(int? port = null);

        /// <summary>
        /// Sets the Mssql protocol of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="port">The value of port.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithMssqlProtocol(int? port = null);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify destination addresses in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDestinationAddress<ParentT>
    {
        /// <summary>
        /// Sets the destination address of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="destinationAddress">The value of destination address.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationAddress(string destinationAddress);

        /// <summary>
        /// Sets the destination addresses of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="destinationAddresses">The value of destination addresses.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationAddresses(IList<string> destinationAddresses);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify destination ports in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDestinationPort<ParentT>
    {
        /// <summary>
        /// Sets the destination port of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="destinationPort">The value of destination port.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationPort(string destinationPort);

        /// <summary>
        /// Sets the destination ports of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="destinationPorts">The value of destination ports.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationPorts(IList<string> destinationPorts);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify protocol in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRuleProtocol<ParentT>
    {
        /// <summary>
        /// Adds TCP protocol in firewall rule.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithTcpProtocol();

        /// <summary>
        /// Adds UDP protocol in firewall rule.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithUdpProtocol();

        /// <summary>
        /// Adds ANY protocol in firewall rule.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithAnyProtocol();

        /// <summary>
        /// Adds ICMP protocol in firewall rule.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithIcmpProtocol();
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify destination fdqns in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDestinationFqdn<ParentT>
    {
        /// <summary>
        /// Sets the full qualified domain name of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="domainName">The value of domain name.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationFullQualifiedDomainName(string domainName);

        /// <summary>
        /// Sets the full qualified domain names of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="domainNames">The value of domain names.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationFullQualifiedDomainNames(IList<string> domainNames);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify source IP groups in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSourceIpGroup<ParentT>
    {
        /// <summary>
        /// Sets the source IP group of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="sourceIpGroup">The value of source IP group.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithSourceIpGroup(string sourceIpGroup);

        /// <summary>
        /// Sets the source IP groups of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="sourceIpGroups">The value of source IP groups.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithSourceIpGroups(IList<string> sourceIpGroups);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify destination IP groups in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDestinationIpGroup<ParentT>
    {
        /// <summary>
        /// Sets the destination IP group of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="destinationIpGroup">The value of destination IP group.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationIpGroup(string destinationIpGroup);

        /// <summary>
        /// Sets the destination IP groups of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="destinationIpGroups">The value of destination IP groups.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithDestinationIpGroups(IList<string> destinationIpGroups);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify target fqdns in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTargetFqdn<ParentT>
    {
        /// <summary>
        /// Sets the target full qualified domain name of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="domainName">The value of domain name.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithTargetFullQualifiedDomainName(string domainName);

        /// <summary>
        /// Sets the target full qualified domain names of firewall rule in Azure firewall.
        /// </summary>
        /// <param name="domainNames">The value of domain names.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithTargetFullQualifiedDomainNames(IList<string> domainNames);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify fqdn tags in firewall rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFqdnTag<ParentT>
    {
        /// <summary>
        /// Sets the tag of full qualified domain name in Azure firewall.
        /// </summary>
        /// <param name="tag">The value of tag.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithFullQualifiedDomainNameTag(string tag);

        /// <summary>
        /// Sets the tags of full qualified domain name in Azure firewall.
        /// </summary>
        /// <param name="tags">The value of tags.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithFullQualifiedDomainNameTags(IList<string> tags);
    }
}
