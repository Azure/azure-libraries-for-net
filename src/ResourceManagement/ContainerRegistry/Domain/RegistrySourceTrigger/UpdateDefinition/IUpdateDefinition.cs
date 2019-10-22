// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;

    /// <summary>
    /// The first stage of a source trigger definition.
    /// </summary>
    public interface IBlank 
    {
        /// <summary>
        /// The function that specifies Azure DevOps will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl WithAzureDevOpsAsSourceControl();

        /// <summary>
        /// The function that specifies Github will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl WithGithubAsSourceControl();

        /// <summary>
        /// The function that allows the user to input their own kind of source control.
        /// </summary>
        /// <param name="sourceControl">The source control the user wishes to use.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl WithSourceControl(SourceControlType sourceControl);
    }

    /// <summary>
    /// The stage of the container registry source trigger definition allowing to specify the URL of the source control repository.
    /// </summary>
    public interface IRepositoryUrl 
    {
        /// <summary>
        /// The function that specifies the URL of the source control repository.
        /// </summary>
        /// <param name="sourceControlRepositoryUrl">The URL of the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ITriggerEventsDefinition WithSourceControlRepositoryUrl(string sourceControlRepositoryUrl);
    }

    /// <summary>
    /// Container interface for defining a new trigger during a task update.
    /// </summary>
    public interface IUpdateDefinition  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IBlank,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ITriggerEventsDefinition,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IRepositoryBranchAndAuth,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ITriggerStatusDefinition,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the container registry source trigger definition allowing to specify the status of the trigger.
    /// </summary>
    public interface ITriggerStatusDefinition 
    {
        /// <summary>
        /// The function that allows the user to input the state of the trigger status.
        /// </summary>
        /// <param name="triggerStatus">The user's choice for the trigger status.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithTriggerStatus(TriggerStatus triggerStatus);

        /// <summary>
        /// The function that sets the trigger status to be disabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithTriggerStatusDisabled();

        /// <summary>
        /// The function that sets the trigger status to be enabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithTriggerStatusEnabled();
    }

    /// <summary>
    /// The stage of the container registry source trigger definition allowing to specify the type of actions that will trigger a run.
    /// </summary>
    public interface ITriggerEventsDefinition 
    {
        /// <summary>
        /// The function that specifies a commit action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithCommitTriggerEvent();

        /// <summary>
        /// The function that specifies a pull action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithPullTriggerEvent();

        /// <summary>
        /// The function that allows the user to specify an action that will trigger a run when it is executed.
        /// </summary>
        /// <param name="sourceTriggerEvent">The action that will trigger a run.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithTriggerEvent(SourceTriggerEvent sourceTriggerEvent);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be attached,
    /// but also allows for any other optional settings to be specified.
    /// </summary>
    public interface ISourceTriggerAttachable  :
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.IRepositoryBranchAndAuth,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ITriggerEventsDefinition,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ITriggerStatusDefinition,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the container registry source trigger definition allowing to specify the branch of the repository and authentication credentials
    /// if needed to interact with the source control repository.
    /// </summary>
    public interface IRepositoryBranchAndAuth 
    {
        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithRepositoryAuthentication(TokenType tokenType, string token);

        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <param name="refreshToken">The token that is used to refresh the access token.</param>
        /// <param name="scope">The scope of the access token.</param>
        /// <param name="expiresIn">Time in seconds that the token remains valid.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithRepositoryAuthentication(TokenType tokenType, string token, string refreshToken, string scope, int expiresIn);

        /// <summary>
        /// The function that specifies the branch of the respository to use.
        /// </summary>
        /// <param name="branch">The repository branch.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable WithRepositoryBranch(string branch);
    }
}