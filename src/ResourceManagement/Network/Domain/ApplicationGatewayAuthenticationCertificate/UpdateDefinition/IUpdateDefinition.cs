// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition
{
    using System.IO;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The entirety of an application gateway authentication certificate definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IBlank<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithData<ReturnT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway authentication certificate definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithData<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway authentication certificate definition allowing to specify the data of the certificate.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithData<ReturnT>
    {
        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="data">The DER-encoded bytes of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithAttach<ReturnT> FromBytes(params byte[] data);

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="base64data">Base-64 encoded data of the certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithAttach<ReturnT> FromBase64(string base64data);

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="certificateFile">A DER encoded X.509 certificate file.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IOException when there are problems reading the certificate file.</throws>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IWithAttach<ReturnT> FromFile(FileInfo certificateFile);
    }

    /// <summary>
    /// The final stage of an application gateway authentication certificate definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ReturnT>
    {
    }
}