# Prepare for Azure Management Libraries for .NET 1.3 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.2 to 1.3 …

> If this note missed any breaking changes, please open a pull request.

V1.3 is backwards compatible with V1.2 in the APIs intended for public use that reached the general availability (stable) stage in V1.0. 

Some breaking changes were introduced in APIs that were still in Beta in V1.2 (as indicated by their inheritance from the `IBeta` interface.)


### Renames

<table>
  <tr>
    <th align=left>From</th>
    <th align=left>To</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
      <td><code></code></td>
      <td><code></code></td>
      <td><a href=""></a></td>
  </tr>
</table>

### API Removals

<table>
  <tr>
    <th>Removed</th>
    <th>Alternate to switch to</th>
  </tr>
  <tr>
    <td><code>IPacketCapture.DefinePacketCaptureFilter</code></td>
    <td><code>IPacketCapture.DefinePacketCaptureFilter()</code> <i>(method)</i></td>
  </tr>
  <tr>
    <td><code>INetworkWatcher.VerifyIPFlow</code></td>
    <td><code>INetworkWatcher.VerifyIPFlow()</code> <i>(method)</i></td>
  </tr>
  <tr>
    <td><code>INetworkWatcher.NextHop</code></td>
    <td><code>INetworkWatcher.NextHop()</code> <i>(method)</i></td>
  </tr>
</table>
