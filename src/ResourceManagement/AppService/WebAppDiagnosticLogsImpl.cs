// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for WebAppDiagnosticLogs and its create and update interfaces.
    /// </summary>
    /// <typeparam name="FluentT">The fluent interface of the parent web app.</typeparam>
    /// <typeparam name="FluentImplT">The fluent implementation of the parent web app.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwRGlhZ25vc3RpY0xvZ3NJbXBs
    internal partial class WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> :
        IndexableWrapper<Models.SiteLogsConfigInner>,
        IWebAppDiagnosticLogs,
        WebAppDiagnosticLogs.Definition.IDefinition<IWithCreate<FluentT>>,
        IUpdateDefinition<WebAppBase.Update.IUpdate<FluentT>>
        where FluentImplT : WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, WebAppBase.Update.IUpdate<FluentT>
    {
        private LogLevel applicationLogLevel;
        private WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent;

        IWebAppBase IHasParent<IWebAppBase>.Parent => parent;

        ///GENMHASH:A874F3729AB077C5EF390CC63A3F30E2:AEC38C2D7C195C4FA0C12D9DBEC6444C
        internal  WebAppDiagnosticLogsImpl(SiteLogsConfigInner inner, WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent)
            : base(inner)
        {
            if (inner.ApplicationLogs != null) {
                inner.ApplicationLogs.AzureTableStorage = null;
            }
            this.parent = parent;
        }

        ///GENMHASH:640E49ECE11D905EE9279149E32B0E3C:3FC67826902933894B11C0ADE9F7ED15
        public LogLevel ApplicationLoggingFileSystemLogLevel()
        {
            if (Inner.ApplicationLogs == null
                || Inner.ApplicationLogs.FileSystem == null
                || Inner.ApplicationLogs.FileSystem.Level == null)
            {
                return LogLevel.Off;
            }
            else
            {
                return Inner.ApplicationLogs.FileSystem.Level.Value;
            }
        }

        ///GENMHASH:DF1D1F3518E219518D5CF955F655A9B8:00E2D31BD208E82AEA751C6142F22E6E
        public string ApplicationLoggingStorageBlobContainer()
        {
            if (Inner.ApplicationLogs == null || Inner.ApplicationLogs.AzureBlobStorage == null)
            {
                return null;
            }
            else
            {
                return Inner.ApplicationLogs.AzureBlobStorage.SasUrl;
            }
        }

        ///GENMHASH:BA212403E436A3A1E0FD9BC3583417BF:C26946CA05312D3FBBCFCCB1B66C16D0
        public LogLevel ApplicationLoggingStorageBlobLogLevel()
        {
            if (Inner.ApplicationLogs == null
                || Inner.ApplicationLogs.AzureBlobStorage == null
                || Inner.ApplicationLogs.AzureBlobStorage.Level == null)
            {
                return LogLevel.Off;
            }
            else
            {
                return Inner.ApplicationLogs.AzureBlobStorage.Level.Value;
            }
        }

        ///GENMHASH:138085714A711249FD08A63D789B7168:D88431B6604110BF0C650502C128F8E1
        public int ApplicationLoggingStorageBlobRetentionDays()
        {
            if (Inner.ApplicationLogs == null || Inner.ApplicationLogs.AzureBlobStorage == null || Inner.ApplicationLogs.AzureBlobStorage.RetentionInDays == null)
            {
                return 0;
            }
            else
            {
                return (int) Inner.ApplicationLogs.AzureBlobStorage.RetentionInDays;
            }
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:FE136D91D26FF654406776A4C5845948
        public FluentImplT Attach()
        {
            return parent.WithDiagnosticLogs(this);
        }

        ///GENMHASH:A6C3024A0F426DA6CF8B71DEF91E0C7E:9FE8762C1B9FACF15AB88DA1BF9597EC
        public bool DetailedErrorMessages()
        {
            return Inner.DetailedErrorMessages != null && Inner.DetailedErrorMessages.Enabled.HasValue && Inner.DetailedErrorMessages.Enabled.Value;
        }

        ///GENMHASH:34AF806990F25131F59A6070440823E0:A95CC561E4445BE3E7269A572A6BFCB2
        public bool FailedRequestsTracing()
        {
            return Inner.FailedRequestsTracing != null && Inner.FailedRequestsTracing.Enabled.HasValue && Inner.FailedRequestsTracing.Enabled.Value;
        }

        ///GENMHASH:ADA7023132C677B8E810845941E988DA:1964CEE67CCBAFF2114B8BBEF6D87DFA
        public int WebServerLoggingFileSystemQuotaInMB()
        {
            if (Inner.HttpLogs == null || Inner.HttpLogs.FileSystem == null || Inner.HttpLogs.FileSystem.RetentionInMb == null)
            {
                return 0;
            }
            else
            {
                return (int) Inner.HttpLogs.FileSystem.RetentionInMb;
            }
        }

        ///GENMHASH:067ABA00B1A007275866AF73D61E7EB0:5DF1EA4CDB988A732F7C6C250E93EF80
        public int WebServerLoggingFileSystemRetentionDays()
        {
            if (Inner.HttpLogs == null || Inner.HttpLogs.FileSystem == null || Inner.HttpLogs.FileSystem.RetentionInDays == null)
            {
                return 0;
            }
            else
            {
                return (int) Inner.HttpLogs.FileSystem.RetentionInDays;
            }
        }

        ///GENMHASH:4380C0F9DB8F7730F024F27525EABBA9:BDAEE1ED0012E446D0E3908E0C655613
        public string WebServerLoggingStorageBlobContainer()
        {
            if (Inner.HttpLogs == null || Inner.HttpLogs.AzureBlobStorage == null)
            {
                return null;
            }
            else
            {
                return Inner.HttpLogs.AzureBlobStorage.SasUrl;
            }
        }

        ///GENMHASH:FF54EEFFDD547C3BAF368E6F2BC0B4D0:8F71A055A516FBEE1E418778C94BFFA0
        public int WebServerLoggingStorageBlobRetentionDays()
        {
            if (Inner.HttpLogs == null || Inner.HttpLogs.AzureBlobStorage == null || Inner.HttpLogs.AzureBlobStorage.RetentionInDays == null)
            {
                return 0;
            }
            else
            {
                return (int) Inner.HttpLogs.AzureBlobStorage.RetentionInDays;
            }
        }

        ///GENMHASH:15135C1F5D2CD8350FC2B90B187EDE84:AA0B1A914CB4CA564701FB420E772E27
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithApplicationLogging()
        {
            Inner.ApplicationLogs = new ApplicationLogsConfig();
            return this;
        }

        ///GENMHASH:2ECCA6CF80BCF7658A648A571C2F7BF3:B467FF1F87E46050AB4C080D5E257D75
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithApplicationLogsStoredOnFileSystem()
        {
            if (Inner.ApplicationLogs != null)
            {
                Inner.ApplicationLogs.FileSystem = new FileSystemApplicationLogsConfig
                {
                    Level = applicationLogLevel
                };
            }
            return this;
        }

        ///GENMHASH:2D1384E8FA51443AAA0CBEE56F1F9161:5A0ED936D134ACF180A420BD545A4716
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithApplicationLogsStoredOnStorageBlob(string containerSasUrl)
        {
            if (Inner.ApplicationLogs != null)
            {
                Inner.ApplicationLogs.AzureBlobStorage = new AzureBlobStorageApplicationLogsConfig
                {
                    Level = applicationLogLevel,
                    SasUrl = containerSasUrl
                };
            }
            return this;
        }

        ///GENMHASH:9EBAFD920046C4740DBAEA42BD277594:9E7F221B795B1C3152BC026AA660D594
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithDetailedErrorMessages(bool enabled)
        {
            Inner.DetailedErrorMessages = new EnabledConfig
            {
                Enabled = enabled
            };
            return this;
        }

        ///GENMHASH:CBAB4BC6DF1639835F4596ACD46F146A:068C62910AA8ACCD48B4BA6F6904041E
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithFailedRequestTracing(bool enabled)
        {
            Inner.FailedRequestsTracing = new EnabledConfig
            {
                Enabled = enabled
            };
            return this;
        }

        ///GENMHASH:076D20B8AF8886B0F93ED62AB062F502:5B7EC9967CB8721E32E9BDA41F60BB0C
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithLogLevel(LogLevel logLevel)
        {
            this.applicationLogLevel = logLevel;
            return this;
        }

        ///GENMHASH:27B58505EB32F2C2A1069A5602161EB9:31DDB75D31D02F6E8C830CE7A9E778D3
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithLogRetentionDays(int retentionDays)
        {
            if (Inner.HttpLogs != null && Inner.HttpLogs.FileSystem != null && Inner.HttpLogs.FileSystem.Enabled.HasValue && Inner.HttpLogs.FileSystem.Enabled.Value)
            {
            Inner.HttpLogs.FileSystem.RetentionInDays = retentionDays;
            }
            if (Inner.HttpLogs != null && Inner.HttpLogs.AzureBlobStorage != null && Inner.HttpLogs.AzureBlobStorage.Enabled.HasValue && Inner.HttpLogs.AzureBlobStorage.Enabled.Value)
            {
            Inner.HttpLogs.AzureBlobStorage.RetentionInDays = retentionDays;
            }
            if (Inner.ApplicationLogs != null && Inner.ApplicationLogs.AzureBlobStorage != null && Inner.ApplicationLogs.AzureBlobStorage.Level.HasValue)
            {
                Inner.ApplicationLogs.AzureBlobStorage.RetentionInDays = retentionDays;
            }
            return this;
        }

        ///GENMHASH:452C636B060054B19120D7A982C0649D:52D79141FDEBD298AE8513041D2469F7
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutApplicationLogging()
        {
            WithoutApplicationLogsStoredOnFileSystem();
            WithoutApplicationLogsStoredOnStorageBlob();
            return this;
        }

        ///GENMHASH:C837B719BB763297B65FCAA693E77F40:8C9B01E3467F4A88E6F93FA6BD776EF2
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutApplicationLogsStoredOnFileSystem()
        {
            if (Inner.ApplicationLogs != null && Inner.ApplicationLogs.FileSystem != null)
            {
                Inner.ApplicationLogs.FileSystem.Level = LogLevel.Off;
            }
            return this;
        }

        ///GENMHASH:C32A2DA398B0223CB3C25743147A346E:4E9B6CB1DA6A4C3D726237EB6101C250
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutApplicationLogsStoredOnStorageBlob()
        {
            if (Inner.ApplicationLogs != null && Inner.ApplicationLogs.AzureBlobStorage != null)
            {
                Inner.ApplicationLogs.AzureBlobStorage.Level = LogLevel.Off;
            }
            return this;
        }

        ///GENMHASH:59DF92DA011A82A4DC9228B8304644B4:D2F5C9DE85C86DA5508E63A0C377A1E8
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutWebServerLogging()
        {
            WithoutWebServerLogsStoredOnFileSystem();
            WithoutWebServerLogsStoredOnStorageBlob();
            return this;
        }

        ///GENMHASH:E13FA93DDF55EB08430E61891ACC6B9A:D6DC84B0700E4DC053A5C67280BEAC10
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutWebServerLogsStoredOnFileSystem()
        {
            if (Inner.HttpLogs != null && Inner.HttpLogs.FileSystem != null)
            {
                Inner.HttpLogs.FileSystem.Enabled = false;
            }
            return this;
        }

        ///GENMHASH:CF3F55940F39CAC85C5BE54BDBF115CE:CF7750415ED20DECE355690C74FBB95D
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutWebServerLogsStoredOnStorageBlob()
        {
            if (Inner.HttpLogs != null && Inner.HttpLogs.AzureBlobStorage != null)
            {
                Inner.HttpLogs.AzureBlobStorage.Enabled = true;
            }
            return this;
        }

        ///GENMHASH:0AA703FD4D7171D9DD761057420590D4:57E8D27F0D0112D8FDF8632C55262083
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithUnlimitedLogRetentionDays()
        {
            if (Inner.HttpLogs != null && Inner.HttpLogs.FileSystem != null && Inner.HttpLogs.FileSystem.Enabled.HasValue && Inner.HttpLogs.FileSystem.Enabled.Value)
            {
                Inner.HttpLogs.FileSystem.RetentionInDays = 0;
            }
            if (Inner.HttpLogs != null && Inner.HttpLogs.AzureBlobStorage != null && Inner.HttpLogs.FileSystem.Enabled.HasValue && Inner.HttpLogs.FileSystem.Enabled.Value)
            {
                Inner.HttpLogs.AzureBlobStorage.RetentionInDays = 0;
            }
            if (Inner.ApplicationLogs != null && Inner.ApplicationLogs.AzureBlobStorage != null && Inner.ApplicationLogs.AzureBlobStorage.Level.HasValue)
            {
                Inner.ApplicationLogs.AzureBlobStorage.RetentionInDays = 0;
            }
            return this;
        }

        ///GENMHASH:6779E4B38BCBB810944CA68774B310C3:072E24F1A9FC72304BBE1ED245652D70
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithWebServerFileSystemQuotaInMB(int quotaInMB)
        {
            if (Inner.HttpLogs != null && Inner.HttpLogs.FileSystem != null && Inner.HttpLogs.FileSystem.Enabled.HasValue && Inner.HttpLogs.FileSystem.Enabled.Value)
            {
                Inner.HttpLogs.FileSystem.RetentionInMb = quotaInMB;
            }
            return this;
        }

        ///GENMHASH:7CF59D3DACD72ACA92253758D23178BA:6A3A214E822090F293BA8EB6EA24B70D
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithWebServerLogging()
        {
            Inner.HttpLogs = new HttpLogsConfig();
            return this;
        }

        ///GENMHASH:ECADC1490C060E360662B47F64D697D7:39A92D1755BC701B4187BAC4466E663A
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithWebServerLogsStoredOnFileSystem()
        {
            if (Inner.HttpLogs != null)
            {
                Inner.HttpLogs.FileSystem = new FileSystemHttpLogsConfig
                {
                    Enabled = true
                };
            }
            return this;
        }

        ///GENMHASH:275EB20CC4AF95A4E8E3E4AC00B5944A:1DD740D5F021AFB813284B33709A769C
        public WebAppDiagnosticLogsImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithWebServerLogsStoredOnStorageBlob(string containerSasUrl)
        {
            if (Inner.HttpLogs != null)
            {
                Inner.HttpLogs.AzureBlobStorage =
                new AzureBlobStorageHttpLogsConfig
                {
                    Enabled = true,
                    SasUrl = containerSasUrl
                };
            }
            return this;
        }
    }
}