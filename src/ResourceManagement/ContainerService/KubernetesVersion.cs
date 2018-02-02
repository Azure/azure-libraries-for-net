// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for Kubernetes versions.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuS3ViZXJuZXRlc1ZlcnNpb24=
    public class KubernetesVersion :
        ExpandableStringEnum<Microsoft.Azure.Management.ContainerService.Fluent.Models.KubernetesVersion>
    {
        public static readonly KubernetesVersion KUBERNETES_1_7_7 = Parse("1.7.7");
        public static readonly KubernetesVersion KUBERNETES_1_8_1 = Parse("1.8.1");
    }
}