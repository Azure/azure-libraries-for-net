// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for PrimaryAggregationType.
    /// </summary>
    public class PrimaryAggregationType : ExpandableStringEnum<PrimaryAggregationType>
    {
        public static readonly PrimaryAggregationType None = Parse("None");
        public static readonly PrimaryAggregationType Average = Parse("Average");
        public static readonly PrimaryAggregationType Count = Parse("Count");
        public static readonly PrimaryAggregationType Minimum = Parse("Minimum");
        public static readonly PrimaryAggregationType Maximum = Parse("Maximum");
        public static readonly PrimaryAggregationType Total = Parse("Total");
    }
}
