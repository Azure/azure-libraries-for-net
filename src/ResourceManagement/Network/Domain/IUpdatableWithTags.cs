// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.UpdatableWithTags.UpdatableWithTags;

    /// <summary>
    /// Interface for a resource which tags can be updated as a separate operation.
    /// </summary>
    /// <typeparam name="T">The fluent type of the resource.</typeparam>
    public interface IUpdatableWithTags<T> 
    {

        /// <summary>
        /// Begins a tags update for a resource.
        /// This is the beginning of the builder pattern used to update tags for a resources
        /// in Azure. The final method completing the definition and starting the actual resource update
        /// process in Azure is  AppliableWithTags.applyTags().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        UpdatableWithTags.UpdatableWithTags.IUpdateWithTags<T> UpdateTags();
    }
}