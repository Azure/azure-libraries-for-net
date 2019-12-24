﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.MongoDB.Definition
{
    /// <summary>
    /// The entirety of a mongo database definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a mongo database definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the mongo database definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        IWithOptions<ParentT>,
        IWithThroughput<ParentT>,
        IWithChildResource<ParentT>
    {
    }

    /// <summary>
    /// The stage of the mongo database definition allowing to set options.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithOptions<ParentT> :
        HasOptions.Definition.IWithOptions<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of the mongo database definition allowing to set throughput.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithThroughput<Parent> :
        HasThroughputSettings.Definition.IWithThroughput<IWithAttach<Parent>>
    {
    }

    /// <summary>
    /// The stage of the mongo database definition allowing to set child resources.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithChildResource<ParentT>
    {
        /// <summary>
        /// Defines a new mongo collection.
        /// </summary>
        /// <param name="name">The name of the mongo collection.</param>
        /// <returns>The next stage of the definition.</returns>
        MongoCollection.Definition.IBlank<IWithAttach<ParentT>> DefineNewCollection(string name);
    }
}
