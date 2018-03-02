// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The maximum allowed storage capacity for a "Standard" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlElasticPoolStandardStorage : long
    {
        MAX_50Gb = 50L * 1024L * 1024L * 1024L,
        /** 100 GB storage capacity available for the databases. */
        MAX_100Gb = 100L * 1024L * 1024L * 1024L,
        /** 150 GB storage capacity available for the databases. */
        MAX_150Gb = 150L * 1024L * 1024L * 1024L,
        /** 200 GB storage capacity available for the databases. */
        MAX_200Gb = 200L * 1024L * 1024L * 1024L,
        /** 250 GB storage capacity available for the databases. */
        MAX_250Gb = 250L * 1024L * 1024L * 1024L,
        /** 300 GB storage capacity available for the databases. */
        MAX_300Gb = 300L * 1024L * 1024L * 1024L,
        /** 400 GB storage capacity available for the databases. */
        MAX_400Gb = 400L * 1024L * 1024L * 1024L,
        /** 500 GB storage capacity available for the databases. */
        MAX_500Gb = 500L * 1024L * 1024L * 1024L,
        /** 750 GB storage capacity available for the databases. */
        MAX_750Gb = 750L * 1024L * 1024L * 1024L,
        /** 800 GB storage capacity available for the databases. */
        MAX_800Gb = 800L * 1024L * 1024L * 1024L,
        /** 1 TB storage capacity available for the databases. */
        MAX_1Tb = 1L * 1024L * 1024L * 1024L * 1024L,
        /** 1200 GB storage capacity available for the databases. */
        MAX_1200Gb = 1200L * 1024L * 1024L * 1024L,
        /** 1280 GB storage capacity available for the databases. */
        MAX_1280Gb = 1280L * 1024L * 1024L * 1024L,
        /** 1536 GB storage capacity available for the databases. */
        MAX_1536Gb = 1536L * 1024L * 1024L * 1024L,
        /** 1600 GB storage capacity available for the databases. */
        MAX_1600Gb = 1600L * 1024L * 1024L * 1024L,
        /** 1792 GB storage capacity available for the databases. */
        MAX_1792Gb = 1792L * 1024L * 1024L * 1024L,
        /** 2000 GB storage capacity available for the databases. */
        MAX_2000Gb = 2000L * 1024L * 1024L * 1024L,
        /** 2 TB storage capacity available for the databases. */
        MAX_2Tb = 2L * 1024L * 1024L * 1024L * 1024L,
        /** 2304 GB storage capacity available for the databases. */
        MAX_2304Gb = 2304L * 1024L * 1024L * 1024L,
        /** 2560 GB storage capacity available for the database. */
        MAX_2560Gb = 2560L * 1024L * 1024L * 1024L,
        /** 2816 GB storage capacity available for the database. */
        MAX_2816Gb = 2816L * 1024L * 1024L * 1024L,
        /** 3000 GB storage capacity available for the databases. */
        MAX_3000Gb = 3000L * 1024L * 1024L * 1024L,
        /** 3 TB storage capacity available for the databases. */
        MAX_3Tb = 3L * 1024L * 1024L * 1024L * 1024L,
        /** 3328 GB storage capacity available for the database. */
        MAX_3328Gb = 3328L * 1024L * 1024L * 1024L,
        /** 3584 GB storage capacity available for the database. */
        MAX_3584Gb = 3584L * 1024L * 1024L * 1024L,
        /** 3840 GB storage capacity available for the database. */
        MAX_3840Gb = 3840L * 1024L * 1024L * 1024L,
        /** 4 TB storage capacity available for the database. */
        MAX_4Tb = 4L * 1024L * 1024L * 1024L * 1024L
    }
}