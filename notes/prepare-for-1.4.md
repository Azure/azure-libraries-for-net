# Prepare for Azure Management Libraries for .NET 1.4.0 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.3 to 1.4 ...

> If this note missed any breaking changes, please open a pull request.

V1.4 is backwards compatible with V1.3 in the APIs intended for public use that reached the general availability (stable) stage in V1.x. 

There were no breaking changes introduced even in APIs that were still in Beta in V1.2, as indicated by their inheritance from the `IBeta` interface.

## Renames/Removals

The following methods and/or types have been either renamed or removed in V1.4 compared to the previous release (V1.3):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.3</th>
    <th align=left>In V1.4</th>
    <th align=left>Remarks</th>
  </tr>
  <tr>
    <td><code>StorageAccount</code></td>
    <td><code>.WithEncryption(Encryption)</code></td>
    <td><i>Removed</i></td>
    <td>Use <code>WithEncryption()</code> instead</td>
  </tr>
  <tr>
    <td><code>WebApp/FunctionApp/DeploymentSlot</code></td>
    <td><code>.UpdateAuthentication()</code></td>
    <td><i>Removed</i></td>
    <td>Please remove and re-define authentication instead</td>
  </tr>
  <tr>
    <td><code>IComputeManager</code></td>
    <td><code>.ContainerServices</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>IContainerServiceManager.ContainerServices</code> instead</td>
  </tr></table>

## Azure Container Services

Azure Container Service was moved out of Compute into its own namespace and resource manager. The corresponding Compute API's from the service are now deprecated and will be removed in a future release. The IAzure entry point for accessing resource management APIs has been modified to return the refactored service.

Some of the IContainerService API's have been renamed or removed:

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.3</th>
    <th align=left>In V1.4</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td><code>IContainerService</code></td>
    <td><code>.AgentPoolName</code></td>
    <td><i>Removed</i></td>
    <td>Use <code>.AgentPools.First().Value.Name</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerService</code></td>
    <td><code>.AgentPoolCount</code></td>
    <td><i>Removed</i></td>
    <td>Use <code>.AgentPools.First().Value.Count</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerService</code></td>
    <td><code>.AgentPoolLeafDomainLabel</code></td>
    <td><i>Removed</i></td>
    <td>Use <code>.AgentPools.First().Value.DnsPrefix</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerService</code></td>
    <td><code>.MasterLeafDomainLabel</code></td>
    <td><code>.MasterDnsPrefix</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerService</code></td>
    <td><code>.WithMasterLeafDomainLabel()</code></td>
    <td><code>.WithMasterDnsPrefix()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerService</code></td>
    <td><code>.WithAgentVMCount()</code></td>
    <td><code>.WithAgentVirtualMachineCount()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerServiceAgentPool</code></td>
    <td><code>.DnsLabel</code></td>
    <td><code>.DnsPrefix</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerServiceAgentPool</code></td>
    <td><code>.WithLeafDomainLabel()</code></td>
    <td><code>.WithDnsPrefix()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerServiceAgentPool</code></td>
    <td><code>.WithVMCount()</code></td>
    <td><code>.WithVirtualMachineCount()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
  <tr>
    <td><code>IContainerServiceAgentPool</code></td>
    <td><code>.WithVMSize()</code></td>
    <td><code>.WithVirtualMachineSize()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/96">PR #96</a></td>
  </tr>
</table>


A new simplified managed service for the deployment, management and operations for Kubernetes clusters is now available as preview as part of the Azure Container Services:

```CSharp
 kubernetesCluster = containerServiceManager.KubernetesClusters.Define("aksName")
    .WithRegion(Region.USCentral)
    .WithNewResourceGroup()
    .WithLatestVersion()
    .WithRootUsername("testaks")
    .WithSshKey("sshKey")
    .WithServicePrincipalClientId("spId")
    .WithServicePrincipalSecret("spSecret")
    .DefineAgentPool("agentPoolName")
        .WithVirtualMachineCount(1)
        .WithVirtualMachineSize(ContainerServiceVirtualMachineSizeTypes.StandardD1V2)
        .Attach()
    .WithDnsPrefix("dnsPrefix")
    .WithTag("tag1", "value1")
    .Create();
```
