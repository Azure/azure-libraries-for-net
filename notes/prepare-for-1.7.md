# Prepare for Azure Management Libraries for .NET 1.7.0 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.6 to 1.7 ...

> If this note missed any breaking changes, please open a pull request.


V1.7 is backwards compatible with V1.6 in the APIs intended for public use that reached the general availability (stable) stage in V1.x with a few exceptions in the SQL management library (though these changes will have minimal impact on the developer). 

Some breaking changes were introduced in APIs that were still in Beta in V1.6, as indicated by their inheritance from the `IBeta` interface.


## Breaking changes

The following methods and/or types have been changed in V1.7 compared to the previous release (V1.6):

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.6</th>
    <th align=left>In V1.7</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.Version()</code></td>
    <td>returns string</td>
    <td>Previously it returned ServerVersion which contained fixed set of values</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
</table>


## Deprecated API's ##

<table>
  <tr>
    <th align=left>Area/Model</th>
    <th align=left>In V1.6</th>
    <th align=left>In V1.7</th>
    <th align=left>Remarks</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.ListUsages()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.ListUsageMetrics()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.WithNewElasticPool()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.DefineElasticPool()</code> or <code>.ElasticPools().Define()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.WithNewDatabase()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.DefineDatabase()</code> or <code>.Databases().Define()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.WithNewFirewallRule()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.DefineFirewallRule()</code> or <code>.FirewallRules().Define()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.WithoutElasticPool()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>SqlElasticPool.Delete()</code> or <code>.ElasticPools().Delete()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.WithoutDatabase()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>SqlDatabase.Delete()</code> or <code>.Databases().Delete()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlServer</code></td>
    <td><code>.WithoutFirewallRule()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>SqlFirewallRule.Delete()</code> or <code>.FirewallRules().Delete()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>

  <tr>
    <td><code>SqlDatabase</code></td>
    <td><code>.GetUpgradeHint()</code></td>
    <td><i>Deprecated</i></td>
    <td>The service has discontinued this API (it returns null)</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlDatabase</code></td>
    <td><code>.ListUsages()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.ListMetrics()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlDatabase</code></td>
    <td><code>.WithEdition()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithBasicEdition()</code> or <code>.WithStandardEdition()</code> or <code>.WithPremiumEdition()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlDatabase</code></td>
    <td><code>.WithMaxSizeBytes()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithBasicEdition()</code> or <code>.WithStandardEdition()</code> or <code>.WithPremiumEdition()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlDatabase</code></td>
    <td><code>.WithServiceObjective()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithBasicEdition()</code> or <code>.WithStandardEdition()</code> or <code>.WithPremiumEdition()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlElasticPool</code></td>
    <td><code>.StorageMB()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.StorageCapacityInMB()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlElasticPool</code></td>
    <td><code>.WithEdition()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithBasicEdition()</code> or <code>.WithStandardEdition()</code> or <code>.WithPremiumEdition()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlElasticPool</code></td>
    <td><code>.WithDtu()</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithReservedDtu()</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlElasticPool</code></td>
    <td><code>.WithDatabaseDtuMin(int)</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithDatabaseDtuMin(SqlElasticPoolBasicMinEDTUs | SqlElasticPoolStandardMinEDTUs | SqlElasticPoolPremiumMinEDTUs)</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlElasticPool</code></td>
    <td><code>.WithDatabaseDtuMax(int)</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithDatabaseDtuMax(SqlElasticPoolBasicMaxEDTUs | SqlElasticPoolStandardMaxEDTUs | SqlElasticPoolPremiumMaxEDTUs)</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  <tr>
    <td><code>SqlElasticPool</code></td>
    <td><code>.WithStorageCapacity(int)</code></td>
    <td><i>Deprecated</i></td>
    <td>Use <code>.WithStorageCapacity(SqlElasticPoolStandardStorage | SqlElasticPoolPremiumSorage)</code> instead</td>
    <td><a href="https://github.com/Azure/azure-libraries-for-net/pull/194">PR #194 </a></td>
  </tr>
  
</table>

