// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BatchAIExperimentImpl 
    {
        /// <summary>
        /// Gets time when the Experiment was created.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment.CreationTime
        {
            get
            {
                return this.CreationTime();
            }
        }

        /// <summary>
        /// Gets the entry point to Batch AI jobs management API for this experiment.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJobs Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment.Jobs
        {
            get
            {
                return this.Jobs() as Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJobs;
            }
        }

        /// <summary>
        /// Gets the provisioned state of the experiment.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the time at which the experiment entered its current provisioning state.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment.ProvisioningStateTransitionTime
        {
            get
            {
                return this.ProvisioningStateTransitionTime();
            }
        }

        /// <summary>
        /// Gets workspace this experiment belongs to.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment.Workspace
        {
            get
            {
                return this.Workspace() as Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace;
            }
        }
    }
}