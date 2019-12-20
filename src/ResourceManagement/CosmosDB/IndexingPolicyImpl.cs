// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{

    internal partial class IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> :
        ChildResource<Models.IndexingPolicy, ParentImplT, IParentT>,
        IndexingPolicy.Definition.IDefinition<DefinitionParentT>,
        IndexingPolicy.Update.IUpdate<UpdateParentT>
        where ParentImplT : IParentT, DefinitionParentT, UpdateParentT, IHasIndexingPolicy<ParentImplT>
    {
        public IndexingPolicyImpl(Models.IndexingPolicy inner, ParentImplT parent)
            : base(inner, parent)
        {
        }

        public override string Name()
        {
            return null;
        }

        public ParentImplT Attach()
        {
            return this.Parent.WithIndexingPolicy(this.Inner);
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithAutomatic(bool isAutomatic)
        {
            Inner.Automatic = isAutomatic;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithIndexingMode(IndexingMode indexingMode)
        {
            Inner.IndexingMode = indexingMode;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutIndexingMode()
        {
            Inner.IndexingMode = null;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithIncludedPathsAppend(IList<IncludedPath> includedPaths)
        {
            if (Inner.IncludedPaths == null)
            {
                Inner.IncludedPaths = new List<IncludedPath>();
            }

            foreach (var includePath in includedPaths)
            {
                Inner.IncludedPaths.Add(includePath);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithIncludedPathsReplace(IList<IncludedPath> includedPaths)
        {
            Inner.IncludedPaths = includedPaths;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithIncludedPath(int index, IncludedPath includedPath)
        {
            if (Inner.IncludedPaths == null)
            {
                Inner.IncludedPaths = new List<IncludedPath>();
            }

            if (index < 0 || Inner.IncludedPaths.Count <= index)
            {
                Inner.IncludedPaths.Add(includedPath);
            }
            else
            {
                Inner.IncludedPaths[index] = includedPath;
            }

            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutIncludedPath(int index)
        {
            Inner.IncludedPaths.RemoveAt(index);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutIncludedPath(IncludedPath includedPath)
        {
            Inner.IncludedPaths.Remove(includedPath);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutIncludedPaths()
        {
            Inner.IncludedPaths = null;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithExcludedPathsAppend(IList<ExcludedPath> encludedPaths)
        {
            if (Inner.ExcludedPaths == null)
            {
                Inner.ExcludedPaths = new List<ExcludedPath>();
            }

            foreach (var encludePath in encludedPaths)
            {
                Inner.ExcludedPaths.Add(encludePath);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithExcludedPathsReplace(IList<ExcludedPath> excludedPaths)
        {
            Inner.ExcludedPaths = excludedPaths;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithExcludedPath(int index, ExcludedPath excludedPath)
        {
            if (Inner.ExcludedPaths == null)
            {
                Inner.ExcludedPaths = new List<ExcludedPath>();
            }

            if (index < 0 || Inner.ExcludedPaths.Count <= index)
            {
                Inner.ExcludedPaths.Add(excludedPath);
            }
            else
            {
                Inner.ExcludedPaths[index] = excludedPath;
            }

            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutExcludedPath(int index)
        {
            Inner.ExcludedPaths.RemoveAt(index);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutExcludedPath(ExcludedPath excludedPath)
        {
            Inner.ExcludedPaths.Remove(excludedPath);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutExcludedPaths()
        {
            Inner.ExcludedPaths = null;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithCompositeIndexesAppend(IList<IList<CompositePath>> compositePaths)
        {
            if (Inner.CompositeIndexes == null)
            {
                Inner.CompositeIndexes = new List<IList<CompositePath>>();
            }

            foreach (var compositePath in compositePaths)
            {
                Inner.CompositeIndexes.Add(compositePath);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithCompositeIndexesReplace(IList<IList<CompositePath>> compositePaths)
        {
            Inner.CompositeIndexes = compositePaths;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithCompositeIndex(int index, IList<CompositePath> compositePath)
        {
            if (Inner.CompositeIndexes == null)
            {
                Inner.CompositeIndexes = new List<IList<CompositePath>>();
            }

            if (index < 0 || Inner.CompositeIndexes.Count <= index)
            {
                Inner.CompositeIndexes.Add(compositePath);
            }
            else
            {
                Inner.CompositeIndexes[index] = compositePath;
            }

            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutCompositeIndex(int index)
        {
            Inner.CompositeIndexes.RemoveAt(index);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutCompositeIndex(IList<CompositePath> compositePath)
        {
            Inner.CompositeIndexes.Remove(compositePath);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutCompositeIndexes()
        {
            Inner.CompositeIndexes = null;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithSpatialIndexesAppend(IList<SpatialSpec> spatialSpecs)
        {
            if (Inner.SpatialIndexes == null)
            {
                Inner.SpatialIndexes = new List<SpatialSpec>();
            }

            foreach (var spatialSpec in spatialSpecs)
            {
                Inner.SpatialIndexes.Add(spatialSpec);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithSpatialIndexesReplace(IList<SpatialSpec> spatialSpecs)
        {
            Inner.SpatialIndexes = spatialSpecs;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithSpatialIndex(int index, SpatialSpec spatialSpec)
        {
            if (Inner.SpatialIndexes == null)
            {
                Inner.SpatialIndexes = new List<SpatialSpec>();
            }

            if (index < 0 || Inner.SpatialIndexes.Count <= index)
            {
                Inner.SpatialIndexes.Add(spatialSpec);
            }
            else
            {
                Inner.SpatialIndexes[index] = spatialSpec;
            }

            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutSpatialIndex(int index)
        {
            Inner.SpatialIndexes.RemoveAt(index);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutSpatialIndex(SpatialSpec spatialSpec)
        {
            Inner.SpatialIndexes.Remove(spatialSpec);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutSpatialIndexes()
        {
            Inner.SpatialIndexes = null;
            return this;
        }
    }
}
