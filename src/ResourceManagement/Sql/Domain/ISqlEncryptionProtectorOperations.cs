// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// A representation of the Azure SQL Encryption Protector operations.
    /// </summary>
    public interface ISqlEncryptionProtectorOperations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> ListBySqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> ListBySqlServer(ISqlServer sqlServer);

        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector GetBySqlServer(string resourceGroupName, string sqlServerName);

        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector GetBySqlServer(ISqlServer sqlServer);

        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector GetById(string id);

        /// <summary>
        /// Asynchronously lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>> ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>> ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken = default(CancellationToken));
    }
}