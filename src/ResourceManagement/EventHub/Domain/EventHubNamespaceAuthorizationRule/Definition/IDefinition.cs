// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition
{
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Stage of the authorization rule definition allowing to specify the event namespace for which rule needs to be created.
    /// </summary>
    public interface IWithNamespace :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub namespace.
        /// </summary>
        /// <param name="resourceGroupName">Namespace resource group name.</param>
        /// <param name="namespaceName">Namespace name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithAccessPolicy WithExistingNamespace(string resourceGroupName, string namespaceName);

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub namespace.
        /// </summary>
        /// <param name="namespace">The namespace.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithAccessPolicy WithExistingNamespace(IEventHubNamespace nhNamespace);

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub namespace.
        /// </summary>
        /// <param name="namespaceResourceId">The resource id of the event Hub namespace.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithAccessPolicy WithExistingNamespaceId(string namespaceResourceId);
    }

    /// <summary>
    /// Stage of the authorization rule definition allowing to specify access policy.
    /// </summary>
    public interface IWithAccessPolicy :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithListenOrSendOrManage<Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespaceAuthorizationRule>
    {
    }

    /// <summary>
    /// The first stage of event hub namespace authorization rule definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithNamespace
    {
    }

    /// <summary>
    /// The entirety of the event hub namespace authorization rule definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IBlank,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithNamespace,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithAccessPolicy,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubNamespaceAuthorizationRule.Definition.IWithCreate
    {
    }
}