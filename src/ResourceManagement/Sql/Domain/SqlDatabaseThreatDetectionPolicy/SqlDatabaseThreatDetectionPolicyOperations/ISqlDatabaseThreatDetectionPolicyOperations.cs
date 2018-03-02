// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.SqlDatabaseThreatDetectionPolicyOperations
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Sql.Fluent;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition;

    /// <summary>
    /// Container interface for SQL database threat detection policy operations.
    /// </summary>
    public interface ISqlDatabaseThreatDetectionPolicyOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IBlank>
    {
        /// <summary>
        /// Gets a SQL database threat detection policy.
        /// </summary>
        /// <return>The SQL database threat detection policy for the current database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy GetThreatDetectionPolicy();

        /// <summary>
        /// Begins a definition for a security alert policy.
        /// </summary>
        /// <param name="policyName">The name of the security alert policy.</param>
        /// <return>The first stage of the SqlDatabaseThreatDetectionPolicy definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IBlank DefineThreatDetectionPolicy(string policyName);
    }
}