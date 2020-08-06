// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App or Function App.
    /// </summary>
    public interface IWebSiteBase : IResource, IHasResourceGroup, IHasInner<Models.SiteInner>
    {
        /// <summary>
        /// Gets hostnames associated with the app.
        /// </summary>
        IList<string> HostNames { get; }

        /// <summary>
        /// Gets name of the repository site.
        /// </summary>
        string RepositorySiteName { get; }

        /// <summary>
        /// Gets state indicating whether the app has exceeded its quota usage.
        /// Read-only. Possible values include: 'Normal', 'Exceeded'
        /// </summary>
        UsageState? UsageState { get; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the
        /// app is enabled; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;. Setting this value
        /// to false disables the app (takes the app offline).
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Gets enabled hostnames for the app.Hostnames need to be assigned
        /// (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </summary>
        IList<string> EnabledHostNames { get; }

        /// <summary>
        /// Gets management information availability state for the app.
        /// Possible values include: 'Normal', 'Limited',
        /// 'DisasterRecoveryMode'
        /// </summary>
        SiteAvailabilityState? AvailabilityState { get; }

        /// <summary>
        /// Gets hostname SSL states are used to manage the SSL
        /// bindings for app's hostnames.
        /// </summary>
        IList<HostNameSslState> HostNameSslStates { get; }

        /// <summary>
        /// Gets resource ID of the associated App Service plan,
        /// formatted as:
        /// "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        string ServerFarmId { get; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if
        /// reserved; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        bool? Reserved { get; }

        /// <summary>
        /// Gets hyper-V sandbox.
        /// </summary>
        bool? HyperV { get; }

        /// <summary>
        /// Gets last time the app was modified, in UTC. Read-only.
        /// </summary>
        System.DateTime? LastModifiedTimeUtc { get; }

        /// <summary>
        /// Gets azure Traffic Manager hostnames associated with the app.
        /// Read-only.
        /// </summary>
        IList<string> TrafficManagerHostNames { get; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; to stop
        /// SCM (KUDU) site when the app is stopped; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;. The default is
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        bool ScmSiteAlsoStopped { get; }

        /// <summary>
        /// Gets specifies which deployment slot this app will swap into.
        /// Read-only.
        /// </summary>
        string TargetSwapSlot { get; }

        /// <summary>
        /// Gets app Service Environment to use for the app.
        /// </summary>
        HostingEnvironmentProfile HostingEnvironmentProfile { get; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; to
        /// enable client affinity;
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt; to stop sending
        /// session affinity cookies, which route client requests in the same
        /// session to the same instance. Default is
        /// &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt;.
        /// </summary>
        bool ClientAffinityEnabled { get; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; to
        /// enable client certificate authentication (TLS mutual
        /// authentication); otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;. Default is
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        bool ClientCertEnabled { get; }

        /// <summary>
        /// Gets client certificate authentication comma-separated
        /// exclusion paths
        /// </summary>
        string ClientCertExclusionPaths { get; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; to
        /// disable the hostnames of the app; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// If &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt;, the app is only
        /// accessible via API management process.
        /// </summary>
        bool HostNamesDisabled { get; }

        /// <summary>
        /// Gets list of IP addresses that the app uses for outbound
        /// connections (e.g. database access). Includes VIPs from tenants that
        /// site can be hosted with current settings. Read-only.
        /// </summary>
        string OutboundIpAddresses { get; }

        /// <summary>
        /// Gets list of IP addresses that the app uses for outbound
        /// connections (e.g. database access). Includes VIPs from all tenants
        /// except dataComponent. Read-only.
        /// </summary>
        string PossibleOutboundIpAddresses { get; }

        /// <summary>
        /// Gets size of the function container.
        /// </summary>
        int? ContainerSize { get; }

        /// <summary>
        /// Gets maximum allowed daily memory-time quota (applicable on
        /// dynamic apps only).
        /// </summary>
        int? DailyMemoryTimeQuota { get; }

        /// <summary>
        /// Gets app suspended till in case memory-time quota is exceeded.
        /// </summary>
        System.DateTime? SuspendedTill { get; }

        /// <summary>
        /// Gets maximum number of workers.
        /// This only applies to Functions container.
        /// </summary>
        int? MaxNumberOfWorkers { get; }

        /// <summary>
        /// Gets if specified during app creation, the app is cloned
        /// from a source app.
        /// </summary>
        CloningInfo CloningInfo { get; }

        /// <summary>
        /// Gets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the app is a
        /// default container; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        bool IsDefaultContainer { get; }

        /// <summary>
        /// Gets default hostname of the app. Read-only.
        /// </summary>
        string DefaultHostName { get; }

        /// <summary>
        /// Gets status of the last deployment slot swap operation.
        /// </summary>
        SlotSwapStatus SlotSwapStatus { get; }

        /// <summary>
        /// Gets httpsOnly: configures a web site to accept only https
        /// requests. Issues redirect for
        /// http requests
        /// </summary>
        bool HttpsOnly { get; }

        /// <summary>
        /// Gets site redundancy mode. Possible values include: 'None',
        /// 'Manual', 'Failover', 'ActiveActive', 'GeoRedundant'
        /// </summary>
        RedundancyMode? RedundancyMode { get; }

        /// <summary>
        /// </summary>
        ManagedServiceIdentity Identity { get; }

        /// <summary>
        /// Gets kind of resource.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets the operating system.
        /// </summary>
        Fluent.OperatingSystem OperatingSystem { get; }
    }
}
