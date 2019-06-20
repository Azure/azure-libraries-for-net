// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The implementation for  NestedResource.
    /// (Internal use only).
    /// </summary>
    /// <typeparam name="IFluentModelT">The fluent model of the nested resource.</typeparam>
    /// <typeparam name="InnerModelT">The inner model of the nested resource.</typeparam>
    /// <typeparam name="FluentModelImplT">The fluent model implementation of the nested resource.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLk5lc3RlZFJlc291cmNlSW1wbA==
    internal abstract partial class NestedResourceImpl<IFluentModelT, InnerModelT, FluentModelImplT, IUpdateEntryPoint> :
        CreatableUpdatable<IFluentModelT, InnerModelT, FluentModelImplT, IHasId, IUpdateEntryPoint>,
        IHasInner<InnerModelT>,
        IHasManager<IEventHubManager>,
        INestedResource
        where InnerModelT : Resource
        where IFluentModelT : class, IHasId
        where FluentModelImplT : class
        where IUpdateEntryPoint : class
    {
        private readonly IEventHubManager manager;

        ///GENMHASH:9D7EA0C70F6AEA6349849982C6564428:EEC01D2C4CB7B9653F1FB0C80275BD33
        internal NestedResourceImpl(string name, InnerModelT inner, IEventHubManager manager)
            : base(name, inner)
        {
            this.manager = manager;
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:19C4BD8FCE58F39FC1CCEB1A6C862717
        public bool IsInCreateMode()
        {
            return this.Inner.Id == null;
        }

        public IEventHubManager Manager
        {
            get
            {
                return this.manager;
            }
        }

        string INestedResource.Name
        {
            get
            {
                if (this.Inner.Name == null)
                {
                    return base.Name;
                }
                else
                {
                    return this.Inner.Name;
                }
            }
        }

        string IHasId.Id => this.Id();

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        string INestedResource.Type => this.Type();

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }
    }
}