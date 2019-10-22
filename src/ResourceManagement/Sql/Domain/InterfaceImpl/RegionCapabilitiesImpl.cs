// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    internal partial class RegionCapabilitiesImpl 
    {
        /// <summary>
        /// Gets the Azure SQL Database's status for the location.
        /// </summary>
        Models.CapabilityStatus Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the list of supported server versions.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.ServerVersionCapability> Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities.SupportedCapabilitiesByServerVersion
        {
            get
            {
                return this.SupportedCapabilitiesByServerVersion();
            }
        }

        /// <summary>
        /// Gets the location name.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.IRegionCapabilities.Region
        {
            get
            {
                return this.Region();
            }
        }
    }
}