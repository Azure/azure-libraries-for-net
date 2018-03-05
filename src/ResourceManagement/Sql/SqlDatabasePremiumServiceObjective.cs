// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The name of the configured Service Level Objective of a "Premium" Azure SQL Database.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5TcWxEYXRhYmFzZVByZW1pdW1TZXJ2aWNlT2JqZWN0aXZl
    public class SqlDatabasePremiumServiceObjective  :
        ExpandableStringEnum<Microsoft.Azure.Management.Sql.Fluent.SqlDatabasePremiumServiceObjective>
    {
        public static readonly SqlDatabasePremiumServiceObjective P1 = Parse("P1");
        public static readonly SqlDatabasePremiumServiceObjective P2 = Parse("P2");
        public static readonly SqlDatabasePremiumServiceObjective P3 = Parse("P3");
        public static readonly SqlDatabasePremiumServiceObjective P4 = Parse("P4");
        public static readonly SqlDatabasePremiumServiceObjective P6 = Parse("P6");
        public static readonly SqlDatabasePremiumServiceObjective P11 = Parse("P11");
        public static readonly SqlDatabasePremiumServiceObjective P15 = Parse("P15");
    }
}