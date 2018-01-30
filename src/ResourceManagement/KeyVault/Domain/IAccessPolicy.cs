// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a key vault access policy.
    /// </summary>
    public interface IAccessPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.AccessPolicyEntry>
    {
        /// <summary>
        /// Gets Permissions the identity has for keys and secrets.
        /// </summary>
        Models.Permissions Permissions { get; }

        /// <summary>
        /// Gets The Azure Active Directory tenant ID that should be used for
        /// authenticating requests to the key vault.
        /// </summary>
        string TenantId { get; }

        /// <summary>
        /// Gets Application ID of the client making request on behalf of a principal.
        /// </summary>
        string ApplicationId { get; }

        /// <summary>
        /// Gets The object ID of a user or service principal in the Azure Active
        /// Directory tenant for the vault.
        /// </summary>
        string ObjectId { get; }
    }
}