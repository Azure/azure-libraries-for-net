// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;

    internal partial class IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT>
    {
        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithAutomatic<DefinitionParentT>.WithAutomatic(bool isAutomatic)
        {
            return this.WithAutomatic(isAutomatic);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithIndexingMode<DefinitionParentT>.WithIndexingMode(IndexingMode indexingMode)
        {
            return this.WithIndexingMode(indexingMode);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithIncludedPaths<DefinitionParentT>.WithIncludedPaths(IList<IncludedPath> includedPaths)
        {
            return this.WithIncludedPathsAppend(includedPaths);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithIncludedPaths<DefinitionParentT>.WithIncludedPath(IncludedPath includedPath)
        {
            return this.WithIncludedPath(includedPath);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithIncludedPaths<DefinitionParentT>.WithIncludedPath(string path)
        {
            return this.WithIncludedPath(path);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithExcludedPaths<DefinitionParentT>.WithExcludedPaths(IList<ExcludedPath> excludedPaths)
        {
            return this.WithExcludedPathsAppend(excludedPaths);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithExcludedPaths<DefinitionParentT>.WithExcludedPath(ExcludedPath excludedPath)
        {
            return this.WithExcludedPath(excludedPath);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithExcludedPaths<DefinitionParentT>.WithExcludedPath(string path)
        {
            return this.WithExcludedPath(path);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexes<DefinitionParentT>.WithCompositeIndexes(IList<IList<CompositePath>> compositePaths)
        {
            return this.WithCompositeIndexesAppend(compositePaths);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexes<DefinitionParentT>.WithCompositeIndex(IList<CompositePath> compositePath)
        {
            return this.WithCompositeIndex(compositePath);
        }

        IndexingPolicy.Definition.IWithCompositeIndexList<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexes<DefinitionParentT>.WithNewCompositeIndexList()
        {
            return this.WithNewCompositeIndexList();
        }

        IndexingPolicy.Definition.IWithCompositeIndexList<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexList<DefinitionParentT>.WithCompositePath(CompositePath compositePath)
        {
            return this.WithCompositePath(compositePath);
        }

        IndexingPolicy.Definition.IWithCompositeIndexList<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexList<DefinitionParentT>.WithCompositePath(string path, CompositePathSortOrder order)
        {
            return this.WithCompositePath(path, order);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexList<DefinitionParentT>.Attach()
        {
            return this.AttachSelf();
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithSpatialIndexes<DefinitionParentT>.WithSpatialIndexes(IList<SpatialSpec> spatialSpecs)
        {
            return this.WithSpatialIndexesAppend(spatialSpecs);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithSpatialIndexes<DefinitionParentT>.WithSpatialIndex(SpatialSpec spatialSpec)
        {
            return this.WithSpatialIndex(spatialSpec);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithSpatialIndexes<DefinitionParentT>.WithSpatialIndex(string path, params SpatialType[] types)
        {
            return this.WithSpatialIndex(path, types);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithAutomatic<UpdateParentT>.WithAutomatic(bool isAutomatic)
        {
            return this.WithAutomatic(isAutomatic);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIndexingMode<UpdateParentT>.WithIndexingMode(IndexingMode indexingMode)
        {
            return this.WithIndexingMode(indexingMode);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIndexingMode<UpdateParentT>.WithoutIndexingMode()
        {
            return this.WithoutIndexingMode();
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithIncludedPathsAppend(IList<IncludedPath> includedPaths)
        {
            return this.WithIncludedPathsAppend(includedPaths);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithIncludedPathsReplace(IList<IncludedPath> includedPaths)
        {
            return this.WithIncludedPathsReplace(includedPaths);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithIncludedPath(IncludedPath includedPath)
        {
            return this.WithIncludedPath(includedPath);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithIncludedPath(string path)
        {
            return this.WithIncludedPath(path);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithoutIncludedPath(string path)
        {
            return this.WithoutIncludedPath(path);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithoutIncludedPaths()
        {
            return this.WithoutIncludedPaths();
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithExcludedPathsAppend(IList<ExcludedPath> excludedPaths)
        {
            return this.WithExcludedPathsAppend(excludedPaths);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithExcludedPathsReplace(IList<ExcludedPath> excludedPaths)
        {
            return this.WithExcludedPathsReplace(excludedPaths);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithExcludedPath(ExcludedPath excludedPath)
        {
            return this.WithExcludedPath(excludedPath);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithExcludedPath(string path)
        {
            return this.WithExcludedPath(path);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithoutExcludedPath(string path)
        {
            return this.WithoutExcludedPath(path);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithoutExcludedPaths()
        {
            return this.WithoutExcludedPaths();
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithCompositeIndexesAppend(IList<IList<CompositePath>> compositePaths)
        {
            return this.WithCompositeIndexesAppend(compositePaths);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithCompositeIndexesReplace(IList<IList<CompositePath>> compositePaths)
        {
            return this.WithCompositeIndexesReplace(compositePaths);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithCompositeIndex(IList<CompositePath> compositePath)
        {
            return this.WithCompositeIndex(compositePath);
        }

        IndexingPolicy.Update.IWithCompositeIndexList<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithNewCompositeIndexList()
        {
            return this.WithNewCompositeIndexList();
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithoutCompositeIndexes()
        {
            return this.WithoutCompositeIndexes();
        }

        IndexingPolicy.Update.IWithCompositeIndexList<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexList<UpdateParentT>.WithCompositePath(CompositePath compositePath)
        {
            return this.WithCompositePath(compositePath);
        }

        IndexingPolicy.Update.IWithCompositeIndexList<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexList<UpdateParentT>.WithCompositePath(string path, CompositePathSortOrder order)
        {
            return this.WithCompositePath(path, order);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexList<UpdateParentT>.Attach()
        {
            return this.AttachSelf();
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithSpatialIndexesAppend(IList<SpatialSpec> spatialSpecs)
        {
            return this.WithSpatialIndexesAppend(spatialSpecs);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithSpatialIndexesReplace(IList<SpatialSpec> spatialSpecs)
        {
            return this.WithSpatialIndexesReplace(spatialSpecs);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithSpatialIndex(SpatialSpec spatialSpec)
        {
            return this.WithSpatialIndex(spatialSpec);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithSpatialIndex(string path, params SpatialType[] types)
        {
            return this.WithSpatialIndex(path, types);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithoutSpatialIndex(string path)
        {
            return this.WithoutSpatialIndex(path);
        }

        IndexingPolicy.Update.IWithAttach<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithoutSpatialIndexes()
        {
            return this.WithoutSpatialIndexes();
        }

        DefinitionParentT ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<DefinitionParentT>.Attach()
        {
            return this.Attach();
        }

        UpdateParentT ResourceManager.Fluent.Core.ChildResourceActions.ISettable<UpdateParentT>.Parent()
        {
            return this.Attach();
        }
    }
}
