// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for ReadWriteEndpointFailoverPolicy.
    /// </summary>
    public class ReadWriteEndpointFailoverPolicy : ExpandableStringEnum<ReadWriteEndpointFailoverPolicy>
    {
        public static readonly ReadWriteEndpointFailoverPolicy Manual = Parse("Manual");
        public static readonly ReadWriteEndpointFailoverPolicy Automatic = Parse("Automatic");
    }
}
