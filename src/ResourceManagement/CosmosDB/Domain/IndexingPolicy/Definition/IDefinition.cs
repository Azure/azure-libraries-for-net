// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.IndexingPolicy.Definition
{
    /// <summary>
    /// The entirety of an indexing policy definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of an indexing policy definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the indexing policy definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        IWithAutomatic<ParentT>,
        IWithIndexingMode<ParentT>,
        IWithIncludedPaths<ParentT>,
        IWithExcludedPaths<ParentT>,
        IWithCompositeIndexes<ParentT>,
        IWithSpatialIndexes<ParentT>
    {
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set automatic setting.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAutomatic<ParentT>
    {
        /// <summary>
        /// Specifies automatic setting.
        /// </summary>
        /// <param name="isAutomatic">The bool about it is automatic or not</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithAutomatic(bool isAutomatic);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set indexing mode.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIndexingMode<ParentT>
    {
        /// <summary>
        /// Specifies indexing mode.
        /// </summary>
        /// <param name="indexingMode">The indexing mode.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIndexingMode(string indexingMode);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set included paths.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIncludedPaths<ParentT>
    {
        /// <summary>
        /// Specifies included path.
        /// </summary>
        /// <param name="includedPaths">The list of the included path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIncludedPaths(IList<IncludedPath> includedPaths);

        /// <summary>
        /// Specifies included path.
        /// </summary>
        /// <param name="includedPath">One of the included path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIncludedPath(IncludedPath includedPath);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set excluded paths.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithExcludedPaths<ParentT>
    {
        /// <summary>
        /// Specifies excluded path.
        /// </summary>
        /// <param name="excludedPaths">The list of the excluded path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithExcludedPaths(IList<ExcludedPath> excludedPaths);

        /// <summary>
        /// Specifies excluded path.
        /// </summary>
        /// <param name="excludedPath">One of the excluded path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithExcludedPath(ExcludedPath excludedPath);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set composite indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCompositeIndexes<ParentT>
    {
        /// <summary>
        /// Specifies composite index.
        /// </summary>
        /// <param name="compositePaths">The list of the composite path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithCompositeIndexes(IList<CompositePath> compositePaths);

        /// <summary>
        /// Specifies composite index.
        /// </summary>
        /// <param name="compositePath">One of the composite path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithCompositeIndex(CompositePath compositePath);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set spatial indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSpatialIndexes<ParentT>
    {
        /// <summary>
        /// Specifies spatial index.
        /// </summary>
        /// <param name="spatialSpecs">The list of the spatial spec.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSpatialIndexes(IList<SpatialSpec> spatialSpecs);

        /// <summary>
        /// Specifies spatial index.
        /// </summary>
        /// <param name="spatialSpec">One of the spatial spec.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSpatialIndex(SpatialSpec spatialSpec);
    }
}
