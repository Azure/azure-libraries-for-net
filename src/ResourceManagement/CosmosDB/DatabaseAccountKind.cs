// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for container instance OS type.
    /// </summary>
    public class DatabaseAccountKind : ExpandableStringEnum<DatabaseAccountKind>
    {
        public static readonly DatabaseAccountKind GlobalDocumentDB = Parse("GlobalDocumentDB");
        public static readonly DatabaseAccountKind MongoDB = Parse("MongoDB");
        public static readonly DatabaseAccountKind Others = Parse("Parse");
    }
}
