// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.PolicyAssignment.Definition
{
    /// <summary>
    /// The entirety of the PolicyAssignment definition.
    /// </summary>
    public interface IDefinition :
        IBlank,
        IWithPolicyDefinition,
        IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a PolicyAssignment definition.
    /// </summary>
    public interface IBlank :
        IWithScope
    {
    }

    /// <summary>
    /// The stage of the PolicyAssignment definition allowing to specify scope.
    /// </summary>
    public interface IWithScope
    {
        /// <summary>
        /// Specifies the scope of PolicyAssignment.
        /// </summary>
        /// <param name="scope">The scope of the PolicyAssignment.</param>
        /// <return>The next stage of the definition.</return>
        IWithPolicyDefinition ForScope(string scope);

        /// <summary>
        /// Specifies the scope of PolicyAssignment to be a resource group.
        /// </summary>
        /// <param name="resourceGroup">The resource group to assign the policy.</param>
        /// <return>The next stage of the definition.</return>
        IWithPolicyDefinition ForResourceGroup(IResourceGroup resourceGroup);

        /// <summary>
        /// Specifies the scope of PolicyAssignment to be a resource.
        /// </summary>
        /// <param name="genericResource">The resource to assign the policy.</param>
        /// <return>The next stage of the definition.</return>
        IWithPolicyDefinition ForResource(IGenericResource genericResource);
    }

    /// <summary>
    /// The stage of the PolicyAssignment definition allowing to specify policy definition.
    /// </summary>
    public interface IWithPolicyDefinition
    {
        /// <summary>
        /// Specifies the policy definition ID of PolicyAssignment.
        /// </summary>
        /// <param name="policyDefinitionId">The policy definitioin ID of the PolicyAssignment.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithPolicyDefinitionId(string policyDefinitionId);

        /// <summary>
        /// Specifies the policy definition of PolicyAssignment.
        /// </summary>
        /// <param name="policyDefinition">The policy definitioin of the PolicyAssignment.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithPolicyDefinition(IPolicyDefinition policyDefinition);
    }

    /// <summary>
    /// The stage of the PolicyAssignment definition allowing to specify description.
    /// </summary>
    public interface IWithDescription
    {
        /// <summary>
        /// Specifies the description of PolicyAssignment.
        /// </summary>
        /// <param name="description">The description of the PolicyAssignment.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithDescription(string description);
    }

    /// <summary>
    /// The stage of the PolicyAssignment definition allowing to specify display name.
    /// </summary>
    public interface IWithDisplayName
    {
        /// <summary>
        /// Specifies the display name of PolicyAssignment.
        /// </summary>
        /// <param name="displayName">The display name of the PolicyAssignment.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithDisplayName(string displayName);
    }

    /// <summary>
    /// The stage of the PolicyAssignment definition allowing to specify enforcement mode.
    /// </summary>
    public interface IWithEnforcementMode
    {
        /// <summary>
        /// Specifies the 'Default' mode of PolicyAssignment.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithDefaultMode();

        /// <summary>
        /// Specifies the 'DoNotEnforce' mode of PolicyAssignment.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithDoNotEnforceMode();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Core.ResourceActions.ICreatable<IPolicyAssignment>,
        IWithDescription,
        IWithDisplayName,
        IWithEnforcementMode
    {
    }
    
}