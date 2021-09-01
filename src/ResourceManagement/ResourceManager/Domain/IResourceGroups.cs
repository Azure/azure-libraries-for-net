// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.ResourceGroup.Definition;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point to resource group management API.
    /// </summary>
    public interface IResourceGroups :
        ISupportsListing<IResourceGroup>,
        ISupportsListingByTag<IResourceGroup>,
        ISupportsGettingByName<IResourceGroup>,
        ISupportsCreating<IBlank>,
        ISupportsDeletingByName,
        ISupportsBeginDeletingByName,
        ISupportsBatchCreation<IResourceGroup>
    {
        /// <summary>
        /// Checks whether resource group exists.
        /// </summary>
        /// <param name="name">name The name of the resource group to check. The name is case insensitive</param>
        /// <returns>true if the resource group exists; false otherwise</returns>
        [Obsolete("Use Contain() instead.")]
        bool CheckExistence(string name);

        /// <summary>
        /// Checks whether resource group exists.
        /// </summary>
        /// <param name="name">name The name of the resource group to check. The name is case insensitive</param>
        /// <returns>true if the resource group exists; false otherwise</returns>
        bool Contain(string name);

        /// <summary>
        /// Checks whether resource group exists.
        /// </summary>
        /// <param name="name">name The name of the resource group to check. The name is case insensitive</param>
        /// <returns>true if the resource group exists; false otherwise</returns>
        [Obsolete("Use ContainAsync() instead.")]
        Task<bool> CheckExistenceAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks whether resource group exists.
        /// </summary>
        /// <param name="name">name The name of the resource group to check. The name is case insensitive</param>
        /// <returns>true if the resource group exists; false otherwise</returns>
        Task<bool> ContainAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">the name of the resource to delete</param>
        /// <param name="forceDeletionTypes">The resource types you want to force delete. Currently, only the following is supported: Microsoft.Compute/virtualMachines,Microsoft.Compute/virtualMachineScaleSets</param>
        void DeleteByName(string name, string forceDeletionTypes);

        /// <summary>
        /// Deletes a resource asynchronously from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">the name of the resource to delete</param>
        /// <param name="forceDeletionTypes">The resource types you want to force delete. Currently, only the following is supported: Microsoft.Compute/virtualMachines,Microsoft.Compute/virtualMachineScaleSets</param>
        /// <param name="cancellationToken"></param>
        Task DeleteByNameAsync(string name, string forceDeletionTypes, CancellationToken cancellationToken = default(CancellationToken));
    }
}
