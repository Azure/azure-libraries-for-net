// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.IO;

    internal partial class ApplicationGatewayAuthenticationCertificateImpl
    {
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach();
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
        /// Gets base-64 encoded bytes of the X.509 certificate.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayAuthenticationCertificate.Data
        {
            get
            {
                return this.Data();
            }
        }

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="derData">The DER-encoded bytes of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayAuthenticationCertificate.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayAuthenticationCertificate.Definition.IWithData<ApplicationGateway.Definition.IWithCreate>.FromBytes(params byte[] derData)
        {
            return this.FromBytes(derData);
        }

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="certificateFile">A DER encoded X.509 certificate file.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IOException when there are problems reading the certificate file.</throws>
        ApplicationGatewayAuthenticationCertificate.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayAuthenticationCertificate.Definition.IWithData<ApplicationGateway.Definition.IWithCreate>.FromFile(FileInfo certificateFile)
        {
            return this.FromFile(certificateFile);
        }

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="base64data">Base-64 encoded data of the certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayAuthenticationCertificate.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayAuthenticationCertificate.Definition.IWithData<ApplicationGateway.Definition.IWithCreate>.FromBase64(string base64data)
        {
            return this.FromBase64(base64data);
        }

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="data">The DER-encoded bytes of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithData<ApplicationGateway.Update.IUpdate>.FromBytes(params byte[] data)
        {
            return this.FromBytes(data);
        }

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="certificateFile">A DER encoded X.509 certificate file.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IOException when there are problems reading the certificate file.</throws>
        ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithData<ApplicationGateway.Update.IUpdate>.FromFile(FileInfo certificateFile)
        {
            return this.FromFile(certificateFile);
        }

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="base64data">Base-64 encoded data of the certificate.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithData<ApplicationGateway.Update.IUpdate>.FromBase64(string base64data)
        {
            return this.FromBase64(base64data);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }
    }
}