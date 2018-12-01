// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of a Container Registry source trigger.
    /// </summary>
    public interface IRegistrySourceTrigger  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SourceTrigger>
    {

        /// <summary>
        /// Gets the branch of the repository that is being used as source control. I.e., master.
        /// </summary>
        string SourceControlBranch { get; }

        /// <summary>
        /// Gets the URL of the repository used as source control.
        /// </summary>
        string SourceControlRepositoryUrl { get; }

        /// <summary>
        /// Gets Returns the type of source control this trigger uses. I.e., Github, AzureDevOps etc.
        /// </summary>
        Models.SourceControlType SourceControlType { get; }

        /// <summary>
        /// Gets the list of actions that trigger an event. I.e., a commit, a pull request etc.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SourceTriggerEvent> SourceTriggerEvents { get; }

        /// <summary>
        /// Gets the source trigger status. I.e., enabled, disabled.
        /// </summary>
        Models.TriggerStatus Status { get; }
    }
}