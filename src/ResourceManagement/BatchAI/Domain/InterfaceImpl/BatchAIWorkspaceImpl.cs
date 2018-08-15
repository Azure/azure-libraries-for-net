// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class BatchAIWorkspaceImpl
    {
        /// <summary>
        /// Gets the creationTime value.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace.CreationTime
        {
            get
            {
                return this.CreationTime();
            }
        }

        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the provisioningStateTransitionTime value.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace.ProvisioningStateTransitionTime
        {
            get
            {
                return this.ProvisioningStateTransitionTime();
            }
        }

        /// <return>The entry point to Batch AI clusters management API for this workspace.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIClusters Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace.Clusters()
        {
            return this.Clusters();
        }

        /// <return>The entry point to Batch AI experiments management API for this workspace.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiments Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace.Experiments()
        {
            return this.Experiments();
        }

        /// <return>The entry point to Batch AI file servers management API for this workspace.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServers Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace.FileServers()
        {
            return this.FileServers();
        }
    }
}