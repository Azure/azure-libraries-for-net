// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for GalleryImageVersions.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uR2FsbGVyeUltYWdlVmVyc2lvbnNJbXBs
    internal partial class GalleryImageVersionsImpl  :
        Wrapper<IGalleryImageVersionsOperations>,
        IGalleryImageVersions
    {
        private IComputeManager computeManager;

        ///GENMHASH:A9EEA490CE7645ECD897349803718A52:6EECD5978A14CC16129EEACD18FEAD3D
        internal  GalleryImageVersionsImpl(IComputeManager computeManager) : base(computeManager.Inner.GalleryImageVersions)
        {
            this.computeManager = computeManager;
        }

        ///GENMHASH:2E53F022C7AFDEAE030B319F30E14FD5:62583CDF3565D222285C838C0F28452F
        private GalleryImageVersionImpl WrapModel(GalleryImageVersionInner inner)
        {
            return new GalleryImageVersionImpl(inner, computeManager);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:B9860759153D906DA9AA5F19E3223570
        private GalleryImageVersionImpl WrapModel(string name)
        {
            return new GalleryImageVersionImpl(name, this.computeManager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public GalleryImageVersionImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:10F3CDB954F524438ABCFC56A7D1C6F5:592A61181EFBF32EE4853DACFCD9CDE6
        public void DeleteByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName)
        {
            Extensions.Synchronize(() => this.DeleteByGalleryImageAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName));
        }

        ///GENMHASH:EB870CED68BA346711BD5EDAD2C54C45:9EFADC8CB08932BA1B0B7D3A059E8CDE
        public async Task DeleteByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Inner.DeleteAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName, cancellationToken);
        }

        ///GENMHASH:55E8BB7828F84157131E3353B8C2F1A6:A3135C68AEB9B61CBEED408A114C6ECF
        public IGalleryImageVersion GetByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName)
        {
            return Extensions.Synchronize(() => this.GetByGalleryImageAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName));
        }

        ///GENMHASH:86DA5629FEB54C10E005F23B4AC06853:1CB6596D9B3C89EB31276EB7A45C1C1C
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> GetByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Inner.GetAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName, null, cancellationToken);
            return this.WrapModel(inner);
        }

        ///GENMHASH:AAFAE6839E4A57FC097629B58DC8A17D:F4096503FCB134B36B62B34576508060
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> ListByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName)
        {
            return Extensions.Synchronize(() => this.Inner.ListByGalleryImageAsync(resourceGroupName, galleryName, galleryImageName))
                .AsContinuousCollection(nextLink => Extensions.Synchronize(() => this.Inner.ListByGalleryImageNextAsync(nextLink)))
                .Select(inner => WrapModel(inner));
        }

        ///GENMHASH:6850F4FC22F8DD108AC5AAC3F880BB75:ECA8E93D1C1A32FE048EEA5B2C38138D
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion>> ListByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IGalleryImageVersion, GalleryImageVersionInner>.LoadPage(cancel => this.Inner.ListByGalleryImageAsync(resourceGroupName, galleryName, galleryImageName, cancel),
                  (nextLink, cancel) => this.Inner.ListByGalleryImageNextAsync(nextLink, cancellationToken),
                  WrapModel,
                  true,
                  cancellationToken);
        }

        public IGalleryImageVersion GetByGalleryImageWithReplicationStatus(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName)
        {
            return Extensions.Synchronize(() => this.GetByGalleryImageWithReplicationStatusAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName));
        }

        public async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> GetByGalleryImageWithReplicationStatusAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Inner.GetAsync(resourceGroupName, galleryName, galleryImageName, galleryImageVersionName, ReplicationStatusTypes.ReplicationStatus, cancellationToken);
            return this.WrapModel(inner);
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:A537904E18B87B9D0B8AB9A9A0FA714F
        public IComputeManager Manager()
        {
            return this.computeManager;
        }
    }
}