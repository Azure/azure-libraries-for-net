// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class DiagnosticSettingsImpl
    {
        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        MonitorManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>.Manager
        {
            get
            {
                return this.Manager();
            }
        }

        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        DiagnosticSetting.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<DiagnosticSetting.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Deletes a Diagnostic Setting from Azure, identifying it by its resourceId and name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        void Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.Delete(string resourceId, string name)
        {

            this.Delete(resourceId, name);
        }

        /// <summary>
        /// Asynchronously delete a Diagnostic Setting from Azure, identifying it by its resourceId and name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.DeleteAsync(string resourceId, string name, CancellationToken cancellationToken)
        {

            await this.DeleteAsync(resourceId, name, cancellationToken);
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {

            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        void Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion.DeleteByIds(IList<string> ids)
        {
            this.DeleteByIds(ids);
        }

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        void Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion.DeleteByIds(params string[] ids)
        {

            this.DeleteByIds(ids);
        }

        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        /// <return>A representation of the deferred computation of this call returning the resource ID of each successfully deleted resource.</return>
        async Task<System.Collections.Generic.IEnumerable<string>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion.DeleteByIdsAsync(IList<string> ids, CancellationToken cancellationToken)
        {
            return await this.DeleteByIdsAsync(ids, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// </summary>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        /// <return>A representation of the deferred computation of this call returning the resource ID of each successfully deleted resource.</return>
        async Task<System.Collections.Generic.IEnumerable<string>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion.DeleteByIdsAsync(string[] ids, CancellationToken cancellationToken)
        {
            return await this.DeleteByIdsAsync(ids, cancellationToken);
        }

        /// <summary>
        /// Gets the information about Diagnostic Setting from Azure based on the resource id and setting name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.Get(string resourceId, string name)
        {
            return this.Get(resourceId, name);
        }

        /// <summary>
        /// Gets the information about Diagnostic Setting from Azure based on the resource id and setting name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.GetAsync(string resourceId, string name, CancellationToken cancellationToken)
        {
            return await this.GetAsync(resourceId, name, cancellationToken);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>.GetById(string id)
        {
            return this.GetById(id);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets the information about Diagnostic Setting category for Log or Metric Setting for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <param name="name">Of the Log or Metric category.</param>
        /// <return>Diagnostic Setting category available for the resource.</return>
        Models.IDiagnosticSettingsCategory Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.GetCategory(string resourceId, string name)
        {
            return this.GetCategory(resourceId, name);
        }

        /// <summary>
        /// Gets the information about Diagnostic Setting category for Log or Metric Setting for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <param name="name">Of the Log or Metric category.</param>
        /// <return>Diagnostic Setting category available for the resource.</return>
        async Task<Models.IDiagnosticSettingsCategory> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.GetCategoryAsync(string resourceId, string name, CancellationToken cancellationToken)
        {
            return await this.GetCategoryAsync(resourceId, name, cancellationToken);
        }

        /// <summary>
        /// Lists all the diagnostic settings in the currently selected subscription for a specific resource.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.ListByResource(string resourceId)
        {
            return this.ListByResource(resourceId);
        }

        /// <summary>
        /// Lists all the diagnostic settings in the currently selected subscription for a specific resource.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <return>List of resources.</return>
        async Task<System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.ListByResourceAsync(string resourceId, CancellationToken cancellationToken)
        {
            return await this.ListByResourceAsync(resourceId, cancellationToken);
        }

        /// <summary>
        /// Lists all the Diagnostic Settings categories for Log and Metric Settings for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <return>List of Diagnostic Settings category available for the resource.</return>
        System.Collections.Generic.IReadOnlyList<Models.IDiagnosticSettingsCategory> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.ListCategoriesByResource(string resourceId)
        {
            return this.ListCategoriesByResource(resourceId);
        }

        /// <summary>
        /// Lists all the Diagnostic Settings categories for Log and Metric Settings for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <return>List of Diagnostic Settings category available for the resource.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Models.IDiagnosticSettingsCategory>> Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSettings.ListCategoriesByResourceAsync(string resourceId, CancellationToken cancellationToken)
        {
            return await this.ListCategoriesByResourceAsync(resourceId, cancellationToken);
        }
    }
}