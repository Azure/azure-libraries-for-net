// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// Defines values for EventHubNamespaceSkuType.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLkV2ZW50SHViTmFtZXNwYWNlU2t1VHlwZQ==
    public partial class EventHubNamespaceSkuType : IHasInner<Sku>
    {
        public static readonly EventHubNamespaceSkuType Basic = new EventHubNamespaceSkuType(SkuName.Basic, SkuTier.Basic);
        public static readonly EventHubNamespaceSkuType Standard = new EventHubNamespaceSkuType(SkuName.Standard, SkuTier.Standard);

        private readonly Sku sku;

        Sku IHasInner<Sku>.Inner => this.Inner();

        /// <summary>
        /// Creates event hub namespace sku.
        /// </summary>
        /// <param name="sku">Inner sku model instance.</param>
        ///GENMHASH:3322F9FA05FC3BF978F4C911A0C6B2C2:016E3E87610C3ACE9D8B84AD2EBB420A
        public EventHubNamespaceSkuType(Sku sku)
        {
            this.sku = sku;
        }

        /// <return>Sku tier.</return>
        ///GENMHASH:F756CBB3F13EF6198269C107AED6F9A2:A44011D5F68E86AC617B996D6E97D9B5
        public SkuTier Tier()
        {
            return this.sku.Tier;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(EventHubNamespaceSkuType lhs, EventHubNamespaceSkuType rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            else
            {
                return lhs.Equals(rhs);
            }
        }

        public static bool operator !=(EventHubNamespaceSkuType lhs, EventHubNamespaceSkuType rhs)
        {
            return !(lhs == rhs);
        }

        public bool Equals(string value)
        {
            if (value == null)
            {
                return null == this.ToString();
            }
            else
            {
                return value.ToLower().Equals(this.ToString().ToLower());
            }
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:FF17376D1DC52D341D64F2CDC53088D2
        public override bool Equals(object obj)
        {
            string value = ToString();
            EventHubNamespaceSkuType rhs = (EventHubNamespaceSkuType)obj;
            if (!(obj is EventHubNamespaceSkuType))
            {
                return false;
            }
            else if (ReferenceEquals(obj, this))
            {
                return true;
            }
            else if (value == null)
            {
                return rhs.ToString() == null;
            }
            else
            {
                return value.Equals(rhs.ToString(), StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <return>Sku tier.</return>
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:BE2A432E51EEBF22D14FCF34FCC5C687
        public SkuName Name()
        {
            return this.sku.Name;
        }

        /// <summary>
        /// Creates event hub namespace sku.
        /// </summary>
        /// <param name="name">Sku name.</param>
        /// <param name="tier">Sku tier.</param>
        ///GENMHASH:CDE5022F600459C09E74303AF1358498:DA9435990EB5B4F9D93F540EB6E44B17
        public  EventHubNamespaceSkuType(SkuName name, SkuTier tier) : this(new Sku()
        {
            Name = name,
            Tier = tier,
            Capacity = null
        })
        {
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:C57C091D12D89058B09B6CC3C47866A9
        public override string ToString()
        {
            return $"{this.sku.Name.ToString()}_{this.sku.Tier.ToString()}";
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:C699A59FDA7C5364E27C9C53AA1537EA
        public Sku Inner()
        {
            return this.sku;
        }

        /// <return>Sku capacity.</return>
        ///GENMHASH:F0B439C5B2A4923B3B36B77503386DA7:DD0B5064CF829CF304917288A88042A7
        public int Capacity()
        {
            if (this.sku.Capacity != null)
            {
                return this.sku.Capacity.Value;
            }
            else
            {
                return 0;
            }
        }
    }
}