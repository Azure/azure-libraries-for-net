// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The maximum allowed storage capacity for a "Standard" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlDatabaseStandardStorage  : long
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
        Max1Tb = 1L * 1024L * 1024L * 1024L * 1024L
    }
}