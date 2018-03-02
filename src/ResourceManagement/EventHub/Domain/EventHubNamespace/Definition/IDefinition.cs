// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of the event hub namespace definition allowing to specify the throughput unit settings.
    /// </summary>
    public interface IWithThroughputConfiguration  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Enables the scaling up the throughput units automatically based on load.
        /// </summary>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithAutoScaling();

        /// <summary>
        /// Specifies the current throughput units.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithCurrentThroughputUnits(int units);

        /// <summary>
        /// Specifies the maximum throughput units that auto-scalar is allowed to scale-up.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithThroughputUnitsUpperLimit(int units);
    }

    /// <summary>
    /// The stage of the event hub namespace definition allowing to add authorization rule for accessing
    /// the event hub.
    /// </summary>
    public interface IWithAuthorizationRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithNewSendRule(string ruleName);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithNewListenRule(string ruleName);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithNewManageRule(string ruleName);
    }

    /// <summary>
    /// The first stage of a event hub namespace definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the event hub namespace definition allowing to add new event hub in the namespace.
    /// </summary>
    public interface IWithEventHub  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithNewEventHub(string eventHubName);

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithNewEventHub(string eventHubName, int partitionCount);

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <param name="retentionPeriodInDays">The retention period for events in days.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithNewEventHub(string eventHubName, int partitionCount, int retentionPeriodInDays);
    }

    /// <summary>
    /// The stage of the event hub namespace definition allowing to specify the sku.
    /// </summary>
    public interface IWithSku  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate WithSku(EventHubNamespaceSkuType namespaceSku);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate>,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithSku,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithEventHub,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithAuthorizationRule,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithThroughputConfiguration
    {
    }

    /// <summary>
    /// The entirety of the event hub namespace definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IBlank,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithGroup,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the event hub namespace definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition.IWithCreate>
    {
    }
}