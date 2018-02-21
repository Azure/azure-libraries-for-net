// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Type representing authorization rule of  EventHubDisasterRecoveryPairing.
    /// </summary>
    public interface IDisasterRecoveryPairingAuthorizationRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.Models.AuthorizationRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.EventHubManager>
    {
        /// <return>An observable that emits a single entity containing access keys (primary and secondary).</return>
        Task<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets rights associated with the rule.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Management.EventHub.Fluent.Models.AccessRights> Rights { get; }

        /// <return>Entity containing access keys (primary and secondary).</return>
        Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey GetKeys();
    }
}