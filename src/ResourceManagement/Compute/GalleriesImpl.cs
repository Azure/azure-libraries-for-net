// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for Galleries.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uR2FsbGVyaWVzSW1wbA==
    internal partial class GalleriesImpl :
        TopLevelModifiableResources<IGallery,
            GalleryImpl,
            GalleryInner,
            IGalleriesOperations,
            IComputeManager>,
        IGalleries
    {

        ///GENMHASH:BD9D1744BDC1BBB38BBC62335D0CE8A1:97195F31010522B07E5337CCA10E5406
        internal  GalleriesImpl(IComputeManager computeManager) : base(computeManager.Inner.Galleries, computeManager)
        {
        }

        ///GENMHASH:93159F747E6DEB28F8C458E1A8FE933B:A891B9AE7233EAFD68E6DE91B73CDBBD
        protected override IGallery WrapModel(GalleryInner inner)
        {
            return new GalleryImpl(inner.Name, inner, Manager);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:CCBF53F8A04698BF7FD1BA6028E2EB80
        protected override GalleryImpl WrapModel(string name)
        {
            return new GalleryImpl(name, new GalleryInner(), Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:7234FBCA378CC2C494D18F64728B66B6
        protected async override Task DeleteInnerByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(resourceGroupName, name, cancellationToken);
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:69D3BEE424937CDC1E752988A9DF7AEA
        protected async override Task<GalleryInner> GetInnerByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(resourceGroupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        protected async override Task<IPage<GalleryInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<GalleryInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:F27988875BD81EE531DA23D26C675612
        protected async override Task<IPage<GalleryInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<GalleryInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }
    }
}