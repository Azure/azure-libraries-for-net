// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.KubernetesCluster.Definition;
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class KubernetesClusterNetworkProfileImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        KubernetesCluster.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<KubernetesCluster.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies an IP address assigned to the Kubernetes DNS service; it must be within the Kubernetes service
        /// address range specified in the service CIDR.
        /// </summary>
        /// <param name="dnsServiceIP">
        /// The IP address assigned to the Kubernetes DNS service; it must be within the
        /// Kubernetes service address range specified in the service CIDR.
        /// </param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithDnsServiceIP<KubernetesCluster.Definition.IWithCreate>.WithDnsServiceIP(string dnsServiceIP)
        {
            return this.WithDnsServiceIP(dnsServiceIP);
        }

        /// <summary>
        /// Specifies a CIDR notation IP range assigned to the Docker bridge network; it must not overlap with
        /// any subnet IP ranges or the Kubernetes service address range.
        /// </summary>
        /// <param name="dockerBridgeCidr">
        /// The CIDR notation IP range assigned to the Docker bridge network; it must not
        /// overlap with any subnet IP ranges or the Kubernetes service address range.
        /// </param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithDockerBridgeCidr<KubernetesCluster.Definition.IWithCreate>.WithDockerBridgeCidr(string dockerBridgeCidr)
        {
            return this.WithDockerBridgeCidr(dockerBridgeCidr);
        }

        /// <summary>
        /// Specifies the network plugin type to be used for building the Kubernetes network.
        /// </summary>
        /// <param name="networkPlugin">The network plugin type to be used for building the Kubernetes network.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IBlank<KubernetesCluster.Definition.IWithCreate>.WithNetworkPlugin(NetworkPlugin networkPlugin)
        {
            return this.WithNetworkPlugin(networkPlugin);
        }

        /// <summary>
        /// Specifies the network policy to be used for building the Kubernetes network.
        /// </summary>
        /// <param name="networkPolicy">The network policy to be used for building the Kubernetes network.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithNetworkPolicy<KubernetesCluster.Definition.IWithCreate>.WithNetworkPolicy(NetworkPolicy networkPolicy)
        {
            return this.WithNetworkPolicy(networkPolicy);
        }

        /// <summary>
        /// Specifies a CIDR notation IP range from which to assign pod IPs when kubenet is used.
        /// </summary>
        /// <param name="podCidr">The CIDR notation IP range from which to assign pod IPs when kubenet is used.</param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithPodCidr<KubernetesCluster.Definition.IWithCreate>.WithPodCidr(string podCidr)
        {
            return this.WithPodCidr(podCidr);
        }

        /// <summary>
        /// Specifies a CIDR notation IP range from which to assign service cluster IPs; must not overlap with
        /// any subnet IP ranges.
        /// </summary>
        /// <param name="serviceCidr">
        /// The CIDR notation IP range from which to assign service cluster IPs; it must not
        /// overlap with any Subnet IP ranges.
        /// </param>
        /// <return>The next stage of the definition.</return>
        KubernetesCluster.Definition.IWithAttach<KubernetesCluster.Definition.IWithCreate> KubernetesCluster.Definition.IWithServiceCidr<KubernetesCluster.Definition.IWithCreate>.WithServiceCidr(string serviceCidr)
        {
            return this.WithServiceCidr(serviceCidr);
        }
    }
}