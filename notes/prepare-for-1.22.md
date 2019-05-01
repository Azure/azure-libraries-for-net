# Prepare for Azure Management Libraries for .NET 1.22 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.21 to 1.22 ...

> If this note missed any breaking changes, please open a pull request.


V1.21 is backwards compatible with V1.20 in the APIs intended for public use that reached the general availability (stable) stage in V1.x. 

Some breaking changes were introduced in APIs that were still in Beta in V1.16, as indicated by their inheritance from the `IBeta` interface.


## Breaking changes

The following methods and/or types have been changed in V1.22 compared to the previous release (V1.21):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.21</th>
    <th align=left>In V1.22</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
    <tr>
    <td align=left>Storage</td>
    <td align=left>List and ListAsync for StorageUsage</td>
    <td align=left>Removed</td>
    <td align=left></td>
    <td align=left></th>
  </tr>
</table>