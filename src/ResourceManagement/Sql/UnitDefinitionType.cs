// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for UnitDefinitionType.
    /// </summary>
    public class UnitDefinitionType : ExpandableStringEnum<UnitDefinitionType>
    {
        public static readonly UnitDefinitionType Count = Parse("Count");
        public static readonly UnitDefinitionType Bytes = Parse("Bytes");
        public static readonly UnitDefinitionType Seconds = Parse("Seconds");
        public static readonly UnitDefinitionType Percent = Parse("Percent");
        public static readonly UnitDefinitionType CountPerSecond = Parse("CountPerSecond");
        public static readonly UnitDefinitionType BytesPerSecond = Parse("BytesPerSecond");
    }
}
