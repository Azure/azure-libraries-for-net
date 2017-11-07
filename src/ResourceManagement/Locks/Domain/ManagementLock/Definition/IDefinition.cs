// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition
{
    using Microsoft.Azure.Management.Locks.Fluent.Models;
    using Microsoft.Azure.Management.Locks.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The stage of a management lock definition allowing to specify notes for the lock.
    /// </summary>
    public interface IWithLevel 
    {
        /// <summary>
        /// Specifies the lock level.
        /// </summary>
        /// <param name="level">The level of the lock.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithCreate WithLevel(LockLevel level);
    }

    /// <summary>
    /// The stage of a management lock definition allowing to specify the level of the lock.
    /// </summary>
    public interface IWithNotes 
    {
        /// <summary>
        /// Specifies the notes for the lock.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithCreate WithNotes(string notes);
    }

    /// <summary>
    /// The stage of the management lock definition which contains all the minimum required inputs for
    /// the resource to be created but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithNotes
    {
    }

    /// <summary>
    /// Container interface for all the definitions.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IBlank,
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithLockedResource,
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithLevel,
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a management lock definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithLockedResource
    {
    }

    /// <summary>
    /// The stage of a management lock definition allowing to specify the resource to lock.
    /// </summary>
    public interface IWithLockedResource 
    {
        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroupName">The name of a resource group.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithLevel WithLockedResourceGroup(string resourceGroupName);

        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroup">A resource group.</param>
        /// <return>Then next stage of the definition.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithLevel WithLockedResourceGroup(IResourceGroup resourceGroup);

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resourceId">The resource ID of the resource to lock.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithLevel WithLockedResource(string resourceId);

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resource">The resource to lock.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition.IWithLevel WithLockedResource(IResource resource);
    }
}