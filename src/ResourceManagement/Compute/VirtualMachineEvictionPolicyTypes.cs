// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for VirtualMachineEvictionPolicyTypes.
    /// </summary>
    public class VirtualMachineEvictionPolicyTypes : ExpandableStringEnum<VirtualMachineEvictionPolicyTypes>, IBeta
    {
        public static readonly VirtualMachineEvictionPolicyTypes Deallocate = Parse("Deallocate");

        public static readonly VirtualMachineEvictionPolicyTypes Delete = Parse("Delete");
    }
}
