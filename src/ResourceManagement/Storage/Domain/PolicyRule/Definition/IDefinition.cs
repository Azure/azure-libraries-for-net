// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// The stage of the management policy rule definition allowing to specify the type of the rule.
    /// </summary>
    public interface IWithPolicyRuleType 
    {

        /// <summary>
        /// The function that specifies Lifecycle as the type of the management policy rule.
        /// </summary>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithBlobTypesToFilterFor WithLifecycleRuleType();
    }

    /// <summary>
    /// Container interface for all of the definitions related to a rule in a management policy.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IBlank,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleType,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithBlobTypesToFilterFor,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IPrefixActionFork,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPrefixesToFilterFor,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithRuleActions,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleAttachable
    {

    }

    /// <summary>
    /// The stage of the management policy rule definition allowing input an optional blob prefix to filter for before
    /// specifying the actions.
    /// </summary>
    public interface IPrefixActionFork  :
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPrefixesToFilterFor,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithRuleActions
    {

    }

    /// <summary>
    /// The stage of the management policy rule definition allowing the specify the prefixes for the blobs that the rule will apply to.
    /// </summary>
    public interface IWithPrefixesToFilterFor 
    {

        /// <summary>
        /// The function that specifies the list of prefixes for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefixes">A list of the prefixes for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithRuleActions WithPrefixesToFilterFor(IList<string> prefixes);

        /// <summary>
        /// The function that specifies a prefix for the blobs that the rule will apply to.
        /// </summary>
        /// <param name="prefix">A prefix for the blobs that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithRuleActions WithPrefixToFilterFor(string prefix);
    }

    /// <summary>
    /// The stage of the management policy rule definition allowing to specify the blob types that the rule will apply to.
    /// </summary>
    public interface IWithBlobTypesToFilterFor 
    {

        /// <summary>
        /// The function that specifies the list of blob types that the rule will apply to.
        /// </summary>
        /// <param name="blobTypes">A list of the types of blob the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IPrefixActionFork WithBlobTypesToFilterFor(IList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> blobTypes);

        /// <summary>
        /// The function that specifies a blob type that the rule will apply to.
        /// </summary>
        /// <param name="blobType">A blob type that the rule will apply to.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IPrefixActionFork WithBlobTypeToFilterFor(BlobTypes blobType);
    }

    /// <summary>
    /// The stage of the management policy rule definition allowing to specify the actions to perform on the selected blobs.
    /// </summary>
    public interface IWithRuleActions 
    {

        /// <summary>
        /// The function that specifies all of the actions to apply to selected base blobs.
        /// </summary>
        /// <param name="baseBlobActions">An object including all of the actions to apply to selected base blobs.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleAttachable WithActionsOnBaseBlob(ManagementPolicyBaseBlob baseBlobActions);

        /// <summary>
        /// The function that specifies all of the actions to apply to selected snapshots.
        /// </summary>
        /// <param name="snapShotActions">An object including all of the actions to apply to selected snapshots.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleAttachable WithActionsOnSnapShot(ManagementPolicySnapShot snapShotActions);

        /// <summary>
        /// The function that specifies a delete action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilDeleting">The number of days after a base blob is last modified until it is deleted.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleAttachable WithDeleteActionOnBaseBlob(int daysAfterBaseBlobModificationUntilDeleting);

        /// <summary>
        /// The function that specifies a delete action on the selected snapshots.
        /// </summary>
        /// <param name="daysAfterSnapShotCreationUntilDeleting">The number of days after a snapshot is created until it is deleted.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleAttachable WithDeleteActionOnSnapShot(int daysAfterSnapShotCreationUntilDeleting);

        /// <summary>
        /// The function that specifies a tier to archive action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilArchiving">The number of days after a base blob is last modified until it is archived.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleAttachable WithTierToArchiveActionOnBaseBlob(int daysAfterBaseBlobModificationUntilArchiving);

        /// <summary>
        /// The function that specifies a tier to cool action on the selected base blobs.
        /// </summary>
        /// <param name="daysAfterBaseBlobModificationUntilCooling">The number of days after a base blob is last modified until it is cooled.</param>
        /// <return>The next stage of the management policy rule definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleAttachable WithTierToCoolActionOnBaseBlob(int daysAfterBaseBlobModificationUntilCooling);
    }

    /// <summary>
    /// The stage of the definition which contains all of the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithPolicyRuleAttachable  :
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithRuleActions,
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPrefixesToFilterFor,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IAttachable<Microsoft.Azure.Management.Storage.Fluent.ManagementPolicy.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The first stage of a management policy rule definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Storage.Fluent.PolicyRule.Definition.IWithPolicyRuleType
    {

    }
}