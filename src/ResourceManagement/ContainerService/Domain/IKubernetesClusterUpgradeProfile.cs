// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The result of checking for the Kubernetes cluster's upgrade profile.
    /// </summary>
    public interface IKubernetesClusterUpgradeProfile  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ManagedClusterUpgradeProfileInner>
    {
        /// <summary>
        /// Gets the ID of the Kubernetes cluster upgrade profile.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the name of the Kubernetes cluster upgrade profile.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the type of the Kubernetes cluster upgrade profile.
        /// </summary>
        string Type { get; }
    }
}