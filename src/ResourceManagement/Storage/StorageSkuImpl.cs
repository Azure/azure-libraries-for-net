// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The implementation for  StorageSku.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uU3RvcmFnZVNrdUltcGw=
    internal partial class StorageSkuImpl : IStorageSku
    {
        private SkuInner inner;

        SkuInner IHasInner<SkuInner>.Inner => inner;

        ///GENMHASH:2DA3D402EF2F4EF1A5D6599913EC4354:65E408C71959AFC55032CE444A61E039
        internal StorageSkuImpl(SkuInner inner)
        {
            this.inner = inner;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:8CC68A07507378BC8AFC6AE910E81D29
        public SkuName Name()
        {
            return this.inner.Name;
        }

        ///GENMHASH:F756CBB3F13EF6198269C107AED6F9A2:9283ED24F5985AB5BC32623F8CD41709
        public SkuTier? Tier()
        {
            return this.inner.Tier;
        }


        ///GENMHASH:EC2A5EE0E9C0A186CA88677B91632991:77A70E2E33FFD6C176C2F31375AF3701
        public StorageResourceType ResourceType()
        {
            if (this.inner.ResourceType != null)
            {
                return StorageResourceType.Parse(this.inner.ResourceType);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:59C1E25F0E77F718395079384661872B:B562BFB1C5ECFEB2DC2005E876CE0263
        public IReadOnlyList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> Regions()
        {
            if (this.inner.Locations != null)
            {
                return this.inner.Locations.Select(location => Region.Create(location)).ToList();
            }
            else
            {
                return (new List<Region>());
            }
        }

        ///GENMHASH:35EB1A31F5F9EE9C1A764577CD186B0D:6040E8BFBA5231929521B137F79766B4
        public IReadOnlyList<Models.SKUCapability> Capabilities()
        {
            if (this.inner.Capabilities != null)
            {
                return new List<Models.SKUCapability>(this.inner.Capabilities);
            }
            else
            {
                return (new List<Models.SKUCapability>());
            }
        }

        ///GENMHASH:2AE8A9F45F1B5A337F363BAAC701B2FA:92979B49D69FB5877658254B7583522F
        public IReadOnlyList<Models.Restriction> Restrictions()
        {
            if (this.inner.Restrictions != null)
            {
                return new List<Models.Restriction>(this.inner.Restrictions);
            }
            else
            {
                return (new List<Models.Restriction>());
            }
        }

        ///GENMHASH:8C1B9B2F559CCE4EE634D1CC6864C337:367E3FD4936A3BAE5AE4EDC28C03E765
        public Kind? StorageAccountKind()
        {
            return this.inner.Kind;
        }

        ///GENMHASH:2F282EC0DA736D13451891CCE3AD259A:062EF7F3A9AFA7EA30A19B31F8DFF818
        public StorageAccountSkuType StorageAccountSku()
        {
            if (this.ResourceType() != null && this.ResourceType().Equals(StorageResourceType.Storage_Accounts))
            {
                return StorageAccountSkuType.FromSkuName(this.inner.Name);
            }
            return null;
        }
    }
}