// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL ElasticPool's Activity.
    /// </summary>
    public interface IElasticPoolActivityBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the requested DTU guarantee.
        /// </summary>
        int RequestedDtuGuarantee { get; }

        /// <summary>
        /// Gets he requested per database DTU guarantee.
        /// </summary>
        int RequestedDatabaseDtuGuarantee { get; }

        /// <summary>
        /// Gets the requested storage limit in MB.
        /// </summary>
        long RequestedStorageLimitInMB { get; }

        /// <summary>
        /// Gets the requested per database DTU cap.
        /// </summary>
        int RequestedDatabaseDtuCap { get; }

        /// <summary>
        /// Gets the geo-location where the resource lives.
        /// </summary>
        string Location { get; }
    }
}