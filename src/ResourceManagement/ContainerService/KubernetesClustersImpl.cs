// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for KubernetesClusters.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnNlcnZpY2UuaW1wbGVtZW50YXRpb24uS3ViZXJuZXRlc0NsdXN0ZXJzSW1wbA==
    internal partial class KubernetesClustersImpl  :
        TopLevelModifiableResources<
            Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster,
            Microsoft.Azure.Management.ContainerService.Fluent.KubernetesClusterImpl,
            Models.ManagedClusterInner,
            IManagedClustersOperations,
            Microsoft.Azure.Management.ContainerService.Fluent.IContainerServiceManager>,
        IKubernetesClusters
    {

        ///GENMHASH:CEE9B4E44892129894F967CA6EF022FA:CA53D863E18032E03B7ADE68186DACBF
        internal KubernetesClustersImpl(IContainerServiceManager containerServiceManager) : base(containerServiceManager.Inner.ManagedClusters, containerServiceManager)
        {
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:3465A3DCD277E9A5753E26447392918E
        protected override KubernetesClusterImpl WrapModel(string name)
        {
            return new KubernetesClusterImpl(name, new ManagedClusterInner(), this.Manager);
        }

        ///GENMHASH:871354AC57E9E37DD419453445BD56FF:8BF85C2711AE52862B285B2BDAB6D0A0
        protected override IKubernetesCluster WrapModel(ManagedClusterInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new KubernetesClusterImpl(inner.Name, inner, this.Manager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:664BEF11BF4AA10D27449EE89EF181F3
        public KubernetesClusterImpl Define(string name)
        {
            return this.WrapModel(name);
        }

        ///GENMHASH:A29E3C44F232D6AD6CD9EF81D1AE9597:48507D05305E08740A0218561D3EDA89
        public ISet<string> ListKubernetesVersions(Region region)
        {
            return Extensions.Synchronize(() => this.ListKubernetesVersionsAsync(region));
        }

        ///GENMHASH:CFB200365F136E24A05DA4CA5D87466A:C8A44D9607E03D975E77B90674D3D3F3
        public async Task<System.Collections.Generic.ISet<string>> ListKubernetesVersionsAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            var kubernetesVersions = new SortedSet<string>();
            var inner = await this.Manager.Inner.ContainerServices.ListOrchestratorsAsync(region.Name, cancellationToken:cancellationToken);
            if (inner != null && inner.Orchestrators != null && inner.Orchestrators.Count > 0)
            {
                foreach (var orchestrator in inner.Orchestrators)
                {
                    if (orchestrator.OrchestratorType.Equals("Kubernetes"))
                    {
                        kubernetesVersions.Add(orchestrator.OrchestratorVersion);
                    }
                }
            }

            return kubernetesVersions;
        }

        public byte[] GetAdminKubeConfigContents(string resourceGroupName, string kubernetesCluster)
        {
            return Extensions.Synchronize(() => this.GetAdminKubeConfigContentsAsync(resourceGroupName, kubernetesCluster));
        }

        public async Task<byte[]> GetAdminKubeConfigContentsAsync(string resourceGroupName, string kubernetesCluster, CancellationToken cancellationToken = default(CancellationToken))
        {
            var credentialInner = await this.Manager.Inner.ManagedClusters
                .ListClusterAdminCredentialsAsync(resourceGroupName, kubernetesCluster, cancellationToken: cancellationToken);
            if (credentialInner == null || credentialInner.Kubeconfigs == null || credentialInner.Kubeconfigs.Count == 0)
            {
                return new byte[0];
            }
            else
            {
                return credentialInner.Kubeconfigs[0].Value;
            }
        }

        public byte[] GetUserKubeConfigContents(string resourceGroupName, string kubernetesCluster)
        {
            return Extensions.Synchronize(() => this.GetUserKubeConfigContentsAsync(resourceGroupName, kubernetesCluster));
        }

        public async Task<byte[]> GetUserKubeConfigContentsAsync(string resourceGroupName, string kubernetesCluster, CancellationToken cancellationToken = default(CancellationToken))
        {
            var credentialInner = await this.Manager.Inner.ManagedClusters
                .ListClusterUserCredentialsAsync(resourceGroupName, kubernetesCluster, cancellationToken: cancellationToken);
            if (credentialInner == null || credentialInner.Kubeconfigs == null || credentialInner.Kubeconfigs.Count == 0)
            {
                return new byte[0];
            }
            else
            {
                return credentialInner.Kubeconfigs[0].Value;
            }
        }

        ///GENMHASH:0FEF45F7011A46EAF6E2D15139AE631D:4593F1A2996AA2D0219FCEB42EA28D41
        protected Task<Models.ManagedClusterInner> GetInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetInnerByGroupAsync(resourceGroupName, name, cancellationToken);
        }

        protected override async Task<ManagedClusterInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await this.Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D35601E6590F84E3EC86E2AC56E37A0:136D659EB836ECA199ED5D69D4606314
        protected async Task DeleteInnerAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteInnerByGroupAsync(resourceGroupName, name, cancellationToken);
        }

        protected override async Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:8F1B6ED149CF9BB9C8B7AF4CAED5C225
        public override IEnumerable<Microsoft.Azure.Management.ContainerService.Fluent.IKubernetesCluster> List()
        {
            return Manager.ResourceManager.ResourceGroups.List()
                                          .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:08226B2C955BC74F546710BB065F1D73
        public async override Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IKubernetesCluster>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellationToken);

            return await PagedCollection<IKubernetesCluster, ManagedClusterInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var kubernetesCluster = await Task.WhenAll(resourceGroups.Select(async (rg) => await ListInnerByGroupAsync(rg.Name, cancellation)));
                return kubernetesCluster.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }

        protected override async Task<IPage<ManagedClusterInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await this.Inner.ListAsync(cancellationToken);
        }

        protected override async Task<IPage<ManagedClusterInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Inner.ListNextAsync(nextLink, cancellationToken);
        }

        protected override async Task<IPage<ManagedClusterInner>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await this.Inner.ListByResourceGroupAsync(resourceGroupName, cancellationToken);
        }

        protected override async Task<IPage<ManagedClusterInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }
    }
}