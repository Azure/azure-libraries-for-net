// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to manage disaster recovery pairing authorization rules.
    /// </summary>
    public interface IDisasterRecoveryPairingAuthorizationRules  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.IDisasterRecoveryConfigsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.EventHubManager>
    {
        /// <summary>
        /// Lists the authorization rules that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <return>List of authorization rules.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> ListByDisasterRecoveryPairing(string resourceGroupName, string namespaceName, string pairingName);

        /// <summary>
        /// Lists the authorization rules that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <return>Observable that emits the authorization rules.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>> ListByDisasterRecoveryPairingAsync(string resourceGroupName, string namespaceName, string pairingName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets an authorization rule that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <param name="name">Rule name.</param>
        /// <return>The authorization rule.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule GetByName(string resourceGroupName, string namespaceName, string pairingName, string name);

        /// <summary>
        /// Gets an authorization rule that can be used to access the disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name.</param>
        /// <param name="namespaceName">Primary namespace name.</param>
        /// <param name="pairingName">Pairing name.</param>
        /// <param name="name">Rule name.</param>
        /// <return>Observable that emits the authorization rule.</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> GetByNameAsync(string resourceGroupName, string namespaceName, string pairingName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}