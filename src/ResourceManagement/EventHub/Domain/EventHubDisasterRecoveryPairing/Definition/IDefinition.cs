// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition
{
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the disaster recovery pairing definition allowing to specify the secondary event hub namespace.
    /// </summary>
    public interface IWithSecondaryNamespace  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespace">The secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithCreate WithExistingSecondaryNamespace(IEventHubNamespace ehNamespace);

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceId">The secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithCreate WithExistingSecondaryNamespaceId(string namespaceId);

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceCreatable">Creatable definition for the primary namespace.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithCreate WithNewSecondaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable);
    }

    /// <summary>
    /// The first stage of a disaster recovery pairing definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithPrimaryNamespace
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing>
    {
    }

    /// <summary>
    /// The entirety of the event hub disaster recovery pairing definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IBlank,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithPrimaryNamespace,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the disaster recovery pairing definition allowing to specify primary event hub namespace.
    /// </summary>
    public interface IWithPrimaryNamespace  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceCreatable">Creatable definition for the primary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace WithNewPrimaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable);

        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceId">The primary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace WithExistingPrimaryNamespaceId(string namespaceId);

        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespace">The primary event hub namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace WithExistingPrimaryNamespace(IEventHubNamespace ehNamespace);

        /// <summary>
        /// Specifies that the given namespace should be used as primary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name of primary namespace.</param>
        /// <param name="namespaceName">The primary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Definition.IWithSecondaryNamespace WithExistingPrimaryNamespace(string resourceGroupName, string namespaceName);
    }
}