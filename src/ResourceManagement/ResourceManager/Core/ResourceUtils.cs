// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public static class ResourceUtils
    {
        private static IReadOnlyDictionary<string, string> apiVersions;

        public static string GroupFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).ResourceGroupName : null;
        }

        public static string SubscriptionFromResourceId(string id)
        {
            return (id != null) ? ResourceId.FromString(id).SubscriptionId : null;
        }

        public static string ResourceProviderFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).ProviderNamespace : null;
        }

        public static string ResourceTypeFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).ResourceType : null;
        }

        public static string NameFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).Name : null;
        }

        public static string ParentResourcePathFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id)?.Parent?.Id : null;
        }

        /// <summary>
        /// Extracts parent resource path from a resource ID string.
        /// </summary>
        /// <example>
        /// "subscriptions/SSS/resourcegroups/RRR/foos/foo/bars/bar" will return "foos/foo".
        /// </example>
        /// <param name="id">a resource ID</param>
        /// <returns>relative parent path</returns>
        public static string ParentRelativePathFromResourceId(string id)
        {
            if (id == null)
            {
                return null;
            }

            ResourceId parent = ResourceId.FromString(id).Parent;
            if (parent != null)
            {
                return parent.ResourceType + "/" + parent.Name;
            }

            return "";
        }

        public static string ConstructResourceId(
            string subscriptionId,
            string resourceGroupName,
            string resourceProviderNamespace,
            string resourceType,
            string resourceName,
            string parentResourcePath)
        {
            string prefixedParentPath = parentResourcePath;
            if (!string.IsNullOrEmpty(parentResourcePath))
            {
                prefixedParentPath = "/" + parentResourcePath;
            }
            return string.Format(
                    "/subscriptions/{0}/resourcegroups/{1}/providers/{2}{3}/{4}/{5}",
                    subscriptionId,
                    resourceGroupName,
                    resourceProviderNamespace,
                    prefixedParentPath,
                    resourceType,
                    resourceName);
        }

        public static string CreateODataFilterForTags(string tagName, string tagValue)
        {
            if (tagName == null)
            {
                return null;
            }

            else if (tagValue == null)
            {
                return $"tagname eq '{tagName.Trim('\'')}'";
            }
            else
            {
                return $"tagname eq '{tagName.Trim('\'')}' and tagvalue eq '{tagValue.Trim('\'')}'";
            }
        }


        /**
         * Try to extract the environment the client is authenticated to based
         * on the information on the rest client.
         * @param restClient the RestClient instance
         * @return the non-null AzureEnvironment
         */
        public static AzureEnvironment ExtractAzureEnvironment(RestClient restClient)
        {
            AzureEnvironment environment = null;
            if (restClient.Credentials is AzureCredentials)
            {
                environment = restClient.Credentials.Environment;
            }
            else
            {
                string baseUrl = restClient.BaseUri;
                if (AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureGlobalCloud;
                }
                else if (AzureEnvironment.AzureChinaCloud.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureChinaCloud;
                }
                else if (AzureEnvironment.AzureGermanCloud.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureGermanCloud;
                }
                else if (AzureEnvironment.AzureUSGovernment.ResourceManagerEndpoint.ToLower().Contains(baseUrl.ToLower()))
                {
                    environment = AzureEnvironment.AzureUSGovernment;
                }
                if (environment == null)
                {
                    throw new NotSupportedException("Unknown resource manager endpoint " + baseUrl);
                }
            }
            return environment;
        }

        public static string ApiVersionFromResourceId(string id)
        {
            if (id == null)
            {
                return null;
            }
            if (apiVersions == null)
            {
                InitApiVersions();
            }
            try
            {
                string type = ResourceTypeFromResourceId(id);
                if (type == null)
                {
                    return null;
                }
                string parent = ParentResourcePathFromResourceId(id);
                string resourceProvider = ResourceProviderFromResourceId(id);
                if (parent != null)
                {
                    type = resourceProvider + "/" + ResourceTypeFromResourceId(parent) + "/" + type;
                }
                else
                {
                    type = resourceProvider + "/" + type;
                }
                apiVersions.TryGetValue(type, out string apiVersion);
                if (apiVersion == null)
                {
                    apiVersions.TryGetValue(resourceProvider, out apiVersion);
                }
                return apiVersion;
            }
            catch (Exception)
            {
                //Ignore here, send ARM API version to the service
                return null;
            }
        }

        public static string ApiVersionFromResourceProviderAndType(string resourceProvider, string resourceType)
        {
            if (resourceProvider == null)
            {
                return null;
            }
            if (apiVersions == null)
            {
                InitApiVersions();
            }
            string apiVersion = null;
            if (resourceType != null)
            {
                apiVersions.TryGetValue(resourceProvider + "/" + resourceType, out apiVersion);
            }
            if (apiVersion == null)
            {
                apiVersions.TryGetValue(resourceProvider, out apiVersion);
            }
            return apiVersion;
        }

        private static void InitApiVersions()
        {
            apiVersions = new Dictionary<string, string>
            {
                //AppService
                {"Microsoft.Web", "2019-08-01"},
                //Authorization in GraphRbac
                {"Microsoft.Authorization/roleDefinitions", "2018-01-01-preview"},
                {"Microsoft.Authorization/roleAssignments", "2018-09-01-preview"},
                //BatchAI
                {"Microsoft.BatchAI", "2018-05-01"},
                //Cdn
                {"Microsoft.Cdn", "2017-10-12"},
                //Compute
                {"Microsoft.Compute", "2019-07-01"},
                //ContainerInstance
                {"Microsoft.ContainerInstance", "2018-10-01"},
                //ContainerRegistry
                {"Microsoft.ContainerRegistry", "2017-10-01"},
                //ContainerService
                {"Microsoft.ContainerService", "2017-07-01"},
                //CosmosDB
                {"Microsoft.DocumentDB/privateEndpointConnections", "2019-08-01-preview"},
                {"Microsoft.DocumentDB/privateLinkResources", "2019-08-01-preview"},
                {"Microsoft.DocumentDB", "2019-08-01"},
                //DNS
                {"Microsoft.Network/dnsZones", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/A", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/AAAA", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/CAA", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/CNAME", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/MX", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/NS", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/PTR", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/SOA", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/SRV", "2018-03-01-preview"},
                {"Microsoft.Network/dnsZones/TXT", "2018-03-01-preview"},
                //EventHub
                {"Microsoft.EventHub", "2017-04-01"},
                //Features in ResourceManager
                {"Microsoft.Features", "2015-12-01"},
                //GraphRbac
                {"Microsoft.GraphRbac", "1.6"},
                //KeyVault
                {"Microsoft.KeyVault", "2018-02-14"},
                //Locks
                {"Microsoft.Authorization/locks", "2016-09-01"},
                //Monitor
                {"Microsoft.Insights/actionGroups", "2019-06-01"},
                {"Microsoft.Insights/activityLogAlerts", "2017-04-01"},
                {"Microsoft.Insights/alertrules", "2019-06-01"},
                {"Microsoft.Insights/autoscalesettings", "2015-04-01"},
                {"Microsoft.Insights/diagnosticSettings", "2017-05-01-preview"},
                {"Microsoft.Insights/diagnosticSettingsCategories", "2017-05-01-preview"},
                {"Microsoft.Insights/logprofiles", "2016-03-01"},
                {"Microsoft.Insights/metricAlerts", "2018-03-01"},
                {"Microsoft.Insights/scheduledQueryRules", "2018-04-16"},
                //Network
                {"Microsoft.Network", "2019-06-01"},
                //PrivateDNS
                {"Microsoft.Network/privateDnsZones", "2018-09-01"},
                {"Microsoft.Network/virtualNetworkLinks", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/A", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/AAAA", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/CNAME", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/MX", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/PTR", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/SOA", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/SRV", "2018-09-01"},
                {"Microsoft.Network/privateDnsZones/TXT", "2018-09-01"},
                //Policy in ResourceManager
                {"Microsoft.Authorization/policyAssignments", "2019-06-01"},
                {"Microsoft.Authorization/policyDefinitions", "2019-06-01"},
                {"Microsoft.Authorization/policySetDefinitions", "2019-06-01"},
                //Redis
                {"Microsoft.Cache", "2018-03-01"},
                //ResourceManager
                {"Microsoft.Resources", "2019-08-01"},
                //Search
                {"Microsoft.Search", "2015-08-19"},
                //ServiceBus
                {"Microsoft.ServiceBus", "2015-08-01"},
                //Storage
                {"Microsoft.Storage", "2018-11-01"},
                //Subscription in ResourceManager
                {"SUBSCRIPTIONS", "2019-06-01"},
                //TrafficManager
                {"Microsoft.Network/trafficManagerProfiles/externalEndpoints", "2018-04-01"},
                {"Microsoft.Network/trafficManagerGeographicHierarchies", "2018-04-01"},
                //MSI
                {"Microsoft.ManagedIdentity", "2018-11-30"}
            };
        }
    }
}
