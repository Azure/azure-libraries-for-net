// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The first stage of a Workspace definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition.IWithGroup>
    {

    }

    /// <summary>
    /// The stage of the Workspace definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        IWithGroup<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIWorkspace>,
        IDefinitionWithTags<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition.IWithCreate>
    {

    }

    /// <summary>
    /// The entirety of the Workspace definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition.IBlank,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition.IWithGroup,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIWorkspace.Definition.IWithCreate
    {

    }
}