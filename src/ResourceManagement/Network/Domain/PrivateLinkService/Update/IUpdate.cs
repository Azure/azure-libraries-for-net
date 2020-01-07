// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.PrivateLinkService.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of the private link service update.
    /// </summary>
    public interface IUpdateCombined :
        IUpdate,
        IWithPrivateLinkServiceIpConfigurationSettings,
        IWithPrivateEndpointConnectionSettings,
        IWithAttach
    {
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate :
        ResourceManager.Fluent.Core.ResourceActions.IAppliable<IPrivateLinkService>,
        ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<IUpdate>,
        IWithFrontendIpConfiguration,
        IWithPrivateLinkServiceIpConfiguration,
        IWithPrivateEndpointConnection,
        IWithVisibility,
        IWithAutoApproval,
        IWithFqdns,
        IWithProxyProtocol
    {
    }

    /// <summary>
    /// The stage of the private line service update allowing to update IP configuration.
    /// </summary>
    public interface IWithAttach
    {
        /// <summary>
        /// Updates the IP configuration, either frontend IP configuration or private link service IP configuration.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate Attach();
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify frontend IP configuration.
    /// </summary>
    public interface IWithFrontendIpConfiguration
    {
        /// <summary>
        /// Sets new frontend IP configuration.
        /// </summary>
        /// <param name="loadBalancerFrontend">The value of load balancer frontend IP configuration.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithFrontendIpConfiguration(ILoadBalancerFrontend loadBalancerFrontend);

        /// <summary>
        /// Removes the frontend IP configuration.
        /// </summary>
        /// <param name="name">The name of frontend IP configuration.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutFrontendIpConfiguration(string name);
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify private link service IP configuration.
    /// </summary>
    public interface IWithPrivateLinkServiceIpConfiguration :
        IWithPrivateLinkServiceIpConfigurationSettings,
        IWithAttach
    {
        /// <summary>
        /// Sets new private link service IP configuration.
        /// </summary>
        /// <param name="name">The name of private link service IP configuration.</param>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings DefinePrivateLinkServiceIpConfiguration(string name);

        /// <summary>
        /// Updates private link service IP configuration.
        /// </summary>
        /// <param name="name">The name of private link service IP configuration.</param>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings UpdatePrivateLinkServiceIpConfiguration(string name);

        /// <summary>
        /// Removes private link service IP configuration.
        /// </summary>
        /// <param name="name">The name of private link service IP configuration.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutPrivateLinkServiceIpConfiguration(string name);
    }

    public interface IWithPrivateLinkServiceIpConfigurationSettings :
        IWithAttach
    {
        /// <summary>
        /// Sets the private link service IP configuration as primary IP configuration.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings SetAsPrimaryIpConfiguration();

        /// <summary>
        /// Sets the private link service IP configuration as non primary IP configuration.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings SetAsNonPrimaryIpConfiguration();

        /// <summary>
        /// Sets private Ip address for the IP configuration.
        /// </summary>
        /// <param name="privateIpAddress">The value of private IP address.</param>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithPrivateIpAddress(string privateIpAddress);

        /// <summary>
        /// Enables private Ip allocation method as 'Static' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithStaticPrivateIpAllocation();

        /// <summary>
        /// Enables private Ip allocation method as 'Dynamic' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithDynamicPrivateIpAllocation();

        /// <summary>
        /// Enables private Ip address version as 'IPv4' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithIpv4PrivateIpAddress();

        /// <summary>
        /// Enables private Ip address version as 'IPv6' for the IP configuration.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithIpv6PrivateIpAddress();

        /// <summary>
        /// Sets the reference of the subnet resource for the IP configuration.
        /// </summary>
        /// <param name="subnetId">The value of the subnet resource ID.</param>
        /// <return>The next stage of the update.</return>
        IWithPrivateLinkServiceIpConfigurationSettings WithSubnet(string subnetId);
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify the visibility list.
    /// </summary>
    public interface IWithVisibility
    {
        /// <summary>
        /// Sets the visible subscription for the private link service.
        /// </summary>
        /// <param name="subscription">The value of the visible subscription ID.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithVisibility(string subscription);

        /// <summary>
        /// Sets the list of visible subscriptions for the private link service.
        /// </summary>
        /// <param name="subscriptions">The list of the visible subscriptions.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithVisibility(IList<string> subscriptions);

        /// <summary>
        /// Removes the visible subscriptions for the private link service.
        /// </summary>
        /// <param name="subscription">The visible subscription.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutVisibility(string subscription);
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify the auto-approval list.
    /// </summary>
    public interface IWithAutoApproval
    {
        /// <summary>
        /// Sets the subscription into auto-approval list for the private link service.
        /// </summary>
        /// <param name="subscription">The value of the subscription ID.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithAutoApproval(string subscription);

        /// <summary>
        /// Sets the subscription into auto-approval list for the private link service.
        /// </summary>
        /// <param name="subscriptions">The list of the subscriptions.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithAutoApproval(IList<string> subscriptions);

        /// <summary>
        /// Sets the subscription into auto-approval list for the private link service.
        /// </summary>
        /// <param name="subscription">The value of the subscription ID.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutAutoApproval(string subscription);
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify the list of Fqdn.
    /// </summary>
    public interface IWithFqdns
    {
        /// <summary>
        /// Sets the domain into Fqdn list for the private link service.
        /// </summary>
        /// <param name="domainName">The value of the domain name.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithFullQualifiedDomainName(string domainName);

        /// <summary>
        /// Sets the Fqdn list for the private link service.
        /// </summary>
        /// <param name="domainNames">The list of domains.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithFullQualifiedDomainNames(IList<string> domainNames);

        /// <summary>
        /// Sets the domain into Fqdn list for the private link service.
        /// </summary>
        /// <param name="domainName">The value of the domain name.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutFullQualifiedDomainName(string domainName);
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify proxy protocol setting.
    /// </summary>
    public interface IWithProxyProtocol
    {
        /// <summary>
        /// Enables the proxy protocol for the private link service.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate EnableProxyProtocol();

        /// <summary>
        /// Disables the proxy protocol for the private link service.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate DisableProxyProtocol();
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify private endpoint connection.
    /// </summary>
    public interface IWithPrivateEndpointConnection
    {
        /// <summary>
        /// Updates private endpoint connection.
        /// </summary>
        /// <param name="name">The name of private endpoint connection.</param>
        /// <return>The next stage of the update.</return>
        IWithPrivateEndpointConnectionSettings UpdatePrivateEndpointConnection(string name);
    }

    /// <summary>
    /// The stage of the private line service update allowing to specify private endpoint connection settings.
    /// </summary>
    public interface IWithPrivateEndpointConnectionSettings :
        ResourceManager.Fluent.Core.ResourceActions.IExecutable<IPrivateEndpointConnection>
    {
        /// <summary>
        /// Sets the private endpoint ID.
        /// </summary>
        /// <param name="privateEndpointId">The ID of private endpoint.</param>
        /// <return>The next stage of the update.</return>
        IWithPrivateEndpointConnectionSettings WithPrivateEndpoint(string privateEndpointId);

        /// <summary>
        /// Sets the private link service connection state.
        /// </summary>
        /// <param name="status">The status of private link service connection state.</param>
        /// <param name="description">The description of private link service connection state.</param>
        /// <param name="actionRequired">The action required of private link service connection state.</param>
        /// <return>The next stage of the update.</return>
        IWithPrivateEndpointConnectionSettings WithPrivateLinkServiceConnetionState(string status, string description, string actionRequired);
    }
}
