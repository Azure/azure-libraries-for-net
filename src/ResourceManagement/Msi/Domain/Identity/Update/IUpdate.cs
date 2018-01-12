// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Msi.Fluent.Identity.Update
{
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The template for an identity update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Msi.Fluent.IIdentity>,
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IWithAccess,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the identity update allowing to set access role (permission) for it
    /// to access a resource or remove an assigned role.
    /// </summary>
    public interface IWithAccess  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that an access role assigned to the identity should be removed.
        /// </summary>
        /// <param name="resourceId">Id of the resource that identity has access.</param>
        /// <param name="role">The access role assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithoutAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource. An applications running on an Azure service with this identity
        /// can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">The resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithAccessTo(IResource resource, BuiltInRole role);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource identified by the given resource id. An applications running
        /// on an Azure service with this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource. An applications running on an Azure service with
        /// this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">Scope of the access represented as ARM resource.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithAccessTo(IResource resource, string roleDefinitionId);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource identified by the given resource id. An applications
        /// running on an Azure service with this identity can use this permission to access
        /// the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on the resource group that identity resides. An applications running on an Azure
        /// service with this identity can use this permission to access the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on the resource group that identity resides. An applications running
        /// on an Azure service with this identity can use this permission to access the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithAccessToCurrentResourceGroup(string roleDefinitionId);

        /// <summary>
        /// Specifies that an access role assigned to the identity should be removed.
        /// </summary>
        /// <param name="roleAssignment">Describes an existing role assigned to the identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Update.IUpdate WithoutAccess(IRoleAssignment roleAssignment);
    }
}