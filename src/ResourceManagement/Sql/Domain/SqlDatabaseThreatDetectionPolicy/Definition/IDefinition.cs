// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The SQL database threat detection policy definition to set the number of days to keep in the Threat Detection audit logs.
    /// </summary>
    public interface IWithRetentionDays 
    {
        /// <summary>
        /// Sets the security alert policy email addresses.
        /// Specifies the number of days to keep in the Threat Detection audit logs.
        /// </summary>
        /// <param name="retentionDays">The number of days to keep in the Threat Detection audit logs.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithRetentionDays(int retentionDays);
    }

    /// <summary>
    /// The SQL database threat detection policy definition to set the storage access key.
    /// </summary>
    public interface IWithStorageAccountAccessKey 
    {
        /// <summary>
        /// Sets the security alert policy storage access key.
        /// </summary>
        /// <param name="storageAccountAccessKey">The storage access key.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithStorageAccountAccessKey(string storageAccountAccessKey);
    }

    /// <summary>
    /// The SQL database threat detection policy definition to set the storage endpoint.
    /// </summary>
    public interface IWithStorageEndpoint 
    {
        /// <summary>
        /// Sets the security alert policy storage endpoint.
        /// </summary>
        /// <param name="storageEndpoint">
        /// The blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net); this blob storage
        /// will hold all Threat Detection audit logs.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageAccountAccessKey WithStorageEndpoint(string storageEndpoint);
    }

    /// <summary>
    /// The first stage of the SQL database threat detection policy definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithSecurityAlertPolicyState
    {
    }

    /// <summary>
    /// The SQL database threat detection policy definition to set that the alert is sent to the account administrators.
    /// </summary>
    public interface IWithEmailToAccountAdmins 
    {
        /// <summary>
        /// Disables the alert will be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithoutEmailToAccountAdmins();

        /// <summary>
        /// Enables the alert to be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithEmailToAccountAdmins();
    }

    /// <summary>
    /// The final stage of the SQL database threat detection policy definition.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageEndpoint,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageAccountAccessKey,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithAlertsFilter,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithEmailAddresses,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithRetentionDays,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithEmailToAccountAdmins,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy>
    {
    }

    /// <summary>
    /// The SQL database threat detection policy definition to set the state.
    /// </summary>
    public interface IWithSecurityAlertPolicyState 
    {
        /// <summary>
        /// Sets the security alert policy state to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithPolicyDisabled();

        /// <summary>
        /// Sets the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageEndpoint WithPolicyNew();

        /// <summary>
        /// Sets the security alert policy state to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageEndpoint WithPolicyEnabled();

        /// <summary>
        /// Sets the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithDefaultSecurityAlertPolicy();
    }

    /// <summary>
    /// The SQL database threat detection policy definition to set the security alert policy email addresses.
    /// </summary>
    public interface IWithEmailAddresses 
    {
        /// <summary>
        /// Sets the security alert policy email addresses.
        /// </summary>
        /// <param name="addresses">The semicolon-separated list of e-mail addresses to which the alert is sent to.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithEmailAddresses(string addresses);
    }

    /// <summary>
    /// The SQL database threat detection policy definition to set the security alert policy alerts to be disabled.
    /// </summary>
    public interface IWithAlertsFilter 
    {
        /// <summary>
        /// Sets the security alert policy alerts to be disabled.
        /// </summary>
        /// <param name="alertsFilter">
        /// The semicolon-separated list of alerts that are disabled, or empty string to disable no alerts.
        /// Possible values: Sql_Injection; Sql_Injection_Vulnerability; Access_Anomaly; Usage_Anomaly.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate WithAlertsFilter(string alertsFilter);
    }
}