namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-versions
    /// </summary>
    public class ServiceFabricOsType
        : ExpandableStringEnum<ServiceFabricOsType>
    {
        public static readonly ServiceFabricOsType Linux = Parse("Linux");
        public static readonly ServiceFabricOsType Windows = Parse("Windows");
    }
}
