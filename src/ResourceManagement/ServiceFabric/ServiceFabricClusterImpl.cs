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

using Environment = Microsoft.Azure.Management.ServiceFabric.Fluent.Models.Environment;


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
            IWithParameters,
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

        public IWithCreate WithVmImage(Environment environment)
        {
            this.Inner.ClusterParameters.VmImage = Microsoft.Azure.Management.ServiceFabric.Fluent.Models.Environment.Windows.ToString();

            return this;
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

