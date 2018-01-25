// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition
{
    using System.IO;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// The entirety of an application gateway backend HTTPS configuration definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IBlank<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the name for the affinity cookie.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithCookieName<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithCookieNameBeta<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the request timeout.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithRequestTimeout<ReturnT>
    {
        /// <summary>
        /// Specifies the request timeout.
        /// </summary>
        /// <param name="seconds">A number of seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithRequestTimeout(int seconds);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to add an authentication certificate,
    /// specify other options or attach to the parent application gateway update.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithAttachAndAuthCert<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAuthenticationCertificate<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to add an authentication certificate.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithAuthenticationCertificate<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAuthenticationCertificateBeta<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the host header.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithHostHeader<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithHostHeaderBeta<ReturnT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway backend HTTP configuration definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IBlank<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway backend HTTP configuration definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithPort<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAffinity<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithProtocol<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithRequestTimeout<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithHostHeader<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithConnectionDraining<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithCookieName<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithPath<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAuthenticationCertificate<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to enable or disable cookie based affinity.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithAffinity<ReturnT>
    {
        /// <summary>
        /// Disables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithoutCookieBasedAffinity();

        /// <summary>
        /// Enables cookie based affinity.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithCookieBasedAffinity();
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the path to use as the prefix for all HTTP requests.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithPath<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithPathBeta<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to associate an existing probe.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithProbe<ReturnT>
    {
        /// <summary>
        /// Specifies an existing probe on this application gateway to associate with this backend.
        /// If the probe with the specified name does not yet exist, it must be defined separately in the optional part
        /// of the application gateway definition. This only adds a reference to the probe by its name.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithProbe(string name);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to control connection draining.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithConnectionDraining<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithConnectionDrainingBeta<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the port number.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithPort<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.HasPort.UpdateDefinition.IWithPort<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT>>
    {
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the protocol.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithProtocolBeta<ReturnT>
    {
        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        /// <deprecated>Use  .withHttps() instead (HTTP is the default).</deprecated>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithProtocol(ApplicationGatewayProtocol protocol);

    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the name for the affinity cookie.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithCookieNameBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the name for the affinity cookie.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithAffinityCookieName(string name);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to add an authentication certificate.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithAuthenticationCertificateBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration based on the specified data.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="derData">The DER encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ReturnT> WithAuthenticationCertificateFromBytes(params byte[] derData);

        /// <summary>
        /// Associates the specified authentication certificate that exists on this application gateway with this backend HTTP confifuration.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="name">The name of an existing authentication certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ReturnT> WithAuthenticationCertificate(string name);

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="base64Data">The base-64 encoded data of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ReturnT> WithAuthenticationCertificateFromBase64(string base64Data);

        /// <summary>
        /// Associates a new, automatically named certificate with this HTTP backend configuration loaded from the specified file.
        /// Multiple calls to this method will add additional certificate references.
        /// </summary>
        /// <param name="certificateFile">A file containing the DER representation of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IOException when there are issues reading from the specified file.</throws>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ReturnT> WithAuthenticationCertificateFromFile(FileInfo certificateFile);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the host header.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithHostHeaderBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">The host header.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithHostHeader(string hostHeader);

        /// <summary>
        /// Specifies that the host header should come from the host name of the backend server.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithHostHeaderFromBackend();
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the path to use as the prefix for all HTTP requests.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithPathBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the path prefix for all HTTP requests.
        /// </summary>
        /// <param name="path">A path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithPath(string path);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to control connection draining.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithConnectionDrainingBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the number of seconds when connection draining is active.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 3600.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttach<ReturnT> WithConnectionDrainingTimeoutInSeconds(int seconds);
    }

    /// <summary>
    /// The stage of an application gateway backend HTTP configuration allowing to specify the protocol.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithProtocolBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies HTTPS as the protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IWithAttachAndAuthCert<ReturnT> WithHttps();
    }
}