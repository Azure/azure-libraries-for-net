// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for Action Group management API.
    /// </summary>
    public interface IActionGroups :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ActionGroup.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<IMonitorManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IActionGroupsOperations>
    {

        /// <summary>
        /// Enable a receiver in an action group. This changes the receiver's status from Disabled to Enabled. This operation is only supported for Email or SMS receivers.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="actionGroupName">The name of the action group.</param>
        /// <param name="receiverName">The name of the receiver to resubscribe.</param>
        void EnableReceiver(string resourceGroupName, string actionGroupName, string receiverName);

        /// <summary>
        /// Enable a receiver in an action group. This changes the receiver's status from Disabled to Enabled. This operation is only supported for Email or SMS receivers.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="actionGroupName">The name of the action group.</param>
        /// <param name="receiverName">The name of the receiver to resubscribe.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task EnableReceiverAsync(string resourceGroupName, string actionGroupName, string receiverName, CancellationToken cancellationToken = default(CancellationToken));
    }
}