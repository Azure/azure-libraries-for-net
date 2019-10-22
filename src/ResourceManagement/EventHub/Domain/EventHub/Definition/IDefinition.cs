// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// The entirety of the event hub definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IBlank,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithNamespace,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureProviderOrCreate,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureEnabledDisabled,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureOptionalSettingsOrCreate,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a event hub definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithNamespace
    {
    }

    /// <summary>
    /// The stage of the event hub definition allowing to enable or disable data capturing.
    /// </summary>
    public interface IWithCaptureEnabledDisabled  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that data capture should be enabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureOptionalSettingsOrCreate WithDataCaptureEnabled();

        /// <summary>
        /// Specifies that data capture should be disabled for the event hub.
        /// </summary>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureOptionalSettingsOrCreate WithDataCaptureDisabled();
    }

    /// <summary>
    /// The stage of the event hub definition allowing to add consumer group for the event hub.
    /// </summary>
    public interface IWithConsumerGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Consumer group name.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate WithNewConsumerGroup(string name);

        /// <summary>
        /// Specifies that a new consumer group should be created for the event hub.
        /// </summary>
        /// <param name="name">Consumer group name.</param>
        /// <param name="metadata">Consumer group metadata.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate WithNewConsumerGroup(string name, string metadata);
    }

    /// <summary>
    /// The stage of the event hub definition allowing to configure data capturing.
    /// </summary>
    public interface IWithCaptureOptionalSettingsOrCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate
    {
        /// <summary>
        /// Specifies file name format containing captured data.
        /// </summary>
        /// <param name="format">The file name format.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureOptionalSettingsOrCreate WithDataCaptureFileNameFormat(string format);

        /// <summary>
        /// Specifies the capture window size in seconds.
        /// </summary>
        /// <param name="sizeInSeconds">Window size in seconds.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureOptionalSettingsOrCreate WithDataCaptureWindowSizeInSeconds(int sizeInSeconds);

        /// <summary>
        /// Specifies the capture window size in MB.
        /// </summary>
        /// <param name="sizeInMB">Window size in MB.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureOptionalSettingsOrCreate WithDataCaptureWindowSizeInMB(int sizeInMB);


        /// <summary>
        /// Set a value that indicates whether to Skip Empty Archives.
        /// </summary>
        /// <param name="skipEmptyArchives">The skipEmptyArchives value to set.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureOptionalSettingsOrCreate WithDataCaptureSkipEmptyArchives(bool skipEmptyArchives);
    }

    /// <summary>
    /// The stage of the event hub definition allowing to specify partition count for event hub.
    /// </summary>
    public interface IWithPartitionCount  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the number of partitions in the event hub.
        /// </summary>
        /// <param name="count">Partitions count.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate WithPartitionCount(long count);
    }

    /// <summary>
    /// The stage of the event hub definition allowing to specify provider to store captured data when data capturing is enabled.
    /// </summary>
    public interface IWithCaptureProviderOrCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate
    {
        /// <summary>
        /// Specifies a new storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountCreatable">Creatable storage account definition.</param>
        /// <param name="containerName">Container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureEnabledDisabled WithNewStorageAccountForCapturedData(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName);

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccount">Storage account.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureEnabledDisabled WithExistingStorageAccountForCapturedData(IStorageAccount storageAccount, string containerName);

        /// <summary>
        /// Specifies an existing storage account to store the captured data when data capturing is enabled.
        /// </summary>
        /// <param name="storageAccountId">Storage account arm id.</param>
        /// <param name="containerName">An existing or new container to store the files containing captured data.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureEnabledDisabled WithExistingStorageAccountForCapturedData(string storageAccountId, string containerName);
    }

    /// <summary>
    /// The stage of the event hub definition allowing to add authorization rule for accessing
    /// the event hub.
    /// </summary>
    public interface IWithAuthorizationRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that a new authorization rule should be created that has send access to the event hub.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate WithNewSendRule(string ruleName);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has listen access to the event hub.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate WithNewListenRule(string ruleName);

        /// <summary>
        /// Specifies that a new authorization rule should be created that has manage access to the event hub.
        /// </summary>
        /// <param name="ruleName">Rule name.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate WithNewManageRule(string ruleName);
    }

    /// <summary>
    /// The stage of the event hub definition allowing to specify the name space in which event hub needs to be created.
    /// </summary>
    public interface IWithNamespace  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies an existing event hub namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="namespace">Event hub namespace.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureProviderOrCreate WithExistingNamespace(IEventHubNamespace ehNamespace);

        /// <summary>
        /// Specifies an existing event hub namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Event hub namespace.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureProviderOrCreate WithExistingNamespace(string resourceGroupName, string namespaceName);

        /// <summary>
        /// Specifies the new namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="namespaceCreatable">Namespace creatable definition.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureProviderOrCreate WithNewNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable);

        /// <summary>
        /// Specifies id of an existing event hub namespace in which event hub needs to be created.
        /// </summary>
        /// <param name="namespaceId">Event hub namespace resource id.</param>
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCaptureProviderOrCreate WithExistingNamespaceId(string namespaceId);
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
        /// <return>Next stage of the event hub definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithCreate WithRetentionPeriodInDays(long period);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub>,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithAuthorizationRule,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithConsumerGroup,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithPartitionCount,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition.IWithRetentionPeriod
    {
    }
}