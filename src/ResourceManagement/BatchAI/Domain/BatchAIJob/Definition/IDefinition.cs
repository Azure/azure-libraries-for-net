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
    /// The stage of the Batch AI job definition allowing to specify environment variables with secrets.
    /// </summary>
    public interface IWithEnvironmentVariableSecretValue
    {
        /// <summary>
        /// Sets the value of the environment variable. This value will never be reported
        /// back by Batch AI.
        /// </summary>
        /// <param name="name">Name of the variable to set.</param>
        /// <param name="value">Value of the variable to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithEnvironmentVariableSecretValue(string name, string value);

        /// <summary>
        /// Specifies KeyVault Store and Secret which contains the value for the
        /// environment variable.
        /// </summary>
        /// <param name="name">Name of the variable to set.</param>
        /// <param name="keyVaultId">Fully qualified resource Id for the Key Vault.</param>
        /// <param name="secretUrl">The URL referencing a secret in a Key Vault.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithEnvironmentVariableSecretValue(string name, string keyVaultId, string secretUrl);
    }

    /// <summary>
    /// The stage of a virtual network gateway connection definition with sufficient inputs to create a new connection in the cloud,
    /// but exposing additional optional settings to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob>,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithJobPreparation,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithInputDirectory,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithOutputDirectory,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithContainerSettings,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithEnvironmentVariable,
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithEnvironmentVariableSecretValue,
        Microsoft.Azure.Management.BatchAI.Fluent.Models.HasMountVolumes.Definition.IWithMountVolumes<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate>
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

    public interface IWithOutputDirectory  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithOutputDirectoryBeta
    {
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithOutputDirectory(string id, string pathPrefix);
    }

    /// <summary>
    /// The first stage of Batch AI job definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCluster
    {

    }

    /// <summary>
    /// The stage of the Batch AI job definition allowing to specify cluster for the job.
    /// </summary>
    public interface IWithCluster
    {

        /// <summary>
        /// Sets Batch AI cluster for the job.
        /// </summary>
        /// <param name="cluster">Batch AI cluster to run the job.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithNodeCount WithExistingCluster(IBatchAICluster cluster);

        /// <summary>
        /// Sets Batch AI cluster id for the job.
        /// </summary>
        /// <param name="clusterId">Batch AI cluster id.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithNodeCount WithExistingClusterId(string clusterId);
    }

    public interface IWithToolType
    {
        ToolTypeSettings.Chainer.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineChainer();

        ToolTypeSettings.Caffe2.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCaffe2();

        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithCustomCommandLine(string commandLine);

        ToolTypeSettings.CognitiveToolkit.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCognitiveToolkit();

        ToolTypeSettings.TensorFlow.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineTensorflow();

        ToolTypeSettings.Caffe.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCaffe();

        ToolTypeSettings.PyTorch.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefinePyTorch();

        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomMpi.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCustomMpi();

        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CustomToolkit.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineCustomToolkit();

        Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Horovod.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineHorovod();
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
    /// Allows to specify environment variables.
    /// </summary>
    public interface IWithEnvironmentVariable
    {
        /// <param name="name">Name of the variable to set.</param>
        /// <param name="value">Value of the variable to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate WithEnvironmentVariable(string name, string value);
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

    public interface IWithOutputDirectoryBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {

        /// <param name="id">The name for the output directory.</param>
        /// <return>The nest stage of the definition for output directory settings.</return>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition.IBlank<Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition.IWithCreate> DefineOutputDirectory(string id);
    }
}