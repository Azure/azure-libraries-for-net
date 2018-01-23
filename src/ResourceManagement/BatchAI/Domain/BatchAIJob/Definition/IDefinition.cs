// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition
{
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe2.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition;

    /// <summary>
    /// Specifies the command line to be executed before tool kit is launched.
    /// The specified actions will run on all the nodes that are part of the job.
    /// </summary>
    public interface IWithJobPreparation 
    {
        /// <param name="commandLine">Command line to execute.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithCommandLine(string commandLine);
    }

    /// <summary>
    /// The stage of a virtual network gateway connection definition with sufficient inputs to create a new connection in the cloud,
    /// but exposing additional optional settings to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate>,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithJobPreparation,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithInputDirectory,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithOutputDirectory,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithContainerSettings,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithExperimentName
    {
    }

    /// <summary>
    /// Specifies details of the container registry and image such as name, URL and credentials.
    /// </summary>
    public interface IWithContainerSettings 
    {
        /// <param name="image">The name of the image in image repository.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithContainerImage(string image);
    }

    public interface IWithOutputDirectory 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithOutputDirectory(string id, string pathPrefix);
    }

    /// <summary>
    /// The first stage of Batch AI job definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithNodeCount>
    {
    }

    /// <summary>
    /// Allows tro specify the experiment information of the job.
    /// </summary>
    public interface IWithExperimentName 
    {
        /// <param name="experimentName">Describes the experiment information of the job.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithExperimentName(string experimentName);
    }

    public interface IWithToolType
    {
        ToolTypeSettings.Chainer.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineChainer();

        ToolTypeSettings.Caffe2.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCaffe2();

        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithCustomCommandLine(string commandLine);

        ToolTypeSettings.CognitiveToolkit.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCognitiveToolkit();

        ToolTypeSettings.TensorFlow.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineTensorflow();

        ToolTypeSettings.Caffe.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCaffe();
    }

    /// <summary>
    /// The stage of the setup task definition allowing to specify where Batch AI will upload stdout and stderr of the job.
    /// </summary>
    public interface IWithStdOutErrPathPrefix 
    {
        /// <param name="stdOutErrPathPrefix">The path where the Batch AI service will upload the stdout and stderror of the job.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithToolType WithStdOutErrPathPrefix(string stdOutErrPathPrefix);
    }

    /// <summary>
    /// The stage of the definition allowing to specify number of compute nodes to run the job on.
    /// The job will be gang scheduled on that many compute nodes.
    /// </summary>
    public interface IWithNodeCount 
    {
        /// <param name="nodeCount">Number of nodes.</param>
        /// <return>The next staeg of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithStdOutErrPathPrefix WithNodeCount(int nodeCount);
    }

    /// <summary>
    /// The entirety of the Batch AI job definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IBlank,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithStdOutErrPathPrefix,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithNodeCount,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithToolType,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate
    {
    }

    public interface IWithInputDirectory 
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithInputDirectory(string id, string path);
    }
}