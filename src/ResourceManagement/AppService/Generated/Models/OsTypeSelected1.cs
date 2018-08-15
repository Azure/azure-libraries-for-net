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
    /// Defines values for OsTypeSelected1.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(Management.ResourceManager.Fluent.Core.ExpandableStringEnumConverter<OsTypeSelected1>))]
    public class OsTypeSelected1 : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<OsTypeSelected1>
    {
        public static readonly OsTypeSelected1 Windows = Parse("Windows");
        public static readonly OsTypeSelected1 Linux = Parse("Linux");
    }
}
