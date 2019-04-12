// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The template for a site update operation, containing all the settings that can be modified.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IUpdate<FluentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<FluentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithClientAffinityEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithClientCertEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithScmSiteAlsoStopped<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithSiteConfigs<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithAppSettings<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithConnectionString<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithSourceControl<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithHostNameBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithHostNameSslBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithAuthentication<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithDiagnosticLogging<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithManagedServiceIdentity<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithSystemAssignedIdentityBasedAccess<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithUserAssignedManagedServiceIdentityBasedAccess<FluentT>
    {

    }

    /// <summary>
    /// A web app definition stage allowing System Assigned Managed Service Identity to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithManagedServiceIdentity<FluentT> 
    {

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithSystemAssignedManagedServiceIdentity();

        /// <summary>
        /// Specifies that User Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithUserAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// The stage of the web app update allowing host name binding to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithHostNameBinding<FluentT> 
    {

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding update.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineHostnameBinding();

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames);

        /// <summary>
        /// Unbinds a hostname from the web app.
        /// </summary>
        /// <param name="hostname">The hostname to unbind.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutHostnameBinding(string hostname);

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithThirdPartyHostnameBinding(string domain, params string[] hostnames);
    }

    /// <summary>
    /// A web app update stage allowing app settings to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithAppSettings<FluentT> 
    {

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSetting(string key, string value);

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSettings(IDictionary<string,string> settings);

        /// <summary>
        /// Changes the stickiness of an app setting.
        /// </summary>
        /// <param name="key">The key of the app setting to change stickiness.</param>
        /// <param name="sticky">True if the app setting sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSettingStickiness(string key, bool sticky);

        /// <summary>
        /// Removes an app setting from the web app.
        /// </summary>
        /// <param name="key">The key of the app setting to remove.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutAppSetting(string key);

        /// <summary>
        /// Adds an app setting to the web app. This app setting
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyAppSetting(string key, string value);

        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyAppSettings(IDictionary<string,string> settings);
    }

    /// <summary>
    /// The stage of the web app update allowing setting if client affinity is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientAffinityEnabled<FluentT> 
    {

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithClientAffinityEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the web app update allowing setting if SCM site is also stopped when the web app is stopped.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithScmSiteAlsoStopped<FluentT> 
    {

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithScmSiteAlsoStopped(bool scmSiteAlsoStopped);
    }

    /// <summary>
    /// The stage of the web app update allowing SSL binding to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithHostNameSslBinding<FluentT> 
    {

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineSslBinding();

        /// <summary>
        /// Removes an SSL binding for a specific hostname.
        /// </summary>
        /// <param name="hostname">The hostname to remove SSL certificate from.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSslBinding(string hostname);
    }

    /// <summary>
    /// A web app update stage allowing connection strings to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithConnectionString<FluentT> 
    {

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithConnectionString(string name, string value, ConnectionStringType type);

        /// <summary>
        /// Changes the stickiness of a connection string.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="sticky">True if the connection string sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithConnectionStringStickiness(string name, bool sticky);

        /// <summary>
        /// Removes a connection string from the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutConnectionString(string name);

        /// <summary>
        /// Adds a connection string to the web app. This connection string
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyConnectionString(string name, string value, ConnectionStringType type);
    }

    /// <summary>
    /// A web app definition stage allowing authentication to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithAuthentication<FluentT> 
    {

        /// <summary>
        /// Specifies the definition of a new authentication configuration.
        /// </summary>
        /// <return>The first stage of an authentication definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineAuthentication();

        /// <summary>
        /// Turns off the authentication on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutAuthentication();
    }

    /// <summary>
    /// A web app update stage allowing source control to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSourceControl<FluentT> 
    {

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineSourceControl();

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithLocalGitSourceControl();

        /// <summary>
        /// Removes source control for deployment from the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSourceControl();
    }

    /// <summary>
    /// The stage of the System Assigned (Local) Managed Service Identity enabled web app allowing to
    /// set access role for the identity.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSystemAssignedIdentityBasedAccess<FluentT> 
    {

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on an ARM resource identified by the resource ID. Applications running
        /// on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.
        /// Applications running on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on the resource group that web app resides. Applications running
        /// on the web app will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that web app resides.
        /// Applications running on the web app will have the same permission (role) on the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId);

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSystemAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// The stage of the web app update allowing setting if client cert is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientCertEnabled<FluentT> 
    {

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithClientCertEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the web app update allowing disabling the web app upon creation.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteEnabled<FluentT> 
    {

        /// <summary>
        /// Disables the web app upon creation.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppDisabledOnCreation();
    }

    /// <summary>
    /// A web app definition stage allowing diagnostic logging to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithDiagnosticLogging<FluentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets Specifies the update of an existing diagnostic logs configuration.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an diagnostic logs update.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Update.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> UpdateDiagnosticLogsConfiguration();

        /// <summary>
        /// Disable the container logging for Linux web apps.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithContainerLoggingDisabled();

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// </summary>
        /// <param name="quotaInMB">The limit that restricts file system usage by app diagnostics logs. Value can range from 25 MB and 100 MB.</param>
        /// <param name="retentionDays">Maximum days of logs that will be available.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithContainerLoggingEnabled(int quotaInMB, int retentionDays);

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// Logs will be stored on the file system for up to 35 MB.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithContainerLoggingEnabled();
    }

    /// <summary>
    /// The stage of the web app update allowing other configurations to be set. These configurations
    /// can be cloned when creating or swapping with a deployment slot.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteConfigs<FluentT> 
    {

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAutoSwapSlotName(string slotName);

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithDefaultDocument(string document);

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithDefaultDocuments(IList<string> documents);

        /// <summary>
        /// Sets whether the web app supports certain type of FTP(S).
        /// </summary>
        /// <param name="ftpsState">The FTP(S) configuration.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithFtpsState(FtpsState ftpsState);

        /// <summary>
        /// Sets whether the web app accepts HTTP 2.0 traffic.
        /// </summary>
        /// <param name="http20Enabled">True if the web app accepts HTTP 2.0 traffic.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithHttp20Enabled(bool http20Enabled);

        /// <summary>
        /// Sets whether the web app only accepts HTTPS traffic.
        /// </summary>
        /// <param name="httpsOnly">True if the web app only accepts HTTPS traffic.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithHttpsOnly(bool httpsOnly);

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithWebContainer<FluentT> WithJavaVersion(JavaVersion version);

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode);

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithNetFrameworkVersion(NetFrameworkVersion version);

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutDefaultDocument(string document);

        /// <summary>
        /// Turn off Java support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutJava();

        /// <summary>
        /// Turn off Python support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutPython();

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPhpVersion(PhpVersion version);

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPlatformArchitecture(PlatformArchitecture platform);

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPythonVersion(PythonVersion version);

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithRemoteDebuggingDisabled();

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion);

        /// <summary>
        /// Sets the virtual applications in the web app.
        /// </summary>
        /// <param name="virtualApplications">The list of virtual applications in the web app.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithVirtualApplications(IList<Microsoft.Azure.Management.AppService.Fluent.Models.VirtualApplication> virtualApplications);

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebAppAlwaysOn(bool alwaysOn);

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebSocketsEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the web app update allowing to add User Assigned (External) Managed Service Identities.
    /// </summary>
    public interface IWithUserAssignedManagedServiceIdentityBasedAccess<FluentT> 
    {

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the web app.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithExistingUserAssignedManagedServiceIdentity(IIdentity identity);

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the web app.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithNewUserAssignedManagedServiceIdentity(ICreatable<IIdentity> creatableIdentity);

        /// <summary>
        /// Specifies that an user assigned identity associated with the web app should be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>The next stage of the virtual machine update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutUserAssignedManagedServiceIdentity(string identityId);
    }

    /// <summary>
    /// The stage of the web app update allowing Java web container to be set. This is required
    /// after specifying Java version.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithWebContainer<FluentT> 
    {

        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebContainer(WebContainer webContainer);
    }
}