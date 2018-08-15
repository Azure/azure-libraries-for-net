// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// Entry point for Batch AI Experiment management API in Azure.
    /// </summary>
    public interface IBatchAIExperiment  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.Models.ExperimentInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment>
    {

        /// <summary>
        /// Gets time when the Experiment was created.
        /// </summary>
        System.DateTime CreationTime { get; }

        /// <summary>
        /// Gets the entry point to Batch AI jobs management API for this experiment.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJobs Jobs { get; }

        /// <summary>
        /// Gets the provisioned state of the experiment.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the time at which the experiment entered its current provisioning state.
        /// </summary>
        System.DateTime ProvisioningStateTransitionTime { get; }

        /// <summary>
        /// Gets workspace this experiment belongs to.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace Workspace { get; }
    }
}