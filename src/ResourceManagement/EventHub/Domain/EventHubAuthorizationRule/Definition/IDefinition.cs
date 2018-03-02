// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition
{
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition;

    /// <summary>
    /// The entirety of the event hub namespace authorization rule definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IBlank,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithEventHub,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithAccessPolicy,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>
    {
    }

    /// <summary>
    /// Stage of the authorization rule definition allowing to specify access policy.
    /// </summary>
    public interface IWithAccessPolicy :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithListenOrSendOrManage<Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The first stage of event hub authorization rule definition.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithEventHub
    {
    }

    /// <summary>
    /// Stage of the authorization rule definition allowing to specify the event for which rule needs to be created.
    /// </summary>
    public interface IWithEventHub :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub.
        /// </summary>
        /// <param name="resourceGroupName">Event hub namespace resource group name.</param>
        /// <param name="namespaceName">Event hub parent namespace name.</param>
        /// <param name="eventHubName">Event hub name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithAccessPolicy WithExistingEventHub(string resourceGroupName, string namespaceName, string eventHubName);

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub.
        /// </summary>
        /// <param name="eventHub">The event hub.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithAccessPolicy WithExistingEventHub(IEventHub eventHub);

        /// <summary>
        /// Specifies that authorization rule needs to be created for the given event hub.
        /// </summary>
        /// <param name="eventHubResourceId">The resource id of the event Hub.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Definition.IWithAccessPolicy WithExistingEventHubId(string eventHubResourceId);
    }
}