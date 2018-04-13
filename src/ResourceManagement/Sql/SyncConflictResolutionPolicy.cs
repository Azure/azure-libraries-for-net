// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for SyncConflictResolutionPolicy.
    /// </summary>
    public class SyncConflictResolutionPolicy : ExpandableStringEnum<SyncConflictResolutionPolicy>
    {
        public static readonly SyncConflictResolutionPolicy HubWin = Parse("HubWin");
        public static readonly SyncConflictResolutionPolicy MemberWin = Parse("MemberWin");
    }
}
