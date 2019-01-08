# Prepare for Azure Management Libraries for .NET 1.18 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.17 to 1.18 ...

> If this note missed any breaking changes, please open a pull request.


V1.17 is backwards compatible with V1.16 in the APIs intended for public use that reached the general availability (stable) stage in V1.x. 

Some breaking changes were introduced in APIs that were still in Beta in V1.16, as indicated by their inheritance from the `IBeta` interface.


## Breaking changes

The following methods and/or types have been changed in V1.18 compared to the previous release (V1.17):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.17</th>
    <th align=left>In V1.18</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
    <tr>
    <td align=left>ContainerRegistery</td>
    <td align=left>QueuedBuildOperations</td>
    <td align=left>RegistryTaskRuns</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/543">PR #543</th>
  </tr>
</table>

