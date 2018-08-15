// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Update;

    internal partial class EventHubAuthorizationRuleImpl 
    {
        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub.
        /// </summary>
        /// <param name="eventHubResourceId">The resource id of the event Hub.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithAccessPolicy EventHubAuthorizationRule.Definition.IWithEventHub.WithExistingEventHubId(string eventHubResourceId)
        {
            return this.WithExistingEventHubId(eventHubResourceId);
        }

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub.
        /// </summary>
        /// <param name="resourceGroupName">Event hub namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithAccessPolicy EventHubAuthorizationRule.Definition.IWithEventHub.WithExistingEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            return this.WithExistingEventHub(resourceGroupName, namespaceName, eventHubName);
        }

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub.
        /// </summary>
        /// <param name="eventHub">The event hub.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithAccessPolicy EventHubAuthorizationRule.Definition.IWithEventHub.WithExistingEventHub(IEventHub eventHub)
        {
            return this.WithExistingEventHub(eventHub);
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithCreate Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithListen<IWithCreate>.WithListenAccess()
        {
            return this.WithListeningEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithCreate Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithSend<IWithCreate>.WithSendAccess()
        {
            return this.WithSendingEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithCreate Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithManage<IWithCreate>.WithManageAccess()
        {
            return this.WithManagementEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Update.IUpdate Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Update.IWithListen<IUpdate>.WithListenAccess()
        {
            return this.WithListeningEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Update.IUpdate Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Update.IWithSend<IUpdate>.WithSendAccess()
        {
            return this.WithSendingEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Update.IUpdate Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Update.IWithManage<IUpdate>.WithManageAccess()
        {
            return this.WithManagementEnabled();
        }

        /// <summary>
        /// Gets the resource group of the namespace where parent event hub resides.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule.NamespaceResourceGroupName
        {
            get
            {
                return this.NamespaceResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the namespace name of parent event hub.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }

        /// <summary>
        /// Gets the name of the parent event hub.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule.EventHubName
        {
            get
            {
                return this.EventHubName();
            }
        }
    }
}