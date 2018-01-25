// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.IO;

    /// <summary>
    /// The final stage of an application gateway authentication certificate definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ReturnT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway authentication certificate definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IBlank<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IWithAttach<ReturnT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IWithData<ReturnT>
    {
    }

    /// <summary>
    /// The stage of an application gateway authentication certificate definition allowing to specify the data of the certificate.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithData<ReturnT>
    {
        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="derData">The DER-encoded bytes of an X.509 certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IWithAttach<ReturnT> FromBytes(params byte[] derData);

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="base64data">Base-64 encoded data of the certificate.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IWithAttach<ReturnT> FromBase64(string base64data);

        /// <summary>
        /// Specifies an X.509 certificate to upload.
        /// </summary>
        /// <param name="certificateFile">A DER encoded X.509 certificate file.</param>
        /// <return>The next stage of the definition.</return>
        /// <throws>IOException when there are problems reading the certificate file.</throws>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IWithAttach<ReturnT> FromFile(FileInfo certificateFile);
    }

    /// <summary>
    /// The first stage of an application gateway authentication certificate definition.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.Definition.IWithData<ReturnT>
    {
    }
}