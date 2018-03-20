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
        Wrapper<Microsoft.Azure.Management.Monitor.Fluent.Models.EventDataInner>,
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
        internal EventDataImpl(EventDataInner innerObject)
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

        ///GENMHASH:75A24615E0F3B49CA6A8676D0E97F051:EE22C0BA057EA06554EC650E1ED7DE94
        public SenderAuthorization Authorization()
        {
            return this.Inner.Authorization;
        }

        ///GENMHASH:BDFB6D34DA7DA4BBB34E6085AEFA0B7B:970EC97BFBDFB0BE3A85469293527519
        public string Caller()
        {
            return this.Inner.Caller;
        }

        ///GENMHASH:70DABADB95F2B7BB813E71268028E9B4:A6C1F6A45BDFA724A05C13E771468252
        public ILocalizableString Category()
        {
            return this.category;
        }

        ///GENMHASH:94E5830694E58A1DED21BEC55AFB3B4F:8BC04A579DF46E4BCE02E2CE57EA24DF
        public IReadOnlyDictionary<string, string> Claims()
        {
            return (Dictionary<string, string>)this.Inner.Claims;
        }

        ///GENMHASH:114F5D18E97B7C84662DDD601D3C7CCB:35F10347D0C87C6C23D9B7D25C35906C
        public string CorrelationId()
        {
            return this.Inner.CorrelationId;
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:7695E7B72747642402D7878F2C30B7C4
        public string Description()
        {
            return this.Inner.Description;
        }

        ///GENMHASH:AC10DDF949411944E83259E405F3DD26:68B9FFB8E82E2D5545690EDFD98404B4
        public string EventDataId()
        {
            return this.Inner.EventDataId;
        }

        ///GENMHASH:D7F3652E26573D18DD056442DF88C504:367230DCF85F9730292B52A86DC1D3C2
        public ILocalizableString EventName()
        {
            return this.eventName;
        }

        ///GENMHASH:B0EE4B1A29D7F12AFDE925EBAAD217AB:2F600EA8D4BA66CAD0C3C847FBE3303D
        public DateTime? EventTimestamp()
        {
            return this.Inner.EventTimestamp;
        }

        ///GENMHASH:8C4C7136F1967E04A93B8491B1DB483F:247B6EFD87B6590D5CD4BAF0A70D9FB1
        public HttpRequestInfo HttpRequest()
        {
            return this.Inner.HttpRequest;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:0F9B233590D7C7BD29A15401FB74B3D2
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:CDB75282F99C92A566E39254F670EF12:750A34FFE2B819BF8D6016203CD94837
        public EventLevel? Level()
        {
            return this.Inner.Level;
        }

        ///GENMHASH:03526126BC38B1E6BD9561737558EC5D:ECA52246B13DA58A596F735642459A0C
        public string OperationId()
        {
            return this.Inner.OperationId;
        }

        ///GENMHASH:B04FD125F3C782E454493E34FE36D640:56B70D408C76B65391723E80354BD945
        public ILocalizableString OperationName()
        {
            return this.operationName;
        }

        ///GENMHASH:8B7516D588FD59CC5DE9546ABF50D1A7:BF2F2DC34CC8A58C00DC43882B955FF1
        public IReadOnlyDictionary<string, string> Properties()
        {
            return (Dictionary<string, string>)this.Inner.Properties;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:A0876ACA2D44CD290BF5E9E851703A74
        public string ResourceGroupName()
        {
            return this.Inner.ResourceGroupName;
        }

        ///GENMHASH:FE2BD4F5F53442BA2A87A646EE3AE424:5FC58B52A5BD20F01C4DD6D0E5DD85E2
        public string ResourceId()
        {
            return this.Inner.ResourceId;
        }

        ///GENMHASH:98F104D2D969C4E159C012F3A443C17A:3D5C5C46204AC1ECBDDB8A670AD35D58
        public ILocalizableString ResourceProviderName()
        {
            return this.resourceProviderName;
        }

        ///GENMHASH:EC2A5EE0E9C0A186CA88677B91632991:CE470B970499BD719175685810781168
        public ILocalizableString ResourceType()
        {
            return this.resourceType;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:D0CC10C6B358E77BAA9BBA8BE68B1545
        public ILocalizableString Status()
        {
            return this.status;
        }

        ///GENMHASH:63C6597045C6A60307C99B0B5B137474:156219751FD9A5A583075622C28EB9D5
        public DateTime? SubmissionTimestamp()
        {
            return this.Inner.SubmissionTimestamp;
        }

        ///GENMHASH:561EEE43F415BCC5A5C6A30A1481AA8F:EA3B58E99550C4E27B91AC254902C858
        public string SubscriptionId()
        {
            return this.Inner.SubscriptionId;
        }

        ///GENMHASH:17C335645917D6833B7BB81C4F7E3332:29A0ECA85F17B689A9766D2EECDC2BCE
        public ILocalizableString SubStatus()
        {
            return this.subStatus;
        }

        ///GENMHASH:DA183CCEBC00D21096D59D1B439F4E2F:111A2D1062AE7B0AB09421D902294418
        public string TenantId()
        {
            return this.Inner.TenantId;
        }
    }
}