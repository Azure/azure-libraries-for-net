// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for ServerKeyType.
    /// </summary>
    public class ServerKeyType : ExpandableStringEnum<ServerKeyType>
    {
        public static readonly ServerKeyType ServiceManaged = Parse("ServiceManaged");
        public static readonly ServerKeyType AzureKeyVault = Parse("AzureKeyVault");
    }
}
