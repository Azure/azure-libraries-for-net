// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class EventHubDisasterRecoveryPairingImpl 
    {
        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceId">The secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        EventHubDisasterRecoveryPairing.Definition.IWithCreate EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace.WithExistingSecondaryNamespaceId(string namespaceId)
        {
            return this.WithExistingSecondaryNamespaceId(namespaceId);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceCreatable">Creatable definition for the primary namespace.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHubDisasterRecoveryPairing.Definition.IWithCreate EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace.WithNewSecondaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable)
        {
            return this.WithNewSecondaryNamespace(namespaceCreatable);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespace">The secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        EventHubDisasterRecoveryPairing.Definition.IWithCreate EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace.WithExistingSecondaryNamespace(IEventHubNamespace ehNamespace)
        {
            return this.WithExistingSecondaryNamespace(ehNamespace);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceId">The secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing update.</return>
        EventHubDisasterRecoveryPairing.Update.IUpdate EventHubDisasterRecoveryPairing.Update.IWithSecondaryNamespace.WithExistingSecondaryNamespaceId(string namespaceId)
        {
            return this.WithExistingSecondaryNamespaceId(namespaceId);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceCreatable">Creatable definition for the secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing update.</return>
        EventHubDisasterRecoveryPairing.Update.IUpdate EventHubDisasterRecoveryPairing.Update.IWithSecondaryNamespace.WithNewSecondaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable)
        {
            return this.WithNewSecondaryNamespace(namespaceCreatable);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespace">The secondary event hub namespace.</param>
        /// <return>Next stage of the disaster recovery pairing update.</return>
        EventHubDisasterRecoveryPairing.Update.IUpdate EventHubDisasterRecoveryPairing.Update.IWithSecondaryNamespace.WithExistingSecondaryNamespace(IEventHubNamespace ehNamespace)
        {
            return this.WithExistingSecondaryNamespace(ehNamespace);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceId">The primary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace EventHubDisasterRecoveryPairing.Definition.IWithPrimaryNamespace.WithExistingPrimaryNamespaceId(string namespaceId)
        {
            return this.WithExistingPrimaryNamespaceId(namespaceId);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceCreatable">Creatable definition for the primary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace EventHubDisasterRecoveryPairing.Definition.IWithPrimaryNamespace.WithNewPrimaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable)
        {
            return this.WithNewPrimaryNamespace(namespaceCreatable);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespace">The primary event hub namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace EventHubDisasterRecoveryPairing.Definition.IWithPrimaryNamespace.WithExistingPrimaryNamespace(IEventHubNamespace ehNamespace)
        {
            return this.WithExistingPrimaryNamespace(ehNamespace);
        }

        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name of primary namespace.</param>
        /// <param name="namespaceName">The primary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace EventHubDisasterRecoveryPairing.Definition.IWithPrimaryNamespace.WithExistingPrimaryNamespace(string resourceGroupName, string namespaceName)
        {
            return this.WithExistingPrimaryNamespace(resourceGroupName, namespaceName);
        }

        /// <summary>
        /// Gets Perform fail over so that the secondary namespace becomes the primary.
        /// </summary>
        /// <summary>
        /// Gets completable representing the fail-over action.
        /// </summary>
        async Task Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.FailOverAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.FailOverAsync(cancellationToken);
        }

        /// <summary>
        /// Gets secondary event hub namespace in the pairing.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.SecondaryNamespaceId
        {
            get
            {
                return this.SecondaryNamespaceId();
            }
        }

        /// <summary>
        /// Gets provisioning state of the pairing.
        /// </summary>
        ProvisioningStateDR? Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets primary event hub namespace resource group.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.PrimaryNamespaceResourceGroupName
        {
            get
            {
                return this.PrimaryNamespaceResourceGroupName();
            }
        }

        /// <summary>
        /// Gets primary event hub namespace in the pairing.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.PrimaryNamespaceName
        {
            get
            {
                return this.PrimaryNamespaceName();
            }
        }

        /// <summary>
        /// Gets the namespace role.
        /// </summary>
        RoleDisasterRecovery? Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.NamespaceRole
        {
            get
            {
                return this.NamespaceRole();
            }
        }

        /// <summary>
        /// Gets Break the pairing between a primary and secondary namespace.
        /// </summary>
        /// <summary>
        /// Gets completable representing the pairing break action.
        /// </summary>
        async Task Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.BreakPairingAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        {
            await this.BreakPairingAsync(cancellationToken);
        }

        /// <summary>
        /// Perform fail over so that the secondary namespace becomes the primary.
        /// </summary>
        void Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.FailOver()
        {
 
            this.FailOver();
        }

        /// <return>The authorization rules for the event hub disaster recovery pairing.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.ListAuthorizationRules()
        {
            return this.ListAuthorizationRules();
        }

        /// <return>The authorization rules for the event hub disaster recovery pairing.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationRule>> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.ListAuthorizationRulesAsync(CancellationToken cancellationToken)
        {
            return await this.ListAuthorizationRulesAsync(cancellationToken);
        }

        /// <summary>
        /// Break the pairing between a primary and secondary namespace.
        /// </summary>
        void Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing.BreakPairing()
        {
 
            this.BreakPairing();
        }
    }
}