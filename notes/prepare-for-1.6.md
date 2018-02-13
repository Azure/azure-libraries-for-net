# Prepare for Azure Management Libraries for .NET 1.6.0 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.4 to 1.6 ...

> If this note missed any breaking changes, please open a pull request.

V1.6 is backwards compatible with V1.4 in the APIs intended for public use that reached the general availability (stable) stage in V1.x. 

Some breaking changes were introduced in APIs that were still in Beta in V1.4, as indicated by their inheritance from the `IBeta` interface.

## Renames/Removals

The following methods and/or types have been either renamed or removed in V1.6 compared to the previous release (V1.4):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.4</th>
    <th align=left>In V1.6</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td><code>StorageAccount</code></td>
    <td><code>.WithEncryption()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>withBlobEncryption()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/137">PR #137 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine</code></td>
    <td><code>.ManagedServiceIdentityTenantId()</code></td>
    <td><code>.SystemAssignedManagedServiceIdentityTenantId()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine</code></td>
    <td><code>.ManagedServiceIdentityPrincipalId()</code></td>
    <td><code>.SystemAssignedManagedServiceIdentityPrincipalId()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine</code></td>
    <td><code>.WithManagedServiceIdentity()</code></td>
    <td><code>.WithSystemAssignedManagedServiceIdentity()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine</code></td>
    <td><code>.WithRoleBasedAccessTo(scope, role)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessTo(resourceId, role)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine</code></td>
    <td><code>.WithRoleBasedAccessToCurrentResourceGroup(role)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine</code></td>
    <td><code>.WithRoleDefinitionBasedAccessTo(scope, roleDefinitionId)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine</code></td>
    <td><code>.WithRoleDefinitionBasedAccessToCurrentResourceGroup(roleDefinitionId)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet</code></td>
    <td><code>.ManagedServiceIdentityTenantId()</code></td>
    <td><code>.SystemAssignedManagedServiceIdentityTenantId()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet</code></td>
    <td><code>.ManagedServiceIdentityPrincipalId()</code></td>
    <td><code>.SystemAssignedManagedServiceIdentityPrincipalId()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet</code></td>
    <td><code>.WithManagedServiceIdentity()</code></td>
    <td><code>.WithSystemAssignedManagedServiceIdentity()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet</code></td>
    <td><code>.WithRoleBasedAccessTo(scope, role)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessTo(resourceId, role)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet</code></td>
    <td><code>.WithRoleBasedAccessToCurrentResourceGroup(role)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet</code></td>
    <td><code>.WithRoleDefinitionBasedAccessTo(scope, roleDefinitionId)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet</code></td>
    <td><code>.WithRoleDefinitionBasedAccessToCurrentResourceGroup(roleDefinitionId)</code></td>
    <td><code>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId)</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/136">PR #136 </a></td>
  </tr>
  <tr>
    <td><code>WebAppBase</code></td>
    <td><code>.IsPremiumApp()</code></td>
    <td><code>Removed</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/149">PR #149 </a></td>
  </tr>
  <tr>
    <td><code>WebAppBase</code></td>
    <td><code>.MicroService()</code></td>
    <td><code>Removed</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/149">PR #149 </a></td>
  </tr>
  <tr>
    <td><code>WebAppBase</code></td>
    <td><code>.GatewaySiteName()</code></td>
    <td><code>Removed</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/149">PR #149 </a></td>
  </tr>
</table>

