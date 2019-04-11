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

        internal ManagementPolicyImpl(string name, StorageManager manager) : base(name, new ManagementPolicyInner())
        {
            this.manager = manager;
            // Set resource name
            this.accountName = name;
            //
            this.cpolicy = new ManagementPolicySchema();
            this.upolicy = new ManagementPolicySchema();

        }

        internal ManagementPolicyImpl(ManagementPolicyInner inner, StorageManager manager) : base(inner.Name, inner)
        {
            this.manager = manager;
            // Set resource name
            this.accountName = inner.Name;
            // set resource ancestor and positional variables
            this.resourceGroupName = GetValueFromIdByName(inner.Id, "resourceGroups");
            this.accountName = GetValueFromIdByName(inner.Id, "storageAccounts");
            //
            this.cpolicy = new ManagementPolicySchema();
            this.upolicy = new ManagementPolicySchema();
        }

        internal void DefineRule(PolicyRuleImpl policyRuleImpl)
        {
            if (IsInCreateMode())
            {
                if (this.cpolicy.Rules == null)
                {
                    this.cpolicy.Rules = new List<ManagementPolicyRule>();
                }
                List<ManagementPolicyRule> rules = this.cpolicy.Rules as List<ManagementPolicyRule>;
                rules.Add(policyRuleImpl.Inner());
                this.cpolicy.Rules = rules;
            }
            else
            {
                if (this.upolicy.Rules == null)
                {
                    this.upolicy.Rules = new List<ManagementPolicyRule>();
                }
                List<ManagementPolicyRule> rules = this.upolicy.Rules as List<ManagementPolicyRule>;
                rules.Add(policyRuleImpl.Inner());
                this.upolicy.Rules = rules;
            }
        }

        private void ResetCreateUpdateParameters()
        {
            this.cpolicy = new ManagementPolicySchema();
            this.upolicy = new ManagementPolicySchema();
        }

        protected override async Task<ManagementPolicyInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IManagementPoliciesOperations client = this.manager.Inner.ManagementPolicies;
            return await client.GetAsync(this.resourceGroupName, this.accountName);
        }

        public override async Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode())
            {
                IManagementPoliciesOperations client = this.manager.Inner.ManagementPolicies;
                ManagementPolicyInner managementPolicyInner = await client.CreateOrUpdateAsync(this.resourceGroupName, this.accountName, this.cpolicy);
                ResetCreateUpdateParameters();
                this.SetInner(managementPolicyInner);
                return this;
            } else
            {
                await UpdateResourceAsync(cancellationToken);
                return this;
            }
        }

        public PolicyRule.Definition.IBlank DefineRule(string name)
        {
            return new PolicyRuleImpl(this, name);
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public bool IsInCreateMode()
        {
            return this.Inner.Id == null;
        }

        public DateTime? LastModifiedTime()
        {
            return this.Inner.LastModifiedTime;
        }

        public StorageManager Manager()
        {
            return this.manager;
        }

        public string Name()
        {
            return this.Inner.Name;
        }

        public ManagementPolicySchema Policy()
        {
            return this.Inner.Policy;
        }

        public IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.IPolicyRule> Rules()
        {
            List<ManagementPolicyRule> originalRules = this.Inner.Policy.Rules as List<ManagementPolicyRule>;
            List<IPolicyRule> returnRules = new List<IPolicyRule>();
            foreach (ManagementPolicyRule originalRule in originalRules)
            {
                List<String> originalBlobTypes = originalRule.Definition.Filters.BlobTypes as List<String>;
                List<BlobTypes> returnBlobTypes = new List<BlobTypes>();
                foreach (String originalBlobType in originalBlobTypes)
                {
                    returnBlobTypes.Add(BlobTypes.Parse(originalBlobType));
                }
                IPolicyRule returnRule = new PolicyRuleImpl(originalRule.Name)
                .WithLifecycleRuleType()
                .WithBlobTypesToFilterFor(returnBlobTypes);

                // building up prefixes to filter on
                if (originalRule.Definition.Filters.PrefixMatch != null)
                {
                    ((PolicyRuleImpl)returnRule).WithPrefixesToFilterFor(originalRule.Definition.Filters.PrefixMatch);
                }

                // building up actions on base blob
                ManagementPolicyBaseBlob originalBaseBlobActions = originalRule.Definition.Actions.BaseBlob;
                if (originalBaseBlobActions != null)
                {
                    if (originalBaseBlobActions.TierToCool != null)
                    {
                        ((PolicyRuleImpl)returnRule).WithTierToCoolActionOnBaseBlob(originalBaseBlobActions.TierToCool.DaysAfterModificationGreaterThan);
                    }
                    if (originalBaseBlobActions.TierToArchive != null)
                    {
                        ((PolicyRuleImpl)returnRule).WithTierToArchiveActionOnBaseBlob(originalBaseBlobActions.TierToArchive.DaysAfterModificationGreaterThan);
                    }
                    if (originalBaseBlobActions.Delete != null)
                    {
                        ((PolicyRuleImpl)returnRule).WithDeleteActionOnBaseBlob(originalBaseBlobActions.Delete.DaysAfterModificationGreaterThan);
                    }
                }

                // build up actions on snapshot
                ManagementPolicySnapShot originalSnapshotActions = originalRule.Definition.Actions.Snapshot;
                if (originalSnapshotActions != null)
                {
                    if (originalSnapshotActions.Delete != null)
                    {
                        ((PolicyRuleImpl)returnRule).WithDeleteActionOnSnapShot(originalSnapshotActions.Delete.DaysAfterCreationGreaterThan);
                    }
                }
                returnRules.Add(returnRule);
            }
            return returnRules.AsReadOnly();
        }

        public string Type()
        {
            return this.Inner.Type;
        }

        private async Task<Microsoft.Azure.Management.Storage.Fluent.IManagementPolicy> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IManagementPoliciesOperations client = this.manager.Inner.ManagementPolicies;
            ManagementPolicyInner managementPolicyInner = await client.CreateOrUpdateAsync(this.resourceGroupName, this.accountName, this.upolicy);
            ResetCreateUpdateParameters();
            this.SetInner(managementPolicyInner);
            return this;
        }

        public PolicyRule.Update.IUpdate UpdateRule(string name)
        {
            ManagementPolicyRule ruleToUpdate = null;
            foreach (ManagementPolicyRule rule in this.Inner.Policy.Rules)
            {
                if (rule.Name.Equals(name))
                {
                    ruleToUpdate = rule;
                }
            }
            if (ruleToUpdate == null)
            {
                throw new NotSupportedException("There is no rule that exists with the name " + name + ". Please define a rule with this name before updating.");
            }
            return new PolicyRuleImpl(ruleToUpdate, this);
        }

        public ManagementPolicyImpl WithExistingStorageAccount(string resourceGroupName, string accountName)
        {
            this.resourceGroupName = resourceGroupName;
            this.accountName = accountName;
            return this;
        }

        public ManagementPolicy.Update.IUpdate WithoutRule(string name)
        {
            ManagementPolicyRule ruleToDelete = null;
            foreach (ManagementPolicyRule rule in this.Inner.Policy.Rules)
            {
                if (rule.Name.Equals(name))
                {
                    ruleToDelete = rule;
                }
            }
            if (ruleToDelete == null)
            {
                throw new NotSupportedException("There is no rule that exists with the name " + name + " so this rule can not be deleted.");
            }
            List<ManagementPolicyRule> currentRules = this.upolicy.Rules as List<ManagementPolicyRule>;
            currentRules.Remove(ruleToDelete);
            this.upolicy.Rules = currentRules;
            return this;
        }

        public ManagementPolicyImpl WithPolicy(ManagementPolicySchema policy)
        {
            if (IsInCreateMode())
            {
                this.cpolicy = policy;
            }
            else
            {
                this.upolicy = policy;
            }
            return this;
        }

        private static string GetValueFromIdByName(string id, string name)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                IEnumerable<string> enumerable = id.Split(new char[] { '/' });
                var itr = enumerable.GetEnumerator();
                while (itr.MoveNext())
                {
                    string part = itr.Current;
                    if (!string.IsNullOrEmpty(part))
                    {
                        if (part.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            if (itr.MoveNext())
                            {
                                return itr.Current;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                return null;
            }
        }
    }
}