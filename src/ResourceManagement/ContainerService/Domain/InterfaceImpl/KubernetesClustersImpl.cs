// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class KubernetesClustersImpl
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        KubernetesCluster.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<KubernetesCluster.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Returns the admin Kube.config content which can be used with a Kubernetes client.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name where the cluster is.</param>
        /// <param name="kubernetesClusterName">The managed cluster name.</param>
        /// <return>The Kube.config content which can be used with a Kubernetes client.</return>
        byte[] Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusters.GetAdminKubeConfigContents(string resourceGroupName, string kubernetesClusterName)
        {
            return this.GetAdminKubeConfigContents(resourceGroupName, kubernetesClusterName);
        }

        /// <summary>
        /// Returns asynchronously the admin Kube.config content which can be used with a Kubernetes client.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name where the cluster is.</param>
        /// <param name="kubernetesClusterName">The managed cluster name.</param>
        /// <return>A future representation of the Kube.config content which can be used with a Kubernetes client.</return>
        async Task<byte[]> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusters.GetAdminKubeConfigContentsAsync(string resourceGroupName, string kubernetesClusterName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetAdminKubeConfigContentsAsync(resourceGroupName, kubernetesClusterName, cancellationToken);
        }

        /// <summary>
        /// Returns the user Kube.config content which can be used with a Kubernetes client.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name where the cluster is.</param>
        /// <param name="kubernetesClusterName">The managed cluster name.</param>
        /// <return>The Kube.config content which can be used with a Kubernetes client.</return>
        byte[] Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusters.GetUserKubeConfigContents(string resourceGroupName, string kubernetesClusterName)
        {
            return this.GetUserKubeConfigContents(resourceGroupName, kubernetesClusterName);
        }

        /// <summary>
        /// Returns asynchronously the user Kube.config content which can be used with a Kubernetes client.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name where the cluster is.</param>
        /// <param name="kubernetesClusterName">The managed cluster name.</param>
        /// <return>A future representation of the Kube.config content which can be used with a Kubernetes client.</return>
        async Task<byte[]> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusters.GetUserKubeConfigContentsAsync(string resourceGroupName, string kubernetesClusterName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetUserKubeConfigContentsAsync(resourceGroupName, kubernetesClusterName, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IKubernetesCluster>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster>.ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListByResourceGroupAsync(resourceGroupName, loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Returns the list of available Kubernetes versions available for the given Azure region.
        /// </summary>
        /// <param name="region">The Azure region to query into.</param>
        /// <return>A set of Kubernetes versions which can be used when creating a service in this region.</return>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusters.ListKubernetesVersions(Region region)
        {
            return this.ListKubernetesVersions(region);
        }

        /// <summary>
        /// Returns the list of available Kubernetes versions available for the given Azure region.
        /// </summary>
        /// <param name="region">The Azure region to query into.</param>
        /// <return>A future representation of a set of Kubernetes versions which can be used when creating a service in this region.</return>
        async Task<System.Collections.Generic.ISet<string>> Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesClusters.ListKubernetesVersionsAsync(Region region, CancellationToken cancellationToken)
        {
            return await this.ListKubernetesVersionsAsync(region, cancellationToken);
        }
    }
}