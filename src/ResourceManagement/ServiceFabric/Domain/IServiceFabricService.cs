namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    using Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricCluster.Update;
    using Microsoft.Azure.Management.ServiceFabric.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// A client-side representation for a managed Kubernetes cluster.
    /// </summary>
    public interface IServiceFabricService  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<
                Microsoft.Azure.Management.ServiceFabric.Fluent.IServiceFabricManager, 
                Models.ServiceResourceInner
            >,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ServiceFabric.Fluent.IServiceFabricCluster>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ServiceFabricCluster.Update.IUpdate>
    {


        /// <summary>
        /// Gets the provisioning state of the Kubernetes cluster.
        /// </summary>
        string ProvisioningState { get; }

        ReliabilityLevel ReliabilityLevel { get; }

        /// <summary>
        /// Gets the Linux SSH key.
        /// </summary>
        string SshKey { get; }

        /// <summary>
        /// Gets the Kubernetes version.
        /// </summary>
        Microsoft.Azure.Management.ServiceFabric.Fluent.Models.ServiceFabricVersion Version { get; }
    }
}