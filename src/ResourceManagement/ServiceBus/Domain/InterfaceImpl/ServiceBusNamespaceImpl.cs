// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using System.Collections.Generic;
    using System;

    internal partial class ServiceBusNamespaceImpl
    {
        /// <summary>
        /// Creates a queue entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the queue entity.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithQueue.WithNewQueue(string name, int maxSizeInMB)
        {
            return this.WithNewQueue(name, maxSizeInMB);
        }

        /// <summary>
        /// Removes a queue entity from the Service Bus namespace.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithQueue.WithoutQueue(string name)
        {
            return this.WithoutQueue(name);
        }

        /// <summary>
        /// Creates a queue entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the queue entity.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithQueue.WithNewQueue(string name, int maxSizeInMB)
        {
            return this.WithNewQueue(name, maxSizeInMB);
        }

        /// <summary>
        /// Creates a manage authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name);
        }

        /// <summary>
        /// Creates a send authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name);
        }

        /// <summary>
        /// Removes an authorization rule from the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithAuthorizationRule.WithoutAuthorizationRule(string name)
        {
            return this.WithoutAuthorizationRule(name);
        }

        /// <summary>
        /// Creates a listen authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name);
        }

        /// <summary>
        /// Creates a manage authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name);
        }

        /// <summary>
        /// Creates a send authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name);
        }

        /// <summary>
        /// Creates a listen authorization rule for the Service Bus namespace.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name);
        }

        /// <summary>
        /// Creates a topic entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Topic name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the topic entity.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithTopic.WithNewTopic(string name, int maxSizeInMB)
        {
            return this.WithNewTopic(name, maxSizeInMB);
        }

        /// <summary>
        /// Removes a topic entity from the Service Bus namespace.
        /// </summary>
        /// <param name="name">Topic name.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithTopic.WithoutTopic(string name)
        {
            return this.WithoutTopic(name);
        }

        /// <summary>
        /// Creates a topic entity in the Service Bus namespace.
        /// </summary>
        /// <param name="name">Topic name.</param>
        /// <param name="maxSizeInMB">Maximum size of memory allocated for the topic entity.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithTopic.WithNewTopic(string name, int maxSizeInMB)
        {
            return this.WithNewTopic(name, maxSizeInMB);
        }

        /// <summary>
        /// Gets the relative DNS name of the Service Bus namespace.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.DnsLabel
        {
            get
            {
                return this.DnsLabel();
            }
        }

        /// <summary>
        /// Gets fully qualified domain name (FQDN) of the Service Bus namespace.
        /// </summary>
        string Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Gets time the namespace was created.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.CreatedAt
        {
            get
            {
                return this.CreatedAt();
            }
        }

        /// <summary>
        /// Gets sku value.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceSku Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.Sku
        {
            get
            {
                return this.Sku();
            }
        }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRules Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.AuthorizationRules
        {
            get
            {
                return this.AuthorizationRules();
            }
        }

        /// <summary>
        /// Gets time the namespace was updated.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.UpdatedAt
        {
            get
            {
                return this.UpdatedAt();
            }
        }

        /// <summary>
        /// Gets entry point to manage topics entities in the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.ITopics Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.Topics
        {
            get
            {
                return this.Topics();
            }
        }

        /// <summary>
        /// Gets entry point to manage queue entities in the Service Bus namespace.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.IQueues Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusNamespace.Queues
        {
            get
            {
                return this.Queues();
            }
        }

        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the Service Bus namespace update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Update.IWithSku.WithSku(NamespaceSku namespaceSku)
        {
            return this.WithSku(namespaceSku);
        }

        /// <summary>
        /// Specifies the namespace sku.
        /// </summary>
        /// <param name="namespaceSku">The sku.</param>
        /// <return>Next stage of the Service Bus namespace definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.ServiceBusNamespace.Definition.IWithSku.WithSku(NamespaceSku namespaceSku)
        {
            return this.WithSku(namespaceSku);
        }
    }
}