// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for AutoscaleSetting.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQXV0b3NjYWxlU2V0dGluZ0ltcGw=
    internal partial class AutoscaleSettingImpl  :
        GroupableResource<
            IAutoscaleSetting,
            AutoscaleSettingResourceInner,
            AutoscaleSettingImpl, 
            IMonitorManager,
            AutoscaleSetting.Definition.IWithGroup,
            AutoscaleSetting.Definition.IWithAutoscaleSettingResourceTargetResourceUri,
            AutoscaleSetting.Definition.IWithCreate,
            AutoscaleSetting.Update.IUpdate>,
        IAutoscaleSetting,
        AutoscaleSetting.Definition.IDefinition,
        AutoscaleSetting.Update.IUpdate
    {

        ///GENMHASH:1951CB8117AA8085BF0634A788CBF037:D08BAF31CDD26D315315C1E3748622FA
        internal  AutoscaleSettingImpl(string name, AutoscaleSettingResourceInner innerModel, IMonitorManager monitorManager)
            : base(name, innerModel, monitorManager)
        {
            //$ super(name, innerModel, monitorManager);
            //$ if (isInCreateMode()) {
            //$ this.Inner.WithEnabled(true);
            //$ }
            //$ if (this.Inner.Notifications() == null) {
            //$ this.Inner.WithNotifications(new ArrayList<AutoscaleNotification>());
            //$ this.Inner.Notifications().Add(new AutoscaleNotification());
            //$ }
            //$ if (this.Inner.Profiles() == null) {
            //$ this.Inner.WithProfiles(new ArrayList<AutoscaleProfileInner>());
            //$ }
            //$ }

        }

        ///GENMHASH:D7FA6C68BE839D34DF268E7A42BAF509:8E8FEC32C8C6DA0D997B8D4E3E70B348
        private AutoscaleNotification GetNotificationInner()
        {
            //$ AutoscaleNotification notificationInner = this.Inner.Notifications().Get(0);
            //$ if (notificationInner.Email() == null) {
            //$ notificationInner.WithEmail(new EmailNotification());
            //$ }
            //$ return notificationInner;
            //$ }

            return null;
        }

        ///GENMHASH:F8DF19759C164FF791C75FE281F680AB:6F29538EC771A82924D921085201270B
        private int GetProfileIndexByName(string name)
        {
            //$ int idxResult = -1;
            //$ for (int idx = 0; idx < this.Inner.Profiles().Size(); idx++) {
            //$ if (this.Inner.Profiles().Get(idx).Name().EqualsIgnoreCase(name)) {
            //$ idxResult = idx;
            //$ break;
            //$ }
            //$ }
            //$ return idxResult;
            //$ }

            return 0;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:AF95B09C7B89B7117678F310CA21E090
        protected async override Task<Models.AutoscaleSettingResourceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.AutoscaleSettings().GetByResourceGroupAsync(this.ResourceGroupName(), this.Name());

            return null;
        }

        ///GENMHASH:3AF50C65B0CC9B047E6C1E065D6BFBED:268594186991AA178F36385596B61033
        public AutoscaleSettingImpl AddNewAutoscaleProfile(AutoscaleProfileImpl profile)
        {
            //$ this.Inner.Profiles().Add(profile.Inner);
            //$ return this;
            //$ }

            return this;
        }

        ///GENMHASH:DA355E0A436E4A2189582BE98C124B08:D439B5816A7605EBE2389552867A7E75
        public bool AdminEmailNotificationEnabled()
        {
            //$ if (this.Inner.Notifications() != null
            //$ && this.Inner.Notifications().Get(0) != null
            //$ && this.Inner.Notifications().Get(0).Email() != null) {
            //$ return this.Inner.Notifications().Get(0).Email().SendToSubscriptionAdministrator();
            //$ }
            //$ return false;

            return false;
        }

        ///GENMHASH:00543BF5BE5B497955D34FC3F5EBBCAD:EB71563FB99F270D0827FDCDA083A584
        public bool AutoscaleEnabled()
        {
            //$ return this.Inner.Enabled();

            return false;
        }

        ///GENMHASH:E0153C57553C2696B4198D577FCF1CD8:8C8C16074B2DE4624FD9BBA316CF5173
        public bool COAdminEmailNotificationEnabled()
        {
            //$ if (this.Inner.Notifications() != null
            //$ && this.Inner.Notifications().Get(0) != null
            //$ && this.Inner.Notifications().Get(0).Email() != null) {
            //$ return this.Inner.Notifications().Get(0).Email().SendToSubscriptionCoAdministrators();
            //$ }
            //$ return false;

            return false;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:51500324D39371EFC4EA49C66AEA3E8B
        public async override Task<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.AutoscaleSettings().CreateOrUpdateAsync(this.ResourceGroupName(), this.Name(), this.Inner)
            //$ .Map(innerToFluentMap(this));

            return null;
        }

        ///GENMHASH:21D900182EBD400E53FA60965D596C4A:1BD46A7D6D0C5CC15485C2E76DCCFCD7
        public IReadOnlyList<string> CustomEmailsNotification()
        {
            //$ if (this.Inner.Notifications() != null
            //$ && this.Inner.Notifications().Get(0) != null
            //$ && this.Inner.Notifications().Get(0).Email() != null
            //$ && this.Inner.Notifications().Get(0).Email().CustomEmails() != null) {
            //$ return this.Inner.Notifications().Get(0).Email().CustomEmails();
            //$ }
            //$ return new ArrayList<>();

            return null;
        }

        ///GENMHASH:5D8E818F861966D6DAC64AB862206F4E:11CCC5384AE4646655D367DC94FB2D9F
        public AutoscaleProfileImpl DefineAutoscaleProfile(string name)
        {
            //$ return new AutoscaleProfileImpl(name, new AutoscaleProfileInner(), this);

            return null;
        }

        ///GENMHASH:61B5A645876D07C504C5B173DE0F3F4B:B458F7A8C0DBFEDF2F7A0B2B1732CBAA
        public IReadOnlyDictionary<string,Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleProfile> Profiles()
        {
            //$ Map<String, AutoscaleProfile> result = new HashMap<>();
            //$ foreach(var profileInner in this.Inner.Profiles()) {
            //$ AutoscaleProfile profileImpl = new AutoscaleProfileImpl(profileInner.Name(), profileInner, this);
            //$ result.Put(profileImpl.Name(), profileImpl);
            //$ }
            //$ return result;

            return null;
        }

        ///GENMHASH:54FF9EAE063A707BF467152E850B0B04:A45091BF0DB6C335C011320E8AF5F0AD
        public string TargetResourceId()
        {
            //$ return this.Inner.TargetResourceUri();

            return null;
        }

        ///GENMHASH:2D6554AE08DA447816C1326945125C4C:27CF032C636E59C916D51F0F7D1297E5
        public AutoscaleProfileImpl UpdateAutoscaleProfile(string name)
        {
            //$ int idx = getProfileIndexByName(name);
            //$ if (idx == -1) {
            //$ throw new IllegalArgumentException("Cannot find autoscale profile with the name '" + name + "'");
            //$ }
            //$ AutoscaleProfileInner innerProfile = this.Inner.Profiles().Get(idx);
            //$ 
            //$ return new AutoscaleProfileImpl(innerProfile.Name(), innerProfile, this);

            return null;
        }

        ///GENMHASH:9D0954ABF2D15324652CDFD343FBE932:A2BDF2939197001B4DF03D8C4C1E650E
        public string WebhookNotification()
        {
            //$ if (this.Inner.Notifications() != null
            //$ && this.Inner.Notifications().Get(0) != null
            //$ && this.Inner.Notifications().Get(0).Email() != null
            //$ && this.Inner.Notifications().Get(0).Webhooks() != null
            //$ && this.Inner.Notifications().Get(0).Webhooks().Size() > 0) {
            //$ return this.Inner.Notifications().Get(0).Webhooks().Get(0).ServiceUri();
            //$ }
            //$ return null;

            return null;
        }

        ///GENMHASH:A60FA673255CD90CF90360D833C4EBAF:2607E71F27E13987C31EB07CC2C07AFE
        public AutoscaleSettingImpl WithAdminEmailNotification()
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ notificationInner.Email().WithSendToSubscriptionAdministrator(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:2A1682469B64B349612E20FC5B870712:9A4882A827B87B926799484B506DA9A3
        public AutoscaleSettingImpl WithAutoscaleDisabled()
        {
            //$ this.Inner.WithEnabled(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:558D027593B7EABE01F80F16F0FCE647:B605F0C6D20484DEA14055C58519B8C8
        public AutoscaleSettingImpl WithAutoscaleEnabled()
        {
            //$ this.Inner.WithEnabled(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:ADEF0E0AF61A1F04E899E5CD6BA7CCF5:7634C631DECF7B75434907BC1FA3D6BB
        public AutoscaleSettingImpl WithCoAdminEmailNotification()
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ notificationInner.Email().WithSendToSubscriptionCoAdministrators(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:44A886000EAC41E11C33AE8226E59E03:25EEA7B6445180E1074783820A990B83
        public AutoscaleSettingImpl WithCustomEmailsNotification(params string[] customEmailAddresses)
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ notificationInner.Email().WithCustomEmails(new ArrayList<String>());
            //$ foreach(var strEmail in customEmailAddresses) {
            //$ notificationInner.Email().CustomEmails().Add(strEmail);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:99139129B04D4F7AE97765A8DADA0456:A543A6502A7D2F2175895FF3CCE1B382
        public AutoscaleSettingImpl WithoutAdminEmailNotification()
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ notificationInner.Email().WithSendToSubscriptionAdministrator(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:5A4115DA6C71A962B72AF788326A9217:A7415243692BC25432F457FB9E394944
        public AutoscaleSettingImpl WithoutAutoscaleProfile(string name)
        {
            //$ int idx = getProfileIndexByName(name);
            //$ if (idx != -1) {
            //$ this.Inner.Profiles().Remove(idx);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:37FD126A7010D20B98B1C9F401A1FAF1:53FFF8DB234F6295C4B8595A40BEF2CB
        public AutoscaleSettingImpl WithoutCoAdminEmailNotification()
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ notificationInner.Email().WithSendToSubscriptionCoAdministrators(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:9B8AAB7C73A4356DBEF416219D2D8DA6:96373044CBF1765272DF6C51C3B19117
        public AutoscaleSettingImpl WithoutCustomEmailsNotification()
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ notificationInner.Email().WithCustomEmails(null);
            //$ return this;

            return this;
        }

        ///GENMHASH:783AF027875007335DC23E8ED954FA13:D3FA1B616BB3AA38C79772191BE14DA0
        public AutoscaleSettingImpl WithoutWebhookNotification()
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ notificationInner.WithWebhooks(null);
            //$ return this;

            return this;
        }

        ///GENMHASH:21C5E913CC99F20E7CFF02057B43ED9D:A0BCC46BF5C404DED27286B465C8298F
        public AutoscaleSettingImpl WithTargetResource(string targetResourceId)
        {
            //$ this.Inner.WithTargetResourceUri(targetResourceId);
            //$ return this;

            return this;
        }

        ///GENMHASH:08A3122AA7CA480A84E335D8795B4125:129E16E1D02FECD29C6E8361F462E692
        public AutoscaleSettingImpl WithWebhookNotification(string serviceUri)
        {
            //$ AutoscaleNotification notificationInner = getNotificationInner();
            //$ if (notificationInner.Webhooks() == null) {
            //$ notificationInner.WithWebhooks(new ArrayList<WebhookNotification>());
            //$ }
            //$ if (notificationInner.Webhooks().IsEmpty()) {
            //$ notificationInner.Webhooks().Add(new WebhookNotification());
            //$ }
            //$ notificationInner.Webhooks().Get(0).WithServiceUri(serviceUri);
            //$ return this;

            return this;
        }
    }
}