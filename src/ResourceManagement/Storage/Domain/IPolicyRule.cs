// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of a rule in an Azure Management Policy.
    /// </summary>
    public interface IPolicyRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<ManagementPolicyRule>
    {

        /// <summary>
        /// Gets an object describing the actions to take on the filtered base blobs in this rule.
        /// </summary>
        ManagementPolicyBaseBlob ActionsOnBaseBlob { get; }

        /// <summary>
        /// Gets an object describing the actions to take on the filtered snapshot in this rule.
        /// </summary>
        ManagementPolicySnapShot ActionsOnSnapShot { get; }

        /// <summary>
        /// Gets an unmodifiable list of the blob types this rule will apply for.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Storage.Fluent.BlobTypes> BlobTypesToFilterFor { get; }

        /// <summary>
        /// Gets the number of days after a filtered base blob is last modified when the tier to archive action is enacted.
        /// </summary>
        int? DaysAfterBaseBlobModificationUntilArchiving { get; }

        /// <summary>
        /// Gets the number of days after a filtered base blob is last modified when the tier to cool action is enacted.
        /// </summary>
        int? DaysAfterBaseBlobModificationUntilCooling { get; }

        /// <summary>
        /// Gets the number of days after a filtered base blob is last modified when the delete action is enacted.
        /// </summary>
        int? DaysAfterBaseBlobModificationUntilDeleting { get; }

        /// <summary>
        /// Gets the number of days after a filtered snapshot is created when the delete action is enacted.
        /// </summary>
        int? DaysAfterSnapShotCreationUntilDeleting { get; }

        /// <summary>
        /// Gets whether there is a delete action specified for the filtered base blobs in this rule.
        /// </summary>
        bool DeleteActionOnBaseBlobEnabled { get; }

        /// <summary>
        /// Gets whether there is a delete action specified for the filtered snapshots in this rule.
        /// </summary>
        bool DeleteActionOnSnapShotEnabled { get; }

        /// <summary>
        /// Gets the name of the rule.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets an unmodifiable list of the prefixes of the blob types this rule will apply for.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> PrefixesToFilterFor { get; }

        /// <summary>
        /// Gets whether there is a tier to archive action specified for the filtered base blobs in this rule.
        /// </summary>
        bool TierToArchiveActionOnBaseBlobEnabled { get; }

        /// <summary>
        /// Gets whether there is a tier to cool action specified for the filtered base blobs in this rule.
        /// </summary>
        bool TierToCoolActionOnBaseBlobEnabled { get; }

        /// <summary>
        /// Gets the type of the rule.
        /// </summary>
        string Type { get; }
    }
}