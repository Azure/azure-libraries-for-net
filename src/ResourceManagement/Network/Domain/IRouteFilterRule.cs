// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// A route filter rule in a route filter group.
    /// </summary>
    public interface IRouteFilterRule :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.RouteFilterRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IRouteFilter>
    {

        /// <summary>
        /// Gets the access type of the rule.
        /// </summary>
        Models.Access Access { get; }

        /// <summary>
        /// Gets The collection for bgp community values to filter on. e.g.
        /// ['12076:5010','12076:5020'].
        /// </summary>
        /// <summary>
        /// Gets collection of community values.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Communities { get; }

        /// <summary>
        /// Gets resource location.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the provisioning state of the resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the rule type of the rule.
        /// </summary>
        string RouteFilterRuleType { get; }
    }
}