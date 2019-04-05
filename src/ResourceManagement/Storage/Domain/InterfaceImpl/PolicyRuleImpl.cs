// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update;
    using System.Collections.Generic;

    public partial class PolicyRuleImpl 
    {
        /// <summary>
        /// Gets an object describing the actions to take on the filtered base blobs in this rule.
        /// </summary>
        ManagementPolicyBaseBlob Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.ActionsOnBaseBlob
        {
            get
            {
                return this.ActionsOnBaseBlob();
            }
        }

        /// <summary>
        /// Attaches this child object's definition to its parent's definition.
        /// </summary>
        /// <return>The next stage of the parent object's definition.</return>
        ManagementPolicy.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<ManagementPolicy.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Gets an object describing the actions to take on the filtered snapshot in this rule.
        /// </summary>
        ManagementPolicySnapShot Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.ActionsOnSnapShot
        {
            get
            {
                return this.ActionsOnSnapShot();
            }
        }

        /// <summary>
        /// Gets an unmodifiable list of the blob types this rule will apply for.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.BlobTypesToFilterFor
        {
            get
            {
                return this.BlobTypesToFilterFor();
            }
        }

        /// <summary>
        /// Gets the number of days after a filtered base blob is last modified when the tier to archive action is enacted.
        /// </summary>
        int? Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.DaysAfterBaseBlobModificationUntilArchiving
        {
            get
            {
                return this.DaysAfterBaseBlobModificationUntilArchiving();
            }
        }

        /// <summary>
        /// Gets the number of days after a filtered base blob is last modified when the tier to cool action is enacted.
        /// </summary>
        int? Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.DaysAfterBaseBlobModificationUntilCooling
        {
            get
            {
                return this.DaysAfterBaseBlobModificationUntilCooling();
            }
        }

        /// <summary>
        /// Gets the number of days after a filtered base blob is last modified when the delete action is enacted.
        /// </summary>
        int? Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.DaysAfterBaseBlobModificationUntilDeleting
        {
            get
            {
                return this.DaysAfterBaseBlobModificationUntilDeleting();
            }
        }

        /// <summary>
        /// Gets the number of days after a filtered snapshot is created when the delete action is enacted.
        /// </summary>
        int? Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.DaysAfterSnapShotCreationUntilDeleting
        {
            get
            {
                return this.DaysAfterSnapShotCreationUntilDeleting();
            }
        }

        /// <summary>
        /// Gets whether there is a delete action specified for the filtered base blobs in this rule.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.DeleteActionOnBaseBlobEnabled
        {
            get
            {
                return this.DeleteActionOnBaseBlobEnabled();
            }
        }

        /// <summary>
        /// Gets whether there is a delete action specified for the filtered snapshots in this rule.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.DeleteActionOnSnapShotEnabled
        {
            get
            {
                return this.DeleteActionOnSnapShotEnabled();
            }
        }

        /// <summary>
        /// Gets the name of the rule.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets an unmodifiable list of the prefixes of the blob types this rule will apply for.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.PrefixesToFilterFor
        {
            get
            {
                return this.PrefixesToFilterFor();
            }
        }

        /// <summary>
        /// Gets whether there is a tier to archive action specified for the filtered base blobs in this rule.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.TierToArchiveActionOnBaseBlobEnabled
        {
            get
            {
                return this.TierToArchiveActionOnBaseBlobEnabled();
            }
        }

        /// <summary>
        /// Gets whether there is a tier to cool action specified for the filtered base blobs in this rule.
        /// </summary>
        bool Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.TierToCoolActionOnBaseBlobEnabled
        {
            get
            {
                return this.TierToCoolActionOnBaseBlobEnabled();
            }
        }

        /// <summary>
        /// Gets the type of the rule.
        /// </summary>
        string Microsoft.Azure.Management.Storage.Fluent.IPolicyRule.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// The function that specifies all of the actions to apply to selected base blobs.
        /// </summary>
        /// <param name="baseBlobActions">An object including all of the actions to apply to selected base blobs.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithActions.UpdateActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions)
        {
            return this.UpdateActionsOnBaseBlob(baseBlobActions);
        }

        /// <summary>
        /// The function that specifies all of the actions to apply to selected snapshots.
        /// </summary>
        /// <param name="snapShotActions">An object including all of the actions to apply to selected snapshots.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithActions.UpdateActionsOnSnapShot(ManagementPolicySnapShot snapShotActions)
        {
            return this.UpdateActionsOnSnapShot(snapShotActions);
        }

        /// <summary>
        /// The function that specifies all of the actions to apply to selected base blobs.
        /// </summary>
        /// <param name="baseBlobActions">An object including all of the actions to apply to selected base blobs.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithPolicyRuleAttachable PolicyRule.Definition.IWithRuleActions.WithActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions)
        {
            return this.WithActionsOnBaseBlob(baseBlobActions);
        }

        /// <summary>
        /// The function that specifies all of the actions to apply to selected snapshots.
        /// </summary>
        /// <param name="snapShotActions">An object including all of the actions to apply to selected snapshots.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithPolicyRuleAttachable PolicyRule.Definition.IWithRuleActions.WithActionsOnSnapShot(ManagementPolicySnapShot snapShotActions)
        {
            return this.WithActionsOnSnapShot(snapShotActions);
        }

        /// <summary>
        /// The function that specifies the list of blob types that the rule will apply to.
        /// </summary>
        /// <param name="blobTypes">A list of the types of blob the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithBlobTypesToFilterFor.WithBlobTypesToFilterFor(IList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> blobTypes)
        {
            return this.WithBlobTypesToFilterFor(blobTypes);
        }

        /// <summary>
        /// The function that specifies the list of blob types that the rule will apply to.
        /// </summary>
        /// <param name="blobTypes">A list of the types of blob the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IPrefixActionFork PolicyRule.Definition.IWithBlobTypesToFilterFor.WithBlobTypesToFilterFor(IList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> blobTypes)
        {
            return this.WithBlobTypesToFilterFor(blobTypes);
        }

        /// <summary>
        /// The function that specifies a blob type that the rule will apply to.
        /// </summary>
        /// <param name="blobType">A blob type that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithBlobTypesToFilterFor.WithBlobTypeToFilterFor(BlobTypes blobType)
        {
            return this.WithBlobTypeToFilterFor(blobType);
        }

        /// <summary>
        /// The function that specifies a blob type that the rule will apply to.
        /// </summary>
        /// <param name="blobType">A blob type that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IPrefixActionFork PolicyRule.Definition.IWithBlobTypesToFilterFor.WithBlobTypeToFilterFor(BlobTypes blobType)
        {
            return this.WithBlobTypeToFilterFor(blobType);
        }

        /// <summary>
        /// The function that specifies to remove a blob type that the rule will apply to.
        /// </summary>
        /// <param name="blobType">The blob type that you wish the rule to no longer apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithBlobTypesToFilterFor.WithBlobTypeToFilterForRemoved(BlobTypes blobType)
        {
            return this.WithBlobTypeToFilterForRemoved(blobType);
        }

        /// <summary>
        /// The function that specifies a delete action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilDeleting">The number of days after a base blob is last modified until it is deleted.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithPolicyRuleAttachable PolicyRule.Definition.IWithRuleActions.WithDeleteActionOnBaseBlob(int daysAfterBaseBlobModificationUntilDeleting)
        {
            return this.WithDeleteActionOnBaseBlob(daysAfterBaseBlobModificationUntilDeleting);
        }

        /// <summary>
        /// The function that specifies a delete action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilDeleting">The number of days after a base blob is last modified until it is deleted.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithActions.WithDeleteActionOnBaseBlob(int daysAfterBaseBlobModificationUntilDeleting)
        {
            return this.WithDeleteActionOnBaseBlob(daysAfterBaseBlobModificationUntilDeleting);
        }

        /// <summary>
        /// The function that specifies a delete action on the selected snapshots.
        /// </summary>
        /// <param name="daysAfterSnapShotCreationUntilDeleting">The number of days after a snapshot is created until it is deleted.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithPolicyRuleAttachable PolicyRule.Definition.IWithRuleActions.WithDeleteActionOnSnapShot(int daysAfterSnapShotCreationUntilDeleting)
        {
            return this.WithDeleteActionOnSnapShot(daysAfterSnapShotCreationUntilDeleting);
        }

        /// <summary>
        /// The function that specifies a delete action on the selected snapshots.
        /// </summary>
        /// <param name="daysAfterSnapShotCreationUntilDeleting">The number of days after a snapshot is created until it is deleted.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithActions.WithDeleteActionOnSnapShot(int daysAfterSnapShotCreationUntilDeleting)
        {
            return this.WithDeleteActionOnSnapShot(daysAfterSnapShotCreationUntilDeleting);
        }

        /// <summary>
        /// The function that specifies Lifecycle as the type of the management policy rule.
        /// </summary>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithBlobTypesToFilterFor PolicyRule.Definition.IWithPolicyRuleType.WithLifecycleRuleType()
        {
            return this.WithLifecycleRuleType();
        }

        /// <summary>
        /// The function that clears all blob prefixes so the rule will apply to blobs regardless of prefixes.
        /// </summary>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithPrefixesToFilterFor.WithoutPrefixesToFilterFor()
        {
            return this.WithoutPrefixesToFilterFor();
        }

        /// <summary>
        /// The function that specifies the list of prefixes for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefixes">A list of the prefixes for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithPrefixesToFilterFor.WithPrefixesToFilterFor(IList<string> prefixes)
        {
            return this.WithPrefixesToFilterFor(prefixes);
        }

        /// <summary>
        /// The function that specifies the list of prefixes for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefixes">A list of the prefixes for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithRuleActions PolicyRule.Definition.IWithPrefixesToFilterFor.WithPrefixesToFilterFor(IList<string> prefixes)
        {
            return this.WithPrefixesToFilterFor(prefixes);
        }

        /// <summary>
        /// The function that specifies a prefix for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefix">A prefix for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithPrefixesToFilterFor.WithPrefixToFilterFor(string prefix)
        {
            return this.WithPrefixToFilterFor(prefix);
        }

        /// <summary>
        /// The function that specifies a prefix for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefix">A prefix for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithRuleActions PolicyRule.Definition.IWithPrefixesToFilterFor.WithPrefixToFilterFor(string prefix)
        {
            return this.WithPrefixToFilterFor(prefix);
        }

        /// <summary>
        /// The function that specifies a tier to archive action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilArchiving">The number of days after a base blob is last modified until it is archived.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithPolicyRuleAttachable PolicyRule.Definition.IWithRuleActions.WithTierToArchiveActionOnBaseBlob(int daysAfterBaseBlobModificationUntilArchiving)
        {
            return this.WithTierToArchiveActionOnBaseBlob(daysAfterBaseBlobModificationUntilArchiving);
        }

        /// <summary>
        /// The function that specifies a tier to archive action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilArchiving">The number of days after a base blob is last modified until it is archived.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithActions.WithTierToArchiveActionOnBaseBlob(int daysAfterBaseBlobModificationUntilArchiving)
        {
            return this.WithTierToArchiveActionOnBaseBlob(daysAfterBaseBlobModificationUntilArchiving);
        }

        /// <summary>
        /// The function that specifies a tier to cool action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilCooling">The number of days after a base blob is last modified until it is cooled.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        PolicyRule.Definition.IWithPolicyRuleAttachable PolicyRule.Definition.IWithRuleActions.WithTierToCoolActionOnBaseBlob(int daysAfterBaseBlobModificationUntilCooling)
        {
            return this.WithTierToCoolActionOnBaseBlob(daysAfterBaseBlobModificationUntilCooling);
        }

        /// <summary>
        /// The function that specifies a tier to cool action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilCooling">The number of days after a base blob is last modified until it is cooled.</param>
        /// <return>The next stage of the management policy rule update.</return>
        PolicyRule.Update.IUpdate PolicyRule.Update.IWithActions.WithTierToCoolActionOnBaseBlob(int daysAfterBaseBlobModificationUntilCooling)
        {
            return this.WithTierToCoolActionOnBaseBlob(daysAfterBaseBlobModificationUntilCooling);
        }
    }
}