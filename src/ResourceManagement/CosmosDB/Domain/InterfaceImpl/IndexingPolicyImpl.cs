﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
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
            return this.WithIncludedPath(-1, includedPath);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithExcludedPaths<DefinitionParentT>.WithExcludedPaths(IList<ExcludedPath> excludedPaths)
        {
            return this.WithExcludedPathsAppend(excludedPaths);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithExcludedPaths<DefinitionParentT>.WithExcludedPath(ExcludedPath excludedPath)
        {
            return this.WithExcludedPath(-1, excludedPath);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexes<DefinitionParentT>.WithCompositeIndexes(IList<IList<CompositePath>> compositePaths)
        {
            return this.WithCompositeIndexesAppend(compositePaths);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithCompositeIndexes<DefinitionParentT>.WithCompositeIndex(IList<CompositePath> compositePath)
        {
            return this.WithCompositeIndex(-1, compositePath);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithSpatialIndexes<DefinitionParentT>.WithSpatialIndexes(IList<SpatialSpec> spatialSpecs)
        {
            return this.WithSpatialIndexesAppend(spatialSpecs);
        }

        IndexingPolicy.Definition.IWithAttach<DefinitionParentT> IndexingPolicy.Definition.IWithSpatialIndexes<DefinitionParentT>.WithSpatialIndex(SpatialSpec spatialSpec)
        {
            return this.WithSpatialIndex(-1, spatialSpec);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithAutomatic<UpdateParentT>.WithAutomatic(bool isAutomatic)
        {
            return this.WithAutomatic(isAutomatic);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIndexingMode<UpdateParentT>.WithIndexingMode(IndexingMode indexingMode)
        {
            return this.WithIndexingMode(indexingMode);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIndexingMode<UpdateParentT>.WithoutIndexingMode()
        {
            return this.WithoutIndexingMode();
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithIncludedPathsAppend(IList<IncludedPath> includedPaths)
        {
            return this.WithIncludedPathsAppend(includedPaths);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithIncludedPathsReplace(IList<IncludedPath> includedPaths)
        {
            return this.WithIncludedPathsReplace(includedPaths);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithIncludedPath(int index, IncludedPath includedPath)
        {
            return this.WithIncludedPath(index, includedPath);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithoutIncludedPath(IncludedPath includedPath)
        {
            return this.WithoutIncludedPath(includedPath);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithoutIncludedPath(int index)
        {
            return this.WithoutIncludedPath(index);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithIncludedPaths<UpdateParentT>.WithoutIncludedPaths()
        {
            return this.WithoutIncludedPaths();
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithExcludedPathsAppend(IList<ExcludedPath> excludedPaths)
        {
            return this.WithExcludedPathsAppend(excludedPaths);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithExcludedPathsReplace(IList<ExcludedPath> excludedPaths)
        {
            return this.WithExcludedPathsReplace(excludedPaths);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithExcludedPath(int index, ExcludedPath excludedPath)
        {
            return this.WithExcludedPath(index, excludedPath);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithoutExcludedPath(ExcludedPath excludedPath)
        {
            return this.WithoutExcludedPath(excludedPath);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithoutExcludedPath(int index)
        {
            return this.WithoutExcludedPath(index);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithExcludedPaths<UpdateParentT>.WithoutExcludedPaths()
        {
            return this.WithoutExcludedPaths();
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithCompositeIndexesAppend(IList<IList<CompositePath>> compositePaths)
        {
            return this.WithCompositeIndexesAppend(compositePaths);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithCompositeIndexesReplace(IList<IList<CompositePath>> compositePaths)
        {
            return this.WithCompositeIndexesReplace(compositePaths);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithCompositeIndex(int index, IList<CompositePath> compositePath)
        {
            return this.WithCompositeIndex(index, compositePath);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithoutCompositeIndex(IList<CompositePath> compositePath)
        {
            return this.WithoutCompositeIndex(compositePath);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithoutCompositeIndex(int index)
        {
            return this.WithoutCompositeIndex(index);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithCompositeIndexes<UpdateParentT>.WithoutCompositeIndexes()
        {
            return this.WithoutCompositeIndexes();
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithSpatialIndexesAppend(IList<SpatialSpec> spatialSpecs)
        {
            return this.WithSpatialIndexesAppend(spatialSpecs);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithSpatialIndexesReplace(IList<SpatialSpec> spatialSpecs)
        {
            return this.WithSpatialIndexesReplace(spatialSpecs);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithSpatialIndex(int index, SpatialSpec spatialSpec)
        {
            return this.WithSpatialIndex(index, spatialSpec);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithoutSpatialIndex(int index)
        {
            return this.WithoutSpatialIndex(index);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithoutSpatialIndex(SpatialSpec spatialSpec)
        {
            return this.WithoutSpatialIndex(spatialSpec);
        }

        IndexingPolicy.Update.IUpdate<UpdateParentT> IndexingPolicy.Update.IWithSpatialIndexes<UpdateParentT>.WithoutSpatialIndexes()
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
