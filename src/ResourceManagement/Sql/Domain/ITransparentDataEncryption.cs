// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's TransparentDataEncryption.
    /// </summary>
    public interface ITransparentDataEncryption  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.TransparentDataEncryptionInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId
    {
        /// <return>An Azure SQL Database Transparent Data Encryption Activities.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> ListActivities();

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Updates the state of the transparent data encryption status.
        /// </summary>
        /// <param name="transparentDataEncryptionState">State of the data encryption to set.</param>
        /// <return>The new encryption settings after the update operation.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption UpdateStatus(TransparentDataEncryptionStatus transparentDataEncryptionState);

        /// <return>An Azure SQL Database Transparent Data Encryption Activities.</return>
        Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity>> ListActivitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the state of the transparent data encryption status.
        /// </summary>
        /// <param name="transparentDataEncryptionState">State of the data encryption to set.</param>
        /// <return>A representation of the deferred computation of the new encryption settings after the update operation.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption> UpdateStatusAsync(TransparentDataEncryptionStatus transparentDataEncryptionState, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the status of the Azure SQL Database Transparent Data Encryption.
        /// </summary>
        Models.TransparentDataEncryptionStatus Status { get; }
    }
}