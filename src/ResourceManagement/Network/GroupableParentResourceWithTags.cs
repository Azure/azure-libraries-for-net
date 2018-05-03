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
    public abstract partial class GroupableParentResourceWithTags<
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
            UTypeWithTags>
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
            return this as IUpdateWithTags<IFluentResourceT>;
        }

        public IFluentResourceT applyTags()
        {
            return Extensions.Synchronize(() => ApplyTagsAsync());
        }

        protected abstract Task<InnerResourceT> ApplyTagsToInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        public async Task<IFluentResourceT> ApplyTagsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await ApplyTagsToInnerAsync(cancellationToken);
            SetInner(inner);
            return this as FluentResourceT;
        }

//        public IAppliableWithTags<IFluentResourceT> WithoutTag(string key)
//        {
//            base.WithoutTag(key);
//            return this as IAppliableWithTags<IFluentResourceT>;
//        }
//
//        public IAppliableWithTags<IFluentResourceT> WithTag(string key, string value)
//        {
//            base.WithTag(key, value);
//            return this as IAppliableWithTags<IFluentResourceT>;
//        }
//
//        public IAppliableWithTags<IFluentResourceT> WithTags(IDictionary<string, string> tags)
//        {
//            base.WithTags(tags);
//            return this as IAppliableWithTags<IFluentResourceT>;
//        }
    }
}
