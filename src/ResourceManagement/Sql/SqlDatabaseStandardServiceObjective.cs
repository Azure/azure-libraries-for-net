// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The name of the configured Service Level Objective of a "Standard" Azure SQL Database.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5TcWxEYXRhYmFzZVN0YW5kYXJkU2VydmljZU9iamVjdGl2ZQ==
    public class SqlDatabaseStandardServiceObjective  :
        ExpandableStringEnum<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseStandardServiceObjective>
    {
        public static readonly SqlDatabaseStandardServiceObjective S0 = Parse("S0");
        public static readonly SqlDatabaseStandardServiceObjective S1 = Parse("S1");
        public static readonly SqlDatabaseStandardServiceObjective S2 = Parse("S2");
        public static readonly SqlDatabaseStandardServiceObjective S3 = Parse("S3");
        public static readonly SqlDatabaseStandardServiceObjective S4 = Parse("S4");
        public static readonly SqlDatabaseStandardServiceObjective S6 = Parse("S6");
        public static readonly SqlDatabaseStandardServiceObjective S7 = Parse("S7");
        public static readonly SqlDatabaseStandardServiceObjective S9 = Parse("S9");
        public static readonly SqlDatabaseStandardServiceObjective S12 = Parse("S12");
    }
}