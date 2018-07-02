// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update;

    internal partial class EventHubNamespaceAuthorizationRuleImpl 
    {
        /// <summary>
        /// Gets the resource group of the namespace where parent event hub resides.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule.NamespaceResourceGroupName
        {
            get
            {
                return this.NamespaceResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the name of the event hub namespace.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule.NamespaceName
        {
            get
            {
                return this.NamespaceName();
            }
        }

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub namespace.
        /// </summary>
        /// <param name="namespaceResourceId">The resource id of the event Hub namespace.</param>
        /// <return>The next stage of the definition.</return>
        EventHubNamespaceAuthorizationRule.Definition.IWithAccessPolicy EventHubNamespaceAuthorizationRule.Definition.IWithNamespace.WithExistingNamespaceId(string namespaceResourceId)
        {
            return this.WithExistingNamespaceId(namespaceResourceId);
        }

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub namespace.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>The next stage of the definition.</return>
        EventHubNamespaceAuthorizationRule.Definition.IWithAccessPolicy EventHubNamespaceAuthorizationRule.Definition.IWithNamespace.WithExistingNamespace(string resourceGroupName, string namespaceName)
        {
            return this.WithExistingNamespace(resourceGroupName, namespaceName);
        }

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub namespace.
        /// </summary>
        /// <param name="namespace">The namespace.</param>
        /// <return>The next stage of the definition.</return>
        EventHubNamespaceAuthorizationRule.Definition.IWithAccessPolicy EventHubNamespaceAuthorizationRule.Definition.IWithNamespace.WithExistingNamespace(IEventHubNamespace ehNamespace)
        {
            return this.WithExistingNamespace(ehNamespace);
        }


        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate AuthorizationRule.Definition.IWithListen<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate>.WithListenAccess()
        {
            return base.WithListeningEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate AuthorizationRule.Definition.IWithSend<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate>.WithSendAccess()
        {
            return base.WithSendingEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate AuthorizationRule.Definition.IWithManage<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate>.WithManageAccess()
        {
            return base.WithManagementEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update.IUpdate AuthorizationRule.Update.IWithListen<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update.IUpdate>.WithListenAccess()
        {
            return base.WithListeningEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update.IUpdate AuthorizationRule.Update.IWithSend<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update.IUpdate>.WithSendAccess()
        {
            return base.WithSendingEnabled();
        }

        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update.IUpdate AuthorizationRule.Update.IWithManage<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Update.IUpdate>.WithManageAccess()
        {
            return base.WithManagementEnabled();
        }
    }
}