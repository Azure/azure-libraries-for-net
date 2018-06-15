# Prepare for Azure Management Libraries for .NET 1.11 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.10 to 1.11 ...

> If this note missed any breaking changes, please open a pull request.


V1.11 is backwards compatible with V1.10 in the APIs intended for public use that reached the general availability (stable) stage in V1.x with a few exceptions in the SQL management library (though these changes will have minimal impact on the developer). 

Some breaking changes were introduced in APIs that were still in Beta in V1.10, as indicated by their inheritance from the `IBeta` interface.


## Breaking changes

The following methods and/or types have been changed in V1.11 compared to the previous release (V1.10):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.10</th>
    <th align=left>In V1.11</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td><code>ContainerServiceVMSizeTypes</code></td>
    <td><code>StandardA0, StandardB1MS, StandardB1S</code></td>
    <td><code>N/A</code></td>
    <td>These container service VM size types are removed but since it's an expandable enum these values can be manually instantiated.</code></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/335">PR #335</a></td>
  </tr>
</table>

