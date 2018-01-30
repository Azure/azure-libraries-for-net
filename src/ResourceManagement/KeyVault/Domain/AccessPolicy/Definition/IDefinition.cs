// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The final stage of the access policy definition.
    /// At this stage, more permissions can be added or application ID can be specified,
    /// or the access policy definition can be attached to the parent key vault definition
    /// using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithPermissions<ParentT>
    {
    }

    /// <summary>
    /// The first stage of an access policy definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithIdentity<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an access policy definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT> :
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The access policy definition stage allowing permissions to be added.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPermissions<ParentT>
    {
        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowKeyAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowKeyPermissions(params Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions[] permissions);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions);

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowSecretAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowSecretPermissions(params Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions[] permissions);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions);

        /// <summary>
        /// Allow all permissions for the AD identity to access certificates.
        /// </summary>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowCertificateAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowCertificatePermissions(params CertificatePermissions[] permissions);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access certificates.
        /// </summary>
        /// <param name="permissions">The list of permissions allowed.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> AllowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions);
    }

    /// <summary>
    /// The access policy definition stage allowing the Active Directory identity to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIdentity<ParentT>
    {
        /// <summary>
        /// Specifies the object ID of the Active Directory identity this access policy is for.
        /// </summary>
        /// <param name="objectId">The object ID of the AD identity.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> ForObjectId(string objectId);

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="user">The AD user object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> ForUser(IActiveDirectoryUser user);

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="userPrincipalName">The user principal name of the AD user.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> ForUser(string userPrincipalName);

        /// <summary>
        /// Specifies the Active Directory group this access policy is for.
        /// </summary>
        /// <param name="activeDirectoryGroup">The AD group object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> ForGroup(IActiveDirectoryGroup activeDirectoryGroup);

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipal">The AD service principal object.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> ForServicePrincipal(IServicePrincipal servicePrincipal);

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipalName">The service principal name of the AD user.</param>
        /// <return>The next stage of access policy definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition.IWithAttach<ParentT> ForServicePrincipal(string servicePrincipalName);
    }
}