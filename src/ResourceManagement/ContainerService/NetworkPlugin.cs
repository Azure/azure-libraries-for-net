// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.Models
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for NetworkPlugin.
    /// </summary>
    public class NetworkPlugin :
        ExpandableStringEnum<Microsoft.Azure.Management.ContainerService.Fluent.Models.NetworkPlugin>
    {
        public static readonly NetworkPlugin Azure = Parse("azure");
        public static readonly NetworkPlugin Kubenet = Parse("kubenet");
    }
}
