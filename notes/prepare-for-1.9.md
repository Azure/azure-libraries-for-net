# Prepare for Azure Management Libraries for .NET 1.9 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.8 to 1.9 ...

> If this note missed any breaking changes, please open a pull request.


V1.9 is backwards compatible with V1.6 in the APIs intended for public use that reached the general availability (stable) stage in V1.x with a few exceptions in the SQL management library (though these changes will have minimal impact on the developer). 

Some breaking changes were introduced in APIs that were still in Beta in V1.8, as indicated by their inheritance from the `IBeta` interface.


## Breaking changes

The following methods and/or types have been changed in V1.9 compared to the previous release (V1.8):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.8</th>
    <th align=left>In V1.9</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td><code>Authentication flow</code></td>
    <td><code>Credentials</code> property of <code>RestClient</code> class was of type <code>ServiceClientCredentials</code></td>
    <td><code>Credentials</code> property of <code>RestClient</code> class is now of type<code>AzureCredentials</code></td>
    <td><code>AzureCredentials</code> has a new constructor that accepts <code>ServiceClientCredentials</code> parameter. This will enable handling authentication process outside Fluent SDK framework and using acuired token during Fluent SDK communication by passing in <code>ServiceClientCredentials</code></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/195">PR #195 </a></td>
  </tr>
  <tr>
    <td><code>NetworkWatcher</code></td>
    <td><code>.GetTopology(string targetResourceGroup)</code></td>
    <td><code>.Topology().WithTargetResourceGroup(string resourceGroupName).WithTargetNetwork(string networkId).WithTargetSubnet(string subnetName).Execute()</code> where <code>WithTargetNetwork()</code> and <code>WithTargetSubnet()</code> are optional</td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/267">PR #267 </a></td>
  </tr>
  <tr>
    <td><code>NetworkWatcher</code></td>
    <td><code>.GetTopologyAsync(string targetResourceGroup)</code></td>
    <td><code>.Topology().WithTargetResourceGroup(string resourceGroupName).WithTargetNetwork(string networkId).WithTargetSubnet(string subnetName).ExecuteAsync()</code> where <code>WithTargetNetwork()</code> and <code>WithTargetSubnet()</code> are optional</td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/267">PR #267 </a></td>
  </tr>
  <tr>
    <td><code>VerificationIPFlow</code></td>
    <td><code>.WithProtocol(Protocol protocol)</code></td>
    <td><code>.WithProtocol(IpFlowProtocol)</code></td>
    <td>Updated to the latest swagger specs</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/267">PR #267 </a></td>
  </tr>
  <tr>
    <td><code>ExpressRouteCircuitPeering</code></td>
    <td><code>ExpressRouteCircuitPeeringType PeeringType</code></td>
    <td><code>ExpressRoutePeeringType PeeringType</code></td>
    <td>Property type changed.</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/267">PR #267 </a></td>
  </tr>
  <tr>
    <td><code>ExpressRouteCircuitPeering</code></td>
    <td><code>ExpressRouteCircuitPeeringState State</code></td>
    <td><code>ExpressRoutePeeringState State</code></td>
    <td>Property type changed.</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/267">PR #267 </a></td>
  </tr>
  <tr>
    <td><code>ExpressRouteCircuitPeering</code></td>
    <td><code>int PeerAsn</code></td>
    <td><code>long PeerAsn</code></td>
    <td>Property type changed.</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/267">PR #267 </a></td>
  </tr>
  <tr>
    <td><code>NetworkPeering</code></td>
    <td><code>NetworkPeeringState State</code></td>
    <td><code>VirtualNetworkPeeringState State</code></td>
    <td>Property type changed.</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/267">PR #267 </a></td>
  </tr>                      
</table>


## Deprecated API's ##

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.8</th>
    <th align=left>In V1.9</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>

  <tr>
    <td><code>Redis Cache</code></td>
    <td><code>Update.WithSubnet(HasId networkResource, string subnetName)</code></td>
    <td><i>Deprecated</i></td>
    <td>Subnet configuration cannot be changed on existing Redis Cache instance.</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/240">PR #240 </a></td>
  </tr>
  <tr>
    <td><code>Redis Cache</code></td>
    <td><code>Update.WithStaticIP(string staticIP)</code></td>
    <td><i>Deprecated</i></td>
    <td>Static IP configuration cannot be changed on existing Redis Cache instance.</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/240">PR #240 </a></td>
  </tr>
</table>

