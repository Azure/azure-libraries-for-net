// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    public partial class ManagementPolicyImpl  :
        CreatableUpdatable<
            Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy,
            ManagementPolicyInner,
            Microsoft.Azure.Management.Storage.Fluent.ManagementPolicyImpl,
            IHasId,
            Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update.IUpdate>,
        IManagementPolicy,
        ManagementPolicy.Definition.IDefinition,
        ManagementPolicy.Update.IUpdate
    {
        private string accountName;
        private ManagementPolicySchema cpolicy;
        private StorageManager manager;
        private string resourceGroupName;
        private ManagementPolicySchema upolicy;

        StorageManager IHasManager<StorageManager>.Manager => this.manager;

        string IHasId.Id => Inner.Id;

        internal  ManagementPolicyImpl(string name, StorageManager manager) : base(name, new ManagementPolicyInner())
        {
            //$ super(name, new ManagementPolicyInner());
            //$ this.manager = manager;
            //$ // Set resource name
            //$ this.accountName = name;
            //$ //
            //$ this.cpolicy = new ManagementPolicySchema();
            //$ this.upolicy = new ManagementPolicySchema();
            //$ }

        }

                internal  ManagementPolicyImpl(ManagementPolicyInner inner, StorageManager manager) : base(inner.Name, inner)
        {
            //$ super(inner.Name(), inner);
            //$ this.manager = manager;
            //$ // Set resource name
            //$ this.accountName = inner.Name();
            //$ // set resource ancestor and positional variables
            //$ this.resourceGroupName = IdParsingUtils.GetValueFromIdByName(inner.Id(), "resourceGroups");
            //$ this.accountName = IdParsingUtils.GetValueFromIdByName(inner.Id(), "storageAccounts");
            //$ //
            //$ this.cpolicy = new ManagementPolicySchema();
            //$ this.upolicy = new ManagementPolicySchema();
            //$ }

        }

                internal void DefineRule(PolicyRuleImpl policyRuleImpl)
        {
            //$ if (isInCreateMode()) {
            //$ if (this.cpolicy.Rules() == null) {
            //$ this.cpolicy.WithRules(new ArrayList<ManagementPolicyRule>());
            //$ }
            //$ List<ManagementPolicyRule> rules = this.cpolicy.Rules();
            //$ rules.Add(policyRuleImpl.Inner());
            //$ this.cpolicy.WithRules(rules);
            //$ } else {
            //$ if (this.upolicy.Rules() == null) {
            //$ this.upolicy.WithRules(new ArrayList<ManagementPolicyRule>());
            //$ }
            //$ List<ManagementPolicyRule> rules = this.upolicy.Rules();
            //$ rules.Add(policyRuleImpl.Inner());
            //$ this.upolicy.WithRules(rules);
            //$ }
            //$ }

        }

                private void ResetCreateUpdateParameters()
        {
            //$ this.cpolicy = new ManagementPolicySchema();
            //$ this.upolicy = new ManagementPolicySchema();
            //$ }

        }

                protected override async Task<ManagementPolicyInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ ManagementPoliciesInner client = this.manager().Inner().ManagementPolicies();
            //$ return client.GetAsync(this.resourceGroupName, this.accountName);

            return null;
        }

                public override async Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ ManagementPoliciesInner client = this.manager().Inner().ManagementPolicies();
            //$ return client.CreateOrUpdateAsync(this.resourceGroupName, this.accountName, this.cpolicy)
            //$ .Map(new Func1<ManagementPolicyInner, ManagementPolicyInner>() {
            //$ @Override
            //$ public ManagementPolicyInner call(ManagementPolicyInner resource) {
            //$ resetCreateUpdateParameters();
            //$ return resource;
            //$ }
            //$ })
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public PolicyRule.Definition.IBlank DefineRule(string name)
        {
            //$ return new PolicyRuleImpl(this, name);

            return null;
        }

                public string Id()
        {
            //$ return this.Inner().Id();

            return null;
        }

                public bool IsInCreateMode()
        {
            //$ return this.Inner().Id() == null;

            return false;
        }

                public DateTime LastModifiedTime()
        {
            //$ return this.Inner().LastModifiedTime();

            return DateTime.Now;
        }

                public StorageManager Manager()
        {
            //$ return this.manager;

            return null;
        }

                public string Name()
        {
            //$ return this.Inner().Name();

            return null;
        }

                public ManagementPolicySchema Policy()
        {
            //$ return this.Inner().Policy();

            return null;
        }

                public IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.IPolicyRule> Rules()
        {
            //$ List<ManagementPolicyRule> originalRules = this.Policy().Rules();
            //$ List<PolicyRule> returnRules = new ArrayList<>();
            //$ for (ManagementPolicyRule originalRule : originalRules) {
            //$ List<String> originalBlobTypes = originalRule.Definition().Filters().BlobTypes();
            //$ List<BlobTypes> returnBlobTypes = new ArrayList<>();
            //$ for (String originalBlobType : originalBlobTypes) {
            //$ returnBlobTypes.Add(BlobTypes.FromString(originalBlobType));
            //$ }
            //$ PolicyRule returnRule = new PolicyRuleImpl(originalRule.Name())
            //$ .WithLifecycleRuleType()
            //$ .WithBlobTypesToFilterFor(returnBlobTypes);
            //$ 
            //$ // building up prefixes to filter on
            //$ if (originalRule.Definition().Filters().PrefixMatch() != null) {
            //$ ((PolicyRuleImpl) returnRule).WithPrefixesToFilterFor(originalRule.Definition().Filters().PrefixMatch());
            //$ }
            //$ 
            //$ // building up actions on base blob
            //$ ManagementPolicyBaseBlob originalBaseBlobActions = originalRule.Definition().Actions().BaseBlob();
            //$ if (originalBaseBlobActions != null) {
            //$ if (originalBaseBlobActions.TierToCool() != null) {
            //$ ((PolicyRuleImpl) returnRule).WithTierToCoolActionOnBaseBlob(originalBaseBlobActions.TierToCool().DaysAfterModificationGreaterThan());
            //$ }
            //$ if (originalBaseBlobActions.TierToArchive() != null) {
            //$ ((PolicyRuleImpl) returnRule).WithTierToArchiveActionOnBaseBlob(originalBaseBlobActions.TierToArchive().DaysAfterModificationGreaterThan());
            //$ }
            //$ if (originalBaseBlobActions.Delete() != null) {
            //$ ((PolicyRuleImpl) returnRule).WithDeleteActionOnBaseBlob(originalBaseBlobActions.Delete().DaysAfterModificationGreaterThan());
            //$ }
            //$ }
            //$ 
            //$ // build up actions on snapshot
            //$ ManagementPolicySnapShot originalSnapshotActions = originalRule.Definition().Actions().Snapshot();
            //$ if (originalSnapshotActions != null) {
            //$ if (originalSnapshotActions.Delete() != null) {
            //$ ((PolicyRuleImpl) returnRule).WithDeleteActionOnSnapShot(originalSnapshotActions.Delete().DaysAfterCreationGreaterThan());
            //$ }
            //$ }
            //$ returnRules.Add(returnRule);
            //$ }
            //$ return Collections.UnmodifiableList(returnRules);

            return null;
        }

                public string Type()
        {
            //$ return this.Inner().Type();

            return null;
        }

                public async Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ ManagementPoliciesInner client = this.manager().Inner().ManagementPolicies();
            //$ return client.CreateOrUpdateAsync(this.resourceGroupName, this.accountName, this.upolicy)
            //$ .Map(new Func1<ManagementPolicyInner, ManagementPolicyInner>() {
            //$ @Override
            //$ public ManagementPolicyInner call(ManagementPolicyInner resource) {
            //$ resetCreateUpdateParameters();
            //$ return resource;
            //$ }
            //$ })
            //$ .Map(innerToFluentMap(this));

            return null;
        }

                public PolicyRule.Update.IUpdate UpdateRule(string name)
        {
            //$ ManagementPolicyRule ruleToUpdate = null;
            //$ for (ManagementPolicyRule rule : this.Policy().Rules()) {
            //$ if (rule.Name().Equals(name)) {
            //$ ruleToUpdate = rule;
            //$ }
            //$ }
            //$ if (ruleToUpdate == null) {
            //$ throw new UnsupportedOperationException("There is no rule that exists with the name " + name + ". Please define a rule with this name before updating.");
            //$ }
            //$ return new PolicyRuleImpl(ruleToUpdate, this);

            return null;
        }

                public ManagementPolicyImpl WithExistingStorageAccount(string resourceGroupName, string accountName)
        {
            //$ this.resourceGroupName = resourceGroupName;
            //$ this.accountName = accountName;
            //$ return this;

            return this;
        }

                public ManagementPolicy.Update.IUpdate WithoutRule(string name)
        {
            //$ ManagementPolicyRule ruleToDelete = null;
            //$ for (ManagementPolicyRule rule : this.Policy().Rules()) {
            //$ if (rule.Name().Equals(name)) {
            //$ ruleToDelete = rule;
            //$ }
            //$ }
            //$ if (ruleToDelete == null) {
            //$ throw new UnsupportedOperationException("There is no rule that exists with the name " + name + " so this rule can not be deleted.");
            //$ }
            //$ List<ManagementPolicyRule> currentRules = this.upolicy.Rules();
            //$ currentRules.Remove(ruleToDelete);
            //$ this.upolicy.WithRules(currentRules);
            //$ return this;

            return null;
        }

                public ManagementPolicyImpl WithPolicy(ManagementPolicySchema policy)
        {
            //$ if (isInCreateMode()) {
            //$ this.cpolicy = policy;
            //$ } else {
            //$ this.upolicy = policy;
            //$ }
            //$ return this;

            return this;
        }
    }
}