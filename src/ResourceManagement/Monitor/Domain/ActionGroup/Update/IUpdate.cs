// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update
{
    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Monitor.Fluent.IActionGroup>,
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionDefinition,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IUpdate>
    {

    }

    /// <summary>
    /// Receivers action update stage allowing to set each receiver's configuration.
    /// </summary>
    public interface IWithActionUpdateDefinition
    {

        /// <summary>
        /// Returns to the Action Group update flow.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IUpdate Parent();

        /// <summary>
        /// Sets the Azure Automation Runbook notification receiver.
        /// </summary>
        /// <param name="automationAccountId">The automationAccountId value to set.</param>
        /// <param name="runbookName">The runbookName value to set.</param>
        /// <param name="webhookResourceId">The webhookResourceId value to set.</param>
        /// <param name="isGlobalRunbook">The isGlobalRunbook value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithAutomationRunbook(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook);

        /// <summary>
        /// Sets the Azure Functions receiver.
        /// </summary>
        /// <param name="functionAppResourceId">The functionAppResourceId value to set.</param>
        /// <param name="functionName">The functionName value to set.</param>
        /// <param name="httpTriggerUrl">The httpTriggerUrl value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithAzureFunction(string functionAppResourceId, string functionName, string httpTriggerUrl);

        /// <summary>
        /// Sets the email receiver.
        /// </summary>
        /// <param name="emailAddress">The email Address value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithEmail(string emailAddress);

        /// <summary>
        /// Sets the ITSM receiver.
        /// </summary>
        /// <param name="workspaceId">The workspaceId value to set.</param>
        /// <param name="connectionId">The connectionId value to set.</param>
        /// <param name="ticketConfiguration">The ticketConfiguration value to set.</param>
        /// <param name="region">The region value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithItsm(string workspaceId, string connectionId, string ticketConfiguration, string region);

        /// <summary>
        /// Sets the Logic App receiver.
        /// </summary>
        /// <param name="logicAppResourceId">The logicAppResourceId value to set.</param>
        /// <param name="callbackUrl">The callbackUrl value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithLogicApp(string logicAppResourceId, string callbackUrl);

        /// <summary>
        /// Removes Azure Automation Runbook receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutAutomationRunbook();

        /// <summary>
        /// Removes Azure Function receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutAzureFunction();

        /// <summary>
        /// Removes email receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutEmail();

        /// <summary>
        /// Removes ITSM receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutItsm();

        /// <summary>
        /// Removes Azure Logic App receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutLogicApp();

        /// <summary>
        /// Removes Azure mobile App Push notification receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutPushNotification();

        /// <summary>
        /// Removes SMS receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutSms();

        /// <summary>
        /// Removes Voice receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutVoice();

        /// <summary>
        /// Removes Webhook receiver from current receiver's group.
        /// </summary>
        /// <return>The next stage of the receiver group update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithoutWebhook();

        /// <summary>
        /// Sets the Azure Mobile App Push Notification  receiver.
        /// </summary>
        /// <param name="emailAddress">The emailAddress value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithPushNotification(string emailAddress);

        /// <summary>
        /// Sets the SMS receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithSms(string countryCode, string phoneNumber);

        /// <summary>
        /// Sets the Voice notification receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithVoice(string countryCode, string phoneNumber);

        /// <summary>
        /// Sets the Webhook receiver.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition WithWebhook(string serviceUri);
    }

    /// <summary>
    /// The stage of update which contains all the top level fields and transition stages to receiver updates.
    /// </summary>
    public interface IWithActionDefinition
    {

        /// <summary>
        /// Begins a definition for a new receiver group in the current Action group object.
        /// </summary>
        /// <param name="actionNamePrefix">The actionNamePrefix value to use during receiver name creation.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IUpdate> DefineReceiver(string actionNamePrefix);

        /// <summary>
        /// Begins an update flow for an existing receiver group.
        /// </summary>
        /// <param name="actionNamePrefix">The actionNamePrefix value to use during receiver filtering.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IWithActionUpdateDefinition UpdateReceiver(string actionNamePrefix);

        /// <summary>
        /// Removes all the receivers that contain specified actionNamePrefix string in the name.
        /// </summary>
        /// <param name="actionNamePrefix">The actionNamePrefix value to use during receiver filtering.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IUpdate WithoutReceiver(string actionNamePrefix);

        /// <summary>
        /// Sets the short name of the action group. This will be used in SMS messages. Maximum length cannot exceed 12 symbols.
        /// </summary>
        /// <param name="shortName">Short name of the action group. Cannot exceed 12 symbols.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.Update.IUpdate WithShortName(string shortName);
    }
}