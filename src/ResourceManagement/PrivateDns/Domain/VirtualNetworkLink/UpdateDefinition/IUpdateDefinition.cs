// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent.VirtualNetworkLink.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a virtual network link definition as a part of parent update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a virtual network link definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the virtual network link definition.
    /// At this stage, any remaining optional settings can be specified, or the virtual network link
    /// definition can be attached.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        IWithAutoRegistration<ParentT>,
        IWithETagCheck<ParentT>,
        IWithReferenceVirtualNetwork<ParentT>,
        IWithRegion<ParentT>,
        IWithTags<ParentT>
    {
    }

    /// <summary>
    /// The stage of the virtual network link definition allowing to manage auto-registration of virtual network records.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAutoRegistration<ParentT>
    {
        /// <summary>
        /// Specifies to enable auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> EnableAutoRegistration();

        /// <summary>
        /// Specifies to disable auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> DisableAutoRegistration();
    }

    /// <summary>
    /// The stage of the virtual network link definition allowing to enable ETag validation.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithETagCheck<ParentT>
    {
        /// <summary>
        /// Specifies that If-None-Match header needs to set to  to prevent updating an existing virtual network link.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithETagCheck();
    }

    /// <summary>
    /// The stage of the virtual network link definition allowing to set the reference of virtual network by ID.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithReferenceVirtualNetwork<ParentT>
    {
        /// <summary>
        /// Specifies to set the reference of virtual network with value of ID.
        /// </summary>
        /// <param name="referencedVirtualNetworkId">The value of reference virtual network ID.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithReferencedVirtualNetworkId(string referencedVirtualNetworkId);
    }

    /// <summary>
    /// The stage of the virtual network link definition allowing to set where the virtual network link lives.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRegion<ParentT>
    {
        /// <summary>
        /// Specifies where the virtual network link lives.
        /// </summary>
        /// <param name="regionName">The value of region name.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithRegion(string regionName);

        /// <summary>
        /// Specifies where the virtual network link lives.
        /// </summary>
        /// <param name="region">The value of region.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithRegion(Region region);
    }

    /// <summary>
    /// The stage of the virtual network link definition allowing to set the tags of the virtual network link.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTags<ParentT>
    {
        /// <summary>
        /// Specifies the tags of virtual network link.
        /// </summary>
        /// <param name="tags">The value of tags.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithTags(IDictionary<string, string> tags);

        /// <summary>
        /// Specifies to add a tag to the virtual network link.
        /// </summary>
        /// <param name="key">the key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> WithTag(string key, string value);
    }
}
