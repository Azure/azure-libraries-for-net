// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition;
    using Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// Implementation for ActionGroup.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQWN0aW9uR3JvdXBJbXBs
    internal partial class ActionGroupImpl :
        GroupableResource<
            IActionGroup,
            ActionGroupResourceInner,
            ActionGroupImpl,
            IMonitorManager,
            ActionGroup.Definition.IBlank,
            ActionGroup.Definition.IWithCreate,
            ActionGroup.Definition.IWithCreate,
            ActionGroup.Update.IUpdate>,
        IActionGroup,
        IDefinition,
        IActionDefinition<ActionGroup.Definition.IWithCreate>,
        IActionDefinition<ActionGroup.Update.IUpdate>,
        IUpdate,
        IWithActionUpdateDefinition
    {
        private string actionReceiverPrefix;
        private Dictionary<string, Models.AzureAppPushReceiver> appActionReceivers;
        private static readonly string appActionSuffix = "_-AzureAppAction-";
        private IDictionary<string, Models.EmailReceiver> emailReceivers;
        private static readonly string emailSuffix = "_-EmailAction-";
        private Dictionary<string, Models.AzureFunctionReceiver> functionReceivers;
        private static readonly string functionSuffix = " (F)";
        private Dictionary<string, Models.ItsmReceiver> itsmReceivers;
        private static readonly string itsmSuffix = " (ITSM)";
        private Dictionary<string, Models.LogicAppReceiver> logicReceivers;
        private static readonly string logicSuffix = " (LA)";
        private Dictionary<string, Models.AutomationRunbookReceiver> runBookReceivers;
        private static readonly string runBookSuffix = " (RB)";
        private Dictionary<string, Models.SmsReceiver> smsReceivers;
        private static readonly string smsSuffix = "_-SMSAction-";
        private Dictionary<string, Models.VoiceReceiver> voiceReceivers;
        private static readonly string voiceSuffix = "_-VoiceAction-";
        private Dictionary<string, Models.WebhookReceiver> webhookReceivers;
        private static readonly string webhookSuffix = " (WH)";

        ///GENMHASH:41BEC53C7D3065426CE12D60045E5A76:62D1D1E233FE3541B287099A447FD5C1
        internal ActionGroupImpl(string name, ActionGroupResourceInner innerModel, IMonitorManager monitorManager)
            : base(name, innerModel, monitorManager)
        {
            this.actionReceiverPrefix = "";
            this.emailReceivers = new Dictionary<string, Models.EmailReceiver>();
            this.smsReceivers = new Dictionary<string, Models.SmsReceiver>();
            this.appActionReceivers = new Dictionary<string, Models.AzureAppPushReceiver>();
            this.voiceReceivers = new Dictionary<string, Models.VoiceReceiver>();
            this.runBookReceivers = new Dictionary<string, Models.AutomationRunbookReceiver>();
            this.logicReceivers = new Dictionary<string, Models.LogicAppReceiver>();
            this.functionReceivers = new Dictionary<string, Models.AzureFunctionReceiver>();
            this.webhookReceivers = new Dictionary<string, Models.WebhookReceiver>();
            this.itsmReceivers = new Dictionary<string, Models.ItsmReceiver>();
            if (this.IsInCreateMode)
            {
                this.Inner.Enabled = true;
                this.Inner.GroupShortName = this.Name.Substring(0, (this.Name.Length > 12) ? 12 : this.Name.Length);
            }
            else
            {
                this.WithExistingResourceGroup(ResourceUtils.GroupFromResourceId(this.Id));
            }

        }

        ///GENMHASH:9E5F28984A8DFC9234E431D86BD1C98B:446E17035C92AA884C492FD3B42DF222
        private void PopulateReceivers()
        {
            if (this.emailReceivers.Values.Any())
            {
                if (this.Inner.EmailReceivers == null)
                {
                    this.Inner.EmailReceivers = new List<EmailReceiver>();
                }
                else
                {
                    this.Inner.EmailReceivers.Clear();
                }
                ((List<EmailReceiver>)this.Inner.EmailReceivers).AddRange(this.emailReceivers.Values);
            }
            else
            {
                this.Inner.EmailReceivers = null;
            }

            if (this.smsReceivers.Values.Any())
            {
                if (this.Inner.SmsReceivers == null)
                {
                    this.Inner.SmsReceivers = new List<SmsReceiver>();
                }
                else
                {
                    this.Inner.SmsReceivers.Clear();
                }
                ((List<SmsReceiver>)this.Inner.SmsReceivers).AddRange(this.smsReceivers.Values);
            }
            else
            {
                this.Inner.SmsReceivers = null;
            }

            if (this.appActionReceivers.Values.Any())
            {
                if (this.Inner.AzureAppPushReceivers == null)
                {
                    this.Inner.AzureAppPushReceivers = new List<AzureAppPushReceiver>();
                }
                else
                {
                    this.Inner.AzureAppPushReceivers.Clear();
                }
                ((List<AzureAppPushReceiver>)this.Inner.AzureAppPushReceivers).AddRange(this.appActionReceivers.Values);
            }
            else
            {
                this.Inner.AzureAppPushReceivers = null;
            }

            if (this.voiceReceivers.Values.Any())
            {
                if (this.Inner.VoiceReceivers == null)
                {
                    this.Inner.VoiceReceivers = new List<VoiceReceiver>();
                }
                else
                {
                    this.Inner.VoiceReceivers.Clear();
                }
                ((List<VoiceReceiver>)this.Inner.VoiceReceivers).AddRange(this.voiceReceivers.Values);
            }
            else
            {
                this.Inner.VoiceReceivers = null;
            }

            if (this.runBookReceivers.Values.Any())
            {
                if (this.Inner.AutomationRunbookReceivers == null)
                {
                    this.Inner.AutomationRunbookReceivers = new List<AutomationRunbookReceiver>();
                }
                else
                {
                    this.Inner.AutomationRunbookReceivers.Clear();
                }
                ((List<AutomationRunbookReceiver>)this.Inner.AutomationRunbookReceivers).AddRange(this.runBookReceivers.Values);
            }
            else
            {
                this.Inner.AutomationRunbookReceivers = null;
            }

            if (this.logicReceivers.Values.Any())
            {
                if (this.Inner.LogicAppReceivers == null)
                {
                    this.Inner.LogicAppReceivers = new List<LogicAppReceiver>();
                }
                else
                {
                    this.Inner.LogicAppReceivers.Clear();
                }
                ((List<LogicAppReceiver>)this.Inner.LogicAppReceivers).AddRange(this.logicReceivers.Values);
            }
            else
            {
                this.Inner.LogicAppReceivers = null;
            }

            if (this.functionReceivers.Values.Any())
            {
                if (this.Inner.AzureFunctionReceivers == null)
                {
                    this.Inner.AzureFunctionReceivers = new List<AzureFunctionReceiver>();
                }
                else
                {
                    this.Inner.AzureFunctionReceivers.Clear();
                }
                ((List<AzureFunctionReceiver>)this.Inner.AzureFunctionReceivers).AddRange(this.functionReceivers.Values);
            }
            else
            {
                this.Inner.AzureFunctionReceivers = null;
            }

            if (this.webhookReceivers.Values.Any())
            {
                if (this.Inner.WebhookReceivers == null)
                {
                    this.Inner.WebhookReceivers = new List<WebhookReceiver>();
                }
                else
                {
                    this.Inner.WebhookReceivers.Clear();
                }
                ((List<WebhookReceiver>)this.Inner.WebhookReceivers).AddRange(this.webhookReceivers.Values);
            }
            else
            {
                this.Inner.WebhookReceivers = null;
            }

            if (this.itsmReceivers.Values.Any())
            {
                if (this.Inner.ItsmReceivers == null)
                {
                    this.Inner.ItsmReceivers = new List<ItsmReceiver>();
                }
                else
                {
                    this.Inner.ItsmReceivers.Clear();
                }
                ((List<ItsmReceiver>)this.Inner.ItsmReceivers).AddRange(this.itsmReceivers.Values);
            }
            else
            {
                this.Inner.ItsmReceivers = null;
            }
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:11B66B97304A7DE4AC2AA17C7BBBF58D
        protected async override Task<Models.ActionGroupResourceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.ActionGroups.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:2E02F656F74847E8C999282F87DB8F0C
        public ActionGroupImpl Attach()
        {
            this.actionReceiverPrefix = "";
            PopulateReceivers();

            this.emailReceivers.Clear();
            this.smsReceivers.Clear();
            this.appActionReceivers.Clear();
            this.voiceReceivers.Clear();
            this.runBookReceivers.Clear();
            this.logicReceivers.Clear();
            this.functionReceivers.Clear();
            this.webhookReceivers.Clear();
            this.itsmReceivers.Clear();

            return this;
        }

        ///GENMHASH:4554BAEED7C5456CD1392AC46A0B427A:7E3390262271B97BF99FF716DE6906CB
        public IReadOnlyList<Models.AutomationRunbookReceiver> AutomationRunbookReceivers()
        {
            return this.Inner.AutomationRunbookReceivers.ToList();
        }

        ///GENMHASH:F13477E0BE1CCD7BAB34590248147ECB:27202ABC1F2C4E8A5A7A5A906C995A45
        public IReadOnlyList<Models.AzureFunctionReceiver> AzureFunctionReceivers()
        {
            return this.Inner.AzureFunctionReceivers.ToList();
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:E9540F4E2DD531C67CBC49D5ECC9158E
        public async override Task<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Inner.Location = "global";
            this.SetInner(await this.Manager.Inner.ActionGroups.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken));

            return this;
        }

        ///GENMHASH:2D5550FE29FD7200AB73B6351C2A661F:7692C7C7A43C2D3C31B341647F5EF686
        public ActionGroupImpl DefineReceiver(string actionNamePrefix)
        {
            return this.UpdateReceiver(actionNamePrefix);
        }

        ///GENMHASH:9C68A5DA80262C0E546F50E0A2C847B2:50461EBCEEC10788CCE50D23AA972083
        public IReadOnlyList<Models.EmailReceiver> EmailReceivers()
        {
            return this.Inner.EmailReceivers.ToList();
        }

        ///GENMHASH:7276AF4A233B2F0954BFD4C0ECF6D58B:C504382627430A3EBC6E30E4A95CDAA7
        public IReadOnlyList<Models.ItsmReceiver> ItsmReceivers()
        {
            return this.Inner.ItsmReceivers.ToList();
        }

        ///GENMHASH:5F82E93293F5ABE15BC634DD253CAC89:2CAE2F5BEC1E5646870E0372A9D6A879
        public IReadOnlyList<Models.LogicAppReceiver> LogicAppReceivers()
        {
            return this.Inner.LogicAppReceivers.ToList();
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:E2EB59B5370CEE812A6D8ECA69BFB7D1
        public ActionGroupImpl Parent()
        {
            return this.Attach();
        }

        ///GENMHASH:1DDC53CFDF25A285EC0454044DCD1675:701818A6DF18068BF950BC2079562345
        public IReadOnlyList<Models.AzureAppPushReceiver> PushNotificationReceivers()
        {
            return this.Inner.AzureAppPushReceivers.ToList();
        }

        ///GENMHASH:50EA7681E35A3BDC55F7BBB87F8D9E44:2D4F3E96DFE47F8BC60B3BF071B7170D
        public string ShortName()
        {
            return this.Inner.GroupShortName;
        }

        ///GENMHASH:E9156B2826244EC8242E603AFC88AF52:229D31FAC7AA64177AAC909D4DBD860D
        public IReadOnlyList<Models.SmsReceiver> SmsReceivers()
        {
            return this.Inner.SmsReceivers.ToList();
        }

        ///GENMHASH:F159BED05CA2232DA272DCE38261C1CD:84823286A60ABC06EFCDEBD1EEFAC7CC
        public ActionGroupImpl UpdateReceiver(string actionNamePrefix)
        {
            this.actionReceiverPrefix = actionNamePrefix;
            this.emailReceivers.Clear();
            this.smsReceivers.Clear();
            this.appActionReceivers.Clear();
            this.voiceReceivers.Clear();
            this.runBookReceivers.Clear();
            this.logicReceivers.Clear();
            this.functionReceivers.Clear();
            this.webhookReceivers.Clear();
            this.itsmReceivers.Clear();

            if (this.Inner.EmailReceivers != null)
            {
                foreach (var er in this.Inner.EmailReceivers)
                {
                    this.emailReceivers[er.Name] = er;
                }
            }
            if (this.Inner.SmsReceivers != null)
            {
                foreach (var sr in this.Inner.SmsReceivers)
                {
                    this.smsReceivers[sr.Name] = sr;
                }
            }
            if (this.Inner.AzureAppPushReceivers != null)
            {
                foreach (var ar in this.Inner.AzureAppPushReceivers)
                {
                    this.appActionReceivers[ar.Name] = ar;
                }
            }
            if (this.Inner.VoiceReceivers != null)
            {
                foreach (var vr in this.Inner.VoiceReceivers)
                {
                    this.voiceReceivers[vr.Name] = vr;
                }
            }
            if (this.Inner.AutomationRunbookReceivers != null)
            {
                foreach (var ar in this.Inner.AutomationRunbookReceivers)
                {
                    this.runBookReceivers[ar.Name] = ar;
                }
            }
            if (this.Inner.LogicAppReceivers != null)
            {
                foreach (var lr in this.Inner.LogicAppReceivers)
                {
                    this.logicReceivers[lr.Name] = lr;
                }
            }
            if (this.Inner.AzureFunctionReceivers != null)
            {
                foreach (var fr in this.Inner.AzureFunctionReceivers)
                {
                    this.functionReceivers[fr.Name] = fr;
                }
            }
            if (this.Inner.WebhookReceivers != null)
            {
                foreach (var wr in this.Inner.WebhookReceivers)
                {
                    this.webhookReceivers[wr.Name] = wr;
                }
            }
            if (this.Inner.ItsmReceivers != null)
            {
                foreach (var ir in this.Inner.ItsmReceivers)
                {
                    this.itsmReceivers[ir.Name] = ir;
                }
            }
            return this;
        }

        ///GENMHASH:8EE174E1385FB0B32D41564037542BAB:A5878FD314DAE783FB5E0D95F85AA44C
        public IReadOnlyList<Models.VoiceReceiver> VoiceReceivers()
        {
            return this.Inner.VoiceReceivers.ToList();
        }

        ///GENMHASH:6263B9BD1D789A296A068E90CB6A5341:1DF7A6F0713C42E86553F8ECABA9163B
        public IReadOnlyList<Models.WebhookReceiver> WebhookReceivers()
        {
            return this.Inner.WebhookReceivers.ToList();
        }

        ///GENMHASH:4CDF7BECCD0844E46C921F74A59882A2:AE1E8ADC0D1A19DBCA7A107CCDE71569
        public ActionGroupImpl WithAutomationRunbook(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook)
        {
            this.WithoutAutomationRunbook();

            var compositeKey = this.actionReceiverPrefix + runBookSuffix;
            var arr = new AutomationRunbookReceiver
            {
                Name = compositeKey,
                AutomationAccountId = automationAccountId,
                RunbookName = runbookName,
                WebhookResourceId = webhookResourceId,
                IsGlobalRunbook = isGlobalRunbook
            };

            this.runBookReceivers[compositeKey] = arr;
            return this;
        }
        ///GENMHASH:29EAC07C793D2A0E5EB067301A745E12:1239BA4DDECAC5CB19A72AFF5EF502B0
        public ActionGroupImpl WithAzureFunction(string functionAppResourceId, string functionName, string httpTriggerUrl)
        {
            this.WithoutAzureFunction();

            var compositeKey = this.actionReceiverPrefix + functionSuffix;
            var afr = new AzureFunctionReceiver
            {
                Name = compositeKey,
                FunctionAppResourceId = functionAppResourceId,
                FunctionName = functionName,
                HttpTriggerUrl = httpTriggerUrl
            };

            this.functionReceivers[compositeKey] = afr;
            return this;
        }

        ///GENMHASH:9CE8C2CD9B4FF3636CD0315913CD5E9D:0B9ABFC681832754AEA179BB66B99F05
        public ActionGroupImpl WithEmail(string emailAddress)
        {
            this.WithoutEmail();

            var compositeKey = this.actionReceiverPrefix + emailSuffix;
            var er = new EmailReceiver
            {
                Name = compositeKey,
                EmailAddress = emailAddress
            };

            this.emailReceivers[compositeKey] = er;
            return this;
        }

        ///GENMHASH:98D697808674D2777184202E66C380B4:276AB46D78E1C91A065B8814F6C2E177
        public ActionGroupImpl WithItsm(string workspaceId, string connectionId, string ticketConfiguration, string region)
        {
            this.WithoutItsm();

            var compositeKey = this.actionReceiverPrefix + itsmSuffix;
            var ir = new ItsmReceiver
            {
                Name = compositeKey,
                WorkspaceId = workspaceId,
                ConnectionId = connectionId,
                Region = region,
                TicketConfiguration = ticketConfiguration
            };
            this.itsmReceivers[compositeKey] = ir;
            return this;
        }

        ///GENMHASH:8725DC52ABD03FF631A8419911616ECF:0B992D320C1057B364C3C054EFD0BA8F
        public ActionGroupImpl WithLogicApp(string logicAppResourceId, string callbackUrl)
        {
            this.WithoutLogicApp();

            var compositeKey = this.actionReceiverPrefix + logicSuffix;
            var lr = new LogicAppReceiver
            {
                Name = compositeKey,
                ResourceId = logicAppResourceId,
                CallbackUrl = callbackUrl
            };
            this.logicReceivers[compositeKey] = lr;
            return this;
        }

        ///GENMHASH:99FCD0B812DFC65C409CC3AF22C21EF9:92CF190BD934B53CB15E021DC6619207
        public ActionGroupImpl WithoutAutomationRunbook()
        {
            var compositeKey = this.actionReceiverPrefix + runBookSuffix;
            if (this.runBookReceivers.ContainsKey(compositeKey))
            {
                this.runBookReceivers.Remove(compositeKey);
            }
            if (this.runBookReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.runBookReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:A4A60D3F15D17DFC190AA6A7DE0A9FC9:20ECB8BB00FE58830FFCD466DA0B77AA
        public ActionGroupImpl WithoutAzureFunction()
        {
            var compositeKey = this.actionReceiverPrefix + logicSuffix;
            if (this.functionReceivers.ContainsKey(compositeKey))
            {
                this.functionReceivers.Remove(compositeKey);
            }
            if (this.functionReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.functionReceivers.Remove(actionReceiverPrefix);
            }

            return this;
        }

        ///GENMHASH:99CB3039D2358FF53225541164664E2C:66EE3C59C0828BE7D728B62D8B9A635D
        public ActionGroupImpl WithoutEmail()
        {
            var compositeKey = this.actionReceiverPrefix + emailSuffix;
            if (this.emailReceivers.ContainsKey(compositeKey))
            {
                this.emailReceivers.Remove(compositeKey);
            }
            if (this.emailReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.emailReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:079C08836F7EB8DE5A8595E23651E5B7:3423BB0F36103DF1666285AFFC65BD72
        public ActionGroupImpl WithoutItsm()
        {
            var compositeKey = this.actionReceiverPrefix + itsmSuffix;
            if (this.itsmReceivers.ContainsKey(compositeKey))
            {
                this.itsmReceivers.Remove(compositeKey);
            }
            if (this.itsmReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.itsmReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:14A2A053D79FB066AD542EFEE40F95CC:F39B7CFC2407B4FEDFAEFA553A1DBAE6
        public ActionGroupImpl WithoutLogicApp()
        {
            var compositeKey = this.actionReceiverPrefix + logicSuffix;
            if (this.logicReceivers.ContainsKey(compositeKey))
            {
                this.logicReceivers.Remove(compositeKey);
            }
            if (this.logicReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.logicReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:6EC8E9CF1C683C3A8D6B7DDF62FBA07A:7E6C5850D68A45EAB5905869CA3556A8
        public ActionGroupImpl WithoutPushNotification()
        {
            var compositeKey = this.actionReceiverPrefix + appActionSuffix;
            if (this.appActionReceivers.ContainsKey(compositeKey))
            {
                this.appActionReceivers.Remove(compositeKey);
            }
            if (this.appActionReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.appActionReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:6E2B27425509BA79FDED7388129810A7:5C8848803185D3CBDDFB76762D97E840

        public ActionGroupImpl WithoutReceiver(string actionNamePrefix)
        {
            this.UpdateReceiver(actionNamePrefix);
            this.WithoutEmail();
            this.WithoutSms();
            this.WithoutPushNotification();
            this.WithoutVoice();
            this.WithoutAutomationRunbook();
            this.WithoutLogicApp();
            this.WithoutAzureFunction();
            this.WithoutWebhook();
            this.WithoutItsm();
            return this.Parent();
        }

        ///GENMHASH:12CF8A1863C1E0A33100D5123E12554B:66FDA4CEA2F950F926E760061D588669
        public ActionGroupImpl WithoutSms()
        {
            var compositeKey = this.actionReceiverPrefix + smsSuffix;
            if (this.smsReceivers.ContainsKey(compositeKey))
            {
                this.smsReceivers.Remove(compositeKey);
            }
            if (this.smsReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.smsReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:649BCAE049ABF1D55129AB34FDAF9551:1196CD0E7A3BAC49F4F489DAECE2AA25
        public ActionGroupImpl WithoutVoice()
        {
            var compositeKey = this.actionReceiverPrefix + voiceSuffix;
            if (this.voiceReceivers.ContainsKey(compositeKey))
            {
                this.voiceReceivers.Remove(compositeKey);
            }
            if (this.voiceReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.voiceReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:B067B8E42D8768ED80A83D5D675D056A:5E8FEBF3231D188D0F5B771A45663427
        public ActionGroupImpl WithoutWebhook()
        {
            var compositeKey = this.actionReceiverPrefix + webhookSuffix;
            if (this.webhookReceivers.ContainsKey(compositeKey))
            {
                this.webhookReceivers.Remove(compositeKey);
            }
            if (this.webhookReceivers.ContainsKey(this.actionReceiverPrefix))
            {
                this.webhookReceivers.Remove(actionReceiverPrefix);
            }
            return this;
        }

        ///GENMHASH:7931352AF6E66532AD6ACE6AC8206A20:7C2BE31C7D877C66ABED0845AC3403DF
        public ActionGroupImpl WithPushNotification(string emailAddress)
        {
            this.WithoutPushNotification();

            var compositeKey = this.actionReceiverPrefix + appActionSuffix;
            var ar = new AzureAppPushReceiver
            {
                Name = compositeKey,
                EmailAddress = emailAddress
            };
            this.appActionReceivers[compositeKey] = ar;

            return this;
        }

        ///GENMHASH:E15A0C7634ADA2C9A92740002891993B:BE7DA6BC0C09A661C34F2BFFA2DF061D
        public ActionGroupImpl WithShortName(string shortName)
        {
            this.Inner.GroupShortName = shortName;
            return this;
        }

        ///GENMHASH:B1C01D344AC2E2E2A88189E7C986CA10:51672C6C6F0ABF78362B77B2C4D0C68E
        public ActionGroupImpl WithSms(string countryCode, string phoneNumber)
        {
            this.WithoutSms();

            var compositeKey = this.actionReceiverPrefix + smsSuffix;
            var sr = new SmsReceiver
            {
                Name = compositeKey,
                CountryCode = countryCode,
                PhoneNumber = phoneNumber
            };
            this.smsReceivers[compositeKey] = sr;

            return this;
        }

        ///GENMHASH:28EA8740CFC6755BFA8A1D7E7EC01656:E04F70E660B16F519FBABB6207B6EA67
        public ActionGroupImpl WithVoice(string countryCode, string phoneNumber)
        {
            this.WithoutVoice();

            var compositeKey = this.actionReceiverPrefix + voiceSuffix;
            var vr = new VoiceReceiver
            {
                Name = compositeKey,
                CountryCode = countryCode,
                PhoneNumber = phoneNumber
            };
            this.voiceReceivers[compositeKey] = vr;
            return this;
        }

        ///GENMHASH:C34DF80D865E0754A608505E39967191:5CD8BED7C3EE09742CEC0037A2B5A61B
        public ActionGroupImpl WithWebhook(string serviceUri)
        {
            this.WithoutWebhook();

            var compositeKey = this.actionReceiverPrefix + webhookSuffix;
            var wr = new WebhookReceiver
            {
                Name = compositeKey,
                ServiceUri = serviceUri
            };
            this.webhookReceivers[compositeKey] = wr;

            return this;
        }
    }
}