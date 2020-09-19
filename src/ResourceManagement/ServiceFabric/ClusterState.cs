namespace Microsoft.Azure.Management.ServiceFabric.Fluent
{
    public enum ClusterState
    {
        WaitingForNodes,
        Deploying,
        BaselineUpgrade,
        UpdatingUserConfiguration,
        UpdatingUserCertificate,
        UpdatingInfrastructure,
        EnforcingClusterVersion,
        UpgradeServiceUnreachable,
        AutoScale,
        Ready
    }
}
