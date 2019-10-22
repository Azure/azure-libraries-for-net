// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Eventhub.Fluent;

    /// <summary>
    /// The stage of the event hub update allowing to configure data capture.
    /// </summary>
    public interface IWithCapture  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the format of the file containing captured data.
        /// </summary>
        /// <param name="format">The file name format.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithDataCaptureFileNameFormat(string format);

        /// <summary>
        /// Specifies a new storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountCreatable">Creatable storage account definition.</param>
        /// <param name="containerName">Container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithNewStorageAccountForCapturedData(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName);

        /// <summary>
        /// Specifies that data capture should be enabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithDataCaptureEnabled();

        /// <summary>
        /// Specifies the capture window size in seconds.
        /// </summary>
        /// <param name="sizeInSeconds">Window size in seconds.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithDataCaptureWindowSizeInSeconds(int sizeInSeconds);

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccount">Storage account.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithExistingStorageAccountForCapturedData(IStorageAccount storageAccount, string containerName);

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountId">Storage account arm id.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithExistingStorageAccountForCapturedData(string storageAccountId, string containerName);

        /// <summary>
        /// Specifies that data capture should be disabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithDataCaptureDisabled();

        /// <summary>
        /// Specifies the capture window size in MB.
        /// </summary>
        /// <param name="sizeInMB">Window size in MB.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithDataCaptureWindowSizeInMB(int sizeInMB);


        /// <summary>
        ///  Specified the capture whether to Skip Empty Archives.
        /// </summary>
        /// <param name="skipEmptyArchives">The skipEmptyArchives value to set.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithDataCaptureSkipEmptyArchives(bool skipEmptyArchives);
    }

    /// <summary>
    /// The stage of the event hub definition allowing to add an authorization rule for accessing
    /// the event hub.
    /// </summary>
    public interface IWithAuthorizationRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithNewSendRule(string name);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithNewListenRule(string name);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithNewManageRule(string name);

        /// <summary>
        /// Specifies that an authorization rule associated with the event hub should be deleted.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithoutAuthorizationRule(string ruleName);
    }

    /// <summary>
    /// The stage of the event hub update allowing to add consumer group for event hub.
    /// </summary>
    public interface IWithConsumerGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithNewConsumerGroup(string name);

        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <param name="metadata">Group metadata.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithNewConsumerGroup(string name, string metadata);

        /// <summary>
        /// Specifies that a consumer group associated with the event hub should be deleted.
        /// </summary>
        /// <param name="name">Group name.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithoutConsumerGroup(string name);
    }

    /// <summary>
    /// The stage of the event hub update allowing to specify partition count for event hub.
    /// </summary>
    public interface IWithPartitionCount  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the number of partitions in the event hub.
        /// </summary>
        /// <param name="count">Partitions count.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithPartitionCount(long count);
    }

    /// <summary>
    /// The template for a event hub update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IWithConsumerGroup,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IWithAuthorizationRule,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IWithCapture,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IWithPartitionCount,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IWithRetentionPeriod
    {
    }

    /// <summary>
    /// The stage of the event hub definition allowing to specify retention period for event hub events.
    /// </summary>
    public interface IWithRetentionPeriod  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the retention period for events in days.
        /// </summary>
        /// <param name="period">Retention period.</param>
        /// <return>Next stage of the event hub update.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update.IUpdate WithRetentionPeriodInDays(long period);
    }
}