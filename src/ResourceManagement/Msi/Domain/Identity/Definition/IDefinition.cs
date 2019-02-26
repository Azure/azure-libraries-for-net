// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Msi.Fluent.Identity.Definition
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The stage of the identity definition allowing to set access role (permission) for it
    /// to access a resource.
    /// </summary>
    public interface IWithAccess 
    {
        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource. An applications running on an Azure service with this identity
        /// can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">The resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate WithAccessTo(IResource resource, BuiltInRole role);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on an ARM resource identified by the given resource id. An applications running
        /// on an Azure service with this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate WithAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource. An applications running on an Azure service with
        /// this identity can use this permission to access the resource.
        /// </summary>
        /// <param name="resource">Scope of the access represented as ARM resource.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate WithAccessTo(IResource resource, string roleDefinitionId);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on an ARM resource identified by the given resource id. An applications
        /// running on an Azure service with this identity can use this permission to access
        /// the resource.
        /// </summary>
        /// <param name="resourceId">Id of the resource to access.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate WithAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role)
        /// on the resource group that identity resides. An applications running on an Azure
        /// service with this identity can use this permission to access the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate WithAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that the identity should have the given access (described by the role
        /// definition) on the resource group that identity resides. An applications running
        /// on an Azure service with this identity can use this permission to access the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate WithAccessToCurrentResourceGroup(string roleDefinitionId);
    }

    /// <summary>
    /// The stage of the identity definition which contains all the minimum required inputs for
    /// the resource to be created but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity>,
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithAccess
    {
    }

    /// <summary>
    /// The first stage of an identity definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the identity definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// Container interface for all the definitions related to identity.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IBlank,
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithGroup,
        Microsoft.Azure.Management.Msi.Fluent.Identity.Definition.IWithCreate
    {
    }
}