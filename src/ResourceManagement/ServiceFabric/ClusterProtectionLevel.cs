namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    ///
    /// </summary>
    public class ClusterProtectionLevel : ExpandableStringEnum<ClusterProtectionLevel>
    {
        public static readonly ClusterProtectionLevel None = Parse("None");
        public static readonly ClusterProtectionLevel Signed = Parse("Signed");
        public static readonly ClusterProtectionLevel EncryptAndSign = Parse("EncryptAndSign");
    }
}
