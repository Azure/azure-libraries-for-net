// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for UnitType.
    /// </summary>
    public class SyncMemberDbType : ExpandableStringEnum<SyncMemberDbType>
    {
        public static readonly SyncMemberDbType AzureSqlDatabase = Parse("AzureSqlDatabase");
        public static readonly SyncMemberDbType SqlServerDatabase = Parse("SqlServerDatabase");
    }
}
