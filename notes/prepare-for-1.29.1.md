# Prepare for Azure Management Libraries for .NET 1.29.1 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.29 to 1.29.1 ...

> If this note missed any breaking changes, please open a pull request.

V1.29.1 is backwards compatible with V1.29 in the APIs intended for public use that reached the general availability (stable) stage in V1.x.

Some breaking changes were introduced in APIs that were still in Beta in V1.29, as indicated by their inheritance from the `IBeta` interface.

## Breaking changes

The following methods and/or types have been changed in V1.29.1 compared to the previous release (V1.29):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.29</th>
    <th align=left>In V1.29.1</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
    <tr>
    <td align=left>ProvisioningState</td>
    <td align=left>string ProvisioningState</td>
    <td align=left>ProvisioningState ProvisioningState</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/927/commits/14adb5670babdbb2e35e39559fb89a206890f84e">PR #927</th>
  </tr>
</table>