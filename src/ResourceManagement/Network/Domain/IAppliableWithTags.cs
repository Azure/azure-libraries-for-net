// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.UpdatableWithTags.UpdatableWithTags;
    using Microsoft.Rest;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The base interface for all template interfaces that support update tags operations.
    /// </summary>
    /// <typeparam name="T">The type of the resource returned from the update.</typeparam>
    public interface IAppliableWithTags<T>  :
        UpdatableWithTags.UpdatableWithTags.IUpdateWithTags<T>
    {

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <return>The updated resource.</return>
        T ApplyTags();

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        Task<T> ApplyTagsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}