// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Msi.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent.Identity.Definition;
    using Microsoft.Azure.Management.Msi.Fluent.Identity.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;

    internal sealed partial class IdentityImpl 
    {
        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource. An applications running on an Azure service with this identity
        /// can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">The resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithAccessTo(IResource resource, BuiltInRole role)
        {
            return this.WithAccessTo(resource, role);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource identified by the given resource id. An applications running
        /// on an Azure service with this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource. An applications running on an Azure service with
        /// this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">Scope of the access represented as ARM resource.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithAccessTo(IResource resource, string roleDefinitionId)
        {
            return this.WithAccessTo(resource, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource identified by the given resource id. An applications
        /// running on an Azure service with this identity can use this permission to access
        /// the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithAccessTo(resourceId, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that an access role assigned to the identity should be removed.
        /// </summary>
        /// <param name="roleAssignment">Describes an existing role assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithoutAccess(IRoleAssignment roleAssignment)
        {
            return this.WithoutAccess(roleAssignment);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on the resource group that identity resides. An applications running on an Azure
        /// service with this identity can use this permission to access the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on the resource group that identity resides. An applications running
        /// on an Azure service with this identity can use this permission to access the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithAccessToCurrentResourceGroup(roleDefinitionId);
        }

        /// <summary>
        /// Specifies that an access role assigned to the identity should be removed.
        /// </summary>
        /// <param name="resourceId">Id of the resource that identity has access.</param>
        /// <param name="role">The access role assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Identity.Update.IUpdate Identity.Update.IWithAccess.WithoutAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithoutAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource. An applications running on an Azure service with this identity
        /// can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">The resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Identity.Definition.IWithCreate Identity.Definition.IWithAccess.WithAccessTo(IResource resource, BuiltInRole role)
        {
            return this.WithAccessTo(resource, role);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource identified by the given resource id. An applications running
        /// on an Azure service with this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Identity.Definition.IWithCreate Identity.Definition.IWithAccess.WithAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource. An applications running on an Azure service with
        /// this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">Scope of the access represented as ARM resource.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Identity.Definition.IWithCreate Identity.Definition.IWithAccess.WithAccessTo(IResource resource, string roleDefinitionId)
        {
            return this.WithAccessTo(resource, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource identified by the given resource id. An applications
        /// running on an Azure service with this identity can use this permission to access
        /// the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Identity.Definition.IWithCreate Identity.Definition.IWithAccess.WithAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithAccessTo(resourceId, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on the resource group that identity resides. An applications running on an Azure
        /// service with this identity can use this permission to access the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Identity.Definition.IWithCreate Identity.Definition.IWithAccess.WithAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on the resource group that identity resides. An applications running
        /// on an Azure service with this identity can use this permission to access the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Identity.Definition.IWithCreate Identity.Definition.IWithAccess.WithAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithAccessToCurrentResourceGroup(roleDefinitionId);
        }

        /// <summary>
        /// Gets id of the Azure Active Directory application associated with the identity.
        /// </summary>
        string Microsoft.Azure.Management.Msi.Fluent.IIdentity.ClientId
        {
            get
            {
                return this.ClientId();
            }
        }

        /// <summary>
        /// Gets id of the Azure Active Directory tenant to which the identity belongs to.
        /// </summary>
        string Microsoft.Azure.Management.Msi.Fluent.IIdentity.TenantId
        {
            get
            {
                return this.TenantId();
            }
        }

        /// <summary>
        /// Gets the url that can be queried to obtain the identity credentials.
        /// </summary>
        string Microsoft.Azure.Management.Msi.Fluent.IIdentity.ClientSecretUrl
        {
            get
            {
                return this.ClientSecretUrl();
            }
        }

        /// <summary>
        /// Gets id of the Azure Active Directory service principal object associated with the identity.
        /// </summary>
        string Microsoft.Azure.Management.Msi.Fluent.IIdentity.PrincipalId
        {
            get
            {
                return this.PrincipalId();
            }
        }
    }
}