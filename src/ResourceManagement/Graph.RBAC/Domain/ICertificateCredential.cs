// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure AD credential.
    /// </summary>
    public interface ICertificateCredential :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.ICredential,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.KeyCredential>
    {
        /// <summary>
        /// Custom Key Identifier. If the credential is defined by .NET SDK with name,
        /// it would be the base64 encoding of name. If it is set by other tools, it would
        /// be that value. Otherwise, it would usually be the thumbprint of certificate.
        /// </summary>
        string CustomKeyIdentifier { get; }
    }
}