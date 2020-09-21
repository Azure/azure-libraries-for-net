using Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricCluster.Definition;


namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Domain.InterfaceImpl
{
    internal partial class ServiceFabricClusterImpl
    {
        IWithCreate IWithVmImage.WithVmImage()
        {
            return this.WithVmImage();
        }

    }
}
