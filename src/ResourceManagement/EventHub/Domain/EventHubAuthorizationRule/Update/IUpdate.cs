// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Update
{
    using Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Update;
    using Microsoft.Azure.Management.Eventhub.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of the event hub authorization rule update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>,
        Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Update.IWithListenOrSendOrManage<Microsoft.Azure.Management.Eventhub.Fluent.EventHubAuthorizationRule.Update.IUpdate>
    {
    }
}