// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace Microsoft.Azure.Management.Storage.Fluent
{

    /// <summary>
    /// Type representing ManagementPolicy.
    /// </summary>
    public interface IManagementPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ManagementPolicyInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ManagementPolicy.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Storage.Fluent.StorageManager>
    {

        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the lastModifiedTime value.
        /// </summary>
        System.DateTime? LastModifiedTime { get; }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the policy value.
        /// </summary>
        ManagementPolicySchema Policy { get; }

        /// <summary>
        /// Gets the list of rules for this policy.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.IPolicyRule> Rules { get; }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Type { get; }
    }
}