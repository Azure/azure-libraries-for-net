// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The extent of deviation required to trigger an alert. This will affect how tight the threshold is to the metric series pattern.
    /// </summary>
    [JsonConverter(typeof(Management.ResourceManager.Fluent.Core.ExpandableStringEnumConverter<DynamicThresholdSensitivity>))]
    public class DynamicThresholdSensitivity : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<DynamicThresholdSensitivity>
    {
        public static readonly DynamicThresholdSensitivity Low = Parse("Low");
        public static readonly DynamicThresholdSensitivity Medium = Parse("Medium");
        public static readonly DynamicThresholdSensitivity High = Parse("High");
    }
}
