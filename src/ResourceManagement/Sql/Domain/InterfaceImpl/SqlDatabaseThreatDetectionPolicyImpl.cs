// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.SqlDatabaseThreatDetectionPolicyDefinition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update;

    internal partial class SqlDatabaseThreatDetectionPolicyImpl 
    {
        /// <summary>
        /// Updates the security alert policy storage access key.
        /// </summary>
        /// <param name="storageAccountAccessKey">The storage access key.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithStorageAccountAccessKey.WithStorageAccountAccessKey(string storageAccountAccessKey)
        {
            return this.WithStorageAccountAccessKey(storageAccountAccessKey);
        }

        /// <summary>
        /// Sets the security alert policy storage access key.
        /// </summary>
        /// <param name="storageAccountAccessKey">The storage access key.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageAccountAccessKey.WithStorageAccountAccessKey(string storageAccountAccessKey)
        {
            return this.WithStorageAccountAccessKey(storageAccountAccessKey);
        }

        /// <summary>
        /// Updates the security alert policy state to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithSecurityAlertPolicyState.WithPolicyEnabled()
        {
            return this.WithPolicyEnabled();
        }

        /// <summary>
        /// Updates the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithSecurityAlertPolicyState.WithPolicyNew()
        {
            return this.WithPolicyNew();
        }

        /// <summary>
        /// Update the security alert policy state to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithSecurityAlertPolicyState.WithPolicyDisabled()
        {
            return this.WithPolicyDisabled();
        }

        /// <summary>
        /// Updates the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithSecurityAlertPolicyState.WithDefaultSecurityAlertPolicy()
        {
            return this.WithDefaultSecurityAlertPolicy();
        }

        /// <summary>
        /// Sets the security alert policy state to "Enabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageEndpoint SqlDatabaseThreatDetectionPolicy.Definition.IWithSecurityAlertPolicyState.WithPolicyEnabled()
        {
            return this.WithPolicyEnabled();
        }

        /// <summary>
        /// Sets the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageEndpoint SqlDatabaseThreatDetectionPolicy.Definition.IWithSecurityAlertPolicyState.WithPolicyNew()
        {
            return this.WithPolicyNew();
        }

        /// <summary>
        /// Sets the security alert policy state to "Disabled".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithSecurityAlertPolicyState.WithPolicyDisabled()
        {
            return this.WithPolicyDisabled();
        }

        /// <summary>
        /// Sets the security alert policy state to "New".
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithSecurityAlertPolicyState.WithDefaultSecurityAlertPolicy()
        {
            return this.WithDefaultSecurityAlertPolicy();
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Disables the alert will be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithEmailToAccountAdmins.WithoutEmailToAccountAdmins()
        {
            return this.WithoutEmailToAccountAdmins();
        }

        /// <summary>
        /// Enables the alert to be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithEmailToAccountAdmins.WithEmailToAccountAdmins()
        {
            return this.WithEmailToAccountAdmins();
        }

        /// <summary>
        /// Disables the alert will be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithEmailToAccountAdmins.WithoutEmailToAccountAdmins()
        {
            return this.WithoutEmailToAccountAdmins();
        }

        /// <summary>
        /// Enables the alert to be sent to the account administrators.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithEmailToAccountAdmins.WithEmailToAccountAdmins()
        {
            return this.WithEmailToAccountAdmins();
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlDatabaseThreatDetectionPolicy.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Gets the geo-location where the resource lives.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the number of days to keep in the Threat Detection audit logs.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.RetentionDays
        {
            get
            {
                return this.RetentionDays();
            }
        }

        /// <summary>
        /// Gets the resource kind.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Gets the identifier key of the Threat Detection audit storage account.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.StorageAccountAccessKey
        {
            get
            {
                return this.StorageAccountAccessKey();
            }
        }

        /// <summary>
        /// Gets true if using default server policy.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.IsDefaultSecurityAlertPolicy
        {
            get
            {
                return this.IsDefaultSecurityAlertPolicy();
            }
        }

        /// <summary>
        /// Gets the semicolon-separated list of alerts that are disabled.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.DisabledAlerts
        {
            get
            {
                return this.DisabledAlerts();
            }
        }

        /// <summary>
        /// Gets the semicolon-separated list of e-mail addresses to which the alert is sent.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.EmailAddresses
        {
            get
            {
                return this.EmailAddresses();
            }
        }

        /// <summary>
        /// Gets the blob storage endpoint.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.StorageEndpoint
        {
            get
            {
                return this.StorageEndpoint();
            }
        }

        /// <summary>
        /// Gets true if the alert is sent to the account administrators.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.EmailAccountAdmins
        {
            get
            {
                return this.EmailAccountAdmins();
            }
        }

        /// <summary>
        /// Gets the state of the policy.
        /// </summary>
        Models.SecurityAlertPolicyState Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy.CurrentState
        {
            get
            {
                return this.CurrentState();
            }
        }

        /// <summary>
        /// Updates the security alert policy storage endpoint.
        /// </summary>
        /// <param name="storageEndpoint">
        /// The blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net); this blob storage
        /// will hold all Threat Detection audit logs.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithStorageEndpoint.WithStorageEndpoint(string storageEndpoint)
        {
            return this.WithStorageEndpoint(storageEndpoint);
        }

        /// <summary>
        /// Sets the security alert policy storage endpoint.
        /// </summary>
        /// <param name="storageEndpoint">
        /// The blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net); this blob storage
        /// will hold all Threat Detection audit logs.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageAccountAccessKey SqlDatabaseThreatDetectionPolicy.Definition.IWithStorageEndpoint.WithStorageEndpoint(string storageEndpoint)
        {
            return this.WithStorageEndpoint(storageEndpoint);
        }

        /// <summary>
        /// Updates the security alert policy email addresses.
        /// </summary>
        /// <param name="addresses">The semicolon-separated list of e-mail addresses to which the alert is sent to.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithEmailAddresses.WithEmailAddresses(string addresses)
        {
            return this.WithEmailAddresses(addresses);
        }

        /// <summary>
        /// Sets the security alert policy email addresses.
        /// </summary>
        /// <param name="addresses">The semicolon-separated list of e-mail addresses to which the alert is sent to.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithEmailAddresses.WithEmailAddresses(string addresses)
        {
            return this.WithEmailAddresses(addresses);
        }

        /// <summary>
        /// Updates the security alert policy alerts to be disabled.
        /// </summary>
        /// <param name="alertsFilter">
        /// The semicolon-separated list of alerts that are disabled, or empty string to disable no alerts.
        /// Possible values: Sql_Injection; Sql_Injection_Vulnerability; Access_Anomaly; Usage_Anomaly.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithAlertsFilter.WithAlertsFilter(string alertsFilter)
        {
            return this.WithAlertsFilter(alertsFilter);
        }

        /// <summary>
        /// Sets the security alert policy alerts to be disabled.
        /// </summary>
        /// <param name="alertsFilter">
        /// The semicolon-separated list of alerts that are disabled, or empty string to disable no alerts.
        /// Possible values: Sql_Injection; Sql_Injection_Vulnerability; Access_Anomaly; Usage_Anomaly.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithAlertsFilter.WithAlertsFilter(string alertsFilter)
        {
            return this.WithAlertsFilter(alertsFilter);
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Updates the security alert policy email addresses.
        /// Specifies the number of days to keep in the Threat Detection audit logs.
        /// </summary>
        /// <param name="retentionDays">The number of days to keep in the Threat Detection audit logs.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Update.IUpdate SqlDatabaseThreatDetectionPolicy.Update.IWithRetentionDays.WithRetentionDays(int retentionDays)
        {
            return this.WithRetentionDays(retentionDays);
        }

        /// <summary>
        /// Sets the security alert policy email addresses.
        /// Specifies the number of days to keep in the Threat Detection audit logs.
        /// </summary>
        /// <param name="retentionDays">The number of days to keep in the Threat Detection audit logs.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabaseThreatDetectionPolicy.Definition.IWithCreate SqlDatabaseThreatDetectionPolicy.Definition.IWithRetentionDays.WithRetentionDays(int retentionDays)
        {
            return this.WithRetentionDays(retentionDays);
        }
    }
}