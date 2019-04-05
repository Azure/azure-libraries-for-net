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

        internal  PolicyRuleImpl(ManagementPolicyImpl managementPolicyImpl, string name)
        {
            //$ this.inner = new ManagementPolicyRule();
            //$ this.inner.WithDefinition(new ManagementPolicyDefinition());
            //$ this.inner.Definition().WithFilters(new ManagementPolicyFilter());
            //$ this.inner.Definition().WithActions(new ManagementPolicyAction());
            //$ this.managementPolicyImpl = managementPolicyImpl;
            //$ this.inner.WithName(name);
            //$ }

        }

                internal  PolicyRuleImpl(string name)
        {
            //$ this.inner = new ManagementPolicyRule();
            //$ this.inner.WithDefinition(new ManagementPolicyDefinition());
            //$ this.inner.Definition().WithFilters(new ManagementPolicyFilter());
            //$ this.inner.Definition().WithActions(new ManagementPolicyAction());
            //$ this.inner.WithName(name);
            //$ }

        }

                internal  PolicyRuleImpl(ManagementPolicyRule managementPolicyRule, ManagementPolicyImpl managementPolicyImpl)
        {
            //$ this.inner = managementPolicyRule;
            //$ this.managementPolicyImpl = managementPolicyImpl;
            //$ }

        }

                public ManagementPolicyBaseBlob ActionsOnBaseBlob()
        {
            //$ return this.inner.Definition().Actions().BaseBlob();

            return null;
        }

                public ManagementPolicySnapShot ActionsOnSnapShot()
        {
            //$ return this.inner.Definition().Actions().Snapshot();

            return null;
        }

                public ManagementPolicyImpl Attach()
        {
            //$ this.managementPolicyImpl.DefineRule(this);
            //$ return this.managementPolicyImpl;

            return null;
        }

                public IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> BlobTypesToFilterFor()
        {
            //$ List<BlobTypes> blobTypes = new ArrayList<>();
            //$ for (String blobTypeString : this.inner.Definition().Filters().BlobTypes()) {
            //$ blobTypes.Add(BlobTypes.FromString(blobTypeString));
            //$ }
            //$ return Collections.UnmodifiableList(blobTypes);

            return null;
        }

                public int? DaysAfterBaseBlobModificationUntilArchiving()
        {
            //$ if (this.inner.Definition().Actions().BaseBlob() == null || this.inner.Definition().Actions().BaseBlob().TierToArchive() == null) {
            //$ return null;
            //$ }
            //$ return this.inner.Definition().Actions().BaseBlob().TierToArchive().DaysAfterModificationGreaterThan();

            return null;
        }

                public int? DaysAfterBaseBlobModificationUntilCooling()
        {
            //$ if (this.inner.Definition().Actions().BaseBlob() == null || this.inner.Definition().Actions().BaseBlob().TierToCool() == null) {
            //$ return null;
            //$ }
            //$ return this.inner.Definition().Actions().BaseBlob().TierToCool().DaysAfterModificationGreaterThan();

            return null;
        }

                public int? DaysAfterBaseBlobModificationUntilDeleting()
        {
            //$ if (this.inner.Definition().Actions().BaseBlob() == null || this.inner.Definition().Actions().BaseBlob().Delete() == null) {
            //$ return null;
            //$ }
            //$ return this.inner.Definition().Actions().BaseBlob().Delete().DaysAfterModificationGreaterThan();

            return null;
        }

                public int? DaysAfterSnapShotCreationUntilDeleting()
        {
            //$ if (this.inner.Definition().Actions().Snapshot() == null || this.inner.Definition().Actions().Snapshot().Delete() == null) {
            //$ return null;
            //$ }
            //$ return this.inner.Definition().Actions().Snapshot().Delete().DaysAfterCreationGreaterThan();

            return null;
        }

                public bool DeleteActionOnBaseBlobEnabled()
        {
            //$ if (this.inner.Definition().Actions().BaseBlob() == null) {
            //$ return false;
            //$ }
            //$ return this.inner.Definition().Actions().BaseBlob().Delete() != null;

            return false;
        }

                public bool DeleteActionOnSnapShotEnabled()
        {
            //$ if (this.inner.Definition().Actions().Snapshot() == null) {
            //$ return false;
            //$ }
            //$ return this.inner.Definition().Actions().Snapshot().Delete() != null;

            return false;
        }

                public ManagementPolicyRule Inner()
        {
            //$ return this.inner;

            return null;
        }

                public string Name()
        {
            //$ return this.inner.Name();

            return null;
        }

                public ManagementPolicy.Update.IUpdate Parent()
        {
            //$ this.managementPolicyImpl.DefineRule(this);
            //$ return this.managementPolicyImpl;

            return null;
        }

                public IReadOnlyList<string> PrefixesToFilterFor()
        {
            //$ return Collections.UnmodifiableList(this.inner.Definition().Filters().PrefixMatch());

            return null;
        }

                public bool TierToArchiveActionOnBaseBlobEnabled()
        {
            //$ if (this.inner.Definition().Actions().BaseBlob() == null) {
            //$ return false;
            //$ }
            //$ return this.inner.Definition().Actions().BaseBlob().TierToArchive() != null;

            return false;
        }

                public bool TierToCoolActionOnBaseBlobEnabled()
        {
            //$ if (this.inner.Definition().Actions().BaseBlob() == null) {
            //$ return false;
            //$ }
            //$ return this.inner.Definition().Actions().BaseBlob().TierToCool() != null;

            return false;
        }

                public string Type()
        {
            //$ return this.inner.Type();

            return null;
        }

                public PolicyRule.Update.IUpdate UpdateActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions)
        {
            //$ this.inner.Definition().Actions().WithBaseBlob(baseBlobActions);
            //$ return this;

            return null;
        }

                public PolicyRule.Update.IUpdate UpdateActionsOnSnapShot(ManagementPolicySnapShot snapShotActions)
        {
            //$ this.inner.Definition().Actions().WithSnapshot(snapShotActions);
            //$ return this;

            return null;
        }

                public IWithPolicyRuleAttachable WithActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions)
        {
            //$ this.inner.Definition().Actions().WithBaseBlob(baseBlobActions);
            //$ return this;

            return null;
        }

                public IWithPolicyRuleAttachable WithActionsOnSnapShot(ManagementPolicySnapShot snapShotActions)
        {
            //$ this.inner.Definition().Actions().WithSnapshot(snapShotActions);
            //$ return this;

            return null;
        }

                public PolicyRuleImpl WithBlobTypesToFilterFor(IList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> blobTypes)
        {
            //$ List<String> blobTypesString = new ArrayList<>();
            //$ for (BlobTypes blobType : blobTypes) {
            //$ blobTypesString.Add(blobType.ToString());
            //$ }
            //$ this.inner.Definition().Filters().WithBlobTypes(blobTypesString);
            //$ return this;

            return this;
        }

                public PolicyRuleImpl WithBlobTypeToFilterFor(BlobTypes blobType)
        {
            //$ List<String> blobTypesToFilterFor = this.inner.Definition().Filters().BlobTypes();
            //$ if (blobTypesToFilterFor == null) {
            //$ blobTypesToFilterFor = new ArrayList<>();
            //$ }
            //$ if (blobTypesToFilterFor.Contains(blobType)) {
            //$ return this;
            //$ }
            //$ blobTypesToFilterFor.Add(blobType.ToString());
            //$ this.inner.Definition().Filters().WithBlobTypes(blobTypesToFilterFor);
            //$ return this;

            return this;
        }

                public PolicyRule.Update.IUpdate WithBlobTypeToFilterForRemoved(BlobTypes blobType)
        {
            //$ List<String> blobTypesToFilterFor = this.inner.Definition().Filters().BlobTypes();
            //$ blobTypesToFilterFor.Remove(blobType.ToString());
            //$ this.inner.Definition().Filters().WithBlobTypes(blobTypesToFilterFor);
            //$ return this;

            return null;
        }

                public PolicyRuleImpl WithDeleteActionOnBaseBlob(int daysAfterBaseBlobModificationUntilDeleting)
        {
            //$ ManagementPolicyBaseBlob currentBaseBlob = this.inner.Definition().Actions().BaseBlob();
            //$ if (currentBaseBlob == null) {
            //$ currentBaseBlob = new ManagementPolicyBaseBlob();
            //$ }
            //$ currentBaseBlob.WithDelete(new DateAfterModification().WithDaysAfterModificationGreaterThan(daysAfterBaseBlobModificationUntilDeleting));
            //$ this.inner.Definition().Actions().WithBaseBlob(currentBaseBlob);
            //$ return this;

            return this;
        }

                public PolicyRuleImpl WithDeleteActionOnSnapShot(int daysAfterSnapShotCreationUntilDeleting)
        {
            //$ ManagementPolicySnapShot currentSnapShot = new ManagementPolicySnapShot();
            //$ if (currentSnapShot == null) {
            //$ currentSnapShot = new ManagementPolicySnapShot();
            //$ }
            //$ currentSnapShot.WithDelete(new DateAfterCreation().WithDaysAfterCreationGreaterThan(daysAfterSnapShotCreationUntilDeleting));
            //$ this.inner.Definition().Actions().WithSnapshot(currentSnapShot);
            //$ return this;

            return this;
        }

                public PolicyRuleImpl WithLifecycleRuleType()
        {
            //$ this.inner.WithType("Lifecycle");
            //$ return this;

            return this;
        }

                public PolicyRule.Update.IUpdate WithoutPrefixesToFilterFor()
        {
            //$ this.inner.Definition().Filters().WithPrefixMatch(null);
            //$ return this;

            return null;
        }

                public PolicyRuleImpl WithPrefixesToFilterFor(IList<string> prefixes)
        {
            //$ this.inner.Definition().Filters().WithPrefixMatch(prefixes);
            //$ return this;

            return this;
        }

                public PolicyRuleImpl WithPrefixToFilterFor(string prefix)
        {
            //$ List<String> prefixesToFilterFor = this.inner.Definition().Filters().PrefixMatch();
            //$ if (prefixesToFilterFor == null) {
            //$ prefixesToFilterFor = new ArrayList<>();
            //$ }
            //$ if (prefixesToFilterFor.Contains(prefix)) {
            //$ return this;
            //$ }
            //$ prefixesToFilterFor.Add(prefix);
            //$ this.inner.Definition().Filters().WithPrefixMatch(prefixesToFilterFor);
            //$ return this;

            return this;
        }

                public PolicyRuleImpl WithTierToArchiveActionOnBaseBlob(int daysAfterBaseBlobModificationUntilArchiving)
        {
            //$ ManagementPolicyBaseBlob currentBaseBlob = this.inner.Definition().Actions().BaseBlob();
            //$ if (currentBaseBlob == null) {
            //$ currentBaseBlob = new ManagementPolicyBaseBlob();
            //$ }
            //$ currentBaseBlob.WithTierToArchive(new DateAfterModification().WithDaysAfterModificationGreaterThan(daysAfterBaseBlobModificationUntilArchiving));
            //$ this.inner.Definition().Actions().WithBaseBlob(currentBaseBlob);
            //$ return this;

            return this;
        }

                public PolicyRuleImpl WithTierToCoolActionOnBaseBlob(int daysAfterBaseBlobModificationUntilCooling)
        {
            //$ ManagementPolicyBaseBlob currentBaseBlob = this.inner.Definition().Actions().BaseBlob();
            //$ if (currentBaseBlob == null) {
            //$ currentBaseBlob = new ManagementPolicyBaseBlob();
            //$ }
            //$ currentBaseBlob.WithTierToCool(new DateAfterModification().WithDaysAfterModificationGreaterThan(daysAfterBaseBlobModificationUntilCooling));
            //$ this.inner.Definition().Actions().WithBaseBlob(currentBaseBlob);
            //$ return this;

            return this;
        }
    }
}