// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition;
    using Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Definition;
    using Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update;
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class ActionGroupImpl
    {
        /// <summary>
        /// Gets the automationRunbookReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the automationRunbookReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AutomationRunbookReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.AutomationRunbookReceivers
        {
            get
            {
                return this.AutomationRunbookReceivers();
            }
        }

        /// <summary>
        /// Gets the azureFunctionReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the azureFunctionReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AzureFunctionReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.AzureFunctionReceivers
        {
            get
            {
                return this.AzureFunctionReceivers();
            }
        }

        /// <summary>
        /// Gets the emailReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the emailReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.EmailReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.EmailReceivers
        {
            get
            {
                return this.EmailReceivers();
            }
        }

        /// <summary>
        /// Gets the itsmReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the itsmReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ItsmReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.ItsmReceivers
        {
            get
            {
                return this.ItsmReceivers();
            }
        }

        /// <summary>
        /// Gets the logicAppReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the logicAppReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.LogicAppReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.LogicAppReceivers
        {
            get
            {
                return this.LogicAppReceivers();
            }
        }

        /// <summary>
        /// Gets the pushNotificationReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the pushNotificationReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.AzureAppPushReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.PushNotificationReceivers
        {
            get
            {
                return this.PushNotificationReceivers();
            }
        }

        /// <summary>
        /// Gets the groupShortName value.
        /// </summary>
        /// <summary>
        /// Gets the groupShortName value.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.ShortName
        {
            get
            {
                return this.ShortName();
            }
        }

        /// <summary>
        /// Gets the smsReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the smsReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SmsReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.SmsReceivers
        {
            get
            {
                return this.SmsReceivers();
            }
        }

        /// <summary>
        /// Gets the voiceReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the voiceReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.VoiceReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.VoiceReceivers
        {
            get
            {
                return this.VoiceReceivers();
            }
        }

        /// <summary>
        /// Gets the webhookReceivers value.
        /// </summary>
        /// <summary>
        /// Gets the webhookReceivers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.WebhookReceiver> Microsoft.Azure.Management.Monitor.Fluent.IActionGroup.WebhookReceivers
        {
            get
            {
                return this.WebhookReceivers();
            }
        }

        /// <summary>
        /// Attaches the defined receivers to the Action Group configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        IWithCreate ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Begins a definition for a new receiver group in the current Action group object.
        /// </summary>
        /// <param name="actionNamePrefix">The actionNamePrefix value to use during receiver name creation.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.ActionDefinition.IActionDefinition<ActionGroup.Update.IUpdate> ActionGroup.Update.IWithActionDefinition.DefineReceiver(string actionNamePrefix)
        {
            return this.DefineReceiver(actionNamePrefix);
        }

        /// <summary>
        /// Begins the definition of Action Group receivers with the specified name prefix.
        /// </summary>
        /// <param name="actionNamePrefix">Prefix for each receiver name.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<ActionGroup.Definition.IWithCreate> ActionGroup.Definition.IWithCreate.DefineReceiver(string actionNamePrefix)
        {
            return this.DefineReceiver(actionNamePrefix);
        }

        /// <summary>
        /// Returns to the Action Group update flow.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IUpdate ActionGroup.Update.IWithActionUpdateDefinition.Parent()
        {
            return this.Parent();
        }

        /// <summary>
        /// Begins an update flow for an existing receiver group.
        /// </summary>
        /// <param name="actionNamePrefix">The actionNamePrefix value to use during receiver filtering.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionDefinition.UpdateReceiver(string actionNamePrefix)
        {
            return this.UpdateReceiver(actionNamePrefix);
        }

        /// <summary>
        /// Sets the Azure Automation Runbook notification receiver.
        /// </summary>
        /// <param name="automationAccountId">The automationAccountId value to set.</param>
        /// <param name="runbookName">The runbookName value to set.</param>
        /// <param name="webhookResourceId">The webhookResourceId value to set.</param>
        /// <param name="isGlobalRunbook">The isGlobalRunbook value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithAutomationRunbook(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook)
        {
            return this.WithAutomationRunbook(automationAccountId, runbookName, webhookResourceId, isGlobalRunbook);
        }

        /// <summary>
        /// Sets the Azure Automation Runbook notification receiver.
        /// </summary>
        /// <param name="automationAccountId">The automationAccountId value to set.</param>
        /// <param name="runbookName">The runbookName value to set.</param>
        /// <param name="webhookResourceId">The webhookResourceId value to set.</param>
        /// <param name="isGlobalRunbook">The isGlobalRunbook value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithAutomationRunbook(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook)
        {
            return this.WithAutomationRunbook(automationAccountId, runbookName, webhookResourceId, isGlobalRunbook);
        }

        /// <summary>
        /// Sets the Azure Functions receiver.
        /// </summary>
        /// <param name="functionAppResourceId">The functionAppResourceId value to set.</param>
        /// <param name="functionName">The functionName value to set.</param>
        /// <param name="httpTriggerUrl">The httpTriggerUrl value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithAzureFunction(string functionAppResourceId, string functionName, string httpTriggerUrl)
        {
            return this.WithAzureFunction(functionAppResourceId, functionName, httpTriggerUrl);
        }

        /// <summary>
        /// Sets the Azure Functions receiver.
        /// </summary>
        /// <param name="functionAppResourceId">The functionAppResourceId value to set.</param>
        /// <param name="functionName">The functionName value to set.</param>
        /// <param name="httpTriggerUrl">The httpTriggerUrl value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithAzureFunction(string functionAppResourceId, string functionName, string httpTriggerUrl)
        {
            return this.WithAzureFunction(functionAppResourceId, functionName, httpTriggerUrl);
        }

        /// <summary>
        /// Sets the email receiver.
        /// </summary>
        /// <param name="emailAddress">The email Address value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithEmail(string emailAddress)
        {
            return this.WithEmail(emailAddress);
        }

        /// <summary>
        /// Sets the email receiver.
        /// </summary>
        /// <param name="emailAddress">The email Address value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithEmail(string emailAddress)
        {
            return this.WithEmail(emailAddress);
        }

        /// <summary>
        /// Sets the ITSM receiver.
        /// </summary>
        /// <param name="workspaceId">The workspaceId value to set.</param>
        /// <param name="connectionId">The connectionId value to set.</param>
        /// <param name="ticketConfiguration">The ticketConfiguration value to set.</param>
        /// <param name="region">The region value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithItsm(string workspaceId, string connectionId, string ticketConfiguration, string region)
        {
            return this.WithItsm(workspaceId, connectionId, ticketConfiguration, region);
        }

        /// <summary>
        /// Sets the ITSM receiver.
        /// </summary>
        /// <param name="workspaceId">The workspaceId value to set.</param>
        /// <param name="connectionId">The connectionId value to set.</param>
        /// <param name="ticketConfiguration">The ticketConfiguration value to set.</param>
        /// <param name="region">The region value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithItsm(string workspaceId, string connectionId, string ticketConfiguration, string region)
        {
            return this.WithItsm(workspaceId, connectionId, ticketConfiguration, region);
        }

        /// <summary>
        /// Sets the Logic App receiver.
        /// </summary>
        /// <param name="logicAppResourceId">The logicAppResourceId value to set.</param>
        /// <param name="callbackUrl">The callbackUrl value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithLogicApp(string logicAppResourceId, string callbackUrl)
        {
            return this.WithLogicApp(logicAppResourceId, callbackUrl);
        }

        /// <summary>
        /// Sets the Logic App receiver.
        /// </summary>
        /// <param name="logicAppResourceId">The logicAppResourceId value to set.</param>
        /// <param name="callbackUrl">The callbackUrl value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithLogicApp(string logicAppResourceId, string callbackUrl)
        {
            return this.WithLogicApp(logicAppResourceId, callbackUrl);
        }

        /// <summary>
        /// Sets the Azure Mobile App Push Notification  receiver.
        /// </summary>
        /// <param name="emailAddress">The emailAddress value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithPushNotification(string emailAddress)
        {
            return this.WithPushNotification(emailAddress);
        }

        /// <summary>
        /// Sets the Azure Mobile App Push Notification  receiver.
        /// </summary>
        /// <param name="emailAddress">The emailAddress value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithPushNotification(string emailAddress)
        {
            return this.WithPushNotification(emailAddress);
        }

        /// <summary>
        /// Removes Azure Automation Runbook receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutAutomationRunbook()
        {
            return this.WithoutAutomationRunbook();
        }

        /// <summary>
        /// Removes Azure Function receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutAzureFunction()
        {
            return this.WithoutAzureFunction();
        }

        /// <summary>
        /// Removes email receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutEmail()
        {
            return this.WithoutEmail();
        }

        /// <summary>
        /// Removes ITSM receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutItsm()
        {
            return this.WithoutItsm();
        }

        /// <summary>
        /// Removes Azure Logic App receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutLogicApp()
        {
            return this.WithoutLogicApp();
        }

        /// <summary>
        /// Removes Azure mobile App Push notification receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutPushNotification()
        {
            return this.WithoutPushNotification();
        }

        /// <summary>
        /// Removes all the receivers that contain specified actionNamePrefix string in the name.
        /// </summary>
        /// <param name="actionNamePrefix">The actionNamePrefix value to use during receiver filtering.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IUpdate ActionGroup.Update.IWithActionDefinition.WithoutReceiver(string actionNamePrefix)
        {
            return this.WithoutReceiver(actionNamePrefix);
        }

        /// <summary>
        /// Removes SMS receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutSms()
        {
            return this.WithoutSms();
        }

        /// <summary>
        /// Removes Voice receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutVoice()
        {
            return this.WithoutVoice();
        }

        /// <summary>
        /// Removes Webhook receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithoutWebhook()
        {
            return this.WithoutWebhook();
        }

        /// <summary>
        /// Sets the short name of the action group. This will be used in SMS messages. Maximum length cannot exceed 12 symbols.
        /// </summary>
        /// <param name="shortName">Short name of the action group. Cannot exceed 12 symbols.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IUpdate ActionGroup.Update.IWithActionDefinition.WithShortName(string shortName)
        {
            return this.WithShortName(shortName);
        }

        /// <summary>
        /// Sets the short name of the action group. This will be used in SMS messages. Maximum length cannot exceed 12 symbols.
        /// </summary>
        /// <param name="shortName">Short name of the action group. Cannot exceed 12 symbols.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.Definition.IWithCreate ActionGroup.Definition.IWithCreate.WithShortName(string shortName)
        {
            return this.WithShortName(shortName);
        }

        /// <summary>
        /// Sets the SMS receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithSms(string countryCode, string phoneNumber)
        {
            return this.WithSms(countryCode, phoneNumber);
        }

        /// <summary>
        /// Sets the SMS receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithSms(string countryCode, string phoneNumber)
        {
            return this.WithSms(countryCode, phoneNumber);
        }

        /// <summary>
        /// Sets the Voice notification receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithVoice(string countryCode, string phoneNumber)
        {
            return this.WithVoice(countryCode, phoneNumber);
        }

        /// <summary>
        /// Sets the Voice notification receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithVoice(string countryCode, string phoneNumber)
        {
            return this.WithVoice(countryCode, phoneNumber);
        }

        /// <summary>
        /// Sets the Webhook receiver.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of the update.</return>
        ActionGroup.Update.IWithActionUpdateDefinition ActionGroup.Update.IWithActionUpdateDefinition.WithWebhook(string serviceUri)
        {
            return this.WithWebhook(serviceUri);
        }

        /// <summary>
        /// Sets the Webhook receiver.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of the definition.</return>
        ActionGroup.ActionDefinition.IActionDefinition<IWithCreate> ActionGroup.ActionDefinition.IActionDefinition<IWithCreate>.WithWebhook(string serviceUri)
        {
            return this.WithWebhook(serviceUri);
        }

        // catchup method ovverides
        IUpdate IActionDefinition<IUpdate>.Attach()
        {
            return this.Attach();
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithAutomationRunbook(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook)
        {
            return this.WithAutomationRunbook(automationAccountId, runbookName, webhookResourceId, isGlobalRunbook);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithAzureFunction(string functionAppResourceId, string functionName, string httpTriggerUrl)
        {
            return this.WithAzureFunction(functionAppResourceId, functionName, httpTriggerUrl);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithEmail(string emailAddress)
        {
            return this.WithEmail(emailAddress);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithItsm(string workspaceId, string connectionId, string ticketConfiguration, string region)
        {
            return this.WithItsm(workspaceId, connectionId, ticketConfiguration, region);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithLogicApp(string logicAppResourceId, string callbackUrl)
        {
            return this.WithLogicApp(logicAppResourceId, callbackUrl);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithPushNotification(string emailAddress)
        {
            return this.WithPushNotification(emailAddress);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithSms(string countryCode, string phoneNumber)
        {
            return this.WithSms(countryCode, phoneNumber);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithVoice(string countryCode, string phoneNumber)
        {
            return this.WithVoice(countryCode, phoneNumber);
        }

        IActionDefinition<IUpdate> IActionDefinition<IUpdate>.WithWebhook(string serviceUri)
        {
            return this.WithWebhook(serviceUri);
        }
    }
}