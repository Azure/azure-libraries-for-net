// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class ActionGroupsImpl
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        ActionGroup.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ActionGroup.Definition.IBlank>.Define(string name)
        {
            return this.Define(name);
        }

        /// <summary>
        /// Enable a receiver in an action group. This changes the receiver's status from Disabled to Enabled. This operation is only supported for Email or SMS receivers.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="actionGroupName">The name of the action group.</param>
        /// <param name="receiverName">The name of the receiver to resubscribe.</param>
        void Microsoft.Azure.Management.Monitor.Fluent.IActionGroups.EnableReceiver(string resourceGroupName, string actionGroupName, string receiverName)
        {

            this.EnableReceiver(resourceGroupName, actionGroupName, receiverName);
        }

        /// <summary>
        /// Enable a receiver in an action group. This changes the receiver's status from Disabled to Enabled. This operation is only supported for Email or SMS receivers.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="actionGroupName">The name of the action group.</param>
        /// <param name="receiverName">The name of the receiver to resubscribe.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Monitor.Fluent.IActionGroups.EnableReceiverAsync(string resourceGroupName, string actionGroupName, string receiverName, CancellationToken cancellationToken)
        {

            await this.EnableReceiverAsync(resourceGroupName, actionGroupName, receiverName, cancellationToken);
        }
    }
}