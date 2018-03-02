// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update
{
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The template for a disaster recovery pairing update operation, containing all the settings
    /// that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update.IWithSecondaryNamespace,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubDisasterRecoveryPairing>
    {
    }

    /// <summary>
    /// The stage of the disaster recovery pairing definition allowing to specify primary event hub namespace.
    /// </summary>
    public interface IWithSecondaryNamespace  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespace">The secondary event hub namespace.</param>
        /// <return>Next stage of the disaster recovery pairing update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update.IUpdate WithExistingSecondaryNamespace(IEventHubNamespace ehNamespace);

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceId">The secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update.IUpdate WithExistingSecondaryNamespaceId(string namespaceId);

        /// <summary>
        /// Specifies that the given namespace should be used as secondary namespace in disaster recovery pairing.
        /// </summary>
        /// <param name="namespaceCreatable">Creatable definition for the secondary namespace.</param>
        /// <return>Next stage of the disaster recovery pairing update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubDisasterRecoveryPairing.Update.IUpdate WithNewSecondaryNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable);
    }
}