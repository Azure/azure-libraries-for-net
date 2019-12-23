// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.SqlContainer.Definition
{
    /// <summary>
    /// The entirety of a sql container definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a sql container definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the sql container definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        IWithOptions<ParentT>,
        IWithThroughput<ParentT>,
        IWithIndexingPolicy<ParentT>,
        IWithPartitionKey<ParentT>,
        IWithDefaultTtl<ParentT>,
        IWithUniqueKeyPolicy<ParentT>,
        IWithConflictResolutionPolicy<ParentT>,
        IWithChildResource<ParentT>
    {
    }

    /// <summary>
    /// The stage of a sql container definition allowing to set options.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithOptions<ParentT> :
        HasOptions.Definition.IWithOptions<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of a sql container definition allowing to set through put.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithThroughput<ParentT> :
        HasThroughputSettings.Definition.IWithThroughput<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of a sql container definition allowing to set indexing policy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIndexingPolicy<ParentT>
    {
        /// <summary>
        /// Specifies indexing policy.
        /// </summary>
        /// <param name="indexingPolicy">The whole object of the indexing policy.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIndexingPolicy(Models.IndexingPolicy indexingPolicy);

        /// <summary>
        /// Starts the definition of indexing policy.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        IndexingPolicy.Definition.IBlank<IWithAttach<ParentT>> DefineIndexingPolicy();
    }

    /// <summary>
    /// The stage of a sql container definition allowing to set partition key.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPartitionKey<ParentT>
    {
        /// <summary>
        /// Specifies container partition key.
        /// </summary>
        /// <param name="containerPartitionKey">The whole object of the container partition key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithContainerPartitionKey(ContainerPartitionKey containerPartitionKey);
    }

    /// <summary>
    /// The stage of a sql container definition allowing to set default ttl.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDefaultTtl<ParentT>
    {
        /// <summary>
        /// Specifies default ttl.
        /// </summary>
        /// <param name="ttl">The default time to live.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithDefaultTtl(int ttl);
    }

    /// <summary>
    /// The stage of a sql container definition allowing to set unique key policy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithUniqueKeyPolicy<ParentT>
    {
        /// <summary>
        /// Specifies unique key policy.
        /// </summary>
        /// <param name="uniqueKeyPolicy">The whole object of the unique key policy.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUniqueKeyPolicy(UniqueKeyPolicy uniqueKeyPolicy);

        /// <summary>
        /// Specifies the list of unique key.
        /// </summary>
        /// <param name="uniqueKeys">The list of unique key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUniqueKeys(IList<UniqueKey> uniqueKeys);

        /// <summary>
        /// Specifies the a unique key appended to original list.
        /// </summary>
        /// <param name="uniqueKey">A unique key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUniqueKey(UniqueKey uniqueKey);
    }

    /// <summary>
    /// The stage of a sql container definition allowing to set conflict resolution policy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithConflictResolutionPolicy<ParentT>
    {
        /// <summary>
        /// Specifies conflict resolution policy.
        /// </summary>
        /// <param name="conflictResolutionPolicy">The whole object of the conflict resolution policy.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithConflictResolutionPolicy(ConflictResolutionPolicy conflictResolutionPolicy);
    }

    /// <summary>
    /// The stage of a sql container definition allowing to specify child resource.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithChildResource<ParentT>
    {
        /// <summary>
        /// Specifies a stored procedure.
        /// </summary>
        /// <param name="name">The name of the stored procedure.</param>
        /// <param name="resource">The store procedure resource, no need to specify id.</param>
        /// <param name="options">The options for the store procedure.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithStoredProcedure(string name, SqlStoredProcedureResource resource = default(SqlStoredProcedureResource), IDictionary<string, string> options = default(IDictionary<string, string>));

        /// <summary>
        /// Specifies a user defined function.
        /// </summary>
        /// <param name="name">The name of the user defined function.</param>
        /// <param name="resource">The user defined function resource, no need to specify id.</param>
        /// <param name="options">The options for the user defined function.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUserDefinedFunction(string name, SqlUserDefinedFunctionResource resource = default(SqlUserDefinedFunctionResource), IDictionary<string, string> options = default(IDictionary<string, string>));

        /// <summary>
        /// Specifies a trigger.
        /// </summary>
        /// <param name="name">The name of the trigger.</param>
        /// <param name="resource">The trigger resource, no need to specify id.</param>
        /// <param name="options">The options for the trigger.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithTrigger(string name, SqlTriggerResource resource = default(SqlTriggerResource), IDictionary<string, string> options = default(IDictionary<string, string>));
    }
}
