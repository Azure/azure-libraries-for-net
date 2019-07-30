// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    /// <summary>
    /// Helper to operate on storage account NetworkRule set(StorageAccountInner.networkRuleSet) property.
    /// </summary>
    internal class StorageNetworkRulesHelper
    {
        private static string BYPASS_NONE_STR = Bypass.None.ToString().ToLowerInvariant();
        private bool isInCreateMode;
        private StorageAccountInner inner;
        private StorageAccountCreateParameters createParameters;
        private StorageAccountUpdateParameters updateParameters;

        /// <summary>
        /// Creates StorageNetworkRulesHelper.
        /// </summary>
        /// <param name="createParameters">the model representing payload for storage account create.</param>
        internal StorageNetworkRulesHelper(StorageAccountCreateParameters createParameters)
        {
            this.isInCreateMode = true;
            this.createParameters = createParameters;
            this.updateParameters = null;
            this.inner = null;
        }

        /// <summary>
        /// Creates StorageNetworkRulesHelper.
        /// </summary>
        /// <param name="updateParameters">the model representing payload for storage account update</param>
        /// <param name="inner">the current state of storage account</param>
        internal StorageNetworkRulesHelper(StorageAccountUpdateParameters updateParameters, StorageAccountInner inner)
        {
            this.isInCreateMode = false;
            this.createParameters = null;
            this.updateParameters = updateParameters;
            this.inner = inner;
        }

        /// <summary>
        /// Checks whether access to the given storage account is allowed from all networks. 
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>true if access allowed from all networks, false otherwise</returns>
        internal static bool IsAccessAllowedFromAllNetworks(StorageAccountInner inner)
        {
            if (inner.NetworkRuleSet == null || inner.NetworkRuleSet.DefaultAction == null)
            {
                return true;
            }
            return inner.NetworkRuleSet.DefaultAction.Equals(DefaultAction.Allow);
        }

        /// <summary>
        /// The list of resource id of subnets having access to the given storage account.
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>list of subnet resource ids</returns>
        internal static List<String> NetworkSubnetsWithAccess(StorageAccountInner inner)
        {
            var subnetIds = new List<string>();
            if (inner.NetworkRuleSet != null && inner.NetworkRuleSet.VirtualNetworkRules != null)
            {
                foreach (var rule in inner.NetworkRuleSet.VirtualNetworkRules)
                {
                    if (rule != null && rule.VirtualNetworkResourceId != null)
                    {
                        subnetIds.Add(rule.VirtualNetworkResourceId);
                    }
                }
            }
            return subnetIds;
        }

        /// <summary>
        /// The list of ipv4 addresses having access to the given storage account.
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>list of ip addresses</returns>
        internal static List<String> IpAddressesWithAccess(StorageAccountInner inner)
        {
            var ipAddresses = new List<string>();
            if (inner.NetworkRuleSet != null && inner.NetworkRuleSet.IpRules != null)
            {
                foreach (var rule in inner.NetworkRuleSet.IpRules)
                {
                    if (rule != null && rule.IPAddressOrRange != null && !rule.IPAddressOrRange.Contains("/"))
                    {
                        ipAddresses.Add(rule.IPAddressOrRange);
                    }
                }
            }
            return ipAddresses;
        }

        /// <summary>
        /// The list of CIDR formatted ip address ranges having access to the given storage account.
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>list of ip address ranges in cidr format</returns>
        internal static List<String> IpAddressRangesWithAccess(StorageAccountInner inner)
        {
            var ipAddressRanges = new List<string>();
            if (inner.NetworkRuleSet != null && inner.NetworkRuleSet.IpRules != null)
            {
                foreach (var rule in inner.NetworkRuleSet.IpRules)
                {
                    if (rule != null && rule.IPAddressOrRange != null && rule.IPAddressOrRange.Contains("/"))
                    {
                        ipAddressRanges.Add(rule.IPAddressOrRange);
                    }
                }
            }
            return ipAddressRanges;
        }

        /// <summary>
        /// Checks storage log entries can be read from any network.
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>true if storage log entries can be read from any network, false otherwise</returns>
        internal static bool CanReadLogEntriesFromAnyNetwork(StorageAccountInner inner)
        {
            if (inner.NetworkRuleSet != null && inner.NetworkRuleSet.DefaultAction != null && inner.NetworkRuleSet.DefaultAction.Equals(DefaultAction.Deny))
            {
                ISet<String> bypassSet = ParseBypass(inner.NetworkRuleSet.Bypass);
                return bypassSet.Contains(Bypass.Logging.ToString().ToLowerInvariant());
            }
            return true;
        }

        /// <summary>
        /// Checks storage metrics can be read from any network.
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>true if storage metrics can be read from any network, false otherwise</returns>
        internal static bool CanReadMetricsFromAnyNetwork(StorageAccountInner inner)
        {
            if (inner.NetworkRuleSet != null && inner.NetworkRuleSet.DefaultAction != null && inner.NetworkRuleSet.DefaultAction.Equals(DefaultAction.Deny))
            {
                ISet<String> bypassSet = ParseBypass(inner.NetworkRuleSet.Bypass);
                return bypassSet.Contains(Bypass.Metrics.ToString().ToLowerInvariant());
            }
            return true;
        }

        /// <summary>
        /// Checks storage account can be accessed from applications running on azure.
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>true if storage can be accessed from application running on azure, false otherwise</returns>
        internal static bool CanAccessFromAzureServices(StorageAccountInner inner)
        {
            if (inner.NetworkRuleSet != null && inner.NetworkRuleSet.DefaultAction != null && inner.NetworkRuleSet.DefaultAction.Equals(DefaultAction.Deny))
            {
                ISet<String> bypassSet = ParseBypass(inner.NetworkRuleSet.Bypass);
                return bypassSet.Contains(Bypass.AzureServices.ToString().ToLowerInvariant());
            }
            return true;
        }

        /// <summary>
        /// Specifies that access to the storage account should be allowed from all networks.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithAccessFromAllNetworks()
        {
            NetworkRuleSet networkRuleSet = this.GetNetworkRuleSetConfig(true);
            networkRuleSet.DefaultAction = DefaultAction.Allow;
            return this;
        }

        /// <summary>
        /// Specifies that access to the storage account should be allowed only from selected networks.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithAccessFromSelectedNetworks()
        {
            NetworkRuleSet networkRuleSet = this.GetNetworkRuleSetConfig(true);
            networkRuleSet.DefaultAction = DefaultAction.Deny;
            return this;
        }

        /// <summary>
        /// cifies that access to the storage account from the given network subnet should be allowed.
        /// </summary>
        /// <param name="subnetId">the network subnet resource id</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithAccessFromNetworkSubnet(String subnetId)
        {
            NetworkRuleSet networkRuleSet = this.GetNetworkRuleSetConfig(true);
            if (networkRuleSet.VirtualNetworkRules == null)
            {
                networkRuleSet.VirtualNetworkRules = new List<VirtualNetworkRule>();
            }
            if (!networkRuleSet.VirtualNetworkRules.Any(r => r.VirtualNetworkResourceId.Equals(subnetId, StringComparison.OrdinalIgnoreCase)))
            {
                networkRuleSet.VirtualNetworkRules.Add(new VirtualNetworkRule
                {
                    VirtualNetworkResourceId = subnetId,
                    Action = Models.Action.Allow
                });
            }
            return this;
        }

        /// <summary>
        /// Specifies that access to the storage account from the given ip address should be allowed.
        /// </summary>
        /// <param name="ipAddress">the ip address</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithAccessFromIpAddress(string ipAddress)
        {
            return WithAccessAllowedFromIpAddressOrRange(ipAddress);
        }

        /// <summary>
        /// Specifies that access to the storage account from the given ip address range should be allowed.
        /// </summary>
        /// <param name="ipAddressCidr">the ip address range in cidr format</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithAccessFromIpAddressRange(string ipAddressCidr)
        {
            return WithAccessAllowedFromIpAddressOrRange(ipAddressCidr);
        }

        /// <summary>
        /// Specifies that read access to the storage account logging should be allowed from all networks.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithReadAccessToLoggingFromAnyNetwork()
        {
            AddToBypassList(Bypass.Logging);
            return this;
        }

        /// <summary>
        /// Specifies that read access to the storage account metrics should be allowed from all networks.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithReadAccessToMetricsFromAnyNetwork()
        {
            AddToBypassList(Bypass.Metrics);
            return this;
        }

        /// <summary>
        /// Specifies that access to the storage account from application running on Azure should be allowed.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithAccessAllowedFromAzureServices()
        {
            AddToBypassList(Bypass.AzureServices);
            return this;
        }

        /// <summary>
        /// Specifies that existing access to the storage account from the given subnet should be removed.
        /// </summary>
        /// <param name="subnetId">the network subnet resource id</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithoutNetworkSubnetAccess(String subnetId)
        {
            var networkRuleSet = this.GetNetworkRuleSetConfig(false);
            if (networkRuleSet == null || networkRuleSet.VirtualNetworkRules == null || networkRuleSet.VirtualNetworkRules.Count() == 0)
            {
                return this;
            }
            int foundIndex = -1;
            int i = 0;
            foreach (var rule in networkRuleSet.VirtualNetworkRules)
            {
                if (rule.VirtualNetworkResourceId.Equals(subnetId, StringComparison.OrdinalIgnoreCase))
                {
                    foundIndex = i;
                    break;
                }
                i++;
            }
            if (foundIndex != -1)
            {
                networkRuleSet.VirtualNetworkRules.RemoveAt(foundIndex);
            }
            return this;
        }


        /// <summary>
        /// Specifies that existing access to the storage account from the given ip address should be removed.
        /// </summary>
        /// <param name="ipAddress">the ip address</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithoutIpAddressAccess(string ipAddress)
        {
            return WithoutIpAddressOrRangeAccess(ipAddress);
        }

        /// <summary>
        /// Specifies that existing access to the storage account from the given ip address range should be removed.
        /// </summary>
        /// <param name="ipAddressCidr">the ip address range in cidr format</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithoutIpAddressRangeAccess(string ipAddressCidr)
        {
            return WithoutIpAddressOrRangeAccess(ipAddressCidr);
        }

        /// <summary>
        /// Specifies that previously added read access exception to the storage logging from any network
        /// should be removed.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithoutReadAccessToLoggingFromAnyNetwork()
        {
            RemoveFromBypassList(Bypass.Logging);
            return this;
        }

        /// <summary>
        /// Specifies that previously added read access exception to the storage metrics from any network
        /// should be removed.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithoutReadAccessToMetricsFromAnyNetwork()
        {
            RemoveFromBypassList(Bypass.Metrics);
            return this;
        }

        /// <summary>
        /// Specifies that previously added access exception to the storage account from application
        /// running on azure should be removed.
        /// </summary>
        /// <returns>StorageNetworkRulesHelper</returns>
        internal StorageNetworkRulesHelper WithoutAccessFromAzureServices()
        {
            RemoveFromBypassList(Bypass.AzureServices);
            return this;
        }

        /// <summary>
        /// Specifies that access to the storage account should be allowed from the given ip address or ip address range.
        /// </summary>
        /// <param name="ipAddressOrRange">the ip address or ip address range in cidr format</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        private StorageNetworkRulesHelper WithAccessAllowedFromIpAddressOrRange(String ipAddressOrRange)
        {
            var networkRuleSet = this.GetNetworkRuleSetConfig(true);
            if (networkRuleSet.IpRules == null)
            {
                networkRuleSet.IpRules = new List<IPRule>();
            }
            if (!networkRuleSet.IpRules.Any(r => r.IPAddressOrRange.Equals(ipAddressOrRange, StringComparison.OrdinalIgnoreCase)))
            {
                networkRuleSet.IpRules.Add(new IPRule
                {
                    IPAddressOrRange = ipAddressOrRange,
                    Action = Models.Action.Allow
                });
            }
            return this;
        }

        /// <summary>
        /// Specifies that existing access to the storage account from the given ip address or ip address range should be removed.
        /// </summary>
        /// <param name="ipAddressOrRange">the ip address or ip address range in cidr format</param>
        /// <returns>StorageNetworkRulesHelper</returns>
        private StorageNetworkRulesHelper WithoutIpAddressOrRangeAccess(String ipAddressOrRange)
        {
            NetworkRuleSet networkRuleSet = this.GetNetworkRuleSetConfig(false);
            if (networkRuleSet == null || networkRuleSet.IpRules == null || networkRuleSet.IpRules.Count() == 0)
            {
                return this;
            }
            int foundIndex = -1;
            int i = 0;
            foreach (IPRule rule in networkRuleSet.IpRules)
            {
                if (rule.IPAddressOrRange.Equals(ipAddressOrRange, StringComparison.OrdinalIgnoreCase))
                {
                    foundIndex = i;
                    break;
                }
                i++;
            }
            if (foundIndex != -1)
            {
                networkRuleSet.IpRules.RemoveAt(foundIndex);
            }
            return this;
        }


        /// <summary>
        /// Add the given bypass to the list of bypass configured for the storage account.
        /// </summary>
        /// <param name="bypass">access type to which default network access action is not applied.</param>
        private void AddToBypassList(Bypass bypass)
        {
            var networkRuleSet = this.GetNetworkRuleSetConfig(true);
            ISet<string> bypassSet = ParseBypass(networkRuleSet.Bypass);
            var bypassLower = bypass.ToString().ToLowerInvariant();
            if (bypassLower.Equals(BYPASS_NONE_STR, StringComparison.OrdinalIgnoreCase))
            {
                bypassSet.Clear();
                bypassSet.Add(BYPASS_NONE_STR);
            }
            else
            {
                if (bypassSet.Contains(BYPASS_NONE_STR))
                {
                    bypassSet.Remove(BYPASS_NONE_STR);
                }
                bypassSet.Add(bypassLower);
            }
            networkRuleSet.Bypass = Bypass.Parse(string.Join(",", bypassSet));
        }

        /// <summary>
        /// Removes the given bypass from the list of bypass configured for the storage account.
        /// </summary>
        /// <param name="bypass">access type to which default network access action is not applied.</param>
        private void RemoveFromBypassList(Bypass bypass)
        {
            var networkRuleSet = this.GetNetworkRuleSetConfig(false);
            if (networkRuleSet == null)
            {
                return;
            }
            else
            {
                ISet<string> bypassSet = ParseBypass(networkRuleSet.Bypass);
                var bypassLower = bypass.ToString().ToLowerInvariant();
                if (bypassSet.Contains(bypassLower))
                {
                    bypassSet.Remove(bypassLower);
                }
                if (bypassSet.Count == 0 && !bypassLower.Equals(BYPASS_NONE_STR, StringComparison.OrdinalIgnoreCase))
                {
                    bypassSet.Add(BYPASS_NONE_STR);
                }
                networkRuleSet.Bypass = Bypass.Parse(string.Join(",", bypassSet));
            }
        }


        /// <summary>
        /// Parses the given comma separated traffic sources to bypass and convert them to list.
        /// </summary>
        /// <param name="bypassVal">comma separated traffic sources to bypass.</param>
        /// <returns>the bypass list</returns>
        private static ISet<string> ParseBypass(Bypass bypassVal)
        {
            if (bypassVal == null)
            {
                return new HashSet<string>();
            }
            else
            {
                ISet<String> bypassSet = new HashSet<string>();
                foreach (string s in bypassVal.ToString().Split(','))
                {
                    var sl = s.Trim().ToLowerInvariant();
                    if (!string.IsNullOrEmpty(sl) && !bypassSet.Contains(sl))
                    {
                        bypassSet.Add(sl);
                    }
                }
                return bypassSet;
            }
        }

        /// <summary>
        /// Gets the network rule set.
        /// </summary>
        /// <param name="createIfNotExists">flag indicating whether to create a network rule set config if it does not exists already</param>
        /// <returns>the network rule set</returns>
        private NetworkRuleSet GetNetworkRuleSetConfig(bool createIfNotExists)
        {
            if (this.isInCreateMode)
            {
                if (this.createParameters.NetworkRuleSet == null)
                {
                    if (createIfNotExists)
                    {
                        this.createParameters.NetworkRuleSet = new NetworkRuleSet();
                    }
                    else
                    {
                        return null;
                    }
                }
                return this.createParameters.NetworkRuleSet;
            }
            else
            {
                if (this.updateParameters.NetworkRuleSet == null)
                {
                    if (this.inner.NetworkRuleSet == null)
                    {
                        if (createIfNotExists)
                        {
                            this.updateParameters.NetworkRuleSet = new NetworkRuleSet();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        // Create clone of current ruleSet
                        //
                        var clonedNetworkRuleSet = new NetworkRuleSet
                        {
                            DefaultAction = this.inner.NetworkRuleSet.DefaultAction
                        };
                        clonedNetworkRuleSet.Bypass = this.inner.NetworkRuleSet.Bypass;
                        if (this.inner.NetworkRuleSet.VirtualNetworkRules != null)
                        {
                            clonedNetworkRuleSet.VirtualNetworkRules = new List<VirtualNetworkRule>();
                            foreach (VirtualNetworkRule rule in this.inner.NetworkRuleSet.VirtualNetworkRules)
                            {
                                clonedNetworkRuleSet.VirtualNetworkRules.Add(new VirtualNetworkRule
                                {
                                    Action = rule.Action,
                                    VirtualNetworkResourceId = rule.VirtualNetworkResourceId
                                });
                            }
                        }
                        if (this.inner.NetworkRuleSet.IpRules != null)
                        {
                            clonedNetworkRuleSet.IpRules = new List<IPRule>();
                            foreach (IPRule rule in this.inner.NetworkRuleSet.IpRules)
                            {
                                clonedNetworkRuleSet.IpRules.Add(new IPRule
                                {
                                    Action = rule.Action,
                                    IPAddressOrRange = rule.IPAddressOrRange
                                });
                            }
                        }
                        this.updateParameters.NetworkRuleSet = clonedNetworkRuleSet;
                    }
                }
                return this.updateParameters.NetworkRuleSet;
            }
        }

        /// <summary>
        /// The NetworkRuleSet#defaultAction is a required property.
        /// During create mode, this method sets the default action to DENY if it is already not set by the user
        /// and user specifies at least one network rule or choose at least one exception.
        /// 
        /// When in update mode, this method set action to DENY only if there is no existing network rules and exception
        /// hence this is the first time user is adding a network rule or exception and action is not explicitly set by user.
        /// If there is any existing rules or exception, we honor currently configured action.
        /// </summary>
        internal void SetDefaultActionIfRequired()
        {
            if (isInCreateMode)
            {
                if (createParameters.NetworkRuleSet != null)
                {
                    bool hasAtLeastOneRule = false;

                    if (createParameters.NetworkRuleSet.VirtualNetworkRules != null && createParameters.NetworkRuleSet.VirtualNetworkRules.Count() > 0)
                    {
                        hasAtLeastOneRule = true;
                    }
                    else if (createParameters.NetworkRuleSet.IpRules != null && createParameters.NetworkRuleSet.IpRules.Count() > 0)
                    {
                        hasAtLeastOneRule = true;
                    }

                    bool anyException = createParameters.NetworkRuleSet.Bypass != null;
                    if ((hasAtLeastOneRule || anyException) && createParameters.NetworkRuleSet.DefaultAction == null)
                    {
                        // If user specified at least one network rule or selected any exception
                        // and didn't choose the default access action then "DENY" access from
                        // unknown networks.
                        //
                        createParameters.NetworkRuleSet.DefaultAction = DefaultAction.Deny;
                        if (!anyException)
                        {
                            // If user didn't select any by-pass explicitly then disable "all bypass"
                            // if this is not specified then by default service allows access from
                            // "azure-services".
                            //
                            createParameters.NetworkRuleSet.Bypass = Bypass.None;
                        }
                    }
                }
            }
            else
            {
                var currentRuleSet = this.inner.NetworkRuleSet;

                bool hasNoExistingException = currentRuleSet != null && currentRuleSet.Bypass == null;
                bool hasExistingRules = false;

                if (currentRuleSet != null)
                {
                    if (currentRuleSet.VirtualNetworkRules != null && currentRuleSet.VirtualNetworkRules.Count() > 0)
                    {
                        hasExistingRules = true;
                    }
                    else if (currentRuleSet.IpRules != null && currentRuleSet.IpRules.Count() > 0)
                    {
                        hasExistingRules = true;
                    }
                }
                if (!hasExistingRules)
                {
                    if (updateParameters.NetworkRuleSet != null)
                    {
                        bool anyRulesAddedFirstTime = false;

                        if (updateParameters.NetworkRuleSet.VirtualNetworkRules != null && updateParameters.NetworkRuleSet.VirtualNetworkRules.Count() > 0)
                        {
                            anyRulesAddedFirstTime = true;
                        }
                        else if (updateParameters.NetworkRuleSet.IpRules != null && updateParameters.NetworkRuleSet.IpRules.Count() > 0)
                        {
                            anyRulesAddedFirstTime = true;
                        }
                        bool anyExceptionAddedFirstTime = !hasNoExistingException && updateParameters.NetworkRuleSet.Bypass != null;
                        if ((anyRulesAddedFirstTime || anyExceptionAddedFirstTime) && updateParameters.NetworkRuleSet.DefaultAction == null)
                        {
                            // If there was no existing rules & exceptions and if user specified at least one
                            // network rule or exception and didn't choose the default access action for
                            // unknown networks then DENY access from unknown networks.
                            //
                            updateParameters.NetworkRuleSet.DefaultAction = DefaultAction.Deny;
                            if (!anyExceptionAddedFirstTime)
                            {
                                // If user didn't select any by-pass explicitly then disable "all bypass"
                                // if this is not specified then by default service allows access from
                                // "azure-services".
                                //
                                createParameters.NetworkRuleSet.Bypass = Bypass.None;
                            }
                        }
                    }
                }
            }
        }

    }
}