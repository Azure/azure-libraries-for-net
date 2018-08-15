// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent.BatchAIExperiment.Definition
{
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of a Batch AI experiment definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIExperiment.Definition.IWithCreate
    {

    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment>
    {

    }
}