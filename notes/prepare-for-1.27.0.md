# Prepare for Azure Management Libraries for .NET 1.27 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.26.1 to 1.27 ...

> If this note missed any breaking changes, please open a pull request.

V1.27 is backwards compatible with V1.26.1 in the APIs intended for public use that reached the general availability (stable) stage in V1.x.

## Breaking changes

The following methods and/or types have been changed in V1.27.0 compared to the previous release (V1.26.1):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.26.1</th>
    <th align=left>In V1.27.0</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td align=left>Batch</td>
    <td align=left>All Package</td>
    <td align=left>Removed</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/831">PR #831</th>
  </tr>
  <tr>
    <td align=left>Container Service</td>
    <td align=left>StorageProfile in ManagedClusterAgentPoolProfile</td>
    <td align=left>Removed</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/793">PR #793</th>
  </tr>
  <tr>
    <td align=left>Container Service</td>
    <td align=left><code>ContainerServiceVirtualMachineSizeTypes</code></td>
    <td align=left><code>ContainerServiceVMSizeTypes</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/793">PR #793</th>
  </tr>
  <tr>
    <td align=left>Container Service</td>
    <td align=left><code>StorageProfileTypes</code></td>
    <td align=left><code>ContainerServiceStorageProfileTypes</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/793">PR #793</th>
  </tr>
  <tr>
    <td align=left>Container Service</td>
    <td align=left><code>ContainerServiceOSTypes</code></td>
    <td align=left><code>OSType</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/793">PR #793</th>
  </tr>
</table>