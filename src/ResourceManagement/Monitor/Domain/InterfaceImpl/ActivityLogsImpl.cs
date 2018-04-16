// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class ActivityLogsImpl
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
        /// Begins a definition for a new Activity log query.
        /// </summary>
        /// <return>The stage of start time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataStartTimeFilter Microsoft.Azure.Management.Monitor.Fluent.IActivityLogs.DefineQuery()
        {
            return this.DefineQuery();
        }

        /// <summary>
        /// Sets the end time for Activity Log query filter.
        /// </summary>
        /// <param name="endTime">Specifies end time of cut off filter.</param>
        /// <return>The stage of optional query parameter definition and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataFieldFilter Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataEndFilter.EndsBefore(DateTime endTime)
        {
            return this.EndsBefore(endTime);
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <return>Activity Log events received after query execution.</return>
        System.Collections.Generic.IEnumerable<Models.IEventData> Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute.Execute()
        {
            return this.Execute();
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <return>A representation of the deferred computation of Activity Log query call.</return>
        async Task<System.Collections.Generic.IEnumerable<Models.IEventData>> Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await this.ExecuteAsync(cancellationToken);
        }

        /// <summary>
        /// Filters events that were generated at the Tenant level.
        /// </summary>
        /// <return>The stage of Activity log filtering by Tenant level and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute.FilterAtTenantLevel()
        {
            return this.FilterAtTenantLevel();
        }

        /// <summary>
        /// Filters events for a given correlation id.
        /// </summary>
        /// <param name="correlationId">Specifies correlation id.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter.FilterByCorrelationId(string correlationId)
        {
            return this.FilterByCorrelationId(correlationId);
        }

        /// <summary>
        /// Filters events for a given resource.
        /// </summary>
        /// <param name="resourceId">Specifies resource Id.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter.FilterByResource(string resourceId)
        {
            return this.FilterByResource(resourceId);
        }

        /// <summary>
        /// Filters events for a given resource group.
        /// </summary>
        /// <param name="resourceGroupName">Specifies resource group name.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter.FilterByResourceGroup(string resourceGroupName)
        {
            return this.FilterByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Filters events for a given resource provider.
        /// </summary>
        /// <param name="resourceProviderName">Specifies resource provider.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsQueryExecute Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter.FilterByResourceProvider(string resourceProviderName)
        {
            return this.FilterByResourceProvider(resourceProviderName);
        }

        /// <summary>
        /// Lists available event categories supported in the Activity Logs Service.
        /// </summary>
        /// <return>List of available event categories supported in the Activity Logs Service.</return>
        System.Collections.Generic.IReadOnlyList<Models.ILocalizableString> Microsoft.Azure.Management.Monitor.Fluent.IActivityLogs.ListEventCategories()
        {
            return this.ListEventCategories();
        }

        /// <summary>
        /// Lists available event categories supported in the Activity Logs Service.
        /// </summary>
        /// <return>List of available event categories supported in the Activity Logs Service.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Models.ILocalizableString>> Microsoft.Azure.Management.Monitor.Fluent.IActivityLogs.ListEventCategoriesAsync(CancellationToken cancellationToken)
        {
            return await this.ListEventCategoriesAsync(cancellationToken);
        }

        /// <summary>
        /// Sets the start time for Activity Log query filter.
        /// </summary>
        /// <param name="startTime">Specifies start time of cut off filter.</param>
        /// <return>The stage of end time filter definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataEndFilter Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataStartTimeFilter.StartingFrom(DateTime startTime)
        {
            return this.StartingFrom(startTime);
        }

        /// <summary>
        /// Sets the server response to include all the available properties.
        /// </summary>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataFieldFilter.WithAllPropertiesInResponse()
        {
            return this.WithAllPropertiesInResponse();
        }

        /// <summary>
        /// Selects data fields that will be populated in the server response.
        /// </summary>
        /// <param name="responseProperties">Field names in the server response.</param>
        /// <return>The stage of Activity log filtering by type and query execution.</return>
        Microsoft.Azure.Management.Monitor.Fluent.IWithActivityLogsSelectFilter Microsoft.Azure.Management.Monitor.Fluent.IWithEventDataFieldFilter.WithResponseProperties(params EventDataPropertyName[] responseProperties)
        {
            return this.WithResponseProperties(responseProperties);
        }
    }
}