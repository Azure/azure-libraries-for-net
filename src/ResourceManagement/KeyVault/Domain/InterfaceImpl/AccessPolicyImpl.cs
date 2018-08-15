// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class AccessPolicyImpl
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
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowSecretPermissions(params SecretPermissions[] permissions)
        {
            return this.AllowSecretPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions)
        {
            return this.AllowSecretPermissions(permissions);
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowKeyAllPermissions()
        {
            return this.AllowKeyAllPermissions();
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowSecretAllPermissions()
        {
            return this.AllowSecretAllPermissions();
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowKeyPermissions(params KeyPermissions[] permissions)
        {
            return this.AllowKeyPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions)
        {
            return this.AllowKeyPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowCertificatePermissions(params Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions[] permissions)
        {
            return this.AllowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions)
        {
            return this.AllowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access certificates.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.AllowCertificateAllPermissions()
        {
            return this.AllowCertificateAllPermissions();
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowCertificatePermissions(params Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions[] permissions)
        {
            return this.AllowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions)
        {
            return this.AllowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowSecretPermissions(params SecretPermissions[] permissions)
        {
            return this.AllowSecretPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions)
        {
            return this.AllowSecretPermissions(permissions);
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowKeyAllPermissions()
        {
            return this.AllowKeyAllPermissions();
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowSecretAllPermissions()
        {
            return this.AllowSecretAllPermissions();
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowKeyPermissions(params KeyPermissions[] permissions)
        {
            return this.AllowKeyPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions)
        {
            return this.AllowKeyPermissions(permissions);
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access certificates.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.AllowCertificateAllPermissions()
        {
            return this.AllowCertificateAllPermissions();
        }

        /// <summary>
        /// Gets The object ID of a user or service principal in the Azure Active
        /// Directory tenant for the vault.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy.ObjectId
        {
            get
            {
                return this.ObjectId;
            }
        }

        /// <summary>
        /// Gets The Azure Active Directory tenant ID that should be used for
        /// authenticating requests to the key vault.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy.TenantId
        {
            get
            {
                return this.TenantId;
            }
        }

        /// <summary>
        /// Gets Permissions the identity has for keys and secrets.
        /// </summary>
        Microsoft.Azure.Management.KeyVault.Fluent.Models.Permissions Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy.Permissions
        {
            get
            {
                return this.Permissions;
            }
        }

        /// <summary>
        /// Gets Application ID of the client making request on behalf of a principal.
        /// </summary>
        string Microsoft.Azure.Management.KeyVault.Fluent.IAccessPolicy.ApplicationId
        {
            get
            {
                return this.ApplicationId;
            }
        }

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipal">The AD service principal object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.ForServicePrincipal(IServicePrincipal servicePrincipal)
        {
            return this.ForServicePrincipal(servicePrincipal);
        }

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipalName">The service principal name of the AD user.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.ForServicePrincipal(string servicePrincipalName)
        {
            return this.ForServicePrincipal(servicePrincipalName);
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="user">The AD user object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.ForUser(IActiveDirectoryUser user)
        {
            return this.ForUser(user);
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="userPrincipalName">The user principal name of the AD user.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.ForUser(string userPrincipalName)
        {
            return this.ForUser(userPrincipalName);
        }

        /// <summary>
        /// Specifies the Active Directory group this access policy is for.
        /// </summary>
        /// <param name="activeDirectoryGroup">The AD group object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.ForGroup(IActiveDirectoryGroup activeDirectoryGroup)
        {
            return this.ForGroup(activeDirectoryGroup);
        }

        /// <summary>
        /// Specifies the object ID of the Active Directory identity this access policy is for.
        /// </summary>
        /// <param name="objectId">The object ID of the AD identity.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.ForObjectId(string objectId)
        {
            return this.ForObjectId(objectId);
        }

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipal">The AD service principal object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.ForServicePrincipal(IServicePrincipal servicePrincipal)
        {
            return this.ForServicePrincipal(servicePrincipal);
        }

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipalName">The service principal name of the AD user.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.ForServicePrincipal(string servicePrincipalName)
        {
            return this.ForServicePrincipal(servicePrincipalName);
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="user">The AD user object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.ForUser(IActiveDirectoryUser user)
        {
            return this.ForUser(user);
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="userPrincipalName">The user principal name of the AD user.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.ForUser(string userPrincipalName)
        {
            return this.ForUser(userPrincipalName);
        }

        /// <summary>
        /// Specifies the Active Directory group this access policy is for.
        /// </summary>
        /// <param name="activeDirectoryGroup">The AD group object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.ForGroup(IActiveDirectoryGroup activeDirectoryGroup)
        {
            return this.ForGroup(activeDirectoryGroup);
        }

        /// <summary>
        /// Specifies the object ID of the Active Directory identity this access policy is for.
        /// </summary>
        /// <param name="objectId">The object ID of the AD identity.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate> Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>.ForObjectId(string objectId)
        {
            return this.ForObjectId(objectId);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Revoke all permissions for the AD identity to access certificates.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowCertificateAllPermissions()
        {
            return this.DisallowCertificateAllPermissions();
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowCertificatePermissions(params Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions[] permissions)
        {
            return this.DisallowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions)
        {
            return this.DisallowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowCertificatePermissions(params Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions[] permissions)
        {
            return this.AllowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions)
        {
            return this.AllowCertificatePermissions(permissions);
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowSecretPermissions(params SecretPermissions[] permissions)
        {
            return this.DisallowSecretPermissions(permissions);
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions)
        {
            return this.DisallowSecretPermissions(permissions);
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowKeyPermissions(params KeyPermissions[] permissions)
        {
            return this.DisallowKeyPermissions(permissions);
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions to revoke.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions)
        {
            return this.DisallowKeyPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowSecretPermissions(params SecretPermissions[] permissions)
        {
            return this.AllowSecretPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions)
        {
            return this.AllowSecretPermissions(permissions);
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowKeyAllPermissions()
        {
            return this.AllowKeyAllPermissions();
        }

        /// <summary>
        /// Revoke all permissions for the AD identity to access secrets.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowSecretAllPermissions()
        {
            return this.DisallowSecretAllPermissions();
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowSecretAllPermissions()
        {
            return this.AllowSecretAllPermissions();
        }

        /// <summary>
        /// Revoke all permissions for the AD identity to access keys.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.DisallowKeyAllPermissions()
        {
            return this.DisallowKeyAllPermissions();
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowKeyPermissions(params KeyPermissions[] permissions)
        {
            return this.AllowKeyPermissions(permissions);
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions)
        {
            return this.AllowKeyPermissions(permissions);
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access certificates.
        /// </summary>
        /// <return>The next stage of access policy update.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IWithPermissions.AllowCertificateAllPermissions()
        {
            return this.AllowCertificateAllPermissions();
        }
    }
}