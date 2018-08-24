// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImage.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for GalleryImages.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uR2FsbGVyeUltYWdlc0ltcGw=
    internal partial class GalleryImagesImpl  :
        Wrapper<IGalleryImagesOperations>,
        IGalleryImages
    {
        private IComputeManager computeManager;

        ///GENMHASH:3A1EEE0D46163B2BB169EDD0192927A1:96ECD0088A4ADA604D8B34B2EB91EAA4
        internal  GalleryImagesImpl(IComputeManager computeManager) : base(computeManager.Inner.GalleryImages)
        {
            this.computeManager = computeManager;
        }

        ///GENMHASH:DEFBDB096DEECBB96427EF245FBBCFB5:B84D8C5A6C67F036ADFA43B14CFFF21A
        private GalleryImageImpl WrapModel(GalleryImageInner inner)
        {
            return new GalleryImageImpl(inner, this.computeManager);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:52349E059F2469ABB9FD81000DB055F7
        private GalleryImageImpl WrapModel(string name)
        {
            return new GalleryImageImpl(name, this.computeManager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public GalleryImageImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:F4DF88F6A86FD1454052745B4C980EA9:6E01E0C46ADB4BD7E70EE0384766382E
        public void DeleteByGallery(string resourceGroupName, string galleryName, string galleryImageName)
        {
            Extensions.Synchronize(() => this.DeleteByGalleryAsync(resourceGroupName, galleryName, galleryImageName));
        }

        ///GENMHASH:F3D774EE2FA1E468815997A41FC8FE39:59C3BBD5140129084DF92FFE9968F576
        public async Task DeleteByGalleryAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.Inner;
            await client.DeleteAsync(resourceGroupName, galleryName, galleryImageName, cancellationToken);
        }

        ///GENMHASH:ABDD9456266A8CBE8E979EDD5B2C046F:788B7A78330944C05823764DCC963776
        public IGalleryImage GetByGallery(string resourceGroupName, string galleryName, string galleryImageName)
        {
            return Extensions.Synchronize(() => this.GetByGalleryAsync(resourceGroupName, galleryName, galleryImageName));
        }

        ///GENMHASH:A73D04375D3F249B3045C9CEDC2141F3:1648608B9C06972043D4D7D4160CE0CA
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> GetByGalleryAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Inner.GetAsync(resourceGroupName, galleryName, galleryImageName, cancellationToken);
            return WrapModel(inner);
        }

        ///GENMHASH:4345D5A66E1702D97F499A727F578367:916A29CD1FAC599481DE96751E9D5E4E
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> ListByGallery(string resourceGroupName, string galleryName)
        {
            return Extensions.Synchronize(() => this.Inner.ListByGalleryAsync(resourceGroupName, galleryName))
                .AsContinuousCollection(nextLink => Extensions.Synchronize(() => this.Inner.ListByGalleryNextAsync(nextLink)))
                .Select(inner => WrapModel(inner));
        }

        ///GENMHASH:E49B4CBC6C38AEF3FDB262F14D641C70:F18C22CA14F57FA7E28380ABF45215AD
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>> ListByGalleryAsync(string resourceGroupName, string galleryName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IGalleryImage, GalleryImageInner>.LoadPage(cancel => this.Inner.ListByGalleryAsync(resourceGroupName, galleryName, cancel),
                  (nextLink, cancel) => this.Inner.ListByGalleryNextAsync(nextLink, cancellationToken),
                  WrapModel,
                  true,
                  cancellationToken);
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:A537904E18B87B9D0B8AB9A9A0FA714F
        public IComputeManager Manager()
        {
            return this.computeManager;
        }
    }
}