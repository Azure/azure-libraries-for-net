// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The maximum allowed storage capacity for a "Premium" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlElasticPoolPremiumSorage  : long
    {
        MAX_50_GB = 50L * 1024L * 1024L * 1024L,
        /** 100 GB storage capacity available for the databases. */
        MAX_100_GB = 100L * 1024L * 1024L * 1024L,
        /** 150 GB storage capacity available for the databases. */
        MAX_150_GB = 150L * 1024L * 1024L * 1024L,
        /** 200 GB storage capacity available for the databases. */
        MAX_200_GB = 200L * 1024L * 1024L * 1024L,
        /** 250 GB storage capacity available for the databases. */
        MAX_250_GB = 250L * 1024L * 1024L * 1024L,
        /** 300 GB storage capacity available for the databases. */
        MAX_300_GB = 300L * 1024L * 1024L * 1024L,
        /** 400 GB storage capacity available for the databases. */
        MAX_400_GB = 400L * 1024L * 1024L * 1024L,
        /** 500 GB storage capacity available for the databases. */
        MAX_500_GB = 500L * 1024L * 1024L * 1024L,
        /** 750 GB storage capacity available for the databases. */
        MAX_750_GB = 750L * 1024L * 1024L * 1024L,
        /** 800 GB storage capacity available for the databases. */
        MAX_800_GB = 800L * 1024L * 1024L * 1024L,
        /** 1 TB storage capacity available for the databases. */
        MAX_1_TB = 1L * 1024L * 1024L * 1024L * 1024L,
        /** 1200 GB storage capacity available for the databases. */
        MAX_1200_GB = 1200L * 1024L * 1024L * 1024L,
        /** 1280 GB storage capacity available for the databases. */
        MAX_1280_GB = 1280L * 1024L * 1024L * 1024L,
        /** 1536 GB storage capacity available for the databases. */
        MAX_1536_GB = 1536L * 1024L * 1024L * 1024L,
        /** 1600 GB storage capacity available for the databases. */
        MAX_1600_GB = 1600L * 1024L * 1024L * 1024L,
        /** 1792 GB storage capacity available for the databases. */
        MAX_1792_GB = 1792L * 1024L * 1024L * 1024L,
        /** 2000 GB storage capacity available for the databases. */
        MAX_2000_GB = 2000L * 1024L * 1024L * 1024L,
        /** 2 TB storage capacity available for the databases. */
        MAX_2_TB = 2L * 1024L * 1024L * 1024L * 1024L,
        /** 2304 GB storage capacity available for the databases. */
        MAX_2304_GB = 2304L * 1024L * 1024L * 1024L,
        /** 2560 GB storage capacity available for the database. */
        MAX_2560_GB = 2560L * 1024L * 1024L * 1024L,
        /** 2816 GB storage capacity available for the database. */
        MAX_2816_GB = 2816L * 1024L * 1024L * 1024L,
        /** 3000 GB storage capacity available for the databases. */
        MAX_3000_GB = 3000L * 1024L * 1024L * 1024L,
        /** 3 TB storage capacity available for the databases. */
        MAX_3_TB = 3L * 1024L * 1024L * 1024L * 1024L,
        /** 3328 GB storage capacity available for the database. */
        MAX_3328_GB = 3328L * 1024L * 1024L * 1024L,
        /** 3584 GB storage capacity available for the database. */
        MAX_3584_GB = 3584L * 1024L * 1024L * 1024L,
        /** 3840 GB storage capacity available for the database. */
        MAX_3840_GB = 3840L * 1024L * 1024L * 1024L,
        /** 4 TB storage capacity available for the database. */
        MAX_4_TB = 4L * 1024L * 1024L * 1024L * 1024L
    }
}