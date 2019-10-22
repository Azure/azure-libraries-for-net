// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition;
    using System.Collections.Generic;

    internal partial class SqlEncryptionProtectorOperationsImpl 
    {
        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.GetBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(resourceGroupName, sqlServerName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.GetBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken)
        {
            return await this.GetBySqlServerAsync(sqlServer, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>> Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.ListBySqlServerAsync(string resourceGroupName, string sqlServerName, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(resourceGroupName, sqlServerName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>> Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.ListBySqlServerAsync(ISqlServer sqlServer, CancellationToken cancellationToken)
        {
            return await this.ListBySqlServerAsync(sqlServer, cancellationToken);
        }

        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="resourceGroupName">The name of resource group.</param>
        /// <param name="sqlServerName">The name of SQL server parent resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.GetBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.GetBySqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server, identifying it by its resource group and parent.
        /// </summary>
        /// <param name="sqlServer">The SQL server parent resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.GetBySqlServer(ISqlServer sqlServer)
        {
            return this.GetBySqlServer(sqlServer);
        }

        /// <summary>
        /// Lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="sqlServerName">The name of parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.ListBySqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Lists Azure SQL the Encryption Protector resources of the specified Azure SQL server in the specified resource group.
        /// </summary>
        /// <param name="sqlServer">The parent Azure SQL server.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.ListBySqlServer(ISqlServer sqlServer)
        {
            return this.ListBySqlServer(sqlServer);
        }

        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server using the resource ID.
        /// </summary>
        /// <param name="id">The ID of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtectorOperations.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server.
        /// </summary>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition.ISqlEncryptionProtectorActionsDefinition.Get()
        {
            return this.Get();
        }

        /// <summary>
        /// Lists Azure SQL the Encryption Protector resources.
        /// </summary>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition.ISqlEncryptionProtectorActionsDefinition.List()
        {
            return this.List();
        }

        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server.
        /// </summary>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition.ISqlEncryptionProtectorActionsDefinition.GetAsync(CancellationToken cancellationToken)
        {
            return await this.GetAsync(cancellationToken);
        }

        /// <summary>
        /// Asynchronously lists Azure SQL the Encryption Protector resources.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task<System.Collections.Generic.IReadOnlyList<ISqlEncryptionProtector>> SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition.ISqlEncryptionProtectorActionsDefinition.ListAsync(CancellationToken cancellationToken)
        {
            return await this.ListAsync(cancellationToken);
        }
    }
}