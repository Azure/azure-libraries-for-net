// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for PublicIPSkuType.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuUHVibGljSVBTa3VUeXBl
    public class PublicIPSkuType : ExpandableStringEnum<PublicIPSkuType>
    {
        public static readonly PublicIPSkuType Basic = Parse(PublicIPAddressSkuName.Basic.Value);
        public static readonly PublicIPSkuType Standard = Parse(PublicIPAddressSkuName.Standard.Value);
    }
}