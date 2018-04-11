// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for UnitType.
    /// </summary>
    public class SyncMemberState : ExpandableStringEnum<SyncMemberState>
    {
        public static readonly SyncMemberState SyncInProgress = Parse("SyncInProgress");
        public static readonly SyncMemberState SyncSucceeded = Parse("SyncSucceeded");
        public static readonly SyncMemberState SyncFailed = Parse("SyncFailed");
        public static readonly SyncMemberState DisabledTombstoneCleanup = Parse("DisabledTombstoneCleanup");
        public static readonly SyncMemberState DisabledBackupRestore = Parse("DisabledBackupRestore");
        public static readonly SyncMemberState SyncSucceededWithWarnings = Parse("SyncSucceededWithWarnings");
        public static readonly SyncMemberState SyncCancelling = Parse("SyncCancelling");
        public static readonly SyncMemberState SyncCancelled = Parse("SyncCancelled");
        public static readonly SyncMemberState UnProvisioned = Parse("UnProvisioned");
        public static readonly SyncMemberState Provisioning = Parse("Provisioning");
        public static readonly SyncMemberState Provisioned = Parse("Provisioned");
        public static readonly SyncMemberState ProvisionFailed = Parse("ProvisionFailed");
        public static readonly SyncMemberState DeProvisioning = Parse("DeProvisioning");
        public static readonly SyncMemberState DeProvisioned = Parse("DeProvisioned");
        public static readonly SyncMemberState DeProvisionFailed = Parse("DeProvisionFailed");
        public static readonly SyncMemberState Reprovisioning = Parse("Reprovisioning");
        public static readonly SyncMemberState ReprovisionFailed = Parse("ReprovisionFailed");
        public static readonly SyncMemberState UnReprovisioned = Parse("UnReprovisioned");
    }
}
