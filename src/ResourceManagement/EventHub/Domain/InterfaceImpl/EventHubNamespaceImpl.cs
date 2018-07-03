// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespace.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class EventHubNamespaceImpl 
    {
        /// <summary>
        /// Specifies the current throughput units.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithThroughputConfiguration.WithCurrentThroughputUnits(int units)
        {
            return this.WithCurrentThroughputUnits(units);
        }

        /// <summary>
        /// Specifies the maximum throughput units that auto-scalar is allowed to scale-up.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithThroughputConfiguration.WithThroughputUnitsUpperLimit(int units)
        {
            return this.WithThroughputUnitsUpperLimit(units);
        }

        /// <summary>
        /// Enables the scaling up the throughput units automatically based on load.
        /// </summary>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithThroughputConfiguration.WithAutoScaling()
        {
            return this.WithAutoScaling();
        }

        /// <summary>
        /// Specifies the current throughput units.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithThroughputConfiguration.WithCurrentThroughputUnits(int units)
        {
            return this.WithCurrentThroughputUnits(units);
        }

        /// <summary>
        /// Specifies the maximum throughput units that auto-scalar is allowed to scale-up.
        /// </summary>
        /// <param name="units">Throughput units.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithThroughputConfiguration.WithThroughputUnitsUpperLimit(int units)
        {
            return this.WithThroughputUnitsUpperLimit(units);
        }

        /// <summary>
        /// Enables the scaling up the throughput units automatically based on load.
        /// </summary>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithThroughputConfiguration.WithAutoScaling()
        {
            return this.WithAutoScaling();
        }

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithEventHub.WithNewEventHub(string eventHubName)
        {
            return this.WithNewEventHub(eventHubName);
        }

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithEventHub.WithNewEventHub(string eventHubName, int partitionCount)
        {
            return this.WithNewEventHub(eventHubName, partitionCount);
        }

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <param name="retentionPeriodInDays">The retention period for events in days.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithEventHub.WithNewEventHub(string eventHubName, int partitionCount, int retentionPeriodInDays)
        {
            return this.WithNewEventHub(eventHubName, partitionCount, retentionPeriodInDays);
        }

        /// <summary>
        /// Deletes an event hub in the event hub namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithEventHub.WithoutEventHub(string eventHubName)
        {
            return this.WithoutEventHub(eventHubName);
        }

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithEventHub.WithNewEventHub(string eventHubName)
        {
            return this.WithNewEventHub(eventHubName);
        }

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithEventHub.WithNewEventHub(string eventHubName, int partitionCount)
        {
            return this.WithNewEventHub(eventHubName, partitionCount);
        }

        /// <summary>
        /// Specifies that a new event hub should be created in the namespace.
        /// </summary>
        /// <param name="eventHubName">Event hub name.</param>
        /// <param name="partitionCount">The number of partitions in the event hub.</param>
        /// <param name="retentionPeriodInDays">The retention period for events in days.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithEventHub.WithNewEventHub(string eventHubName, int partitionCount, int retentionPeriodInDays)
        {
            return this.WithNewEventHub(eventHubName, partitionCount, retentionPeriodInDays);
        }

        /// <summary>
        /// Gets the service bus endpoint associated with the namespace.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.ServiceBusEndpoint
        {
            get
            {
                return this.ServiceBusEndpoint();
            }
        }

        /// <return>The event hubs in the namespace.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.ListEventHubsAsync(CancellationToken cancellationToken)
        {
            return await this.ListEventHubsAsync(cancellationToken);
        }

        /// <return>List of event hubs in the namespace.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.ListEventHubs()
        {
            return this.ListEventHubs();
        }

        /// <summary>
        /// Gets true if auto-scale is enabled for the namespace, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.IsAutoScaleEnabled
        {
            get
            {
                return this.IsAutoScaleEnabled();
            }
        }

        /// <summary>
        /// Gets maximum throughput unit that auto-scalar is allowed to set.
        /// </summary>
        int Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.ThroughputUnitsUpperLimit
        {
            get
            {
                return this.ThroughputUnitsUpperLimit();
            }
        }

        /// <summary>
        /// Gets resource id of the Azure Insights metrics associated with the namespace.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.AzureInsightMetricId
        {
            get
            {
                return this.AzureInsightMetricId();
            }
        }

        /// <summary>
        /// Gets current throughput units set for the namespace.
        /// </summary>
        int Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.CurrentThroughputUnits
        {
            get
            {
                return this.CurrentThroughputUnits();
            }
        }

        /// <summary>
        /// Gets namespace created time.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.CreatedAt
        {
            get
            {
                return this.CreatedAt();
            }
        }

        /// <summary>
        /// Gets provisioning state of the namespace.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets namespace sku.
        /// </summary>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceSkuType Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets namespace last modified time.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.UpdatedAt
        {
            get
            {
                return this.UpdatedAt();
            }
        }

        /// <return>List of authorization rules for the event hub namespace.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.ListAuthorizationRules()
        {
            return this.ListAuthorizationRules();
        }

        /// <return>The authorization rules for the event hub namespace.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>> Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace.ListAuthorizationRulesAsync(CancellationToken cancellationToken)
        {
            return await this.ListAuthorizationRulesAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithAuthorizationRule.WithNewManageRule(string ruleName)
        {
            return this.WithNewManageRule(ruleName);
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithAuthorizationRule.WithNewSendRule(string ruleName)
        {
            return this.WithNewSendRule(ruleName);
        }

        /// <summary>
        /// Deletes an authorization rule associated with the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithAuthorizationRule.WithoutAuthorizationRule(string ruleName)
        {
            return this.WithoutAuthorizationRule(ruleName);
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithAuthorizationRule.WithNewListenRule(string ruleName)
        {
            return this.WithNewListenRule(ruleName);
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithAuthorizationRule.WithNewManageRule(string ruleName)
        {
            return this.WithNewManageRule(ruleName);
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithAuthorizationRule.WithNewSendRule(string ruleName)
        {
            return this.WithNewSendRule(ruleName);
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub namespace.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithAuthorizationRule.WithNewListenRule(string ruleName)
        {
            return this.WithNewListenRule(ruleName);
        }

        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the event hub namespace update.</return>
        EventHubNamespace.Update.IUpdate EventHubNamespace.Update.IWithSku.WithSku(EventHubNamespaceSkuType namespaceSku)
        {
            return this.WithSku(namespaceSku);
        }

        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the event hub namespace definition.</return>
        EventHubNamespace.Definition.IWithCreate EventHubNamespace.Definition.IWithSku.WithSku(EventHubNamespaceSkuType namespaceSku)
        {
            return this.WithSku(namespaceSku);
        }
    }
}