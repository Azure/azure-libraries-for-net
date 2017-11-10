// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent
{
    using Microsoft.Azure.Management.Locks.Fluent.Models;
    using Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Management lock.
    /// </summary>
    public interface IManagementLock  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Locks.Fluent.IManagementLock>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ManagementLock.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ManagementLockObjectInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Locks.Fluent.IAuthorizationManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId
    {
        /// <summary>
        /// Gets any notes associated with the lock.
        /// </summary>
        string Notes { get; }

        /// <summary>
        /// Gets the lock level.
        /// </summary>
        Models.LockLevel Level { get; }

        /// <summary>
        /// Gets the resource ID of the locked resource.
        /// </summary>
        string LockedResourceId { get; }
    }
}