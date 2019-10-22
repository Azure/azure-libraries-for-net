// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Express route circuit sku type.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuRXhwcmVzc1JvdXRlQ2lyY3VpdFNrdVR5cGU=
    public partial class ExpressRouteCircuitSkuType
    {
        private static IDictionary<string, ExpressRouteCircuitSkuType> ValuesByName;
        /** Static value for Standard sku tier and MeteredData sku family. */
        public static readonly ExpressRouteCircuitSkuType StandardMeteredData = new ExpressRouteCircuitSkuType(ExpressRouteCircuitSkuTier.Standard, ExpressRouteCircuitSkuFamily.MeteredData);
        /** Static value for Standard sku tier and UnlimitedData sku family. */
        public static readonly ExpressRouteCircuitSkuType StandardUnlimitedData = new ExpressRouteCircuitSkuType(ExpressRouteCircuitSkuTier.Standard, ExpressRouteCircuitSkuFamily.UnlimitedData);
        /** Static value for Premium sku tier and MeteredData sku family. */
        public static readonly ExpressRouteCircuitSkuType PremiumMeteredData = new ExpressRouteCircuitSkuType(ExpressRouteCircuitSkuTier.Premium, ExpressRouteCircuitSkuFamily.MeteredData);
        /** Static value for Premium sku tier and UnlimitedData sku family. */
        public static readonly ExpressRouteCircuitSkuType PremiumUnlimitedData = new ExpressRouteCircuitSkuType(ExpressRouteCircuitSkuTier.Premium, ExpressRouteCircuitSkuFamily.UnlimitedData);
        private ExpressRouteCircuitSku sku;
        private string value;
        /// <summary>
        /// Searches for an SKU type and creates a new Express Route circuit SKU type instance if not found among the existing ones.
        /// </summary>
        /// <param name="sku">An Express Route circuit SKU.</param>
        /// <return>The parsed or created Express Route circuit SKU type.</return>
        ///GENMHASH:38408DF1B8F232AEBED1B12F2C1202F0:027E47FEFAA31D61D917E0DD4AC48C00
        public static ExpressRouteCircuitSkuType FromSku(ExpressRouteCircuitSku sku)
        {
            if (sku == null)
            {
                return null;
            }
            String nameToLookFor = sku.Name;
            ExpressRouteCircuitSkuType result; if (ValuesByName == null)
            {
                return new ExpressRouteCircuitSkuType(sku);
            }
            else if (ValuesByName.TryGetValue(nameToLookFor.ToLower(), out result))
            {
                return result;
            }
            else
            {
                return new ExpressRouteCircuitSkuType(sku);
            }
        }

        /// <summary>
        /// Creates a copy of the given sku.
        /// </summary>
        /// <param name="sku">The sku to create copy of.</param>
        /// <return>The copy.</return>
        ///GENMHASH:6814A8EC14C83C183FB49EDF6AE3F872:B3778201CB03DCFF865B01FE490DDFBE
        private static ExpressRouteCircuitSku CreateCopy(ExpressRouteCircuitSku sku)
        {
            return new ExpressRouteCircuitSku()
            {
                Name = sku.Name,
                Tier = sku.Tier,
                Family = sku.Family
            };
        }

        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7E40CAD8AD46FC64A58AAA73BDA0A301
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <return>Predefined Express Route circuit SKU types.</return>
        ///GENMHASH:B6EAF7CA43219B097DF06B50881D6E8F:BC01661680F72D14A4F65843C810D3F9
        public IEnumerable<ExpressRouteCircuitSkuType> Values
        {
            get
            {
                return (ValuesByName != null) ? ValuesByName.Values : null;
            }
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:4E26040AFD9869C516B029A3057AAE99
        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is ExpressRouteCircuitSkuType))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            ExpressRouteCircuitSkuType anotherSkuType = (ExpressRouteCircuitSkuType)obj;
            if (value == null)
            {
                return anotherSkuType.value == null;
            }
            return value.Equals(anotherSkuType.value);
        }

        /// <summary>
        /// Creates a custom value for ExpressRouteCircuitSkuType.
        /// </summary>
        /// <param name="skuTier">A SKU tier.</param>
        /// <param name="skuFamily">An SKU family.</param>
        ///GENMHASH:1C1AC2081EDF467E58696D79BFED26DF:7E16A0307E12AFD2D0B6FA7988E995EB
        public ExpressRouteCircuitSkuType(ExpressRouteCircuitSkuTier skuTier, ExpressRouteCircuitSkuFamily skuFamily) : this(new ExpressRouteCircuitSku(skuTier + "_" + skuFamily, skuTier, skuFamily))
        {
        }

        /// <summary>
        /// Creates a custom value for ExpressRouteCircuitSkuType.
        /// </summary>
        /// <param name="sku">The SKU.</param>
        ///GENMHASH:0762E3C06783B20D994901ACEEE8FBA2:A0902CB87BB5668B63DA725DD104430C
        public ExpressRouteCircuitSkuType(ExpressRouteCircuitSku sku)
        {
            // Store Sku copy since original user provided sku can be modified
            // by the user.

            this.sku = CreateCopy(sku);
            value = sku.Tier + "_" + sku.Family;
            if (ValuesByName == null)
            {
                ValuesByName = new Dictionary<string, ExpressRouteCircuitSkuType>();
            }
            ValuesByName[value.ToLower()] = this;
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:2C26F6EDF15B8D7739B8CA1E43BCDCEA
        public override string ToString()
        {
            return value;
        }

        /// <return>The SKU.</return>
        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:F4AEB2881DC7C83DE6A798AD971FA6CA
        public ExpressRouteCircuitSku Sku()
        {
            // Return copy of sku to guard ExpressRouteCircuitSkuType from ending up with invalid
            // sku in case consumer changes the returned Sku instance.
            return CreateCopy(this.sku);
        }
    }
}