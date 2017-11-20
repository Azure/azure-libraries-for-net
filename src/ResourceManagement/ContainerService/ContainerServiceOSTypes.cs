// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ContainerService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    /// <summary>
    /// Defines values for Container Service OS types.
    /// </summary>
    public class ContainerServiceOSTypes :
        ExpandableStringEnum<Microsoft.Azure.Management.ContainerService.Fluent.ContainerServiceOSTypes>
    {
        public static readonly ContainerServiceOSTypes Linux = Parse(Models.OSType.Linux);
        public static readonly ContainerServiceOSTypes Windows = Parse(Models.OSType.Windows);
    }
}