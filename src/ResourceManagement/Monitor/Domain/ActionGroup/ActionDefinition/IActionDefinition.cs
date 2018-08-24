// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition
{
    /// <summary>
    /// Receivers action definition allowing to set each receiver's configuration.
    /// </summary>
    /// <typeparam name="ParentT">The next stage of the definition.</typeparam>
    public interface IActionDefinition<ParentT>
    {

        /// <summary>
        /// Attaches the defined receivers to the Action Group configuration.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT Attach();

        /// <summary>
        /// Sets the Azure Automation Runbook notification receiver.
        /// </summary>
        /// <param name="automationAccountId">The automationAccountId value to set.</param>
        /// <param name="runbookName">The runbookName value to set.</param>
        /// <param name="webhookResourceId">The webhookResourceId value to set.</param>
        /// <param name="isGlobalRunbook">The isGlobalRunbook value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithAutomationRunbook(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook);

        /// <summary>
        /// Sets the Azure Functions receiver.
        /// </summary>
        /// <param name="functionAppResourceId">The functionAppResourceId value to set.</param>
        /// <param name="functionName">The functionName value to set.</param>
        /// <param name="httpTriggerUrl">The httpTriggerUrl value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithAzureFunction(string functionAppResourceId, string functionName, string httpTriggerUrl);

        /// <summary>
        /// Sets the email receiver.
        /// </summary>
        /// <param name="emailAddress">The email Address value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithEmail(string emailAddress);

        /// <summary>
        /// Sets the ITSM receiver.
        /// </summary>
        /// <param name="workspaceId">The workspaceId value to set.</param>
        /// <param name="connectionId">The connectionId value to set.</param>
        /// <param name="ticketConfiguration">The ticketConfiguration value to set.</param>
        /// <param name="region">The region value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithItsm(string workspaceId, string connectionId, string ticketConfiguration, string region);

        /// <summary>
        /// Sets the Logic App receiver.
        /// </summary>
        /// <param name="logicAppResourceId">The logicAppResourceId value to set.</param>
        /// <param name="callbackUrl">The callbackUrl value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithLogicApp(string logicAppResourceId, string callbackUrl);

        /// <summary>
        /// Sets the Azure Mobile App Push Notification  receiver.
        /// </summary>
        /// <param name="emailAddress">The emailAddress value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithPushNotification(string emailAddress);

        /// <summary>
        /// Sets the SMS receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithSms(string countryCode, string phoneNumber);

        /// <summary>
        /// Sets the Voice notification receiver.
        /// </summary>
        /// <param name="countryCode">The countryCode value to set.</param>
        /// <param name="phoneNumber">The phoneNumber value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithVoice(string countryCode, string phoneNumber);

        /// <summary>
        /// Sets the Webhook receiver.
        /// </summary>
        /// <param name="serviceUri">The serviceUri value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Monitor.Fluent.ActionGroup.ActionDefinition.IActionDefinition<ParentT> WithWebhook(string serviceUri);
    }
}