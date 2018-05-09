// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.UpdatableWithTags.UpdatableWithTags
{
    using Microsoft.Azure.Management.Network.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// An update allowing tags to be modified for the resource.
    /// </summary>
    /// <typeparam name="T">The type of the resource being update.</typeparam>
    public interface IUpdateWithTags<T> 
    {

        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.IAppliableWithTags<T> WithoutTag(string key);

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.IAppliableWithTags<T> WithTag(string key, string value);

        /// <summary>
        /// Specifies tags for the resource as a  Map.
        /// </summary>
        /// <param name="tags">A  Map of tags.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.IAppliableWithTags<T> WithTags(IDictionary<string,string> tags);
    }
}