// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasCookieBasedAffinity.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasCookieBasedAffinity.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasHostName.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasHostName.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasSslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.IO;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayRequestRoutingRuleImpl
    {
        /// <summary>
        /// Gets the associated host name.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasHostName.HostName
        {
            get
            {
                return this.HostName();
            }
        }

        /// <summary>
        /// Associates the request routing rule with a backend on this application gateway.
        /// If the specified backend does not yet exist, it will be automatically created.
        /// </summary>
        /// <param name="name">The name of a backend.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithBackend.ToBackend(string name)
        {
            return this.ToBackend(name);
        }

        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// </summary>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithBackendHttpConfiguration.ToBackendHttpConfiguration(string name)
        {
            return this.ToBackendHttpConfiguration(name);
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's public (Internet-facing) frontend.
        /// If the public frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a public IP address specified for its public frontend, one will be created
        /// automatically, unless a specific public IP address is specified in the application gateway definition's optional settings.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontend<ApplicationGateway.Update.IUpdate>.FromPublicFrontend()
        {
            return this.FromPublicFrontend();
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's private (internal) frontend.
        /// If the private frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a subnet specified for its private frontend, one will be created automatically,
        /// unless a specific subnet is specified in the application gateway definition's optional settings.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontend<ApplicationGateway.Update.IUpdate>.FromPrivateFrontend()
        {
            return this.FromPrivateFrontend();
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's public (Internet-facing) frontend.
        /// If the public frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a public IP address specified for its public frontend, one will be created
        /// automatically, unless a specific public IP address is specified in the application gateway definition's optional settings.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontend<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromPublicFrontend()
        {
            return this.FromPublicFrontend();
        }

        /// <summary>
        /// Enables the rule to apply to the application gateway's private (internal) frontend.
        /// If the private frontend IP configuration does not yet exist, it will be created under an auto-generated name.
        /// If the application gateway does not have a subnet specified for its private frontend, one will be created automatically,
        /// unless a specific subnet is specified in the application gateway definition's optional settings.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontend<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromPrivateFrontend()
        {
            return this.FromPrivateFrontend();
        }

        /// <summary>
        /// Specifies the host name to reference.
        /// </summary>
        /// <param name="hostName">An existing host name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasHostName.UpdateDefinition.IWithHostName<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithHostName(string hostName)
        {
            return this.WithHostName(hostName);
        }

        /// <summary>
        /// Specifies the hostname to reference.
        /// </summary>
        /// <param name="hostName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasHostName.Definition.IWithHostName<ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithHostName(string hostName)
        {
            return this.WithHostName(hostName);
        }

        /// <summary>
        /// Gets the backend port number the network traffic is sent to.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IHasCookieBasedAffinity.CookieBasedAffinity
        {
            get
            {
                return this.CookieBasedAffinity();
            }
        }

        /// <summary>
        /// Gets true if server name indication (SNI) is required, else false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IHasServerNameIndication.RequiresServerNameIndication
        {
            get
            {
                return this.RequiresServerNameIndication();
            }
        }

        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasCookieBasedAffinity.UpdateDefinition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity();
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasCookieBasedAffinity.UpdateDefinition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity();
        }

        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasCookieBasedAffinity.Definition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity();
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasCookieBasedAffinity.Definition.IWithCookieBasedAffinity<ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity();
        }

        /// <summary>
        /// Removes the association with a redirect configuration, if any.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithRedirectConfigBeta.WithoutRedirectConfiguration()
        {
            return this.WithoutRedirectConfiguration();
        }

        /// <summary>
        /// Associates the specified redirect configuration with this request routing rule.
        /// Note that no backend can be associated with this request routing rule if it has a redirect configuration assigned to it,
        /// so this will also remove any backend and backend HTTP settings configuration.
        /// </summary>
        /// <param name="name">The name of a redirect configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithRedirectConfigBeta.WithRedirectConfiguration(string name)
        {
            return this.WithRedirectConfiguration(name);
        }

        /// <summary>
        /// Associates the request routing rule with an existing frontend listener.
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </summary>
        /// <param name="name">The name of a listener to reference.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGatewayRequestRoutingRule.Update.IWithListener.FromListener(string name)
        {
            return this.FromListener(name);
        }

        /// <summary>
        /// Adds an FQDN (fully qualified domain name) to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple FQDNs.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressOrAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddress<ApplicationGateway.Update.IUpdate>.ToBackendFqdn(string fqdn)
        {
            return this.ToBackendFqdn(fqdn);
        }

        /// <summary>
        /// Adds an IP address to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple IP addresses.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressOrAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddress<ApplicationGateway.Update.IUpdate>.ToBackendIPAddress(string ipAddress)
        {
            return this.ToBackendIPAddress(ipAddress);
        }

        /// <summary>
        /// Adds the specified IP addresses to the backend associated with this rule.
        /// </summary>
        /// <param name="ipAddresses">IP addresses to add.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressOrAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendAddressBeta<ApplicationGateway.Update.IUpdate>.ToBackendIPAddresses(params string[] ipAddresses)
        {
            return this.ToBackendIPAddresses(ipAddresses);
        }

        /// <summary>
        /// Adds an FQDN (fully qualified domain name) to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple FQDNs.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressOrAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendFqdn(string fqdn)
        {
            return this.ToBackendFqdn(fqdn);
        }

        /// <summary>
        /// Adds an IP address to the backend associated with this rule.
        /// If no backend has been associated with this rule yet, a new one will be created with an auto-generated name.
        /// This call can be used in a sequence to add multiple IP addresses.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressOrAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendIPAddress(string ipAddress)
        {
            return this.ToBackendIPAddress(ipAddress);
        }

        /// <summary>
        /// Adds the specified IP addresses to the backend associated with this rule.
        /// </summary>
        /// <param name="ipAddresses">IP addresses to add.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressOrAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendAddressBeta<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendIPAddresses(params string[] ipAddresses)
        {
            return this.ToBackendIPAddresses(ipAddresses);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Gets the frontend port number the inbound network traffic is received on.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasFrontendPort.FrontendPort
        {
            get
            {
                return this.FrontendPort();
            }
        }

        /// <summary>
        /// Associates the request routing rule with a backend on this application gateway.
        /// If the backend does not yet exist, it will be automatically created.
        /// </summary>
        /// <param name="name">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackend<ApplicationGateway.Update.IUpdate>.ToBackend(string name)
        {
            return this.ToBackend(name);
        }

        /// <summary>
        /// Associates the request routing rule with a backend on this application gateway.
        /// If the backend does not yet exist, it will be automatically created.
        /// </summary>
        /// <param name="name">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackend<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackend(string name)
        {
            return this.ToBackend(name);
        }

        /// <summary>
        /// Gets the associated backend HTTP settings configuration.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.BackendHttpConfiguration
        {
            get
            {
                return this.BackendHttpConfiguration();
            }
        }

        /// <summary>
        /// Gets rule type.
        /// </summary>
        Models.ApplicationGatewayRequestRoutingRuleType Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.RuleType
        {
            get
            {
                return this.RuleType();
            }
        }

        /// <summary>
        /// Gets the associated backend address pool.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.Backend
        {
            get
            {
                return this.Backend();
            }
        }

        /// <summary>
        /// Gets the addresses assigned to the associated backend.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.ApplicationGatewayBackendAddress> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.BackendAddresses
        {
            get
            {
                return this.BackendAddresses();
            }
        }

        /// <summary>
        /// Gets the frontend protocol.
        /// </summary>
        Models.ApplicationGatewayProtocol Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.FrontendProtocol
        {
            get
            {
                return this.FrontendProtocol();
            }
        }

        /// <summary>
        /// Gets the redirect configuration associated with this request routing rule, if any.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRuleBeta.RedirectConfiguration
        {
            get
            {
                return this.RedirectConfiguration();
            }
        }

        /// <summary>
        /// Gets the associated frontend HTTP listener.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule.Listener
        {
            get
            {
                return this.Listener();
            }
        }

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate> HasServerNameIndication.UpdateDefinition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>>.WithoutServerNameIndication()
        {
            return this.WithoutServerNameIndication();
        }

        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate> HasServerNameIndication.UpdateDefinition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>>.WithServerNameIndication()
        {
            return this.WithServerNameIndication();
        }

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasServerNameIndication.Definition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithoutServerNameIndication()
        {
            return this.WithoutServerNameIndication();
        }

        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasServerNameIndication.Definition.IWithServerNameIndication<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithServerNameIndication()
        {
            return this.WithServerNameIndication();
        }

        /// <summary>
        /// Gets the resource ID of the associated public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress.PublicIPAddressId
        {
            get
            {
                return this.PublicIPAddressId();
            }
        }

        /// <return>The associated public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress.GetPublicIPAddress()
        {
            return this.GetPublicIPAddress();
        }

        /// <summary>
        /// Gets the associated SSL certificate, if any.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate Microsoft.Azure.Management.Network.Fluent.IHasSslCertificate<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate>.SslCertificate
        {
            get
            {
                return this.SslCertificate();
            }
        }

        /// <summary>
        /// Associates the request routing rule with a frontend listener.
        /// If the listener with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition. This only adds a reference to the listener by its name.
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </summary>
        /// <param name="name">The name of a listener to reference.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrRedirect<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithListener<ApplicationGateway.Update.IUpdate>.FromListener(string name)
        {
            return this.FromListener(name);
        }

        /// <summary>
        /// Associates the request routing rule with a frontend listener.
        /// If the listener with the specified name does not yet exist, it must be defined separately in the optional stages
        /// of the application gateway definition. This only adds a reference to the listener by its name.
        /// Also, note that a given listener can be used by no more than one request routing rule at a time.
        /// </summary>
        /// <param name="name">The name of a listener to reference.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithListener<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromListener(string name)
        {
            return this.FromListener(name);
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
        /// Associates the specified redirect configuration with this request routing rule.
        /// </summary>
        /// <param name="name">The name of a redirect configuration on this application gateway.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithRedirectConfigBeta<ApplicationGateway.Update.IUpdate>.WithRedirectConfiguration(string name)
        {
            return this.WithRedirectConfiguration(name);
        }

        /// <summary>
        /// Associates the specified redirect configuration with this request routing rule.
        /// </summary>
        /// <param name="name">The name of a redirect configuration on this application gateway.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithAttach<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithRedirectConfigBeta<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.WithRedirectConfiguration(string name)
        {
            return this.WithRedirectConfiguration(name);
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the parent resource update.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate associated with this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate HasSslCertificate.Update.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Update.IUpdate>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name);
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the optional part of the parent resource definition.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate> HasSslCertificate.UpdateDefinition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate>>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name);
        }

        /// <summary>
        /// Specifies an SSL certificate to associate with this resource.
        /// If the certificate does not exist yet, it must be defined in the optional part of the parent resource definition.
        /// </summary>
        /// <param name="name">The name of an existing SSL certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasSslCertificate.Definition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithSslCertificate(string name)
        {
            return this.WithSslCertificate(name);
        }

        /// <summary>
        /// Sepecifies the content of the private key using key vault.
        /// </summary>
        /// <param name="keyVaultSecretId">The secret id of key vault.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate HasSslCertificate.Update.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Update.IUpdate>.WithSslCertificateFromKeyVaultSecretId(string keyVaultSecretId)
        {
            return this.WithSslCertificateFromKeyVaultSecretId(keyVaultSecretId);
        }

        /// <summary>
        /// Sepecifies the content of the private key using key vault.
        /// </summary>
        /// <param name="keyVaultSecretId">The secret id of key vault.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate> HasSslCertificate.UpdateDefinition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate>>.WithSslCertificateFromKeyVaultSecretId(string keyVaultSecretId)
        {
            return this.WithSslCertificateFromKeyVaultSecretId(keyVaultSecretId);
        }

        /// <summary>
        /// Sepecifies the content of the private key using key vault.
        /// </summary>
        /// <param name="keyVaultSecretId">The secret id of key vault.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasSslCertificate.Definition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithSslCertificateFromKeyVaultSecretId(string keyVaultSecretId)
        {
            return this.WithSslCertificateFromKeyVaultSecretId(keyVaultSecretId);
        }

        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associate with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <throws>IOException when there are issues with the provided file.</throws>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.Update.IWithSslPassword<ApplicationGatewayRequestRoutingRule.Update.IUpdate> HasSslCertificate.Update.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Update.IUpdate>.WithSslCertificateFromPfxFile(FileInfo pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile);
        }

        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associated with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <throws>IOException when there are issues with the provided file.</throws>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.UpdateDefinition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate>> HasSslCertificate.UpdateDefinition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate>>.WithSslCertificateFromPfxFile(FileInfo pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile);
        }

        /// <summary>
        /// Specifies the PFX file to import the SSL certificate from to associated with this resource.
        /// The certificate will be named using an auto-generated name.
        /// </summary>
        /// <param name="pfxFile">An existing PFX file.</param>
        /// <throws>IOException when there are issues with the provided file.</throws>
        /// <return>The next stage of the definition.</return>
        HasSslCertificate.Definition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>> HasSslCertificate.Definition.IWithSslCertificate<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithSslCertificateFromPfxFile(FileInfo pfxFile)
        {
            return this.WithSslCertificateFromPfxFile(pfxFile);
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate HasSslCertificate.Update.IWithSslPassword<ApplicationGatewayRequestRoutingRule.Update.IUpdate>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password);
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate> HasSslCertificate.UpdateDefinition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Update.IUpdate>>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password);
        }

        /// <summary>
        /// Specifies the password for the specified PFX file containing the private key of the imported SSL certificate.
        /// </summary>
        /// <param name="password">The password of the imported PFX file.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> HasSslCertificate.Definition.IWithSslPassword<ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrSniOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>>.WithSslCertificatePassword(string password)
        {
            return this.WithSslCertificatePassword(password);
        }

        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// If the backend configuration does not exist yet, it must be defined in the optional part of the application gateway
        /// definition. The request routing rule references it only by name.
        /// </summary>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendOrAddress<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>.ToBackendHttpConfiguration(string name)
        {
            return this.ToBackendHttpConfiguration(name);
        }

        /// <summary>
        /// Creates a backend HTTP settings configuration for the specified backend port and the HTTP protocol, and associates it with this
        /// request routing rule.
        /// An auto-generated name will be used for this newly created configuration.
        /// </summary>
        /// <param name="portNumber">The port number for a new backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendOrAddress<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfiguration<ApplicationGateway.Update.IUpdate>.ToBackendHttpPort(int portNumber)
        {
            return this.ToBackendHttpPort(portNumber);
        }

        /// <summary>
        /// Associates the specified backend HTTP settings configuration with this request routing rule.
        /// If the backend configuration does not exist yet, it must be defined in the optional part of the application gateway
        /// definition. The request routing rule references it only by name.
        /// </summary>
        /// <param name="name">The name of a backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendOrAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendHttpConfiguration(string name)
        {
            return this.ToBackendHttpConfiguration(name);
        }

        /// <summary>
        /// Creates a backend HTTP settings configuration for the specified backend port and the HTTP protocol, and associates it with this
        /// request routing rule.
        /// An auto-generated name will be used for this newly created configuration.
        /// </summary>
        /// <param name="portNumber">The port number for a new backend HTTP settings configuration.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendOrAddress<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfiguration<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.ToBackendHttpPort(int portNumber)
        {
            return this.ToBackendHttpPort(portNumber);
        }

        /// <summary>
        /// Gets the backend port number the network traffic is sent to.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasBackendPort.BackendPort
        {
            get
            {
                return this.BackendPort();
            }
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTPS protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithSslCertificate<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>.FromFrontendHttpsPort(int portNumber)
        {
            return this.FromFrontendHttpsPort(portNumber);
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTP protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithBackendHttpConfigOrRedirect<ApplicationGateway.Update.IUpdate> ApplicationGatewayRequestRoutingRule.UpdateDefinition.IWithFrontendPort<ApplicationGateway.Update.IUpdate>.FromFrontendHttpPort(int portNumber)
        {
            return this.FromFrontendHttpPort(portNumber);
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTPS protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithSslCertificate<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromFrontendHttpsPort(int portNumber)
        {
            return this.FromFrontendHttpsPort(portNumber);
        }

        /// <summary>
        /// Associates a new listener for the specified port number and the HTTP protocol with this rule.
        /// </summary>
        /// <param name="portNumber">The port number to listen to.</param>
        /// <return>The next stage of the definition, or null if the specified port number is already used for a different protocol.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IWithBackendHttpConfigOrRedirect<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGatewayRequestRoutingRule.Definition.IWithFrontendPort<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>.FromFrontendHttpPort(int portNumber)
        {
            return this.FromFrontendHttpPort(portNumber);
        }
    }
}