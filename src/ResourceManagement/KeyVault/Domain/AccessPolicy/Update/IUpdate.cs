// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The access policy update stage allowing permissions to be added or removed.
    /// </summary>
    public interface IWithPermissions
    {
        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowKeyAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowKeyPermissions(params KeyPermissions[] permissions);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions);

        /// <summary>
        /// Revoke all permissions for the AD identity to access keys.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowKeyAllPermissions();

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowKeyPermissions(params KeyPermissions[] permissions);

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions);

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowSecretAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowSecretPermissions(params SecretPermissions[] permissions);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions);

        /// <summary>
        /// Revoke all permissions for the AD identity to access secrets.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowSecretAllPermissions();

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowSecretPermissions(params SecretPermissions[] permissions);

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions);

        /// <summary>
        /// Revoke all permissions for the AD identity to access certificates.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowCertificateAllPermissions();

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowCertificatePermissions(params CertificatePermissions[] permissions);

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate DisallowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions);

        /// <summary>
        /// Allow all permissions for the AD identity to access certificates.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowCertificateAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowCertificatePermissions(params CertificatePermissions[] permissions);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate AllowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions);
    }

    /// <summary>
    /// The entirety of an access policy update as part of a key vault update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>
    {
    }
}