// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    public class DynamicThresholdSensitivity : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<DynamicThresholdSensitivity>
    {
        public static readonly DynamicThresholdSensitivity Low = Parse("Low");
        public static readonly DynamicThresholdSensitivity Medium = Parse("Medium");
        public static readonly DynamicThresholdSensitivity High = Parse("High");
    }
}
