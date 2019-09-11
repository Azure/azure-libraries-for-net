// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to deleting a resource from Azure, with additional option.
    /// </summary>
    public interface ISupportAppDeleteOption
    {
        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">the resource ID of the resource to delete</param>
        /// <param name="option">the option for deletion</param>
        void DeleteById(string id, AppDeleteOption option);

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">the resource ID of the resource to delete</param>
        /// <param name="option">the option for deletion</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task DeleteByIdAsync(string id, AppDeleteOption option, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">the group the resource is part of</param>
        /// <param name="name">the name of the resource</param>
        /// <param name="option">the option for deletion</param>
        void DeleteByResourceGroup(string resourceGroupName, string name, AppDeleteOption option);

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">the group the resource is part of</param>
        /// <param name="name">the name of the resource</param>
        /// <param name="option">the option for deletion</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task DeleteByResourceGroupAsync(string resourceGroupName, string name, AppDeleteOption option, CancellationToken cancellationToken = default(CancellationToken));
    }
}
