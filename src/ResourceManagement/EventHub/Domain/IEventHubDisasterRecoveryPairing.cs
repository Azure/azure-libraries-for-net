// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Type representing disaster recovery pairing for event hub namespaces.
    /// </summary>
    public interface IEventHubDisasterRecoveryPairing  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.INestedResource,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.IEventHubManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<EventHubDisasterRecoveryPairing.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.Models.ArmDisasterRecoveryInner>
    {
        /// <summary>
        /// Gets secondary event hub namespace in the pairing.
        /// </summary>
        string SecondaryNamespaceId { get; }

        /// <summary>
        /// Perform fail over so that the secondary namespace becomes the primary.
        /// </summary>
        Task FailOverAsync(CancellationToken cancellationToken);

        /// <return>The authorization rules for the event hub disaster recovery pairing.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> ListAuthorizationRules();

        /// <summary>
        /// Break the pairing between a primary and secondary namespace.
        /// </summary>
        Task BreakPairingAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets primary event hub namespace in the pairing.
        /// </summary>
        string PrimaryNamespaceName { get; }

        /// <summary>
        /// Perform fail over so that the secondary namespace becomes the primary.
        /// </summary>
        void FailOver();

        /// <summary>
        /// Gets the namespace role.
        /// </summary>
        Management.EventHub.Fluent.Models.RoleDisasterRecovery? NamespaceRole { get; }

        /// <summary>
        /// Gets provisioning state of the pairing.
        /// </summary>
        Management.EventHub.Fluent.Models.ProvisioningStateDR? ProvisioningState { get; }

        /// <summary>
        /// Gets primary event hub namespace resource group.
        /// </summary>
        string PrimaryNamespaceResourceGroupName { get; }

        /// <summary>
        /// Break the pairing between a primary and secondary namespace.
        /// </summary>
        void BreakPairing();

        /// <return>The authorization rules for the event hub disaster recovery pairing.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>> ListAuthorizationRulesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}