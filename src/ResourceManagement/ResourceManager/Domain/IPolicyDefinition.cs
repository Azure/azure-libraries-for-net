// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Policy Definition.
    /// </summary>
    public interface IPolicyDefinition :
        IHasName,
        IHasId,
        IIndexable,
        IRefreshable<IPolicyDefinition>,
        IUpdatable<PolicyDefinition.Update.IUpdate>
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
        /// Gets the mode value.
        /// </summary>
        string Mode { get; }

        /// <summary>
        /// Gets the policy rule value.
        /// </summary>
        Object PolicyRule { get; }

        /// <summary>
        /// Gets the policy type value.
        /// </summary>
        PolicyType PolicyType { get; }
    }
}