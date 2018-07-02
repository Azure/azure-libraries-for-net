// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPort.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.IO;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayBackendHttpConfigurationImpl
    {
        /// <summary>
        /// Specifies the number of seconds when connection draining is active.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 3600.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithConnectionDrainingBeta.WithConnectionDrainingTimeoutInSeconds(int seconds)
        {
            return this.WithConnectionDrainingTimeoutInSeconds(seconds);
        }

        /// <summary>
        /// Disables connection draining.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithConnectionDrainingBeta.WithoutConnectionDraining()
        {
            return this.WithoutConnectionDraining();
        }

        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> HasPort.UpdateDefinition.IWithPort<ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>>.WithPort(int portNumber)
        {
            return this.WithPort(portNumber);
        }

        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate HasPort.Update.IWithPort<ApplicationGatewayBackendHttpConfiguration.Update.IUpdate>.WithPort(int portNumber)
        {
            return this.WithPort(portNumber);
        }

        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> HasPort.Definition.IWithPort<ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>>.WithPort(int portNumber)
        {
            return this.WithPort(portNumber);
        }

        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAffinity<ApplicationGateway.Update.IUpdate>.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity();
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAffinity<ApplicationGateway.Update.IUpdate>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity();
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithAffinity<ApplicationGateway.Definition.IWithCreate>.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity();
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">The host header.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithHostHeaderBeta<ApplicationGateway.Update.IUpdate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader);
        }

        /// <summary>
        /// Specifies that the host header should come from the host name of the backend server.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithHostHeaderBeta<ApplicationGateway.Update.IUpdate>.WithHostHeaderFromBackend()
        {
            return this.WithHostHeaderFromBackend();
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">The host header.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithHostHeaderBeta<ApplicationGateway.Definition.IWithCreate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader);
        }

        /// <summary>
        /// Specifies that the host header should come from the host name of the backend server.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithHostHeaderBeta<ApplicationGateway.Definition.IWithCreate>.WithHostHeaderFromBackend()
        {
            return this.WithHostHeaderFromBackend();
        }

        /// <summary>
        /// Gets the port number.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IHasPort.Port
        {
            get
            {
                return this.Port();
            }
        }

        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithRequestTimeout<ApplicationGateway.Update.IUpdate>.WithRequestTimeout(int seconds)
        {
            return this.WithRequestTimeout(seconds);
        }

        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithRequestTimeout<ApplicationGateway.Definition.IWithCreate>.WithRequestTimeout(int seconds)
        {
            return this.WithRequestTimeout(seconds);
        }

        /// <summary>
        /// Specifies the path prefix for all HTTP requests.
        /// </summary>
        /// <param name="path">A path.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithPathBeta<ApplicationGateway.Update.IUpdate>.WithPath(string path)
        {
            return this.WithPath(path);
        }

        /// <summary>
        /// Specifies the path prefix for all HTTP requests.
        /// </summary>
        /// <param name="path">A path.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithPathBeta<ApplicationGateway.Definition.IWithCreate>.WithPath(string path)
        {
            return this.WithPath(path);
        }

        /// <summary>
        /// Specifies an existing probe on this application gateway to associate with this backend.
        /// If the probe with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition. This only adds a reference to the probe by its name.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithProbe<ApplicationGateway.Definition.IWithCreate>.WithProbe(string name)
        {
            return this.WithProbe(name);
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
        /// Specifies that no host header should be used.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithHostHeaderBeta.WithoutHostHeader()
        {
            return this.WithoutHostHeader();
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">The host header.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithHostHeaderBeta.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader);
        }

        /// <summary>
        /// Specifies that the host header should come from the host name of the backend server.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithHostHeaderBeta.WithHostHeaderFromBackend()
        {
            return this.WithHostHeaderFromBackend();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies the path prefix for all HTTP requests.
        /// </summary>
        /// <param name="path">A path.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithPathBeta.WithPath(string path)
        {
            return this.WithPath(path);
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration based on the specified data.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="derData">The DER encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAuthenticationCertificateBeta<ApplicationGateway.Update.IUpdate>.WithAuthenticationCertificateFromBytes(params byte[] derData)
        {
            return this.WithAuthenticationCertificateFromBytes(derData);
        }

        /// <summary>
        /// Associates the specified authentication certificate that exists on this application gateway with this backend HTTP confifuration.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="name">The name of an existing authentication certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAuthenticationCertificateBeta<ApplicationGateway.Update.IUpdate>.WithAuthenticationCertificate(string name)
        {
            return this.WithAuthenticationCertificate(name);
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="certificateFile">A file containing the DER representation of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IOException when there are issues reading from the specified file.</throws>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAuthenticationCertificateBeta<ApplicationGateway.Update.IUpdate>.WithAuthenticationCertificateFromFile(FileInfo certificateFile)
        {
            return this.WithAuthenticationCertificateFromFile(certificateFile);
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="base64Data">The base-64 encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAuthenticationCertificateBeta<ApplicationGateway.Update.IUpdate>.WithAuthenticationCertificateFromBase64(string base64Data)
        {
            return this.WithAuthenticationCertificateFromBase64(base64Data);
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration based on the specified data.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="derData">The DER-encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttachAndAuthCert<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithAuthenticationCertificateBeta<ApplicationGateway.Definition.IWithCreate>.WithAuthenticationCertificateFromBytes(params byte[] derData)
        {
            return this.WithAuthenticationCertificateFromBytes(derData);
        }

        /// <summary>
        /// Associates the specified authentication certificate that exists on this application gateway with this backend HTTP confifuration.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="name">The name of an existing authentication certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttachAndAuthCert<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithAuthenticationCertificateBeta<ApplicationGateway.Definition.IWithCreate>.WithAuthenticationCertificate(string name)
        {
            return this.WithAuthenticationCertificate(name);
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="certificateFile">A file containing the DER format representation of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IOException when there are issues reading from the specified file.</throws>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttachAndAuthCert<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithAuthenticationCertificateBeta<ApplicationGateway.Definition.IWithCreate>.WithAuthenticationCertificateFromFile(FileInfo certificateFile)
        {
            return this.WithAuthenticationCertificateFromFile(certificateFile);
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="base64Data">The base-64 encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttachAndAuthCert<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithAuthenticationCertificateBeta<ApplicationGateway.Definition.IWithCreate>.WithAuthenticationCertificateFromBase64(string base64Data)
        {
            return this.WithAuthenticationCertificateFromBase64(base64Data);
        }

        /// <summary>
        /// Gets if 0 then connection draining is not enabled, otherwise if between 1 and 3600, then the number of seconds when connection draining is active.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta.ConnectionDrainingTimeoutInSeconds
        {
            get
            {
                return this.ConnectionDrainingTimeoutInSeconds();
            }
        }

        /// <summary>
        /// Gets name used for the affinity cookie.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta.AffinityCookieName
        {
            get
            {
                return this.AffinityCookieName();
            }
        }

        /// <summary>
        /// Gets authentication certificates associated with this backend HTTPS configuration.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayAuthenticationCertificate> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta.AuthenticationCertificates
        {
            get
            {
                return this.AuthenticationCertificates();
            }
        }

        /// <summary>
        /// Gets the probe associated with this backend.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration.Probe
        {
            get
            {
                return this.Probe();
            }
        }

        /// <summary>
        /// Gets true if cookie based affinity (sticky sessions) is enabled, else false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration.CookieBasedAffinity
        {
            get
            {
                return this.CookieBasedAffinity();
            }
        }

        /// <summary>
        /// Gets whether the host header should come from the host name of the backend server.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta.IsHostHeaderFromBackend
        {
            get
            {
                return this.IsHostHeaderFromBackend();
            }
        }

        /// <summary>
        /// Gets HTTP request timeout in seconds. Requests will fail if no response is received within the specified time.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration.RequestTimeout
        {
            get
            {
                return this.RequestTimeout();
            }
        }

        /// <summary>
        /// Gets host header to be sent to the backend servers.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta.HostHeader
        {
            get
            {
                return this.HostHeader();
            }
        }

        /// <summary>
        /// Gets the path, if any, used as a prefix for all HTTP requests.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta.Path
        {
            get
            {
                return this.Path();
            }
        }

        /// <summary>
        /// Gets true if the probe is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta.IsProbeEnabled
        {
            get
            {
                return this.IsProbeEnabled();
            }
        }

        /// <summary>
        /// Specifies the name for the affinity cookie.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithCookieNameBeta.WithAffinityCookieName(string name)
        {
            return this.WithAffinityCookieName(name);
        }

        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAffinity.WithoutCookieBasedAffinity()
        {
            return this.WithoutCookieBasedAffinity();
        }

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAffinity.WithCookieBasedAffinity()
        {
            return this.WithCookieBasedAffinity();
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration based on the specified data.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="derData">The DER-encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificateBeta.WithAuthenticationCertificateFromBytes(params byte[] derData)
        {
            return this.WithAuthenticationCertificateFromBytes(derData);
        }

        /// <summary>
        /// Removes the reference to the specified authentication certificate from this HTTP backend configuration.
        /// Note the certificate will remain associated with the application gateway until removed from it explicitly.
        /// </summary>
        /// <param name="name">The name of an existing authentication certificate associated with this HTTP backend configuration.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificateBeta.WithoutAuthenticationCertificate(string name)
        {
            return this.WithoutAuthenticationCertificate(name);
        }

        /// <summary>
        /// Associates the specified authentication certificate that exists on this application gateway with this backend HTTP confifuration.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="name">The name of an existing authentication certificate.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificateBeta.WithAuthenticationCertificate(string name)
        {
            return this.WithAuthenticationCertificate(name);
        }

        /// <summary>
        /// Removes all references to any authentication certificates.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificateBeta.WithoutAuthenticationCertificates()
        {
            return this.WithoutAuthenticationCertificates();
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// </summary>
        /// <param name="certificateFile">A file containing the DER representation of an X.509 certificate.</param>
        /// <return>The next stage of the update.</return>
        /// <throws>IOException when there are issues reading the specified file.</throws>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificateBeta.WithAuthenticationCertificateFromFile(FileInfo certificateFile)
        {
            return this.WithAuthenticationCertificateFromFile(certificateFile);
        }

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="base64Data">The base-64 encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificateBeta.WithAuthenticationCertificateFromBase64(string base64Data)
        {
            return this.WithAuthenticationCertificateFromBase64(base64Data);
        }

        /// <summary>
        /// Specifies HTTP as the protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithProtocolBeta.WithHttp()
        {
            return this.WithHttp();
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        /// <deprecated>Use  .withHttp() or  .withHttps() instead.</deprecated>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithProtocol.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Specifies HTTPS as the protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithProtocolBeta.WithHttps()
        {
            return this.WithHttps();
        }

        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithRequestTimeout.WithRequestTimeout(int seconds)
        {
            return this.WithRequestTimeout(seconds);
        }

        /// <summary>
        /// Specifies the number of seconds when connection draining is active.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 3600.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithConnectionDrainingBeta<ApplicationGateway.Update.IUpdate>.WithConnectionDrainingTimeoutInSeconds(int seconds)
        {
            return this.WithConnectionDrainingTimeoutInSeconds(seconds);
        }

        /// <summary>
        /// Specifies the number of seconds when connection draining is active.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 3600.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithConnectionDrainingBeta<ApplicationGateway.Definition.IWithCreate>.WithConnectionDrainingTimeoutInSeconds(int seconds)
        {
            return this.WithConnectionDrainingTimeoutInSeconds(seconds);
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        /// <deprecated>Use  .withHttps() instead (HTTP is the default).</deprecated>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithProtocol<ApplicationGateway.Update.IUpdate>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Specifies HTTPS as the protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithProtocolBeta<ApplicationGateway.Update.IUpdate>.WithHttps()
        {
            return this.WithHttps();
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        /// <deprecated>Use  .withHttps() instead (HTTP is the default).</deprecated>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithProtocol<ApplicationGateway.Definition.IWithCreate>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Specifies HTTPS as the protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttachAndAuthCert<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithProtocolBeta<ApplicationGateway.Definition.IWithCreate>.WithHttps()
        {
            return this.WithHttps();
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
        /// Removes the association with a probe.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithProbe.WithoutProbe()
        {
            return this.WithoutProbe();
        }

        /// <summary>
        /// Specifies an existing probe on this application gateway to associate with this backend.
        /// If the probe with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition. This only adds a reference to the probe by its name.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGatewayBackendHttpConfiguration.Update.IWithProbe.WithProbe(string name)
        {
            return this.WithProbe(name);
        }

        /// <summary>
        /// Specifies the name for the affinity cookie.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithCookieNameBeta<ApplicationGateway.Update.IUpdate>.WithAffinityCookieName(string name)
        {
            return this.WithAffinityCookieName(name);
        }

        /// <summary>
        /// Specifies the name for the affinity cookie.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayBackendHttpConfiguration.Definition.IWithCookieNameBeta<ApplicationGateway.Definition.IWithCreate>.WithAffinityCookieName(string name)
        {
            return this.WithAffinityCookieName(name);
        }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        Models.ApplicationGatewayProtocol Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.ApplicationGatewayProtocol>.Protocol
        {
            get
            {
                return this.Protocol();
            }
        }
    }
}