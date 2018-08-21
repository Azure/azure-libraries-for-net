// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models.HasMountVolumes.Definition;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe2.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.CognitiveToolkit.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.TensorFlow.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    public partial class BatchAIJobImpl 
    {
        /// <summary>
        /// Gets The time at which the job entered its current provisioning state.
        /// </summary>
        /// <summary>
        /// Gets the time at which the job entered its current provisioning state.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ProvisioningStateTransitionTime
        {
            get
            {
                return this.ProvisioningStateTransitionTime();
            }
        }

        /// <summary>
        /// Gets Additional environment variables to be passed to the job.
        /// Batch AI services sets the following environment variables for all jobs:
        /// AZ_BATCHAI_INPUT_id, AZ_BATCHAI_OUTPUT_id, AZ_BATCHAI_NUM_GPUS_PER_NODE,
        /// For distributed TensorFlow jobs, following additional environment
        /// variables are set by the Batch AI Service: AZ_BATCHAI_PS_HOSTS,
        /// AZ_BATCHAI_WORKER_HOSTS.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariable> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.EnvironmentVariables
        {
            get
            {
                return this.EnvironmentVariables();
            }
        }

        /// <summary>
        /// Gets constraints associated with the Job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPropertiesConstraints Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Constraints
        {
            get
            {
                return this.Constraints();
            }
        }

        /// <summary>
        /// Terminates a job.
        /// </summary>
        void Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Terminate()
        {
 
            this.Terminate();
        }

        /// <summary>
        /// Gets the path where the Batch AI service will upload stdout and stderror of the job.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.StdOutErrPathPrefix
        {
            get
            {
                return this.StdOutErrPathPrefix();
            }
        }

        /// <summary>
        /// Gets the settings for the container to run the job. If not provided, the job will run on the VM.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ContainerSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ContainerSettings
        {
            get
            {
                return this.ContainerSettings();
            }
        }

        /// <summary>
        /// Gets the current state of the job. Possible values are: queued - The job is
        /// queued and able to run. A job enters this state when it is created, or
        /// when it is awaiting a retry after a failed run. running - The job is
        /// running on a compute cluster. This includes job-level preparation such
        /// as downloading resource files or set up container specified on the job -
        /// it does not necessarily mean that the job command line has started
        /// executing. terminating - The job is terminated by the user, the
        /// terminate operation is in progress. succeeded - The job has completed
        /// running succesfully and exited with exit code 0. failed - The job has
        /// finished unsuccessfully (failed with a non-zero exit code) and has
        /// exhausted its retry limit. A job is also marked as failed if an error
        /// occurred launching the job.
        /// </summary>
        /// <summary>
        /// Gets the current state of the job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ExecutionState Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ExecutionState
        {
            get
            {
                return this.ExecutionState();
            }
        }

        /// <summary>
        /// Gets information about the execution of a job in the Azure Batch service.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPropertiesExecutionInfo Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ExecutionInfo
        {
            get
            {
                return this.ExecutionInfo();
            }
        }

        /// <summary>
        /// Gets the experiment information of the job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Experiment
        {
            get
            {
                return this.Experiment();
            }
        }


        /// <summary>
        /// Gets a segment of job's output directories path created by BatchAI.
        /// Batch AI creates job's output directories under an unique path to avoid
        /// conflicts between jobs. This value contains a path segment generated by
        /// Batch AI to make the path unique and can be used to find the output
        /// directory on the node or mounted filesystem.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.JobOutputDirectoryPathSegment
        {
            get
            {
                return this.JobOutputDirectoryPathSegment();
            }
        }

        /// <summary>
        /// Gets the list of output directories where the models will be created.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectory> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.OutputDirectories
        {
            get
            {
                return this.OutputDirectories();
            }
        }

        /// <summary>
        /// Gets the settings for Tensor Flow job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.TensorFlowSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.TensorFlowSettings
        {
            get
            {
                return this.TensorFlowSettings();
            }
        }

        /// <summary>
        /// Gets the settings for CNTK (aka Microsoft Cognitive Toolkit) job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CNTKsettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.CntkSettings
        {
            get
            {
                return this.CntkSettings();
            }
        }

        /// <summary>
        /// Gets number of compute nodes to run the job on. The job will be gang scheduled on that many compute nodes.
        /// </summary>
        int Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.NodeCount
        {
            get
            {
                return this.NodeCount();
            }
        }

        /// <summary>
        /// Gets the provisioned state of the Batch AI job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the settings for pyTorch job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.PyTorchSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.PYTorchSettings
        {
            get
            {
                return this.PYTorchSettings();
            }
        }

        /// <summary>
        /// Gets priority associated with the job. Priority values can range from -1000
        /// to 1000, with -1000 being the lowest priority and 1000 being the highest
        /// priority. The default value is 0.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPriority Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.SchedulingPriority
        {
            get
            {
                return this.SchedulingPriority();
            }
        }


        /// <summary>
        /// Gets the list of input directories for the Job.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.InputDirectory> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.InputDirectories
        {
            get
            {
                return this.InputDirectories();
            }
        }

        /// <summary>
        /// Gets environment variables with secret values to set on the job. Only names are reported,
        /// server will never report values of these variables back.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariableWithSecretValue> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Secrets
        {
            get
            {
                return this.Secrets();
            }
        }

        /// <summary>
        /// Terminates a job.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.TerminateAsync(CancellationToken cancellationToken)
        {
 
            await this.TerminateAsync(cancellationToken);
        }



        /// <summary>
        /// Gets the Id of the cluster on which this job will run.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Cluster
        {
            get
            {
                return this.Cluster();
            }
        }

        /// <summary>
        /// Gets the settings for custom tool kit job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CustomToolkitSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.CustomToolkitSettings
        {
            get
            {
                return this.CustomToolkitSettings();
            }
        }

        /// <summary>
        /// Gets the creation time of the job.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.CreationTime
        {
            get
            {
                return this.CreationTime();
            }
        }

         /// <summary>
         /// Begins the definition of Azure blob file system reference to be mounted on each cluster node.
         /// </summary>
         /// <return>The first stage of Azure blob file system reference definition.</return>
         AzureBlobFileSystem.Definition.IBlank<BatchAIJob.Definition.IWithCreate> IWithMountVolumes<BatchAIJob.Definition.IWithCreate>.DefineAzureBlobFileSystem()
         {
            return this.DefineAzureBlobFileSystem();
         }

         /// <summary>
         /// Begins the definition of Azure file share reference to be mounted on each cluster node.
         /// </summary>
         /// <return>The first stage of file share reference definition.</return>
         AzureFileShare.Definition.IBlank<BatchAIJob.Definition.IWithCreate> IWithMountVolumes<BatchAIJob.Definition.IWithCreate>.DefineAzureFileShare()
         {
            return this.DefineAzureFileShare();
         }

        /// <summary>
        /// Begins the definition of Azure file server reference.
        /// </summary>
        /// <return>The first stage of file server reference definition.</return>
        FileServer.Definition.IBlank<BatchAIJob.Definition.IWithCreate> IWithMountVolumes<BatchAIJob.Definition.IWithCreate>.DefineFileServer()
        {
            return this.DefineFileServer();
        }

        ToolTypeSettings.CustomMpi.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCustomMpi()
        {
            return this.DefineCustomMpi();
        }

        ToolTypeSettings.CustomToolkit.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCustomToolkit()
        {
            return this.DefineCustomToolkit();
        }

        /// <param name="id">The name for the output directory.</param>
        /// <return>The nest stage of the definition for output directory settings.</return>
        Models.OutputDirectorySettings.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithOutputDirectoryBeta.DefineOutputDirectory(string id)
        {
            return this.DefineOutputDirectory(id);
        }

        /// <summary>
        /// Gets the time at which the job entered its current execution state.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ExecutionStateTransitionTime
        {
            get
            {
                return this.ExecutionStateTransitionTime();
            }
        }

 /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">
        /// Id of the job output directory. This is the OutputDirectory--&gt;id
        /// parameter that is given by the user during Create Job.
        /// </param>
        /// <return>List of files inside the given output directory.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ListFiles(string outputDirectoryId)
        {
            return this.ListFiles(outputDirectoryId);
        }

        /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">Id of the job output directory. This is the OutputDirectory--&gt;id parameter that is given by the user during Create Job.</param>
        /// <param name="directory">The path to the directory.</param>
        /// <param name="linkExpiryMinutes">The number of minutes after which the download link will expire.</param>
        /// <param name="maxResults">The maximum number of items to return in the response. A maximum of 1000 files can be returned.</param>
        /// <return>List of files inside the given output directory.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ListFiles(string outputDirectoryId, string directory, int linkExpiryMinutes, int maxResults)
        {
            return this.ListFiles(outputDirectoryId, directory, linkExpiryMinutes, maxResults);
        }

        /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">
        /// Id of the job output directory. This is the OutputDirectory--&gt;id
        /// parameter that is given by the user during Create Job.
        /// </param>
        /// <return>An observable that emits output file information.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ListFilesAsync(string outputDirectoryId, CancellationToken cancellationToken)
        {
            return await this.ListFilesAsync(outputDirectoryId, cancellationToken);
        }

        /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">Id of the job output directory. This is the OutputDirectory--&gt;id parameter that is given by the user during Create Job.</param>
        /// <param name="directory">The path to the directory.</param>
        /// <param name="linkExpiryMinutes">The number of minutes after which the download link will expire.</param>
        /// <param name="maxResults">The maximum number of items to return in the response. A maximum of 1000 files can be returned.</param>
        /// <return>An observable that emits output file information.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ListFilesAsync(string outputDirectoryId, string directory, int linkExpiryMinutes, int maxResults, CancellationToken cancellationToken)
        {
            return await this.ListFilesAsync(outputDirectoryId, directory, linkExpiryMinutes, maxResults, cancellationToken);
        }

        /// <summary>
        /// Gets the settings for Caffe job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CaffeSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.CaffeSettings
        {
            get
            {
                return this.CaffeSettings();
            }
        }

        /// <summary>
        /// Gets a list of currently existing nodes which were used for the Job execution. The returned information contains the node ID, its public IP and SSH port.
        /// </summary>
        /// <return>List of remote login details.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IRemoteLoginInformation> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ListRemoteLoginInformation()
        {
            return this.ListRemoteLoginInformation();
        }

        /// <summary>
        /// Gets a list of currently existing nodes which were used for the Job execution. The returned information contains the node ID, its public IP and SSH port.
        /// </summary>
        /// <return>An observable that emits remote login information.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IRemoteLoginInformation>> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ListRemoteLoginInformationAsync(CancellationToken cancellationToken)
        {
            return await this.ListRemoteLoginInformationAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the actions to be performed before tool kit is launched.
        /// The specified actions will run on all the nodes that are part of the
        /// job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPreparation Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.JobPreparation
        {
            get
            {
                return this.JobPreparation();
            }
        }

        /// <summary>
        /// Gets The toolkit type of this job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ToolType Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ToolType
        {
            get
            {
                return this.ToolType();
            }
        }

        /// <summary>
        /// Gets the settings for Chainer job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ChainerSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ChainerSettings
        {
            get
            {
                return this.ChainerSettings();
            }
        }

        ToolTypeSettings.Caffe.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCaffe()
        {
            return this.DefineCaffe();
        }

        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithToolType.WithCustomCommandLine(string commandLine)
        {
            return this.WithCustomCommandLine(commandLine);
        }

        ToolTypeSettings.Chainer.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineChainer()
        {
            return this.DefineChainer();
        }

        ToolTypeSettings.Caffe2.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCaffe2()
        {
            return this.DefineCaffe2();
        }

        ToolTypeSettings.CognitiveToolkit.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCognitiveToolkit()
        {
            return this.DefineCognitiveToolkit();
        }

        ToolTypeSettings.TensorFlow.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineTensorflow()
        {
            return this.DefineTensorflow();
        }

        /// <param name="image">The name of the image in image repository.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithContainerSettings.WithContainerImage(string image)
        {
            return this.WithContainerImage(image);
        }

     /// <param name="name">Name of the variable to set.</param>
        /// <param name="value">Value of the variable to set.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithEnvironmentVariable.WithEnvironmentVariable(string name, string value)
        {
            return this.WithEnvironmentVariable(name, value);
        }

        /// <summary>
        /// Sets the value of the environment variable. This value will never be reported
        /// back by Batch AI.
        /// </summary>
        /// <param name="name">Name of the variable to set.</param>
        /// <param name="value">Value of the variable to set.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithEnvironmentVariableSecretValue.WithEnvironmentVariableSecretValue(string name, string value)
        {
            return this.WithEnvironmentVariableSecretValue(name, value);
        }

        /// <summary>
        /// Specifies KeyVault Store and Secret which contains the value for the
        /// environment variable.
        /// </summary>
        /// <param name="name">Name of the variable to set.</param>
        /// <param name="keyVaultId">Fully qualified resource Id for the Key Vault.</param>
        /// <param name="secretUrl">The URL referencing a secret in a Key Vault.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithEnvironmentVariableSecretValue.WithEnvironmentVariableSecretValue(string name, string keyVaultId, string secretUrl)
        {
            return this.WithEnvironmentVariableSecretValue(name, keyVaultId, secretUrl);
        }

        /// <param name="stdOutErrPathPrefix">The path where the Batch AI service will upload the stdout and stderror of the job.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithToolType BatchAIJob.Definition.IWithStdOutErrPathPrefix.WithStdOutErrPathPrefix(string stdOutErrPathPrefix)
        {
            return this.WithStdOutErrPathPrefix(stdOutErrPathPrefix);
        }

        /// <summary>
        /// Sets Batch AI cluster for the job.
        /// </summary>
        /// <param name="cluster">Batch AI cluster to run the job.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithNodeCount BatchAIJob.Definition.IWithCluster.WithExistingCluster(IBatchAICluster cluster)
        {
            return this.WithExistingCluster(cluster);
        }

        /// <summary>
        /// Sets Batch AI cluster id for the job.
        /// </summary>
        /// <param name="clusterId">Batch AI cluster id.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithNodeCount BatchAIJob.Definition.IWithCluster.WithExistingClusterId(string clusterId)
        {
            return this.WithExistingClusterId(clusterId);
        }

        /// <param name="commandLine">Command line to execute.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithJobPreparation.WithCommandLine(string commandLine)
        {
            return this.WithCommandLine(commandLine);
        }

        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithInputDirectory.WithInputDirectory(string id, string path)
        {
            return this.WithInputDirectory(id, path);
        }

        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithOutputDirectory.WithOutputDirectory(string id, string pathPrefix)
        {
            return this.WithOutputDirectory(id, pathPrefix);
        }

        /// <param name="nodeCount">Number of nodes.</param>
        /// <return>The next staeg of the definition.</return>
        BatchAIJob.Definition.IWithStdOutErrPathPrefix BatchAIJob.Definition.IWithNodeCount.WithNodeCount(int nodeCount)
        {
            return this.WithNodeCount(nodeCount);
        }


        /// <summary>
        /// Specifies the details of the file system to mount on the compute cluster nodes.
        /// </summary>
        /// <param name="mountCommand">Command used to mount the unmanaged file system.</param>
        /// <param name="relativeMountPath">The relative path on the compute cluster node where the file system will be mounted.</param>
        /// <return>The next stage of Batch AI cluster definition.</return>
        BatchAIJob.Definition.IWithCreate IWithMountVolumes<BatchAIJob.Definition.IWithCreate>.WithUnmanagedFileSystem(string mountCommand, string relativeMountPath)
        {
            return this.WithUnmanagedFileSystem(mountCommand, relativeMountPath);
        }
    }
}