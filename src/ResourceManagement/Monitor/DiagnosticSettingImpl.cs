// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.Monitor.Fluent;
    using Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.DiagnosticSetting.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Azure metric definition entries are of type DiagnosticSetting.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uRGlhZ25vc3RpY1NldHRpbmdJbXBs
    internal partial class DiagnosticSettingImpl :
            CreatableUpdatable<IDiagnosticSetting, DiagnosticSettingsResourceInner, DiagnosticSettingImpl, IHasId, IUpdate>,
        IDiagnosticSetting,
        IDefinition,
        IUpdate
    {
        internal static string DiagnosticSettingsUri = "/providers/microsoft.insights/diagnosticSettings/";

        private Dictionary<string, Microsoft.Azure.Management.Monitor.Fluent.Models.LogSettings> logSet;
        private Dictionary<string, Microsoft.Azure.Management.Monitor.Fluent.Models.MetricSettings> metricSet;
        private MonitorManager myManager;
        private string resourceId;


        ///GENMHASH:6D9B44965E58C7AF4C88C69BB9C414BF:C0E061407A15A42809F90D36822F65BD
        internal DiagnosticSettingImpl(string name, DiagnosticSettingsResourceInner innerModel, MonitorManager monitorManager)
            : base(name, innerModel)
        {
            this.myManager = monitorManager;
            InitializeSets();
        }

        ///GENMHASH:CAC45AF8408F49A1951116CE5A9CBD95:A50F87096DE64B7F5DB0058299BD1D9E
        private void InitializeSets()
        {
            if (this.metricSet == null)
            {
                this.metricSet = new Dictionary<string, MetricSettings>();
            }
            if (this.logSet == null)
            {
                this.logSet = new Dictionary<string, LogSettings>();
            }
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:4339F43F1B6F6582557A22ADE7A41E58
        protected async override Task<Microsoft.Azure.Management.Monitor.Fluent.Models.DiagnosticSettingsResourceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager().Inner.DiagnosticSettings.GetAsync(this.resourceId, this.Name, cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:C5F68195D0E808EBB9AE0E4E6169503D
        public async override Task<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Inner.Logs = logSet.Values.ToList();
            this.Inner.Metrics = metricSet.Values.ToList();
            SetInner(await this.Manager().Inner.DiagnosticSettings.CreateOrUpdateAsync(this.resourceId, this.Inner, this.Name, cancellationToken));
            return this;
        }

        ///GENMHASH:9AD65905834A40118BCCC1044E56DC9F:8F357D686C59E5640B3D44596D881E22
        public string EventHubAuthorizationRuleId()
        {
            return this.Inner.EventHubAuthorizationRuleId;
        }

        ///GENMHASH:5BE993289973437601F36360EECCC6F5:0F02B95851AA548925670494025242B5
        public string EventHubName()
        {
            return this.Inner.EventHubName;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:19C4BD8FCE58F39FC1CCEB1A6C862717
        public bool IsInCreateMode()
        {
            return this.Inner.Id == null;
        }

        ///GENMHASH:84462A2A9C3B6A6EBCEBE5817E7E5807:1AEFF9849C84922F5EE274F744F412B2
        public IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.LogSettings> Logs()
        {
            if (this.Inner.Logs == null)
            {
                return null;
            }
            return this.Inner.Logs.ToList();
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:363E4D62FCA795A36F9CB60513C86AFA
        public MonitorManager Manager()
        {
            return this.myManager;
        }

        ///GENMHASH:5E46449A7B51B1BC98D66C6A37EC1F02:A13FABF3D36822187ADA9B6BAF757E34
        public IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.Models.MetricSettings> Metrics()
        {
            if (this.Inner.Metrics == null)
            {
                return null;
            }
            return this.Inner.Metrics.ToList();
        }

        ///GENMHASH:FE2BD4F5F53442BA2A87A646EE3AE424:40517408F4384B3EDA6AA56CAE62AE2B
        public string ResourceId()
        {
            return this.resourceId;
        }

        ///GENMHASH:E4491E587BCDF31E1D90D9FF40BCACCA:277215C049DF2178E150ECB88DD37EA1
        public override void SetInner(DiagnosticSettingsResourceInner inner)
        {
            base.SetInner(inner);
            InitializeSets();
            this.metricSet.Clear();
            this.logSet.Clear();
            if (!IsInCreateMode())
            {
                this.resourceId = inner.Id.Substring(0,
                        this.Inner.Id.Length - (DiagnosticSettingImpl.DiagnosticSettingsUri + this.Inner.Name).Length);

                foreach (MetricSettings ms in this.Inner.Metrics)
                {
                    this.metricSet[ms.Category] = ms;
                }
                foreach (LogSettings ls in this.Inner.Logs)
                {
                    this.logSet[ls.Category] = ls;
                }
            }
        }

        ///GENMHASH:FD8ECACF00949BD4087A4104E8B18EA6:A94A07604F525DEB65BB3A6540EC6B18
        public string StorageAccountId()
        {
            return this.Inner.StorageAccountId;
        }

        ///GENMHASH:53A5F265E95CFD13FF10649BF0DD56B6:0CFB6D97063E05E2ED04383951357FF4
        public DiagnosticSettingImpl WithEventHub(string eventHubAuthorizationRuleId)
        {
            this.Inner.EventHubAuthorizationRuleId = eventHubAuthorizationRuleId;
            return this;
        }

        ///GENMHASH:C3A3AC10AF89F5B33FDF9B4B36D0C5A8:1CDB28B1AF5B7A5C41A682A041509B13
        public DiagnosticSettingImpl WithEventHub(string eventHubAuthorizationRuleId, string eventHubName)
        {
            this.WithEventHub(eventHubAuthorizationRuleId);
            this.Inner.EventHubName = eventHubName;
            return this;
        }

        ///GENMHASH:76FA3517E3D538A47738F14AD184E090:54EF59EFC9FBD535CE2A88AFAE86D0B6
        public DiagnosticSettingImpl WithLog(string category, int retentionDays)
        {
            this.logSet[category] = new LogSettings
            {
                Category = category,
                Enabled = true,
                RetentionPolicy = new RetentionPolicy
                {
                    Days = retentionDays,
                    Enabled = retentionDays > 0
                }
            };

            return this;
        }

        ///GENMHASH:DEE9B94824361410A89948B51270F636:2AEF7C7EAD6A713EEBD32D11DBD7956B
        public DiagnosticSettingImpl WithLogAnalytics(string workspaceId)
        {
            this.Inner.WorkspaceId = workspaceId;
            return this;
        }

        ///GENMHASH:32BD86F9B5A1FB18B4A5804F8A72C51F:BD595BDDFC52C1066A971D053AEC33D9
        public DiagnosticSettingImpl WithLogsAndMetrics(IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.Models.IDiagnosticSettingsCategory> categories, TimeSpan timeGrain, int retentionDays)
        {
            foreach (var dsc in categories)
            {
                if (dsc.Type == CategoryType.Metrics)
                {
                    this.WithMetric(dsc.Name, timeGrain, retentionDays);
                }
                else if (dsc.Type == CategoryType.Logs)
                {
                    this.WithLog(dsc.Name, retentionDays);
                }
                else
                {
                    throw new NotSupportedException(dsc.Type.ToString() + " is unsupported.");
                }
            }
            return this;
        }

        ///GENMHASH:F79BD378EAE710C5C9F371BF23C28227:52AC945F23176C57DC0BFF8106D87738
        public DiagnosticSettingImpl WithMetric(string category, TimeSpan timeGrain, int retentionDays)
        {
            this.metricSet[category] = new MetricSettings
            {
                Category = category,
                Enabled = true,
                TimeGrain = timeGrain,
                RetentionPolicy = new RetentionPolicy
                {
                    Days = retentionDays,
                    Enabled = retentionDays > 0
                }
            };
            return this;
        }

        ///GENMHASH:8F34CD935ED25D558A4C4D03BB646E68:0E9B8E9CBF554F51D21A3238842B522E
        public DiagnosticSettingImpl WithoutEventHub()
        {
            this.Inner.EventHubAuthorizationRuleId = null;
            this.Inner.EventHubName = null;
            return this;
        }

        ///GENMHASH:7455A8C3D212AB1D376FEEA3B84A261C:F9D1B8035ADCD5ED8E321E575BD63D41
        public DiagnosticSettingImpl WithoutLog(string category)
        {
            this.logSet.Remove(category);
            return this;
        }

        ///GENMHASH:BE74262D71E6342FDC4B2F1960EB5FFA:6FE64648BCDFE324BAB9D15001163B12
        public DiagnosticSettingImpl WithoutLogAnalytics()
        {
            this.Inner.WorkspaceId = null;
            return this;
        }

        ///GENMHASH:6AE250A350827A2E6ADD1B14BD75A646:DAE2442CC1A2A8237219726D3D061EEA
        public DiagnosticSettingImpl WithoutLogs()
        {
            this.logSet.Clear();
            return this;
        }

        ///GENMHASH:AC034166668930D77A1D314876795C9D:9020126CE2CBF5E75258E6DBD9386BD3
        public DiagnosticSettingImpl WithoutMetric(string category)
        {
            this.metricSet.Remove(category);
            return this;
        }

        ///GENMHASH:E80F15196FAF1E4F4C55CC1762EE0B8C:F97B71F53001939E52DF0D1472560037
        public DiagnosticSettingImpl WithoutMetrics()
        {
            this.metricSet.Clear();
            return this;
        }

        ///GENMHASH:15D36ECAB00E9FCCF84FA127687D0CE2:00EFA714EC4305A50B535598AE0963E0
        public DiagnosticSettingImpl WithoutStorageAccount()
        {
            this.Inner.StorageAccountId = null;
            return this;
        }

        ///GENMHASH:0581CFB67BA81AD8FEBB6B969597E080:652F835262202B064290DAC9EB805797
        public DiagnosticSettingImpl WithResource(string resourceId)
        {
            this.resourceId = resourceId;
            return this;
        }

        ///GENMHASH:34214CDA694B09312AB4062B1B86A083:528882B806456294A257879BDDA6D138
        public DiagnosticSettingImpl WithStorageAccount(string storageAccountId)
        {
            this.Inner.StorageAccountId = storageAccountId;

            return this;
        }

        ///GENMHASH:1A73E55BF9489C93F9341BEC00CCD925:9314CE069011E2DF6506FFD6550AF0FB
        public string WorkspaceId()
        {
            return this.Inner.WorkspaceId;
        }

        // catch up methods
        public override IUpdate Update()
        {
            return this;
        }
    }
}