// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.AppService.Fluent.Models
{
    using Management.ResourceManager;
    using Management.ResourceManager.Fluent;
    using Management.ResourceManager.Fluent.Core;

    using Newtonsoft.Json;
    /// <summary>
    /// Defines values for SkuName.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(Management.ResourceManager.Fluent.Core.ExpandableStringEnumConverter<SkuName>))]
    public class SkuName : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<SkuName>
    {
        public static readonly SkuName Free = Parse("Free");
        public static readonly SkuName Shared = Parse("Shared");
        public static readonly SkuName Basic = Parse("Basic");
        public static readonly SkuName Standard = Parse("Standard");
        public static readonly SkuName Premium = Parse("Premium");
        public static readonly SkuName Dynamic = Parse("Dynamic");
        public static readonly SkuName Isolated = Parse("Isolated");
        public static readonly SkuName PremiumV2 = Parse("PremiumV2");
    }
}
