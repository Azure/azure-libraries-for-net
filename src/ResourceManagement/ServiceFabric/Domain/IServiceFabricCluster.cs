// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    using Microsoft.Azure.Management.ServiceFabric.Fluent;
    using Microsoft.Azure.Management.ServiceFabric.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A client-side representation for a Service Fabric cluster.
    /// </summary>
    public interface IServiceFabricCluster :
        IBeta,
        IGroupableResource<
                IServiceFabricManager,
                ServiceResourceInner
            >,
        IRefreshable<IServiceFabricCluster>,
        IUpdatable<Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricCluster.Update.IUpdate>
    {
        /// <summary>
        /// Gets the provisioning state of the Service Fabric cluster.
        /// </summary>
        string ClusterState { get; }

        /// <summary>
        /// Gets the Service Fabric version.
        /// </summary>
        ServiceFabricVersion Version { get; }
    }
}