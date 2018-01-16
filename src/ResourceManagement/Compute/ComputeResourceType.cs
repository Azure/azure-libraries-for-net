// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Compute resource types.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuQ29tcHV0ZVJlc291cmNlVHlwZQ==
    public partial class ComputeResourceType : ExpandableStringEnum<Microsoft.Azure.Management.Compute.Fluent.ComputeResourceType>, IBeta
    {
        /// <summary>
        /// Static value availabilitySets for ComputeResourceType.
        /// </summary>
        public static readonly ComputeResourceType AvailabilitySets = Parse("availabilitySets");

        /// <summary>
        /// Static value disks for ComputeResourceType.
        /// </summary>
        public static readonly ComputeResourceType Disks = Parse("disks");

        /// <summary>
        /// Static value snapshots for ComputeResourceType.
        /// </summary>
        public static readonly ComputeResourceType Snapshots = Parse("snapshots");

        /// <summary>
        /// Static value VirtualMachines for ComputeResourceType.
        /// </summary>
        public static readonly ComputeResourceType VirtualMachines = Parse("virtualMachines");
    }
}