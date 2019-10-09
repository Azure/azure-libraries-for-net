// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.MetricAlert.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for MetricAlert.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTWV0cmljQWxlcnRJbXBs
    internal partial class MetricAlertImpl :
        GroupableResource<
            IMetricAlert,
            MetricAlertResourceInner,
            MetricAlertImpl,
            MonitorManager,
            MetricAlert.Definition.IBlank,
            MetricAlert.Definition.IWithScopes,
            MetricAlert.Definition.IWithCreate,
            MetricAlert.Update.IUpdate>,
        IMetricAlert,
        IDefinition,
        IDefinitionMultipleResource,
        IUpdate,
        IWithMetricUpdate
    {
        // 2019/09 at present service support 2 static criteria, or 1 dynamic criteria
        private Dictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition> conditions;
        private Dictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricDynamicAlertCondition> dynamicConditions;

        private bool multipleResource = false;

        ///GENMHASH:93FFF181B400DDE81DA77A82752C1C48:F98AC2175A8CD73451AD6F369CD5E05F
        internal MetricAlertImpl(string name, MetricAlertResourceInner innerModel, MonitorManager monitorManager)
            : base(name, innerModel, monitorManager)
        {
            this.conditions = new Dictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition>();
            this.dynamicConditions = new Dictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricDynamicAlertCondition>();

            if (innerModel.Criteria != null)
            {
                if (innerModel.Criteria is MetricAlertSingleResourceMultipleMetricCriteria)
                {
                    multipleResource = false;
                    var crits = (innerModel.Criteria as MetricAlertSingleResourceMultipleMetricCriteria).AllOf;
                    if (crits != null)
                    {
                        foreach (var crit in crits)
                        {
                            this.conditions[crit.Name] = new MetricAlertConditionImpl(crit.Name, crit, this);
                        }
                    }
                }
                else if (innerModel.Criteria is MetricAlertMultipleResourceMultipleMetricCriteria)
                {
                    multipleResource = true;
                    // multiple resource with either multiple static criteria, or (currently single) dynamic criteria
                    var crits = (innerModel.Criteria as MetricAlertMultipleResourceMultipleMetricCriteria).AllOf;
                    if (crits != null)
                    {
                        foreach (var crit in crits)
                        {
                            if (crit is MetricCriteria)
                            {
                                this.conditions[crit.Name] = new MetricAlertConditionImpl(crit.Name, crit as MetricCriteria, this);
                            }
                            else if (crit is DynamicMetricCriteria)
                            {
                                this.dynamicConditions[crit.Name] = new MetricDynamicAlertConditionImpl(crit.Name, crit as DynamicMetricCriteria, this);
                            }
                        }
                    }
                }
            }
        }

        ///GENMHASH:04C3DADE8E037DF05A82835AF96AF265:D45B28490B7AE6B4CA8461670CCAE4DC
        internal MetricAlertImpl WithAlertCriteria(MetricAlertConditionImpl criteria)
        {
            this.WithoutAlertCriteria(criteria.Name());
            this.conditions[criteria.Name()] = criteria;
            return this;
        }

        internal MetricAlertImpl WithDynamicAlertCriteria(MetricDynamicAlertConditionImpl criteria)
        {
            this.WithoutAlertCriteria(criteria.Name());
            this.dynamicConditions[criteria.Name()] = criteria;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:5B960FE4701B7B30A98A4F211FA06D5D
        protected override async Task<Models.MetricAlertResourceInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.MetricAlerts.GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:66DC6CE2AC9BE61B5E666402EB693221:2D08CF98D3B6811D1A7A4C18C0CE3C12
        public IReadOnlyCollection<string> ActionGroupIds()
        {
            var ids = new List<string>();
            if (this.Inner.Actions != null && this.Inner.Actions != null)
            {
                foreach (var maag in this.Inner.Actions)
                {
                    ids.Add(maag.ActionGroupId);
                }
            }

            return ids;
        }

        ///GENMHASH:757305684CB38CD78E303A75B6BB60FF:C847040A726E35E60A000ACD7F24E314
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricAlertCondition> AlertCriterias()
        {
            return this.conditions;
        }

        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Monitor.Fluent.IMetricDynamicAlertCondition> DynamicAlertCriterias()
        {
            return this.dynamicConditions;
        }

        ///GENMHASH:BD4E8EEC1F995C84FF18BAE3CCFD22A6:F72671A23D283F9DD9B5C804037ECE33
        public bool AutoMitigate()
        {
            return (this.Inner.AutoMitigate.HasValue == false) ? false : this.Inner.AutoMitigate.Value;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:3D3357BF7A9E06A99BB65E3E9DAF00FD
        public override async Task<Microsoft.Azure.Management.Monitor.Fluent.IMetricAlert> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!this.conditions.Any() && !this.dynamicConditions.Any())
            {
                throw new ArgumentException("Condition cannot be empty");
            }
            else if (this.conditions.Any() && this.dynamicConditions.Any())
            {
                throw new ArgumentException("Static condition and dynamic condition cannot co-exist");
            }

            this.Inner.Location = "global";
            if (this.conditions.Any())
            {
                if (!multipleResource)
                {
                    var crit = new MetricAlertSingleResourceMultipleMetricCriteria();
                    crit.AllOf = new List<MetricCriteria>();
                    foreach (var mc in conditions.Values)
                    {
                        crit.AllOf.Add(mc.Inner);
                    }
                    this.Inner.Criteria = crit;
                }
                else
                {
                    var crit = new MetricAlertMultipleResourceMultipleMetricCriteria();
                    crit.AllOf = new List<MultiMetricCriteria>();
                    foreach (var mc in conditions.Values)
                    {
                        crit.AllOf.Add(mc.Inner);
                    }
                    this.Inner.Criteria = crit;
                }
            }
            else if (this.dynamicConditions.Any())
            {
                var crit = new MetricAlertMultipleResourceMultipleMetricCriteria();
                crit.AllOf = new List<MultiMetricCriteria>();
                foreach (var mc in dynamicConditions.Values)
                {
                    crit.AllOf.Add(mc.Inner);
                }
                this.Inner.Criteria = crit;
            }
            SetInner(await this.Manager.Inner.MetricAlerts.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken));
            return this;
        }

        ///GENMHASH:8CCE644095FFB50F9DEE14F363C80774:D71D22182A27EAB88444CD16A8974390
        public MetricAlertConditionImpl DefineAlertCriteria(string name)
        {
            return new MetricAlertConditionImpl(name, new MetricCriteria(), this);
        }

        public MetricDynamicAlertConditionImpl DefineDynamicAlertCriteria(string name)
        {
            return new MetricDynamicAlertConditionImpl(name, new DynamicMetricCriteria(), this);
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        public string Description()
        {
            return this.Inner.Description;
        }

        ///GENMHASH:1703877FCECC33D73EA04EEEF89045EF:EB71563FB99F270D0827FDCDA083A584
        public bool Enabled()
        {
            return this.Inner.Enabled;
        }

        ///GENMHASH:6B9F8E34E59C56A0ADE05FF4B71FFF16:3A883853EF6DBDD2909F1D82D52F6295
        public TimeSpan EvaluationFrequency()
        {
            return this.Inner.EvaluationFrequency;
        }

        ///GENMHASH:DF5C039E76E3291E606FA7B30E6A35B8:63328FCE78D88A10DDBE141D8DF86DAB
        public DateTime? LastUpdatedTime()
        {
            return this.Inner.LastUpdatedTime;
        }

        ///GENMHASH:C457EEA978B7A6C6C56D90DDF5271FFB:82059B9BE2545D9387D9EA1B5A801869
        public IReadOnlyCollection<string> Scopes()
        {
            return this.Inner.Scopes.ToList();
        }

        ///GENMHASH:ADCA390FA193949D8BA48D8804FB138B:D820AD5904970E73EAE6FDD91C9395A4
        public int Severity()
        {
            return this.Inner.Severity;
        }

        ///GENMHASH:A61C25AD4B6930EB03CA48C25CDEF795:79090E4718A09FDF5299FE081DD6B337
        public MetricAlertConditionImpl UpdateAlertCriteria(string name)
        {
            return this.conditions[name] as MetricAlertConditionImpl;
        }

        public MetricDynamicAlertConditionImpl UpdateDynamicAlertCriteria(string name)
        {
            return this.dynamicConditions[name] as MetricDynamicAlertConditionImpl;
        }

        ///GENMHASH:AE926B5FF5A4B01D584D38C07E21A243:15DB234CEC0D38C1E33EB2ECEB2CC038
        public TimeSpan WindowSize()
        {
            return this.Inner.WindowSize;
        }

        ///GENMHASH:8251517CD3DB23FD0217AD932D86E975:89FE971323C03077A05F6DBB399CC7F8
        public MetricAlertImpl WithActionGroups(params string[] actionGroupId)
        {
            if (this.Inner.Actions == null)
            {
                this.Inner.Actions = new List<MetricAlertAction>();
            }
            this.Inner.Actions.Clear();
            foreach (var agid in actionGroupId)
            {
                var maa = new MetricAlertAction();
                maa.ActionGroupId = agid;
                this.Inner.Actions.Add(maa);
            }
            return this;
        }

        ///GENMHASH:3E72FBE95EB9F0D5CB0EE25FB0D4289B:D28CEE20EE587F7BE2C58D660CBB76F2
        public MetricAlertImpl WithAlertDetails(int severity, string description)
        {
            this.WithSeverity(severity);
            return this.WithDescription(description);
        }

        ///GENMHASH:B1FAD9ED00B5928448AB0AA933758335:5640B4C7C912ABC98D9779381D53E6DC
        public MetricAlertImpl WithAutoMitigation()
        {
            this.Inner.AutoMitigate = true;

            return this;
        }

        ///GENMHASH:016764F09D1966D691B5DE3A7FD47AC9:5D67BF1D9DA1008F878F13C112FF5F35
        public MetricAlertImpl WithDescription(string description)
        {
            this.Inner.Description = description;
            return this;
        }

        ///GENMHASH:CEDDCCEB2476E58338BF2FA01220048D:CFB14B1FCC87FA2BAE66C1739882B0E0
        public MetricAlertImpl WithFrequency(TimeSpan frequency)
        {
            this.Inner.EvaluationFrequency = frequency;
            return this;
        }

        ///GENMHASH:ED05B641BBACDA0FE20CB8084C06E215:7AEA88F41785879622403706A8BF6B9A
        public MetricAlertImpl WithoutActionGroup(string actionGroupId)
        {
            if (this.Inner.Actions != null)
            {
                var toDelete = new List<MetricAlertAction>();
                foreach (var maa in this.Inner.Actions)
                {
                    if (maa.ActionGroupId.Equals(actionGroupId, StringComparison.OrdinalIgnoreCase))
                    {
                        toDelete.Add(maa);
                    }
                }
                foreach (var maa in toDelete)
                {
                    this.Inner.Actions.Remove(maa);
                }
            }
            return this;
        }

        ///GENMHASH:E4FEC8C316C1129E5FA8F1D228445F51:4B6FC8F18AB8BEA63867486135BF38C3
        public MetricAlertImpl WithoutAlertCriteria(string name)
        {
            if (this.conditions.ContainsKey(name))
            {
                this.conditions.Remove(name);
            }
            if (this.dynamicConditions.ContainsKey(name))
            {
                this.dynamicConditions.Remove(name);
            }
            return this;
        }

        ///GENMHASH:1350F1101BA21E04B29D498C2E0AA500:C7B841429CEB812AD0A4C96DFAFF636B
        public MetricAlertImpl WithoutAutoMitigation()
        {
            this.Inner.AutoMitigate = false;
            return this;
        }

        ///GENMHASH:252AAE75064297D555927CEDAE99C9D4:3E52FB242763B2F8A4587CF4CE43F118
        public MetricAlertImpl WithPeriod(TimeSpan size)
        {
            this.Inner.WindowSize = size;
            return this;
        }

        ///GENMHASH:19D591A5811CC295B77719A40CEB3F64:9A4882A827B87B926799484B506DA9A3
        public MetricAlertImpl WithRuleDisabled()
        {
            this.Inner.Enabled = false;
            return this;
        }

        ///GENMHASH:1952D7AE67830F92010B1423D9533A88:B605F0C6D20484DEA14055C58519B8C8
        public MetricAlertImpl WithRuleEnabled()
        {
            this.Inner.Enabled = true;
            return this;
        }

        ///GENMHASH:7ED8FFB8E1E8A478D0B971D4B84FAE92:3182F67E8B2D04AAB4A46329B8E3F9E8
        public MetricAlertImpl WithSeverity(int severity)
        {
            this.Inner.Severity = severity;
            return this;
        }

        ///GENMHASH:21C5E913CC99F20E7CFF02057B43ED9D:252983E9D051F9EAAC0EB5276C560315
        public MetricAlertImpl WithTargetResource(string resourceId)
        {
            multipleResource = false;

            this.Inner.Scopes = new List<string>();
            this.Inner.Scopes.Add(resourceId);
            return this;
        }

        ///GENMHASH:FF34A220CBD022BF5822C4584DEEE94E:A6098866C47E7A7E582B09209AD5C53E
        public MetricAlertImpl WithTargetResource(IHasId resource)
        {
            multipleResource = false;

            return this.WithTargetResource(resource.Id);
        }

        public MetricAlertImpl WithMultipleTargetResources(IEnumerable<string> resourceIds, string type, string regionName)
        {
            multipleResource = true;

            List<string> scopes = new List<string>();
            scopes.AddRange(resourceIds);
            this.Inner.Scopes = scopes;
            this.Inner.TargetResourceType = type;
            this.Inner.TargetResourceRegion = regionName;
            return this;
        }

        public MetricAlertImpl WithMultipleTargetResources(IEnumerable<IResource> resources)
        {
            if (resources == null || !resources.Any())
            {
                throw new ArgumentException("Target resource cannot be empty");
            }

            multipleResource = true;

            List<string> resourceIds = new List<string>();
            string type = resources.First().Type;
            string regionName = resources.First().RegionName;
            foreach (IResource resource in resources)
            {
                if (!type.Equals(resource.Type, StringComparison.OrdinalIgnoreCase) || !regionName.Equals(resource.RegionName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Target resource must be of the same resource type and in the same region");
                }
                resourceIds.Add(resource.Id);
            }
            return this.WithMultipleTargetResources(resourceIds, type, regionName);
        }
    }
}