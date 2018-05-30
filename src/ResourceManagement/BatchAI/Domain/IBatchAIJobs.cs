// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for Batch AI jobs management API in Azure.
    /// </summary>
    public interface IBatchAIJobs  :
        IBeta,
        ISupportsCreating<BatchAIJob.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob>,
        ISupportsGettingById<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob>,
        ISupportsDeletingById,
        IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.IJobsOperations>
    {
    }
}