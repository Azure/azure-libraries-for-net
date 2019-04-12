// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="FluentT"></typeparam>
    /// <typeparam name="FluentImplT"></typeparam>
    /// <typeparam name="DefAfterRegionT"></typeparam>
    /// <typeparam name="DefAfterGroupT"></typeparam>
    /// <typeparam name="UpdateT"></typeparam>
    internal abstract partial class WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>
    {
        /// <summary>
        /// Removes source control for deployment from the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSourceControl<FluentT>.WithoutSourceControl()
        {
            return this.WithoutSourceControl();
        }

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSourceControl<FluentT>.WithLocalGitSourceControl()
        {
            return this.WithLocalGitSourceControl();
        }

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        WebAppSourceControl.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithSourceControl<FluentT>.DefineSourceControl()
        {
            return this.DefineSourceControl();
        }

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSourceControl<FluentT>.WithLocalGitSourceControl()
        {
            return this.WithLocalGitSourceControl();
        }

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        WebAppSourceControl.Definition.IBlank<WebAppBase.Definition.IWithCreate<FluentT>> WebAppBase.Definition.IWithSourceControl<FluentT>.DefineSourceControl()
        {
            return this.DefineSourceControl();
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on an ARM resource identified by the resource ID. Applications running
        /// on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSystemAssignedIdentityBasedAccess<FluentT>.WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.
        /// Applications running on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSystemAssignedIdentityBasedAccess<FluentT>.WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId);
        }

        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSystemAssignedIdentityBasedAccess<FluentT>.WithoutSystemAssignedManagedServiceIdentity()
        {
            return this.WithoutSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on the resource group that web app resides. Applications running
        /// on the web app will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSystemAssignedIdentityBasedAccess<FluentT>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that web app resides.
        /// Applications running on the web app will have the same permission (role) on the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSystemAssignedIdentityBasedAccess<FluentT>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId);
        }

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithManagedServiceIdentity<FluentT>.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        ///  Specifies that User Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithManagedServiceIdentity<FluentT>.WithUserAssignedManagedServiceIdentity()
        {
            return this.WithUserAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WebAppBase.Definition.IWithManagedServiceIdentity<FluentT>.WithSystemAssignedManagedServiceIdentity()
        {
            return this.WithSystemAssignedManagedServiceIdentity();
        }

        /// <summary>
        /// Specifies that System Assigned Managed Service Identity needs to be enabled in the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        WebAppBase.Definition.IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT> WebAppBase.Definition.IWithManagedServiceIdentity<FluentT>.WithUserAssignedManagedServiceIdentity()
        {
            return this.WithUserAssignedManagedServiceIdentity();
        }

        IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT> IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT>.WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            return this.WithExistingUserAssignedManagedServiceIdentity(identity);
        }

        IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT> IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT>.WithNewUserAssignedManagedServiceIdentity(ICreatable<IIdentity> creatableIdentity)
        {
            return this.WithNewUserAssignedManagedServiceIdentity(creatableIdentity);
        }

        IUpdate<FluentT> WebAppBase.Definition.IWithManagedServiceIdentity<FluentT>.WithoutSystemAssignedManagedServiceIdentity()
        {
            return this.WithoutSystemAssignedManagedServiceIdentity();
        }


        IUpdate<FluentT> IWithUserAssignedManagedServiceIdentityBasedAccessOrCreate<FluentT>.WithoutUserAssignedManagedServiceIdentity(string identityId)
        {
            return this.WithoutUserAssignedManagedServiceIdentity(identityId);
        }

        IUpdate<FluentT> IWithUserAssignedManagedServiceIdentityBasedAccess<FluentT>.WithExistingUserAssignedManagedServiceIdentity(IIdentity identity)
        {
            return this.WithExistingUserAssignedManagedServiceIdentity(identity);
        }

        IUpdate<FluentT> IWithUserAssignedManagedServiceIdentityBasedAccess<FluentT>.WithoutUserAssignedManagedServiceIdentity(string identityId)
        {
            return this.WithoutUserAssignedManagedServiceIdentity(identityId);
        }

        IUpdate<FluentT> IWithUserAssignedManagedServiceIdentityBasedAccess<FluentT>.WithNewUserAssignedManagedServiceIdentity(ICreatable<IIdentity> creatableIdentity)
        {
            return this.WithNewUserAssignedManagedServiceIdentity(creatableIdentity);
        }

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithScmSiteAlsoStopped<FluentT>.WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            return this.WithScmSiteAlsoStopped(scmSiteAlsoStopped);
        }

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithScmSiteAlsoStopped<FluentT>.WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            return this.WithScmSiteAlsoStopped(scmSiteAlsoStopped);
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on an ARM resource identified by the resource ID. Applications running
        /// on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">The ARM identifier of the resource.</param>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT>.WithSystemAssignedIdentityBasedAccessTo(string resourceId, BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, role);
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on an ARM resource identified by the resource ID.
        /// Applications running on the web app will have the same permission (role) on the ARM resource.
        /// </summary>
        /// <param name="resourceId">Scope of the access represented in ARM resource ID format.</param>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT>.WithSystemAssignedIdentityBasedAccessTo(string resourceId, string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessTo(resourceId, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the given access
        /// (described by the role) on the resource group that web app resides. Applications running
        /// on the web app will have the same permission (role) on the resource group.
        /// </summary>
        /// <param name="role">Access role to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(role);
        }

        /// <summary>
        /// Specifies that web app's system assigned (local) identity should have the access
        /// (described by the role definition) on the resource group that web app resides.
        /// Applications running on the web app will have the same permission (role) on the
        /// resource group.
        /// </summary>
        /// <param name="roleDefinitionId">Access role definition to assigned to the web app's local identity.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT> WebAppBase.Definition.IWithSystemAssignedIdentityBasedAccessOrCreate<FluentT>.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithSystemAssignedIdentityBasedAccessToCurrentResourceGroup(roleDefinitionId);
        }

        /// <summary>
        /// Changes the stickiness of an app setting.
        /// </summary>
        /// <param name="key">The key of the app setting to change stickiness.</param>
        /// <param name="sticky">True if the app setting sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithAppSettingStickiness(string key, bool sticky)
        {
            return this.WithAppSettingStickiness(key, sticky);
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithStickyAppSettings(IDictionary<string,string> settings)
        {
            return this.WithStickyAppSettings(settings);
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithAppSettings(IDictionary<string,string> settings)
        {
            return this.WithAppSettings(settings);
        }

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithAppSetting(string key, string value)
        {
            return this.WithAppSetting(key, value);
        }

        /// <summary>
        /// Removes an app setting from the web app.
        /// </summary>
        /// <param name="key">The key of the app setting to remove.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithoutAppSetting(string key)
        {
            return this.WithoutAppSetting(key);
        }

        /// <summary>
        /// Adds an app setting to the web app. This app setting
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithStickyAppSetting(string key, string value)
        {
            return this.WithStickyAppSetting(key, value);
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithStickyAppSettings(IDictionary<string,string> settings)
        {
            return this.WithStickyAppSettings(settings);
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithAppSettings(IDictionary<string,string> settings)
        {
            return this.WithAppSettings(settings);
        }

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithAppSetting(string key, string value)
        {
            return this.WithAppSetting(key, value);
        }

        /// <summary>
        /// Adds an app setting to the web app. This app setting will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithStickyAppSetting(string key, string value)
        {
            return this.WithStickyAppSetting(key, value);
        }

        /// <summary>
        /// Turns off the authentication on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAuthentication<FluentT>.WithoutAuthentication()
        {
            return this.WithoutAuthentication();
        }

        /// <summary>
        /// Specifies the definition of a new authentication configuration.
        /// </summary>
        /// <return>The first stage of an authentication definition.</return>
        WebAppAuthentication.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithAuthentication<FluentT>.DefineAuthentication()
        {
            return this.DefineAuthentication();
        }

        /// <summary>
        /// Specifies the definition of a new authentication configuration.
        /// </summary>
        /// <return>The first stage of an authentication definition.</return>
        WebAppAuthentication.Definition.IBlank<WebAppBase.Definition.IWithCreate<FluentT>> WebAppBase.Definition.IWithAuthentication<FluentT>.DefineAuthentication()
        {
            return this.DefineAuthentication();
        }

        /// <summary>
        /// Removes an SSL binding for a specific hostname.
        /// </summary>
        /// <param name="hostname">The hostname to remove SSL certificate from.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameSslBinding<FluentT>.WithoutSslBinding(string hostname)
        {
            return this.WithoutSslBinding(hostname);
        }

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        HostNameSslBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithHostNameSslBinding<FluentT>.DefineSslBinding()
        {
            return this.DefineSslBinding();
        }

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        HostNameSslBinding.Definition.IBlank<WebAppBase.Definition.IWithCreate<FluentT>> WebAppBase.Definition.IWithHostNameSslBinding<FluentT>.DefineSslBinding()
        {
            return this.DefineSslBinding();
        }

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithConnectionString(name, value, type);
        }

        /// <summary>
        /// Adds a connection string to the web app. This connection string
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithStickyConnectionString(name, value, type);
        }

        /// <summary>
        /// Removes a connection string from the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithoutConnectionString(string name)
        {
            return this.WithoutConnectionString(name);
        }

        /// <summary>
        /// Changes the stickiness of a connection string.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="sticky">True if the connection string sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithConnectionStringStickiness(string name, bool sticky)
        {
            return this.WithConnectionStringStickiness(name, sticky);
        }

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithConnectionString<FluentT>.WithConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithConnectionString(name, value, type);
        }

        /// <summary>
        /// Adds a connection string to the web app. This connection string will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithConnectionString<FluentT>.WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithStickyConnectionString(name, value, type);
        }

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameBinding<FluentT>.WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            return this.WithThirdPartyHostnameBinding(domain, hostnames);
        }

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameBinding<FluentT>.WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            return this.WithManagedHostnameBindings(domain, hostnames);
        }

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding update.</return>
        HostNameBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithHostNameBinding<FluentT>.DefineHostnameBinding()
        {
            return this.DefineHostnameBinding();
        }

        /// <summary>
        /// Unbinds a hostname from the web app.
        /// </summary>
        /// <param name="hostname">The hostname to unbind.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameBinding<FluentT>.WithoutHostnameBinding(string hostname)
        {
            return this.WithoutHostnameBinding(hostname);
        }

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithHostNameBinding<FluentT>.WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            return this.WithThirdPartyHostnameBinding(domain, hostnames);
        }

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithHostNameBinding<FluentT>.WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            return this.WithManagedHostnameBindings(domain, hostnames);
        }

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding definition.</return>
        HostNameBinding.Definition.IBlank<WebAppBase.Definition.IWithCreate<FluentT>> WebAppBase.Definition.IWithHostNameBinding<FluentT>.DefineHostnameBinding()
        {
            return this.DefineHostnameBinding();
        }

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithDefaultDocuments(IList<string> documents)
        {
            return this.WithDefaultDocuments(documents);
        }

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithWebSocketsEnabled(bool enabled)
        {
            return this.WithWebSocketsEnabled(enabled);
        }

        /// <summary>
        /// Turn off Java support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithoutJava()
        {
            return this.WithoutJava();
        }

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IWithWebContainer<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithJavaVersion(JavaVersion version)
        {
            return this.WithJavaVersion(version);
        }

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithRemoteDebuggingDisabled()
        {
            return this.WithRemoteDebuggingDisabled();
        }

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithWebAppAlwaysOn(bool alwaysOn)
        {
            return this.WithWebAppAlwaysOn(alwaysOn);
        }

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithoutDefaultDocument(string document)
        {
            return this.WithoutDefaultDocument(document);
        }

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithPlatformArchitecture(PlatformArchitecture platform)
        {
            return this.WithPlatformArchitecture(platform);
        }

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithDefaultDocument(string document)
        {
            return this.WithDefaultDocument(document);
        }

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            return this.WithNetFrameworkVersion(version);
        }

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithPhpVersion(PhpVersion version)
        {
            return this.WithPhpVersion(version);
        }

        /// <summary>
        /// Turn off Python support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithoutPython()
        {
            return this.WithoutPython();
        }

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithAutoSwapSlotName(string slotName)
        {
            return this.WithAutoSwapSlotName(slotName);
        }

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            return this.WithRemoteDebuggingEnabled(remoteVisualStudioVersion);
        }

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            return this.WithManagedPipelineMode(managedPipelineMode);
        }

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithPythonVersion(PythonVersion version)
        {
            return this.WithPythonVersion(version);
        }

        /// <summary>
        /// Sets whether the web app only accepts HTTPS traffic.
        /// </summary>
        /// <param name="httpsOnly">true if the web app only accepts HTTPS traffic.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithHttpsOnly(bool httpsOnly)
        {
            return this.WithHttpsOnly(httpsOnly);
        }

        /// <summary>
        /// Sets whether the web app only accepts HTTP 2.0 traffic.
        /// </summary>
        /// <param name="http20Enabled">true if the web app accepts HTTP 2.0 traffic.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithHttp20Enabled(bool http20Enabled)
        {
            return this.WithHttp20Enabled(http20Enabled);
        }

        /// <summary>
        /// Sets whether the web app supports certain type of FTP(S).
        /// </summary>
        /// <param name="ftpsState">the FTP(S) configuration.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithFtpsState(FtpsState ftpsState)
        {
            return this.WithFtpsState(ftpsState);
        }

        /// <summary>
        /// Sets the virtual applications in the web app.
        /// </summary>
        /// <param name="virtualApplications">the list of virtual applications in the web app</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithVirtualApplications(IList<VirtualApplication> virtualApplications)
        {
            return this.WithVirtualApplications(virtualApplications);
        }

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithDefaultDocuments(IList<string> documents)
        {
            return this.WithDefaultDocuments(documents);
        }

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithWebSocketsEnabled(bool enabled)
        {
            return this.WithWebSocketsEnabled(enabled);
        }

        /// <summary>
        /// Turn off PHP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithoutPhp()
        {
            return this.WithoutPhp();
        }

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithWebContainer<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithJavaVersion(JavaVersion version)
        {
            return this.WithJavaVersion(version);
        }

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithRemoteDebuggingDisabled()
        {
            return this.WithRemoteDebuggingDisabled();
        }

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithWebAppAlwaysOn(bool alwaysOn)
        {
            return this.WithWebAppAlwaysOn(alwaysOn);
        }

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithoutDefaultDocument(string document)
        {
            return this.WithoutDefaultDocument(document);
        }

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithPlatformArchitecture(PlatformArchitecture platform)
        {
            return this.WithPlatformArchitecture(platform);
        }

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithDefaultDocument(string document)
        {
            return this.WithDefaultDocument(document);
        }

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            return this.WithNetFrameworkVersion(version);
        }

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithPhpVersion(PhpVersion version)
        {
            return this.WithPhpVersion(version);
        }

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithAutoSwapSlotName(string slotName)
        {
            return this.WithAutoSwapSlotName(slotName);
        }

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            return this.WithRemoteDebuggingEnabled(remoteVisualStudioVersion);
        }

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            return this.WithManagedPipelineMode(managedPipelineMode);
        }

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithPythonVersion(PythonVersion version)
        {
            return this.WithPythonVersion(version);
        }

        /// <summary>
        /// Sets whether the web app only accepts HTTPS traffic.
        /// </summary>
        /// <param name="httpsOnly">true if the web app only accepts HTTPS traffic.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithHttpsOnly(bool httpsOnly)
        {
            return this.WithHttpsOnly(httpsOnly);
        }

        /// <summary>
        /// Sets whether the web app only accepts HTTP 2.0 traffic.
        /// </summary>
        /// <param name="http20Enabled">true if the web app accepts HTTP 2.0 traffic.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithHttp20Enabled(bool http20Enabled)
        {
            return this.WithHttp20Enabled(http20Enabled);
        }

        /// <summary>
        /// Sets whether the web app supports certain type of FTP(S).
        /// </summary>
        /// <param name="ftpsState">the FTP(S) configuration.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithFtpsState(FtpsState ftpsState)
        {
            return this.WithFtpsState(ftpsState);
        }

        /// <summary>
        /// Sets the virtual applications in the web app.
        /// </summary>
        /// <param name="virtualApplications">the list of virtual applications in the web app</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithVirtualApplications(IList<VirtualApplication> virtualApplications)
        {
            return this.WithVirtualApplications(virtualApplications);
        }

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithClientAffinityEnabled<FluentT>.WithClientAffinityEnabled(bool enabled)
        {
            return this.WithClientAffinityEnabled(enabled);
        }

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithClientAffinityEnabled<FluentT>.WithClientAffinityEnabled(bool enabled)
        {
            return this.WithClientAffinityEnabled(enabled);
        }

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// </summary>
        /// <param name="quotaInMB">The limit that restricts file system usage by app diagnostics logs. Value can range from 25 MB and 100 MB.</param>
        /// <param name="retentionDays">Maximum days of logs that will be available.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithDiagnosticLogging<FluentT>.WithContainerLoggingEnabled(int quotaInMB, int retentionDays)
        {
            return this.WithContainerLoggingEnabled(quotaInMB, retentionDays);
        }

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// Logs will be stored on the file system for up to 35 MB.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithDiagnosticLogging<FluentT>.WithContainerLoggingEnabled()
        {
            return this.WithContainerLoggingEnabled();
        }

        /// <summary>
        /// Disable the container logging for Linux web apps.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithDiagnosticLogging<FluentT>.WithContainerLoggingDisabled()
        {
            return this.WithContainerLoggingDisabled();
        }

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// </summary>
        /// <param name="quotaInMB">The limit that restricts file system usage by app diagnostics logs. Value can range from 25 MB and 100 MB.</param>
        /// <param name="retentionDays">Maximum days of logs that will be available.</param>
        /// <return>The next stage of the web app definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithDiagnosticLogging<FluentT>.WithContainerLoggingEnabled(int quotaInMB, int retentionDays)
        {
            return this.WithContainerLoggingEnabled(quotaInMB, retentionDays);
        }

        /// <summary>
        /// Specifies the configuration for container logging for Linux web apps.
        /// Logs will be stored on the file system for up to 35 MB.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithDiagnosticLogging<FluentT>.WithContainerLoggingEnabled()
        {
            return this.WithContainerLoggingEnabled();
        }

        /// <summary>
        /// Disable the container logging for Linux web apps.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithDiagnosticLogging<FluentT>.WithContainerLoggingDisabled()
        {
            return this.WithContainerLoggingDisabled();
        }

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithClientCertEnabled<FluentT>.WithClientCertEnabled(bool enabled)
        {
            return this.WithClientCertEnabled(enabled);
        }

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithClientCertEnabled<FluentT>.WithClientCertEnabled(bool enabled)
        {
            return this.WithClientCertEnabled(enabled);
        }

        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithWebContainer<FluentT>.WithWebContainer(WebContainer webContainer)
        {
            return this.WithWebContainer(webContainer);
        }

        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithWebContainer<FluentT>.WithWebContainer(WebContainer webContainer)
        {
            return this.WithWebContainer(webContainer);
        }

        /// <return>The connection strings defined on the web app.</return>
        async Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString>> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetConnectionStringsAsync(CancellationToken cancellationToken)
        {
            return await this.GetConnectionStringsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets management information availability state for the web app.
        /// </summary>
        Models.SiteAvailabilityState Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AvailabilityState
        {
            get
            {
                return this.AvailabilityState();
            }
        }

        /// <summary>
        /// Gets true if the site is enabled; otherwise, false.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        /// <summary>
        /// Gets the remote debugging version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.RemoteVisualStudioVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.RemoteDebuggingVersion
        {
            get
            {
                return this.RemoteDebuggingVersion();
            }
        }

        /// <summary>
        /// Gets if web socket is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.WebSocketsEnabled
        {
            get
            {
                return this.WebSocketsEnabled();
            }
        }

        /// <summary>
        /// Gets the Linux app framework and version if this is a Linux web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.LinuxFxVersion
        {
            get
            {
                return this.LinuxFxVersion();
            }
        }

        /// <summary>
        /// Gets site is a default container.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.IsDefaultContainer
        {
            get
            {
                return this.IsDefaultContainer();
            }
        }

        /// <summary>
        /// Gets managed pipeline mode.
        /// </summary>
        Models.ManagedPipelineMode Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ManagedPipelineMode
        {
            get
            {
                return this.ManagedPipelineMode();
            }
        }

        /// <summary>
        /// Gets the version of Node.JS.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.NodeVersion
        {
            get
            {
                return this.NodeVersion();
            }
        }

        /// <summary>
        /// Gets name of repository site.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.RepositorySiteName
        {
            get
            {
                return this.RepositorySiteName();
            }
        }

        /// <summary>
        /// Gets if the public hostnames are disabled the web app.
        /// If set to true the app is only accessible via API
        /// Management process.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.HostNamesDisabled
        {
            get
            {
                return this.HostNamesDisabled();
            }
        }

        /// <summary>
        /// Gets the version of PHP.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PhpVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.PhpVersion
        {
            get
            {
                return this.PhpVersion();
            }
        }

        /// <summary>
        /// Gets the operating system the web app is running on.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.OperatingSystem Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.OperatingSystem
        {
            get
            {
                return this.OperatingSystem();
            }
        }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory tenant ID assigned
        /// to the web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.SystemAssignedManagedServiceIdentityTenantId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityTenantId();
            }
        }

        /// <summary>
        /// The user Assigned Identity Ids.
        /// </summary>
        ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.UserAssignedManagedServiceIdentityIds
        {
            get
            {
                return this.UserAssignedManagedServiceIdentityIds();
            }
        }

        /// <summary>
        /// Gets whether to stop SCM (KUDU) site when the web app is
        /// stopped. Default is false.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ScmSiteAlsoStopped
        {
            get
            {
                return this.ScmSiteAlsoStopped();
            }
        }

        /// <summary>
        /// Gets Java container version.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.JavaContainerVersion
        {
            get
            {
                return this.JavaContainerVersion();
            }
        }

        /// <summary>
        /// Gets the auto swap slot name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AutoSwapSlotName
        {
            get
            {
                return this.AutoSwapSlotName();
            }
        }

        /// <return>The connection strings defined on the web app.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetConnectionStrings()
        {
            return this.GetConnectionStrings();
        }

        /// <summary>
        /// Gets state indicating whether web app has exceeded its quota usage.
        /// </summary>
        Models.UsageState Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.UsageState
        {
            get
            {
                return this.UsageState();
            }
        }

        /// <summary>
        /// Gets The resource ID of the app service plan.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AppServicePlanId
        {
            get
            {
                return this.AppServicePlanId();
            }
        }

        /// <summary>
        /// Gets the default documents.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.DefaultDocuments
        {
            get
            {
                return this.DefaultDocuments();
            }
        }

        /// <summary>
        /// Gets the version of Python.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PythonVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.PythonVersion
        {
            get
            {
                return this.PythonVersion();
            }
        }

        /// <summary>
        /// First step specifying the parameters to make a web deployment (MS Deploy) to the web app.
        /// </summary>
        /// <return>A stage to create web deployment.</return>
        WebDeployment.Definition.IWithPackageUri Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Deploy()
        {
            return this.Deploy();
        }

        /// <summary>
        /// Gets if the web app is always on.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AlwaysOn
        {
            get
            {
                return this.AlwaysOn();
            }
        }

        /// <summary>
        /// Gets hostnames associated with web app.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.HostNames
        {
            get
            {
                return this.HostNames();
            }
        }

        /// <summary>
        /// Gets the System Assigned (Local) Managed Service Identity specific Active Directory service principal ID
        /// assigned to the web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.SystemAssignedManagedServiceIdentityPrincipalId
        {
            get
            {
                return this.SystemAssignedManagedServiceIdentityPrincipalId();
            }
        }

        /// <return>The app settings defined on the web app.</return>
        async Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting>> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetAppSettingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetAppSettingsAsync(cancellationToken);
        }

        /// <return>The app settings defined on the web app.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetAppSettings()
        {
            return this.GetAppSettings();
        }

        /// <summary>
        /// Gets Java container.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.JavaContainer
        {
            get
            {
                return this.JavaContainer();
            }
        }

        /// <return>The authentication configuration defined on the web app.</return>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppAuthentication Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetAuthenticationConfig()
        {
            return this.GetAuthenticationConfig();
        }

        /// <summary>
        /// Gets the .NET Framework version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.NetFrameworkVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.NetFrameworkVersion
        {
            get
            {
                return this.NetFrameworkVersion();
            }
        }

        /// <summary>
        /// Gets list of SSL states used to manage the SSL bindings for site's hostnames.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.HostNameSslState> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.HostNameSslStates
        {
            get
            {
                return this.HostNameSslStates();
            }
        }

        /// <summary>
        /// Gets list of IP addresses that this web app uses for
        /// outbound connections. Those can be used when configuring firewall
        /// rules for databases accessed by this web app.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.OutboundIPAddresses
        {
            get
            {
                return this.OutboundIPAddresses();
            }
        }

        /// <summary>
        /// Gets list of Azure Traffic manager host names associated with web
        /// app.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.TrafficManagerHostNames
        {
            get
            {
                return this.TrafficManagerHostNames();
            }
        }

        /// <summary>
        /// Gets if the client affinity is enabled when load balancing http
        /// request for multiple instances of the web app.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ClientAffinityEnabled
        {
            get
            {
                return this.ClientAffinityEnabled();
            }
        }

        /// <summary>
        /// Gets the architecture of the platform, either 32 bit (x86) or 64 bit (x64).
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PlatformArchitecture Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.PlatformArchitecture
        {
            get
            {
                return this.PlatformArchitecture();
            }
        }

        /// <summary>
        /// Gets if the client certificate is enabled for the web app.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ClientCertEnabled
        {
            get
            {
                return this.ClientCertEnabled();
            }
        }

        /// <summary>
        /// Gets Java version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.JavaVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.JavaVersion
        {
            get
            {
                return this.JavaVersion();
            }
        }

        /// <summary>
        /// Gets information about whether the web app is cloned from another.
        /// </summary>
        Models.CloningInfo Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.CloningInfo
        {
            get
            {
                return this.CloningInfo();
            }
        }

        /// <summary>
        /// Gets host names for the web app that are enabled.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.EnabledHostNames
        {
            get
            {
                return this.EnabledHostNames();
            }
        }

        /// <summary>
        /// Gets if the remote eebugging is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.RemoteDebuggingEnabled
        {
            get
            {
                return this.RemoteDebuggingEnabled();
            }
        }

        /// <summary>
        /// Gets default hostname of the web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.DefaultHostName
        {
            get
            {
                return this.DefaultHostName();
            }
        }

        /// <summary>
        /// Gets which slot this app will swap into.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.TargetSwapSlot
        {
            get
            {
                return this.TargetSwapSlot();
            }
        }

        /// <summary>
        /// Gets state of the web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.State
        {
            get
            {
                return this.State();
            }
        }

        /// <summary>
        /// Gets Last time web app was modified in UTC.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        /// <summary>
        /// Gets size of a function container.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ContainerSize
        {
            get
            {
                return this.ContainerSize();
            }
        }

        /// <return>The authentication configuration defined on the web app.</return>
        async Task<Microsoft.Azure.Management.AppService.Fluent.IWebAppAuthentication> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetAuthenticationConfigAsync(CancellationToken cancellationToken)
        {
            return await this.GetAuthenticationConfigAsync(cancellationToken);
        }

        /// <summary>
        /// Gets Specifies the definition of a new diagnostic logs configuration.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an diagnostic logs definition.
        /// </summary>
        WebAppDiagnosticLogs.Definition.IBlank<WebAppBase.Definition.IWithCreate<FluentT>> WebAppBase.Definition.IWithDiagnosticLogging<FluentT>.DefineDiagnosticLogsConfiguration()
        {
            return this.DefineDiagnosticLogsConfiguration();
        }

        /// <summary>
        /// Gets Specifies the update of an existing diagnostic logs configuration.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an diagnostic logs update.
        /// </summary>
        WebAppDiagnosticLogs.Update.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithDiagnosticLogging<FluentT>.UpdateDiagnosticLogsConfiguration()
        {
            return this.UpdateDiagnosticLogsConfiguration();
        }

        /// <summary>
        /// Gets the diagnostic logs configuration.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppDiagnosticLogs Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.DiagnosticLogsConfig
        {
            get
            {
                return this.DiagnosticLogsConfig();
            }
        }
    }
}