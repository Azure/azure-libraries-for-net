// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Management.Network.Fluent.Models;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PointToSiteConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.VirtualNetworkGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;


    /// <summary>
    /// Implementation for PointToSiteConfiguration and its create and update interfaces.
    /// </summary>
    public partial class PointToSiteConfigurationImpl :
        IndexableWrapper<VpnClientConfiguration>,
        IPointToSiteConfiguration,
        IDefinition<VirtualNetworkGateway.Update.IUpdate>,
        PointToSiteConfiguration.Update.IUpdate
    {
        private string BEGIN_CERT = "-----BEGIN CERTIFICATE-----";
        private string END_CERT = "-----END CERTIFICATE-----";
        private VirtualNetworkGatewayImpl parent;

        public PointToSiteConfigurationImpl WithAzureCertificateFromFile(string name, FileInfo certificateFile)
        {
            if (certificateFile == null)
            {
                throw new ArgumentNullException();
            }
            String content = File.ReadAllText(certificateFile.FullName);
            return this.WithAzureCertificate(name, content.Replace(BEGIN_CERT, "").Replace(END_CERT, ""));
        }

        public VirtualNetworkGateway.Update.IUpdate Parent()
        {
            return parent;
        }

        public PointToSiteConfigurationImpl WithRadiusAuthentication(string serverIPAddress, string serverSecret)
        {
            Inner.RadiusServerAddress = serverIPAddress;
            Inner.RadiusServerSecret = serverSecret;
            Inner.VpnClientRootCertificates = null;
            Inner.VpnClientRevokedCertificates = null;
            return this;
        }

        public PointToSiteConfigurationImpl WithAzureCertificate(string name, string certificateData)
        {
            if (Inner.VpnClientRootCertificates == null)
            {
                Inner.VpnClientRootCertificates = new List<VpnClientRootCertificateInner>();
            }
            Inner.VpnClientRootCertificates.Add(new VpnClientRootCertificateInner(certificateData, name:name));
            Inner.RadiusServerAddress = null;
            Inner.RadiusServerSecret = null;
            return this;
        }

        public PointToSiteConfigurationImpl WithAddressPool(string addressPool)
        {
            var addressPrefixes = new List<string>();
            addressPrefixes.Add(addressPool);
            Inner.VpnClientAddressPool = new AddressSpace(addressPrefixes);
            return this;
        }

        public PointToSiteConfiguration.Update.IUpdate WithoutAzureCertificate(string name)
        {
            if (Inner.VpnClientRootCertificates != null)
            {
                foreach (VpnClientRootCertificateInner certificateInner in Inner.VpnClientRootCertificates)
                {
                    if (name.Equals(certificateInner.Name))
                    {
                        Inner.VpnClientRootCertificates.Remove(certificateInner);
                        break;
                    }
                }
            }
            return this;
        }

        internal VirtualNetworkGatewayImpl Attach()
        {
            parent.AttachPointToSiteConfiguration(this);
            return parent;
        }

        public PointToSiteConfigurationImpl WithSstpOnly()
        {
            Inner.VpnClientProtocols = new List<VpnClientProtocol>{VpnClientProtocol.SSTP};
            return this;
        }

        public PointToSiteConfigurationImpl WithRevokedCertificate(string name, string thumbprint)
        {
            if (Inner.VpnClientRevokedCertificates == null)
            {
                Inner.VpnClientRevokedCertificates = new List<VpnClientRevokedCertificateInner>();
            }
            Inner.VpnClientRevokedCertificates.Add(new VpnClientRevokedCertificateInner(name:name, thumbprint:thumbprint));
            Inner.RadiusServerAddress = null;
            Inner.RadiusServerSecret = null;
            return this;
        }

        public PointToSiteConfigurationImpl WithIkeV2Only()
        {
            Inner.VpnClientProtocols = new List<VpnClientProtocol> {VpnClientProtocol.IkeV2};
            return this;
        }

        internal PointToSiteConfigurationImpl(VpnClientConfiguration inner, VirtualNetworkGatewayImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }
    }
}