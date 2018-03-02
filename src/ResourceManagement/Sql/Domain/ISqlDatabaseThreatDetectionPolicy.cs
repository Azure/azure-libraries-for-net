// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseThreatDetectionPolicy.Update;

    /// <summary>
    /// A representation of the Azure SQL Database threat detection policy.
    /// </summary>
    public interface ISqlDatabaseThreatDetectionPolicy  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy,Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DatabaseSecurityAlertPolicyInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseThreatDetectionPolicy>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlDatabaseThreatDetectionPolicy.Update.IUpdate>
    {
        /// <summary>
        /// Gets the semicolon-separated list of alerts that are disabled.
        /// </summary>
        string DisabledAlerts { get; }

        /// <summary>
        /// Gets the blob storage endpoint.
        /// </summary>
        string StorageEndpoint { get; }

        /// <summary>
        /// Gets true if using default server policy.
        /// </summary>
        bool IsDefaultSecurityAlertPolicy { get; }

        /// <summary>
        /// Gets the semicolon-separated list of e-mail addresses to which the alert is sent.
        /// </summary>
        string EmailAddresses { get; }

        /// <summary>
        /// Gets true if the alert is sent to the account administrators.
        /// </summary>
        bool EmailAccountAdmins { get; }

        /// <summary>
        /// Gets the number of days to keep in the Threat Detection audit logs.
        /// </summary>
        int RetentionDays { get; }

        /// <summary>
        /// Gets the resource kind.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets the identifier key of the Threat Detection audit storage account.
        /// </summary>
        string StorageAccountAccessKey { get; }

        /// <summary>
        /// Gets the geo-location where the resource lives.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Gets the state of the policy.
        /// </summary>
        Models.SecurityAlertPolicyState CurrentState { get; }
    }
}