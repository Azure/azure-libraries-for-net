// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an Azure Action Group.
    /// </summary>
    public interface IActionGroup :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<IMonitorManager, Models.ActionGroupResourceInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ActionGroup.Update.IUpdate>
    {

        /// <summary>
        /// Gets the automationRunbookReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the automationRunbookReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AutomationRunbookReceiver> AutomationRunbookReceivers { get; }

        /// <summary>
        /// Gets the azureFunctionReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the azureFunctionReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AzureFunctionReceiver> AzureFunctionReceivers { get; }

        /// <summary>
        /// Gets the emailReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the emailReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.EmailReceiver> EmailReceivers { get; }

        /// <summary>
        /// Gets the itsmReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the itsmReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ItsmReceiver> ItsmReceivers { get; }

        /// <summary>
        /// Gets the logicAppReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the logicAppReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.LogicAppReceiver> LogicAppReceivers { get; }

        /// <summary>
        /// Gets the pushNotificationReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the pushNotificationReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AzureAppPushReceiver> PushNotificationReceivers { get; }

        /// <summary>
        /// Gets the groupShortName value.
        /// </summary>
        /// <summary>
        /// Gets the groupShortName value.
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// Gets the smsReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the smsReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SmsReceiver> SmsReceivers { get; }

        /// <summary>
        /// Gets the voiceReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the voiceReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.VoiceReceiver> VoiceReceivers { get; }

        /// <summary>
        /// Gets the webhookReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the webhookReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.WebhookReceiver> WebhookReceivers { get; }
    }
}