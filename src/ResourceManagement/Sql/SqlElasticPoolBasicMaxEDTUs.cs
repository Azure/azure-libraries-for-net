// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The maximum limit of the reserved eDTUs value range for a "Basic" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlElasticPoolBasicMaxEDTUs : int
    {
        /** Maximum 5 eDTUs available per each database. */
        eDTU_5 = 5
    }
}