// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class PointToSiteConfigurationImpl 
    {
        /// <summary>
        /// Specifies revoked certificate.
        /// </summary>
        /// <param name="name">Certificate name.</param>
        /// <param name="thumbprint">Certificate thumbprint.</param>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithRevokedCertificate.WithRevokedCertificate(string name, string thumbprint)
        {
            return this.WithRevokedCertificate(name, thumbprint);
        }

        /// <summary>
        /// Specifies that RADIUS authentication type will be used.
        /// </summary>
        /// <param name="serverIPAddress">The radius server address.</param>
        /// <param name="serverSecret">The radius server secret.</param>
        /// <return>The next stage of the update.</return>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithAuthenticationType.WithRadiusAuthentication(string serverIPAddress, string serverSecret)
        {
            return this.WithRadiusAuthentication(serverIPAddress, serverSecret);
        }

        PointToSiteConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Update.IUpdate> PointToSiteConfiguration.Definition.IWithRevokedCertificate<VirtualNetworkGateway.Update.IUpdate>.WithRevokedCertificate(string name, string thumbprint)
        {
            return this.WithRevokedCertificate(name, thumbprint);
        }

        /// <summary>
        /// Specifies that only SSTP tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithTunnelType.WithSstpOnly()
        {
            return this.WithSstpOnly();
        }

        /// <summary>
        /// Specifies that only IKEv2 VPN tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithTunnelType.WithIkeV2Only()
        {
            return this.WithIkeV2Only();
        }

        /// <summary>
        /// Specifies that only SSTP tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PointToSiteConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Update.IUpdate> PointToSiteConfiguration.Definition.IWithTunnelType<VirtualNetworkGateway.Update.IUpdate>.WithSstpOnly()
        {
            return this.WithSstpOnly();
        }

        /// <summary>
        /// Specifies that only IKEv2 VPN tunnel type will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        PointToSiteConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Update.IUpdate> PointToSiteConfiguration.Definition.IWithTunnelType<VirtualNetworkGateway.Update.IUpdate>.WithIkeV2Only()
        {
            return this.WithIkeV2Only();
        }

        /// <summary>
        /// Specifies that Azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateData">The certificate public data.</param>
        /// <return>The next stage of the update.</return>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithAzureCertificate.WithAzureCertificate(string name, string certificateData)
        {
            return this.WithAzureCertificate(name, certificateData);
        }

        /// <summary>
        /// Removes attached azure certificate with specified name.
        /// </summary>
        /// <param name="name">Name of the certificate.</param>
        /// <return>The next stage of the update.</return>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithAzureCertificate.WithoutAzureCertificate(string name)
        {
            return this.WithoutAzureCertificate(name);
        }

        /// <summary>
        /// Specifies that azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateFile">Public Base64-encoded certificate file.</param>
        /// <return>The next stage of the update.</return>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithAzureCertificate.WithAzureCertificateFromFile(string name, FileInfo certificateFile)
        {
            return this.WithAzureCertificateFromFile(name, certificateFile);
        }

        /// <summary>
        /// Specifies that RADIUS server will be used for authentication.
        /// </summary>
        /// <param name="serverIPAddress">The radius server address.</param>
        /// <param name="serverSecret">The radius server secret.</param>
        /// <return>The next stage of the definition.</return>
        PointToSiteConfiguration.Definition.IWithAttach<VirtualNetworkGateway.Update.IUpdate> PointToSiteConfiguration.Definition.IWithAuthenticationType<VirtualNetworkGateway.Update.IUpdate>.WithRadiusAuthentication(string serverIPAddress, string serverSecret)
        {
            return this.WithRadiusAuthentication(serverIPAddress, serverSecret);
        }

        /// <summary>
        /// Specifies that Azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateData">The certificate public data.</param>
        /// <return>The next stage of the definition.</return>
        PointToSiteConfiguration.Definition.IWithAttachAndAzureCertificate<VirtualNetworkGateway.Update.IUpdate> PointToSiteConfiguration.Definition.IWithAzureCertificate<VirtualNetworkGateway.Update.IUpdate>.WithAzureCertificate(string name, string certificateData)
        {
            return this.WithAzureCertificate(name, certificateData);
        }

        /// <summary>
        /// Specifies that Azure certificate authentication type will be used and certificate to use for Azure authentication.
        /// </summary>
        /// <param name="name">Name of certificate.</param>
        /// <param name="certificateFile">Public Base64-encoded certificate file.</param>
        /// <return>The next stage of the definition.</return>
        PointToSiteConfiguration.Definition.IWithAttachAndAzureCertificate<VirtualNetworkGateway.Update.IUpdate> PointToSiteConfiguration.Definition.IWithAzureCertificate<VirtualNetworkGateway.Update.IUpdate>.WithAzureCertificateFromFile(string name, FileInfo certificateFile)
        {
            return this.WithAzureCertificateFromFile(name, certificateFile);
        }

        /// <summary>
        /// Specifies address pool.
        /// </summary>
        /// <param name="addressPool">Address pool.</param>
        /// <return>The next stage of the update.</return>
        PointToSiteConfiguration.Update.IUpdate PointToSiteConfiguration.Update.IWithAddressPool.WithAddressPool(string addressPool)
        {
            return this.WithAddressPool(addressPool);
        }

        PointToSiteConfiguration.Definition.IWithAuthenticationType<VirtualNetworkGateway.Update.IUpdate> PointToSiteConfiguration.Definition.IWithAddressPool<VirtualNetworkGateway.Update.IUpdate>.WithAddressPool(string addressPool)
        {
            return this.WithAddressPool(addressPool);
        }

        VirtualNetworkGateway.Update.IUpdate ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualNetworkGateway.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }
    }
}