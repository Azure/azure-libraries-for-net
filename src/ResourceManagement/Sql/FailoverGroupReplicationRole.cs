// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for FailoverGroupReplicationRole.
    /// </summary>
    public class FailoverGroupReplicationRole : ExpandableStringEnum<FailoverGroupReplicationRole>
    {
        public static readonly FailoverGroupReplicationRole Primary = Parse("Primary");
        public static readonly FailoverGroupReplicationRole Secondary = Parse("Secondary");
    }
}
