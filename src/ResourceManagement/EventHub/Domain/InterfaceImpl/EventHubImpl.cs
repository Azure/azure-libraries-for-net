// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class EventHubImpl 
    {
        /// <summary>
        /// Specifies the new namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="namespaceCreatable">Namespace creatable definition.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureProviderOrCreate EventHub.Definition.IWithNamespace.WithNewNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable)
        {
            return this.WithNewNamespace(namespaceCreatable) as EventHub.Definition.IWithCaptureProviderOrCreate;
        }

        /// <summary>
        /// Specifies an existing event hub namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="namespace">Event hub namespace.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureProviderOrCreate EventHub.Definition.IWithNamespace.WithExistingNamespace(IEventHubNamespace ehNamespace)
        {
            return this.WithExistingNamespace(ehNamespace) as EventHub.Definition.IWithCaptureProviderOrCreate;
        }

        /// <summary>
        /// Specifies an existing event hub namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub namespace.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureProviderOrCreate EventHub.Definition.IWithNamespace.WithExistingNamespace(string resourceGroupName, string namespaceName)
        {
            return this.WithExistingNamespace(resourceGroupName, namespaceName) as EventHub.Definition.IWithCaptureProviderOrCreate;
        }

        /// <summary>
        /// Specifies id of an existing event hub namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="namespaceId">Event hub namespace resource id.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureProviderOrCreate EventHub.Definition.IWithNamespace.WithExistingNamespaceId(string namespaceId)
        {
            return this.WithExistingNamespaceId(namespaceId) as EventHub.Definition.IWithCaptureProviderOrCreate;
        }

        /// <summary>
        /// Specifies that data capture should be disabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureOptionalSettingsOrCreate EventHub.Definition.IWithCaptureEnabledDisabled.WithDataCaptureDisabled()
        {
            return this.WithDataCaptureDisabled() as EventHub.Definition.IWithCaptureOptionalSettingsOrCreate;
        }

        /// <summary>
        /// Specifies that data capture should be enabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureOptionalSettingsOrCreate EventHub.Definition.IWithCaptureEnabledDisabled.WithDataCaptureEnabled()
        {
            return this.WithDataCaptureEnabled() as EventHub.Definition.IWithCaptureOptionalSettingsOrCreate;
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that an authorization rule associated with the event hub should be deleted.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithAuthorizationRule.WithoutAuthorizationRule(string ruleName)
        {
            return this.WithoutAuthorizationRule(ruleName) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCreate EventHub.Definition.IWithAuthorizationRule.WithNewManageRule(string ruleName)
        {
            return this.WithNewManageRule(ruleName) as EventHub.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCreate EventHub.Definition.IWithAuthorizationRule.WithNewListenRule(string ruleName)
        {
            return this.WithNewListenRule(ruleName) as EventHub.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCreate EventHub.Definition.IWithAuthorizationRule.WithNewSendRule(string ruleName)
        {
            return this.WithNewSendRule(ruleName) as EventHub.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the number of partitions in the event hub.
        /// </summary>
        /// <param name="count">Partitions count.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithPartitionCount.WithPartitionCount(long count)
        {
            return this.WithPartitionCount(count) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the number of partitions in the event hub.
        /// </summary>
        /// <param name="count">Partitions count.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCreate EventHub.Definition.IWithPartitionCount.WithPartitionCount(long count)
        {
            return this.WithPartitionCount(count) as EventHub.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        EventHub.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<EventHub.Update.IUpdate>.Update()
        {
            return this.Update() as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a consumer group associated with the event hub should be deleted.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithConsumerGroup.WithoutConsumerGroup(string name)
        {
            return this.WithoutConsumerGroup(name) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithConsumerGroup.WithNewConsumerGroup(string name)
        {
            return this.WithNewConsumerGroup(name) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <param name="metadata">Group metadata.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithConsumerGroup.WithNewConsumerGroup(string name, string metadata)
        {
            return this.WithNewConsumerGroup(name, metadata) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Consumer group name.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCreate EventHub.Definition.IWithConsumerGroup.WithNewConsumerGroup(string name)
        {
            return this.WithNewConsumerGroup(name) as EventHub.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Consumer group name.</param>
        /// <param name="metadata">Consumer group metadata.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCreate EventHub.Definition.IWithConsumerGroup.WithNewConsumerGroup(string name, string metadata)
        {
            return this.WithNewConsumerGroup(name, metadata) as EventHub.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the retention period for events in days.
        /// </summary>
        /// <param name="period">Retention period.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithRetentionPeriod.WithRetentionPeriodInDays(long period)
        {
            return this.WithRetentionPeriodInDays(period) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the retention period for events in days.
        /// </summary>
        /// <param name="period">Retention period.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCreate EventHub.Definition.IWithRetentionPeriod.WithRetentionPeriodInDays(long period)
        {
            return this.WithRetentionPeriodInDays(period) as EventHub.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the capture window size in MB.
        /// </summary>
        /// <param name="sizeInMB">Window size in MB.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureOptionalSettingsOrCreate EventHub.Definition.IWithCaptureOptionalSettingsOrCreate.WithDataCaptureWindowSizeInMB(int sizeInMB)
        {
            return this.WithDataCaptureWindowSizeInMB(sizeInMB) as EventHub.Definition.IWithCaptureOptionalSettingsOrCreate;
        }

        /// <summary>
        /// Specifies file name format containing captured data.
        /// </summary>
        /// <param name="format">The file name format.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureOptionalSettingsOrCreate EventHub.Definition.IWithCaptureOptionalSettingsOrCreate.WithDataCaptureFileNameFormat(string format)
        {
            return this.WithDataCaptureFileNameFormat(format) as EventHub.Definition.IWithCaptureOptionalSettingsOrCreate;
        }

        /// <summary>
        /// Specifies the capture window size in seconds.
        /// </summary>
        /// <param name="sizeInSeconds">Window size in seconds.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureOptionalSettingsOrCreate EventHub.Definition.IWithCaptureOptionalSettingsOrCreate.WithDataCaptureWindowSizeInSeconds(int sizeInSeconds)
        {
            return this.WithDataCaptureWindowSizeInSeconds(sizeInSeconds) as EventHub.Definition.IWithCaptureOptionalSettingsOrCreate;
        }

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccount">Storage account.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureEnabledDisabled EventHub.Definition.IWithCaptureProviderOrCreate.WithExistingStorageAccountForCapturedData(IStorageAccount storageAccount, string containerName)
        {
            return this.WithExistingStorageAccountForCapturedData(storageAccount, containerName) as EventHub.Definition.IWithCaptureEnabledDisabled;
        }

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountId">Storage account arm id.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureEnabledDisabled EventHub.Definition.IWithCaptureProviderOrCreate.WithExistingStorageAccountForCapturedData(string storageAccountId, string containerName)
        {
            return this.WithExistingStorageAccountForCapturedData(storageAccountId, containerName) as EventHub.Definition.IWithCaptureEnabledDisabled;
        }

        /// <summary>
        /// Specifies a new storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountCreatable">Creatable storage account definition.</param>
        /// <param name="containerName">Container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub definition.</return>
        EventHub.Definition.IWithCaptureEnabledDisabled EventHub.Definition.IWithCaptureProviderOrCreate.WithNewStorageAccountForCapturedData(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName)
        {
            return this.WithNewStorageAccountForCapturedData(storageAccountCreatable, containerName) as EventHub.Definition.IWithCaptureEnabledDisabled;
        }

        /// <summary>
        /// Specifies that data capture should be disabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithDataCaptureDisabled()
        {
            return this.WithDataCaptureDisabled() as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the capture window size in MB.
        /// </summary>
        /// <param name="sizeInMB">Window size in MB.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithDataCaptureWindowSizeInMB(int sizeInMB)
        {
            return this.WithDataCaptureWindowSizeInMB(sizeInMB) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the format of the file containing captured data.
        /// </summary>
        /// <param name="format">The file name format.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithDataCaptureFileNameFormat(string format)
        {
            return this.WithDataCaptureFileNameFormat(format) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccount">Storage account.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithExistingStorageAccountForCapturedData(IStorageAccount storageAccount, string containerName)
        {
            return this.WithExistingStorageAccountForCapturedData(storageAccount, containerName) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountId">Storage account arm id.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithExistingStorageAccountForCapturedData(string storageAccountId, string containerName)
        {
            return this.WithExistingStorageAccountForCapturedData(storageAccountId, containerName) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that data capture should be enabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithDataCaptureEnabled()
        {
            return this.WithDataCaptureEnabled() as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the capture window size in seconds.
        /// </summary>
        /// <param name="sizeInSeconds">Window size in seconds.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithDataCaptureWindowSizeInSeconds(int sizeInSeconds)
        {
            return this.WithDataCaptureWindowSizeInSeconds(sizeInSeconds) as EventHub.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountCreatable">Creatable storage account definition.</param>
        /// <param name="containerName">Container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub update.</return>
        EventHub.Update.IUpdate EventHub.Update.IWithCapture.WithNewStorageAccountForCapturedData(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName)
        {
            return this.WithNewStorageAccountForCapturedData(storageAccountCreatable, containerName) as EventHub.Update.IUpdate;
        }

        /// <return>Consumer group in the event hub.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>> Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.ListConsumerGroupsAsync(CancellationToken cancellationToken)
        {
            return await this.ListConsumerGroupsAsync(cancellationToken) as IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>;
        }

        /// <return>Authorization rules enabled for the event hub.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.ListAuthorizationRules()
        {
            return this.ListAuthorizationRules() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>;
        }

        /// <summary>
        /// Gets configured window in seconds to be used for event capturing when capturing is enabled.
        /// </summary>
        int Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.DataCaptureWindowSizeInSeconds
        {
            get
            {
                return this.DataCaptureWindowSizeInSeconds();
            }
        }

        /// <return>Consumer group in the event hub.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.ListConsumerGroups()
        {
            return this.ListConsumerGroups() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>;
        }

        /// <summary>
        /// Gets configured window in MB to be used for event capturing when capturing is enabled.
        /// </summary>
        int Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.DataCaptureWindowSizeInMB
        {
            get
            {
                return this.DataCaptureWindowSizeInMB();
            }
        }

        /// <summary>
        /// Gets description of the destination where captured data will be stored.
        /// </summary>
        Destination Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.CaptureDestination
        {
            get
            {
                return this.CaptureDestination() as Destination;
            }
        }

        /// <summary>
        /// Gets the format file name that stores captured data when capturing is enabled.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.DataCaptureFileNameFormat
        {
            get
            {
                return this.DataCaptureFileNameFormat();
            }
        }

        /// <summary>
        /// Gets true if the data capture enabled for the event hub events, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.IsDataCaptureEnabled
        {
            get
            {
                return this.IsDataCaptureEnabled();
            }
        }

        /// <summary>
        /// Gets the resource group of the parent namespace.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.NamespaceResourceGroupName
        {
            get
            {
                return this.NamespaceResourceGroupName();
            }
        }

        /// <summary>
        /// Gets name of the parent namespace.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }

        /// <return>Authorization rules enabled for the event hub.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>> Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.ListAuthorizationRulesAsync(CancellationToken cancellationToken)
        {
            return await this.ListAuthorizationRulesAsync(cancellationToken) as IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>;
        }

        /// <summary>
        /// Gets retention period of events in days.
        /// </summary>
        long Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.MessageRetentionPeriodInDays
        {
            get
            {
                return this.MessageRetentionPeriodInDays();
            }
        }

        /// <summary>
        /// Gets the partition identifiers.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<string> Microsoft.Azure.Management.Eventhub.Fluent.IEventHub.PartitionIds
        {
            get
            {
                return this.PartitionIds() as IReadOnlyCollection<string>;
            }
        }
    }
}