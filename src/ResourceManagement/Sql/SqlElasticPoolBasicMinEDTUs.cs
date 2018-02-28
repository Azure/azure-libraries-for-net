// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The minimum limit of the reserved eDTUs value range for a "Basic" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlElasticPoolBasicMinEDTUs : int
    {
        /** 0 reserved minimum eDTUs available for each database in the pool. */
        eDTU_0 = 0,
        /** 5 reserved minimum eDTUs available for each database in the pool. */
        eDTU_5 = 5
    }
}