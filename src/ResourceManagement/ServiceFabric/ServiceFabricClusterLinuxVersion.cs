namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    class ServiceFabricLinuxVersion :
        ExpandableStringEnum<Microsoft.Azure.Management.ServiceFabric.Fluent.ServiceFabricLinuxVersion>
        {
            public static readonly ServiceFabricLinuxVersion Ubuntu16_04 = Parse("16.04");
            public static readonly ServiceFabricLinuxVersion Ubuntu18_04 = Parse("18.04");
            public static readonly ServiceFabricLinuxVersion RHEL = Parse("RHEL");
    }
}
