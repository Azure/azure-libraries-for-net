// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Msi.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update
{
    /// <summary>
    /// The stage of the container group update allowing to enable System Assigned (Local) Managed Service Identity.
    /// </summary>
    public interface IWithSystemAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IUpdate WithoutSystemAssignedManagedServiceIdentity();

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be enabled in the
        /// container group.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// The stage of the System Assigned (Local) Managed Service Identity enabled container group allowing
    /// to set access role for the identity.
    /// </summary>
    public interface IWithSystemAssignedIdentityBasedAccessOrUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IUpdate
    {

        /// <summary>
        /// Specifies that container group's system assigned (local) identity should have the given
        /// access (described by the role) on an ARM resource identified by the resource ID.
        /// Applications running on the container group will have the same permission (role) on
        /// the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the container group's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that container group's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.
        /// Applications running on the container group will have the same permission (role) on
        /// the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the container group's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that container group's system assigned (local) identity should have the given access
        /// (described by the role) on the resource group that container group resides. Applications running
        /// on the container group will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the container group's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that container group's system assigned (local) identity should have the access (described by the
        /// role definition) on the resource group that container group resides. Applications running
        /// on the container group will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the container group's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IWithSystemAssignedIdentityBasedAccessOrUpdate WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }

    /// <summary>
    /// The stage of the container group update allowing to add or remove User Assigned (External) Managed Service Identities.
    /// </summary>
    public interface IWithUserAssignedManagedServiceIdentity :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the container group.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the container group update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IUpdate WithExistingUserAssignedManagedServiceIdentity(IIdentity identity);

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the container group.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the container group update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IUpdate WithNewUserAssignedManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity);

        /// <summary>
        /// Specifies that an user assigned identity associated with the container group should be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>The next stage of the container group update.</return>
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IUpdate WithoutUserAssignedManagedServiceIdentity(string identityId);
    }


    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ContainerInstance.Fluent.IContainerGroup>,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IWithSystemAssignedManagedServiceIdentity,
        Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Update.IWithUserAssignedManagedServiceIdentity
    {

    }
}