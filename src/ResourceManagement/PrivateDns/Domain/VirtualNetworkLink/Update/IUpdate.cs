// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.PrivateDns.Fluent.VirtualNetworkLink.Update
{
    /// <summary>
    /// The set of configurations that can be updated for virtual network link.
    /// </summary>
    public interface IUpdate :
        ResourceManager.Fluent.Core.ChildResourceActions.ISettable<PrivateDnsZone.Update.IUpdate>,
        IWithAutoRegistration,
        IWithETagCheck,
        IWithTags
    {
    }

    /// <summary>
    /// The stage of the virtual network link definition allowing to manage auto-registration of virtual network records.
    /// </summary>
    public interface IWithAutoRegistration
    {
        /// <summary>
        /// Enables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate EnableAutoRegistration();

        /// <summary>
        /// Disables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate DisableAutoRegistration();
    }

    /// <summary>
    /// The stage of the virtual network link update allowing to enable ETag validation.
    /// </summary>
    public interface IWithETagCheck
    {
        /// <summary>
        /// Specifies that If-Match header needs to set to the current eTag value associated
        /// with the virtual network link.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithETagCheck();

        /// <summary>
        /// Specifies that if-Match header needs to set to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithETagCheck(string eTagValue);
    }

    /// <summary>
    /// The stage of the virtual network link definition allowing to update the tags of the virtual network link.
    /// </summary>
    public interface IWithTags
    {
        /// <summary>
        /// Specifies the tags of virtual network link.
        /// </summary>
        /// <param name="tags">The value of tags.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithTags(IDictionary<string, string> tags);

        /// <summary>
        /// Specifies to add a tag to the virtual network link.
        /// </summary>
        /// <param name="key">the key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithTag(string key, string value);

        /// <summary>
        /// Removes a tag from the virtual network link.
        /// </summary>
        /// <param name="key">the key for the tag to remove.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutTag(string key);
    }
}
