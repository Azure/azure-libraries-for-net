# Prepare for Azure Management Libraries for .NET 1.29 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.28.1 to 1.29 ...

> If this note missed any breaking changes, please open a pull request.

V1.29 is backwards compatible with V1.28.1 in the APIs intended for public use that reached the general availability (stable) stage in V1.x.

Some breaking changes were introduced in APIs that were still in Beta in V1.28.1, as indicated by their inheritance from the `IBeta` interface.

## Breaking changes

The following methods and/or types have been changed in V1.29 compared to the previous release (V1.28.1):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.28.1</th>
    <th align=left>In V1.29</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
    <tr>
    <td align=left>IDisk</td>
    <td align=left>FromVhd</td>
    <td align=left>FromVhd.WithStorageAccount</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/911/commits/adb39238fd20b940bdcfb6e2bc11234da8c732b6">PR #911</th>
  </tr>
</table>