// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// Entry point for load balancer management API in Azure.
    /// </summary>
    public interface ILoadBalancerBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets public IP address sku.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.Models.LoadBalancerSkuType Sku { get; }
    }
}