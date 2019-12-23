// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.IndexingPolicy.Update
{
    /// <summary>
    /// The entirety of an indexing policy update as a part of parent update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IUpdate<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<ParentT>,
        IWithAutomatic<ParentT>,
        IWithIndexingMode<ParentT>,
        IWithIncludedPaths<ParentT>,
        IWithExcludedPaths<ParentT>,
        IWithCompositeIndexes<ParentT>,
        IWithSpatialIndexes<ParentT>
    {
    }

    /// <summary>
    /// The stage of the indexing policy update allowing to set automatic setting.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithAutomatic<ParentT>
    {
        /// <summary>
        /// Specifies the automatic setting.
        /// </summary>
        /// <param name="isAutomatic">Whether index automatically or not.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithAutomatic(bool isAutomatic);
    }

    /// <summary>
    /// The stage of the indexing policy update allowing to set indexing mode.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithIndexingMode<ParentT>
    {
        /// <summary>
        /// Specifies the indexing mode.
        /// </summary>
        /// <param name="indexingMode">The indexing mode.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithIndexingMode(IndexingMode indexingMode);


        /// <summary>
        /// Removes the indexing mode.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutIndexingMode();
    }

    /// <summary>
    /// The stage of the indexing policy update allowing to set included paths.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithIncludedPaths<ParentT>
    {
        /// <summary>
        /// Appends included paths.
        /// </summary>
        /// <param name="includedPaths">The list of the included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithIncludedPathsAppend(IList<IncludedPath> includedPaths);

        /// <summary>
        /// Replaces the included paths.
        /// </summary>
        /// <param name="includedPaths">The list of the included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithIncludedPathsReplace(IList<IncludedPath> includedPaths);

        /// <summary>
        /// Specifies an included path.
        /// </summary>
        /// <param name="index">The specific index, append to list when index is out of range.</param>
        /// <param name="includedPath">One of the included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithIncludedPath(int index, IncludedPath includedPath);

        /// <summary>
        /// Removes an included path.
        /// </summary>
        /// <param name="index">The index of the included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutIncludedPath(int index);

        /// <summary>
        /// Removes an included path.
        /// </summary>
        /// <param name="includedPath">The included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutIncludedPath(IncludedPath includedPath);

        /// <summary>
        /// Removes all included paths.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutIncludedPaths();
    }

    /// <summary>
    /// The stage of the indexing policy update allowing to set excluded paths.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithExcludedPaths<ParentT>
    {
        /// <summary>
        /// Appends excluded paths.
        /// </summary>
        /// <param name="excludedPaths">The list of the excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithExcludedPathsAppend(IList<ExcludedPath> excludedPaths);

        /// <summary>
        /// Replaces the excluded paths.
        /// </summary>
        /// <param name="excludedPaths">The list of the excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithExcludedPathsReplace(IList<ExcludedPath> excludedPaths);

        /// <summary>
        /// Specifies an excluded path.
        /// </summary>
        /// <param name="index">The specific index, append to list when index is out of range.</param>
        /// <param name="excludedPath">One of the excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithExcludedPath(int index, ExcludedPath excludedPath);

        /// <summary>
        /// Removes an excluded path.
        /// </summary>
        /// <param name="index">The index of the excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutExcludedPath(int index);

        /// <summary>
        /// Removes an excluded path.
        /// </summary>
        /// <param name="excludedPath">The excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutExcludedPath(ExcludedPath excludedPath);

        /// <summary>
        /// Removes all excluded paths.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutExcludedPaths();
    }

    /// <summary>
    /// The stage of the indexing policy update allowing to set composite indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithCompositeIndexes<ParentT>
    {
        /// <summary>
        /// Appends composite indexes.
        /// </summary>
        /// <param name="compositePaths">The list of the composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithCompositeIndexesAppend(IList<IList<CompositePath>> compositePaths);

        /// <summary>
        /// Replaces the composite indexes.
        /// </summary>
        /// <param name="compositePaths">The list of the composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithCompositeIndexesReplace(IList<IList<CompositePath>> compositePaths);

        /// <summary>
        /// Specifies a composite index.
        /// </summary>
        /// <param name="index">The specific index, append to list when index is out of range.</param>
        /// <param name="compositePath">One of the composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithCompositeIndex(int index, IList<CompositePath> compositePath);

        /// <summary>
        /// Removes a composite index.
        /// </summary>
        /// <param name="index">The index of the composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutCompositeIndex(int index);

        /// <summary>
        /// Removes a composite index.
        /// </summary>
        /// <param name="compositePath">The composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutCompositeIndex(IList<CompositePath> compositePath);

        /// <summary>
        /// Removes all composite indexes.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutCompositeIndexes();
    }

    /// <summary>
    /// The stage of the indexing policy update allowing to set spatial indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent update to return to after attaching this update.</typeparam>
    public interface IWithSpatialIndexes<ParentT>
    {
        /// <summary>
        /// Appends spatial indexes.
        /// </summary>
        /// <param name="spatialSpecs">The list of the spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithSpatialIndexesAppend(IList<SpatialSpec> spatialSpecs);

        /// <summary>
        /// Replaces the spatial indexes.
        /// </summary>
        /// <param name="spatialSpecs">The list of the spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithSpatialIndexesReplace(IList<SpatialSpec> spatialSpecs);

        /// <summary>
        /// Specifies a spatial index.
        /// </summary>
        /// <param name="index">The specific index, append to list when index is out of range.</param>
        /// <param name="spatialSpec">One of the spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithSpatialIndex(int index, SpatialSpec spatialSpec);

        /// <summary>
        /// Removes a spatial index.
        /// </summary>
        /// <param name="index">The index of the spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutSpatialIndex(int index);

        /// <summary>
        /// Removes a spatial index.
        /// </summary>
        /// <param name="spatialSpec">The spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutSpatialIndex(SpatialSpec spatialSpec);

        /// <summary>
        /// Removes all spatial indexes.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutSpatialIndexes();
    }
}
