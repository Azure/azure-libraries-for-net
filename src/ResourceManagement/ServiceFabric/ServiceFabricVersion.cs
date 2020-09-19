namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for Service Fabric versions.
    /// https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-versions
    /// </summary>
    public class ServiceFabricVersion :
        ExpandableStringEnum<Microsoft.Azure.Management.ServiceFabric.Fluent.Models.ServiceFabricVersion>
    {
        public static readonly ServiceFabricVersion ServiceFabricWindowsRuntime_7_0_RTO = Parse("7.0.457.9590");
        public static readonly ServiceFabricVersion ServiceFabricWindowsRuntime_7_0_CU2 = Parse("7.0.464.9590");
        public static readonly ServiceFabricVersion ServiceFabricWindowsRuntime_7_0_CU3 = Parse("7.0.466.9590");
        public static readonly ServiceFabricVersion ServiceFabricWindowsRuntime_7_0_CU4 = Parse("7.0.470.9590");
        public static readonly ServiceFabricVersion ServiceFabricWindowsRuntime_7_1_RTO = Parse("7.1.409.9590");

        //public static readonly ServiceFabricVersion ServiceFabricLinuxRuntime_7_0_RTO = Parse("7.0.457.1");
        //public static readonly ServiceFabricVersion ServiceFabricLinuxRuntime_7_0_CU2 = Parse("7.0.464.1");
        //public static readonly ServiceFabricVersion ServiceFabricLinuxRuntime_7_0_CU3 = Parse("7.0.465.1");
        //public static readonly ServiceFabricVersion ServiceFabricLinuxRuntime_7_0_CU4 = Parse("7.0.469.1");
        //public static readonly ServiceFabricVersion ServiceFabricLinuxRuntime_7_1_RTO = Parse("7.1.410.1");
    }
}
