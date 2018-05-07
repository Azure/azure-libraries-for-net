// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class AvailableProvidersImpl 
    {
        /// <summary>
        /// Gets parameters used to query available internet providers.
        /// </summary>
        Models.AvailableProvidersListParameters Microsoft.Azure.Management.Network.Fluent.IAvailableProviders.AvailableProvidersParameters
        {
            get
            {
                return this.AvailableProvidersParameters();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkWatcher Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Gets read-only map of available internet providers, indexed by country.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.AvailableProvidersListCountry> Microsoft.Azure.Management.Network.Fluent.IAvailableProviders.ProvidersByCountry
        {
            get
            {
                return this.ProvidersByCountry();
            }
        }

        /// <summary>
        /// Sets Azure region name. Note: this method has additive effect.
        /// </summary>
        /// <param name="azureLocation">Region name.</param>
        /// <return>The AvailableProviders object itself.</return>
        AvailableProviders.Definition.IWithExecuteAndCountry AvailableProviders.Definition.IWithAzureLocations.WithAzureLocation(string azureLocation)
        {
            return this.WithAzureLocation(azureLocation);
        }

        /// <summary>
        /// Set the list of Azure regions. Note: this will overwrite locations if already set.
        /// </summary>
        /// <param name="azureLocations">Locations list.</param>
        /// <return>The AvailableProviders object itself.</return>
        AvailableProviders.Definition.IWithExecute AvailableProviders.Definition.IWithAzureLocations.WithAzureLocations(params string[] azureLocations)
        {
            return this.WithAzureLocations(azureLocations);
        }

        /// <param name="city">The city or town for available providers list.</param>
        /// <return>The next stage of the definition.</return>
        AvailableProviders.Definition.IWithExecute AvailableProviders.Definition.IWithExecuteAndCity.WithCity(string city)
        {
            return this.WithCity(city);
        }

        /// <param name="country">The country for available providers list.</param>
        /// <return>The next stage of the definition.</return>
        AvailableProviders.Definition.IWithExecuteAndState AvailableProviders.Definition.IWithExecuteAndCountry.WithCountry(string country)
        {
            return this.WithCountry(country);
        }

        /// <param name="state">The state for available providers list.</param>
        /// <return>The next stage of the definition.</return>
        AvailableProviders.Definition.IWithExecuteAndCity AvailableProviders.Definition.IWithExecuteAndState.WithState(string state)
        {
            return this.WithState(state);
        }
    }
}