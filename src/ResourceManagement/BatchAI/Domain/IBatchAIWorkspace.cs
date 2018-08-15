// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// Type representing Workspace.
    /// </summary>
    public interface IBatchAIWorkspace  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<IBatchAIManager, WorkspaceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<BatchAIWorkspace.Update.IUpdate>
    {

        /// <summary>
        /// Gets the creationTime value.
        /// </summary>
        System.DateTime CreationTime { get; }

        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets the provisioningStateTransitionTime value.
        /// </summary>
        System.DateTime ProvisioningStateTransitionTime { get; }

        /// <return>The entry point to Batch AI clusters management API for this workspace.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIClusters Clusters();

        /// <return>The entry point to Batch AI experiments management API for this workspace.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiments Experiments();

        /// <return>The entry point to Batch AI file servers management API for this workspace.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIFileServers FileServers();
    }
}