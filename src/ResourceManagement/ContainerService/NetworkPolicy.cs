// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.Models
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for NetworkPolicy.
    /// </summary>
    public class NetworkPolicy :
        ExpandableStringEnum<Microsoft.Azure.Management.ContainerService.Fluent.Models.NetworkPolicy>
    {
        public static readonly NetworkPolicy Calico = Parse("Calico");
    }
}
