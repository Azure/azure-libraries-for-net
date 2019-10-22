// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    /// <summary>
    /// The Azure event log entries are of type EventData.
    /// </summary>
    public interface IEventData :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Monitor.Fluent.Models.EventData>
    {

        /// <summary>
        /// Gets the authorization value.
        /// </summary>
        /// <summary>
        /// Gets the authorization value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.SenderAuthorization Authorization { get; }

        /// <summary>
        /// Gets the caller value.
        /// </summary>
        /// <summary>
        /// Gets the caller value.
        /// </summary>
        string Caller { get; }

        /// <summary>
        /// Gets the category value.
        /// </summary>
        /// <summary>
        /// Gets the category value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Category { get; }

        /// <summary>
        /// Gets the claims value.
        /// </summary>
        /// <summary>
        /// Gets the claims value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Claims { get; }

        /// <summary>
        /// Gets the correlationId value.
        /// </summary>
        /// <summary>
        /// Gets the correlationId value.
        /// </summary>
        string CorrelationId { get; }

        /// <summary>
        /// Gets the description value.
        /// </summary>
        /// <summary>
        /// Gets the description value.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the eventDataId value.
        /// </summary>
        /// <summary>
        /// Gets the eventDataId value.
        /// </summary>
        string EventDataId { get; }

        /// <summary>
        /// Gets the eventName value.
        /// </summary>
        /// <summary>
        /// Gets the eventName value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString EventName { get; }

        /// <summary>
        /// Gets the eventTimestamp value.
        /// </summary>
        /// <summary>
        /// Gets the eventTimestamp value.
        /// </summary>
        System.DateTime? EventTimestamp { get; }

        /// <summary>
        /// Gets the httpRequest value.
        /// </summary>
        /// <summary>
        /// Gets the httpRequest value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.HttpRequestInfo HttpRequest { get; }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the level value.
        /// </summary>
        /// <summary>
        /// Gets the level value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.EventLevel? Level { get; }

        /// <summary>
        /// Gets the operationId value.
        /// </summary>
        /// <summary>
        /// Gets the operationId value.
        /// </summary>
        string OperationId { get; }

        /// <summary>
        /// Gets the operationName value.
        /// </summary>
        /// <summary>
        /// Gets the operationName value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString OperationName { get; }

        /// <summary>
        /// Gets the properties value.
        /// </summary>
        /// <summary>
        /// Gets the properties value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get; }

        /// <summary>
        /// Gets the resourceGroupName value.
        /// </summary>
        /// <summary>
        /// Gets the resourceGroupName value.
        /// </summary>
        string ResourceGroupName { get; }

        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        string ResourceId { get; }

        /// <summary>
        /// Gets the resourceProviderName value.
        /// </summary>
        /// <summary>
        /// Gets the resourceProviderName value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString ResourceProviderName { get; }

        /// <summary>
        /// Gets the resourceType value.
        /// </summary>
        /// <summary>
        /// Gets the resourceType value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString ResourceType { get; }

        /// <summary>
        /// Gets the status value.
        /// </summary>
        /// <summary>
        /// Gets the status value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Status { get; }

        /// <summary>
        /// Gets the submissionTimestamp value.
        /// </summary>
        /// <summary>
        /// Gets the submissionTimestamp value.
        /// </summary>
        System.DateTime? SubmissionTimestamp { get; }

        /// <summary>
        /// Gets the subscriptionId value.
        /// </summary>
        /// <summary>
        /// Gets the subscriptionId value.
        /// </summary>
        string SubscriptionId { get; }

        /// <summary>
        /// Gets the subStatus value.
        /// </summary>
        /// <summary>
        /// Gets the subStatus value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString SubStatus { get; }

        /// <summary>
        /// Gets the tenantId value.
        /// </summary>
        /// <summary>
        /// Gets the tenantId value.
        /// </summary>
        string TenantId { get; }
    }
}