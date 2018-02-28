// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The minimum limit of the reserved eDTUs value range for a "Premium" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlElasticPoolStandardMinEDTUs : int
    {
        /** 0 reserved minimum eDTUs available for each database in the pool. */
        eDTU_0 = 0,

        /** 20 reserved minimum eDTUs available for each database in the pool. */
        eDTU_20 = 20,

        /** 50 reserved minimum eDTUs available for each database in the pool. */
        eDTU_50 = 50,

        /** 100 reserved minimum eDTUs available for each database in the pool. */
        eDTU_100 = 100,

        /** 200 reserved minimum eDTUs available for each database in the pool. */
        eDTU_200 = 200,

        /** 300 reserved minimum eDTUs available for each database in the pool. */
        eDTU_300 = 300,

        /** 400 reserved minimum eDTUs available for each database in the pool. */
        eDTU_400 = 400,

        /** 800 reserved minimum eDTUs available for each database in the pool. */
        eDTU_800 = 800,

        /** 1200 reserved minimum eDTUs available for each database in the pool. */
        eDTU_1200 = 1200,

        /** 1600 reserved minimum eDTUs available for each database in the pool. */
        eDTU_1600 = 1600,

        /** 2000 reserved minimum eDTUs available for each database in the pool. */
        eDTU_2000 = 2000,

        /** 2500 reserved minimum eDTUs available for each database in the pool. */
        eDTU_2500 = 2500,

        /** 3000 reserved minimum eDTUs available for each database in the pool. */
        eDTU_3000 = 3000
    }
}