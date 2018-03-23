// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for ReadOnlyEndpointFailoverPolicy.
    /// </summary>
    public class ReadOnlyEndpointFailoverPolicy : ExpandableStringEnum<ReadOnlyEndpointFailoverPolicy>
    {
        public static readonly ReadOnlyEndpointFailoverPolicy Disabled = Parse("Disabled");
        public static readonly ReadOnlyEndpointFailoverPolicy Enabled = Parse("Enabled");
    }
}
