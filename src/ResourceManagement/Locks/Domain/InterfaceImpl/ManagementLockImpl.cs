// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Locks.Fluent.Models;
    using Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition;
    using Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class ManagementLockImpl 
    {
        /// <summary>
        /// Specifies the lock level.
        /// </summary>
        /// <param name="level">The level of the lock.</param>
        /// <return>The next stage of the definition.</return>
        ManagementLock.Update.IUpdate ManagementLock.Update.IWithLevel.WithLevel(LockLevel level)
        {
            return this.WithLevel(level);
        }

        /// <summary>
        /// Specifies the lock level.
        /// </summary>
        /// <param name="level">The level of the lock.</param>
        /// <return>The next stage of the definition.</return>
        ManagementLock.Definition.IWithCreate ManagementLock.Definition.IWithLevel.WithLevel(LockLevel level)
        {
            return this.WithLevel(level);
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Specifies the notes for the lock.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ManagementLock.Definition.IWithCreate ManagementLock.Definition.IWithNotes.WithNotes(string notes)
        {
            return this.WithNotes(notes);
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Locks.Fluent.IAuthorizationManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Locks.Fluent.IAuthorizationManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }

        /// <summary>
        /// Gets the lock level.
        /// </summary>
        Models.LockLevel Microsoft.Azure.Management.Locks.Fluent.IManagementLock.Level
        {
            get
            {
                return this.Level();
            }
        }

        /// <summary>
        /// Gets the resource ID of the locked resource.
        /// </summary>
        string Microsoft.Azure.Management.Locks.Fluent.IManagementLock.LockedResourceId
        {
            get
            {
                return this.LockedResourceId();
            }
        }

        /// <summary>
        /// Gets any notes associated with the lock.
        /// </summary>
        string Microsoft.Azure.Management.Locks.Fluent.IManagementLock.Notes
        {
            get
            {
                return this.Notes();
            }
        }

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resourceId">The resource ID of the resource to lock.</param>
        /// <return>The next stage of the update.</return>
        ManagementLock.Update.IUpdate ManagementLock.Update.IWithLockedResource.WithLockedResource(string resourceId)
        {
            return this.WithLockedResource(resourceId);
        }

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resource">The resource to lock.</param>
        /// <return>The next stage of the update.</return>
        ManagementLock.Update.IUpdate ManagementLock.Update.IWithLockedResource.WithLockedResource(IResource resource)
        {
            return this.WithLockedResource(resource);
        }

        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroupName">The name of a resource group.</param>
        /// <return>The next stage of the update.</return>
        ManagementLock.Update.IUpdate ManagementLock.Update.IWithLockedResource.WithLockedResourceGroup(string resourceGroupName)
        {
            return this.WithLockedResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroup">A resource group.</param>
        /// <return>Then next stage of the update.</return>
        ManagementLock.Update.IUpdate ManagementLock.Update.IWithLockedResource.WithLockedResourceGroup(IResourceGroup resourceGroup)
        {
            return this.WithLockedResourceGroup(resourceGroup);
        }

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resourceId">The resource ID of the resource to lock.</param>
        /// <return>The next stage of the definition.</return>
        ManagementLock.Definition.IWithLevel ManagementLock.Definition.IWithLockedResource.WithLockedResource(string resourceId)
        {
            return this.WithLockedResource(resourceId);
        }

        /// <summary>
        /// Specifies the resource to lock.
        /// </summary>
        /// <param name="resource">The resource to lock.</param>
        /// <return>The next stage of the definition.</return>
        ManagementLock.Definition.IWithLevel ManagementLock.Definition.IWithLockedResource.WithLockedResource(IResource resource)
        {
            return this.WithLockedResource(resource);
        }

        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroupName">The name of a resource group.</param>
        /// <return>The next stage of the definition.</return>
        ManagementLock.Definition.IWithLevel ManagementLock.Definition.IWithLockedResource.WithLockedResourceGroup(string resourceGroupName)
        {
            return this.WithLockedResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Specifies the resource group to lock.
        /// </summary>
        /// <param name="resourceGroup">A resource group.</param>
        /// <return>Then next stage of the definition.</return>
        ManagementLock.Definition.IWithLevel ManagementLock.Definition.IWithLockedResource.WithLockedResourceGroup(IResourceGroup resourceGroup)
        {
            return this.WithLockedResourceGroup(resourceGroup);
        }
    }
}