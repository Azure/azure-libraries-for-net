// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    /// <summary>
    /// An interface representing a model that can attach an indexing policy.
    /// </summary>
    public interface IHasIndexingPolicy<T> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Attaches the indexing policy
        /// </summary>
        /// <param name="indexingPolicy">The indexing policy to attach to.</param>
        /// <returns>The interface itself.</returns>
        T WithIndexingPolicy(Models.IndexingPolicy indexingPolicy);
    }
}
