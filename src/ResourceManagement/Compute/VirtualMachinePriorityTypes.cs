// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for VirtualMachinePriorityTypes.
    /// </summary>
    public class VirtualMachinePriorityTypes : ExpandableStringEnum<VirtualMachinePriorityTypes>, IBeta
    {
        public static readonly VirtualMachinePriorityTypes Regular = Parse("Regular");

        public static readonly VirtualMachinePriorityTypes Low = Parse("Low");
    }
}
