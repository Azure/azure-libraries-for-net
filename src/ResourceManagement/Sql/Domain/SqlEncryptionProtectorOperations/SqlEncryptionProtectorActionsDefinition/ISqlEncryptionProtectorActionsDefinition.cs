// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtectorOperations.SqlEncryptionProtectorActionsDefinition
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// Grouping of the Azure SQL Server Key common actions.
    /// </summary>
    public interface ISqlEncryptionProtectorActionsDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the information about an Encryption Protector resource from Azure SQL server.
        /// </summary>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector Get();

        /// <summary>
        /// Asynchronously gets the information about an Encryption Protector resource from Azure SQL server.
        /// </summary>
        /// <return>A representation of the deferred computation of this call returning the found resource.</return>
        Task<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists Azure SQL the Encryption Protector resources.
        /// </summary>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector> List();

        /// <summary>
        /// Asynchronously lists Azure SQL the Encryption Protector resources.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<System.Collections.Generic.IReadOnlyList<ISqlEncryptionProtector>> ListAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}