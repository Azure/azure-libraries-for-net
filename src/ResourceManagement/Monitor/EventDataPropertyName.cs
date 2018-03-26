// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    /// <summary>
    /// Defines values for EventDataPropertyName.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuRXZlbnREYXRhUHJvcGVydHlOYW1l
    public sealed partial class EventDataPropertyName : ExpandableStringEnum<EventDataPropertyName>
    {
        public static readonly EventDataPropertyName Authorization = Parse("authorization");
        public static readonly EventDataPropertyName Claims = Parse("claims");
        public static readonly EventDataPropertyName CorrelationId = Parse("correlationId");
        public static readonly EventDataPropertyName Description = Parse("description");
        public static readonly EventDataPropertyName EventDataId = Parse("eventDataId");
        public static readonly EventDataPropertyName EventName = Parse("eventName");
        public static readonly EventDataPropertyName EventTimestamp = Parse("eventTimestamp");
        public static readonly EventDataPropertyName HttpRequest = Parse("httpRequest");
        public static readonly EventDataPropertyName Level = Parse("level");
        public static readonly EventDataPropertyName OperationId = Parse("operationId");
        public static readonly EventDataPropertyName OperationName = Parse("operationName");
        public static readonly EventDataPropertyName Properties = Parse("properties");
        public static readonly EventDataPropertyName ResourceGroupName = Parse("resourceGroupName");
        public static readonly EventDataPropertyName ResourceProviderName = Parse("resourceProviderName");
        public static readonly EventDataPropertyName ResourceId = Parse("resourceId");
        public static readonly EventDataPropertyName Status = Parse("status");
        public static readonly EventDataPropertyName SubmissionTimestamp = Parse("submissionTimestamp");
        public static readonly EventDataPropertyName SubStatus = Parse("subStatus");
        public static readonly EventDataPropertyName SubscriptionId = Parse("subscriptionId");
    }
}
