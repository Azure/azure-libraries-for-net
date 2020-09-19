namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-versions
    /// </summary>
    class ServiceFabricWindowsVersion :
        ExpandableStringEnum<Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricWindowsVersion>
        {
            public static readonly ServiceFabricWindowsVersion WindowsServer2012_R2 = Parse("All");
            public static readonly ServiceFabricWindowsVersion WindowsServer2016 = Parse("6.0");
            public static readonly ServiceFabricWindowsVersion WindowsServer1709 = Parse("6.4");
            public static readonly ServiceFabricWindowsVersion WindowsServer1803 = Parse("6.4.654.9590");
            public static readonly ServiceFabricWindowsVersion WindowsServer1809 = Parse("6.4.654.9590");
            public static readonly ServiceFabricWindowsVersion WindowsServer2019 = Parse("6.0");
    }
}
