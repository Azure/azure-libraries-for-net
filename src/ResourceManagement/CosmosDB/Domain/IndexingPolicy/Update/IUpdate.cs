﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Specifies automatic setting.
        /// </summary>
        /// <param name="isAutomatic">The bool about it is automatic or not</param>
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
        /// Specifies indexing mode.
        /// </summary>
        /// <param name="indexingMode">The indexing mode.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithIndexingMode(string indexingMode);


        /// <summary>
        /// Removes indexing mode.
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
        /// Specifies included path.
        /// </summary>
        /// <param name="includedPaths">The list of the included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithIncludedPaths(IList<IncludedPath> includedPaths);

        /// <summary>
        /// Specifies included path.
        /// </summary>
        /// <param name="includedPath">One of the included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithIncludedPath(IncludedPath includedPath);

        /// <summary>
        /// Removes included path.
        /// </summary>
        /// <param name="index">The index of the included path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutIncludedPath(int index);

        /// <summary>
        /// Removes included path.
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
        /// Specifies excluded path.
        /// </summary>
        /// <param name="excludedPaths">The list of the excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithExcludedPaths(IList<ExcludedPath> excludedPaths);

        /// <summary>
        /// Specifies excluded path.
        /// </summary>
        /// <param name="excludedPath">One of the excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithExcludedPath(ExcludedPath excludedPath);

        /// <summary>
        /// Removes excluded path.
        /// </summary>
        /// <param name="index">The index of the excluded path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutExcludedPath(int index);

        /// <summary>
        /// Removes excluded path.
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
        /// Specifies composite index.
        /// </summary>
        /// <param name="compositePaths">The list of the composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithCompositeIndexes(IList<CompositePath> compositePaths);

        /// <summary>
        /// Specifies composite index.
        /// </summary>
        /// <param name="compositePath">One of the composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithCompositeIndex(CompositePath compositePath);

        /// <summary>
        /// Removes composite index.
        /// </summary>
        /// <param name="index">The index of the composite path.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutCompositeIndex(int index);

        /// <summary>
        /// Removes composite index.
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
        /// Specifies spatial index.
        /// </summary>
        /// <param name="spatialSpecs">The list of the spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithSpatialIndexes(IList<SpatialSpec> spatialSpecs);

        /// <summary>
        /// Specifies spatial index.
        /// </summary>
        /// <param name="spatialSpec">One of the spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithSpatialIndex(SpatialSpec spatialSpec);

        /// <summary>
        /// Removes spatial index.
        /// </summary>
        /// <param name="index">The index of the spatial spec.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutSpatialIndex(int index);

        /// <summary>
        /// Removes spatial index.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate<ParentT> WithoutSpatialIndexes();
    }
}
