// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition
{
    /// <summary>
    /// The entirety of a Action Group definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition.IBlank,
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition.IWithCreate>,
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The first stage of a Action Group definition allowing the resource group to be specified.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition.IWithCreate>
    {

        /// <summary>
        /// Begins the definition of Action Group receivers with the specified name prefix.
        /// </summary>
        /// <param name="actionNamePrefix">Prefix for each receiver name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition.IWithCreate> DefineReceiver(string actionNamePrefix);

        /// <summary>
        /// Sets the short name of the action group. This will be used in SMS messages. Maximum length cannot exceed 12 symbols.
        /// </summary>
        /// <param name="shortName">Short name of the action group. Cannot exceed 12 symbols.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition.IWithCreate WithShortName(string shortName);
    }
}