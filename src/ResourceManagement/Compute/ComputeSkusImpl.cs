// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for  ComputeSkus.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQ29tcHV0ZVNrdXNJbXBs
    internal sealed partial class ComputeSkusImpl :
        ReadableWrappers<Microsoft.Azure.Management.Compute.Fluent.IComputeSku, Microsoft.Azure.Management.Compute.Fluent.ComputeSkuImpl, Models.ResourceSkuInner>,
        IComputeSkus
    {
        private IComputeManager manager;

        IResourceSkusOperations IHasInner<IResourceSkusOperations>.Inner => this.Inner();

        ///GENMHASH:AD27D3B464C617FF7BD739B06405A654:0A321A6C5FAF43B9081469690636C762
        internal ComputeSkusImpl(IComputeManager computeManager)
        {
            this.manager = computeManager;
        }

        ///GENMHASH:4318BDBAE10D86DA6726695F6F266DD0:B4E67A1F603F32204572EE549690656C
        protected override IComputeSku WrapModel(ResourceSkuInner inner)
        {
            return new ComputeSkuImpl(inner);
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IComputeManager Manager()
        {
            return this.manager;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:F5ECE5E9A8B9555D6BF8AC109057562A
        public IResourceSkusOperations Inner()
        {
            return this.manager.Inner.ResourceSkus;
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:11D194372CF16B8AF88A146421D05EAF
        public async Task<IPagedCollection<IComputeSku>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IComputeSku, ResourceSkuInner>.LoadPage(this.ListInnerAsync, this.Inner().ListNextAsync, this.WrapModel, loadAllPages, cancellationToken);
        }

        private async Task<IPage<ResourceSkuInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner().ListAsync(null, cancellationToken);
        }

        ///GENMHASH:2ED29FF482F2137640A1CA66925828A8:E51B3B0303249AFE9CE203C2598B0127
        public Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> ListByRegionAsync(string regionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ListByRegionAsync(Region.Create(regionName), cancellationToken);
        }

        ///GENMHASH:271CC39CE723B6FD3D7CCA7471D4B201:8C5090C004DE7C712DE99F9B8F51B4CA
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> ListByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            var skus = new List<IComputeSku>();
            foreach (var computeSku in await ListAsync(true, cancellationToken))
            {
                if (computeSku.Regions != null && computeSku.Regions.Contains(region))
                {
                    skus.Add(computeSku);
                }
            }
            return PagedCollection<IComputeSku, ResourceSkuInner>.CreateFromEnumerable(skus);
        }


        ///GENMHASH:DA8A5646C9FB008D95AE668C78D2D6E3:6B10CB3C99866C8C031CBDBB0E6EB421
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> ListbyRegionAndResourceTypeAsync(Region region, ComputeResourceType resourceType, CancellationToken cancellationToken = default(CancellationToken))
        {
            var skus = new List<IComputeSku>();
            foreach (var computeSku in await ListAsync(true, cancellationToken))
            {
                if (computeSku.ResourceType != null && computeSku.ResourceType.Equals(resourceType) && computeSku.Regions != null && computeSku.Regions.Contains(region))
                {
                    skus.Add(computeSku);
                }
            }
            return PagedCollection<IComputeSku, ResourceSkuInner>.CreateFromEnumerable(skus);
        }


        ///GENMHASH:D37E1E7B14292953A9F1B5EFCE33BA48:69C6AC5876477147A7C1E8E476E33234
        public async Task<IPagedCollection<Microsoft.Azure.Management.Compute.Fluent.IComputeSku>> ListByResourceTypeAsync(ComputeResourceType resourceType, CancellationToken cancellationToken = default(CancellationToken))
        {
            var skus = new List<IComputeSku>();
            foreach (var computeSku in await ListAsync(true, cancellationToken))
            {
                if (computeSku.ResourceType != null && computeSku.ResourceType.Equals(resourceType))
                {
                    skus.Add(computeSku);
                }
            }
            return PagedCollection<IComputeSku, ResourceSkuInner>.CreateFromEnumerable(skus);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:EFF74B68F06CBC4611C3EEE115E1A032
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> List()
        {
            return Extensions.Synchronize(() => this.ListAsync(true, default(CancellationToken)));
        }

        ///GENMHASH:360BB74037893879A730ED7ED0A3938A:917BB758BFF8E1B644CC01BA7858E692
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> ListByRegion(string regionName)
        {
            return Extensions.Synchronize(() => this.ListByRegionAsync(regionName, default(CancellationToken)));
        }

        ///GENMHASH:BA2FEDDF9D78BF55786D81F6C85E907C:5D47B231876294D1CF4205575C853D8A
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> ListByRegion(Region region)
        {
            return Extensions.Synchronize(() => this.ListByRegionAsync(region, default(CancellationToken)));
        }

        ///GENMHASH:372906835BE693DE5D4A7F12276C3990:5C1835ED29E5F2A90B34F08CE07563A4
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> ListbyRegionAndResourceType(Region region, ComputeResourceType resourceType)
        {
            return Extensions.Synchronize(() => this.ListbyRegionAndResourceTypeAsync(region, resourceType, default(CancellationToken)));
        }

        ///GENMHASH:0429C96B2B559250BBBC61B7966D5BAD:6A56FF83B3B2102411DAE30F95C25A54
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IComputeSku> ListByResourceType(ComputeResourceType resourceType)
        {
            return Extensions.Synchronize(() => this.ListByResourceTypeAsync(resourceType, default(CancellationToken)));
        }
    }
}