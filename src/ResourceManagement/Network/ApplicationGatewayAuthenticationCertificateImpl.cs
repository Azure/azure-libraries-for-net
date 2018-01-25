// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System;
    using System.IO;

    /// <summary>
    /// Implementation for ApplicationGatewayAuthenticationCertificate.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5QXV0aGVudGljYXRpb25DZXJ0aWZpY2F0ZUltcGw=
    internal partial class ApplicationGatewayAuthenticationCertificateImpl :
        ChildResource<ApplicationGatewayAuthenticationCertificateInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayAuthenticationCertificate,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayAuthenticationCertificate.Update.IUpdate
    {
        ///GENMHASH:0648E1690535D61A28573BC3B13B6716:0F5669B96D71397B2A3BB1B5796EB1EA
        public string Data()
        {
            return Inner.Data;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        ///GENMHASH:6D44DD4D4F43AB2BAA4A5DD6D3D2BFCF:91FF797CDC201A00D6D902170FC1687A
        public ApplicationGatewayAuthenticationCertificateImpl FromBytes(params byte[] data)
        {
            string encoded = Convert.ToBase64String(data);
            return FromBase64(encoded);
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:26FAC135B91E92094DB49DC9C39E44F5
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithAuthenticationCertificate(this);
        }

        ///GENMHASH:C701E85BEC09E6869EB591BA77B862A1:74190EC00C414CE1E8D405570DCEEB51
        public ApplicationGatewayAuthenticationCertificateImpl FromBase64(string base64data)
        {
            if (base64data == null)
            {
                return this;
            }

            Inner.Data = base64data;
            return this;
        }

        ///GENMHASH:7DFCEDE8B7263E2097B6A68AAB6AFBE5:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayAuthenticationCertificateImpl(ApplicationGatewayAuthenticationCertificateInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:CDA6F03684CEB7F17161B79EB6C65F2D:4199CFBD77A78AE24D69DB2F945A21A1
        public ApplicationGatewayAuthenticationCertificateImpl FromFile(FileInfo certificateFile)
        {
            if (certificateFile == null)
            {
                return null;
            }

            byte[] content = File.ReadAllBytes(certificateFile.FullName);
            return (content != null) ? FromBytes(content) : null;
        }
    }
}