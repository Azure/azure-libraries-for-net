// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The stage of an application gateway definition allowing to add a new Internet-facing frontend with a public IP address.
    /// </summary>
    public interface IWithPublicIPAddress :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition.IWithPublicIPAddressNoDnsLabel<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to define one or more public, or Internet-facing, frontends.
    /// </summary>
    public interface IWithPublicFrontend :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithPublicIPAddress
    {
        /// <summary>
        /// Specifies that the application gateway should not be Internet-facing.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithoutPublicFrontend();
    }

    /// <summary>
    /// The stage of an internal application gateway definition allowing to make the application gateway accessible to its
    /// virtual network.
    /// </summary>
    public interface IWithPrivateFrontend
    {
        /// <summary>
        /// Enables a private (internal) default frontend within the subnet containing the application gateway.
        /// A frontend with an automatically generated name will be created if none exists.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithPrivateFrontend();

        /// <summary>
        /// Specifies that no private (internal) frontend should be enabled.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithoutPrivateFrontend();
    }

    /// <summary>
    /// The first stage of an application gateway definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a request routing rule.
    /// </summary>
    public interface IWithRequestRoutingRule
    {
        /// <summary>
        /// Begins the definition of a request routing rule for this application gateway.
        /// </summary>
        /// <param name="name">A unique name for the request routing rule.</param>
        /// <return>The first stage of the request routing rule.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> DefineRequestRoutingRule(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add an SSL certificate to be used by HTTPS listeners.
    /// </summary>
    public interface IWithSslCert
    {
        /// <summary>
        /// Begins the definition of a new application gateway SSL certificate to be attached to the gateway for use in HTTPS listeners.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        /// <return>The first stage of the certificate definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineSslCertificate(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a probe.
    /// </summary>
    public interface IWithProbe
    {
        /// <summary>
        /// Begins the definition of a new probe.
        /// </summary>
        /// <param name="name">A unique name for the probe.</param>
        /// <return>The first stage of a probe definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineProbe(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify Managed Service Identities.
    /// </summary>
    public interface IWithManagedServiceIdentity 
    {
        /// <summary>
        /// Specifies an identity to be associated with the application gateway.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithIdentity(ManagedServiceIdentity identity);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a backend.
    /// </summary>
    public interface IWithBackend
    {
        /// <summary>
        /// Begins the definition of a new application gateway backend to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend.</param>
        /// <return>The first stage of the backend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineBackend(string name);
    }

    /// <summary>
    /// The entirety of the application gateway definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRule,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRule>
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a listener.
    /// </summary>
    public interface IWithListener
    {
        /// <summary>
        /// Begins the definition of a new application gateway listener to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the listener.</param>
        /// <return>The first stage of the listener definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineListener(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the capacity (number of instances) of the application gateway.
    /// </summary>
    public interface IWithInstanceCount
    {
        /// <summary>
        /// Specifies the capacity (number of instances) for the application gateway.
        /// By default, 1 instance is used.
        /// </summary>
        /// <param name="instanceCount">The capacity as a number between 1 and 10 but also based on the limits imposed by the selected application gateway size.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithInstanceCount(int instanceCount);


        /// <summary>
        /// Specifies the min and max auto scale bound.
        /// </summary>
        /// <param name="minCapacity">Lower bound on number of Application Gateway capacity.</param>
        /// <param name="maxCapacity">Upper bound on number of Application Gateway capacity.</param>
        /// <returns>The next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithAutoscale(int minCapacity, int maxCapacity);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a backend HTTP configuration.
    /// </summary>
    public interface IWithBackendHttpConfig
    {
        /// <summary>
        /// Begins the definition of a new application gateway backend HTTP configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend HTTP configuration.</param>
        /// <return>The first stage of the backend HTTP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineBackendHttpConfiguration(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a redirect configuration.
    /// </summary>
    public interface IWithRedirectConfiguration :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRedirectConfigurationBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a frontend port.
    /// </summary>
    public interface IWithFrontendPort
    {
        /// <summary>
        /// Creates a frontend port with an auto-generated name and the specified port number, unless one already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithFrontendPort(int portNumber);

        /// <summary>
        /// Creates a frontend port with the specified name and port number, unless a port matching this name and/or number already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <param name="name">The name to assign to the port.</param>
        /// <return>The next stage of the definition, or null if a port matching either the name or the number, but not both, already exists.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithFrontendPort(int portNumber, string name);
    }


    /// <summary>
    /// The stage of the application gateway definition allowing to specify availability zone.
    /// </summary>
    public interface IWithAvailabilityZone :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the availability zone for the application gateway.
        /// Note, this functionality is not enabled for most subscriptions and is subject to significant redesign
        /// and/or removal in the future.
        /// </summary>
        /// <param name="zoneId">The zone identifier.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithAvailabilityZone(AvailabilityZoneId zoneId);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add an authentication certificate for the backends to use.
    /// </summary>
    public interface IWithAuthenticationCertificate :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithAuthenticationCertificateBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the default IP address the app gateway will be internally available at,
    /// if a default private frontend has been enabled.
    /// </summary>
    public interface IWithPrivateIPAddress :
        Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Definition.IWithPrivateIPAddress<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the subnet the app gateway is getting
    /// its private IP address from.
    /// </summary>
    public interface IWithExistingSubnet :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>
    {
        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="network">The virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of an application gateway definition containing all the required inputs for
    /// the resource to be created, but also allowing
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithSku,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithWebApplicationFirewall,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithInstanceCount,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithSslCert,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithFrontendPort,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithListener,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithBackendHttpConfig,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithExistingSubnet,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithPrivateIPAddress,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithPrivateFrontend,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithPublicFrontend,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithPublicIPAddress,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithProbe,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithDisabledSslProtocol,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithAuthenticationCertificate,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRedirectConfiguration,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithManagedServiceIdentity,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithAvailabilityZone
    {
        /// <summary>
        /// Enables HTTP2 traffic on the Application Gateway.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithEnableHttp2();

        /// <summary>
        /// Disables HTTP2 traffic on the Application Gateway.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithoutEnableHttp2();
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to continue adding more request routing rules,
    /// or start specifying optional settings, or create the application gateway.
    /// </summary>
    public interface IWithRequestRoutingRuleOrCreate :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRule,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the sku.
    /// </summary>
    public interface IWithSku
    {
        /// <summary>
        /// Set tier of an application gateway. Possible values include: 'Standard', 'WAF', 'Standard_v2', 'WAF_v2'.
        /// </summary>
        /// <param name="tier">The tier value to set</param>
        /// <returns>The next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithTier(ApplicationGatewayTier tier);

        /// <summary>
        /// Specifies the size of the application gateway to create within the context of the selected tier.
        /// By default, the smallest size is used.
        /// </summary>
        /// <param name="size">An application gateway SKU name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithSize(ApplicationGatewaySkuName size);
    }

    /// <summary>
    /// The stage of the applicationgateway update allowing to specify WebApplicationFirewallConfiguration.
    /// </summary>
    public interface IWithWebApplicationFirewall
    {

        /// <summary>
        /// Specifies web application firewall configuration with default values.
        /// </summary>
        /// <param name="enabled">enable the firewall when created</param>
        /// <param name="mode">Web application firewall mode.</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithWebApplicationFirewall(bool enabled, ApplicationGatewayFirewallMode mode);

        /// <summary>
        /// Specifies web application firewall configuration.
        /// </summary>
        /// <param name="webApplicationFirewallConfiguration">The web application firewall configuration</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithWebApplicationFirewall(ApplicationGatewayWebApplicationFirewallConfiguration webApplicationFirewallConfiguration);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the SSL protocols to disable.
    /// </summary>
    public interface IWithDisabledSslProtocol :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithDisabledSslProtocolBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a redirect configuration.
    /// </summary>
    public interface IWithRedirectConfigurationBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new application gateway redirect configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the redirect configuration.</param>
        /// <return>The first stage of the redirect configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineRedirectConfiguration(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add an authentication certificate for the backends to use.
    /// </summary>
    public interface IWithAuthenticationCertificateBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new application gateway authentication certificate to be attached to the gateway for use by the backends.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        /// <return>The first stage of the certificate definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineAuthenticationCertificate(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the SSL protocols to disable.
    /// </summary>
    public interface IWithDisabledSslProtocolBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Disables the specified SSL protocols.
        /// </summary>
        /// <param name="protocols">SSL protocols.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols);

        /// <summary>
        /// Disables the specified SSL protocol.
        /// </summary>
        /// <param name="protocol">An SSL protocol.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithDisabledSslProtocol(ApplicationGatewaySslProtocol protocol);
    }
}