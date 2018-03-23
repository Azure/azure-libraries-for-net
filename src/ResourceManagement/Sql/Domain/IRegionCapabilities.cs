// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL server capabilities for a given region.
    /// </summary>
    public interface IRegionCapabilities  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.LocationCapabilitiesInner>
    {
        /// <summary>
        /// Gets the location name.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Gets the Azure SQL Database's status for the location.
        /// </summary>
        Models.CapabilityStatus Status { get; }

        /// <summary>
        /// Gets the list of supported server versions.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.ServerVersionCapability> SupportedCapabilitiesByServerVersion { get; }
    }
}