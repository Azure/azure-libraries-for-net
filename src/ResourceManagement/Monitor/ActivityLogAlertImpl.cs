// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.ActivityLogAlert.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for ActivityLogAlert.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQWN0aXZpdHlMb2dBbGVydEltcGw=
    internal partial class ActivityLogAlertImpl  :
        GroupableResource<
            IActivityLogAlert,
            ActivityLogAlertResourceInner,
            ActivityLogAlertImpl,
            MonitorManager,
            ActivityLogAlert.Definition.IBlank,
            ActivityLogAlert.Definition.IWithScopes,
            ActivityLogAlert.Definition.IWithCreate,
            ActivityLogAlert.Update.IUpdate>,
        IActivityLogAlert,
        IDefinition,
        IUpdate,
        IWithActivityLogUpdate
    {
        private Dictionary<string,string> conditions;

        ///GENMHASH:BB950CA14FF4F1F69C522AF91F90FC34:408D5FE696EAF2806ED2D70B7393F055
        internal ActivityLogAlertImpl(string name, ActivityLogAlertResourceInner innerModel, MonitorManager monitorManager)
            : base(name, innerModel, monitorManager)
        {
            //$ super(name, innerModel, monitorManager);
            //$ this.conditions = new TreeMap<>();
            //$ if (innerModel.Condition() != null && innerModel.Condition().AllOf() != null) {
            //$ foreach(var aac in innerModel.Condition().AllOf()) {
            //$ this.conditions.Put(aac.Field(), aac.Equals());
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:1DCFF5A76BE07CD1A05C937F9EDA2875
        protected override async Task<Models.ActivityLogAlertResourceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.ActivityLogAlerts().GetByResourceGroupAsync(this.ResourceGroupName(), this.Name());

            return null;
        }

        ///GENMHASH:66DC6CE2AC9BE61B5E666402EB693221:5E24241966A03424F2E45A8D9C85B7E3
        public IReadOnlyCollection<string> ActionGroupIds()
        {
            //$ if (this.Inner.Actions() != null
            //$ && this.Inner.Actions().ActionGroups() != null) {
            //$ List<String> ids = new ArrayList<>();
            //$ foreach(var alaag in this.Inner.Actions().ActionGroups()) {
            //$ ids.Add(alaag.ActionGroupId());
            //$ }
            //$ return Collections.UnmodifiableCollection(ids);
            //$ }
            //$ return Collections.EmptyList();

            return null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:9B7B9E01CD94CAAB45F3A60AA8B80787
        public override async Task<Microsoft.Azure.Management.Monitor.Fluent.IActivityLogAlert> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ this.Inner.WithLocation("global");
            //$ ActivityLogAlertAllOfCondition condition = new ActivityLogAlertAllOfCondition();
            //$ condition.WithAllOf(new ArrayList<ActivityLogAlertLeafCondition>());
            //$ for (Map.Entry<String, String> cds : conditions.EntrySet()) {
            //$ ActivityLogAlertLeafCondition alalc = new ActivityLogAlertLeafCondition();
            //$ alalc.WithField(cds.GetKey());
            //$ alalc.WithEquals(cds.GetValue());
            //$ condition.AllOf().Add(alalc);
            //$ }
            //$ this.Inner.WithCondition(condition);
            //$ return this.Manager().Inner.ActivityLogAlerts().CreateOrUpdateAsync(this.ResourceGroupName(), this.Name(), this.Inner)
            //$ .Map(innerToFluentMap(this));

            return null;
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        public string Description()
        {
            //$ return this.Inner.Description();

            return null;
        }

        ///GENMHASH:1703877FCECC33D73EA04EEEF89045EF:EB71563FB99F270D0827FDCDA083A584
        public bool Enabled()
        {
            //$ return this.Inner.Enabled();

            return false;
        }

        ///GENMHASH:98F3CB7FC44C6127EC66A44A86617755:C847040A726E35E60A000ACD7F24E314
        public IReadOnlyDictionary<string,string> EqualsConditions()
        {
            //$ return this.conditions;

            return null;
        }

        ///GENMHASH:C457EEA978B7A6C6C56D90DDF5271FFB:82059B9BE2545D9387D9EA1B5A801869
        public IReadOnlyCollection<string> Scopes()
        {
            //$ return Collections.UnmodifiableCollection(this.Inner.Scopes());

            return null;
        }

        ///GENMHASH:8251517CD3DB23FD0217AD932D86E975:C86469D57481319F5A214F5EC8087A9A
        public ActivityLogAlertImpl WithActionGroups(params string[] actionGroupId)
        {
            //$ if (this.Inner.Actions() == null) {
            //$ this.Inner.WithActions(new ActivityLogAlertActionList());
            //$ this.Inner.Actions().WithActionGroups(new ArrayList<ActivityLogAlertActionGroup>());
            //$ }
            //$ this.Inner.Actions().ActionGroups().Clear();
            //$ 
            //$ foreach(var agid in actionGroupId) {
            //$ ActivityLogAlertActionGroup aaa = new ActivityLogAlertActionGroup();
            //$ aaa.WithActionGroupId(agid);
            //$ this.Inner.Actions().ActionGroups().Add(aaa);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:016764F09D1966D691B5DE3A7FD47AC9:5D67BF1D9DA1008F878F13C112FF5F35
        public ActivityLogAlertImpl WithDescription(string description)
        {
            //$ this.Inner.WithDescription(description);
            //$ return this;

            return this;
        }

        ///GENMHASH:1A83DF7BBE2B0E999F6ABB21FE550BDC:D499B9B549494173D48F5774E68D385F
        public ActivityLogAlertImpl WithEqualsCondition(string field, string equals)
        {
            //$ this.WithoutEqualsCondition(field);
            //$ this.conditions.Put(field, equals);
            //$ return this;

            return this;
        }

        ///GENMHASH:012586BEA031ABB7E8D7DA7C5407D11D:5CD188D9DC123B8EF062D3406B1366C7
        public ActivityLogAlertImpl WithEqualsConditions(IDictionary<string,string> fieldEqualsMap)
        {
            //$ this.conditions.Clear();
            //$ this.conditions.PutAll(fieldEqualsMap);
            //$ return this;

            return this;
        }

        ///GENMHASH:ED05B641BBACDA0FE20CB8084C06E215:7D2C8F9251DDB86FA30AE515EE6BAA94
        public ActivityLogAlertImpl WithoutActionGroup(string actionGroupId)
        {
            //$ if (this.Inner.Actions() != null && this.Inner.Actions().ActionGroups() != null) {
            //$ List<ActivityLogAlertActionGroup> toDelete = new ArrayList<>();
            //$ foreach(var aaa in this.Inner.Actions().ActionGroups()) {
            //$ if (aaa.ActionGroupId().EqualsIgnoreCase(actionGroupId)) {
            //$ toDelete.Add(aaa);
            //$ }
            //$ }
            //$ this.Inner.Actions().ActionGroups().RemoveAll(toDelete);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:237AE1DD2F36D83D699F312F5527B0A4:BD960AA3B170F286E76A114183EF968A
        public ActivityLogAlertImpl WithoutEqualsCondition(string field)
        {
            //$ if (this.conditions.ContainsKey(field)) {
            //$ this.conditions.Remove(field);
            //$ }
            //$ return this;

            return this;
        }

        ///GENMHASH:19D591A5811CC295B77719A40CEB3F64:9A4882A827B87B926799484B506DA9A3
        public ActivityLogAlertImpl WithRuleDisabled()
        {
            //$ this.Inner.WithEnabled(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:1952D7AE67830F92010B1423D9533A88:B605F0C6D20484DEA14055C58519B8C8
        public ActivityLogAlertImpl WithRuleEnabled()
        {
            //$ this.Inner.WithEnabled(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:21C5E913CC99F20E7CFF02057B43ED9D:252983E9D051F9EAAC0EB5276C560315
        public ActivityLogAlertImpl WithTargetResource(string resourceId)
        {
            //$ this.Inner.WithScopes(new ArrayList<String>());
            //$ this.Inner.Scopes().Add(resourceId);
            //$ return this;

            return null;
        }

        ///GENMHASH:FF34A220CBD022BF5822C4584DEEE94E:A6098866C47E7A7E582B09209AD5C53E
        public ActivityLogAlertImpl WithTargetResource(IHasId resource)
        {
            //$ return this.WithTargetResource(resource.Id());

            return null;
        }

        ///GENMHASH:F4B0D12B9C1C3B68E6A05E465C7B1E57:5956998ECA780A89CC7DB7F37D0036EB
        public ActivityLogAlertImpl WithTargetSubscription(string targetSubscriptionId)
        {
            //$ return this.WithTargetResource("/subscriptions/" + targetSubscriptionId);

            return null;
        }
    }
}