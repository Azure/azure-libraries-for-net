// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    internal partial class DisasterRecoveryPairingAuthorizationRulesImpl 
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Gets an authorization rule that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <param name="name">Rule name.</param>
        /// <return>The authorization rule.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRules.GetByName(string resourceGroupName, string namespaceName, string pairingName, string name)
        {
            return this.GetByName(resourceGroupName, namespaceName, pairingName, name);
        }

        /// <summary>
        /// Gets an authorization rule that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <param name="name">Rule name.</param>
        /// <return>Observable that emits the authorization rule.</return>
        async Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRules.GetByNameAsync(string resourceGroupName, string namespaceName, string pairingName, string name, CancellationToken cancellationToken)
        {
            return await this.GetByNameAsync(resourceGroupName, namespaceName, pairingName, name, cancellationToken);
        }

        /// <summary>
        /// Lists the authorization rules that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <return>Observable that emits the authorization rules.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>> Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRules.ListByDisasterRecoveryPairingAsync(string resourceGroupName, string namespaceName, string pairingName, CancellationToken cancellationToken)
        {
            return await this.ListByDisasterRecoveryPairingAsync(resourceGroupName, namespaceName, pairingName, cancellationToken);
        }

        /// <summary>
        /// Lists the authorization rules that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <return>List of authorization rules.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRules.ListByDisasterRecoveryPairing(string resourceGroupName, string namespaceName, string pairingName)
        {
            return this.ListByDisasterRecoveryPairing(resourceGroupName, namespaceName, pairingName);
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Management.EventHub.Fluent.EventHubManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.EventHubManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }
    }
}