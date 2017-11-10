// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update
{
    using Microsoft.Azure.Management.Locks.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Locks.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Container interface for all the updates.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IWithLevel,
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IWithLockedResource
    {
    }

    /// <summary>
    /// The stage of a management lock update allowing to modify the level of the lock.
    /// </summary>
    public interface IWithLevel 
    {
        /// <summary>
        /// Specifies the lock level.
        /// </summary>
        /// <param name="level">The level of the lock.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IUpdate WithLevel(LockLevel level);
    }

    /// <summary>
    /// The stage of a management lock update allowing to specify the resource to lock.
    /// </summary>
    public interface IWithLockedResource 
    {
        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroupName">The name of a resource group.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IUpdate WithLockedResourceGroup(string resourceGroupName);

        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroup">A resource group.</param>
        /// <return>Then next stage of the update.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IUpdate WithLockedResourceGroup(IResourceGroup resourceGroup);

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resourceId">The resource ID of the resource to lock.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IUpdate WithLockedResource(string resourceId);

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resource">The resource to lock.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IUpdate WithLockedResource(IResource resource);
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
        Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update.IUpdate WithNotes(string notes);
    }
}