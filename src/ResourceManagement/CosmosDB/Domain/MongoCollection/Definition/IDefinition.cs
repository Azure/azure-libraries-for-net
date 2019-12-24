// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.MongoCollection.Definition
{
    /// <summary>
    /// The entirety of a mongo collection definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a mongo collection definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the mongo collection definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        IWithOptions<ParentT>,
        IWithThroughput<ParentT>,
        IWithSharedKey<ParentT>,
        IWithIndex<ParentT>
    {
    }

    /// <summary>
    /// The stage of the mongo collection definition allowing to set options.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithOptions<ParentT> :
        HasOptions.Definition.IWithOptions<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of the mongo collection definition allowing to set throughput.
    /// </summary>
    /// <typeparam name="Parent">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithThroughput<Parent> :
        HasThroughputSettings.Definition.IWithThroughput<IWithAttach<Parent>>
    {
    }

    /// <summary>
    /// The stage of the mongo collection definition allowing to set shared keys.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSharedKey<ParentT>
    {
        /// <summary>
        /// Specifies a shared key with default partition kind "Hash".
        /// </summary>
        /// <param name="sharedKey">The shared key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSharedKey(string sharedKey);

        /// <summary>
        /// Specifies a shared key.
        /// </summary>
        /// <param name="sharedKey">The shared key.</param>
        /// <param name="partitionKind">The partition kind, only support "Hash" partition kind in api-version 2019-08-01.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSharedKey(string sharedKey, string partitionKind);

        /// <summary>
        /// Appends all shared keys to current shared keys.
        /// </summary>
        /// <param name="sharedKeys">The shared keys needs appending.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithSharedKeys(IDictionary<string, string> sharedKeys);
    }

    /// <summary>
    /// The stage of the mongo collection definition allowing to set indexes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIndex<ParentT>
    {
        /// <summary>
        /// Specifies a mongo index.
        /// </summary>
        /// <param name="index">The specific mongo index.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIndex(MongoIndex index);

        /// <summary>
        /// Specifies a mongo index.
        /// </summary>
        /// <param name="key">The key of the index.</param>
        /// <param name="option">The option of the index.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIndex(MongoIndexKeys key, MongoIndexOptions option);

        /// <summary>
        /// Appends all mongo indexes to current indexes.
        /// </summary>
        /// <param name="indexes">The indexes needs appending.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIndexes(IList<MongoIndex> indexes);
    }
}
