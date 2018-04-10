// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for LoadBalancerSkuType.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuTG9hZEJhbGFuY2VyU2t1VHlwZQ==
    public class LoadBalancerSkuType : ExpandableStringEnum<LoadBalancerSkuType>
    {
        public static readonly LoadBalancerSkuType Basic = Parse(LoadBalancerSkuName.Basic.Value);
        public static readonly LoadBalancerSkuType Standard = Parse(LoadBalancerSkuName.Standard.Value);
    }
}