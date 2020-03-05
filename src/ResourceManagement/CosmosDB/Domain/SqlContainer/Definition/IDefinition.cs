// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.SqlContainer.Definition
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a SQL container definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT> :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a SQL container definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the SQL container definition.
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
    /// The stage of a SQL container definition allowing to set options.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithOptions<ParentT> :
        HasOptions.Definition.IWithOptions<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of a SQL container definition allowing to set throughput.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithThroughput<ParentT> :
        HasThroughputSettings.Definition.IWithThroughput<IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The stage of a SQL container definition allowing to set indexing policy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIndexingPolicy<ParentT>
    {
        /// <summary>
        /// Specifies the indexing policy.
        /// </summary>
        /// <param name="indexingPolicy">The indexing policy.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithIndexingPolicy(Models.IndexingPolicy indexingPolicy);

        /// <summary>
        /// Starts the definition of the indexing policy.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        IndexingPolicy.Definition.IBlank<IWithAttach<ParentT>> DefineIndexingPolicy();
    }

    /// <summary>
    /// The stage of a SQL container definition allowing to set partition key.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPartitionKey<ParentT>
    {
        /// <summary>
        /// Specifies the container partition key.
        /// </summary>
        /// <param name="containerPartitionKey">The whole object of the container partition key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithPartitionKey(Models.ContainerPartitionKey containerPartitionKey);

        /// <summary>
        /// Specifies the container partition key.
        /// </summary>
        /// <param name="kind">Indicates the kind of algorithm used for partitioning. Possible values include: 'Hash', 'Range'.</param>
        /// <param name="version">Indicates the version of the partition key definition.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithPartitionKey(Models.PartitionKind kind, int? version);

        /// <summary>
        /// Specifies the container partition key paths.
        /// </summary>
        /// <param name="paths">List of paths using which data within the container can be partitioned.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithPartitionKeyPath(params string[] paths);
    }

    /// <summary>
    /// The stage of a SQL container definition allowing to set default ttl.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDefaultTtl<ParentT>
    {
        /// <summary>
        /// Specifies the default time to live.
        /// </summary>
        /// <param name="ttl">The default time to live.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithDefaultTtl(int ttl);
    }

    /// <summary>
    /// The stage of a SQL container definition allowing to set unique key policy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithUniqueKeyPolicy<ParentT>
    {
        /// <summary>
        /// Specifies the unique key policy.
        /// </summary>
        /// <param name="uniqueKeyPolicy">The whole object of the unique key policy.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy);

        /// <summary>
        /// Specifies the list of unique key.
        /// </summary>
        /// <param name="uniqueKeys">The list of unique key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUniqueKeys(IList<Models.UniqueKey> uniqueKeys);

        /// <summary>
        /// Specifies a unique key appended to original list.
        /// </summary>
        /// <param name="uniqueKey">A unique key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUniqueKey(Models.UniqueKey uniqueKey);

        /// <summary>
        /// Specifies a unique key appended to original list.
        /// </summary>
        /// <param name="paths">The paths of the unique key.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUniqueKey(params string[] paths);
    }

    /// <summary>
    /// The stage of a SQL container definition allowing to set conflict resolution policy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithConflictResolutionPolicy<ParentT>
    {
        /// <summary>
        /// Specifies the conflict resolution policy.
        /// </summary>
        /// <param name="conflictResolutionPolicy">The whole object of the conflict resolution policy.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy);

        /// <summary>
        /// Specifies the conflict resolution policy with conflict resolution path.
        /// </summary>
        /// <param name="mode">The conflict resolution mode.</param>
        /// <param name="conflictResolutionPath">The conflict resolution path.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithConflictResolutionPath(Models.ConflictResolutionMode mode, string conflictResolutionPath);

        /// <summary>
        /// Specifies the conflict resolution policy with conflict resolution procedure.
        /// </summary>
        /// <param name="mode">The conflict resolution mode.</param>
        /// <param name="conflictResolutionProcedure">The conflict resolution procedure.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithConflictResolutionProcedure(Models.ConflictResolutionMode mode, string conflictResolutionProcedure);
    }

    /// <summary>
    /// The stage of a SQL container definition allowing to specify child resource.
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
        IWithAttach<ParentT> WithStoredProcedure(string name, Models.SqlStoredProcedureResource resource, Models.CreateUpdateOptions options = default(Models.CreateUpdateOptions));

        /// <summary>
        /// Specifies a stored procedure.
        /// </summary>
        /// <param name="name">The name of the stored procedure.</param>
        /// <param name="body">The store procedure body.</param>
        /// <param name="options">The options for the store procedure.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithStoredProcedure(string name, string body, Models.CreateUpdateOptions options = default(Models.CreateUpdateOptions));

        /// <summary>
        /// Specifies a user defined function.
        /// </summary>
        /// <param name="name">The name of the user defined function.</param>
        /// <param name="resource">The user defined function resource, no need to specify id.</param>
        /// <param name="options">The options for the user defined function.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUserDefinedFunction(string name, Models.SqlUserDefinedFunctionResource resource, Models.CreateUpdateOptions options = default(Models.CreateUpdateOptions));

        /// <summary>
        /// Specifies a user defined function.
        /// </summary>
        /// <param name="name">The name of the user defined function.</param>
        /// <param name="body">The user defined function body.</param>
        /// <param name="options">The options for the user defined function.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithUserDefinedFunction(string name, string body, Models.CreateUpdateOptions options = default(Models.CreateUpdateOptions));

        /// <summary>
        /// Specifies a trigger.
        /// </summary>
        /// <param name="name">The name of the trigger.</param>
        /// <param name="resource">The trigger resource, no need to specify id.</param>
        /// <param name="options">The options for the trigger.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithTrigger(string name, Models.SqlTriggerResource resource, Models.CreateUpdateOptions options = default(Models.CreateUpdateOptions));

        /// <summary>
        /// Specifies a trigger.
        /// </summary>
        /// <param name="name">The name of the trigger.</param>
        /// <param name="body">The trigger body.</param>
        /// <param name="triggerType">The trigger type.</param>
        /// <param name="triggerOperation">The trigger operation.</param>
        /// <param name="options">The options for the trigger.</param>
        /// <returns>The next stage of the definition.</returns>
        IWithAttach<ParentT> WithTrigger(string name, string body, Models.TriggerType triggerType, Models.TriggerOperation triggerOperation, Models.CreateUpdateOptions options = default(Models.CreateUpdateOptions));
    }
}
