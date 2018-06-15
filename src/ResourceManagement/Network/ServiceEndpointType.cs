// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for ServiceEndpointType.
    /// </summary>
    public class ServiceEndpointType : ExpandableStringEnum<ServiceEndpointType>, IBeta
    {
        public static readonly ServiceEndpointType MicrosoftStorage = Parse("Microsoft.Storage");
        public static readonly ServiceEndpointType MicrosoftSql = Parse("Microsoft.Sql");
        public static readonly ServiceEndpointType MicrosoftAzureCosmosDB = Parse("Microsoft.AzureCosmosDB");
    }
}
