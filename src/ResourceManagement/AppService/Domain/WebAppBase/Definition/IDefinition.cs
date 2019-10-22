// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A web app definition stage allowing setting if SCM site is also stopped when the web app is stopped.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithScmSiteAlsoStopped<FluentT> 
    {

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithScmSiteAlsoStopped(bool scmSiteAlsoStopped);
    }

    /// <summary>
    /// A web app definition stage allowing diagnostic logging to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithDiagnosticLogging<FluentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <summary>
        /// Gets Specifies the definition of a new diagnostic logs configuration.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an diagnostic logs definition.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.WebAppDiagnosticLogs.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineDiagnosticLogsConfiguration();

        /// <summary>
        /// Disable the container logging for Linux web apps.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithContainerLoggingDisabled();

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// </summary>
        /// <param name="quotaInMB">The limit that restricts file system usage by app diagnostics logs. Value can range from 25 MB and 100 MB.</param>
        /// <param name="retentionDays">Maximum days of logs that will be available.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithContainerLoggingEnabled(int quotaInMB, int retentionDays);

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// Logs will be stored on the file system for up to 35 MB.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithContainerLoggingEnabled();
    }

    /// <summary>
    /// The stage of the System Assigned (Local) Managed Service Identity enabled web app allowing to
    /// set access role for the identity.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>
    {

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on an ARM resource identified by the resource ID. Applications running
        /// on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role);

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.
        /// Applications running on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId);

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on the resource group that web app resides. Applications running
        /// on the web app will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role);

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that web app resides.
        /// Applications running on the web app will have the same permission (role) on the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId);
    }

    /// <summary>
    /// A web app definition stage allowing SSL binding to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithHostNameSslBinding<FluentT> 
    {

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineSslBinding();
    }

    /// <summary>
    /// A web app definition stage allowing app settings to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithAppSettings<FluentT> 
    {

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAppSetting(string key, string value);

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAppSettings(IDictionary<string,string> settings);

        /// <summary>
        /// Adds an app setting to the web app. This app setting will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithStickyAppSetting(string key, string value);

        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithStickyAppSettings(IDictionary<string,string> settings);
    }

    /// <summary>
    /// A web app definition stage allowing disabling the web app upon creation.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteEnabled<FluentT> 
    {

        /// <summary>
        /// Disables the web app upon creation.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAppDisabledOnCreation();
    }

    /// <summary>
    /// A web app definition stage allowing setting if client cert is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientCertEnabled<FluentT> 
    {

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithClientCertEnabled(bool enabled);
    }

    /// <summary>
    /// The entirety of the web app base definition.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IDefinition<FluentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithWebContainer<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT>
    {

    }

    /// <summary>
    /// A web app definition stage allowing connection strings to be set.
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithConnectionString(string name, string value, ConnectionStringType type);

        /// <summary>
        /// Adds a connection string to the web app. This connection string will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithStickyConnectionString(string name, string value, ConnectionStringType type);
    }

    /// <summary>
    /// A web app definition stage allowing setting if client affinity is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientAffinityEnabled<FluentT> 
    {

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithClientAffinityEnabled(bool enabled);
    }

    /// <summary>
    /// A web app definition stage allowing host name binding to be specified.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithHostNameBinding<FluentT> 
    {

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineHostnameBinding();

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames);

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithThirdPartyHostnameBinding(string domain, params string[] hostnames);
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
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineAuthentication();
    }

    /// <summary>
    /// A site definition with sufficient inputs to create a new web app /
    /// deployments slot in the cloud, but exposing additional optional
    /// inputs to specify.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithCreate<FluentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<FluentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithClientAffinityEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithClientCertEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithScmSiteAlsoStopped<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSiteConfigs<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithAppSettings<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithConnectionString<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSourceControl<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameSslBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithAuthentication<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithDiagnosticLogging<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithManagedServiceIdentity<FluentT>
    {

    }

    /// <summary>
    /// A web app definition stage allowing Java web container to be set. This is required
    /// after specifying Java version.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithWebContainer<FluentT> 
    {

        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithWebContainer(WebContainer webContainer);
    }

    /// <summary>
    /// The stage of the web app update allowing to add User Assigned (External) Managed Service Identities.
    /// </summary>
    public interface IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>
    {

        /// <summary>
        /// Specifies an existing user assigned identity to be associated with the web app.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT> WithExistingUserAssignedManagedServiceIdentity(IIdentity identity);

        /// <summary>
        /// Specifies the definition of a not-yet-created user assigned identity to be associated with the web app.
        /// </summary>
        /// <param name="creatableIdentity">A creatable identity definition.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT> WithNewUserAssignedManagedServiceIdentity(ICreatable<IIdentity> creatableIdentity);

        /// <summary>
        /// Specifies that an user assigned identity associated with the web app should be removed.
        /// </summary>
        /// <param name="identityId">ARM resource id of the identity.</param>
        /// <return>The next stage of the virtual machine update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutUserAssignedManagedServiceIdentity(string identityId);
    }

    /// <summary>
    /// A web app definition stage allowing other configurations to be set. These configurations
    /// can be cloned when creating or swapping with a deployment slot.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteConfigs<FluentT> 
    {

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAutoSwapSlotName(string slotName);

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithDefaultDocument(string document);

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithDefaultDocuments(IList<string> documents);

        /// <summary>
        /// Sets whether the web app supports certain type of FTP(S).
        /// </summary>
        /// <param name="ftpsState">The FTP(S) configuration.</param>
        /// <return>The next stage of web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithFtpsState(FtpsState ftpsState);

        /// <summary>
        /// Sets whether the web app accepts HTTP 2.0 traffic.
        /// </summary>
        /// <param name="http20Enabled">True if the web app accepts HTTP 2.0 traffic.</param>
        /// <return>The next stage of web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithHttp20Enabled(bool http20Enabled);

        /// <summary>
        /// Sets whether the web app only accepts HTTPS traffic.
        /// </summary>
        /// <param name="httpsOnly">True if the web app only accepts HTTPS traffic.</param>
        /// <return>The next stage of web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithHttpsOnly(bool httpsOnly);

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithWebContainer<FluentT> WithJavaVersion(JavaVersion version);

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode);

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithNetFrameworkVersion(NetFrameworkVersion version);

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithoutDefaultDocument(string document);

        /// <summary>
        /// Turn off PHP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithoutPhp();

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithPhpVersion(PhpVersion version);

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithPlatformArchitecture(PlatformArchitecture platform);

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithPythonVersion(PythonVersion version);

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithRemoteDebuggingDisabled();

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion);

        /// <summary>
        /// Sets the virtual applications in the web app.
        /// </summary>
        /// <param name="virtualApplications">The list of virtual applications in the web app.</param>
        /// <return>The next stage of web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithVirtualApplications(IList<Microsoft.Azure.Management.AppService.Fluent.Models.VirtualApplication> virtualApplications);

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithWebAppAlwaysOn(bool alwaysOn);

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithWebSocketsEnabled(bool enabled);
    }

    /// <summary>
    /// A web app definition stage allowing System Assigned Managed Service Identity to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithManagedServiceIdentity<FluentT> 
    {

        /// <summary>
        /// Specifies that System Assigned (Local) Managed Service Identity needs to be disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSystemAssignedManagedServiceIdentity();

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WithSystemAssignedManagedServiceIdentity();

        /// <summary>
        /// Specifies that User Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT> WithUserAssignedManagedServiceIdentity();
    }

    /// <summary>
    /// A web app definition stage allowing source control to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSourceControl<FluentT> 
    {

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineSourceControl();

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithLocalGitSourceControl();
    }
}