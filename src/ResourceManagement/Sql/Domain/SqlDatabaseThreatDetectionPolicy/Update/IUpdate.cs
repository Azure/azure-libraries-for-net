// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The SQL database threat detection policy update definition to set the number of days to keep in the Threat Detection audit logs.
    /// </summary>
    public interface IWithRetentionDays 
    {
        /// <summary>
        /// Updates the security alert policy email addresses.
        /// Specifies the number of days to keep in the Threat Detection audit logs.
        /// </summary>
        /// <param name="retentionDays">The number of days to keep in the Threat Detection audit logs.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithRetentionDays(int retentionDays);
    }

    /// <summary>
    /// The SQL database threat detection policy update definition to set the security alert policy alerts to be disabled.
    /// </summary>
    public interface IWithAlertsFilter 
    {
        /// <summary>
        /// Updates the security alert policy alerts to be disabled.
        /// </summary>
        /// <param name="alertsFilter">
        /// The semicolon-separated list of alerts that are disabled, or empty string to disable no alerts.
        /// Possible values: Sql_Injection; Sql_Injection_Vulnerability; Access_Anomaly; Usage_Anomaly.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithAlertsFilter(string alertsFilter);
    }

    /// <summary>
    /// The SQL database threat detection policy update definition to set the state.
    /// </summary>
    public interface IWithSecurityAlertPolicyState 
    {
        /// <summary>
        /// Update the security alert policy state to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithPolicyDisabled();

        /// <summary>
        /// Updates the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithPolicyNew();

        /// <summary>
        /// Updates the security alert policy state to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithPolicyEnabled();

        /// <summary>
        /// Updates the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithDefaultSecurityAlertPolicy();
    }

    /// <summary>
    /// The SQL database threat detection policy update definition to set the storage access key.
    /// </summary>
    public interface IWithStorageAccountAccessKey 
    {
        /// <summary>
        /// Updates the security alert policy storage access key.
        /// </summary>
        /// <param name="storageAccountAccessKey">The storage access key.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithStorageAccountAccessKey(string storageAccountAccessKey);
    }

    /// <summary>
    /// The SQL database threat detection policy update definition to set the security alert policy email addresses.
    /// </summary>
    public interface IWithEmailAddresses 
    {
        /// <summary>
        /// Updates the security alert policy email addresses.
        /// </summary>
        /// <param name="addresses">The semicolon-separated list of e-mail addresses to which the alert is sent to.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithEmailAddresses(string addresses);
    }

    /// <summary>
    /// The template for a SQL database threat detection policy update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IWithSecurityAlertPolicyState,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IWithStorageEndpoint,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IWithStorageAccountAccessKey,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IWithAlertsFilter,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IWithEmailAddresses,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IWithRetentionDays,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IWithEmailToAccountAdmins,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy>
    {
    }

    /// <summary>
    /// The SQL database threat detection policy update definition to set that the alert is sent to the account administrators.
    /// </summary>
    public interface IWithEmailToAccountAdmins 
    {
        /// <summary>
        /// Disables the alert will be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithoutEmailToAccountAdmins();

        /// <summary>
        /// Enables the alert to be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithEmailToAccountAdmins();
    }

    /// <summary>
    /// The SQL database threat detection policy update definition to set the storage endpoint.
    /// </summary>
    public interface IWithStorageEndpoint 
    {
        /// <summary>
        /// Updates the security alert policy storage endpoint.
        /// </summary>
        /// <param name="storageEndpoint">
        /// The blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net); this blob storage
        /// will hold all Threat Detection audit logs.
        /// </param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update.IUpdate WithStorageEndpoint(string storageEndpoint);
    }
}