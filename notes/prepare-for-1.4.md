# Prepare for Azure Management Libraries for .NET 1.4.0 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.4 to 1.4 ...

> If this note missed any breaking changes, please open a pull request.

V1.4 is backwards compatible with V1.3 in the APIs intended for public use that reached the general availability (stable) stage in V1.x. 

Some breaking changes There were no breaking changes introduced even in APIs that were still in Beta in V1.2, as indicated by their inheritance from the `IBeta` interface.

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
</table>
