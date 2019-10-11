// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.IO;

    /// <summary>
    /// The entirety of an application gateway SSL certificate definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IUpdateDefinition<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithData<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ParentT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway SSL certificate definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {
    }


    /// <summary>
    /// The stage of an SSL certificate definition allowing to specify the password for the private key (PFX) content of the certificate.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway to return to after attaching.</typeparam>
    public interface IWithPassword<ParentT>
    {
        /// <summary>
        /// Specifies the password currently used to protect the provided PFX content of the SSL certificate.
        /// </summary>
        /// <param name="password">A password.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithAttach<ParentT> WithPfxPassword(string password);
    }

    /// <summary>
    /// The stage of an SSL certificate definition allowing to specify the contents of the SSL certificate.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway to return to after attaching.</typeparam>
    public interface IWithData<ParentT>
    {
        /// <summary>
        /// Specifies the PFX (PKCS#12) file to get the private key content from.
        /// </summary>
        /// <param name="pfxFile">A file in the PFX format.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>Java.io.IOException when there are problems with the provided file.</throws>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ParentT> WithPfxFromFile(FileInfo pfxFile);

        /// <summary>
        /// Specifies the contents of the private key in the PFX (PKCS#12) format, not base64-encoded.
        /// </summary>
        /// <param name="pfxData">The contents of the private key in the PFX format.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithPassword<ParentT> WithPfxFromBytes(params byte[] pfxData);

        /// <summary>
        /// Sepecifies the content of the private key using key vault.
        /// </summary>
        /// <param name="keyVaultSecretId">The secret id of key vault.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithAttach<ParentT> WithKeyVaultSecretId(string keyVaultSecretId);

    }

    /// <summary>
    /// The first stage of an application gateway authentication certificate definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IWithData<ParentT>
    {
    }
}