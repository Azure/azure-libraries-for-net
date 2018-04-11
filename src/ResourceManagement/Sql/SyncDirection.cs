// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for SyncDirection.
    /// </summary>
    public class SyncDirection : ExpandableStringEnum<SyncDirection>
    {
        public static readonly SyncDirection Bidirectional = Parse("Bidirectional");
        public static readonly SyncDirection OneWayMemberToHub = Parse("OneWayMemberToHub");
        public static readonly SyncDirection OneWayHubToMember = Parse("OneWayHubToMember");
    }
}
