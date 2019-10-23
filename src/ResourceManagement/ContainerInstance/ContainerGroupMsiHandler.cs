// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Utility class to set Managed Service Identity (MSI) and MSI related resources for a container instance.
    /// </summary>
    public partial class ContainerGroupMsiHandler : RoleAssignmentHelper
    {
        private ISet<string> creatableIdentityKeys;
        private IDictionary<string, ContainerGroupIdentityUserAssignedIdentitiesValue> userAssignedIdentities;
        private ContainerGroupImpl containerGroup;

        /// <summary>
        /// Creates ContainerInstanceMsiHandler
        /// </summary>
        /// <param name="rbacManager">The graph rbac manager</param>
        /// <param name="containerGroup">Instance of container group</param>
        internal ContainerGroupMsiHandler(IGraphRbacManager rbacManager, ContainerGroupImpl containerGroup)
            : base(rbacManager, new ContainerGroupIdProvider(containerGroup))
        {
            this.containerGroup = containerGroup;
            this.creatableIdentityKeys = new HashSet<string>();
            this.userAssignedIdentities = new Dictionary<string, ContainerGroupIdentityUserAssignedIdentitiesValue>();
        }

        internal void HandleExternalIdentities()
        {
            if (this.containerGroup.Inner.Identity == null)
            {
                return;
            }

            if (this.userAssignedIdentities == null || this.userAssignedIdentities.Count == 0)
            {
                if (this.containerGroup.Inner.Identity.Type == ResourceIdentityType.SystemAssignedUserAssigned)
                {
                    this.containerGroup.Inner.Identity.Type = ResourceIdentityType.SystemAssigned;
                }
                if (this.containerGroup.Inner.Identity.Type == ResourceIdentityType.UserAssigned)
                {
                    this.containerGroup.Inner.Identity.Type = ResourceIdentityType.None;
                }
                this.containerGroup.Inner.Identity.UserAssignedIdentities = null;
            }
            else
            {
                this.containerGroup.Inner.Identity.UserAssignedIdentities = this.userAssignedIdentities;
            }
        }

        internal void ProcessCreatedExternalIdentities()
        {
            foreach (var key in this.creatableIdentityKeys)
            {
                var identity = (IIdentity)this.containerGroup.CreatorTaskGroup.CreatedResource(key);
                this.userAssignedIdentities[identity.Id] = new ContainerGroupIdentityUserAssignedIdentitiesValue();
            }
            this.creatableIdentityKeys.Clear();
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be enabled in the container group.
        /// MSI extension is not already installed then it will be installed with access token
        /// port as 50342.
        /// </summary>
        /// <returns>ContainerGroupMsiHandler</returns>
        internal ContainerGroupMsiHandler WithLocalManagedServiceIdentity()
        {
            this.InitContainerGroupIdentity(ResourceIdentityType.SystemAssigned);
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the container group.
        /// </summary>
        /// <param name="creatableIdentity">Yet-to-be-created identity to be associated with the container group.</param>
        /// <return>ContainerGroupMsiHandler</return>
        internal ContainerGroupMsiHandler WithNewExternalManagedServiceIdentity(ICreatable<IIdentity> creatableIdentity)
        {
            if (!this.creatableIdentityKeys.Contains(creatableIdentity.Key))
            {
                this.InitContainerGroupIdentity(ResourceIdentityType.UserAssigned);
                this.creatableIdentityKeys.Add(creatableIdentity.Key);
                ((creatableIdentity as IResourceCreator<IHasId>).CreatorTaskGroup).Merge(this.containerGroup.CreatorTaskGroup);
            }
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be set as one of the External Managed Service Identity
        /// of the container group.
        /// </summary>
        /// <param name="identity">An identity to associate.</param>
        /// <return>ContainerGroupMsiHandler.</return>
        internal ContainerGroupMsiHandler WithExistingExternalManagedServiceIdentity(IIdentity identity)
        {
            this.InitContainerGroupIdentity(ResourceIdentityType.UserAssigned);
            this.userAssignedIdentities[identity.Id] = new ContainerGroupIdentityUserAssignedIdentitiesValue();
            return this;
        }

        /// <summary>
        /// Specifies that given identity should be removed from the list of External Managed Service Identity
        /// associated with the container group machine.
        /// </summary>
        /// <param name="identityId">Resource id of the identity.</param>
        /// <return>VirtualMachineMsiHandler.</return>
        internal ContainerGroupMsiHandler WithoutExternalManagedServiceIdentity(string identityId)
        {
            this.userAssignedIdentities.Remove(identityId);
            return this;
        }

        /// <summary>
        /// Specifies that Local Managed Service Identity needs to be disabled in the container group.
        /// </summary>
        /// <return>VirtualMachineMsiHandler.</return>
        internal ContainerGroupMsiHandler WithoutLocalManagedServiceIdentity()
        {
            if (this.containerGroup.Inner.Identity == null ||
                this.containerGroup.Inner.Identity.Type == null ||
                this.containerGroup.Inner.Identity.Type == Models.ResourceIdentityType.None ||
                this.containerGroup.Inner.Identity.Type == Models.ResourceIdentityType.UserAssigned)
            {
                return this;
            }
            else if (this.containerGroup.Inner.Identity.Type == Models.ResourceIdentityType.SystemAssigned)
            {
                this.containerGroup.Inner.Identity.Type = Models.ResourceIdentityType.None;
            }
            else if (this.containerGroup.Inner.Identity.Type.Value == Models.ResourceIdentityType.SystemAssignedUserAssigned)
            {
                this.containerGroup.Inner.Identity.Type = Models.ResourceIdentityType.UserAssigned;
            }
            return this;
        }

        private void InitContainerGroupIdentity(ResourceIdentityType identityType)
        {
            if (identityType != ResourceIdentityType.UserAssigned && identityType != ResourceIdentityType.SystemAssigned)
            {
                throw new ArgumentException("Invalid argument: " + identityType);
            }

            ContainerGroupInner containerGroupInner = this.containerGroup.Inner;
            if (containerGroupInner.Identity == null)
            {
                containerGroupInner.Identity = new ContainerGroupIdentity();
            }

            if (containerGroupInner.Identity.Type == null ||
                containerGroupInner.Identity.Type == ResourceIdentityType.None ||
                containerGroupInner.Identity.Type == identityType)
            {
                containerGroupInner.Identity.Type = identityType;
            }
            else
            {
                containerGroupInner.Identity.Type = ResourceIdentityType.SystemAssignedUserAssigned;
            }
        }

        internal class ContainerGroupIdProvider : IIdProvider
        {
            private readonly ContainerGroupImpl containerGroup;

            internal ContainerGroupIdProvider(ContainerGroupImpl containerGroup)
            {
                this.containerGroup = containerGroup;
            }

            public string PrincipalId
            {
                get
                {
                    if (this.containerGroup.Inner != null && this.containerGroup.Inner.Identity != null)
                    {
                        return this.containerGroup.Inner.Identity.PrincipalId;
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
                    if (this.containerGroup.Inner != null)
                    {
                        return this.containerGroup.Inner.Id;
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