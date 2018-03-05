// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The reserved eDTUs value range for a "Premium" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlElasticPoolPremiumEDTUs : int
    {
        /** 125 eDTUs available to the pool. */
        eDTU_125 = 125,

        /** 250 eDTUs available to the pool. */
        eDTU_250 = 250,

        /** 500 eDTUs available to the pool. */
        eDTU_500 = 500,

        /** 1000 eDTUs available to the pool. */
        eDTU_1000 = 1000,

        /** 1500 eDTUs available to the pool. */
        eDTU_1500 = 1500,

        /** 2000 eDTUs available to the pool. */
        eDTU_2000 = 2000,

        /** 2500 eDTUs available to the pool. */
        eDTU_2500 = 2500,

        /** 3000 eDTUs available to the pool. */
        eDTU_3000 = 3000,

        /** 3500 eDTUs available to the pool. */
        eDTU_3500 = 3500,

        /** 4000 eDTUs available to the pool. */
        eDTU_4000 = 4000
    }
}