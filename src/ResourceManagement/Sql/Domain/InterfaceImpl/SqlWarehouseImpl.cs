// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Rest;

    internal partial class SqlWarehouseImpl 
    {
        /// <summary>
        /// Resume an Azure SQL Data Warehouse database asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse.ResumeDataWarehouseAsync(CancellationToken cancellationToken)
        {
 
            await this.ResumeDataWarehouseAsync(cancellationToken);
        }

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse.PauseDataWarehouse()
        {
 
            this.PauseDataWarehouse();
        }

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse.PauseDataWarehouseAsync(CancellationToken cancellationToken)
        {
 
            await this.PauseDataWarehouseAsync(cancellationToken);
        }

        /// <summary>
        /// Resume an Azure SQL Data Warehouse database.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse.ResumeDataWarehouse()
        {
 
            this.ResumeDataWarehouse();
        }
    }
}