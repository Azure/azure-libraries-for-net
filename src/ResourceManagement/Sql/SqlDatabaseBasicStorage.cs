// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The maximum allowed storage capacity for a "Basic" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlDatabaseBasicStorage : long
    {
        /** 100 MB storage capacity available for the database. */
        MAX_100_MB = 100L * 1024L * 1024L,
        /** 500 MB storage capacity available for the database. */
        MAX_500_MB = 500L * 1024L * 1024L,
        /** 1 GB storage capacity available for the database. */
        MAX_1_GB = 1L * 1024L * 1024L * 1024L,
        /** 2 GB storage capacity available for the database. */
        MAX_2_GB = 2L * 1024L * 1024L * 1024L
    }
}