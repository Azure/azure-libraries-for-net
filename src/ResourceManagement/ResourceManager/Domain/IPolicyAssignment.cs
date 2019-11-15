// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure Policy Assignment.
    /// </summary>
    public interface IPolicyAssignment :
        IHasName,
        IHasId,
        IIndexable,
        IRefreshable<IPolicyAssignment>,
        IHasInner<PolicyAssignmentInner>
    {
        /// <summary>
        /// Gets the description value.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the display name value.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the enforcement mode value.
        /// </summary>
        EnforcementMode EnforcementMode { get; }

        /// <summary>
        /// Gets the scope value.
        /// </summary>
        string Scope { get; }

        /// <summary>
        /// Gets the policy definition ID value.
        /// </summary>
        string PolicyDefinitionId { get; }
    }
}
