// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.PolicyDefinition.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using System;

    /// <summary>
    /// The entirety of the PolicyDefinition definition.
    /// </summary>
    public interface IDefinition :
        IBlank,
        IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a PolicyDefinition definition.
    /// </summary>
    public interface IBlank :
        IWithPolicyRule
    {
    }

    /// <summary>
    /// The stage of the PolicyDefinition definition allowing to specify policy rule.
    /// </summary>
    public interface IWithPolicyRule
    {
        /// <summary>
        /// Specifies the policy rule of PolicyDefinition.
        /// </summary>
        /// <param name="policyRule">The policy rule of the PolicyDefinition.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithPolicyRule(Object policyRule);

        /// <summary>
        /// Specifies the policy rule of PolicyDefinition.
        /// </summary>
        /// <param name="policyRuleJson">The policy rule of the PolicyDefinition.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithPolicyRuleJson(string policyRuleJson);
    }

    /// <summary>
    /// The stage of the PolicyDefinition definition allowing to specify description.
    /// </summary>
    public interface IWithDescription
    {
        /// <summary>
        /// Specifies the description of PolicyDefinition.
        /// </summary>
        /// <param name="description">The description of the PolicyDefinition.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithDescription(string description);
    }

    /// <summary>
    /// The stage of the PolicyDefinition definition allowing to specify display name.
    /// </summary>
    public interface IWithDisplayName
    {
        /// <summary>
        /// Specifies the display name of PolicyDefinition.
        /// </summary>
        /// <param name="displayName">The display name of the PolicyDefinition.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithDisplayName(string displayName);
    }

    /// <summary>
    /// The stage of the PolicyDefinition definition allowing to specify mode.
    /// </summary>
    public interface IWithMode
    {
        /// <summary>
        /// Specifies the mode of PolicyDefinition.
        /// </summary>
        /// <param name="mode">The mode of the PolicyDefinition.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithMode(string mode);
    }

    /// <summary>
    /// The stage of the PolicyDefinition definition allowing to specify policy type.
    /// </summary>
    public interface IWithPolicyType
    {
        /// <summary>
        /// Specifies the policy type of PolicyDefinition to be 'NotSpecified'.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithNotSpecifiedPolicyType();

        /// <summary>
        /// Specifies the policy type of PolicyDefinition to be 'BuiltIn'.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithBuiltInPolicyType();

        /// <summary>
        /// Specifies the policy type of PolicyDefinition to be 'Custom'.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithCustomPolicyType();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Core.ResourceActions.ICreatable<IPolicyDefinition>,
        IWithDescription,
        IWithDisplayName,
        IWithMode,
        IWithPolicyType
    {
    }
}