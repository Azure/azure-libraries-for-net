// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for UnitType.
    /// </summary>
    public class UnitType : ExpandableStringEnum<UnitType>
    {
        public static readonly UnitType Count = Parse("count");
        public static readonly UnitType Bytes = Parse("bytes");
        public static readonly UnitType Seconds = Parse("seconds");
        public static readonly UnitType Percent = Parse("percent");
        public static readonly UnitType CountPerSecond = Parse("countPerSecond");
        public static readonly UnitType BytesPerSecond = Parse("bytesPerSecond");
    }
}
