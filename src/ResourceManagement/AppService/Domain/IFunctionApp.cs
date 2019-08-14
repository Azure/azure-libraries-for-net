// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// An immutable client-side representation of an Azure Function App.
    /// </summary>
    public interface IFunctionApp  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.AppService.Fluent.IWebAppBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<FunctionApp.Update.IUpdate>
    {
        /// <return>The master key for the function app.</return>
        string GetMasterKey();

        /// <summary>
        /// Removes a key to a function in this function app.
        /// </summary>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key to remove.</param>
        void RemoveFunctionKey(string functionName, string keyName);

        /// <summary>
        /// Adds a key to a function in this function app.
        /// </summary>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key to add.</param>
        /// <param name="keyValue">Optional. If not provided, a value will be generated.</param>
        /// <return>The added function key.</return>
        Models.NameValuePair AddFunctionKey(string functionName, string keyName, string keyValue);

        /// <summary>
        /// Gets the entry point to deployment slot management API under the function app.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IFunctionDeploymentSlots DeploymentSlots { get; }

        /// <summary>
        /// Removes a key to a function in this function app.
        /// </summary>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key to remove.</param>
        /// <return>The completable of the operation.</return>
        Task RemoveFunctionKeyAsync(string functionName, string keyName, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The master key for the function app.</return>
        Task<string> GetMasterKeyAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Syncs the triggers on the function app.
        /// </summary>
        void SyncTriggers();

        /// <summary>
        /// Gets Syncs the triggers on the function app.
        /// </summary>
        /// <summary>
        /// Gets a task for the operation.
        /// </summary>
        Task SyncTriggersAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the storage account associated with the function app.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.IStorageAccount StorageAccount { get; }

        /// <summary>
        /// Adds a key to a function in this function app.
        /// </summary>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="keyName">The name of the key to add.</param>
        /// <param name="keyValue">Optional. If not provided, a value will be generated.</param>
        /// <return>The added function key.</return>
        Task<Models.NameValuePair> AddFunctionKeyAsync(string functionName, string keyName, string keyValue, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieve the function key for a specific function.
        /// </summary>
        /// <param name="functionName">The name of the function.</param>
        /// <return>The function key.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,string> ListFunctionKeys(string functionName);

        /// <summary>
        /// Retrieve the function key for a specific function.
        /// </summary>
        /// <param name="functionName">The name of the function.</param>
        /// <return>The function key.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string,string>> ListFunctionKeysAsync(string functionName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the functions
        /// </summary>
        IReadOnlyList<IFunctionEnvelope> ListFunctions();

        /// <summary>
        /// List the functions
        /// </summary>
        /// <param name='loadAllPages'>
        /// Specify true to load all pages, false to get paginated result.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<IPagedCollection<IFunctionEnvelope>> ListFunctionsAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}