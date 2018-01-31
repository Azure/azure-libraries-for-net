// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a Activity Logs query definition.
    /// </summary>
    public interface IActivityLogsQueryDefinition :
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataStartTimeFilter,
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataEndFilter,
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataFieldFilter,
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter,
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute
    {
    }

    /// <summary>
    /// Entry point for Monitor Activity logs API.
    /// </summary>
    public interface IActivityLogs :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<MonitorManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IActivityLogsOperations>
    {
        /// <summary>
        /// Gets Begins a definition for a new Activity log query.
        /// </summary>
        /// <summary>
        /// Gets the stage of start time filter definition.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataStartTimeFilter DefineQuery();
    }

    /// <summary>
    /// The stage of the Activity log filtering by type and query execution.
    /// </summary>
    public interface IWithActivityLogsSelectFilter :
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute
    {
        /// <summary>
        /// Filters events for a given resource provider.
        /// </summary>
        /// <param name="resourceProviderName">Specifies resource provider.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute FilterByResourceProvider(string resourceProviderName);

        /// <summary>
        /// Filters events for a given resource.
        /// </summary>
        /// <param name="resourceId">Specifies resource Id.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute FilterByResource(string resourceId);

        /// <summary>
        /// Filters events for a given resource group.
        /// </summary>
        /// <param name="resourceGroupName">Specifies resource group name.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute FilterByResourceGroup(string resourceGroupName);

        /// <summary>
        /// Filters events for a given correlation id.
        /// </summary>
        /// <param name="correlationId">Specifies correlation id.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute FilterByCorrelationId(string correlationId);
    }

    /// <summary>
    /// The stage of the Activity log query execution.
    /// </summary>
    public interface IWithActivityLogsQueryExecute
    {
        /// <summary>
        /// Gets Executes the query.
        /// </summary>
        /// <summary>
        /// Gets Activity Log events received after query execution.
        /// </summary>
        System.Collections.Generic.IEnumerable<Models.IEventData> Execute();

        /// <summary>
        /// Gets Executes the query.
        /// </summary>
        /// <summary>
        /// Gets a representation of the deferred computation of Activity Log query call.
        /// </summary>
        Task<IPagedCollection<IEventData>> ExecuteAsync(CancellationToken cancellationToken);
    }

    /// <summary>
    /// The stage of a Activity Log query allowing to specify start time filter.
    /// </summary>
    public interface IWithEventDataStartTimeFilter
    {
        /// <summary>
        /// Sets the start time for Activity Log query filter.
        /// </summary>
        /// <param name="startTime">Specifies start time of cut off filter.</param>
        /// <return>The stage of end time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataEndFilter StartingFrom(DateTime startTime);
    }

    /// <summary>
    /// Grouping of Activity log query stages.
    /// </summary>
    public interface IActivityLogsQueryDefinitionStages
    {
    }

    /// <summary>
    /// The stage of a Activity Log query allowing to specify data fields in the server response.
    /// </summary>
    public interface IWithEventDataFieldFilter
    {
        /// <summary>
        /// Selects data fields that will be populated in the server response.
        /// </summary>
        /// <param name="responseProperties">Field names in the server response.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter WithResponseProperties(params EventDataPropertyName[] responseProperties);

        /// <summary>
        /// Sets the server response to include all the available properties.
        /// </summary>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter WithAllPropertiesInResponse();
    }

    /// <summary>
    /// The stage of a Activity Log query allowing to specify end time filter.
    /// </summary>
    public interface IWithEventDataEndFilter
    {
        /// <summary>
        /// Sets the end time for Activity Log query filter.
        /// </summary>
        /// <param name="endTime">Specifies end time of cut off filter.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataFieldFilter EndsBefore(DateTime endTime);
    }
}