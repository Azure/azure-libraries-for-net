// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;
    using System.IO;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App or deployment slot.
    /// </summary>
    public interface IWebAppBase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager,Models.SiteInner>
    {
        /// <summary>
        /// Gets the version of Python.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PythonVersion PythonVersion { get; }

        /// <summary>
        /// Gets list of IP addresses that this web app uses for
        /// outbound connections. Those can be used when configuring firewall
        /// rules for databases accessed by this web app.
        /// </summary>
        System.Collections.Generic.ISet<string> OutboundIPAddresses { get; }

        /// <return>The zipped archive of docker logs for a Linux web app.</return>
        Stream GetContainerLogsZip();

        /// <return>The authentication configuration defined on the web app.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IWebAppAuthentication> GetAuthenticationConfigAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The last lines of docker logs for a Linux web app.</return>
        Stream GetContainerLogs();

        /// <summary>
        /// Gets list of Azure Traffic manager host names associated with web
        /// app.
        /// </summary>
        System.Collections.Generic.ISet<string> TrafficManagerHostNames { get; }

        /// <summary>
        /// Gets list of SSL states used to manage the SSL bindings for site's hostnames.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.HostNameSslState> HostNameSslStates { get; }

        /// <summary>
        /// Gets the operating system the web app is running on.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.OperatingSystem OperatingSystem { get; }

        /// <summary>
        /// First step specifying the parameters to make a web deployment (MS Deploy) to the web app.
        /// </summary>
        /// <return>A stage to create web deployment.</return>
        WebDeployment.Definition.IWithPackageUri Deploy();

        /// <summary>
        /// Gets if the client certificate is enabled for the web app.
        /// </summary>
        bool ClientCertEnabled { get; }

        /// <summary>
        /// Gets state indicating whether web app has exceeded its quota usage.
        /// </summary>
        Models.UsageState UsageState { get; }

        /// <summary>
        /// Gets if the remote eebugging is enabled.
        /// </summary>
        bool RemoteDebuggingEnabled { get; }

        /// <summary>
        /// Gets the Linux app framework and version if this is a Linux web app.
        /// </summary>
        string LinuxFxVersion { get; }

        /// <summary>
        /// Gets if the client affinity is enabled when load balancing http
        /// request for multiple instances of the web app.
        /// </summary>
        bool ClientAffinityEnabled { get; }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The URL and credentials for publishing through FTP or Git.</return>
        Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile GetPublishingProfile();

        /// <return>The source control information for the web app.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets state of the web app.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets the .NET Framework version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.NetFrameworkVersion NetFrameworkVersion { get; }

        /// <summary>
        /// Gets size of a function container.
        /// </summary>
        int ContainerSize { get; }

        /// <summary>
        /// Gets Java container version.
        /// </summary>
        string JavaContainerVersion { get; }

        /// <summary>
        /// Gets default hostname of the web app.
        /// </summary>
        string DefaultHostName { get; }

        /// <summary>
        /// Gets host names for the web app that are enabled.
        /// </summary>
        System.Collections.Generic.ISet<string> EnabledHostNames { get; }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        /// <param name="slotName">
        /// The target slot to swap with. Use 'production' for
        /// the production slot.
        /// </param>
        void Swap(string slotName);

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        /// <param name="slotName">
        /// The target slot to swap with. Use 'production' for
        /// the production slot.
        /// </param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the version of Node.JS.
        /// </summary>
        string NodeVersion { get; }

        /// <return>The last lines of docker logs for a Linux web app.</return>
        Task<Stream> GetContainerLogsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the auto swap slot name.
        /// </summary>
        string AutoSwapSlotName { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory service principal ID
        /// assigned to the web app.
        /// </summary>
        string SystemAssignedManagedServiceIdentityPrincipalId { get; }

        /// <summary>
        /// Gets The ids of the user assigned identities.
        /// </summary>
        System.Collections.Generic.ISet<string> UserAssignedManagedServiceIdentityIds { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets management information availability state for the web app.
        /// </summary>
        Models.SiteAvailabilityState AvailabilityState { get; }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        void Stop();

        /// <summary>
        /// Gets The resource ID of the app service plan.
        /// </summary>
        string AppServicePlanId { get; }

        /// <return>The source control information for the web app.</return>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl GetSourceControl();

        /// <summary>
        /// Gets if the public hostnames are disabled the web app.
        /// If set to true the app is only accessible via API
        /// Management process.
        /// </summary>
        bool HostNamesDisabled { get; }

        /// <summary>
        /// Gets Java container.
        /// </summary>
        string JavaContainer { get; }

        /// <summary>
        /// Gets the remote debugging version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.RemoteVisualStudioVersion RemoteDebuggingVersion { get; }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory tenant ID assigned
        /// to the web app.
        /// </summary>
        string SystemAssignedManagedServiceIdentityTenantId { get; }

        /// <return>The connection strings defined on the web app.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString>> GetConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The authentication configuration defined on the web app.</return>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppAuthentication GetAuthenticationConfig();

        /// <summary>
        /// Gets Last time web app was modified in UTC.
        /// </summary>
        System.DateTime LastModifiedTime { get; }

        /// <return>The app settings defined on the web app.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting> GetAppSettings();

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        /// <param name="slotName">The target slot to apply configurations from.</param>
        void ApplySlotConfigurations(string slotName);

        /// <summary>
        /// Gets the default documents.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> DefaultDocuments { get; }

        /// <summary>
        /// Gets name of repository site.
        /// </summary>
        string RepositorySiteName { get; }

        /// <summary>
        /// Gets Java version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.JavaVersion JavaVersion { get; }

        /// <return>The zipped archive of docker logs for a Linux web app.</return>
        Task<Stream> GetContainerLogsZipAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets hostnames associated with web app.
        /// </summary>
        System.Collections.Generic.ISet<string> HostNames { get; }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        void ResetSlotConfigurations();

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets true if the site is enabled; otherwise, false.
        /// </summary>
        bool Enabled { get; }

        /// <return>The URL and credentials for publishing through FTP or Git.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets site is a default container.
        /// </summary>
        bool IsDefaultContainer { get; }

        /// <return>The connection strings defined on the web app.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString> GetConnectionStrings();

        /// <summary>
        /// Gets whether to stop SCM (KUDU) site when the web app is
        /// stopped. Default is false.
        /// </summary>
        bool ScmSiteAlsoStopped { get; }

        /// <return>The mapping from host names and the host name bindings.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings();

        /// <summary>
        /// Gets if web socket is enabled.
        /// </summary>
        bool WebSocketsEnabled { get; }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        /// <param name="slotName">The target slot to apply configurations from.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets if the web app is always on.
        /// </summary>
        bool AlwaysOn { get; }

        /// <summary>
        /// Gets the version of PHP.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PhpVersion PhpVersion { get; }

        /// <summary>
        /// Gets information about whether the web app is cloned from another.
        /// </summary>
        Models.CloningInfo CloningInfo { get; }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        void Restart();

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        void Start();

        /// <return>The mapping from host names and the host name bindings.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets managed pipeline mode.
        /// </summary>
        Models.ManagedPipelineMode ManagedPipelineMode { get; }

        /// <summary>
        /// Gets the architecture of the platform, either 32 bit (x86) or 64 bit (x64).
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PlatformArchitecture PlatformArchitecture { get; }

        /// <return>The app settings defined on the web app.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting>> GetAppSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken);

        /// <summary>
        /// Gets which slot this app will swap into.
        /// </summary>
        string TargetSwapSlot { get; }

        /// <summary>
        /// True if the web app is configured to accept only HTTPS requests. HTTP requests will be redirected.
        /// </summary>
        bool HttpsOnly { get; }

        /// <summary>
        /// Gets the state of FTP / FTPS service.
        /// </summary>
        FtpsState FtpsState { get; }

        /// <summary>
        /// Gets the virtual applications and their virtual directories in this web app.
        /// </summary>
        IList<VirtualApplication> VirtualApplications { get; }

        /// <summary>
        /// Gets whether to allow clients to connect over http2.0.
        /// </summary>
        bool Http20Enabled { get; }

        /// <summary>
        /// Gets whether local MySQL is enabled.
        /// </summary>
        bool LocalMySqlEnabled { get; }

        /// <summary>
        /// Gets the SCM configuration for the web app.
        /// </summary>
        ScmType ScmType { get; }

        /// <summary>
        /// Gets the root directory for the web app.
        /// </summary>
        string DocumentRoot { get; }

        /// <summary>
        /// Gets the diagnostic logs configuration.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs DiagnosticLogsConfig { get; }

        /// <summary>
        /// Gets a open stream to the application logs.
        /// </summary>
        Stream StreamApplicationLogs();

        /// <summary>
        /// Gets a open stream to the application logs.
        /// </summary>
        Task<Stream> StreamApplicationLogsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a open stream to the HTTP logs.
        /// </summary>
        Stream StreamHttpLogs();

        /// <summary>
        /// Gets a open stream to the HTTP logs.
        /// </summary>
        Task<Stream> StreamHttpLogsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a open stream to the trace logs.
        /// </summary>
        Stream StreamTraceLogs();

        /// <summary>
        /// Gets a open stream to the trace logs.
        /// </summary>
        Task<Stream> StreamTraceLogsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a open stream to the deployment logs.
        /// </summary>
        Stream StreamDeploymentLogs();

        /// <summary>
        /// Gets a open stream to the deployment logs.
        /// </summary>
        Task<Stream> StreamDeploymentLogsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a open stream to all logs.
        /// </summary>
        Stream StreamAllLogs();

        /// <summary>
        /// Gets a open stream to all logs.
        /// </summary>
        Task<Stream> StreamAllLogsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the minimum version of TLS
        /// required for SSL requests for the web app
        /// </summary>
        SupportedTlsVersions MinTlsVersion { get; }
    }
}