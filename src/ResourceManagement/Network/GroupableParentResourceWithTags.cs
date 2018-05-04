// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Fluent.UpdatableWithTags.UpdatableWithTags;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for GroupableResource.
    /// (Internal use only)
    /// 
    /// @param <FluentModelT> The fluent model type
    /// @param <InnerModelT> Azure inner resource class type
    /// @param <FluentModelImplT> the implementation type of the fluent model type
    /// @param <ManagerT> the service manager type
    /// </summary>
    public abstract class GroupableParentResourceWithTags<
        IFluentResourceT,
        InnerResourceT,
        FluentResourceT,
        ManagerT,
        IDefinitionAfterRegion,
        IDefinitionAfterResourceGroup,
        DefTypeWithTags,
        UTypeWithTags> :
        GroupableParentResource<IFluentResourceT,
            InnerResourceT,
            FluentResourceT,
            ManagerT,
            IDefinitionAfterRegion,
            IDefinitionAfterResourceGroup,
            DefTypeWithTags,
            UTypeWithTags>,
        IUpdateWithTags<IFluentResourceT>,
        IAppliableWithTags<IFluentResourceT>
        where FluentResourceT : GroupableParentResource<IFluentResourceT,
            InnerResourceT,
            FluentResourceT,
            ManagerT,
            IDefinitionAfterRegion,
            IDefinitionAfterResourceGroup,
            DefTypeWithTags,
            UTypeWithTags>, IFluentResourceT
        where ManagerT : IManagerBase
        where IFluentResourceT : class, IResource
        where InnerResourceT : Microsoft.Azure.Management.ResourceManager.Fluent.Resource
        where IDefinitionAfterRegion : class
        where IDefinitionAfterResourceGroup : class
        where DefTypeWithTags : class
        where UTypeWithTags : class

    {
        protected GroupableParentResourceWithTags(string name, InnerResourceT innerObject, ManagerT manager) : base(
            name, innerObject, manager)
        {
        }

        public IUpdateWithTags<IFluentResourceT> UpdateTags()
        {
            if (this is IUpdateWithTags<IFluentResourceT>)
            {
                return this as IUpdateWithTags<IFluentResourceT>;
            }

            throw new Exception($"Unable to cast '{this.GetType()}' to '{typeof(IUpdateWithTags<IFluentResourceT>)}'");
        }

        public IFluentResourceT ApplyTags()
        {
            return Extensions.Synchronize(() => ApplyTagsAsync());
        }

        protected abstract Task<InnerResourceT> ApplyTagsToInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        public async Task<IFluentResourceT> ApplyTagsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await ApplyTagsToInnerAsync(cancellationToken);
            SetInner(inner);
            if (this is FluentResourceT)
            {
                return this as FluentResourceT;
            }
            throw new Exception($"Unable to cast '{this.GetType()}' to '{typeof(FluentResourceT)}'");
        }

        public IAppliableWithTags<IFluentResourceT> WithoutTag(string key)
        {
            return (IAppliableWithTags<IFluentResourceT>)base.WithoutTag(key);
        }

        public IAppliableWithTags<IFluentResourceT> WithTag(string key, string value)
        {
            return (IAppliableWithTags<IFluentResourceT>)base.WithTag(key, value);
        }

        public IAppliableWithTags<IFluentResourceT> WithTags(IDictionary<string, string> tags)
        {
            return (IAppliableWithTags<IFluentResourceT>)base.WithTags(tags);
        }
    }
}
