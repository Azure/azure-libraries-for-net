// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.PolicyDefinition.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using System;

    /// <summary>
    /// The template for a PolicyDefinition update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Core.ResourceActions.IAppliable<IPolicyDefinition>,
        IWithDescription,
        IWithDisplayName,
        IWithMode,
        IWithPolicyRule,
        IWithPolicyType
    {
    }

    /// <summary>
    /// The stage of the PolicyDefinition update allowing to specify description.
    /// </summary>
    public interface IWithDescription
    {
        /// <summary>
        /// Specifies the description of PolicyDefinition.
        /// </summary>
        /// <param name="description">The description of the PolicyDefinition.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithDescription(string description);
    }

    /// <summary>
    /// The stage of the PolicyDefinition update allowing to specify display name.
    /// </summary>
    public interface IWithDisplayName
    {
        /// <summary>
        /// Specifies the display name of PolicyDefinition.
        /// </summary>
        /// <param name="displayName">The display name of the PolicyDefinition.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithDisplayName(string displayName);
    }

    /// <summary>
    /// The stage of the PolicyDefinition update allowing to specify mode.
    /// </summary>
    public interface IWithMode
    {
        /// <summary>
        /// Specifies the mode of PolicyDefinition.
        /// </summary>
        /// <param name="mode">The mode of the PolicyDefinition.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithMode(string mode);
    }

    /// <summary>
    /// The stage of the PolicyDefinition update allowing to specify policy rule.
    /// </summary>
    public interface IWithPolicyRule
    {
        /// <summary>
        /// Specifies the policy rule of PolicyDefinition.
        /// </summary>
        /// <param name="policyRule">The policy rule of the PolicyDefinition.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithPolicyRule(Object policyRule);
    }

    /// <summary>
    /// The stage of the PolicyDefinition update allowing to specify policy type.
    /// </summary>
    public interface IWithPolicyType
    {
        /// <summary>
        /// Specifies the policy type of PolicyDefinition to be 'NotSpecified'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithNotSpecifiedPolicyType();

        /// <summary>
        /// Specifies the policy type of PolicyDefinition to be 'BuiltIn'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithBuiltInPolicyType();

        /// <summary>
        /// Specifies the policy type of PolicyDefinition to be 'Custom'.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithCustomPolicyType();

        /// <summary>
        /// Removes the policy type of PolicyDefinition.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutPolicyType();
    }
}