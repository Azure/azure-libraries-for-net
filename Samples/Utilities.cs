// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
using Microsoft.Azure.Management.ContainerService.Fluent;
using Microsoft.Azure.Management.ContainerService.Fluent.Models;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Redis.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using Microsoft.Azure.Management.Dns.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using CoreFtp;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Renci.SshNet;
using Microsoft.Azure.Management.Search.Fluent;
using Microsoft.Azure.Management.Search.Fluent.Models;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Net.Http.Headers;
using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ContainerInstance.Fluent;
using Microsoft.Azure.Management.Locks.Fluent;
using Microsoft.Azure.Management.Msi.Fluent;
using Microsoft.Azure.Management.Eventhub.Fluent;
using Microsoft.Azure.Management.Monitor.Fluent;

namespace Microsoft.Azure.Management.Samples.Common
{
    public static class Utilities
    {
        public static bool IsRunningMocked { get; set; }
        public static Action<string> LoggerMethod { get; set; }
        public static Func<string> PauseMethod { get; set; }

        public static string ProjectPath { get; set; }

        static Utilities()
        {
            LoggerMethod = Console.WriteLine;
            PauseMethod = Console.ReadLine;
            ProjectPath = ".";
        }

        public static void Log(string message)
        {
            LoggerMethod.Invoke(message);
        }

        public static void Log(object obj)
        {
            if (obj != null)
            {
                LoggerMethod.Invoke(obj.ToString());
            }
            else
            {
                LoggerMethod.Invoke("(null)");
            }
        }

        public static void Log()
        {
            Utilities.Log("");
        }

        public static string ReadLine()
        {
            return PauseMethod.Invoke();
        }

        // Print resource group info.
        public static void PrintResourceGroup(IResourceGroup resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Resource Group: ").Append(resource.Id)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags.ToString());
            Log(info.ToString());
        }

        // Print UserAssigned MSI info.
        public static void PrintIdentity(IIdentity resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Identity: ").Append(resource.Id)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags.ToString())
                    .Append("\n\tService Principal Id: ").Append(resource.PrincipalId)
                    .Append("\n\tClient Id: ").Append(resource.ClientId)
                    .Append("\n\tTenant Id: ").Append(resource.TenantId)
                    .Append("\n\tClient Secret Url: ").Append(resource.ClientSecretUrl);
            Log(info.ToString());
        }

        // Print app gateway info
        public static void PrintAppGateway(IApplicationGateway resource)
        {
            var info = new StringBuilder();
            info.Append("App gateway: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags.ToString())
                    .Append("\n\tSKU: ").Append(resource.Sku.ToString())
                    .Append("\n\tOperational state: ").Append(resource.OperationalState)
                    .Append("\n\tInternet-facing? ").Append(resource.IsPublic)
                    .Append("\n\tInternal? ").Append(resource.IsPrivate)
                    .Append("\n\tDefault private IP address: ").Append(resource.PrivateIPAddress)
                    .Append("\n\tPrivate IP address allocation method: ").Append(resource.PrivateIPAllocationMethod)
                    .Append("\n\tDisabled SSL protocols: ").Append(resource.DisabledSslProtocols);

            // Show IP configs
            var ipConfigs = resource.IPConfigurations;
            info.Append("\n\tIP configurations: ").Append(ipConfigs.Count);
            foreach (var ipConfig in ipConfigs.Values)
            {
                info.Append("\n\t\tName: ").Append(ipConfig.Name)
                    .Append("\n\t\t\tNetwork id: ").Append(ipConfig.NetworkId)
                    .Append("\n\t\t\tSubnet name: ").Append(ipConfig.SubnetName);
            }

            // Show frontends
            var frontends = resource.Frontends;
            info.Append("\n\tFrontends: ").Append(frontends.Count);
            foreach (var frontend in frontends.Values)
            {
                info.Append("\n\t\tName: ").Append(frontend.Name)
                    .Append("\n\t\t\tPublic? ").Append(frontend.IsPublic);

                if (frontend.IsPublic)
                {
                    // Show public frontend info
                    info.Append("\n\t\t\tPublic IP address ID: ").Append(frontend.PublicIPAddressId);
                }

                if (frontend.IsPrivate)
                {
                    // Show private frontend info
                    info.Append("\n\t\t\tPrivate IP address: ").Append(frontend.PrivateIPAddress)
                        .Append("\n\t\t\tPrivate IP allocation method: ").Append(frontend.PrivateIPAllocationMethod)
                        .Append("\n\t\t\tSubnet name: ").Append(frontend.SubnetName)
                        .Append("\n\t\t\tVirtual network ID: ").Append(frontend.NetworkId);
                }
            }

            // Show backends
            var backends = resource.Backends;
            info.Append("\n\tBackends: ").Append(backends.Count);
            foreach (var backend in backends.Values)
            {
                info.Append("\n\t\tName: ").Append(backend.Name)
                    .Append("\n\t\t\tAssociated NIC IP configuration IDs: ").Append(string.Join(", ", backend.BackendNicIPConfigurationNames.Keys.ToArray()));

                // Show addresses
                var addresses = backend.Addresses;
                info.Append("\n\t\t\tAddresses: ").Append(addresses.Count);
                foreach (var address in addresses)
                {
                    info.Append("\n\t\t\t\tFQDN: ").Append(address.Fqdn)
                        .Append("\n\t\t\t\tIP: ").Append(address.IpAddress);
                }
            }

            // Show backend HTTP configurations
            var httpConfigs = resource.BackendHttpConfigurations;
            info.Append("\n\tHTTP Configurations: ").Append(httpConfigs.Count);
            foreach (var httpConfig in httpConfigs.Values)
            {
                info.Append("\n\t\tName: ").Append(httpConfig.Name)
                    .Append("\n\t\t\tCookie based affinity: ").Append(httpConfig.CookieBasedAffinity)
                    .Append("\n\t\t\tPort: ").Append(httpConfig.Port)
                    .Append("\n\t\t\tRequest timeout in seconds: ").Append(httpConfig.RequestTimeout)
                    .Append("\n\t\t\tProtocol: ").Append(httpConfig.Protocol.ToString())
                    .Append("\n\t\tHost header: ").Append(httpConfig.HostHeader)
                    .Append("\n\t\tHost header comes from backend? ").Append(httpConfig.IsHostHeaderFromBackend)
                    .Append("\n\t\tConnection draining timeout in seconds: ").Append(httpConfig.ConnectionDrainingTimeoutInSeconds)
                    .Append("\n\t\tAffinity cookie name: ").Append(httpConfig.AffinityCookieName)
                    .Append("\n\t\tPath: ").Append(httpConfig.Path);

                var probe = httpConfig.Probe;
                if (probe != null)
                {
                    info.Append("\n\t\tProbe: " + probe.Name);
                }
            }

            // Show SSL certificates
            var sslCerts = resource.SslCertificates;
            info.Append("\n\tSSL certificates: ").Append(sslCerts.Count);
            foreach (var cert in sslCerts.Values)
            {
                info.Append("\n\t\tName: ").Append(cert.Name)
                    .Append("\n\t\t\tCert data: ").Append(cert.PublicData);
            }

            // Show redirect configurations
            var redirects = resource.RedirectConfigurations;
            info.Append("\n\tRedirect configurations: ").Append(redirects.Count);
            foreach (IApplicationGatewayRedirectConfiguration redirect in redirects.Values)
            {
                info.Append("\n\t\tName: ").Append(redirect.Name)
                    .Append("\n\t\tTarget URL: ").Append(redirect.Type)
                    .Append("\n\t\tTarget URL: ").Append(redirect.TargetUrl)
                    .Append("\n\t\tTarget listener: ").Append(redirect.TargetListener?.Name)
                    .Append("\n\t\tIs path included? ").Append(redirect.IsPathIncluded)
                    .Append("\n\t\tIs query string included? ").Append(redirect.IsQueryStringIncluded)
                    .Append("\n\t\tReferencing request routing rules: ").Append(string.Join(", ", redirect.RequestRoutingRules.Keys.ToArray()));
            }

            // Show HTTP listeners
            var listeners = resource.Listeners;
            info.Append("\n\tHTTP listeners: ").Append(listeners.Count);
            foreach (var listener in listeners.Values)
            {
                info.Append("\n\t\tName: ").Append(listener.Name)
                    .Append("\n\t\t\tHost name: ").Append(listener.HostName)
                    .Append("\n\t\t\tServer name indication required? ").Append(listener.RequiresServerNameIndication)
                    .Append("\n\t\t\tAssociated frontend name: ").Append(listener.Frontend.Name)
                    .Append("\n\t\t\tFrontend port name: ").Append(listener.FrontendPortName)
                    .Append("\n\t\t\tFrontend port number: ").Append(listener.FrontendPortNumber)
                    .Append("\n\t\t\tProtocol: ").Append(listener.Protocol.ToString());
                if (listener.SslCertificate != null)
                {
                    info.Append("\n\t\t\tAssociated SSL certificate: ").Append(listener.SslCertificate.Name);
                }
            }

            // Show request routing rules
            var rules = resource.RequestRoutingRules;
            info.Append("\n\tRequest routing rules: ").Append(rules.Count);
            foreach (var rule in rules.Values)
            {
                info.Append("\n\t\tName: ").Append(rule.Name)
                    .Append("\n\t\t\tType: ").Append(rule.RuleType.ToString())
                    .Append("\n\t\t\tPublic IP address ID: ").Append(rule.PublicIPAddressId)
                    .Append("\n\t\t\tHost name: ").Append(rule.HostName)
                    .Append("\n\t\t\tServer name indication required? ").Append(rule.RequiresServerNameIndication)
                    .Append("\n\t\t\tFrontend port: ").Append(rule.FrontendPort)
                    .Append("\n\t\t\tFrontend protocol: ").Append(rule.FrontendProtocol.ToString())
                    .Append("\n\t\t\tBackend port: ").Append(rule.BackendPort)
                    .Append("\n\t\t\tCookie based affinity enabled? ").Append(rule.CookieBasedAffinity)
                    .Append("\n\t\tRedirect configuration: ").Append(rule.RedirectConfiguration?.Name ?? "(none)");

                // Show backend addresses
                var addresses = rule.BackendAddresses;
                info.Append("\n\t\t\tBackend addresses: ").Append(addresses.Count);
                foreach (var address in addresses)
                {
                    info.Append("\n\t\t\t\t")
                        .Append(address.Fqdn)
                        .Append(" [").Append(address.IpAddress).Append("]");
                }

                
                info
                    // Show SSL cert
                    .Append("\n\t\t\tSSL certificate name: ").Append(rule.SslCertificate?.Name ?? "(none)")

                    // Show backend
                    .Append("\n\t\t\tAssociated backend address pool: ").Append(rule.Backend?.Name ?? "(none)")

                    // Show backend HTTP settings config
                    .Append("\n\t\t\tAssociated backend HTTP settings configuration: ").Append(rule.BackendHttpConfiguration?.Name ?? "(none)")

                    // Show frontend listener
                    .Append("\n\t\t\tAssociated frontend listener: ").Append(rule.Listener?.Name ?? "(none)");
            }

            // Show probes  
            var probes = resource.Probes;
            info.Append("\n\tProbes: ").Append(probes.Count);
            foreach (var probe in probes.Values)
            {
                info.Append("\n\t\tName: ").Append(probe.Name)
                    .Append("\n\t\tProtocol:").Append(probe.Protocol.ToString())
                    .Append("\n\t\tInterval in seconds: ").Append(probe.TimeBetweenProbesInSeconds)
                    .Append("\n\t\tRetries: ").Append(probe.RetriesBeforeUnhealthy)
                    .Append("\n\t\tTimeout: ").Append(probe.TimeoutInSeconds)
                    .Append("\n\t\tHost: ").Append(probe.Host)
                    .Append("\n\t\tHealthy HTTP response status code ranges: ").Append(probe.HealthyHttpResponseStatusCodeRanges)
                    .Append("\n\t\tHealthy HTTP response body contents: ").Append(probe.HealthyHttpResponseBodyContents);
            }

            Utilities.Log(info.ToString());
        }

        public static void Print(ITopicAuthorizationRule topicAuthorizationRule)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Service bus topic authorization rule: ").Append(topicAuthorizationRule.Id)
                    .Append("\n\tName: ").Append(topicAuthorizationRule.Name)
                    .Append("\n\tResourceGroupName: ").Append(topicAuthorizationRule.ResourceGroupName)
                    .Append("\n\tNamespace Name: ").Append(topicAuthorizationRule.NamespaceName)
                    .Append("\n\tTopic Name: ").Append(topicAuthorizationRule.TopicName);

            var rights = topicAuthorizationRule.Rights;
            builder.Append("\n\tNumber of access rights in queue: ").Append(rights.Count);
            foreach (var right in rights)
            {
                builder.Append("\n\t\tAccessRight: ")
                        .Append("\n\t\t\tName :").Append(right.ToString());
            }

            Log(builder.ToString());
        }

        public static void Print(IDiagnosticSetting resource)
        {
            StringBuilder info = new StringBuilder("Diagnostic Setting: ")
                    .Append("\n\tId: ").Append(resource.Id)
                    .Append("\n\tAssociated resource Id: ").Append(resource.ResourceId)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tStorage Account Id: ").Append(resource.StorageAccountId)
                    .Append("\n\tEventHub Namespace Autorization Rule Id: ").Append(resource.EventHubAuthorizationRuleId)
                    .Append("\n\tEventHub name: ").Append(resource.EventHubName)
                    .Append("\n\tLog Analytics workspace Id: ").Append(resource.WorkspaceId);

            if (resource.Logs != null && resource.Logs.Any())
            {
                info.Append("\n\tLog Settings: ");
                foreach (var ls in resource.Logs)
                {
                    info.Append("\n\t\tCategory: ").Append(ls.Category);
                    info.Append("\n\t\tRetention policy: ");
                    if (ls.RetentionPolicy != null)
                    {
                        info.Append(ls.RetentionPolicy.Days + " days");
                    }
                    else
                    {
                        info.Append("NONE");
                    }
                }
            }
            if (resource.Metrics != null && resource.Metrics.Any())
            {
                info.Append("\n\tMetric Settings: ");
                foreach (var ls in resource.Metrics)
                {
                    info.Append("\n\t\tCategory: ").Append(ls.Category);
                    info.Append("\n\t\tTimegrain: ").Append(ls.TimeGrain);
                    info.Append("\n\t\tRetention policy: ");
                    if (ls.RetentionPolicy != null)
                    {
                        info.Append(ls.RetentionPolicy.Days + " days");
                    }
                    else
                    {
                        info.Append("NONE");
                    }
                }
            }
            Log(info.ToString());
        }

        public static void Print(ISearchService searchService)
        {
            var adminKeys = searchService.GetAdminKeys();
            var queryKeys = searchService.ListQueryKeys();

            StringBuilder builder = new StringBuilder()
                    .Append("Service bus subscription: ").Append(searchService.Id)
                    .Append("\n\tResource group: ").Append(searchService.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(searchService.Region)
                    .Append("\n\tSku: ").Append(searchService.Sku.Name)
                    .Append("\n\tStatus: ").Append(searchService.Status)
                    .Append("\n\tProvisioning State: ").Append(searchService.ProvisioningState)
                    .Append("\n\tHosting Mode: ").Append(searchService.HostingMode)
                    .Append("\n\tReplicas: ").Append(searchService.ReplicaCount)
                    .Append("\n\tPartitions: ").Append(searchService.PartitionCount)
                    .Append("\n\tPrimary Admin Key: ").Append(adminKeys.PrimaryKey)
                    .Append("\n\tSecondary Admin Key: ").Append(adminKeys.SecondaryKey)
                    .Append("\n\tQuery keys:");

            foreach (IQueryKey queryKey in queryKeys)
            {
                builder.Append("\n\t\tKey name: ").Append(queryKey.Name);
                builder.Append("\n\t\t   Value: ").Append(queryKey.Key);
            }

            Log(builder.ToString());
        }

        public static void Print(ServiceBus.Fluent.ISubscription serviceBusSubscription)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Service bus subscription: ").Append(serviceBusSubscription.Id)
                    .Append("\n\tName: ").Append(serviceBusSubscription.Name)
                    .Append("\n\tResourceGroupName: ").Append(serviceBusSubscription.ResourceGroupName)
                    .Append("\n\tCreatedAt: ").Append(serviceBusSubscription.CreatedAt)
                    .Append("\n\tUpdatedAt: ").Append(serviceBusSubscription.UpdatedAt)
                    .Append("\n\tAccessedAt: ").Append(serviceBusSubscription.AccessedAt)
                    .Append("\n\tActiveMessageCount: ").Append(serviceBusSubscription.ActiveMessageCount)
                    .Append("\n\tDeadLetterMessageCount: ").Append(serviceBusSubscription.DeadLetterMessageCount)
                    .Append("\n\tDefaultMessageTtlDuration: ").Append(serviceBusSubscription.DefaultMessageTtlDuration)
                    .Append("\n\tIsBatchedOperationsEnabled: ").Append(serviceBusSubscription.IsBatchedOperationsEnabled)
                    .Append("\n\tDeleteOnIdleDurationInMinutes: ").Append(serviceBusSubscription.DeleteOnIdleDurationInMinutes)
                    .Append("\n\tScheduledMessageCount: ").Append(serviceBusSubscription.ScheduledMessageCount)
                    .Append("\n\tStatus: ").Append(serviceBusSubscription.Status)
                    .Append("\n\tTransferMessageCount: ").Append(serviceBusSubscription.TransferMessageCount)
                    .Append("\n\tIsDeadLetteringEnabledForExpiredMessages: ").Append(serviceBusSubscription.IsDeadLetteringEnabledForExpiredMessages)
                    .Append("\n\tIsSessionEnabled: ").Append(serviceBusSubscription.IsSessionEnabled)
                    .Append("\n\tLockDurationInSeconds: ").Append(serviceBusSubscription.LockDurationInSeconds)
                    .Append("\n\tMaxDeliveryCountBeforeDeadLetteringMessage: ").Append(serviceBusSubscription.MaxDeliveryCountBeforeDeadLetteringMessage)
                    .Append("\n\tIsDeadLetteringEnabledForFilterEvaluationFailedMessages: ").Append(serviceBusSubscription.IsDeadLetteringEnabledForFilterEvaluationFailedMessages)
                    .Append("\n\tTransferMessageCount: ").Append(serviceBusSubscription.TransferMessageCount)
                    .Append("\n\tTransferDeadLetterMessageCount: ").Append(serviceBusSubscription.TransferDeadLetterMessageCount);

            Log(builder.ToString());
        }

        public static void Print(ITopic topic)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Service bus topic: ").Append(topic.Id)
                    .Append("\n\tName: ").Append(topic.Name)
                    .Append("\n\tResourceGroupName: ").Append(topic.ResourceGroupName)
                    .Append("\n\tCreatedAt: ").Append(topic.CreatedAt)
                    .Append("\n\tUpdatedAt: ").Append(topic.UpdatedAt)
                    .Append("\n\tAccessedAt: ").Append(topic.AccessedAt)
                    .Append("\n\tActiveMessageCount: ").Append(topic.ActiveMessageCount)
                    .Append("\n\tCurrentSizeInBytes: ").Append(topic.CurrentSizeInBytes)
                    .Append("\n\tDeadLetterMessageCount: ").Append(topic.DeadLetterMessageCount)
                    .Append("\n\tDefaultMessageTtlDuration: ").Append(topic.DefaultMessageTtlDuration)
                    .Append("\n\tDuplicateMessageDetectionHistoryDuration: ").Append(topic.DuplicateMessageDetectionHistoryDuration)
                    .Append("\n\tIsBatchedOperationsEnabled: ").Append(topic.IsBatchedOperationsEnabled)
                    .Append("\n\tIsDuplicateDetectionEnabled: ").Append(topic.IsDuplicateDetectionEnabled)
                    .Append("\n\tIsExpressEnabled: ").Append(topic.IsExpressEnabled)
                    .Append("\n\tIsPartitioningEnabled: ").Append(topic.IsPartitioningEnabled)
                    .Append("\n\tDeleteOnIdleDurationInMinutes: ").Append(topic.DeleteOnIdleDurationInMinutes)
                    .Append("\n\tMaxSizeInMB: ").Append(topic.MaxSizeInMB)
                    .Append("\n\tScheduledMessageCount: ").Append(topic.ScheduledMessageCount)
                    .Append("\n\tStatus: ").Append(topic.Status)
                    .Append("\n\tTransferMessageCount: ").Append(topic.TransferMessageCount)
                    .Append("\n\tSubscriptionCount: ").Append(topic.SubscriptionCount)
                    .Append("\n\tTransferDeadLetterMessageCount: ").Append(topic.TransferDeadLetterMessageCount);

            Log(builder.ToString());
        }

        public static void Print(IAuthorizationKeys keys)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Authorization keys: ")
                    .Append("\n\tPrimaryKey: ").Append(keys.PrimaryKey)
                    .Append("\n\tPrimaryConnectionString: ").Append(keys.PrimaryConnectionString)
                    .Append("\n\tSecondaryKey: ").Append(keys.SecondaryKey)
                    .Append("\n\tSecondaryConnectionString: ").Append(keys.SecondaryConnectionString);

            Log(builder.ToString());
        }

        public static void Print(INamespaceAuthorizationRule namespaceAuthorizationRule)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Service bus queue authorization rule: ").Append(namespaceAuthorizationRule.Id)
                    .Append("\n\tName: ").Append(namespaceAuthorizationRule.Name)
                    .Append("\n\tResourceGroupName: ").Append(namespaceAuthorizationRule.ResourceGroupName)
                    .Append("\n\tNamespace Name: ").Append(namespaceAuthorizationRule.NamespaceName);

            var rights = namespaceAuthorizationRule.Rights;
            builder.Append("\n\tNumber of access rights in queue: ").Append(rights.Count());
            foreach (var right in rights)
            {
                builder.Append("\n\t\tAccessRight: ")
                        .Append("\n\t\t\tName :").Append(right.ToString());
            }

            Log(builder.ToString());
        }

        public static void Print(IQueue queue)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Service bus Queue: ").Append(queue.Id)
                    .Append("\n\tName: ").Append(queue.Name)
                    .Append("\n\tResourceGroupName: ").Append(queue.ResourceGroupName)
                    .Append("\n\tCreatedAt: ").Append(queue.CreatedAt)
                    .Append("\n\tUpdatedAt: ").Append(queue.UpdatedAt)
                    .Append("\n\tAccessedAt: ").Append(queue.AccessedAt)
                    .Append("\n\tActiveMessageCount: ").Append(queue.ActiveMessageCount)
                    .Append("\n\tCurrentSizeInBytes: ").Append(queue.CurrentSizeInBytes)
                    .Append("\n\tDeadLetterMessageCount: ").Append(queue.DeadLetterMessageCount)
                    .Append("\n\tDefaultMessageTtlDuration: ").Append(queue.DefaultMessageTtlDuration)
                    .Append("\n\tDuplicateMessageDetectionHistoryDuration: ").Append(queue.DuplicateMessageDetectionHistoryDuration)
                    .Append("\n\tIsBatchedOperationsEnabled: ").Append(queue.IsBatchedOperationsEnabled)
                    .Append("\n\tIsDeadLetteringEnabledForExpiredMessages: ").Append(queue.IsDeadLetteringEnabledForExpiredMessages)
                    .Append("\n\tIsDuplicateDetectionEnabled: ").Append(queue.IsDuplicateDetectionEnabled)
                    .Append("\n\tIsExpressEnabled: ").Append(queue.IsExpressEnabled)
                    .Append("\n\tIsPartitioningEnabled: ").Append(queue.IsPartitioningEnabled)
                    .Append("\n\tIsSessionEnabled: ").Append(queue.IsSessionEnabled)
                    .Append("\n\tDeleteOnIdleDurationInMinutes: ").Append(queue.DeleteOnIdleDurationInMinutes)
                    .Append("\n\tMaxDeliveryCountBeforeDeadLetteringMessage: ").Append(queue.MaxDeliveryCountBeforeDeadLetteringMessage)
                    .Append("\n\tMaxSizeInMB: ").Append(queue.MaxSizeInMB)
                    .Append("\n\tMessageCount: ").Append(queue.MessageCount)
                    .Append("\n\tScheduledMessageCount: ").Append(queue.ScheduledMessageCount)
                    .Append("\n\tStatus: ").Append(queue.Status)
                    .Append("\n\tTransferMessageCount: ").Append(queue.TransferMessageCount)
                    .Append("\n\tLockDurationInSeconds: ").Append(queue.LockDurationInSeconds)
                    .Append("\n\tTransferDeadLetterMessageCount: ").Append(queue.TransferDeadLetterMessageCount);

            Utilities.Log(builder.ToString());
        }

        public static void Print(IManagementLock l)
        {
            StringBuilder info = new StringBuilder();
            info.Append("\nLock ID: ").Append(l.Id)
            .Append("\nLocked resource ID: ").Append(l.LockedResourceId)
            .Append("\nLevel: ").Append(l.Level);
            Utilities.Log(info.ToString());
        }

        public static void Print(IServiceBusNamespace serviceBusNamespace)
        {
            var builder = new StringBuilder()
                    .Append("Service bus Namespace: ").Append(serviceBusNamespace.Id)
                    .Append("\n\tName: ").Append(serviceBusNamespace.Name)
                    .Append("\n\tRegion: ").Append(serviceBusNamespace.RegionName)
                    .Append("\n\tResourceGroupName: ").Append(serviceBusNamespace.ResourceGroupName)
                    .Append("\n\tCreatedAt: ").Append(serviceBusNamespace.CreatedAt)
                    .Append("\n\tUpdatedAt: ").Append(serviceBusNamespace.UpdatedAt)
                    .Append("\n\tDnsLabel: ").Append(serviceBusNamespace.DnsLabel)
                    .Append("\n\tFQDN: ").Append(serviceBusNamespace.Fqdn)
                    .Append("\n\tSku: ")
                    .Append("\n\t\tCapacity: ").Append(serviceBusNamespace.Sku.Capacity)
                    .Append("\n\t\tSkuName: ").Append(serviceBusNamespace.Sku.Name)
                    .Append("\n\t\tTier: ").Append(serviceBusNamespace.Sku.Tier);

            Utilities.Log(builder.ToString());
        }

        public static void PrintVirtualMachineCustomImage(IVirtualMachineCustomImage image)
        {
            var builder = new StringBuilder().Append("Virtual machine custom image: ").Append(image.Id)
            .Append("Name: ").Append(image.Name)
            .Append("\n\tResource group: ").Append(image.ResourceGroupName)
            .Append("\n\tCreated from virtual machine: ").Append(image.SourceVirtualMachineId);

            builder.Append("\n\tOS disk image: ")
                    .Append("\n\t\tOperating system: ").Append(image.OSDiskImage.OsType)
                    .Append("\n\t\tOperating system state: ").Append(image.OSDiskImage.OsState)
                    .Append("\n\t\tCaching: ").Append(image.OSDiskImage.Caching)
                    .Append("\n\t\tSize (GB): ").Append(image.OSDiskImage.DiskSizeGB);
            if (image.IsCreatedFromVirtualMachine)
            {
                builder.Append("\n\t\tSource virtual machine: ").Append(image.SourceVirtualMachineId);
            }
            if (image.OSDiskImage.ManagedDisk != null)
            {
                builder.Append("\n\t\tSource managed disk: ").Append(image.OSDiskImage.ManagedDisk.Id);
            }
            if (image.OSDiskImage.Snapshot != null)
            {
                builder.Append("\n\t\tSource snapshot: ").Append(image.OSDiskImage.Snapshot.Id);
            }
            if (image.OSDiskImage.BlobUri != null)
            {
                builder.Append("\n\t\tSource un-managed vhd: ").Append(image.OSDiskImage.BlobUri);
            }
            if (image.DataDiskImages != null)
            {
                foreach (var diskImage in image.DataDiskImages.Values)
                {
                    builder.Append("\n\tDisk Image (Lun) #: ").Append(diskImage.Lun)
                            .Append("\n\t\tCaching: ").Append(diskImage.Caching)
                            .Append("\n\t\tSize (GB): ").Append(diskImage.DiskSizeGB);
                    if (image.IsCreatedFromVirtualMachine)
                    {
                        builder.Append("\n\t\tSource virtual machine: ").Append(image.SourceVirtualMachineId);
                    }
                    if (diskImage.ManagedDisk != null)
                    {
                        builder.Append("\n\t\tSource managed disk: ").Append(diskImage.ManagedDisk.Id);
                    }
                    if (diskImage.Snapshot != null)
                    {
                        builder.Append("\n\t\tSource snapshot: ").Append(diskImage.Snapshot.Id);
                    }
                    if (diskImage.BlobUri != null)
                    {
                        builder.Append("\n\t\tSource un-managed vhd: ").Append(diskImage.BlobUri);
                    }
                }
            }
            Log(builder.ToString());
        }

        public static void PrintVirtualMachine(IVirtualMachine virtualMachine)
        {
            var storageProfile = new StringBuilder().Append("\n\tStorageProfile: ");
            if (virtualMachine.StorageProfile.ImageReference != null)
            {
                storageProfile.Append("\n\t\tImageReference:");
                storageProfile.Append("\n\t\t\tPublisher: ").Append(virtualMachine.StorageProfile.ImageReference.Publisher);
                storageProfile.Append("\n\t\t\tOffer: ").Append(virtualMachine.StorageProfile.ImageReference.Offer);
                storageProfile.Append("\n\t\t\tSKU: ").Append(virtualMachine.StorageProfile.ImageReference.Sku);
                storageProfile.Append("\n\t\t\tVersion: ").Append(virtualMachine.StorageProfile.ImageReference.Version);
            }

            if (virtualMachine.StorageProfile.OsDisk != null)
            {
                storageProfile.Append("\n\t\tOSDisk:");
                storageProfile.Append("\n\t\t\tOSType: ").Append(virtualMachine.StorageProfile.OsDisk.OsType);
                storageProfile.Append("\n\t\t\tName: ").Append(virtualMachine.StorageProfile.OsDisk.Name);
                storageProfile.Append("\n\t\t\tCaching: ").Append(virtualMachine.StorageProfile.OsDisk.Caching);
                storageProfile.Append("\n\t\t\tCreateOption: ").Append(virtualMachine.StorageProfile.OsDisk.CreateOption);
                storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(virtualMachine.StorageProfile.OsDisk.DiskSizeGB);
                if (virtualMachine.StorageProfile.OsDisk.Image != null)
                {
                    storageProfile.Append("\n\t\t\tImage Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Image.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.Vhd != null)
                {
                    storageProfile.Append("\n\t\t\tVhd Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Vhd.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.EncryptionSettings != null)
                {
                    storageProfile.Append("\n\t\t\tEncryptionSettings: ");
                    storageProfile.Append("\n\t\t\t\tEnabled: ").Append(virtualMachine.StorageProfile.OsDisk.EncryptionSettings.Enabled);
                    storageProfile.Append("\n\t\t\t\tDiskEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .DiskEncryptionKey.SecretUrl);
                    storageProfile.Append("\n\t\t\t\tKeyEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .KeyEncryptionKey.KeyUrl);
                }
            }

            if (virtualMachine.StorageProfile.DataDisks != null)
            {
                var i = 0;
                foreach (var disk in virtualMachine.StorageProfile.DataDisks)
                {
                    storageProfile.Append("\n\t\tDataDisk: #").Append(i++);
                    storageProfile.Append("\n\t\t\tName: ").Append(disk.Name);
                    storageProfile.Append("\n\t\t\tCaching: ").Append(disk.Caching);
                    storageProfile.Append("\n\t\t\tCreateOption: ").Append(disk.CreateOption);
                    storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(disk.DiskSizeGB);
                    storageProfile.Append("\n\t\t\tLun: ").Append(disk.Lun);
                    if (virtualMachine.IsManagedDiskEnabled)
                    {
                        if (disk.ManagedDisk != null)
                        {
                            storageProfile.Append("\n\t\t\tManaged Disk Id: ").Append(disk.ManagedDisk.Id);
                        }
                    }
                    else
                    {
                        if (disk.Vhd.Uri != null)
                        {
                            storageProfile.Append("\n\t\t\tVhd Uri: ").Append(disk.Vhd.Uri);
                        }
                    }
                    if (disk.Image != null)
                    {
                        storageProfile.Append("\n\t\t\tImage Uri: ").Append(disk.Image.Uri);
                    }
                }
            }
            StringBuilder osProfile;
            if (virtualMachine.OSProfile != null)
            {
                osProfile = new StringBuilder().Append("\n\tOSProfile: ");

                osProfile.Append("\n\t\tComputerName:").Append(virtualMachine.OSProfile.ComputerName);
                if (virtualMachine.OSProfile.WindowsConfiguration != null)
                {
                    osProfile.Append("\n\t\t\tWindowsConfiguration: ");
                    osProfile.Append("\n\t\t\t\tProvisionVMAgent: ")
                            .Append(virtualMachine.OSProfile.WindowsConfiguration.ProvisionVMAgent);
                    osProfile.Append("\n\t\t\t\tEnableAutomaticUpdates: ")
                            .Append(virtualMachine.OSProfile.WindowsConfiguration.EnableAutomaticUpdates);
                    osProfile.Append("\n\t\t\t\tTimeZone: ")
                            .Append(virtualMachine.OSProfile.WindowsConfiguration.TimeZone);
                }
                if (virtualMachine.OSProfile.LinuxConfiguration != null)
                {
                    osProfile.Append("\n\t\t\tLinuxConfiguration: ");
                    osProfile.Append("\n\t\t\t\tDisablePasswordAuthentication: ")
                            .Append(virtualMachine.OSProfile.LinuxConfiguration.DisablePasswordAuthentication);
                }
            }
            else
            {
                osProfile = new StringBuilder().Append("\n\tOSProfile: null");
            }


            var networkProfile = new StringBuilder().Append("\n\tNetworkProfile: ");
            foreach (var networkInterfaceId in virtualMachine.NetworkInterfaceIds)
            {
                networkProfile.Append("\n\t\tId:").Append(networkInterfaceId);
            }

            var msi = new StringBuilder().Append("\n\tMSI: ");
            msi.Append("\n\t\tMSI enabled:").Append(virtualMachine.IsManagedServiceIdentityEnabled);
            msi.Append("\n\t\tMSI Active Directory Service Principal Id:").Append(virtualMachine.SystemAssignedManagedServiceIdentityPrincipalId);
            msi.Append("\n\t\tMSI Active Directory Tenant Id:").Append(virtualMachine.SystemAssignedManagedServiceIdentityTenantId);

            Utilities.Log(new StringBuilder().Append("Virtual Machine: ").Append(virtualMachine.Id)
                    .Append("Name: ").Append(virtualMachine.Name)
                    .Append("\n\tResource group: ").Append(virtualMachine.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(virtualMachine.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(virtualMachine.Tags))
                    .Append("\n\tHardwareProfile: ")
                    .Append("\n\t\tSize: ").Append(virtualMachine.Size)
                    .Append(storageProfile)
                    .Append(osProfile)
                    .Append(networkProfile)
                    .Append(msi)
                    .ToString());
        }

        public static void PrintStorageAccountKeys(IReadOnlyList<StorageAccountKey> storageAccountKeys)
        {
            foreach (var storageAccountKey in storageAccountKeys)
            {
                Utilities.Log($"Key {storageAccountKey.KeyName} = {storageAccountKey.Value}");
            }
        }

        public static void PrintStorageAccount(IStorageAccount storageAccount)
        {
            Utilities.Log($"{storageAccount.Name} created @ {storageAccount.CreationTime}");
        }

        public static string CreateRandomName(string namePrefix)
        {
            return SdkContext.RandomResourceName(namePrefix, 30);
        }

        public static void PrintAvailabilitySet(IAvailabilitySet resource)
        {
            Utilities.Log(new StringBuilder().Append("Availability Set: ").Append(resource.Id)
                .Append("Name: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.Region)
                .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags))
                .Append("\n\tFault domain count: ").Append(resource.FaultDomainCount)
                .Append("\n\tUpdate domain count: ").Append(resource.UpdateDomainCount)
                .ToString());
        }

        public static void PrintBatchAccount(IBatchAccount batchAccount)
        {
            var applicationsOutput = new StringBuilder().Append("\n\tapplications: ");

            if (batchAccount.Applications.Count > 0)
            {
                foreach (var applicationEntry in batchAccount.Applications)
                {
                    var application = applicationEntry.Value;
                    var applicationPackages = new StringBuilder().Append("\n\t\t\tapplicationPackages : ");

                    foreach (var applicationPackageEntry in application.ApplicationPackages)
                    {
                        var applicationPackage = applicationPackageEntry.Value;
                        var singleApplicationPackage = new StringBuilder().Append("\n\t\t\t\tapplicationPackage : " + applicationPackage.Name);
                        singleApplicationPackage.Append("\n\t\t\t\tapplicationPackageState : " + applicationPackage.State);

                        applicationPackages.Append(singleApplicationPackage);
                        singleApplicationPackage.Append("\n");
                    }

                    var singleApplication = new StringBuilder().Append("\n\t\tapplication: " + application.Name);
                    singleApplication.Append("\n\t\tdisplayName: " + application.DisplayName);
                    singleApplication.Append("\n\t\tdefaultVersion: " + application.DefaultVersion);
                    singleApplication.Append(applicationPackages);
                    applicationsOutput.Append(singleApplication);
                    applicationsOutput.Append("\n");
                }
            }

            Utilities.Log(new StringBuilder().Append("BatchAccount: ").Append(batchAccount.Id)
                    .Append("Name: ").Append(batchAccount.Name)
                    .Append("\n\tResource group: ").Append(batchAccount.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(batchAccount.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(batchAccount.Tags))
                    .Append("\n\tAccountEndpoint: ").Append(batchAccount.AccountEndpoint)
                    .Append("\n\tPoolQuota: ").Append(batchAccount.PoolQuota)
                    .Append("\n\tActiveJobAndJobScheduleQuota: ").Append(batchAccount.ActiveJobAndJobScheduleQuota)
                    .Append("\n\tStorageAccount: ").Append(batchAccount.AutoStorage == null ? "No storage account attached" : batchAccount.AutoStorage.StorageAccountId)
                    .Append(applicationsOutput)
                    .ToString());
        }

        public static void PrintBatchAccountKey(BatchAccountKeys batchAccountKeys)
        {
            Utilities.Log("Primary Key (" + batchAccountKeys.Primary + ") Secondary key = ("
                    + batchAccountKeys.Secondary + ")");
        }

        public static void PrintNetworkSecurityGroup(INetworkSecurityGroup resource)
        {
            var nsgOutput = new StringBuilder();
            nsgOutput.Append("NSG: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.RegionName)
                    .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags));

            // Output security rules
            foreach (var rule in resource.SecurityRules.Values)
            {
                nsgOutput.Append("\n\tRule: ").Append(rule.Name)
                        .Append("\n\t\tAccess: ").Append(rule.Access)
                        .Append("\n\t\tDirection: ").Append(rule.Direction)
                        .Append("\n\t\tFrom address: ").Append(rule.SourceAddressPrefix)
                        .Append("\n\t\tFrom port range: ").Append(rule.SourcePortRange)
                        .Append("\n\t\tTo address: ").Append(rule.DestinationAddressPrefix)
                        .Append("\n\t\tTo port: ").Append(rule.DestinationPortRange)
                        .Append("\n\t\tProtocol: ").Append(rule.Protocol)
                        .Append("\n\t\tPriority: ").Append(rule.Priority);
            }
            Utilities.Log(nsgOutput.ToString());
        }

        public static void PrintVirtualNetwork(INetwork network)
        {
            var info = new StringBuilder();
            info.Append("Network: ").Append(network.Id)
                    .Append("Name: ").Append(network.Name)
                    .Append("\n\tResource group: ").Append(network.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(network.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(network.Tags))
                    .Append("\n\tAddress spaces: ").Append(FormatCollection(network.AddressSpaces))
                    .Append("\n\tDNS server IPs: ").Append(FormatCollection(network.DnsServerIPs));

            // Output subnets
            foreach (var subnet in network.Subnets.Values)
            {
                info.Append("\n\tSubnet: ").Append(subnet.Name)
                        .Append("\n\t\tAddress prefix: ").Append(subnet.AddressPrefix);

                // Output associated NSG
                var subnetNsg = subnet.GetNetworkSecurityGroup();
                if (subnetNsg != null)
                {
                    info.Append("\n\t\tNetwork security group: ").Append(subnetNsg.Id);
                }

                // Output associated route table
                var routeTable = subnet.GetRouteTable();
                if (routeTable != null)
                {
                    info.Append("\n\tRoute table ID: ").Append(routeTable.Id);
                }
            }

            // Output peerings
            foreach (var peering in network.Peerings.List())
            {
                info.Append("\n\tPeering: ").Append(peering.Name)
                    .Append("\n\t\tRemote network ID: ").Append(peering.RemoteNetworkId)
                    .Append("\n\t\tPeering state: ").Append(peering.State)
                    .Append("\n\t\tIs traffic forwarded from remote network allowed? ").Append(peering.IsTrafficForwardingFromRemoteNetworkAllowed)
                    .Append("\n\t\tGateway use: ").Append(peering.GatewayUse);
            }

            Utilities.Log(info.ToString());
        }

        public static void PrintIPAddress(IPublicIPAddress publicIPAddress)
        {
            Utilities.Log(new StringBuilder().Append("Public IP Address: ").Append(publicIPAddress.Id)
                .Append("Name: ").Append(publicIPAddress.Name)
                .Append("\n\tResource group: ").Append(publicIPAddress.ResourceGroupName)
                .Append("\n\tRegion: ").Append(publicIPAddress.Region)
                .Append("\n\tTags: ").Append(FormatDictionary(publicIPAddress.Tags))
                .Append("\n\tIP Address: ").Append(publicIPAddress.IPAddress)
                .Append("\n\tLeaf domain label: ").Append(publicIPAddress.LeafDomainLabel)
                .Append("\n\tFQDN: ").Append(publicIPAddress.Fqdn)
                .Append("\n\tReverse FQDN: ").Append(publicIPAddress.ReverseFqdn)
                .Append("\n\tIdle timeout (minutes): ").Append(publicIPAddress.IdleTimeoutInMinutes)
                .Append("\n\tIP allocation method: ").Append(publicIPAddress.IPAllocationMethod)
                .ToString());
        }

        public static void PrintNetworkInterface(INetworkInterface resource)
        {
            var info = new StringBuilder();
            info.Append("NetworkInterface: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags))
                    .Append("\n\tInternal DNS name label: ").Append(resource.InternalDnsNameLabel)
                    .Append("\n\tInternal FQDN: ").Append(resource.InternalFqdn)
                    .Append("\n\tInternal domain name suffix: ").Append(resource.InternalDomainNameSuffix)
                    .Append("\n\tNetwork security group: ").Append(resource.NetworkSecurityGroupId)
                    .Append("\n\tApplied DNS servers: ").Append(FormatCollection(resource.AppliedDnsServers))
                    .Append("\n\tDNS server IPs: ");

            // Output dns servers
            foreach (var dnsServerIp in resource.DnsServers)
            {
                info.Append("\n\t\t").Append(dnsServerIp);
            }

            info.Append("\n\t IP forwarding enabled: ").Append(resource.IsIPForwardingEnabled)
                    .Append("\n\tAccelerated networking enabled: ").Append(resource.IsAcceleratedNetworkingEnabled)
                    .Append("\n\tMAC Address:").Append(resource.MacAddress)
                    .Append("\n\tPrivate IP:").Append(resource.PrimaryPrivateIP)
                    .Append("\n\tPrivate allocation method:").Append(resource.PrimaryPrivateIPAllocationMethod)
                    .Append("\n\tPrimary virtual network ID: ").Append(resource.PrimaryIPConfiguration.NetworkId)
                    .Append("\n\tPrimary subnet name:").Append(resource.PrimaryIPConfiguration.SubnetName);

            Utilities.Log(info.ToString());
        }

        public static void PrintLoadBalancer(ILoadBalancer loadBalancer)
        {
            var info = new StringBuilder();
            info.Append("Load balancer: ").Append(loadBalancer.Id)
                    .Append("Name: ").Append(loadBalancer.Name)
                    .Append("\n\tResource group: ").Append(loadBalancer.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(loadBalancer.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(loadBalancer.Tags))
                    .Append("\n\tBackends: ").Append(FormatCollection(loadBalancer.Backends.Keys));

            // Show public IP addresses
            info.Append("\n\tPublic IP address IDs: ")
                    .Append(loadBalancer.PublicIPAddressIds.Count);
            foreach (var pipId in loadBalancer.PublicIPAddressIds)
            {
                info.Append("\n\t\tPIP id: ").Append(pipId);
            }

            // Show TCP probes
            info.Append("\n\tTCP probes: ")
                    .Append(loadBalancer.TcpProbes.Count);
            foreach (var probe in loadBalancer.TcpProbes.Values)
            {
                info.Append("\n\t\tProbe name: ").Append(probe.Name)
                        .Append("\n\t\t\tPort: ").Append(probe.Port)
                        .Append("\n\t\t\tInterval in seconds: ").Append(probe.IntervalInSeconds)
                        .Append("\n\t\t\tRetries before unhealthy: ").Append(probe.NumberOfProbes);

                // Show associated load balancing rules
                info.Append("\n\t\t\tReferenced from load balancing rules: ")
                        .Append(probe.LoadBalancingRules.Count);
                foreach (var rule in probe.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show HTTP probes
            info.Append("\n\tHTTP probes: ")
                    .Append(loadBalancer.HttpProbes.Count);
            foreach (var probe in loadBalancer.HttpProbes.Values)
            {
                info.Append("\n\t\tProbe name: ").Append(probe.Name)
                        .Append("\n\t\t\tPort: ").Append(probe.Port)
                        .Append("\n\t\t\tInterval in seconds: ").Append(probe.IntervalInSeconds)
                        .Append("\n\t\t\tRetries before unhealthy: ").Append(probe.NumberOfProbes)
                        .Append("\n\t\t\tHTTP request path: ").Append(probe.RequestPath);

                // Show associated load balancing rules
                info.Append("\n\t\t\tReferenced from load balancing rules: ")
                        .Append(probe.LoadBalancingRules.Count);
                foreach (var rule in probe.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show load balancing rules
            info.Append("\n\tLoad balancing rules: ")
                    .Append(loadBalancer.LoadBalancingRules.Count);
            foreach (var rule in loadBalancer.LoadBalancingRules.Values)
            {
                info.Append("\n\t\tLB rule name: ").Append(rule.Name)
                        .Append("\n\t\t\tProtocol: ").Append(rule.Protocol)
                        .Append("\n\t\t\tFloating IP enabled? ").Append(rule.FloatingIPEnabled)
                        .Append("\n\t\t\tIdle timeout in minutes: ").Append(rule.IdleTimeoutInMinutes)
                        .Append("\n\t\t\tLoad distribution method: ").Append(rule.LoadDistribution);

                var frontend = rule.Frontend;
                info.Append("\n\t\t\tFrontend: ");
                if (frontend != null)
                {
                    info.Append(frontend.Name);
                }
                else
                {
                    info.Append("(None)");
                }

                info.Append("\n\t\t\tFrontend port: ").Append(rule.FrontendPort);

                var backend = rule.Backend;
                info.Append("\n\t\t\tBackend: ");
                if (backend != null)
                {
                    info.Append(backend.Name);
                }
                else
                {
                    info.Append("(None)");
                }

                info.Append("\n\t\t\tBackend port: ").Append(rule.BackendPort);

                var probe = rule.Probe;
                info.Append("\n\t\t\tProbe: ");
                if (probe == null)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(probe.Name).Append(" [").Append(probe.Protocol.ToString()).Append("]");
                }
            }

            // Show frontends
            info.Append("\n\tFrontends: ")
                    .Append(loadBalancer.Frontends.Count);
            foreach (var frontend in loadBalancer.Frontends.Values)
            {
                info.Append("\n\t\tFrontend name: ").Append(frontend.Name)
                        .Append("\n\t\t\tInternet facing: ").Append(frontend.IsPublic);
                if (frontend.IsPublic)
                {
                    info.Append("\n\t\t\tPublic IP Address ID: ").Append(((ILoadBalancerPublicFrontend)frontend).PublicIPAddressId);
                }
                else
                {
                    info.Append("\n\t\t\tVirtual network ID: ").Append(((ILoadBalancerPrivateFrontend)frontend).NetworkId)
                            .Append("\n\t\t\tSubnet name: ").Append(((ILoadBalancerPrivateFrontend)frontend).SubnetName)
                            .Append("\n\t\t\tPrivate IP address: ").Append(((ILoadBalancerPrivateFrontend)frontend).PrivateIPAddress)
                            .Append("\n\t\t\tPrivate IP allocation method: ").Append(((ILoadBalancerPrivateFrontend)frontend).PrivateIPAllocationMethod);
                }

                // Inbound NAT pool references
                info.Append("\n\t\t\tReferenced inbound NAT pools: ")
                        .Append(frontend.InboundNatPools.Count);
                foreach (var pool in frontend.InboundNatPools.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(pool.Name);
                }

                // Inbound NAT rule references
                info.Append("\n\t\t\tReferenced inbound NAT rules: ")
                        .Append(frontend.InboundNatRules.Count);
                foreach (var rule in frontend.InboundNatRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }

                // Load balancing rule references
                info.Append("\n\t\t\tReferenced load balancing rules: ")
                        .Append(frontend.LoadBalancingRules.Count);
                foreach (var rule in frontend.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show inbound NAT rules
            info.Append("\n\tInbound NAT rules: ")
                    .Append(loadBalancer.InboundNatRules.Count);
            foreach (var natRule in loadBalancer.InboundNatRules.Values)
            {
                info.Append("\n\t\tInbound NAT rule name: ").Append(natRule.Name)
                        .Append("\n\t\t\tProtocol: ").Append(natRule.Protocol.ToString())
                        .Append("\n\t\t\tFrontend: ").Append(natRule.Frontend.Name)
                        .Append("\n\t\t\tFrontend port: ").Append(natRule.FrontendPort)
                        .Append("\n\t\t\tBackend port: ").Append(natRule.BackendPort)
                        .Append("\n\t\t\tBackend NIC ID: ").Append(natRule.BackendNetworkInterfaceId)
                        .Append("\n\t\t\tBackend NIC IP config name: ").Append(natRule.BackendNicIPConfigurationName)
                        .Append("\n\t\t\tFloating IP? ").Append(natRule.FloatingIPEnabled)
                        .Append("\n\t\t\tIdle timeout in minutes: ").Append(natRule.IdleTimeoutInMinutes);
            }

            // Show inbound NAT pools
            info.Append("\n\tInbound NAT pools: ")
                    .Append(loadBalancer.InboundNatPools.Count);
            foreach (var natPool in loadBalancer.InboundNatPools.Values)
            {
                info.Append("\n\t\tInbound NAT pool name: ").Append(natPool.Name)
                        .Append("\n\t\t\tProtocol: ").Append(natPool.Protocol.ToString())
                        .Append("\n\t\t\tFrontend: ").Append(natPool.Frontend.Name)
                        .Append("\n\t\t\tFrontend port range: ")
                        .Append(natPool.FrontendPortRangeStart)
                        .Append("-")
                        .Append(natPool.FrontendPortRangeEnd)
                        .Append("\n\t\t\tBackend port: ").Append(natPool.BackendPort);
            }

            // Show backends
            info.Append("\n\tBackends: ")
                    .Append(loadBalancer.Backends.Count);
            foreach (var backend in loadBalancer.Backends.Values)
            {
                info.Append("\n\t\tBackend name: ").Append(backend.Name);

                // Show assigned backend NICs
                info.Append("\n\t\t\tReferenced NICs: ")
                        .Append(backend.BackendNicIPConfigurationNames.Count);
                foreach (var entry in backend.BackendNicIPConfigurationNames)
                {
                    info.Append("\n\t\t\t\tNIC ID: ").Append(entry.Key)
                            .Append(" - IP Config: ").Append(entry.Value);
                }

                // Show assigned virtual machines
                var vmIds = backend.GetVirtualMachineIds();
                info.Append("\n\t\t\tReferenced virtual machine ids: ")
                        .Append(vmIds.Count);
                foreach (string vmId in vmIds)
                {
                    info.Append("\n\t\t\t\tVM ID: ").Append(vmId);
                }

                // Show assigned load balancing rules
                info.Append("\n\t\t\tReferenced load balancing rules: ")
                        .Append(FormatCollection(backend.LoadBalancingRules.Keys));
            }

            Utilities.Log(info.ToString());
        }

        public static void PrintVault(IVault vault)
        {
            var info = new StringBuilder().Append("Key Vault: ").Append(vault.Id)
                .Append("Name: ").Append(vault.Name)
                .Append("\n\tResource group: ").Append(vault.ResourceGroupName)
                .Append("\n\tRegion: ").Append(vault.Region)
                .Append("\n\tSku: ").Append(vault.Sku.Name).Append(" - ").Append(KeyVault.Fluent.Models.Sku.Family)
                .Append("\n\tVault URI: ").Append(vault.VaultUri)
                .Append("\n\tAccess policies: ");
            foreach (var accessPolicy in vault.AccessPolicies)
            {
                info.Append("\n\t\tIdentity:").Append(accessPolicy.ObjectId)
                        .Append("\n\t\tKey permissions: ").Append(FormatCollection(accessPolicy.Permissions.Keys))
                        .Append("\n\t\tSecret permissions: ").Append(FormatCollection(accessPolicy.Permissions.Secrets));
            }

            Utilities.Log(info.ToString());
        }

        public static void PrintRedisCache(IRedisCache redisCache)
        {
            var redisInfo = new StringBuilder();
            redisInfo.Append("Redis Cache Name: ").AppendLine(redisCache.Name)
                     .Append("\tResource group: ").AppendLine(redisCache.ResourceGroupName)
                     .Append("\tRegion: ").AppendLine(redisCache.Region.ToString())
                     .Append("\tSKU Name: ").AppendLine(redisCache.Sku.Name)
                     .Append("\tSKU Family: ").AppendLine(redisCache.Sku.Family)
                     .Append("\tHost name: ").AppendLine(redisCache.HostName)
                     .Append("\tSSL port: ").AppendLine(redisCache.SslPort.ToString())
                     .Append("\tNon-SSL port (6379) enabled: ").AppendLine(redisCache.NonSslPort.ToString());
            if (redisCache.RedisConfiguration != null && redisCache.RedisConfiguration.Count > 0)
            {
                redisInfo.AppendLine("\tRedis Configuration:");
                foreach (KeyValuePair<string, string> rc in redisCache.RedisConfiguration)
                {
                    redisInfo.Append("\t  '").Append(rc.Key)
                             .Append("' : '").Append(rc.Value).AppendLine("'");
                }
            }
            if (redisCache.IsPremium)
            {
                var premium = redisCache.AsPremium();
                var scheduleEntries = premium.ListPatchSchedules();
                if (scheduleEntries != null && scheduleEntries.Any())
                {
                    redisInfo.AppendLine("\tRedis Patch Schedule:");
                    foreach (var schedule in scheduleEntries)
                    {
                        redisInfo.Append("\t\tDay: '").Append(schedule.DayOfWeek)
                                .Append("', start at: '").Append(schedule.StartHourUtc)
                                .Append("', maintenance window: '").Append(schedule.MaintenanceWindow)
                                .AppendLine("'");
                    }
                }
            }

            Utilities.Log(redisInfo.ToString());
        }

        public static void PrintRedisAccessKeys(IRedisAccessKeys redisAccessKeys)
        {
            var redisKeys = new StringBuilder();
            redisKeys.AppendLine("Redis Access Keys: ")
                     .Append("\tPrimary Key: '").Append(redisAccessKeys.PrimaryKey).AppendLine("', ")
                     .Append("\tSecondary Key: '").Append(redisAccessKeys.SecondaryKey).AppendLine("', ");

            Utilities.Log(redisKeys.ToString());
        }

        public static void Print(IAppServiceDomain resource)
        {
            var builder = new StringBuilder().Append("Domain: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tCreated time: ").Append(resource.CreatedTime)
                    .Append("\n\tExpiration time: ").Append(resource.ExpirationTime)
                    .Append("\n\tContact: ");
            var contact = resource.RegistrantContact;
            if (contact == null)
            {
                builder = builder.Append("Private");
            }
            else
            {
                builder = builder.Append("\n\t\tName: ").Append(contact.NameFirst + " " + contact.NameLast);
            }
            builder = builder.Append("\n\tName servers: ");
            foreach (String nameServer in resource.NameServers)
            {
                builder = builder.Append("\n\t\t" + nameServer);
            }
            Utilities.Log(builder.ToString());
        }

        public static void Print(IAppServiceCertificateOrder resource)
        {
            var builder = new StringBuilder().Append("App service certificate order: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tDistinguished name: ").Append(resource.DistinguishedName)
                    .Append("\n\tProduct type: ").Append(resource.ProductType)
                    .Append("\n\tValid years: ").Append(resource.ValidityInYears)
                    .Append("\n\tStatus: ").Append(resource.Status)
                    .Append("\n\tIssuance time: ").Append(resource.LastCertificateIssuanceTime)
                    .Append("\n\tSigned certificate: ").Append(resource.SignedCertificate == null ? null : resource.SignedCertificate.Thumbprint);
            Utilities.Log(builder.ToString());
        }

        public static void Print(IAppServicePlan resource)
        {
            var builder = new StringBuilder().Append("App service certificate order: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tPricing tier: ").Append(resource.PricingTier);
            Utilities.Log(builder.ToString());
        }

        public static void Print(IWebAppBase resource)
        {
            var builder = new StringBuilder().Append("Web app: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tState: ").Append(resource.State)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tDefault hostname: ").Append(resource.DefaultHostName)
                    .Append("\n\tApp service plan: ").Append(resource.AppServicePlanId)
                    .Append("\n\tHost name bindings: ");
            foreach (var binding in resource.GetHostNameBindings().Values)
            {
                builder = builder.Append("\n\t\t" + binding.ToString());
            }
            builder = builder.Append("\n\tSSL bindings: ");
            foreach (var binding in resource.HostNameSslStates.Values)
            {
                builder = builder.Append("\n\t\t" + binding.Name + ": " + binding.SslState);
                if (binding.SslState != null && binding.SslState != SslState.Disabled)
                {
                    builder = builder.Append(" - " + binding.Thumbprint);
                }
            }
            builder = builder.Append("\n\tApp settings: ");
            foreach (var setting in resource.GetAppSettings().Values)
            {
                builder = builder.Append("\n\t\t" + setting.Key + ": " + setting.Value + (setting.Sticky ? " - slot setting" : ""));
            }
            builder = builder.Append("\n\tConnection strings: ");
            foreach (var conn in resource.GetConnectionStrings().Values)
            {
                builder = builder.Append("\n\t\t" + conn.Name + ": " + conn.Value + " - " + conn.Type + (conn.Sticky ? " - slot setting" : ""));
            }
            Utilities.Log(builder.ToString());
        }

        private static string FormatDictionary(IReadOnlyDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return string.Empty;
            }

            var outputString = new StringBuilder();

            foreach (var entity in dictionary)
            {
                outputString.AppendLine($"{entity.Key}: {entity.Value}");
            }

            return outputString.ToString();
        }

        private static string FormatCollection(IEnumerable<string> collection)
        {
            return string.Join(", ", collection);
        }

        public static void PrintSqlServer(ISqlServer sqlServer)
        {
            var builder = new StringBuilder().Append("Sql Server: ").Append(sqlServer.Id)
                    .Append("Name: ").Append(sqlServer.Name)
                    .Append("\n\tResource group: ").Append(sqlServer.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(sqlServer.Region)
                    .Append("\n\tSqlServer version: ").Append(sqlServer.Version)
                    .Append("\n\tFully qualified name for Sql Server: ").Append(sqlServer.FullyQualifiedDomainName);
            Utilities.Log(builder.ToString());
        }

        public static void PrintDatabase(ISqlDatabase database)
        {
            var builder = new StringBuilder().Append("Sql Database: ").Append(database.Id)
                    .Append("Name: ").Append(database.Name)
                    .Append("\n\tResource group: ").Append(database.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(database.Region)
                    .Append("\n\tSqlServer Name: ").Append(database.SqlServerName)
                    .Append("\n\tEdition of SQL database: ").Append(database.Edition)
                    .Append("\n\tCollation of SQL database: ").Append(database.Collation)
                    .Append("\n\tCreation date of SQL database: ").Append(database.CreationDate)
                    .Append("\n\tIs data warehouse: ").Append(database.IsDataWarehouse)
                    .Append("\n\tCurrent service objective of SQL database: ").Append(database.ServiceLevelObjective)
                    .Append("\n\tId of current service objective of SQL database: ").Append(database.CurrentServiceObjectiveId)
                    .Append("\n\tMax size bytes of SQL database: ").Append(database.MaxSizeBytes)
                    .Append("\n\tDefault secondary location of SQL database: ").Append(database.DefaultSecondaryLocation);

            Utilities.Log(builder.ToString());
        }

        public static void PrintFirewallRule(ISqlFirewallRule firewallRule)
        {
            var builder = new StringBuilder().Append("Sql firewall rule: ").Append(firewallRule.Id)
                    .Append("Name: ").Append(firewallRule.Name)
                    .Append("\n\tResource group: ").Append(firewallRule.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(firewallRule.Region)
                    .Append("\n\tSqlServer Name: ").Append(firewallRule.SqlServerName)
                    .Append("\n\tStart IP Address of the firewall rule: ").Append(firewallRule.StartIPAddress)
                    .Append("\n\tEnd IP Address of the firewall rule: ").Append(firewallRule.EndIPAddress);

            Utilities.Log(builder.ToString());
        }

        public static void PrintSqlVirtualNetworkRule(ISqlVirtualNetworkRule virtualNetworkRule)
        {
            var builder = new StringBuilder().Append("SQL virtual network rule: ").Append(virtualNetworkRule.Id)
                .Append("Name: ").Append(virtualNetworkRule.Name)
                .Append("\n\tResource group: ").Append(virtualNetworkRule.ResourceGroupName)
                .Append("\n\tSqlServer Name: ").Append(virtualNetworkRule.SqlServerName)
                .Append("\n\tSubnet ID: ").Append(virtualNetworkRule.SubnetId)
                .Append("\n\tState: ").Append(virtualNetworkRule.State);

            Utilities.Log(builder.ToString());
        }

        public static void PrintSqlFailoverGroup(ISqlFailoverGroup failoverGroup)
        {
            var builder = new StringBuilder().Append("SQL Failover Group: ").Append(failoverGroup.Id)
                .Append("Name: ").Append(failoverGroup.Name)
                .Append("\n\tResource group: ").Append(failoverGroup.ResourceGroupName)
                .Append("\n\tSqlServer Name: ").Append(failoverGroup.SqlServerName)
                .Append("\n\tRead-write endpoint policy: ").Append(failoverGroup.ReadWriteEndpointPolicy)
                .Append("\n\tData loss grace period: ").Append(failoverGroup.ReadWriteEndpointDataLossGracePeriodMinutes)
                .Append("\n\tRead-only endpoint policy: ").Append(failoverGroup.ReadOnlyEndpointPolicy)
                .Append("\n\tReplication state: ").Append(failoverGroup.ReplicationState)
                .Append("\n\tReplication role: ").Append(failoverGroup.ReplicationRole);
            builder.Append("\n\tPartner Servers: ");
            foreach (var item in failoverGroup.PartnerServers)
            {
                builder
                    .Append("\n\t\tId: ").Append(item.Id)
                    .Append("\n\t\tLocation: ").Append(item.Location)
                    .Append("\n\t\tReplication role: ").Append(item.ReplicationRole);
            }
            builder.Append("\n\tDatabases: ");
            foreach (var databaseId in failoverGroup.Databases)
            {
                builder.Append("\n\t\tID: ").Append(databaseId);
            }

            Utilities.Log(builder.ToString());
        }

        public static void PrintSqlServerKey(ISqlServerKey serverKey)
        {
            var builder = new StringBuilder().Append("SQL server key: ").Append(serverKey.Id)
                .Append("Name: ").Append(serverKey.Name)
                .Append("\n\tResource group: ").Append(serverKey.ResourceGroupName)
                .Append("\n\tSqlServer Name: ").Append(serverKey.SqlServerName)
                .Append("\n\tRegion: ").Append(serverKey.Region != null ? serverKey.Region.Name : "")
                .Append("\n\tServer Key Type: ").Append(serverKey.ServerKeyType)
                .Append("\n\tServer Key URI: ").Append(serverKey.Uri)
                .Append("\n\tServer Key Thumbprint: ").Append(serverKey.Thumbprint)
                .Append("\n\tServer Key Creation Date: ").Append(serverKey.CreationDate != null ? serverKey.CreationDate.ToString() : "");

            Utilities.Log(builder.ToString());
        }

        public static void PrintElasticPool(ISqlElasticPool elasticPool)
        {
            var builder = new StringBuilder().Append("Sql elastic pool: ").Append(elasticPool.Id)
                    .Append("Name: ").Append(elasticPool.Name)
                    .Append("\n\tResource group: ").Append(elasticPool.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(elasticPool.Region)
                    .Append("\n\tSqlServer Name: ").Append(elasticPool.SqlServerName)
                    .Append("\n\tEdition of elastic pool: ").Append(elasticPool.Edition)
                    .Append("\n\tTotal number of DTUs in the elastic pool: ").Append(elasticPool.Dtu)
                    .Append("\n\tMaximum DTUs a database can get in elastic pool: ").Append(elasticPool.DatabaseDtuMax)
                    .Append("\n\tMinimum DTUs a database is guaranteed in elastic pool: ").Append(elasticPool.DatabaseDtuMin)
                    .Append("\n\tCreation date for the elastic pool: ").Append(elasticPool.CreationDate)
                    .Append("\n\tState of the elastic pool: ").Append(elasticPool.State)
                    .Append("\n\tStorage capacity in MBs for the elastic pool: ").Append(elasticPool.StorageMB);

            Utilities.Log(builder.ToString());
        }

        public static void PrintElasticPoolActivity(IElasticPoolActivity elasticPoolActivity)
        {
            var builder = new StringBuilder().Append("Sql elastic pool activity: ").Append(elasticPoolActivity.Id)
                    .Append("Name: ").Append(elasticPoolActivity.Name)
                    .Append("\n\tResource group: ").Append(elasticPoolActivity.ResourceGroupName)
                    .Append("\n\tState: ").Append(elasticPoolActivity.State)
                    .Append("\n\tElastic pool name: ").Append(elasticPoolActivity.ElasticPoolName)
                    .Append("\n\tStart time of activity: ").Append(elasticPoolActivity.StartTime)
                    .Append("\n\tEnd time of activity: ").Append(elasticPoolActivity.EndTime)
                    .Append("\n\tError code of activity: ").Append(elasticPoolActivity.ErrorCode)
                    .Append("\n\tError message of activity: ").Append(elasticPoolActivity.ErrorMessage)
                    .Append("\n\tError severity of activity: ").Append(elasticPoolActivity.ErrorSeverity)
                    .Append("\n\tOperation: ").Append(elasticPoolActivity.Operation)
                    .Append("\n\tCompleted percentage of activity: ").Append(elasticPoolActivity.PercentComplete)
                    .Append("\n\tRequested DTU max limit in activity: ").Append(elasticPoolActivity.RequestedDatabaseDtuMax)
                    .Append("\n\tRequested DTU min limit in activity: ").Append(elasticPoolActivity.RequestedDatabaseDtuMin)
                    .Append("\n\tRequested DTU limit in activity: ").Append(elasticPoolActivity.RequestedDtu);

            Utilities.Log(builder.ToString());

        }

        public static void PrintDatabaseActivity(IElasticPoolDatabaseActivity databaseActivity)
        {
            var builder = new StringBuilder().Append("Sql elastic pool database activity: ").Append(databaseActivity.Id)
                    .Append("Name: ").Append(databaseActivity.Name)
                    .Append("\n\tResource group: ").Append(databaseActivity.ResourceGroupName)
                    .Append("\n\tSQL Server Name: ").Append(databaseActivity.ServerName)
                    .Append("\n\tDatabase name name: ").Append(databaseActivity.DatabaseName)
                    .Append("\n\tCurrent elastic pool name of the database: ").Append(databaseActivity.CurrentElasticPoolName)
                    .Append("\n\tState: ").Append(databaseActivity.State)
                    .Append("\n\tStart time of activity: ").Append(databaseActivity.StartTime)
                    .Append("\n\tEnd time of activity: ").Append(databaseActivity.EndTime)
                    .Append("\n\tCompleted percentage: ").Append(databaseActivity.PercentComplete)
                    .Append("\n\tError code of activity: ").Append(databaseActivity.ErrorCode)
                    .Append("\n\tError message of activity: ").Append(databaseActivity.ErrorMessage)
                    .Append("\n\tError severity of activity: ").Append(databaseActivity.ErrorSeverity);

            Utilities.Log(builder.ToString());
        }

        public static void PrintSqlMetric(ISqlSubscriptionUsageMetric subscriptionUsageMetric)
        {
            var builder = new StringBuilder().Append("SQL Subscription Usage Metric: ").Append(subscriptionUsageMetric.Id)
                .Append("Name: ").Append(subscriptionUsageMetric.Name)
                .Append("\n\tDisplay Name: ").Append(subscriptionUsageMetric.DisplayName)
                .Append("\n\tCurrent Value: ").Append(subscriptionUsageMetric.CurrentValue)
                .Append("\n\tLimit: ").Append(subscriptionUsageMetric.Limit)
                .Append("\n\tUnit: ").Append(subscriptionUsageMetric.Unit)
                .Append("\n\tType: ").Append(subscriptionUsageMetric.Type);

            Utilities.Log(builder.ToString());
        }

        public static void PrintSqlMetric(ISqlDatabaseUsageMetric dbUsageMetric)
        {
            var builder = new StringBuilder().Append("SQL Database Usage Metric")
                .Append("Name: ").Append(dbUsageMetric.Name)
                .Append("\n\tResource Name: ").Append(dbUsageMetric.ResourceName)
                .Append("\n\tDisplay Name: ").Append(dbUsageMetric.DisplayName)
                .Append("\n\tCurrent Value: ").Append(dbUsageMetric.CurrentValue)
                .Append("\n\tLimit: ").Append(dbUsageMetric.Limit)
                .Append("\n\tUnit: ").Append(dbUsageMetric.Unit)
                .Append("\n\tNext Reset Time: ").Append(dbUsageMetric.NextResetTime.GetValueOrDefault().ToString());

            Utilities.Log(builder.ToString());
        }

        public static void PrintSqlMetric(ISqlDatabaseMetric dbMetric)
        {
            StringBuilder builder = new StringBuilder().Append("SQL Database Metric")
                .Append("Name: ").Append(dbMetric.Name)
                .Append("\n\tStart Time: ").Append(dbMetric.StartTime)
                .Append("\n\tEnd Time: ").Append(dbMetric.EndTime)
                .Append("\n\tTime Grain: ").Append(dbMetric.TimeGrain)
                .Append("\n\tUnit: ").Append(dbMetric.Unit);
            foreach (var metricValue in dbMetric.MetricValues)
            {
                builder
                    .Append("\n\tMetric Value: ")
                    .Append("\n\t\tCount: ").Append(metricValue.Count)
                    .Append("\n\t\tAverage: ").Append(metricValue.Average)
                    .Append("\n\t\tMaximum: ").Append(metricValue.Maximum)
                    .Append("\n\t\tMinimum: ").Append(metricValue.Minimum)
                    .Append("\n\t\tTimestamp: ").Append(metricValue.Timestamp)
                    .Append("\n\t\tTotal: ").Append(metricValue.Total);
            }

            Utilities.Log(builder.ToString());
        }

        public static void Print(ITrafficManagerProfile profile)
        {
            var builder = new StringBuilder();
            builder.Append("Traffic Manager Profile: ").Append(profile.Id)
                    .Append("\n\tName: ").Append(profile.Name)
                    .Append("\n\tResource group: ").Append(profile.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(profile.RegionName)
                    .Append("\n\tTags: ").Append(profile.Tags)
                    .Append("\n\tDNSLabel: ").Append(profile.DnsLabel)
                    .Append("\n\tFQDN: ").Append(profile.Fqdn)
                    .Append("\n\tTTL: ").Append(profile.TimeToLive)
                    .Append("\n\tEnabled: ").Append(profile.IsEnabled)
                    .Append("\n\tRoutingMethod: ").Append(profile.TrafficRoutingMethod)
                    .Append("\n\tMonitor status: ").Append(profile.MonitorStatus)
                    .Append("\n\tMonitoring port: ").Append(profile.MonitoringPort)
                    .Append("\n\tMonitoring path: ").Append(profile.MonitoringPath);

            var azureEndpoints = profile.AzureEndpoints;
            if (!azureEndpoints.Any())
            {
                builder.Append("\n\tAzure endpoints:");
                var idx = 1;
                foreach (var endpoint in azureEndpoints.Values)
                {
                    builder.Append("\n\t\tAzure endpoint: #").Append(idx++)
                            .Append("\n\t\t\tId: ").Append(endpoint.Id)
                            .Append("\n\t\t\tType: ").Append(endpoint.EndpointType)
                            .Append("\n\t\t\tTarget resourceId: ").Append(endpoint.TargetAzureResourceId)
                            .Append("\n\t\t\tTarget resourceType: ").Append(endpoint.TargetResourceType)
                            .Append("\n\t\t\tMonitor status: ").Append(endpoint.MonitorStatus)
                            .Append("\n\t\t\tEnabled: ").Append(endpoint.IsEnabled)
                            .Append("\n\t\t\tRouting priority: ").Append(endpoint.RoutingPriority)
                            .Append("\n\t\t\tRouting weight: ").Append(endpoint.RoutingWeight);
                }
            }

            var externalEndpoints = profile.ExternalEndpoints;
            if (!externalEndpoints.Any())
            {
                builder.Append("\n\tExternal endpoints:");
                var idx = 1;
                foreach (var endpoint in externalEndpoints.Values)
                {
                    builder.Append("\n\t\tExternal endpoint: #").Append(idx++)
                            .Append("\n\t\t\tId: ").Append(endpoint.Id)
                            .Append("\n\t\t\tType: ").Append(endpoint.EndpointType)
                            .Append("\n\t\t\tFQDN: ").Append(endpoint.Fqdn)
                            .Append("\n\t\t\tSource Traffic Location: ").Append(endpoint.SourceTrafficLocation)
                            .Append("\n\t\t\tMonitor status: ").Append(endpoint.MonitorStatus)
                            .Append("\n\t\t\tEnabled: ").Append(endpoint.IsEnabled)
                            .Append("\n\t\t\tRouting priority: ").Append(endpoint.RoutingPriority)
                            .Append("\n\t\t\tRouting weight: ").Append(endpoint.RoutingWeight);
                }
            }

            var nestedProfileEndpoints = profile.NestedProfileEndpoints;
            if (!nestedProfileEndpoints.Any())
            {
                builder.Append("\n\tNested profile endpoints:");
                var idx = 1;
                foreach (var endpoint in nestedProfileEndpoints.Values)
                {
                    builder.Append("\n\t\tNested profile endpoint: #").Append(idx++)
                            .Append("\n\t\t\tId: ").Append(endpoint.Id)
                            .Append("\n\t\t\tType: ").Append(endpoint.EndpointType)
                            .Append("\n\t\t\tNested profileId: ").Append(endpoint.NestedProfileId)
                            .Append("\n\t\t\tMinimum child threshold: ").Append(endpoint.MinimumChildEndpointCount)
                            .Append("\n\t\t\tSource Traffic Location: ").Append(endpoint.SourceTrafficLocation)
                            .Append("\n\t\t\tMonitor status: ").Append(endpoint.MonitorStatus)
                            .Append("\n\t\t\tEnabled: ").Append(endpoint.IsEnabled)
                            .Append("\n\t\t\tRouting priority: ").Append(endpoint.RoutingPriority)
                            .Append("\n\t\t\tRouting weight: ").Append(endpoint.RoutingWeight);
                }
            }
            Utilities.Log(builder.ToString());
        }

        public static void Print(IDnsZone dnsZone)
        {
            var builder = new StringBuilder();
            builder.Append("Dns Zone: ").Append(dnsZone.Id)
                    .Append("\n\tName (Top level domain): ").Append(dnsZone.Name)
                    .Append("\n\tResource group: ").Append(dnsZone.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(dnsZone.RegionName)
                    .Append("\n\tTags: ").Append(dnsZone.Tags)
                    .Append("\n\tName servers:");
            foreach (var nameServer in dnsZone.NameServers)
            {
                builder.Append("\n\t\t").Append(nameServer);
            }
            var soaRecordSet = dnsZone.GetSoaRecordSet();
            var soaRecord = soaRecordSet.Record;
            builder.Append("\n\tSOA Record:")
                    .Append("\n\t\tHost:").Append(soaRecord.Host)
                    .Append("\n\t\tEmail:").Append(soaRecord.Email)
                    .Append("\n\t\tExpire time (seconds):").Append(soaRecord.ExpireTime)
                    .Append("\n\t\tRefresh time (seconds):").Append(soaRecord.RefreshTime)
                    .Append("\n\t\tRetry time (seconds):").Append(soaRecord.RetryTime)
                    .Append("\n\t\tNegative response cache ttl (seconds):").Append(soaRecord.MinimumTtl)
                    .Append("\n\t\tTtl (seconds):").Append(soaRecordSet.TimeToLive);

            var aRecordSets = dnsZone.ARecordSets.List();
            builder.Append("\n\tA Record sets:");
            foreach (var aRecordSet in aRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(aRecordSet.Id)
                        .Append("\n\t\tName: ").Append(aRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(aRecordSet.TimeToLive)
                        .Append("\n\t\tIp v4 addresses: ");
                foreach (var ipAddress in aRecordSet.IPv4Addresses)
                {
                    builder.Append("\n\t\t\t").Append(ipAddress);
                }
            }

            var aaaaRecordSets = dnsZone.AaaaRecordSets.List();
            builder.Append("\n\tAAAA Record sets:");
            foreach (var aaaaRecordSet in aaaaRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(aaaaRecordSet.Id)
                        .Append("\n\t\tName: ").Append(aaaaRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(aaaaRecordSet.TimeToLive)
                        .Append("\n\t\tIp v6 addresses: ");
                foreach (var ipAddress in aaaaRecordSet.IPv6Addresses)
                {
                    builder.Append("\n\t\t\t").Append(ipAddress);
                }
            }

            var cnameRecordSets = dnsZone.CNameRecordSets.List();
            builder.Append("\n\tCNAME Record sets:");
            foreach (var cnameRecordSet in cnameRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(cnameRecordSet.Id)
                        .Append("\n\t\tName: ").Append(cnameRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(cnameRecordSet.TimeToLive)
                        .Append("\n\t\tCanonical name: ").Append(cnameRecordSet.CanonicalName);
            }

            var mxRecordSets = dnsZone.MXRecordSets.List();
            builder.Append("\n\tMX Record sets:");
            foreach (var mxRecordSet in mxRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(mxRecordSet.Id)
                        .Append("\n\t\tName: ").Append(mxRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(mxRecordSet.TimeToLive)
                        .Append("\n\t\tRecords: ");
                foreach (var mxRecord in mxRecordSet.Records)
                {
                    builder.Append("\n\t\t\tExchange server, Preference: ")
                            .Append(mxRecord.Exchange)
                            .Append(" ")
                            .Append(mxRecord.Preference);
                }
            }

            var nsRecordSets = dnsZone.NSRecordSets.List();
            builder.Append("\n\tNS Record sets:");
            foreach (var nsRecordSet in nsRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(nsRecordSet.Id)
                        .Append("\n\t\tName: ").Append(nsRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(nsRecordSet.TimeToLive)
                        .Append("\n\t\tName servers: ");
                foreach (var nameServer in nsRecordSet.NameServers)
                {
                    builder.Append("\n\t\t\t").Append(nameServer);
                }
            }

            var ptrRecordSets = dnsZone.PtrRecordSets.List();
            builder.Append("\n\tPTR Record sets:");
            foreach (var ptrRecordSet in ptrRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(ptrRecordSet.Id)
                        .Append("\n\t\tName: ").Append(ptrRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(ptrRecordSet.TimeToLive)
                        .Append("\n\t\tTarget domain names: ");
                foreach (var domainNames in ptrRecordSet.TargetDomainNames)
                {
                    builder.Append("\n\t\t\t").Append(domainNames);
                }
            }

            var srvRecordSets = dnsZone.SrvRecordSets.List();
            builder.Append("\n\tSRV Record sets:");
            foreach (var srvRecordSet in srvRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(srvRecordSet.Id)
                        .Append("\n\t\tName: ").Append(srvRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(srvRecordSet.TimeToLive)
                        .Append("\n\t\tRecords: ");
                foreach (var srvRecord in srvRecordSet.Records)
                {
                    builder.Append("\n\t\t\tTarget, Port, Priority, Weight: ")
                            .Append(srvRecord.Target)
                            .Append(", ")
                            .Append(srvRecord.Port)
                            .Append(", ")
                            .Append(srvRecord.Priority)
                            .Append(", ")
                            .Append(srvRecord.Weight);
                }
            }

            var txtRecordSets = dnsZone.TxtRecordSets.List();
            builder.Append("\n\tTXT Record sets:");
            foreach (var txtRecordSet in txtRecordSets)
            {
                builder.Append("\n\t\tId: ").Append(txtRecordSet.Id)
                        .Append("\n\t\tName: ").Append(txtRecordSet.Name)
                        .Append("\n\t\tTtl (seconds): ").Append(txtRecordSet.TimeToLive)
                        .Append("\n\t\tRecords: ");
                foreach (var txtRecord in txtRecordSet.Records)
                {
                    if (txtRecord.Value.Count() > 0)
                    {
                        builder.Append("\n\t\t\tValue: ").Append(txtRecord.Value.FirstOrDefault());
                    }
                }
            }
            Utilities.Log(builder.ToString());
        }

        public static void Print(IRegistry azureRegistry)
        {
            StringBuilder info = new StringBuilder();

            var acrCredentials = azureRegistry.GetCredentials();
            info.Append("Azure Container Registry: ").Append(azureRegistry.Id)
                .Append("\n\tName: ").Append(azureRegistry.Name)
                .Append("\n\tServer Url: ").Append(azureRegistry.LoginServerUrl)
                .Append("\n\tUser: ").Append(acrCredentials.Username)
                .Append("\n\tFirst Password: ").Append(acrCredentials.AccessKeys[AccessKeyType.Primary])
                .Append("\n\tSecond Password: ").Append(acrCredentials.AccessKeys[AccessKeyType.Secondary]);
            Log(info.ToString());
        }

        public static void Print(IContainerGroup containerGroup)
        {
            StringBuilder info = new StringBuilder();

            info = new StringBuilder().Append("Container Group: ").Append(containerGroup.Id)
                .Append("Name: ").Append(containerGroup.Name)
                .Append("\n\tResource group: ").Append(containerGroup.ResourceGroupName)
                .Append("\n\tRegion: ").Append(containerGroup.RegionName)
                .Append("\n\tTags: ").Append(containerGroup.Tags)
                .Append("\n\tOS type: ").Append(containerGroup.OSType.Value);

            if (containerGroup.IPAddress != null)
            {
                info.Append("\n\tPublic IP address: ").Append(containerGroup.IPAddress);
                info.Append("\n\tExternal TCP ports:");
                foreach (int port in containerGroup.ExternalTcpPorts)
                {
                    info.Append(" ").Append(port);
                }
                info.Append("\n\tExternal UDP ports:");
                foreach (int port in containerGroup.ExternalUdpPorts)
                {
                    info.Append(" ").Append(port);
                }
            }
            if (containerGroup.ImageRegistryServers.Count > 0)
            {
                info.Append("\n\tPrivate Docker image registries:");
                foreach (string server in containerGroup.ImageRegistryServers)
                {
                    info.Append(" ").Append(server);
                }
            }
            if (containerGroup.Volumes.Count > 0)
            {
                info.Append("\n\tVolume mapping: ");
                foreach (var entry in containerGroup.Volumes)
                {
                    info.Append("\n\t\tName: ").Append(entry.Key).Append(" -> ").Append(entry.Value.AzureFile.ShareName);
                }
            }
            if (containerGroup.Containers.Count > 0)
            {
                info.Append("\n\tContainer instances: ");
                foreach (var entry in containerGroup.Containers)
                {
                    var container = entry.Value;
                    info.Append("\n\t\tName: ").Append(entry.Key).Append(" -> ").Append(container.Image);
                    info.Append("\n\t\t\tResources: ");
                    info.Append(container.Resources.Requests.Cpu).Append(" CPUs ");
                    info.Append(container.Resources.Requests.MemoryInGB).Append(" GB");
                    info.Append("\n\t\t\tPorts:");
                    foreach (var port in container.Ports)
                    {
                        info.Append(" ").Append(port.Port);
                    }
                    if (container.VolumeMounts != null)
                    {
                        info.Append("\n\t\t\tVolume mounts:");
                        foreach (var volumeMount in container.VolumeMounts)
                        {
                            info.Append(" ").Append(volumeMount.Name).Append("->").Append(volumeMount.MountPath);
                        }
                    }
                    if (container.Command != null)
                    {
                        info.Append("\n\t\t\tStart commands:");
                        foreach (var command in container.Command)
                        {
                            info.Append("\n\t\t\t\t").Append(command);
                        }
                    }
                    if (container.EnvironmentVariables != null)
                    {
                        info.Append("\n\t\t\tENV vars:");
                        foreach (var envVar in container.EnvironmentVariables)
                        {
                            info.Append("\n\t\t\t\t").Append(envVar.Name).Append("=").Append(envVar.Value);
                        }
                    }
                }
            }

            Log(info.ToString());
        }

        /**
         * Print an Azure Container Service.
         * @param containerService an Azure Container Service
         */
        public static void Print(ContainerService.Fluent.IContainerService containerService)
        {
            StringBuilder info = new StringBuilder();

            info.Append("Azure Container Service: ").Append(containerService.Id)
                .Append("\n\tName: ").Append(containerService.Name)
                .Append("\n\tWith orchestration: ").Append(containerService.OrchestratorType.ToString())
                .Append("\n\tMaster FQDN: ").Append(containerService.MasterFqdn)
                .Append("\n\tMaster node count: ").Append(containerService.MasterNodeCount)
                .Append("\n\tMaster leaf domain label: ").Append(containerService.MasterDnsPrefix)
                .Append("\n\t\tWith Agent pool name: ").Append(containerService.AgentPools.First().Value.Name)
                .Append("\n\t\tAgent pool count: ").Append(containerService.AgentPools.First().Value.Count)
                .Append("\n\t\tAgent virtual machine size: ").Append(containerService.AgentPools.First().Value.VMSize.ToString())
                .Append("\n\t\tAgent pool FQDN: ").Append(containerService.AgentPools.First().Value.Fqdn)
                .Append("\n\t\tAgent DNS prefix: ").Append(containerService.AgentPools.First().Value.DnsPrefix)
                .Append("\n\tLinux user name: ").Append(containerService.LinuxRootUsername)
                .Append("\n\tSSH key: ").Append(containerService.SshKey);
            if (containerService.OrchestratorType == ContainerService.Fluent.Models.ContainerServiceOrchestratorTypes.Kubernetes)
            {
                info.Append("\n\tService Principal ID: ").Append(containerService.ServicePrincipalClientId);
            }

            Log(info.ToString());
        }

        /**
         * Print a Kubernetes cluster.
         * @param kubernetesCluster a Kubernetes cluster instance
         */
        public static void Print(ContainerService.Fluent.IKubernetesCluster kubernetesCluster)
        {
            StringBuilder info = new StringBuilder();

            info.Append("Azure Container Service: ").Append(kubernetesCluster.Id)
                .Append("\n\tName: ").Append(kubernetesCluster.Name)
                .Append("\n\tFQDN: ").Append(kubernetesCluster.Fqdn)
                .Append("\n\tDNS prefix: ").Append(kubernetesCluster.DnsPrefix)
                .Append("\n\t\tWith Agent pool name: ").Append(kubernetesCluster.AgentPools.First().Value.Name)
                .Append("\n\t\tAgent pool count: ").Append(kubernetesCluster.AgentPools.First().Value.Count)
                .Append("\n\t\tAgent virtual machine size: ").Append(kubernetesCluster.AgentPools.First().Value.VMSize.ToString())
                .Append("\n\tLinux user name: ").Append(kubernetesCluster.LinuxRootUsername)
                .Append("\n\tSSH key: ").Append(kubernetesCluster.SshKey)
                .Append("\n\tService principal ID: ").Append(kubernetesCluster.ServicePrincipalClientId);

            Log(info.ToString());
        }

        /**
         * Retrieve the secondary service principal client ID.
         * @param envSecondaryServicePrincipal an Azure Container Registry
         * @return a service principal client ID
         */
        public static string GetSecondaryServicePrincipalClientID(string envSecondaryServicePrincipal)
        {
            string clientId = "";
            File.ReadAllLines(envSecondaryServicePrincipal).All(line =>
            {
                var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                if (keyVal.Length < 2)
                    return true; // Ignore lines that don't look like $$$=$$$
                if (keyVal[0].Equals("client"))
                    clientId = keyVal[1];
                return true;
            });

            return clientId;
        }

        /**
         * Retrieve the secondary service principal secret.
         * @param envSecondaryServicePrincipal an Azure Container Registry
         * @return a service principal secret
         */
        public static string GetSecondaryServicePrincipalSecret(string envSecondaryServicePrincipal)
        {
            string secret = "";
            File.ReadAllLines(envSecondaryServicePrincipal).All(line =>
            {
                var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                if (keyVal.Length < 2)
                    return true; // Ignore lines that don't look like $$$=$$$
                if (keyVal[0].Equals("key"))
                    secret = keyVal[1];
                return true;
            });

            return secret;
        }

        public static void Print(ICosmosDBAccount cosmosDBAccount)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("CosmosDB: ").Append(cosmosDBAccount.Id)
                    .Append("\n\tName: ").Append(cosmosDBAccount.Name)
                    .Append("\n\tResourceGroupName: ").Append(cosmosDBAccount.ResourceGroupName)
                    .Append("\n\tKind: ").Append(cosmosDBAccount.Kind.ToString())
                    .Append("\n\tDefault consistency level: ").Append(cosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel)
                    .Append("\n\tIP range filter: ").Append(cosmosDBAccount.IPRangeFilter);

            foreach (Location writeReplica in cosmosDBAccount.WritableReplications)
            {
                builder.Append("\n\t\tWrite replication: ")
                        .Append("\n\t\t\tName :").Append(writeReplica.LocationName);
            }

            builder.Append("\n\tNumber of read replications: ").Append(cosmosDBAccount.ReadableReplications.Count);
            foreach (Location readReplica in cosmosDBAccount.ReadableReplications)
            {
                builder.Append("\n\t\tRead replication: ")
                        .Append("\n\t\t\tName :").Append(readReplica.LocationName);
            }

            Log(builder.ToString());
        }

        public static void Print(IActiveDirectoryApplication application)
        {
            StringBuilder builder = new StringBuilder()
                .Append("Active Directory Application: ").Append(application.Id)
                .Append("\n\tName: ").Append(application.Name)
                .Append("\n\tSign on URL: ").Append(application.SignOnUrl.ToString())
                .Append("\n\tReply URLs:");
            foreach (string replyUrl in application.ReplyUrls)
            {
                builder.Append("\n\t\t").Append(replyUrl);
            }

            Log(builder.ToString());
        }

        public static void Print(IServicePrincipal servicePrincipal)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Service Principal: ").Append(servicePrincipal.Id)
                    .Append("\n\tName: ").Append(servicePrincipal.Name)
                    .Append("\n\tApplication Id: ").Append(servicePrincipal.ApplicationId);

            var names = servicePrincipal.ServicePrincipalNames;
            builder.Append("\n\tNames: ").Append(names.Count);
            foreach (string name in names)
            {
                builder.Append("\n\t\tName: ").Append(name);
            }

            Log(builder.ToString());
        }

        public static void Print(IActiveDirectoryGroup group)
        {
            StringBuilder builder = new StringBuilder()
                    .Append("Active Directory Group: ").Append(group.Id)
                    .Append("\n\tName: ").Append(group.Name)
                    .Append("\n\tMail: ").Append(group.Mail)
                    .Append("\n\tSecurity Enabled: ").Append(group.SecurityEnabled)
                    .Append("\n\tGroup members:");

            foreach (var obj in group.ListMembers())
            {
                builder.Append("\n\t\tType: ").Append(obj.GetType().Name).Append("\tName: ").Append(obj.Name);
            }

            Log(builder.ToString());
        }


        public static void Print(IActiveDirectoryUser user)
        {
            var builder = new StringBuilder()
                .Append("Active Directory User: ").Append(user.Id)
                .Append("\n\tName: ").Append(user.Name)
                .Append("\n\tMail: ").Append(user.Mail)
                .Append("\n\tMail Nickname: ").Append(user.MailNickname)
                .Append("\n\tSign In Name: ").Append(user.SignInName)
                .Append("\n\tUser Principal Name: ").Append(user.UserPrincipalName);

            Utilities.Log(builder.ToString());
        }

        public static void Print(IRoleDefinition role)
        {
            StringBuilder builder = new StringBuilder()
                .Append("Role Definition: ").Append(role.Id)
                .Append("\n\tName: ").Append(role.Name)
                .Append("\n\tRole Name: ").Append(role.RoleName)
                .Append("\n\tType: ").Append(role.Type)
                .Append("\n\tDescription: ").Append(role.Description)
                .Append("\n\tType: ").Append(role.Type)
                .Append("\n\tPermissions: ");
            foreach (var permission in role.Permissions)
            {
                builder.Append("\n\t\tPermission Actions: ");
                foreach (var action in permission.Actions)
                {
                    builder.Append("\n\t\t\tName :").Append(action);
                }
                builder.Append("\n\t\tPermission Not Actions: ");
                foreach (var notAction in permission.NotActions)
                {
                    builder.Append("\n\t\t\tName :").Append(notAction);
                }
            }
            builder.Append("\n\tAssignable scopes: ");
            foreach (var scope in role.AssignableScopes)
            {
                builder.Append("\n\t\tAssignable Scope: ")
                    .Append("\n\t\t\tName :").Append(scope);
            }
            Utilities.Log(builder.ToString());
        }

        public static void Print(IRoleAssignment roleAssignment)
        {
            StringBuilder builder = new StringBuilder()
                .Append("Role Assignment: ")
                .Append("\n\tScope: ").Append(roleAssignment.Scope)
                .Append("\n\tPrincipal Id: ").Append(roleAssignment.PrincipalId)
                .Append("\n\tRole Definition Id: ").Append(roleAssignment.RoleDefinitionId);
            Utilities.Log(builder.ToString());
        }

        public static void Print(INetworkWatcher nw)
        {
            StringBuilder builder = new StringBuilder()
                .Append("Network Watcher: ").Append(nw.Id)
                .Append("\n\tName: ").Append(nw.Name)
                .Append("\n\tResource group name: ").Append(nw.ResourceGroupName)
                .Append("\n\tRegion name: ").Append(nw.RegionName);
            Utilities.Log(builder.ToString());
        }

        public static void Print(IPacketCapture resource)
        {
            StringBuilder sb = new StringBuilder().Append("Packet Capture: ").Append(resource.Id)
                .Append("\n\tName: ").Append(resource.Name)
                .Append("\n\tTarget id: ").Append(resource.TargetId)
                .Append("\n\tTime limit in seconds: ").Append(resource.TimeLimitInSeconds)
                .Append("\n\tBytes to capture per packet: ").Append(resource.BytesToCapturePerPacket)
                .Append("\n\tProvisioning state: ").Append(resource.ProvisioningState)
                .Append("\n\tStorage location:")
                .Append("\n\tStorage account id: ").Append(resource.StorageLocation.StorageId)
                .Append("\n\tStorage account path: ").Append(resource.StorageLocation.StoragePath)
                .Append("\n\tFile path: ").Append(resource.StorageLocation.FilePath)
                .Append("\n\t Packet capture filters: ").Append(resource.Filters.Count);
            foreach (var filter in resource.Filters)
            {
                sb.Append("\n\t\tProtocol: ").Append(filter.Protocol);
                sb.Append("\n\t\tLocal IP address: ").Append(filter.LocalIPAddress);
                sb.Append("\n\t\tRemote IP address: ").Append(filter.RemoteIPAddress);
                sb.Append("\n\t\tLocal port: ").Append(filter.LocalPort);
                sb.Append("\n\t\tRemote port: ").Append(filter.RemotePort);
            }
            Utilities.Log(sb.ToString());
        }

        public static void Print(IVerificationIPFlow resource)
        {
            Utilities.Log(new StringBuilder("IP flow verification: ")
                .Append("\n\tAccess: ").Append(resource.Access)
                .Append("\n\tRule name: ").Append(resource.RuleName)
                .ToString());
        }

        public static void Print(ITopology resource)
        {
            StringBuilder sb = new StringBuilder().Append("Topology: ").Append(resource.Id)
                .Append("\n\tResource group: ").Append(resource.TopologyParameters.TargetResourceGroupName)
                .Append("\n\tTarget vitual network: ").Append(resource.TopologyParameters.TargetVirtualNetwork)
                .Append("\n\tTarget subnet: ").Append(resource.TopologyParameters.TargetSubnet)
                .Append("\n\tCreated time: ").Append(resource.CreatedTime)
                .Append("\n\tLast modified time: ").Append(resource.LastModifiedTime);
            foreach (var tr in resource.Resources.Values)
            {
                sb.Append("\n\tTopology resource: ").Append(tr.Id)
                    .Append("\n\t\tName: ").Append(tr.Name)
                    .Append("\n\t\tLocation: ").Append(tr.Location)
                    .Append("\n\t\tAssociations:");
                foreach (var association in tr.Associations)
                {
                    sb.Append("\n\t\t\tName:").Append(association.Name)
                        .Append("\n\t\t\tResource id:").Append(association.ResourceId)
                        .Append("\n\t\t\tAssociation type:").Append(association.AssociationType);
                }
            }
            Utilities.Log(sb.ToString());
        }

        public static void Print(IFlowLogSettings resource)
        {
            Utilities.Log(new StringBuilder().Append("Flow log settings: ")
                .Append("Target resource id: ").Append(resource.TargetResourceId)
                .Append("\n\tFlow log enabled: ").Append(resource.Enabled)
                .Append("\n\tStorage account id: ").Append(resource.StorageId)
                .Append("\n\tRetention policy enabled: ").Append(resource.IsRetentionEnabled)
                .Append("\n\tRetention policy days: ").Append(resource.RetentionDays)
                .ToString());
        }

        public static void Print(ISecurityGroupView resource)
        {
            StringBuilder sb = new StringBuilder().Append("Security group view: ")
                .Append("\n\tVirtual machine id: ").Append(resource.VMId);
            foreach (var sgni in resource.NetworkInterfaces.Values)
            {
                sb.Append("\n\tSecurity group network interface:").Append(sgni.Id)
                    .Append("\n\t\tSecurity group network interface:")
                    .Append("\n\t\tEffective security rules:");
                foreach (var rule in sgni.SecurityRuleAssociations.EffectiveSecurityRules)
                {
                    sb.Append("\n\t\t\tName: ").Append(rule.Name)
                        .Append("\n\t\t\tDirection: ").Append(rule.Direction)
                        .Append("\n\t\t\tAccess: ").Append(rule.Access)
                        .Append("\n\t\t\tPriority: ").Append(rule.Priority)
                        .Append("\n\t\t\tSource address prefix: ").Append(rule.SourceAddressPrefix)
                        .Append("\n\t\t\tSource port range: ").Append(rule.SourcePortRange)
                        .Append("\n\t\t\tDestination address prefix: ").Append(rule.DestinationAddressPrefix)
                        .Append("\n\t\t\tDestination port range: ").Append(rule.DestinationPortRange)
                        .Append("\n\t\t\tProtocol: ").Append(rule.Protocol);
                }
                sb.Append("\n\t\tSubnet:").Append(sgni.SecurityRuleAssociations.SubnetAssociation.Id);
                printSecurityRule(sb, sgni.SecurityRuleAssociations.SubnetAssociation.SecurityRules);
                if (sgni.SecurityRuleAssociations.NetworkInterfaceAssociation != null)
                {
                    sb.Append("\n\t\tNetwork interface:")
                        .Append(sgni.SecurityRuleAssociations.NetworkInterfaceAssociation.Id);
                    printSecurityRule(sb, sgni.SecurityRuleAssociations.NetworkInterfaceAssociation.SecurityRules);
                }
                sb.Append("\n\t\tDefault security rules:");
                printSecurityRule(sb, sgni.SecurityRuleAssociations.DefaultSecurityRules);
            }
            Utilities.Log(sb.ToString());
        }

        private static void printSecurityRule(StringBuilder sb, IList<SecurityRuleInner> rules)
        {
            foreach (var rule in rules)
            {
                sb.Append("\n\t\t\tName: ").Append(rule.Name)
                    .Append("\n\t\t\tDirection: ").Append(rule.Direction)
                    .Append("\n\t\t\tAccess: ").Append(rule.Access)
                    .Append("\n\t\t\tPriority: ").Append(rule.Priority)
                    .Append("\n\t\t\tSource address prefix: ").Append(rule.SourceAddressPrefix)
                    .Append("\n\t\t\tSource port range: ").Append(rule.SourcePortRange)
                    .Append("\n\t\t\tDestination address prefix: ").Append(rule.DestinationAddressPrefix)
                    .Append("\n\t\t\tDestination port range: ").Append(rule.DestinationPortRange)
                    .Append("\n\t\t\tProtocol: ").Append(rule.Protocol)
                    .Append("\n\t\t\tDescription: ").Append(rule.Description)
                    .Append("\n\t\t\tProvisioning state: ").Append(rule.ProvisioningState);
            }
        }

        public static void Print(INextHop resource)
        {
            StringBuilder sb = new StringBuilder("Next hop: ")
                .Append("Next hop type: ").Append(resource.NextHopType)
                .Append("\n\tNext hop ip address: ").Append(resource.NextHopIpAddress)
                .Append("\n\tRoute table id: ").Append(resource.RouteTableId);
            Utilities.Log(sb.ToString());
        }

        public static void Print(IVirtualNetworkGatewayConnection resource)
        {
            StringBuilder sb = new StringBuilder("Virtual network gateway connection: ")
                .Append("\n\tId: ").Append(resource.Id)
                .Append("\n\tName: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.RegionName)
                .Append("\n\tConnection type: ").Append(resource.ConnectionType)
                .Append("\n\tConnection status: ").Append(resource.ConnectionStatus.Value)
                .Append("\n\tFirst virtual network gateway id: ").Append(resource.VirtualNetworkGateway1Id)
                .Append("\n\tSecond virtual network gateway id: ").Append(resource.VirtualNetworkGateway2Id)
                .Append("\n\tLocal network gateway id: ").Append(resource.LocalNetworkGateway2Id)
                .Append("\n\tBgp enabled: ").Append(resource.IsBgpEnabled)
                .Append("\n\tEgressBytesTransferred: ").Append(resource.EgressBytesTransferred)
                .Append("\n\tIngressBytesTransferred: ").Append(resource.IngressBytesTransferred);
            Utilities.Log(sb.ToString());
        }

        public static void Print(IEventHubNamespace resource)
        {
            StringBuilder eh = new StringBuilder("Eventhub Namespace: ")
                .Append("Eventhub Namespace: ").Append(resource.Id)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags.ToString())
                    .Append("\n\tAzureInsightMetricId: ").Append(resource.AzureInsightMetricId)
                    .Append("\n\tIsAutoScale enabled: ").Append(resource.IsAutoScaleEnabled)
                    .Append("\n\tServiceBus endpoint: ").Append(resource.ServiceBusEndpoint)
                    .Append("\n\tThroughPut upper limit: ").Append(resource.ThroughputUnitsUpperLimit)
                    .Append("\n\tCurrent ThroughPut: ").Append(resource.CurrentThroughputUnits)
                    .Append("\n\tCreated time: ").Append(resource.CreatedAt)
                    .Append("\n\tUpdated time: ").Append(resource.UpdatedAt);
            Utilities.Log(eh.ToString());
        }

        public static void Print(IEventHub resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Eventhub: ").Append(resource.Id)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tNamespace resource group: ").Append(resource.NamespaceResourceGroupName)
                    .Append("\n\tNamespace: ").Append(resource.NamespaceName)
                    .Append("\n\tIs data capture enabled: ").Append(resource.IsDataCaptureEnabled)
                    .Append("\n\tPartition ids: ").Append(resource.PartitionIds);
            if (resource.IsDataCaptureEnabled)
            {
                info.Append("\n\t\t\tData capture window size in MB: ").Append(resource.DataCaptureWindowSizeInMB);
                info.Append("\n\t\t\tData capture window size in seconds: ").Append(resource.DataCaptureWindowSizeInSeconds);
                if (resource.CaptureDestination != null)
                {
                    info.Append("\n\t\t\tData capture storage account: ").Append(resource.CaptureDestination.StorageAccountResourceId);
                    info.Append("\n\t\t\tData capture storage container: ").Append(resource.CaptureDestination.BlobContainer);
                }
            }
            Utilities.Log(info.ToString());
        }

        public static void Print(IEventHubDisasterRecoveryPairing resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("DisasterRecoveryPairing: ").Append(resource.Id)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tPrimary namespace resource group name: ").Append(resource.PrimaryNamespaceResourceGroupName)
                    .Append("\n\tPrimary namespace name: ").Append(resource.PrimaryNamespaceName)
                    .Append("\n\tSecondary namespace: ").Append(resource.SecondaryNamespaceId)
                    .Append("\n\tNamespace role: ").Append(resource.NamespaceRole);
            Utilities.Log(info.ToString());
        }

        public static void Print(IDisasterRecoveryPairingAuthorizationRule resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("DisasterRecoveryPairing auth rule: ").Append(resource.Name);
            List<String> rightsStr = new List<string>();
            foreach (var rights in resource.Rights)
            {
                rightsStr.Add(rights.ToString());
            }
            info.Append("\n\tRights: ").Append(rightsStr);
            Utilities.Log(info.ToString());
        }

        public static void Print(IDisasterRecoveryPairingAuthorizationKey resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("DisasterRecoveryPairing auth key: ")
                    .Append("\n\t Alias primary connection string: ").Append(resource.AliasPrimaryConnectionString)
                    .Append("\n\t Alias secondary connection string: ").Append(resource.AliasSecondaryConnectionString)
                    .Append("\n\t Primary key: ").Append(resource.PrimaryKey)
                    .Append("\n\t Secondary key: ").Append(resource.SecondaryKey)
                    .Append("\n\t Primary connection string: ").Append(resource.PrimaryConnectionString)
                    .Append("\n\t Secondary connection string: ").Append(resource.SecondaryConnectionString);
            Utilities.Log(info.ToString());
        }

        public static void Print(IEventHubConsumerGroup resource)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Event hub consumer group: ").Append(resource.Id)
                    .Append("\n\tName: ").Append(resource.Name)
                    .Append("\n\tNamespace resource group: ").Append(resource.NamespaceResourceGroupName)
                    .Append("\n\tNamespace: ").Append(resource.NamespaceName)
                    .Append("\n\tEvent hub name: ").Append(resource.EventHubName)
                    .Append("\n\tUser metadata: ").Append(resource.UserMetadata);
            Utilities.Log(info.ToString());
        }

        public static void Print(IBatchAICluster resource)
        {
            StringBuilder sb = new StringBuilder("Batch AI cluster: ")
                .Append("\n\tId: ").Append(resource.Id)
                .Append("\n\tName: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.RegionName)
                .Append("\n\tVM Size: ").Append(resource.VMSize)
                .Append("\n\tVM Priority: ").Append(resource.VMPriority)
                .Append("\n\tSubnet: ").Append(resource.Subnet)
                .Append("\n\tAllocation state: ").Append(resource.AllocationState)
                .Append("\n\tAllocation state transition time: ").Append(resource.AllocationStateTransitionTime)
                .Append("\n\tCreation time: ").Append(resource.CreationTime)
                .Append("\n\tCurrent node count: ").Append(resource.CurrentNodeCount)
                .Append("\n\tAllocation state transition time: ").Append(resource.AllocationStateTransitionTime)
                .Append("\n\tAllocation state transition time: ").Append(resource.AllocationStateTransitionTime);
            if (resource.ScaleSettings.AutoScale != null)
            {
                sb.Append("\n\tAuto scale settings: ")
                    .Append("\n\t\tInitial node count: ").Append(resource.ScaleSettings.AutoScale.InitialNodeCount)
                    .Append("\n\t\tMinimum node count: ").Append(resource.ScaleSettings.AutoScale.MinimumNodeCount)
                    .Append("\n\t\tMaximum node count: ").Append(resource.ScaleSettings.AutoScale.MaximumNodeCount);
            }
            if (resource.ScaleSettings.Manual != null)
            {
                sb.Append("\n\tManual scale settings: ")
                    .Append("\n\t\tTarget node count: ").Append(resource.ScaleSettings.Manual.TargetNodeCount)
                    .Append("\n\t\tDeallocation option: ")
                    .Append(resource.ScaleSettings.Manual.NodeDeallocationOption.GetValueOrDefault());
            }
            if (resource.NodeStateCounts != null)
            {
                sb.Append("\n\tNode state counts: ")
                    .Append("\n\t\tRunning nodes count: ").Append(resource.NodeStateCounts.RunningNodeCount)
                    .Append("\n\t\tIdle nodes count: ").Append(resource.NodeStateCounts.IdleNodeCount)
                    .Append("\n\t\tPreparing nodes count: ").Append(resource.NodeStateCounts.PreparingNodeCount)
                    .Append("\n\t\tLeaving nodes count: ").Append(resource.NodeStateCounts.LeavingNodeCount)
                    .Append("\n\t\tPreparing nodes count: ").Append(resource.NodeStateCounts.PreparingNodeCount);
            }
            if (resource.VirtualMachineConfiguration != null && resource.VirtualMachineConfiguration.ImageReference != null)
            {
                sb.Append("\n\tVirtual machine configuration: ")
                    .Append("\n\t\tPublisher: ").Append(resource.VirtualMachineConfiguration.ImageReference.Publisher)
                    .Append("\n\t\tOffer: ").Append(resource.VirtualMachineConfiguration.ImageReference.Offer)
                    .Append("\n\t\tSku: ").Append(resource.VirtualMachineConfiguration.ImageReference.Sku)
                    .Append("\n\t\tVersion: ").Append(resource.VirtualMachineConfiguration.ImageReference.Version);
            }
            if (resource.NodeSetup != null && resource.NodeSetup.SetupTask != null)
            {
                sb.Append("\n\tSetup task: ")
                    .Append("\n\t\tCommand line: ").Append(resource.NodeSetup.SetupTask.CommandLine)
                    .Append("\n\t\tRun elevated: ").Append(resource.NodeSetup.SetupTask.RunElevated)
                    .Append("\n\t\tStdout/err Path Prefix: ").Append(resource.NodeSetup.SetupTask.StdOutErrPathPrefix);
            }
            Utilities.Log(sb.ToString());
        }

        public static void Print(IBatchAIJob resource)
        {
            StringBuilder sb = new StringBuilder("Batch AI job: ")
                .Append("\n\tId: ").Append(resource.Id)
                .Append("\n\tName: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.RegionName)
                .Append("\n\tCluster Id: ").Append(resource.Cluster)
                .Append("\n\tCreation time: ").Append(resource.CreationTime)
                .Append("\n\tNode count: ").Append(resource.NodeCount)
                .Append("\n\tPriority: ").Append(resource.Priority)
                .Append("\n\tExecution state: ").Append(resource.ExecutionState)
                .Append("\n\tExecution state transition time: ").Append(resource.ExecutionStateTransitionTime)
                .Append("\n\tTool type: ").Append(resource.ToolType)
                .Append("\n\tExperiment name: ").Append(resource.ExperimentName);
            Utilities.Log(sb.ToString());
        }

        public static void CreateCertificate(string domainName, string pfxPath, string password)
        {
            if (!IsRunningMocked)
            {
                string args = string.Format(
                    @".\createCert.ps1 -pfxFileName {0} -pfxPassword ""{1}"" -domainName ""{2}""",
                    pfxPath,
                    password,
                    domainName);
                ProcessStartInfo info = new ProcessStartInfo("powershell", args);
                string assetPath = Path.Combine(ProjectPath, "Asset");
                info.WorkingDirectory = assetPath;
                Process.Start(info).WaitForExit();
            }
            else
            {
                //File.Copy(
                //    Path.Combine(Utilities.ProjectPath, "Asset", "SampleTestCertificate.pfx"),
                //    Path.Combine(Utilities.ProjectPath, "Asset", pfxPath),
                //    overwrite: true);
            }
        }

        public static void CreateCertificate(string domainName, string pfxName, string cerName, string password)
        {
            if (!IsRunningMocked)
            {
                string args = string.Format(
                    @".\createCert1.ps1 -pfxFileName {0} -cerFileName {1} -pfxPassword ""{2}"" -domainName ""{3}""",
                    pfxName,
                    cerName,
                    password,
                    domainName);
                ProcessStartInfo info = new ProcessStartInfo("powershell", args);
                string assetPath = Path.Combine(ProjectPath, "Asset");
                info.WorkingDirectory = assetPath;
                Process.Start(info).WaitForExit();
            }
            else
            {
                //File.Copy(
                //    Path.Combine(Utilities.ProjectPath, "Asset", "SampleTestCertificate.pfx"),
                //    Path.Combine(Utilities.ProjectPath, "Asset", pfxName),
                //    overwrite: true);
            }
        }

        public static void UploadFileToWebApp(IPublishingProfile profile, string filePath, string fileName = null)
        {
            if (!IsRunningMocked)
            {
                string host = profile.FtpUrl.Split(new char[] { '/' }, 2)[0];

                using (var ftpClient = new FtpClient(new FtpClientConfiguration
                {
                    Host = host,
                    Username = profile.FtpUsername,
                    Password = profile.FtpPassword
                }))
                {
                    var fileinfo = new FileInfo(filePath);
                    ftpClient.LoginAsync().GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "site"))
                    {
                        ftpClient.CreateDirectoryAsync("site").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./site").GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "wwwroot"))
                    {
                        ftpClient.CreateDirectoryAsync("wwwroot").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./wwwroot").GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "webapps"))
                    {
                        ftpClient.CreateDirectoryAsync("webapps").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./webapps").GetAwaiter().GetResult();

                    if (fileName == null)
                    {
                        fileName = Path.GetFileName(filePath);
                    }
                    while (fileName.Contains("/"))
                    {
                        int slash = fileName.IndexOf("/");
                        string subDir = fileName.Substring(0, slash);
                        ftpClient.CreateDirectoryAsync(subDir).GetAwaiter().GetResult();
                        ftpClient.ChangeWorkingDirectoryAsync("./" + subDir);
                        fileName = fileName.Substring(slash + 1);
                    }

                    using (var writeStream = ftpClient.OpenFileWriteStreamAsync(fileName).GetAwaiter().GetResult())
                    {
                        var fileReadStream = fileinfo.OpenRead();
                        fileReadStream.CopyToAsync(writeStream).GetAwaiter().GetResult();
                    }
                }
            }
        }
        public static void UploadFileToFunctionApp(IPublishingProfile profile, string filePath, string fileName = null)
        {
            if (!IsRunningMocked)
            {
                string host = profile.FtpUrl.Split(new char[] { '/' }, 2)[0];

                using (var ftpClient = new FtpClient(new FtpClientConfiguration
                {
                    Host = host,
                    Username = profile.FtpUsername,
                    Password = profile.FtpPassword
                }))
                {
                    var fileinfo = new FileInfo(filePath);
                    ftpClient.LoginAsync().GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "site"))
                    {
                        ftpClient.CreateDirectoryAsync("site").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./site").GetAwaiter().GetResult();
                    if (!ftpClient.ListDirectoriesAsync().GetAwaiter().GetResult().Any(fni => fni.Name == "wwwroot"))
                    {
                        ftpClient.CreateDirectoryAsync("wwwroot").GetAwaiter().GetResult();
                    }
                    ftpClient.ChangeWorkingDirectoryAsync("./wwwroot").GetAwaiter().GetResult();

                    if (fileName == null)
                    {
                        fileName = Path.GetFileName(filePath);
                    }
                    while (fileName.Contains("/"))
                    {
                        int slash = fileName.IndexOf("/");
                        string subDir = fileName.Substring(0, slash);
                        ftpClient.CreateDirectoryAsync(subDir).GetAwaiter().GetResult();
                        ftpClient.ChangeWorkingDirectoryAsync("./" + subDir);
                        fileName = fileName.Substring(slash + 1);
                    }

                    using (var writeStream = ftpClient.OpenFileWriteStreamAsync(fileName).GetAwaiter().GetResult())
                    {
                        var fileReadStream = fileinfo.OpenRead();
                        fileReadStream.CopyToAsync(writeStream).GetAwaiter().GetResult();
                    }
                }
            }
        }

        public static void UploadFilesToContainer(string connectionString, string containerName, params string[] filePaths)
        {
            if (!IsRunningMocked)
            {
                CloudStorageAccount storageAccount;

                try
                {
                    storageAccount = CloudStorageAccount.Parse(connectionString);
                }
                catch (FormatException)
                {
                    Utilities.Log("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                    Utilities.ReadLine();
                    throw;
                }
                catch (ArgumentException)
                {
                    Utilities.Log("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                    Utilities.ReadLine();
                    throw;
                }

                // Create a blob client for interacting with the blob service.
                var blobClient = storageAccount.CreateCloudBlobClient();

                // Create a container for organizing blobs within the storage account.
                Utilities.Log("1. Creating Container");
                var container = blobClient.GetContainerReference(containerName);
                container.CreateIfNotExistsAsync().GetAwaiter().GetResult();

                var containerPermissions = new BlobContainerPermissions();
                // Include public access in the permissions object
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
                // Set the permissions on the container
                container.SetPermissionsAsync(containerPermissions).GetAwaiter().GetResult();

                foreach (var filePath in filePaths)
                {
                    var blob = container.GetBlockBlobReference(Path.GetFileName(filePath));
                    blob.UploadFromFileAsync(filePath).GetAwaiter().GetResult();
                }
            }
        }

        public static void CreateContainer(string connectionString, string containerName)
        {
            if (!IsRunningMocked)
            {
                CloudStorageAccount storageAccount;
                try
                {
                    storageAccount = CloudStorageAccount.Parse(connectionString);
                }
                catch (FormatException)
                {
                    Utilities.Log("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                    Utilities.ReadLine();
                    throw;
                }
                catch (ArgumentException)
                {
                    Utilities.Log("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                    Utilities.ReadLine();
                    throw;
                }
                // Create a blob client for interacting with the blob service.
                var blobClient = storageAccount.CreateCloudBlobClient();
                // Create a container for organizing blobs within the storage account.
                Utilities.Log("Creating Container");
                var container = blobClient.GetContainerReference(containerName);
                container.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            }
        }


        public static void DeployByGit(IPublishingProfile profile, string repository)
        {
            if (!IsRunningMocked)
            {
                string gitCommand = "git";
                string gitInitArgument = @"init";
                string gitAddArgument = @"add -A";
                string gitCommitArgument = @"commit -am ""Initial commit"" ";
                string gitPushArgument = $"push https://{profile.GitUsername}:{profile.GitPassword}@{profile.GitUrl} master:master -f";

                ProcessStartInfo info = new ProcessStartInfo(gitCommand, gitInitArgument);
                info.WorkingDirectory = Path.Combine(ProjectPath, "Asset", repository);
                Process.Start(info).WaitForExit();
                info.Arguments = gitAddArgument;
                Process.Start(info).WaitForExit();
                info.Arguments = gitCommitArgument;
                Process.Start(info).WaitForExit();
                info.Arguments = gitPushArgument;
                Process.Start(info).WaitForExit();
            }
        }

        public static string CheckAddress(string url, IDictionary<string, string> headers = null)
        {
            if (!IsRunningMocked)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromSeconds(300);
                        if (headers != null)
                        {
                            foreach (var header in headers)
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }
                        return client.GetAsync(url).Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    }
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
                }
            }

            return "[Running in PlaybackMode]";
        }

        public static string PostAddress(string url, string body, IDictionary<string, string> headers = null)
        {
            if (!IsRunningMocked)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        if (headers != null)
                        {
                            foreach (var header in headers)
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }
                        return client.PostAsync(url, new StringContent(body)).Result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
                }
            }

            return "[Running in PlaybackMode]";
        }

        public static void DeprovisionAgentInLinuxVM(string host, int port, string userName, string password)
        {
            if (!IsRunningMocked)
            {
                Console.WriteLine("Trying to de-provision: " + host);
                Console.WriteLine("ssh connection status: " + TrySsh(
                    host,
                    port,
                    userName,
                    password,
                    "sudo waagent -deprovision+user --force"));
            }
        }

        public static string GetArmTemplate(string templateFileName)
        {
            var adminUsername = "tirekicker";
            var adminPassword = "12NewPA$$w0rd!";
            var hostingPlanName = SdkContext.RandomResourceName("hpRSAT", 24);
            var webAppName = SdkContext.RandomResourceName("wnRSAT", 24);
            var armTemplateString = File.ReadAllText(Path.Combine(Utilities.ProjectPath, "Asset", templateFileName));

            var parsedTemplate = JObject.Parse(armTemplateString);

            if (String.Equals("ArmTemplate.json", templateFileName, StringComparison.OrdinalIgnoreCase))
            {
                parsedTemplate.SelectToken("parameters.hostingPlanName")["defaultValue"] = hostingPlanName;
                parsedTemplate.SelectToken("parameters.webSiteName")["defaultValue"] = webAppName;
                parsedTemplate.SelectToken("parameters.skuName")["defaultValue"] = "B1";
                parsedTemplate.SelectToken("parameters.skuCapacity")["defaultValue"] = 1;
            }
            else if (String.Equals("ArmTemplateVM.json", templateFileName, StringComparison.OrdinalIgnoreCase))
            {
                parsedTemplate.SelectToken("parameters.adminUsername")["defaultValue"] = adminUsername;
                parsedTemplate.SelectToken("parameters.adminPassword")["defaultValue"] = adminPassword;
            }
            return parsedTemplate.ToString();
        }

        public static string GetCertificatePath(string certificateName)
        {
            return Path.Combine(Utilities.ProjectPath, "Asset", certificateName);
        }

        public static void SendMessageToTopic(string connectionString, string topicName, string message)
        {
            if (!IsRunningMocked)
            {
                try
                {
                    var topicClient = new TopicClient(connectionString, topicName);
                    topicClient.SendAsync(new Message(Encoding.UTF8.GetBytes(message))).Wait();
                    topicClient.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        public static void SendMessageToQueue(string connectionString, string queueName, string message)
        {
            if (!IsRunningMocked)
            {
                try
                {
                    var queueClient = new QueueClient(connectionString, queueName, ReceiveMode.PeekLock);
                    queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes(message))).Wait();
                    queueClient.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        private static string TrySsh(
            string host,
            int port,
            string userName,
            string password,
            string commandToExecute)
        {
            string commandOutput = null;
            var backoffTime = 30 * 1000;
            var retryCount = 3;

            while (retryCount > 0)
            {
                using (var sshClient = new SshClient(host, port, userName, password))
                {
                    try
                    {
                        sshClient.Connect();
                        if (commandToExecute != null)
                        {
                            using (var command = sshClient.CreateCommand(commandToExecute))
                            {
                                commandOutput = command.Execute();
                            }
                        }
                        break;
                    }
                    catch (Exception exception)
                    {
                        retryCount--;
                        if (retryCount == 0)
                        {
                            throw exception;
                        }
                    }
                    finally
                    {
                        try
                        {
                            sshClient.Disconnect();
                        }
                        catch { }
                    }
                }
                SdkContext.DelayProvider.Delay(backoffTime);
            }

            return commandOutput;
        }
    }
}
