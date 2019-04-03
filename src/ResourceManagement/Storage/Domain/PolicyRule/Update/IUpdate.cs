// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// THe stage of the management policy rule update allowing to specify the prefixes for the blobs that the rule will apply to.
    /// </summary>
    public interface IWithPrefixesToFilterFor 
    {

        /// <summary>
        /// The function that clears all blob prefixes so the rule will apply to blobs regardless of prefixes.
        /// </summary>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithoutPrefixesToFilterFor();

        /// <summary>
        /// The function that specifies the list of prefixes for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefixes">A list of the prefixes for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithPrefixesToFilterFor(IList<string> prefixes);

        /// <summary>
        /// The function that specifies a prefix for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefix">A prefix for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithPrefixToFilterFor(string prefix);
    }

    /// <summary>
    /// Container interface for all of the updates related to a rule in a management policy.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IWithBlobTypesToFilterFor,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IWithPrefixesToFilterFor,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IWithActions,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Update.IUpdate>
    {

    }

    /// <summary>
    /// The stage of the management policy rule update allowing to specify the blob types that the rule will apply to.
    /// </summary>
    public interface IWithBlobTypesToFilterFor 
    {

        /// <summary>
        /// The function that specifies the list of blob types that the rule will apply to.
        /// </summary>
        /// <param name="blobTypes">A list of the types of blob the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithBlobTypesToFilterFor(IList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> blobTypes);

        /// <summary>
        /// The function that specifies a blob type that the rule will apply to.
        /// </summary>
        /// <param name="blobType">A blob type that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithBlobTypeToFilterFor(BlobTypes blobType);

        /// <summary>
        /// The function that specifies to remove a blob type that the rule will apply to.
        /// </summary>
        /// <param name="blobType">The blob type that you wish the rule to no longer apply to.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithBlobTypeToFilterForRemoved(BlobTypes blobType);
    }

    /// <summary>
    /// The stage of the management policy rule update allowing to specify the actions to perform on the selected blobs.
    /// </summary>
    public interface IWithActions 
    {

        /// <summary>
        /// The function that specifies all of the actions to apply to selected base blobs.
        /// </summary>
        /// <param name="baseBlobActions">An object including all of the actions to apply to selected base blobs.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate UpdateActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions);

        /// <summary>
        /// The function that specifies all of the actions to apply to selected snapshots.
        /// </summary>
        /// <param name="snapShotActions">An object including all of the actions to apply to selected snapshots.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate UpdateActionsOnSnapShot(ManagementPolicySnapShot snapShotActions);

        /// <summary>
        /// The function that specifies a delete action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilDeleting">The number of days after a base blob is last modified until it is deleted.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithDeleteActionOnBaseBlob(int daysAfterBaseBlobModificationUntilDeleting);

        /// <summary>
        /// The function that specifies a delete action on the selected snapshots.
        /// </summary>
        /// <param name="daysAfterSnapShotCreationUntilDeleting">The number of days after a snapshot is created until it is deleted.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithDeleteActionOnSnapShot(int daysAfterSnapShotCreationUntilDeleting);

        /// <summary>
        /// The function that specifies a tier to archive action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilArchiving">The number of days after a base blob is last modified until it is archived.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithTierToArchiveActionOnBaseBlob(int daysAfterBaseBlobModificationUntilArchiving);

        /// <summary>
        /// The function that specifies a tier to cool action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilCooling">The number of days after a base blob is last modified until it is cooled.</param>
        /// <return>The next stage of the management policy rule update.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Update.IUpdate WithTierToCoolActionOnBaseBlob(int daysAfterBaseBlobModificationUntilCooling);
    }
}