// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update
{
    using Microsoft.Azure.Management.Network.Fluent.HasPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.IO;

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to control connection draining.
    /// </summary>
    public interface IWithConnectionDraining :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithConnectionDrainingBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the port number.
    /// </summary>
    public interface IWithPort :
        Microsoft.Azure.Management.Network.Fluent.HasPort.Update.IWithPort<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to associate an existing probe.
    /// </summary>
    public interface IWithProbe
    {
        /// <summary>
        /// Specifies an existing probe on this application gateway to associate with this backend.
        /// If the probe with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition. This only adds a reference to the probe by its name.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithProbe(string name);

        /// <summary>
        /// Removes the association with a probe.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutProbe();
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to enable or disable cookie based affinity.
    /// </summary>
    public interface IWithAffinity
    {
        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutCookieBasedAffinity();

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithCookieBasedAffinity();
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the name for the affinity cookie.
    /// </summary>
    public interface IWithCookieName :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithCookieNameBeta
    {
    }

    /// <summary>
    /// The entirety of an application gateway backend HTTPS configuration update as part of an application gateway update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithPort,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithAffinity,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithProtocol,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithRequestTimeout,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithProbe,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithHostHeader,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithConnectionDraining,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithCookieName,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithPath,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificate
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the protocol.
    /// </summary>
    public interface IWithProtocol :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithProtocolBeta
    {
        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        /// <deprecated>Use  .withHttp() or  .withHttps() instead.</deprecated>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithProtocol(ApplicationGatewayProtocol protocol);

    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the path to use as the prefix for all HTTP requests.
    /// </summary>
    public interface IWithPath :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithPathBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the request timeout.
    /// </summary>
    public interface IWithRequestTimeout
    {
        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithRequestTimeout(int seconds);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to add an authentication certificate.
    /// </summary>
    public interface IWithAuthenticationCertificate :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithAuthenticationCertificateBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the host header.
    /// </summary>
    public interface IWithHostHeader :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IWithHostHeaderBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to control connection draining.
    /// </summary>
    public interface IWithConnectionDrainingBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the number of seconds when connection draining is active.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 3600.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithConnectionDrainingTimeoutInSeconds(int seconds);

        /// <summary>
        /// Disables connection draining.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutConnectionDraining();
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the name for the affinity cookie.
    /// </summary>
    public interface IWithCookieNameBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the name for the affinity cookie.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithAffinityCookieName(string name);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the protocol.
    /// </summary>
    public interface IWithProtocolBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies HTTP as the protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithHttp();

        /// <summary>
        /// Specifies HTTPS as the protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithHttps();
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the path to use as the prefix for all HTTP requests.
    /// </summary>
    public interface IWithPathBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the path prefix for all HTTP requests.
        /// </summary>
        /// <param name="path">A path.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithPath(string path);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to add an authentication certificate.
    /// </summary>
    public interface IWithAuthenticationCertificateBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration based on the specified data.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="derData">The DER-encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithAuthenticationCertificateFromBytes(params byte[] derData);

        /// <summary>
        /// Removes all references to any authentication certificates.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutAuthenticationCertificates();

        /// <summary>
        /// Associates the specified authentication certificate that exists on this application gateway with this backend HTTP confifuration.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="name">The name of an existing authentication certificate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithAuthenticationCertificate(string name);

        /// <summary>
        /// Removes the reference to the specified authentication certificate from this HTTP backend configuration.
        /// Note the certificate will remain associated with the application gateway until removed from it explicitly.
        /// </summary>
        /// <param name="name">The name of an existing authentication certificate associated with this HTTP backend configuration.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutAuthenticationCertificate(string name);

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="base64Data">The base-64 encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithAuthenticationCertificateFromBase64(string base64Data);

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// </summary>
        /// <param name="certificateFile">A file containing the DER representation of an X.509 certificate.</param>
        /// <return>The next stage of the update.</return>
        /// <throws>IOException when there are issues reading the specified file.</throws>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithAuthenticationCertificateFromFile(FileInfo certificateFile);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the host header.
    /// </summary>
    public interface IWithHostHeaderBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that no host header should be used.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithoutHostHeader();

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">The host header.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithHostHeader(string hostHeader);

        /// <summary>
        /// Specifies that the host header should come from the host name of the backend server.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate WithHostHeaderFromBackend();
    }
}