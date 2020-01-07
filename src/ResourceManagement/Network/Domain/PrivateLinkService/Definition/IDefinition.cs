// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.PrivateLinkService.Definition
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of the private link service definition.
    /// </summary>
    public interface IDefinition :
        IBlank,
        IWithCreate,
        IWithPrivateLinkServiceIpConfigurationSettings,
        IWithAttach
    {
    }

    /// <summary>
    /// The first stage of a private link service definition.
    /// </summary>
    public interface IBlank :
        ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via  WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        ResourceManager.Fluent.Core.ResourceActions.ICreatable<IPrivateLinkService>,
        ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<IWithCreate>,
        ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<IWithCreate>,
        IWithFrontendIpConfiguration,
        IWithPrivateLinkServiceIpConfiguration,
        IWithVisibility,
        IWithAutoApproval,
        IWithFqdns,
        IWithProxyProtocol
    {
    }

    /// <summary>
    /// The stage of the private line service definition allowing to add IP configuration.
    /// </summary>
    public interface  IWithAttach
    {
        /// <summary>
        /// Adds the IP configuration, either frontend IP configuration or private link service IP configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate Attach();
    }

    /// <summary>
    /// The stage of the private line service definition allowing to specify frontend IP configuration.
    /// </summary>
    public interface IWithFrontendIpConfiguration
    {
        /// <summary>
        /// Sets frontend IP configuration.
        /// </summary>
        /// <param name="loadBalancerFrontend">The value of load balancer frontend IP configuration.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithFrontendIpConfiguration(ILoadBalancerFrontend loadBalancerFrontend);
    }

    /// <summary>
    /// The stage of the private line service definition allowing to specify private link service IP configuration.
    /// </summary>
    public interface IWithPrivateLinkServiceIpConfiguration
    {
        /// <summary>
        /// Sets new private link service IP configuration.
        /// </summary>
        /// <param name="name">The name of private link service IP configuration.</param>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings DefinePrivateLinkServiceIpConfiguration(string name);
    }

    /// <summary>
    /// The stage of the private line service definition allowing to specify optional settings of private link service IP configuration.
    /// </summary>
    public interface IWithPrivateLinkServiceIpConfigurationSettings :
        IWithAttach
    {
        /// <summary>
        /// Sets the private link service IP configuration as primary IP configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings SetAsPrimaryIpConfiguration();

        /// <summary>
        /// Sets the private link service IP configuration as non primary IP configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings SetAsNonPrimaryIpConfiguration();

        /// <summary>
        /// Sets private Ip address for the IP configuration.
        /// </summary>
        /// <param name="privateIpAddress">The value of private IP address.</param>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithPrivateIpAddress(string privateIpAddress);

        /// <summary>
        /// Enables private Ip allocation method as 'Static' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithStaticPrivateIpAllocation();

        /// <summary>
        /// Enables private Ip allocation method as 'Dynamic' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithDynamicPrivateIpAllocation();

        /// <summary>
        /// Enables private Ip address version as 'IPv4' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithIpv4PrivateIpAddress();

        /// <summary>
        /// Enables private Ip address version as 'IPv6' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithIpv6PrivateIpAddress();

        /// <summary>
        /// Sets the reference of the subnet resource for the IP configuration.
        /// </summary>
        /// <param name="subnetId">The value of the subnet resource ID.</param>
        /// <return>The next stage of the definition.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithSubnet(string subnetId);
    }

    /// <summary>
    /// The stage of the private line service definition allowing to specify the visibility list.
    /// </summary>
    public interface IWithVisibility
    {
        /// <summary>
        /// Sets the visible subscription for the private link service.
        /// </summary>
        /// <param name="subscription">The value of the visible subscription ID.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithVisibility(string subscription);

        /// <summary>
        /// Sets the list of visible subscriptions for the private link service.
        /// </summary>
        /// <param name="subscriptions">The list of the visible subscriptions.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithVisibility(IList<string> subscriptions);
    }

    /// <summary>
    /// The stage of the private line service definition allowing to specify the auto-approval list.
    /// </summary>
    public interface IWithAutoApproval
    {
        /// <summary>
        /// Sets the subscription into auto-approval list for the private link service.
        /// </summary>
        /// <param name="subscription">The value of the subscription ID.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithAutoApproval(string subscription);

        /// <summary>
        /// Sets the subscription into auto-approval list for the private link service.
        /// </summary>
        /// <param name="subscriptions">The list of the subscriptions.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithAutoApproval(IList<string> subscriptions);
    }

    /// <summary>
    /// The stage of the private line service definition allowing to specify the list of Fqdn.
    /// </summary>
    public interface IWithFqdns
    {
        /// <summary>
        /// Sets the domain into Fqdn list for the private link service.
        /// </summary>
        /// <param name="domainName">The value of the domain name.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithFullQualifiedDomainName(string domainName);

        /// <summary>
        /// Sets the Fqdn list for the private link service.
        /// </summary>
        /// <param name="domainNames">The list of domains.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithFullQualifiedDomainNames(IList<string> domainNames);
    }

    /// <summary>
    /// The stage of the private line service definition allowing to specify proxy protocol setting.
    /// </summary>
    public interface IWithProxyProtocol
    {
        /// <summary>
        /// Enables the proxy protocol for the private link service.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate EnableProxyProtocol();
    }
}
