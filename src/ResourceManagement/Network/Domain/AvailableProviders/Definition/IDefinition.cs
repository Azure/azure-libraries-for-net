// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition
{
    /// <summary>
    /// The stage of the definition which allows to specify country or execute the query.
    /// </summary>
    public interface IWithExecuteAndCountry  :
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecute
    {

        /// <param name="country">The country for available providers list.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecuteAndState WithCountry(string country);
    }

    /// <summary>
    /// The stage of the definition which allows to specify state or execute the query.
    /// </summary>
    public interface IWithExecuteAndState  :
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecute
    {

        /// <param name="state">The state for available providers list.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecuteAndCity WithState(string state);
    }

    /// <summary>
    /// The first stage of available providers parameters definition.
    /// </summary>
    public interface IWithAzureLocations 
    {

        /// <summary>
        /// Sets Azure region name. Note: this method has additive effect.
        /// </summary>
        /// <param name="azureLocation">Region name.</param>
        /// <return>The AvailableProviders object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecuteAndCountry WithAzureLocation(string azureLocation);

        /// <summary>
        /// Set the list of Azure regions. Note: this will overwrite locations if already set.
        /// </summary>
        /// <param name="azureLocations">Locations list.</param>
        /// <return>The AvailableProviders object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecute WithAzureLocations(params string[] azureLocations);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for execution, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IAvailableProviders>,
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithAzureLocations
    {

    }

    /// <summary>
    /// The entirety of available providers parameters definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecuteAndCountry,
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecuteAndState,
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecuteAndCity
    {

    }

    /// <summary>
    /// The stage of the definition which allows to specify city or execute the query.
    /// </summary>
    public interface IWithExecuteAndCity  :
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecute
    {

        /// <param name="city">The city or town for available providers list.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.AvailableProviders.Definition.IWithExecute WithCity(string city);
    }
}