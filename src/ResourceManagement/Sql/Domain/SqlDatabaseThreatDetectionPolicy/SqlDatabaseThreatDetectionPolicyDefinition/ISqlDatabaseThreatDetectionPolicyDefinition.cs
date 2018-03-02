// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.SqlDatabaseThreatDetectionPolicyDefinition
{
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition;

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface ISqlDatabaseThreatDetectionPolicyDefinition  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IBlank,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithSecurityAlertPolicyState,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageEndpoint,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageAccountAccessKey,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithAlertsFilter,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithEmailAddresses,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithRetentionDays,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithEmailToAccountAdmins,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate
    {
    }
}