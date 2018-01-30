// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;

namespace Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update
{
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Specifies authentication type of the point-to-site configuration.
    /// </summary>
    public interface IWithAuthenticationType  :
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IWithAzureCertificate
    {
        /// <summary>
        /// Specifies that RADIUS authentication type will be used.
        /// </summary>
        /// <param name="serverIPAddress">The radius server address.</param>
        /// <param name="serverSecret">The radius server secret.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithRadiusAuthentication(string serverIPAddress, string serverSecret);
    }

    /// <summary>
    /// Specifies revoked certificate for azure authentication.
    /// </summary>
    public interface IWithRevokedCertificate 
    {
        /// <summary>
        /// Specifies revoked certificate.
        /// </summary>
        /// <param name="name">Certificate name.</param>
        /// <param name="thumbprint">Certificate thumbprint.</param>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithRevokedCertificate(string name, string thumbprint);
    }

    /// <summary>
    /// Specifies Azure certificate for authentication.
    /// </summary>
    public interface IWithAzureCertificate 
    {
        /// <summary>
        /// Specifies that azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateFile">Public Base64-encoded certificate file.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithAzureCertificateFromFile(string name, FileInfo certificateFile);

        /// <summary>
        /// Specifies that Azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateData">The certificate public data.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithAzureCertificate(string name, string certificateData);

        /// <summary>
        /// Removes attached azure certificate with specified name.
        /// </summary>
        /// <param name="name">Name of the certificate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithoutAzureCertificate(string name);
    }

    /// <summary>
    /// The stage of the point-to-site configuration definition allowing to specify address pool.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAddressPool 
    {
        /// <summary>
        /// Specifies address pool.
        /// </summary>
        /// <param name="addressPool">Address pool.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithAddressPool(string addressPool);
    }

    /// <summary>
    /// The stage of a point-to-site configuration definition allowing to specify which tunnel type will be used.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTunnelType 
    {
        /// <summary>
        /// Specifies that only SSTP tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithSstpOnly();

        /// <summary>
        /// Specifies that only IKEv2 VPN tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IUpdate WithIkeV2Only();
    }

    /// <summary>
    /// The entirety of a subnet update as part of a network update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IWithAddressPool,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IWithAuthenticationType,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IWithRevokedCertificate,
        Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update.IWithTunnelType,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update.IUpdate>
    {
    }
}