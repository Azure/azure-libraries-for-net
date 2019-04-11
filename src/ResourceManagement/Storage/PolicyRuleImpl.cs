// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update;
    using System;
    using System.Collections.Generic;

    public partial class PolicyRuleImpl  :
        object,
        IPolicyRule,
        PolicyRule.Definition.IDefinition,
        PolicyRule.Update.IUpdate,
        IHasInner<ManagementPolicyRule>
    {
        private ManagementPolicyRule inner;
        private ManagementPolicyImpl managementPolicyImpl;

        ManagementPolicyRule IHasInner<ManagementPolicyRule>.Inner => this.inner;

        internal PolicyRuleImpl(ManagementPolicyImpl managementPolicyImpl, string name)
        {
            this.inner = new ManagementPolicyRule();
            this.inner.Definition = new ManagementPolicyDefinition();
            this.inner.Definition.Filters = new ManagementPolicyFilter();
            this.inner.Definition.Actions = new ManagementPolicyAction();
            this.managementPolicyImpl = managementPolicyImpl;
            this.inner.Name = name;
        }

        internal  PolicyRuleImpl(string name)
        {
            this.inner = new ManagementPolicyRule();
            this.inner.Definition = new ManagementPolicyDefinition();
            this.inner.Definition.Filters = new ManagementPolicyFilter();
            this.inner.Definition.Actions = new ManagementPolicyAction();
            this.inner.Name = name;
        }

        internal  PolicyRuleImpl(ManagementPolicyRule managementPolicyRule, ManagementPolicyImpl managementPolicyImpl)
        {
            this.inner = managementPolicyRule;
            this.managementPolicyImpl = managementPolicyImpl;
        }

        public ManagementPolicyBaseBlob ActionsOnBaseBlob()
        {
            return this.inner.Definition.Actions.BaseBlob;
        }

        public ManagementPolicySnapShot ActionsOnSnapShot()
        {
            return this.inner.Definition.Actions.Snapshot;
        }

        public ManagementPolicyImpl Attach()
        {
            this.managementPolicyImpl.DefineRule(this);
            return this.managementPolicyImpl;
        }

        public IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> BlobTypesToFilterFor()
        {
            List<BlobTypes> blobTypes = new List<BlobTypes>();
            foreach (String blobTypeString in this.inner.Definition.Filters.BlobTypes)
            {
                blobTypes.Add(BlobTypes.Parse(blobTypeString));
            }
            return blobTypes.AsReadOnly();
        }

        public int? DaysAfterBaseBlobModificationUntilArchiving()
        {
            if (this.inner.Definition.Actions.BaseBlob == null || this.inner.Definition.Actions.BaseBlob.TierToArchive == null)
            {
                return null;
            }
            return this.inner.Definition.Actions.BaseBlob.TierToArchive.DaysAfterModificationGreaterThan;
        }

        public int? DaysAfterBaseBlobModificationUntilCooling()
        {
            if (this.inner.Definition.Actions.BaseBlob == null || this.inner.Definition.Actions.BaseBlob.TierToCool == null)
            {
                return null;
            }
            return this.inner.Definition.Actions.BaseBlob.TierToCool.DaysAfterModificationGreaterThan;
        }

        public int? DaysAfterBaseBlobModificationUntilDeleting()
        {
            if (this.inner.Definition.Actions.BaseBlob == null || this.inner.Definition.Actions.BaseBlob.Delete == null)
            {
                return null;
            }
            return this.inner.Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan;
        }

        public int? DaysAfterSnapShotCreationUntilDeleting()
        {
            if (this.inner.Definition.Actions.Snapshot == null || this.inner.Definition.Actions.Snapshot.Delete == null)
            {
                return null;
            }
            return this.inner.Definition.Actions.Snapshot.Delete.DaysAfterCreationGreaterThan;
        }

        public bool DeleteActionOnBaseBlobEnabled()
        {
            if (this.inner.Definition.Actions.BaseBlob == null)
            {
                return false;
            }
            return this.inner.Definition.Actions.BaseBlob.Delete != null;
        }

        public bool DeleteActionOnSnapShotEnabled()
        {
            if (this.inner.Definition.Actions.Snapshot == null)
            {
                return false;
            }
            return this.inner.Definition.Actions.Snapshot.Delete != null;
        }

        public ManagementPolicyRule Inner()
        {
            return this.inner;
        }

        public string Name()
        {
            return this.inner.Name;
        }

        public ManagementPolicy.Update.IUpdate Parent()
        {
            this.managementPolicyImpl.DefineRule(this);
            return this.managementPolicyImpl;
        }

        public IReadOnlyList<string> PrefixesToFilterFor()
        {
            return (this.inner.Definition.Filters.PrefixMatch as List<string>).AsReadOnly();
        }

        public bool TierToArchiveActionOnBaseBlobEnabled()
        {
            if (this.inner.Definition.Actions.BaseBlob == null)
            {
                return false;
            }
            return this.inner.Definition.Actions.BaseBlob.TierToArchive != null;
        }

        public bool TierToCoolActionOnBaseBlobEnabled()
        {
            if (this.inner.Definition.Actions.BaseBlob == null)
            {
                return false;
            }
            return this.inner.Definition.Actions.BaseBlob.TierToCool != null;
        }

        public string Type()
        {
            return "Lifecycle";
        }

        public PolicyRule.Update.IUpdate UpdateActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions)
        {
            this.inner.Definition.Actions.BaseBlob = baseBlobActions;
            return this;
        }

        public PolicyRule.Update.IUpdate UpdateActionsOnSnapShot(ManagementPolicySnapShot snapShotActions)
        {
            this.inner.Definition.Actions.Snapshot = snapShotActions;
            return this;
        }

        public IWithPolicyRuleAttachable WithActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions)
        {
            this.inner.Definition.Actions.BaseBlob = baseBlobActions;
            return this;
        }

        public IWithPolicyRuleAttachable WithActionsOnSnapShot(ManagementPolicySnapShot snapShotActions)
        {
            this.inner.Definition.Actions.Snapshot = snapShotActions;
            return this;
        }

        public PolicyRuleImpl WithBlobTypesToFilterFor(IList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> blobTypes)
        {
            List<String> blobTypesString = new List<String>();
            foreach (BlobTypes blobType in blobTypes)
            {
                blobTypesString.Add(blobType.ToString());
            }
            this.inner.Definition.Filters.BlobTypes = blobTypesString;
            return this;
        }

        public PolicyRuleImpl WithBlobTypeToFilterFor(BlobTypes blobType)
        {
            List<String> blobTypesToFilterFor = this.inner.Definition.Filters.BlobTypes as List<String>;
            if (blobTypesToFilterFor == null)
            {
                blobTypesToFilterFor = new List<String>();
            }
            if (blobTypesToFilterFor.Contains(blobType.ToString()))
            {
                return this;
            }
            blobTypesToFilterFor.Add(blobType.ToString());
            this.inner.Definition.Filters.BlobTypes = blobTypesToFilterFor;
            return this;
        }

        public PolicyRule.Update.IUpdate WithBlobTypeToFilterForRemoved(BlobTypes blobType)
        {
            List<String> blobTypesToFilterFor = this.inner.Definition.Filters.BlobTypes as List<String>;
            blobTypesToFilterFor.Remove(blobType.ToString());
            this.inner.Definition.Filters.BlobTypes = blobTypesToFilterFor;
            return this;
        }

        public PolicyRuleImpl WithDeleteActionOnBaseBlob(int daysAfterBaseBlobModificationUntilDeleting)
        {
            ManagementPolicyBaseBlob currentBaseBlob = this.inner.Definition.Actions.BaseBlob;
            if (currentBaseBlob == null)
            {
                currentBaseBlob = new ManagementPolicyBaseBlob();
            }
            currentBaseBlob.Delete = new DateAfterModification(daysAfterBaseBlobModificationUntilDeleting);
            this.inner.Definition.Actions.BaseBlob = currentBaseBlob;
            return this;
        }

        public PolicyRuleImpl WithDeleteActionOnSnapShot(int daysAfterSnapShotCreationUntilDeleting)
        {
            ManagementPolicySnapShot currentSnapShot = new ManagementPolicySnapShot();
            if (currentSnapShot == null)
            {
                currentSnapShot = new ManagementPolicySnapShot();
            }
            currentSnapShot.Delete = new DateAfterCreation(daysAfterSnapShotCreationUntilDeleting);
            this.inner.Definition.Actions.Snapshot = currentSnapShot;
            return this;
        }

        public PolicyRuleImpl WithLifecycleRuleType()
        {
            return this;
        }

        public PolicyRule.Update.IUpdate WithoutPrefixesToFilterFor()
        {
            this.inner.Definition.Filters.PrefixMatch = null;
            return this;
        }

        public PolicyRuleImpl WithPrefixesToFilterFor(IList<string> prefixes)
        {
            this.inner.Definition.Filters.PrefixMatch = prefixes;
            return this;
        }

        public PolicyRuleImpl WithPrefixToFilterFor(string prefix)
        {
            List<String> prefixesToFilterFor = this.inner.Definition.Filters.PrefixMatch as List<String>;
            if (prefixesToFilterFor == null)
            {
                prefixesToFilterFor = new List<String>();
            }
            if (prefixesToFilterFor.Contains(prefix))
            {
                return this;
            }
            prefixesToFilterFor.Add(prefix);
            this.inner.Definition.Filters.PrefixMatch = prefixesToFilterFor;
            return this;
        }

        public PolicyRuleImpl WithTierToArchiveActionOnBaseBlob(int daysAfterBaseBlobModificationUntilArchiving)
        {
            ManagementPolicyBaseBlob currentBaseBlob = this.inner.Definition.Actions.BaseBlob;
            if (currentBaseBlob == null)
            {
                currentBaseBlob = new ManagementPolicyBaseBlob();
            }
            currentBaseBlob.TierToArchive = new DateAfterModification(daysAfterBaseBlobModificationUntilArchiving);
            this.inner.Definition.Actions.BaseBlob = currentBaseBlob;
            return this;
        }

        public PolicyRuleImpl WithTierToCoolActionOnBaseBlob(int daysAfterBaseBlobModificationUntilCooling)
        {
            ManagementPolicyBaseBlob currentBaseBlob = this.inner.Definition.Actions.BaseBlob;
            if (currentBaseBlob == null)
            {
                currentBaseBlob = new ManagementPolicyBaseBlob();
            }
            currentBaseBlob.TierToCool = new DateAfterModification(daysAfterBaseBlobModificationUntilCooling);
            this.inner.Definition.Actions.BaseBlob = currentBaseBlob;
            return this;
        }
    }
}