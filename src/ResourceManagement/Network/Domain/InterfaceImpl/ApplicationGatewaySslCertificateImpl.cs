// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.IO;

    internal partial class ApplicationGatewaySslCertificateImpl
    {
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
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Gets the public data of the certificate.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate.PublicData
        {
            get
            {
                return this.PublicData();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the contents of the private key in the PFX (PKCS#12) format, not base64-encoded.
        /// </summary>
        /// <param name="pfxData">The contents of the private key in the PFX format.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewaySslCertificate.Definition.IWithPassword<ApplicationGateway.Definition.IWithCreate> ApplicationGatewaySslCertificate.Definition.IWithData<ApplicationGateway.Definition.IWithCreate>.WithPfxFromBytes(params byte[] pfxData)
        {
            return this.WithPfxFromBytes(pfxData) as ApplicationGatewaySslCertificate.Definition.IWithPassword<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the PFX (PKCS#12) file to get the private key content from.
        /// </summary>
        /// <param name="pfxFile">A file in the PFX format.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>Java.io.IOException when there are problems with the provided file.</throws>
        ApplicationGatewaySslCertificate.Definition.IWithPassword<ApplicationGateway.Definition.IWithCreate> ApplicationGatewaySslCertificate.Definition.IWithData<ApplicationGateway.Definition.IWithCreate>.WithPfxFromFile(FileInfo pfxFile)
        {
            return this.WithPfxFromFile(pfxFile) as ApplicationGatewaySslCertificate.Definition.IWithPassword<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the password currently used to protect the provided PFX content of the SSL certificate.
        /// </summary>
        /// <param name="password">A password.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewaySslCertificate.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewaySslCertificate.Definition.IWithPassword<ApplicationGateway.Definition.IWithCreate>.WithPfxPassword(string password)
        {
            return this.WithPfxPassword(password) as ApplicationGatewaySslCertificate.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }


        /// <summary>
        /// Specifies the PFX (PKCS#12) file to get the private key content from.
        /// </summary>
        /// <param name="pfxFile">A file in the PFX format.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>System.IO.IOException when there are problems with the provided file.</throws>
        ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ApplicationGateway.Update.IUpdate> ApplicationGatewaySslCertificate.UpdateDefinition.IWithData<ApplicationGateway.Update.IUpdate>.WithPfxFromFile(FileInfo pfxFile)
        {
            return this.WithPfxFromFile(pfxFile) as ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the password currently used to protect the provided PFX content of the SSL certificate.
        /// </summary>
        /// <param name="password">A password.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ApplicationGateway.Update.IUpdate> ApplicationGatewaySslCertificate.UpdateDefinition.IWithData<ApplicationGateway.Update.IUpdate>.WithPfxFromBytes(params byte[] pfxData)
        {
            return this.WithPfxFromBytes(pfxData) as ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the password currently used to protect the provided PFX content of the SSL certificate.
        /// </summary>
        /// <param name="password">A password.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewaySslCertificate.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ApplicationGateway.Update.IUpdate>.WithPfxPassword(string password)
        {
            return this.WithPfxPassword(password) as ApplicationGatewaySslCertificate.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }
    }
}