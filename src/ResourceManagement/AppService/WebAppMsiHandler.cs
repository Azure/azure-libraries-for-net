// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Linq;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) property on a web app,
    /// install or update MSI extension and create role assignments for the service principal
    /// associated with the web app.
    /// </summary>
    partial class WebAppMsiHandler<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> : RoleAssignmentHelper
        where FluentImplT : WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, WebAppBase.Update.IUpdate<FluentT>
    {
        private ISet<string> creatableIdentityKeys;
        private IDictionary<string, ManagedServiceIdentityUserAssignedIdentitiesValue> userAssignedIdentities;
        private WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> webAppBaseImpl;

        /// <summary>
        /// Creates WebAppMsiHandler.
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager.</param>
        /// <param name="webAppBase">
        /// The web app to which MSI extension needs to be installed and
        /// for which role assignments needs to be created.
        /// </param>
        internal WebAppMsiHandler(IGraphRbacManager rbacManager, WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> webAppBaseImpl)
            : base(rbacManager, new WebAppIdProvider(webAppBaseImpl))
        {
            this.webAppBaseImpl = webAppBaseImpl;
            this.creatableIdentityKeys = new HashSet<string>();
            this.userAssignedIdentities = new Dictionary<string, ManagedServiceIdentityUserAssignedIdentitiesValue>();
        }

        /// <summary>
        /// Clear VirtualMachineMsiHandler post-run specific internal state.
        /// </summary>
        internal void Clear()
        {
            this.userAssignedIdentities.Clear();
        }
        
        internal void HandleExternalIdentities()
        {
            SiteInner siteInner = (SiteInner)this.webAppBaseImpl.Inner;
            if (this.userAssignedIdentities.Any()) {
                siteInner.Identity.UserAssignedIdentities = this.userAssignedIdentities;
            }
        }

        internal void HandleExternalIdentities(SitePatchResource siteUpdate)
        {
            if (this.HandleRemoveAllExternalIdentitiesCase(siteUpdate)) {
                return;
            } else {
                // At this point one of the following condition is met:
                //
                // 1. User don't want touch the 'Site.Identity.UserAssignedIdentities' property
                //      [this.userAssignedIdentities.Empty() == true]
                // 2. User want to add some identities to 'Site.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.webAppBase.Inner().Identity() != null]
                // 3. User want to remove some (not all) identities in 'Site.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.webAppBase.Inner().Identity() != null]
                //      Note: The scenario where this.webAppBase.Inner().Identity() is null in #3 is already handled in
                //      handleRemoveAllExternalIdentitiesCase method
                // 4. User want to add and remove (all or subset) some identities in 'Site.Identity.UserAssignedIdentities'
                //      [this.userAssignedIdentities.Empty() == false and this.webAppBase.Inner().Identity() != null]
                //
                SiteInner siteInner = this.webAppBaseImpl.Inner;
                ManagedServiceIdentity currentIdentity = siteInner.Identity;
                siteUpdate.Identity = currentIdentity;
                if (this.userAssignedIdentities.Any()) {
                    // At this point its guaranteed that 'currentIdentity' is not null so vmUpdate.Identity() is.
                    siteUpdate.Identity.UserAssignedIdentities = this.userAssignedIdentities;
                } else {
                    // User don't want to touch 'VM.Identity.UserAssignedIdentities' property
                    if (currentIdentity != null) {
                        // and currently there is identity exists or user want to manipulate some other properties of
                        // identity, set identities to null so that it won't send over wire.
                        currentIdentity.UserAssignedIdentities = null;
                    }
                }
            }

        }

        internal void ProcessCreatedExternalIdentities()
        {
            foreach (var key in this.creatableIdentityKeys) {
                var identity = (IIdentity)this.webAppBaseImpl.CreatorTaskGroup.CreatedResource(key);
                this.userAssignedIdentities[identity.Id] = new ManagedServiceIdentityUserAssignedIdentitiesValue();
            }

            this.creatableIdentityKeys.Clear();
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the web app.
        /// </summary>
        /// <param name="identity">An identity to associate.</param>
        /// <return>WebAppMsiHandler.</return>
        internal WebAppMsiHandler<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithExistingExternalManagedServiceIdentity(IIdentity identity)
        {
            this.InitSiteIdentity(ManagedServiceIdentityType.UserAssigned);
            this.userAssignedIdentities[identity.Id] = new ManagedServiceIdentityUserAssignedIdentitiesValue();
            return this;
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be enabled in the web app.
        /// If MSI extension is not already installed then it will be installed with access token
        /// port as 50342.
        /// </summary>
        /// <return>WebAppMsiHandler.</return>
        internal WebAppMsiHandler<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithLocalManagedServiceIdentity()
        {
            this.InitSiteIdentity(ManagedServiceIdentityType.SystemAssigned);
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the web app.
        /// </summary>
        /// <param name="creatableIdentity">Yet-to-be-created identity to be associated with the virtual machine.</param>
        /// <return>WebAppMsiHandler.</return>
        internal WebAppMsiHandler<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithNewExternalManagedServiceIdentity(ICreatable<Microsoft.Azure.Management.Msi.Fluent.IIdentity> creatableIdentity)
        {
            if (!this.creatableIdentityKeys.Contains(creatableIdentity.Key))
            {
                this.InitSiteIdentity(ManagedServiceIdentityType.UserAssigned);
                this.creatableIdentityKeys.Add(creatableIdentity.Key);
                ((creatableIdentity as IResourceCreator<IHasId>).CreatorTaskGroup).Merge(this.webAppBaseImpl.CreatorTaskGroup);
            }
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be removed from the list of External Managed Service Identity
        /// associated with the web app.
        /// </summary>
        /// <param name="identityId">Resource id of the identity.</param>
        /// <return>WebAppMsiHandler.</return>
        internal WebAppMsiHandler<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutExternalManagedServiceIdentity(string identityId)
        {
            this.userAssignedIdentities[identityId] =  null;
            return this;
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be disabled in the web app.
        /// </summary>
        /// <return>WebAppMsiHandler.</return>
        internal WebAppMsiHandler<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithoutLocalManagedServiceIdentity()
        {
            SiteInner siteInner = (SiteInner)this.webAppBaseImpl.Inner;

            if (siteInner.Identity == null
            || siteInner.Identity.Type == null
            || siteInner.Identity.Type.Equals(ManagedServiceIdentityType.None)
            || siteInner.Identity.Type.Equals(ManagedServiceIdentityType.UserAssigned)) {
                return this;
            } else if (siteInner.Identity.Type.Equals(ManagedServiceIdentityType.SystemAssigned)) {
                siteInner.Identity.Type = ManagedServiceIdentityType.None;
            } else if (siteInner.Identity.Type.Equals(ManagedServiceIdentityType.SystemAssignedUserAssigned)) {
                siteInner.Identity.Type = ManagedServiceIdentityType.UserAssigned;
            }
            return this;
        }

        /// <summary>
        /// Method that handle the case where user request indicates all it want to do is remove all identities associated
        /// with the virtual machine.
        /// </summary>
        /// <param name="siteUpdate">The vm update payload model.</param>
        /// <return>True if user indented to remove all the identities.</return>
        private bool HandleRemoveAllExternalIdentitiesCase(SitePatchResource siteUpdate)
        {
            SiteInner siteInner = (SiteInner)this.webAppBaseImpl.Inner;
            if (this.userAssignedIdentities.Any())
            {
                int rmCount = 0;
                foreach (var v in this.userAssignedIdentities.Values)
                {
                    if (v == null)
                    {
                        rmCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                bool containsRemoveOnly = rmCount > 0 && rmCount == this.userAssignedIdentities.Count;
                // Check if user request contains only request for removal of identities.
                if (containsRemoveOnly) {
                    HashSet<string> currentIds = new HashSet<string>();
                    ManagedServiceIdentity currentIdentity = siteInner.Identity;
                    if (currentIdentity != null && currentIdentity.UserAssignedIdentities != null) {
                        foreach (String id in currentIdentity.UserAssignedIdentities.Keys) {
                            currentIds.Add(id.ToLower());
                        }
                    }
                    HashSet<string> removeIds = new HashSet<string>();
                    foreach (var entrySet in this.userAssignedIdentities)
                    {
                        if (entrySet.Value == null)
                        {
                            removeIds.Add(entrySet.Key.ToLower());
                        }
                    }


                    var removeAllCurrentIds = currentIds.Count == removeIds.Count && !removeIds.Any(id => !currentIds.Contains(id)); // Java part looks like this -> && currentIds.ContainsAll(removeIds);
                    if (removeAllCurrentIds) {
                        // If so adjust  the identity type [Setting type to SYSTEM_ASSIGNED orNONE will remove all the identities]
                        if (currentIdentity == null || currentIdentity.Type == null) {
                            siteUpdate.Identity = new ManagedServiceIdentity()
                            {
                                Type = ManagedServiceIdentityType.None
                            };
                        } else if (currentIdentity.Type.Equals(ManagedServiceIdentityType.SystemAssignedUserAssigned)) {
                            siteUpdate.Identity = currentIdentity;
                            siteUpdate.Identity.Type = ManagedServiceIdentityType.SystemAssigned;
                        } else if (currentIdentity.Type.Equals(ManagedServiceIdentityType.UserAssigned)) {
                            siteUpdate.Identity = currentIdentity;
                            siteUpdate.Identity.Type = ManagedServiceIdentityType.None;
                        }
                        // and set identities property in the payload model to null so that it won't be sent
                        siteUpdate.Identity.UserAssignedIdentities = null;
                        return true;
                    } else {
                        // Check user is asking to remove identities though there is no identities currently associated
                        if (currentIds.Count == 0
                        && removeIds.Count != 0
                        && currentIdentity == null) {
                            // If so we are in a invalid state but we want to send user input to service and let service
                            // handle it (ignore or error).
                            siteUpdate.Identity = new ManagedServiceIdentity()
                            {
                                Type = ManagedServiceIdentityType.None,
                                UserAssignedIdentities = null
                            };
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Initialize VM's identity property.
        /// </summary>
        /// <param name="identityType">The identity type to set.</param>
        private void InitSiteIdentity(ManagedServiceIdentityType identityType)
        {
            if (!identityType.Equals(ManagedServiceIdentityType.UserAssigned)
                && !identityType.Equals(ManagedServiceIdentityType.SystemAssigned)) {
                throw new ArgumentException("Invalid argument: " + identityType);
            }

            SiteInner siteInner = this.webAppBaseImpl.Inner;
            if (siteInner.Identity == null) {
                siteInner.Identity = new ManagedServiceIdentity();
            }

            if (siteInner.Identity.Type == null
                || siteInner.Identity.Type.Equals(ManagedServiceIdentityType.None)
                || siteInner.Identity.Type.Equals(identityType)) {
                siteInner.Identity.Type = identityType;
            } else {
                siteInner.Identity.Type = ManagedServiceIdentityType.SystemAssignedUserAssigned;
            }
        }

        internal class WebAppIdProvider : IIdProvider
        {
            private readonly IWebAppBase webApp;

            internal WebAppIdProvider(IWebAppBase webApp)
            {
                this.webApp = webApp;
            }

            public string PrincipalId
            {
                get
                {
                    if (this.webApp.Inner != null && this.webApp.Inner.Identity != null)
                    {
                        return this.webApp.Inner.Identity.PrincipalId;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public string ResourceId
            {
                get
                {
                    if (this.webApp.Inner != null)
                    {
                        return this.webApp.Inner.Id;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}