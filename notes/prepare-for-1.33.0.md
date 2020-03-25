# Prepare for Azure Management Libraries for .NET 1.33 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.32 to 1.33 ...

> If this note missed any breaking changes, please open a pull request.

V1.33 is backwards compatible with V1.32 in the APIs intended for public use that reached the general availability (stable) stage in V1.x.

Some breaking changes were introduced in APIs that were still in Beta in V1.32, as indicated by their inheritance from the `IBeta` interface.

## Breaking changes

The following methods and/or types have been changed in V1.33 compared to the previous release (V1.32):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.32.0</th>
    <th align=left>In V1.33.0</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td align=left>CosmosDB</td>
    <td align=left><code>WithVirtualNetwork</code></td>
    <td align=left><code>WithVirtualNetworkRule</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-java/pull/1143">PR #1143</th>
  </tr>
  <tr>
    <td align=left>CosmosDB</td>
    <td align=left><code>WithoutVirtualNetwork</code></td>
    <td align=left><code>WithoutVirtualNetworkRule</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-java/pull/1143">PR #1143</th>
  </tr>
</table>