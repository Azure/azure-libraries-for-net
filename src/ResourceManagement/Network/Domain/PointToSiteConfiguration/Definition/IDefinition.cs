// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;

namespace Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    public interface IWithAddressPool<ParentT> 
    {
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAuthenticationType<ParentT> WithAddressPool(string addressPool);
    }

    /// <summary>
    /// The final stage of the point-to-site configuration definition.
    /// At this stage, any remaining optional settings can be specified, or the point-to-site configuration definition
    /// can be attached to the parent virtual network gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithTunnelType<ParentT>
    {
    }

    /// <summary>
    /// The stage of the point-to-site configuration definition allowing to add root certificate for Azure authentication.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAzureCertificate<ParentT> 
    {
        /// <summary>
        /// Specifies that Azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateFile">Public Base64-encoded certificate file.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttachAndAzureCertificate<ParentT> WithAzureCertificateFromFile(string name, FileInfo certificateFile);

        /// <summary>
        /// Specifies that Azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateData">The certificate public data.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttachAndAzureCertificate<ParentT> WithAzureCertificate(string name, string certificateData);
    }

    public interface IWithRevokedCertificate<ParentT> 
    {
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttach<ParentT> WithRevokedCertificate(string name, string thumbprint);
    }

    /// <summary>
    /// The final stage of the point-to-site configuration definition.
    /// At this stage, any remaining optional settings can be specified, or the point-to-site configuration definition
    /// can be attached to the parent virtual network gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttachAndAzureCertificate<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithTunnelType<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAzureCertificate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithRevokedCertificate<ParentT>
    {
    }

    /// <summary>
    /// The stage of a point-to-site configuration definition allowing to specify which tunnel type will be used.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTunnelType<ParentT> 
    {
        /// <summary>
        /// Specifies that only SSTP tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttach<ParentT> WithSstpOnly();

        /// <summary>
        /// Specifies that only IKEv2 VPN tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttach<ParentT> WithIkeV2Only();
    }

    /// <summary>
    /// The stage of the point-to-site configuration definition allowing to specify authentication type.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAuthenticationType<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAzureCertificate<ParentT>
    {
        /// <summary>
        /// Specifies that RADIUS server will be used for authentication.
        /// </summary>
        /// <param name="serverIPAddress">The radius server address.</param>
        /// <param name="serverSecret">The radius server secret.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttach<ParentT> WithRadiusAuthentication(string serverIPAddress, string serverSecret);
    }

    /// <summary>
    /// The first stage of the point-to-site configuration definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAddressPool<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a point-to-site configuration definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAuthenticationType<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAddressPool<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition.IWithAttachAndAzureCertificate<ParentT>
    {
    }
}