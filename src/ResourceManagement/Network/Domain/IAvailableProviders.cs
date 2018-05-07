// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of available Internet service providers.
    /// </summary>
    public interface IAvailableProviders  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IAvailableProviders>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.AvailableProvidersListInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>
    {

        /// <summary>
        /// Gets parameters used to query available internet providers.
        /// </summary>
        Models.AvailableProvidersListParameters AvailableProvidersParameters { get; }

        /// <summary>
        /// Gets read-only map of available internet providers, indexed by country.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.AvailableProvidersListCountry> ProvidersByCountry { get; }
    }
}