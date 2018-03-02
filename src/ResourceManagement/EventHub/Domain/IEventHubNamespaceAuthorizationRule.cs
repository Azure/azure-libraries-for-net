// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    /// <summary>
    /// Type representing authorization rule of an event hub namespace.
    /// </summary>
    public interface IEventHubNamespaceAuthorizationRule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.IAuthorizationRule<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>
    {
        /// <summary>
        /// Gets the resource group of the namespace where parent event hub resides.
        /// </summary>
        string NamespaceResourceGroupName { get; }

        /// <summary>
        /// Gets the name of the event hub namespace.
        /// </summary>
        string NamespaceName { get; }
    }
}