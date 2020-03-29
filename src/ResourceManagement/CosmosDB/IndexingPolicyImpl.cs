// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Linq;

    internal partial class IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> :
        Wrapper<Models.IndexingPolicy>,
        IndexingPolicy.Definition.IDefinition<DefinitionParentT>,
        IndexingPolicy.Update.IUpdate<UpdateParentT>
        where ParentImplT : IParentT, DefinitionParentT, UpdateParentT, IHasIndexingPolicy<ParentImplT>
    {
        private ParentImplT Parent { get; set; }
        public IndexingPolicyImpl(Models.IndexingPolicy inner, ParentImplT parent)
            : base(inner)
        {
            Parent = parent;
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

            foreach (IncludedPath includePath in includedPaths)
            {
                Inner.IncludedPaths.Add(includePath);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithIncludedPathsReplace(IList<IncludedPath> includedPaths)
        {
            Inner.IncludedPaths = new List<IncludedPath>();
            foreach (IncludedPath includedPath in includedPaths)
            {
                Inner.IncludedPaths.Add(includedPath);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithIncludedPath(IncludedPath includedPath)
        {
            if (Inner.IncludedPaths == null)
            {
                Inner.IncludedPaths = new List<IncludedPath>();
            }

            Inner.IncludedPaths.Add(includedPath);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithIncludedPath(string path)
        {
            return this.WithIncludedPath(new IncludedPath(path: path));
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutIncludedPath(string path)
        {
            Inner.IncludedPaths?.Remove(Inner.IncludedPaths?.FirstOrDefault(element => element.Path == path));
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

            foreach (ExcludedPath encludePath in encludedPaths)
            {
                Inner.ExcludedPaths.Add(encludePath);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithExcludedPathsReplace(IList<ExcludedPath> excludedPaths)
        {
            Inner.ExcludedPaths = new List<ExcludedPath>();
            foreach (ExcludedPath excludedPath in excludedPaths)
            {
                Inner.ExcludedPaths.Add(excludedPath);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithExcludedPath(ExcludedPath excludedPath)
        {
            if (Inner.ExcludedPaths == null)
            {
                Inner.ExcludedPaths = new List<ExcludedPath>();
            }

            Inner.ExcludedPaths.Add(excludedPath);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithExcludedPath(string path)
        {
            return this.WithExcludedPath(new ExcludedPath(path: path));
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutExcludedPath(string path)
        {
            Inner.ExcludedPaths?.Remove(Inner.ExcludedPaths?.FirstOrDefault(element => element.Path == path));
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

            foreach (IList<CompositePath> compositePath in compositePaths)
            {
                Inner.CompositeIndexes.Add(compositePath.Select(path => path).ToList());
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithCompositeIndexesReplace(IList<IList<CompositePath>> compositePaths)
        {
            Inner.CompositeIndexes = new List<IList<CompositePath>>();
            foreach (IList<CompositePath> compositePath in compositePaths)
            {
                Inner.CompositeIndexes.Add(compositePath.Select(path => path).ToList());
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithCompositeIndex(IList<CompositePath> compositePath)
        {
            if (Inner.CompositeIndexes == null)
            {
                Inner.CompositeIndexes = new List<IList<CompositePath>>();
            }

            Inner.CompositeIndexes.Add(compositePath.Select(path => path).ToList());
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithNewCompositeIndexList()
        {
            return this.WithCompositeIndex(new List<CompositePath>());
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutCompositeIndexes()
        {
            Inner.CompositeIndexes = null;
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithCompositePath(CompositePath compositePath)
        {
            Inner.CompositeIndexes.Last().Add(compositePath);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithCompositePath(string path, CompositePathSortOrder order)
        {
            return this.WithCompositePath(new CompositePath(path: path, order: order));
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> AttachSelf()
        {
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithSpatialIndexesAppend(IList<SpatialSpec> spatialSpecs)
        {
            if (Inner.SpatialIndexes == null)
            {
                Inner.SpatialIndexes = new List<SpatialSpec>();
            }

            foreach (SpatialSpec spatialSpec in spatialSpecs)
            {
                Inner.SpatialIndexes.Add(spatialSpec);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithSpatialIndexesReplace(IList<SpatialSpec> spatialSpecs)
        {
            Inner.SpatialIndexes = new List<SpatialSpec>();
            foreach (SpatialSpec spatialSpec in spatialSpecs)
            {
                Inner.SpatialIndexes.Add(spatialSpec);
            }
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithSpatialIndex(SpatialSpec spatialSpec)
        {
            if (Inner.SpatialIndexes == null)
            {
                Inner.SpatialIndexes = new List<SpatialSpec>();
            }

            Inner.SpatialIndexes.Add(spatialSpec);
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithSpatialIndex(string path, params SpatialType[] types)
        {
            return this.WithSpatialIndex(new SpatialSpec(path: path, types: new List<SpatialType>(types)));
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutSpatialIndex(string path)
        {
            Inner.SpatialIndexes?.Remove(Inner.SpatialIndexes?.FirstOrDefault(element => element.Path == path));
            return this;
        }

        public IndexingPolicyImpl<ParentImplT, IParentT, DefinitionParentT, UpdateParentT> WithoutSpatialIndexes()
        {
            Inner.SpatialIndexes = null;
            return this;
        }
    }
}
