// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for UnitType.
    /// </summary>
    public class SyncGroupLogType : ExpandableStringEnum<SyncGroupLogType>
    {
        public static readonly SyncGroupLogType All = Parse("All");
        public static readonly SyncGroupLogType Error = Parse("Error");
        public static readonly SyncGroupLogType Warning = Parse("Warning");
        public static readonly SyncGroupLogType Success = Parse("Success");
    }
}
