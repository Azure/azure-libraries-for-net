// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Gallery.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Gallery.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for Gallery and its create and update interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uR2FsbGVyeUltcGw=
    internal partial class GalleryImpl  :
        GroupableResource<Microsoft.Azure.Management.Compute.Fluent.IGallery,
            Models.GalleryInner,
            Microsoft.Azure.Management.Compute.Fluent.GalleryImpl,
            Microsoft.Azure.Management.Compute.Fluent.IComputeManager, 
            Gallery.Definition.IWithGroup, 
            Gallery.Definition.IWithCreate, 
            Gallery.Definition.IWithCreate, 
            Gallery.Update.IUpdate>,
        IGallery,
        IDefinition,
        IUpdate
    {

        ///GENMHASH:4C297816DBAE1263D05C994CFC8D1928:C5C9A7A1846EEA08D381D40B63B43DC6
        internal  GalleryImpl(string name, GalleryInner innerModel, IComputeManager computeManager) 
            : base(name, innerModel, computeManager)
        {
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        public string Description()
        {
            return this.Inner.Description;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public ProvisioningState ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:07A17FF6E0B36877E5AE5F35F4A21780:5AF374E7E3DC249EA53A40BCB37DA356
        public string UniqueName()
        {
            return this.Inner.Identifier.UniqueName;
        }


        ///GENMHASH:016764F09D1966D691B5DE3A7FD47AC9:5D67BF1D9DA1008F878F13C112FF5F35
        public GalleryImpl WithDescription(string description)
        {
            this.Inner.Description = description;
            return this;
        }

        ///GENMHASH:BB1CC82558B14193A5A9BEEAA39AD490:26089204FBF919DB3A860734DC9174B2
        public IGalleryImage GetImage(string imageName)
        {
            return this.Manager.GalleryImages.GetByGallery(this.ResourceGroupName, this.Name, imageName);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:28C7E2DDF1AF8E0E66353049FE87F488
        protected override async Task<Models.GalleryInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.Manager.Inner.Galleries;
            return await client.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:523D3A51C551EB1AA54A174D5087EF63
        public async override Task<IGallery> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var galleryInner = await Manager.Inner.Galleries.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
            SetInner(galleryInner);
            return this;
        }

        ///GENMHASH:53C5326A96805851579A861BAA315694:20E793DA2931A94A780043403389CAE6
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> GetImageAsync(string imageName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.GalleryImages.GetByGalleryAsync(this.ResourceGroupName, this.Name, imageName, cancellationToken);
        }

        ///GENMHASH:DAC3F56608814B99BD7BDC91F5D5DC28:98D4F325B07679EBBB42B521BFE94119
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage> ListImages()
        {
            return this.Manager.GalleryImages.ListByGallery(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:C9EE1B32D7F72680B29C1B8F3E2216D7:CCA078D6E68AFC9EC4349D75FFE4D7AA
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IGalleryImage>> ListImagesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.GalleryImages.ListByGalleryAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }
    }
}