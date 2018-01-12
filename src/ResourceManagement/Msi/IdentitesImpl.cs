// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Msi.Fluent
{
    using Microsoft.Azure.Management.Msi.Fluent.Identity.Definition;
    using Microsoft.Azure.Management.Msi.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest.Azure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for Identities.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1zaS5pbXBsZW1lbnRhdGlvbi5JZGVudGl0ZXNJbXBs
    internal sealed partial class IdentitesImpl  :
        TopLevelModifiableResources<Microsoft.Azure.Management.Msi.Fluent.IIdentity,Microsoft.Azure.Management.Msi.Fluent.IdentityImpl, IdentityInner, IUserAssignedIdentitiesOperations, IMsiManager>,
        IIdentities
    {
        ///GENMHASH:D841767260CA3AE47D20B12A81460B10:0FCD47CBCD9128C3D4A03458C5796741
        internal IdentitesImpl(IUserAssignedIdentitiesOperations innerCollection, IMsiManager manager) : base(innerCollection, manager)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:C87A4958E891DCFF059719350F8DBD18
        protected override IdentityImpl WrapModel(string name)
        {
            return new IdentityImpl(name, new IdentityInner(), this.Manager);
        }

        ///GENMHASH:20418A1938290FF37C165FEFC11BE339:45C3BD03A5E0CBA65A6C97B302C1DA6F
        protected override IIdentity WrapModel(IdentityInner inner)
        {
            if (inner == null)
            {
                return null;
            }
            else
            {
                return new IdentityImpl(inner.Name, inner, this.Manager);
            }
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
           await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        protected async override Task<IdentityInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        protected async override Task<IPage<IdentityInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<IdentityInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        protected async override Task<IPage<IdentityInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListBySubscriptionAsync(cancellationToken);
        }

        protected async override Task<IPage<IdentityInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListBySubscriptionNextAsync(nextLink, cancellationToken);
        }
    }
}