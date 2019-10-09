// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    public class DynamicThresholdOperator : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<DynamicThresholdOperator>
    {
        public static readonly DynamicThresholdOperator GreaterThan = Parse("GreaterThan");
        public static readonly DynamicThresholdOperator LessThan = Parse("LessThan");
        public static readonly DynamicThresholdOperator GreaterOrLessThan = Parse("GreaterOrLessThan");
    }
}
