// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    internal partial class EventDataImpl
    {
        /// <summary>
        /// Gets the authorization value.
        /// </summary>
        /// <summary>
        /// Gets the authorization value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.SenderAuthorization Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Authorization
        {
            get
            {
                return this.Authorization();
            }
        }

        /// <summary>
        /// Gets the caller value.
        /// </summary>
        /// <summary>
        /// Gets the caller value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Caller
        {
            get
            {
                return this.Caller();
            }
        }

        /// <summary>
        /// Gets the category value.
        /// </summary>
        /// <summary>
        /// Gets the category value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Category
        {
            get
            {
                return this.Category();
            }
        }

        /// <summary>
        /// Gets the claims value.
        /// </summary>
        /// <summary>
        /// Gets the claims value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Claims
        {
            get
            {
                return this.Claims();
            }
        }

        /// <summary>
        /// Gets the correlationId value.
        /// </summary>
        /// <summary>
        /// Gets the correlationId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.CorrelationId
        {
            get
            {
                return this.CorrelationId();
            }
        }

        /// <summary>
        /// Gets the description value.
        /// </summary>
        /// <summary>
        /// Gets the description value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Description
        {
            get
            {
                return this.Description();
            }
        }

        /// <summary>
        /// Gets the eventDataId value.
        /// </summary>
        /// <summary>
        /// Gets the eventDataId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.EventDataId
        {
            get
            {
                return this.EventDataId();
            }
        }

        /// <summary>
        /// Gets the eventName value.
        /// </summary>
        /// <summary>
        /// Gets the eventName value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.EventName
        {
            get
            {
                return this.EventName();
            }
        }

        /// <summary>
        /// Gets the eventTimestamp value.
        /// </summary>
        /// <summary>
        /// Gets the eventTimestamp value.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.EventTimestamp
        {
            get
            {
                return this.EventTimestamp();
            }
        }

        /// <summary>
        /// Gets the httpRequest value.
        /// </summary>
        /// <summary>
        /// Gets the httpRequest value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.HttpRequestInfo Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.HttpRequest
        {
            get
            {
                return this.HttpRequest();
            }
        }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the level value.
        /// </summary>
        /// <summary>
        /// Gets the level value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.EventLevel? Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Level
        {
            get
            {
                return this.Level();
            }
        }

        /// <summary>
        /// Gets the operationId value.
        /// </summary>
        /// <summary>
        /// Gets the operationId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.OperationId
        {
            get
            {
                return this.OperationId();
            }
        }

        /// <summary>
        /// Gets the operationName value.
        /// </summary>
        /// <summary>
        /// Gets the operationName value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.OperationName
        {
            get
            {
                return this.OperationName();
            }
        }

        /// <summary>
        /// Gets the properties value.
        /// </summary>
        /// <summary>
        /// Gets the properties value.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Properties
        {
            get
            {
                return this.Properties();
            }
        }

        /// <summary>
        /// Gets the resourceGroupName value.
        /// </summary>
        /// <summary>
        /// Gets the resourceGroupName value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        /// <summary>
        /// Gets the resourceId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.ResourceId
        {
            get
            {
                return this.ResourceId();
            }
        }

        /// <summary>
        /// Gets the resourceProviderName value.
        /// </summary>
        /// <summary>
        /// Gets the resourceProviderName value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.ResourceProviderName
        {
            get
            {
                return this.ResourceProviderName();
            }
        }

        /// <summary>
        /// Gets the resourceType value.
        /// </summary>
        /// <summary>
        /// Gets the resourceType value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.ResourceType
        {
            get
            {
                return this.ResourceType();
            }
        }

        /// <summary>
        /// Gets the status value.
        /// </summary>
        /// <summary>
        /// Gets the status value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the submissionTimestamp value.
        /// </summary>
        /// <summary>
        /// Gets the submissionTimestamp value.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.SubmissionTimestamp
        {
            get
            {
                return this.SubmissionTimestamp();
            }
        }

        /// <summary>
        /// Gets the subscriptionId value.
        /// </summary>
        /// <summary>
        /// Gets the subscriptionId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.SubscriptionId
        {
            get
            {
                return this.SubscriptionId();
            }
        }

        /// <summary>
        /// Gets the subStatus value.
        /// </summary>
        /// <summary>
        /// Gets the subStatus value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.ILocalizableString Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.SubStatus
        {
            get
            {
                return this.SubStatus();
            }
        }

        /// <summary>
        /// Gets the tenantId value.
        /// </summary>
        /// <summary>
        /// Gets the tenantId value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IEventData.TenantId
        {
            get
            {
                return this.TenantId();
            }
        }
    }
}