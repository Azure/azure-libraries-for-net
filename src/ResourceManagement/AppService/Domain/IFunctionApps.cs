// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for web app management API.
    /// </summary>
    public interface IFunctionApps  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<FunctionApp.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.AppService.Fluent.IWebAppsOperations>
    {
        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">the resource ID of the resource to delete</param>
        /// <param name="deleteMetrics">if true, web app metrics are also deleted</param>
        /// <param name="deleteEmptyServerFarm">if true, empty App Service plan are also deleted</param>
        void DeleteById(string id, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?));

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">the resource ID of the resource to delete</param>
        /// <param name="deleteMetrics">if true, web app metrics are also deleted</param>
        /// <param name="deleteEmptyServerFarm">if true, empty App Service plan are also deleted</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task DeleteByIdAsync(string id, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">the group the resource is part of</param>
        /// <param name="name">the name of the resource</param>
        /// <param name="deleteMetrics">if true, web app metrics are also deleted</param>
        /// <param name="deleteEmptyServerFarm">if true, empty App Service plan are also deleted</param>
        void DeleteByResourceGroup(string resourceGroupName, string name, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?));

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">the group the resource is part of</param>
        /// <param name="name">the name of the resource</param>
        /// <param name="deleteMetrics">if true, web app metrics are also deleted</param>
        /// <param name="deleteEmptyServerFarm">if true, empty App Service plan are also deleted</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task DeleteByResourceGroupAsync(string resourceGroupName, string name, bool? deleteMetrics = default(bool?), bool? deleteEmptyServerFarm = default(bool?), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists basic info for Function Apps in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName"> the name of the resource group to list the resources from</param>
        /// <returns>the list of resources</returns>
        IEnumerable<IFunctionAppBasic> ListFunctionAppBasicByResourceGroup(string resourceGroupName);

        /// <summary>
        /// Lists basic info for Function Apps in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName"> the name of the resource group to list the resources from</param>
        /// <returns>the list of resources</returns>
        Task<IPagedCollection<IFunctionAppBasic>> ListFunctionAppBasicByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists basic info for Function Apps in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        IEnumerable<IFunctionAppBasic> ListFunctionAppBasic();

        /// <summary>
        /// Lists basic info for Function Apps in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        Task<IPagedCollection<IFunctionAppBasic>> ListFunctionAppBasicAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
