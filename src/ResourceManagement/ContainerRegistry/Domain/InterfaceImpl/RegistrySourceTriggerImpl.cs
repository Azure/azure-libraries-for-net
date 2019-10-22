// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Update;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;

    internal partial class RegistrySourceTriggerImpl 
    {
        /// <summary>
        /// Gets the branch of the repository that is being used as source control. I.e., master.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger.SourceControlBranch
        {
            get
            {
                return this.SourceControlBranch();
            }
        }

        /// <summary>
        /// Gets the URL of the repository used as source control.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger.SourceControlRepositoryUrl
        {
            get
            {
                return this.SourceControlRepositoryUrl();
            }
        }

        /// <summary>
        /// Gets Returns the type of source control this trigger uses. I.e., Github, AzureDevOps etc.
        /// </summary>
        Models.SourceControlType Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger.SourceControlType
        {
            get
            {
                return this.SourceControlType();
            }
        }

        /// <summary>
        /// Gets the list of actions that trigger an event. I.e., a commit, a pull request etc.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.SourceTriggerEvent> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger.SourceTriggerEvents
        {
            get
            {
                return this.SourceTriggerEvents();
            }
        }

        /// <summary>
        /// Gets the source trigger status. I.e., enabled, disabled.
        /// </summary>
        Models.TriggerStatus Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        RegistryTask.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<RegistryTask.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        RegistryTask.Definition.ITaskCreatable Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<RegistryTask.Definition.ITaskCreatable>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Begins an update for a child resource.
        /// This is the beginning of the builder pattern used to update child resources
        /// The final method completing the update and continue
        /// the actual parent resource update process in Azure is  Settable.parent().
        /// </summary>
        /// <return>The stage of  parent resource update.</return>
        RegistryTask.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<RegistryTask.Update.IUpdate>.Parent()
        {
            return this.Parent();
        }

        /// <summary>
        /// The function that specifies Azure DevOps will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.IRepositoryUrl RegistrySourceTrigger.Definition.IBlank.WithAzureDevOpsAsSourceControl()
        {
            return this.WithAzureDevOpsAsSourceControl();
        }

        /// <summary>
        /// The function that specifies Azure DevOps will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl RegistrySourceTrigger.UpdateDefinition.IBlank.WithAzureDevOpsAsSourceControl()
        {
            return this.WithAzureDevOpsAsSourceControl();
        }

        /// <summary>
        /// The function that specifies Azure DevOps will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ISourceControlType.WithAzureDevOpsAsSourceControl()
        {
            return this.WithAzureDevOpsAsSourceControl();
        }

        /// <summary>
        /// The function that specifies a commit action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ITriggerEventsDefinition.WithCommitTriggerEvent()
        {
            return this.WithCommitTriggerEvent();
        }

        /// <summary>
        /// The function that specifies a commit action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.ITriggerEventsDefinition.WithCommitTriggerEvent()
        {
            return this.WithCommitTriggerEvent();
        }

        /// <summary>
        /// The function that specifies a commit action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.ITriggerEventsDefinition.WithCommitTriggerEvent()
        {
            return this.WithCommitTriggerEvent();
        }

        /// <summary>
        /// The function that specifies Github will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.IRepositoryUrl RegistrySourceTrigger.Definition.IBlank.WithGithubAsSourceControl()
        {
            return this.WithGithubAsSourceControl();
        }

        /// <summary>
        /// The function that specifies Github will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl RegistrySourceTrigger.UpdateDefinition.IBlank.WithGithubAsSourceControl()
        {
            return this.WithGithubAsSourceControl();
        }

        /// <summary>
        /// The function that specifies Github will be used as the type of source control.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ISourceControlType.WithGithubAsSourceControl()
        {
            return this.WithGithubAsSourceControl();
        }

        /// <summary>
        /// The function that specifies a pull action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ITriggerEventsDefinition.WithPullTriggerEvent()
        {
            return this.WithPullTriggerEvent();
        }

        /// <summary>
        /// The function that specifies a pull action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.ITriggerEventsDefinition.WithPullTriggerEvent()
        {
            return this.WithPullTriggerEvent();
        }

        /// <summary>
        /// The function that specifies a pull action will trigger a run.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.ITriggerEventsDefinition.WithPullTriggerEvent()
        {
            return this.WithPullTriggerEvent();
        }

        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.IRepositoryBranchAndAuth.WithRepositoryAuthentication(TokenType tokenType, string token)
        {
            return this.WithRepositoryAuthentication(tokenType, token);
        }

        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <param name="refreshToken">The token that is used to refresh the access token.</param>
        /// <param name="scope">The scope of the access token.</param>
        /// <param name="expiresIn">Time in seconds that the token remains valid.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.IRepositoryBranchAndAuth.WithRepositoryAuthentication(TokenType tokenType, string token, string refreshToken, string scope, int expiresIn)
        {
            return this.WithRepositoryAuthentication(tokenType, token, refreshToken, scope, expiresIn);
        }

        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.IRepositoryBranchAndAuth.WithRepositoryAuthentication(TokenType tokenType, string token)
        {
            return this.WithRepositoryAuthentication(tokenType, token);
        }

        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <param name="refreshToken">The token that is used to refresh the access token.</param>
        /// <param name="scope">The scope of the access token.</param>
        /// <param name="expiresIn">Time in seconds that the token remains valid.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.IRepositoryBranchAndAuth.WithRepositoryAuthentication(TokenType tokenType, string token, string refreshToken, string scope, int expiresIn)
        {
            return this.WithRepositoryAuthentication(tokenType, token, refreshToken, scope, expiresIn);
        }

        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.IRepositoryBranchAndAuth.WithRepositoryAuthentication(TokenType tokenType, string token)
        {
            return this.WithRepositoryAuthentication(tokenType, token);
        }

        /// <summary>
        /// The function that allows the user to input the type of the token used for authentication and the token itself to authenticate to the source control repository.
        /// </summary>
        /// <param name="tokenType">The type of the token used to authenticate to the source control repository.</param>
        /// <param name="token">The token used to authenticate to the source control repository.</param>
        /// <param name="refreshToken">The token that is used to refresh the access token.</param>
        /// <param name="scope">The scope of the access token.</param>
        /// <param name="expiresIn">Time in seconds that the token remains valid.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.IRepositoryBranchAndAuth.WithRepositoryAuthentication(TokenType tokenType, string token, string refreshToken, string scope, int expiresIn)
        {
            return this.WithRepositoryAuthentication(tokenType, token, refreshToken, scope, expiresIn);
        }

        /// <summary>
        /// The function that specifies the branch of the respository to use.
        /// </summary>
        /// <param name="branch">The repository branch.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.IRepositoryBranchAndAuth.WithRepositoryBranch(string branch)
        {
            return this.WithRepositoryBranch(branch);
        }

        /// <summary>
        /// The function that specifies the branch of the respository to use.
        /// </summary>
        /// <param name="branch">The repository branch.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.IRepositoryBranchAndAuth.WithRepositoryBranch(string branch)
        {
            return this.WithRepositoryBranch(branch);
        }

        /// <summary>
        /// The function that specifies the branch of the respository to use.
        /// </summary>
        /// <param name="branch">The repository branch.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.IRepositoryBranchAndAuth.WithRepositoryBranch(string branch)
        {
            return this.WithRepositoryBranch(branch);
        }

        /// <summary>
        /// The function that allows the user to input their own kind of source control.
        /// </summary>
        /// <param name="sourceControl">The source control the user wishes to use.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.IRepositoryUrl RegistrySourceTrigger.Definition.IBlank.WithSourceControl(SourceControlType sourceControl)
        {
            return this.WithSourceControl(sourceControl);
        }

        /// <summary>
        /// The function that allows the user to input their own kind of source control.
        /// </summary>
        /// <param name="sourceControl">The source control the user wishes to use.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl RegistrySourceTrigger.UpdateDefinition.IBlank.WithSourceControl(SourceControlType sourceControl)
        {
            return this.WithSourceControl(sourceControl);
        }

        /// <summary>
        /// The function that allows the user to input their own kind of source control.
        /// </summary>
        /// <param name="sourceControl">The source control the user wishes to use.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ISourceControlType.WithSourceControl(SourceControlType sourceControl)
        {
            return this.WithSourceControl(sourceControl);
        }

        /// <summary>
        /// The function that specifies the URL of the source control repository.
        /// </summary>
        /// <param name="sourceControlRepositoryUrl">The URL of the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.IRepositoryUrl.WithSourceControlRepositoryUrl(string sourceControlRepositoryUrl)
        {
            return this.WithSourceControlRepositoryUrl(sourceControlRepositoryUrl);
        }

        /// <summary>
        /// The function that specifies the URL of the source control repository.
        /// </summary>
        /// <param name="sourceControlRepositoryUrl">The URL of the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ITriggerEventsDefinition RegistrySourceTrigger.Definition.IRepositoryUrl.WithSourceControlRepositoryUrl(string sourceControlRepositoryUrl)
        {
            return this.WithSourceControlRepositoryUrl(sourceControlRepositoryUrl);
        }

        /// <summary>
        /// The function that specifies the URL of the source control repository.
        /// </summary>
        /// <param name="sourceControlRepositoryUrl">The URL of the source control repository.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ITriggerEventsDefinition RegistrySourceTrigger.UpdateDefinition.IRepositoryUrl.WithSourceControlRepositoryUrl(string sourceControlRepositoryUrl)
        {
            return this.WithSourceControlRepositoryUrl(sourceControlRepositoryUrl);
        }

        /// <summary>
        /// The function that allows the user to specify an action that will trigger a run when it is executed.
        /// </summary>
        /// <param name="sourceTriggerEvent">The action that will trigger a run.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ITriggerEventsDefinition.WithTriggerEvent(SourceTriggerEvent sourceTriggerEvent)
        {
            return this.WithTriggerEvent(sourceTriggerEvent);
        }

        /// <summary>
        /// The function that allows the user to specify an action that will trigger a run when it is executed.
        /// </summary>
        /// <param name="sourceTriggerEvent">The action that will trigger a run.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.ITriggerEventsDefinition.WithTriggerEvent(SourceTriggerEvent sourceTriggerEvent)
        {
            return this.WithTriggerEvent(sourceTriggerEvent);
        }

        /// <summary>
        /// The function that allows the user to specify an action that will trigger a run when it is executed.
        /// </summary>
        /// <param name="sourceTriggerEvent">The action that will trigger a run.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.ITriggerEventsDefinition.WithTriggerEvent(SourceTriggerEvent sourceTriggerEvent)
        {
            return this.WithTriggerEvent(sourceTriggerEvent);
        }

        /// <summary>
        /// The function that allows the user to input the state of the trigger status.
        /// </summary>
        /// <param name="triggerStatus">The user's choice for the trigger status.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ITriggerStatusDefinition.WithTriggerStatus(TriggerStatus triggerStatus)
        {
            return this.WithTriggerStatus(triggerStatus);
        }

        /// <summary>
        /// The function that allows the user to input the state of the trigger status.
        /// </summary>
        /// <param name="triggerStatus">The user's choice for the trigger status.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.ITriggerStatusDefinition.WithTriggerStatus(TriggerStatus triggerStatus)
        {
            return this.WithTriggerStatus(triggerStatus);
        }

        /// <summary>
        /// The function that allows the user to input the state of the trigger status.
        /// </summary>
        /// <param name="triggerStatus">The user's choice for the trigger status.</param>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.ITriggerStatusDefinition.WithTriggerStatus(TriggerStatus triggerStatus)
        {
            return this.WithTriggerStatus(triggerStatus);
        }

        /// <summary>
        /// The function that sets the trigger status to be disabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ITriggerStatusDefinition.WithTriggerStatusDisabled()
        {
            return this.WithTriggerStatusDisabled();
        }

        /// <summary>
        /// The function that sets the trigger status to be disabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.ITriggerStatusDefinition.WithTriggerStatusDisabled()
        {
            return this.WithTriggerStatusDisabled();
        }

        /// <summary>
        /// The function that sets the trigger status to be disabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.ITriggerStatusDefinition.WithTriggerStatusDisabled()
        {
            return this.WithTriggerStatusDisabled();
        }

        /// <summary>
        /// The function that sets the trigger status to be enabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Update.IUpdate RegistrySourceTrigger.Update.ITriggerStatusDefinition.WithTriggerStatusEnabled()
        {
            return this.WithTriggerStatusEnabled();
        }

        /// <summary>
        /// The function that sets the trigger status to be enabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.Definition.ISourceTriggerAttachable RegistrySourceTrigger.Definition.ITriggerStatusDefinition.WithTriggerStatusEnabled()
        {
            return this.WithTriggerStatusEnabled();
        }

        /// <summary>
        /// The function that sets the trigger status to be enabled.
        /// </summary>
        /// <return>The next stage of the container registry source trigger definition.</return>
        RegistrySourceTrigger.UpdateDefinition.ISourceTriggerAttachable RegistrySourceTrigger.UpdateDefinition.ITriggerStatusDefinition.WithTriggerStatusEnabled()
        {
            return this.WithTriggerStatusEnabled();
        }
    }
}