// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The maximum allowed storage capacity for a "Premium" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlDatabasePremiumStorage  : long
    {
        /** 100 MB storage capacity available for the database. */
        Max100Mb = 100L * 1024L * 1024L,
        /** 500 MB storage capacity available for the database. */
        Max500Mb = 500L * 1024L * 1024L,
        /** 1 GB storage capacity available for the database. */
        Max1Gb = 1L * 1024L * 1024L * 1024L,
        /** 2 GB storage capacity available for the database. */
        Max2Gb = 2L * 1024L * 1024L * 1024L,
        /** 5 GB storage capacity available for the database. */
        Max5Gb = 5L * 1024L * 1024L * 1024L,
        /** 10 GB storage capacity available for the database. */
        Max10Gb = 10L * 1024L * 1024L * 1024L,
        /** 20 GB storage capacity available for the database. */
        Max20Gb = 20L * 1024L * 1024L * 1024L,
        /** 30 GB storage capacity available for the database. */
        Max30Gb = 30L * 1024L * 1024L * 1024L,
        /** 40 GB storage capacity available for the database. */
        Max40Gb = 40L * 1024L * 1024L * 1024L,
        /** 50 GB storage capacity available for the database. */
        Max50Gb = 50L * 1024L * 1024L * 1024L,
        /** 100 GB storage capacity available for the database. */
        Max100Gb = 100L * 1024L * 1024L * 1024L,
        /** 150 GB storage capacity available for the database. */
        Max150Gb = 150L * 1024L * 1024L * 1024L,
        /** 200 GB storage capacity available for the database. */
        Max200Gb = 200L * 1024L * 1024L * 1024L,
        /** 250 GB storage capacity available for the database. */
        Max250Gb = 250L * 1024L * 1024L * 1024L,
        /** 300 GB storage capacity available for the database. */
        Max300Gb = 300L * 1024L * 1024L * 1024L,
        /** 400 GB storage capacity available for the database. */
        Max400Gb = 400L * 1024L * 1024L * 1024L,
        /** 500 GB storage capacity available for the database. */
        Max500Gb = 500L * 1024L * 1024L * 1024L,
        /** 750 GB storage capacity available for the database. */
        Max750Gb = 750L * 1024L * 1024L * 1024L,
        /** 1 TB storage capacity available for the database. */
        Max1Tb = 1L * 1024L * 1024L * 1024L * 1024L,
        /** 1280 GB storage capacity available for the database. */
        Max1280Gb = 1280L * 1024L * 1024L * 1024L,
        /** 1536 GB storage capacity available for the database. */
        Max1536Gb = 1536L * 1024L * 1024L * 1024L,
        /** 1792 GB storage capacity available for the database. */
        Max1792Gb = 1792L * 1024L * 1024L * 1024L,
        /** 2 TB storage capacity available for the database. */
        Max2Tb = 2L * 1024L * 1024L * 1024L * 1024L,
        /** 2304 GB storage capacity available for the database. */
        Max2304Gb = 2304L * 1024L * 1024L * 1024L,
        /** 2560 GB storage capacity available for the database. */
        Max2560Gb = 2560L * 1024L * 1024L * 1024L,
        /** 2816 GB storage capacity available for the database. */
        Max2816Gb = 2816L * 1024L * 1024L * 1024L,
        /** 3 TB storage capacity available for the database. */
        Max3Tb = 3L * 1024L * 1024L * 1024L * 1024L,
        /** 3328 GB storage capacity available for the database. */
        Max3328Gb = 3328L * 1024L * 1024L * 1024L,
        /** 3584 GB storage capacity available for the database. */
        Max3584Gb = 3584L * 1024L * 1024L * 1024L,
        /** 3840 GB storage capacity available for the database. */
        Max3840Gb = 3840L * 1024L * 1024L * 1024L,
        /** 4 TB storage capacity available for the database. */
        Max4Tb = 4L * 1024L * 1024L * 1024L * 1024L
    }
}