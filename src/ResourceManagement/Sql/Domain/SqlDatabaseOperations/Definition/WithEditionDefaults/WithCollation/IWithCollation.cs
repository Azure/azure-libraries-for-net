// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.WithEditionDefaults.WithCollation
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition;

    /// <summary>
    /// The SQL Database definition to set the collation for database.
    /// </summary>
    public interface IWithCollation 
    {
        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseOperations.Definition.IWithEditionDefaults WithCollation(string collation);
    }
}