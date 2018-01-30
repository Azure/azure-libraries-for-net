// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    internal class EventDataImpl : Wrapper<EventDataInner>, IEventData
    {
        private ILocalizableString eventName;
        private ILocalizableString category;
        private ILocalizableString resourceProviderName;
        private ILocalizableString resourceType;
        private ILocalizableString operationName;
        private ILocalizableString status;
        private ILocalizableString subStatus;

        public EventDataImpl(EventDataInner innerObject)
            : base(innerObject)
        {
            this.eventName = (Inner.EventName == null) ? null : new LocalizableStringImpl(Inner.EventName);
            this.category = (Inner.Category == null) ? null : new LocalizableStringImpl(Inner.Category);
            this.resourceProviderName = (Inner.ResourceProviderName == null) ? null : new LocalizableStringImpl(Inner.ResourceProviderName);
            this.resourceType = (Inner.ResourceType == null) ? null : new LocalizableStringImpl(Inner.ResourceType);
            this.operationName = (Inner.OperationName == null) ? null : new LocalizableStringImpl(Inner.OperationName);
            this.status = (Inner.Status == null) ? null : new LocalizableStringImpl(Inner.Status);
            this.subStatus = (Inner.SubStatus == null) ? null : new LocalizableStringImpl(Inner.SubStatus);
        }

        public SenderAuthorization Authorization
        {
            get
            {
                return this.Inner.Authorization;
            }
        }

        public IReadOnlyDictionary<string, string> Claims
        {
            get
            {
                return (Dictionary<string, string>)this.Inner.Claims;
            }
        }

        public string Caller
        {
            get
            {
                return this.Inner.Caller;
            }
        }

        public string Description
        {
            get
            {
                return this.Inner.Description;
            }
        }

        public string Id
        {
            get
            {
                return this.Inner.Id;
            }
        }

        public string EventDataId
        {
            get
            {
                return this.Inner.EventDataId;
            }
        }

        public string CorrelationId
        {
            get
            {
                return this.Inner.CorrelationId;
            }
        }

        public ILocalizableString EventName
        {
            get
            {
                return this.eventName;
            }
        }

        public ILocalizableString Category
        {
            get
            {
                return this.category;
            }
        }

        public HttpRequestInfo HttpRequest
        {
            get
            {
                return this.Inner.HttpRequest;
            }
        }

        public EventLevel Level
        {
            get
            {
                return this.Inner.Level;
            }
        }

        public string ResourceGroupName
        {
            get
            {
                return this.Inner.ResourceGroupName;
            }
        }

        public ILocalizableString ResourceProviderName
        {
            get
            {
                return this.resourceProviderName;
            }
        }

        public string ResourceId
        {
            get
            {
                return this.Inner.ResourceId;
            }
        }

        public ILocalizableString ResourceType
        {
            get
            {
                return this.resourceType;
            }
        }

        public string OperationId
        {
            get
            {
                return this.Inner.OperationId;
            }
        }

        public ILocalizableString OperationName
        {
            get
            {
                return this.operationName;
            }
        }

        public IReadOnlyDictionary<string, string> Properties
        {
            get
            {
                return (Dictionary<string, string>)this.Inner.Properties;
            }
        }

        public ILocalizableString Status
        {
            get
            {
                return this.status;
            }
        }

        public ILocalizableString SubStatus
        {
            get
            {
                return this.subStatus;
            }
        }

        public DateTime EventTimestamp
        {
            get
            {
                return this.Inner.EventTimestamp;
            }
        }

        public DateTime SubmissionTimestamp
        {
            get
            {
                return this.Inner.SubmissionTimestamp;
            }
        }

        public string SubscriptionId
        {
            get
            {
                return this.Inner.SubscriptionId;
            }
        }

        public string TenantId
        {
            get
            {
                return this.Inner.TenantId;
            }
        }
    }
}
