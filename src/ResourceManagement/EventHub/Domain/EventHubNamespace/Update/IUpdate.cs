// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update
{
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the event hub namespace update allowing to add new event hub in the namespace.
    /// </summary>
    public interface IWithEventHub  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithNewEventHub(string eventHubName);

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithNewEventHub(string eventHubName, int partitionCount);

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <param name="retentionPeriodInDays">The retention period for events in days.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithNewEventHub(string eventHubName, int partitionCount, int retentionPeriodInDays);

        /// <summary>
        /// Deletes an event hub in the event hub namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithoutEventHub(string eventHubName);
    }

    /// <summary>
    /// The stage of the event hub namespace update allowing to specify the throughput unit settings.
    /// </summary>
    public interface IWithThroughputConfiguration  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Enables the scaling up the throughput units automatically based on load.
        /// </summary>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithAutoScaling();

        /// <summary>
        /// Specifies the current throughput units.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithCurrentThroughputUnits(int units);

        /// <summary>
        /// Specifies the maximum throughput units that auto-scalar is allowed to scale-up.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithThroughputUnitsUpperLimit(int units);
    }

    /// <summary>
    /// The stage of the event hub namespace update allowing to add authorization rule for accessing
    /// the event hub.
    /// </summary>
    public interface IWithAuthorizationRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithNewSendRule(string ruleName);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithNewListenRule(string ruleName);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithNewManageRule(string ruleName);

        /// <summary>
        /// Deletes an authorization rule associated with the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithoutAuthorizationRule(string ruleName);
    }

    /// <summary>
    /// The stage of the event hub namespace update allowing to change the sku.
    /// </summary>
    public interface IWithSku  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate WithSku(EventHubNamespaceSkuType namespaceSku);
    }

    /// <summary>
    /// The template for a event hub namespace update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IUpdate>,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IWithSku,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IWithEventHub,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IWithAuthorizationRule,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update.IWithThroughputConfiguration
    {
    }
}