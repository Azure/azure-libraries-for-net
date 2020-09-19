using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ServiceFabric.Fluent.Models;
using Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricCluster.Update;
using Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricCluster.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    /// <summary>
    /// The implementation for ServiceFabricCluster and its create and update interfaces.
    /// </summary>
    internal partial class ServiceFabricClusterImpl :
        GroupableResource<
            IServiceFabricCluster,
            ServiceResourceInner,
            ServiceFabricClusterImpl,
            IServiceFabricManager,
            IWithGroup,
            IWithOsType,
            IWithCreate,
            IUpdate>,
        IServiceFabricCluster,
        IDefinition,
        IUpdate
    {
        string IIndexable.Key => throw new NotImplementedException();

        public string ClusterState => throw new NotImplementedException();

        ServiceFabricVersion IServiceFabricCluster.Version => throw new NotImplementedException();

        IServiceFabricManager IHasManager<IServiceFabricManager>.Manager => throw new NotImplementedException();

        internal ServiceFabricClusterImpl(string name, ServiceResourceInner innerModel, IServiceFabricManager manager)
            : base(name, innerModel, manager)
        {
        }

        public string ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

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


        IWithGroup IDefinitionWithRegion<IWithGroup>.WithRegion(string regionName)
        {
            throw new NotImplementedException();
        }

        IWithGroup IDefinitionWithRegion<IWithGroup>.WithRegion(Region region)
        {
            throw new NotImplementedException();
        }

        public IWithCreate WithOsType(ServiceFabricOsType serviceFabriOsType)
        {
            throw new NotImplementedException();
        }

        public override Task<IServiceFabricCluster> CreateResourceAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<ServiceResourceInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

