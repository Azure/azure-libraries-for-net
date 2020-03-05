// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.IndexingPolicy.Definition
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of an indexing policy definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithCompositeIndexList<ParentT>,
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
        /// Specifies the automatic setting.
        /// </summary>
        /// <param name="isAutomatic">Whether index automatically or not.</param>
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
        /// Specifies the indexing mode.
        /// </summary>
        /// <param name="indexingMode">The indexing mode.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIndexingMode(IndexingMode indexingMode);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set included paths.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIncludedPaths<ParentT>
    {
        /// <summary>
        /// Specifies the included paths.
        /// </summary>
        /// <param name="includedPaths">The list of the included path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIncludedPaths(IList<IncludedPath> includedPaths);

        /// <summary>
        /// Specifies an included path.
        /// </summary>
        /// <param name="includedPath">One of the included path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIncludedPath(IncludedPath includedPath);

        /// <summary>
        /// Specifies an included path.
        /// </summary>
        /// <param name="path">One of the included path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIncludedPath(string path);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set excluded paths.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithExcludedPaths<ParentT>
    {
        /// <summary>
        /// Specifies the excluded paths.
        /// </summary>
        /// <param name="excludedPaths">The list of the excluded path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithExcludedPaths(IList<ExcludedPath> excludedPaths);

        /// <summary>
        /// Specifies an excluded path.
        /// </summary>
        /// <param name="excludedPath">One of the excluded path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithExcludedPath(ExcludedPath excludedPath);

        /// <summary>
        /// Specifies an excluded path.
        /// </summary>
        /// <param name="path">One of the excluded path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithExcludedPath(string path);
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set composite indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCompositeIndexes<ParentT>
    {
        /// <summary>
        /// Specifies the composite indexes.
        /// </summary>
        /// <param name="compositePaths">The list of the composite path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithCompositeIndexes(IList<IList<CompositePath>> compositePaths);

        /// <summary>
        /// Specifies a composite index.
        /// </summary>
        /// <param name="compositePath">One of the composite path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithCompositeIndex(IList<CompositePath> compositePath);

        /// <summary>
        /// Specifies a composite index empty list to set every composite path.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        IWithCompositeIndexList<ParentT> WithNewCompositeIndexList();
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set one list of composite indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithCompositeIndexList<ParentT>
    {
        /// <summary>
        /// Specifies a composite path attach to the last list.
        /// </summary>
        /// <param name="compositePath">The composite path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithCompositeIndexList<ParentT> WithCompositePath(CompositePath compositePath);

        /// <summary>
        /// Specifies a composite path attach to the last list.
        /// </summary>
        /// <param name="path">The path of the composite path.</param>
        /// <param name="order">The order of the composite path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithCompositeIndexList<ParentT> WithCompositePath(string path, CompositePathSortOrder order);

        /// <summary>
        /// Attaches the last list of the composite index.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> Attach();
    }

    /// <summary>
    /// The stage of the indexing policy definition allowing to set spatial indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSpatialIndexes<ParentT>
    {
        /// <summary>
        /// Specifies the spatial indexes.
        /// </summary>
        /// <param name="spatialSpecs">The list of the spatial spec.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSpatialIndexes(IList<SpatialSpec> spatialSpecs);

        /// <summary>
        /// Specifies a spatial index.
        /// </summary>
        /// <param name="spatialSpec">One of the spatial spec.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSpatialIndex(SpatialSpec spatialSpec);

        /// <summary>
        /// Specifies a spatial index.
        /// </summary>
        /// <param name="path">The path of the spatial index.</param>
        /// <param name="types">The types of the spatial index.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSpatialIndex(string path, params SpatialType[] types);
    }
}
