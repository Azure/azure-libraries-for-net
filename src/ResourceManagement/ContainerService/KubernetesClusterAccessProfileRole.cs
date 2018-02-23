// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for Kubernetes cluster access profile role.
    /// </summary>
    public class KubernetesClusterAccessProfileRole :
        ExpandableStringEnum<Microsoft.Azure.Management.ContainerService.Fluent.Models.KubernetesClusterAccessProfileRole>
    {
        public static readonly KubernetesClusterAccessProfileRole USER = Parse("clusterUser");
        public static readonly KubernetesClusterAccessProfileRole ADMIN = Parse("clusterAdmin");
    }
}
