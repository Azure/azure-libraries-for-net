# Prepare for Azure Management Libraries for .NET 1.31 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.30 to 1.31 ...

> If this note missed any breaking changes, please open a pull request.

V1.31 is backwards compatible with V1.30 in the APIs intended for public use that reached the general availability (stable) stage in V1.x.

Some breaking changes were introduced in APIs that were still in Beta in V1.30, as indicated by their inheritance from the `IBeta` interface.

## Breaking changes

The following methods and/or types have been changed in V1.31 compared to the previous release (V1.30):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.30.0</th>
    <th align=left>In V1.31.0</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td align=left>GenericResources</td>
    <td align=left><code>GetByIdAsync(id, cancellationToken)</code></td>
    <td align=left><code>GetByIdAsync(id, apiVersion, cancellationToken)</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/970">PR #970</th>
  </tr>
  <tr>
    <td align=left>GenericResources</td>
    <td align=left><code>DeleteByIdAsync(id, cancellationToken)</code></td>
    <td align=left><code>DeleteByIdAsync(id, apiVersion, cancellationToken)</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/970">PR #970</th>
  </tr>
  <tr>
    <td align=left>GenericResources</td>
    <td align=left><code>GetByResourceGroup</code></td>
    <td align=left>Removed</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/970">PR #970</th>
  </tr>
  <tr>
    <td align=left>GenericResources</td>
    <td align=left><code>GetByResourceGroupAsync</code></td>
    <td align=left>Removed</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/970">PR #970</th>
  </tr>
</table>