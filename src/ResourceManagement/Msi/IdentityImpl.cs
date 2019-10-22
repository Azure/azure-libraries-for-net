// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Msi.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.Msi.Fluent.Identity.Definition;
    using Microsoft.Azure.Management.Msi.Fluent.Identity.Update;
    using Microsoft.Azure.Management.Msi.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for Identity and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1zaS5pbXBsZW1lbnRhdGlvbi5JZGVudGl0eUltcGw=
    internal sealed partial class IdentityImpl :
        GroupableResource<IIdentity, IdentityInner, IdentityImpl, IMsiManager, IWithGroup, IWithCreate, IWithCreate, IUpdate>,
        IIdentity,
        IDefinition,
        IUpdate
    {
        private RoleAssignmentHelper roleAssignmentHelper;

        ///GENMHASH:35C41CF8EA2B651DBCD26FE5A9B115F3:5000AB36D4511145216DD6380463F729
        internal IdentityImpl(string name, IdentityInner innerModel, IMsiManager manager) : base(name, innerModel, manager)
        {
            this.roleAssignmentHelper = new RoleAssignmentHelper(manager.GraphRbacManager, this.IdProvider());
        }

        ///GENMHASH:73A75260B8EDAA942E9403177A3544DB:2CA42958642F6FA1C5AA7E85785D66B4
        public IdentityImpl WithoutAccessTo(string resourceId, BuiltInRole role)
        {
            this.roleAssignmentHelper.WithoutAccessTo(resourceId, role);
            return this;
        }

        ///GENMHASH:7B85BC19A12FE70FA9CB1E2E3F017EED:68C0AA12C5BD2781831CD7C4B29E5550
        public string ClientId()
        {
            if (this.Inner.ClientId == null)
            {
                return null;
            }
            else
            {
                return this.Inner.ClientId.ToString();
            }
        }

        ///GENMHASH:18397684B4C4DF93493896F6C894F585:4F8CFD4086B8F5614B957F170AA0C22A
        private IIdProvider IdProvider()
        {
            return new IdProvider(this);
        }

        ///GENMHASH:DA183CCEBC00D21096D59D1B439F4E2F:2E310B86723C08380AC47D35B3E5AEEF
        public string TenantId()
        {
            if (this.Inner.TenantId == null)
            {
                return null;
            }
            else
            {
                return this.Inner.TenantId.ToString();
            }
        }

        ///GENMHASH:D88CAA570CC8B4DF8BD60ED918B5BBBE:3BF721FD7650311A6E8E8D610A45E1EB
        public string PrincipalId()
        {
            if (this.Inner.PrincipalId == null) {
                return null;
            }
            else
            {
                return this.Inner.PrincipalId.ToString();
            }
        }

        ///GENMHASH:9E99E28677511E2DF950125EDB997762:7C1D8EF04190738EFBE34E23EE9A2713
        public IdentityImpl WithAccessTo(IResource resource, BuiltInRole role)
        {
            this.roleAssignmentHelper.WithAccessTo(resource.Id, role);
            return this;
        }

        ///GENMHASH:0CEE95C0D1098AAAC5BF7C869DE68D7D:E5512083F6DA7EA2BA516BF9E845E0A9
        public IdentityImpl WithAccessTo(string resourceId, BuiltInRole role)
        {
            this.roleAssignmentHelper.WithAccessTo(resourceId, role);
            return this;
        }

        ///GENMHASH:42891E3932C5EAEFFAD237F428099764:67B4FF5C4E621F31280157F98661447B
        public IdentityImpl WithAccessTo(IResource resource, string roleDefinitionId)
        {
            this.roleAssignmentHelper.WithAccessTo(resource.Id, roleDefinitionId);
            return this;
        }

        ///GENMHASH:98F34D61BDC6DB6BB15851054E2EA4B1:F82A7A6E1E655681DA6796A4A3163D31
        public IdentityImpl WithAccessTo(string resourceId, string roleDefinitionId)
        {
            this.roleAssignmentHelper.WithAccessTo(resourceId, roleDefinitionId);
            return this;
        }

        ///GENMHASH:E52BA5580C6DD688687D5F7962138CA3:C76E712B3F0BFB0C78333420FF42894C
        public IdentityImpl WithAccessToCurrentResourceGroup(BuiltInRole role)
        {
            this.roleAssignmentHelper.WithAccessToCurrentResourceGroup(role);
            return this;
        }

        ///GENMHASH:E4BA8B667A9B8EBB33544679E438B0C4:739831CB1E5F5DA5BD5413DEA9A6E093
        public IdentityImpl WithAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            this.roleAssignmentHelper.WithAccessToCurrentResourceGroup(roleDefinitionId);
            return this;
        }

        ///GENMHASH:6A6233D5A6936441292FB128F4E3011A:11D4D4AD3CE5864DC7FF9FCD6C31A406
        public string ClientSecretUrl()
        {
            return this.Inner.ClientSecretUrl;
        }

        ///GENMHASH:EF11EC04DEA31F31CA7F868E3D094F58:7395BD5AAA04C503F691C11E26A6A807
        public IdentityImpl WithoutAccess(IRoleAssignment access)
        {
            this.roleAssignmentHelper.WithoutAccessTo(access);
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:A65DE7A931E0213F826A5B6E91CBE2D3
        protected override Task<IdentityInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Manager
                .Inner
                .UserAssignedIdentities
                .GetAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:72B6F0E6E03A05991A72A4FF9555BB50
        public async override Task<Microsoft.Azure.Management.Msi.Fluent.IIdentity> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.UserAssignedIdentities.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner, cancellationToken);
            SetInner(inner);
            await this.roleAssignmentHelper.CommitsRoleAssignmentsPendingActionAsync(cancellationToken);

            return this;
        }
    }

    internal class IdProvider : IIdProvider
    {
        private readonly IdentityImpl identity;

        internal IdProvider(IdentityImpl identity)
        {
            this.identity = identity;
        }

        public string PrincipalId
        {
            get
            {
                if (this.identity.Inner == null)
                {
                    throw new InvalidOperationException("Identity.Inner should not be null");
                }

                if (this.identity.Inner.PrincipalId == null)
                {
                    throw new InvalidOperationException("Identity.Inner.PrincipalId should not be null");
                }
                return this.identity.Inner.PrincipalId.Value.ToString();
            }
        }

        public string ResourceId
        {
            get
            {
                if (this.identity.Inner == null)
                {
                    throw new InvalidOperationException("Identity.Inner should not be null");
                }
                if (this.identity.Inner.Id == null)
                {
                    throw new InvalidOperationException("Identity.Inner.Id should not be null");
                }
                return this.identity.Inner.Id;
            }
        }
    }
}