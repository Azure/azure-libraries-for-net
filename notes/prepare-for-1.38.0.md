# Prepare for Azure Management Libraries for .NET 1.38 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.37.1 to 1.38 ...

> If this note missed any breaking changes, please open a pull request.

V1.38 is backwards compatible with V1.37.1 in the APIs intended for public use that reached the general availability (stable) stage in V1.x.

## Features

- Updating resource tag via `IAzure.GenericResources.Manager.Inner.Tags.UpdateAtScopeAsync`.

## Breaking changes

The following methods and/or types have been changed in V1.38 compared to the previous release (V1.37.1):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.37.1</th>
    <th align=left>In V1.38</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td align=left>Resources</td>
    <td align=left>Type of property <code>IDeployment.ProvisioningState</code> is <code>string</code></td>
    <td align=left>Type is changed to <code>ProvisioningState</code></td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/1261">PR #1261</th>
  </tr>
  <tr>
    <td align=left>Resources</td>
    <td align=left>Property <code>IDeployment.Template</code></td>
    <td align=left>Removed, as it is not in response</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/1261">PR #1261</th>
  </tr>
  <tr>
    <td align=left>Resources</td>
    <td align=left>Update flow of <code>IIGenericResource</code> uses PUT method</td>
    <td align=left>Changed to use PATCH method</td>
    <td align=left></td>
    <td align=left><a href="https://github.com/Azure/azure-libraries-for-net/pull/1261">PR #1261</th>
  </tr>
</table>
