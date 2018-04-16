// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for diagnostic settings management API.
    /// </summary>
    public interface IDiagnosticSettings :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<DiagnosticSetting.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IDiagnosticSettingsOperations>
    {

        /// <summary>
        /// Deletes a Diagnostic Setting from Azure, identifying it by its resourceId and name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        void Delete(string resourceId, string name);

        /// <summary>
        /// Asynchronously delete a Diagnostic Setting from Azure, identifying it by its resourceId and name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(string resourceId, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the information about Diagnostic Setting from Azure based on the resource id and setting name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting Get(string resourceId, string name);

        /// <summary>
        /// Gets the information about Diagnostic Setting from Azure based on the resource id and setting name.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <param name="name">The name of Diagnostic Setting.</param>
        /// <return>An immutable representation of the resource.</return>
        Task<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> GetAsync(string resourceId, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the information about Diagnostic Setting category for Log or Metric Setting for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <param name="name">Of the Log or Metric category.</param>
        /// <return>Diagnostic Setting category available for the resource.</return>
        Models.IDiagnosticSettingsCategory GetCategory(string resourceId, string name);

        /// <summary>
        /// Gets the information about Diagnostic Setting category for Log or Metric Setting for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <param name="name">Of the Log or Metric category.</param>
        /// <return>Diagnostic Setting category available for the resource.</return>
        Task<Models.IDiagnosticSettingsCategory> GetCategoryAsync(string resourceId, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the diagnostic settings in the currently selected subscription for a specific resource.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting> ListByResource(string resourceId);

        /// <summary>
        /// Lists all the diagnostic settings in the currently selected subscription for a specific resource.
        /// </summary>
        /// <param name="resourceId">That Diagnostic Setting is associated with.</param>
        /// <return>List of resources.</return>
        Task<System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Monitor.Fluent.IDiagnosticSetting>> ListByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the Diagnostic Settings categories for Log and Metric Settings for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <return>List of Diagnostic Settings category available for the resource.</return>
        System.Collections.Generic.IReadOnlyList<Models.IDiagnosticSettingsCategory> ListCategoriesByResource(string resourceId);

        /// <summary>
        /// Lists all the Diagnostic Settings categories for Log and Metric Settings for a specific resource.
        /// </summary>
        /// <param name="resourceId">Of the requested resource.</param>
        /// <return>List of Diagnostic Settings category available for the resource.</return>
        Task<System.Collections.Generic.IReadOnlyList<Models.IDiagnosticSettingsCategory>> ListCategoriesByResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken));
    }
}