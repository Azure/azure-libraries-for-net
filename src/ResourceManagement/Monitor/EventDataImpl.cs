// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Azure  EventData wrapper class implementation.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uRXZlbnREYXRhSW1wbA==
    internal partial class EventDataImpl :
        Wrapper<Microsoft.Azure.Management.Monitor.Fluent.Models.EventData>,
        IEventData
    {
        private ILocalizableString category;
        private ILocalizableString eventName;
        private ILocalizableString operationName;
        private ILocalizableString resourceProviderName;
        private ILocalizableString resourceType;
        private ILocalizableString status;
        private ILocalizableString subStatus;

        ///GENMHASH:E7A1E750B60FCE79425B3D6049E0E016:1AB861CF0BBC22AC4D9C061C5ABBB4D0
        internal EventDataImpl(EventData innerObject)
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

        ///GENMHASH:75A24615E0F3B49CA6A8676D0E97F051:13798DD034C5BD4911A6D0AA5A7BA8CB
        public SenderAuthorization Authorization()
        {
            return this.Inner.Authorization;
        }

        ///GENMHASH:BDFB6D34DA7DA4BBB34E6085AEFA0B7B:7A7184B8ACDED8482C098E682F6AE974
        public string Caller()
        {
            return this.Inner.Caller;
        }

        ///GENMHASH:70DABADB95F2B7BB813E71268028E9B4:877760306639D3154348C6F900ABBDA9
        public ILocalizableString Category()
        {
            return this.category;
        }

        ///GENMHASH:94E5830694E58A1DED21BEC55AFB3B4F:10D1BE3F743591248547336B3271E0F0
        public IReadOnlyDictionary<string, string> Claims()
        {
            return (Dictionary<string, string>)this.Inner.Claims;
        }

        ///GENMHASH:114F5D18E97B7C84662DDD601D3C7CCB:CF192857F7EC7833B3A4505027850604
        public string CorrelationId()
        {
            return this.Inner.CorrelationId;
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        public string Description()
        {
            return this.Inner.Description;
        }

        ///GENMHASH:AC10DDF949411944E83259E405F3DD26:4016F256B801C8B3871B8F45071573D1
        public string EventDataId()
        {
            return this.Inner.EventDataId;
        }

        ///GENMHASH:D7F3652E26573D18DD056442DF88C504:FC9EE47DB6261A57CF35814940B2AE25
        public ILocalizableString EventName()
        {
            return this.eventName;
        }

        ///GENMHASH:B0EE4B1A29D7F12AFDE925EBAAD217AB:30A5C355001E8F512B0B99130F779F91
        public DateTime? EventTimestamp()
        {
            return this.Inner.EventTimestamp;
        }

        ///GENMHASH:8C4C7136F1967E04A93B8491B1DB483F:1BE0D38E80BBBD0B4A75E38036DF2E67
        public HttpRequestInfo HttpRequest()
        {
            return this.Inner.HttpRequest;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:CDB75282F99C92A566E39254F670EF12:9FAE75E920E3F72AB54825C7B6562D8A
        public EventLevel? Level()
        {
            return this.Inner.Level;
        }

        ///GENMHASH:03526126BC38B1E6BD9561737558EC5D:BA5AF11F0F62FFF9B79F496BD38C3EB8
        public string OperationId()
        {
            return this.Inner.OperationId;
        }

        ///GENMHASH:B04FD125F3C782E454493E34FE36D640:D679D70A87002B0F2F6C4B0666049140
        public ILocalizableString OperationName()
        {
            return this.operationName;
        }

        ///GENMHASH:8B7516D588FD59CC5DE9546ABF50D1A7:E4F4E9AF14BA313DA3DB47987A06E03A
        public IReadOnlyDictionary<string, string> Properties()
        {
            return (Dictionary<string, string>)this.Inner.Properties;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:211841A807B95532F04811AD222AA27C
        public string ResourceGroupName()
        {
            return this.Inner.ResourceGroupName;
        }

        ///GENMHASH:FE2BD4F5F53442BA2A87A646EE3AE424:51F7E88BFD41C47C36267D4E53495034
        public string ResourceId()
        {
            return this.Inner.ResourceId;
        }

        ///GENMHASH:98F104D2D969C4E159C012F3A443C17A:6F378D1581367437F149C43E08584D46
        public ILocalizableString ResourceProviderName()
        {
            return this.resourceProviderName;
        }

        ///GENMHASH:EC2A5EE0E9C0A186CA88677B91632991:51AF68C451AEBFCBB280D581D91D6090
        public ILocalizableString ResourceType()
        {
            return this.resourceType;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:AFF65BBEC65801ED4524201A5662CEC8
        public ILocalizableString Status()
        {
            return this.status;
        }

        ///GENMHASH:63C6597045C6A60307C99B0B5B137474:3165183083D8B9B4FEB73A55F57C14BB
        public DateTime? SubmissionTimestamp()
        {
            return this.Inner.SubmissionTimestamp;
        }

        ///GENMHASH:561EEE43F415BCC5A5C6A30A1481AA8F:8B18E79E4871300D4A416377C9863124
        public string SubscriptionId()
        {
            return this.Inner.SubscriptionId;
        }

        ///GENMHASH:17C335645917D6833B7BB81C4F7E3332:F9DAFB4C0FE2E51A5B32CB76B0F893F8
        public ILocalizableString SubStatus()
        {
            return this.subStatus;
        }

        ///GENMHASH:DA183CCEBC00D21096D59D1B439F4E2F:8FF52B733A2C5D11C34524C2CCD75FB0
        public string TenantId()
        {
            return this.Inner.TenantId;
        }
    }
}