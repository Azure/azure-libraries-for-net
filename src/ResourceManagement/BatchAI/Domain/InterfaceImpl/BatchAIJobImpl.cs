// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
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
                return this.EnvironmentVariables() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariable>;
            }
        }

        /// <summary>
        /// Gets constraints associated with the Job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPropertiesConstraints Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Constraints
        {
            get
            {
                return this.Constraints() as Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPropertiesConstraints;
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
                return this.ContainerSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.ContainerSettings;
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
                return this.ExecutionInfo() as Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPropertiesExecutionInfo;
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
                return this.OutputDirectories() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectory>;
            }
        }

        /// <summary>
        /// Gets the settings for Tensor Flow job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.TensorFlowSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.TensorFlowSettings
        {
            get
            {
                return this.TensorFlowSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.TensorFlowSettings;
            }
        }

        /// <summary>
        /// Gets priority associated with the job. Priority values can range from -1000
        /// to 1000, with -1000 being the lowest priority and 1000 being the highest
        /// priority. The default value is 0.
        /// </summary>
        int Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Priority
        {
            get
            {
                return this.Priority();
            }
        }

        /// <summary>
        /// Gets the settings for CNTK (aka Microsoft Cognitive Toolkit) job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CNTKsettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.CntkSettings
        {
            get
            {
                return this.CntkSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.CNTKsettings;
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
                return this.PYTorchSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.PyTorchSettings;
            }
        }

        /// <summary>
        /// Gets the list of input directories for the Job.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.InputDirectory> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.InputDirectories
        {
            get
            {
                return this.InputDirectories() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.InputDirectory>;
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
                return this.Secrets() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariableWithSecretValue>;
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
        /// Gets the experiment information of the job.
        /// </summary>
        string Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ExperimentName
        {
            get
            {
                return this.ExperimentName();
            }
        }

        /// <summary>
        /// Gets the Id of the cluster on which this job will run.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.Cluster
        {
            get
            {
                return this.Cluster() as Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId;
            }
        }

        /// <summary>
        /// Gets the settings for custom tool kit job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CustomToolkitSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.CustomToolkitSettings
        {
            get
            {
                return this.CustomToolkitSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.CustomToolkitSettings;
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

        /// <param name="id">The name for the output directory.</param>
        /// <return>The nest stage of the definition for output directory settings.</return>
        Models.OutputDirectorySettings.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithOutputDirectoryBeta.DefineOutputDirectory(string id)
        {
            return this.DefineOutputDirectory(id) as Models.OutputDirectorySettings.Definition.IBlank<BatchAIJob.Definition.IWithCreate>;
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
            return this.ListFiles(outputDirectoryId) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>;
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
        /// <return>An observable that emits output file information.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>> Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ListFilesAsync(string outputDirectoryId, CancellationToken cancellationToken)
        {
            return await this.ListFilesAsync(outputDirectoryId, cancellationToken) as IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>;
        }

        /// <summary>
        /// Gets the settings for Caffe job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CaffeSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.CaffeSettings
        {
            get
            {
                return this.CaffeSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.CaffeSettings;
            }
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
                return this.JobPreparation() as Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPreparation;
            }
        }

        /// <summary>
        /// Gets The toolkit type of this job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ToolType Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ToolType
        {
            get
            {
                return this.ToolType() as Microsoft.Azure.Management.BatchAI.Fluent.Models.ToolType;
            }
        }

        /// <summary>
        /// Gets the settings for Chainer job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ChainerSettings Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob.ChainerSettings
        {
            get
            {
                return this.ChainerSettings() as Microsoft.Azure.Management.BatchAI.Fluent.Models.ChainerSettings;
            }
        }

        ToolTypeSettings.Caffe.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCaffe()
        {
            return this.DefineCaffe() as ToolTypeSettings.Caffe.Definition.IBlank<BatchAIJob.Definition.IWithCreate>;
        }

        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithToolType.WithCustomCommandLine(string commandLine)
        {
            return this.WithCustomCommandLine(commandLine) as BatchAIJob.Definition.IWithCreate;
        }

        ToolTypeSettings.Chainer.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineChainer()
        {
            return this.DefineChainer() as ToolTypeSettings.Chainer.Definition.IBlank<BatchAIJob.Definition.IWithCreate>;
        }

        ToolTypeSettings.Caffe2.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCaffe2()
        {
            return this.DefineCaffe2() as ToolTypeSettings.Caffe2.Definition.IBlank<BatchAIJob.Definition.IWithCreate>;
        }

        ToolTypeSettings.CognitiveToolkit.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineCognitiveToolkit()
        {
            return this.DefineCognitiveToolkit() as ToolTypeSettings.CognitiveToolkit.Definition.IBlank<BatchAIJob.Definition.IWithCreate>;
        }

        ToolTypeSettings.TensorFlow.Definition.IBlank<BatchAIJob.Definition.IWithCreate> BatchAIJob.Definition.IWithToolType.DefineTensorflow()
        {
            return this.DefineTensorflow() as ToolTypeSettings.TensorFlow.Definition.IBlank<BatchAIJob.Definition.IWithCreate>;
        }

        /// <param name="image">The name of the image in image repository.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithContainerSettings.WithContainerImage(string image)
        {
            return this.WithContainerImage(image) as BatchAIJob.Definition.IWithCreate;
        }

        /// <param name="stdOutErrPathPrefix">The path where the Batch AI service will upload the stdout and stderror of the job.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithToolType BatchAIJob.Definition.IWithStdOutErrPathPrefix.WithStdOutErrPathPrefix(string stdOutErrPathPrefix)
        {
            return this.WithStdOutErrPathPrefix(stdOutErrPathPrefix) as BatchAIJob.Definition.IWithToolType;
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
            return this.WithCommandLine(commandLine) as BatchAIJob.Definition.IWithCreate;
        }

        /// <param name="experimentName">Describes the experiment information of the job.</param>
        /// <return>The next stage of the definition.</return>
        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithExperimentName.WithExperimentName(string experimentName)
        {
            return this.WithExperimentName(experimentName) as BatchAIJob.Definition.IWithCreate;
        }

        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithInputDirectory.WithInputDirectory(string id, string path)
        {
            return this.WithInputDirectory(id, path) as BatchAIJob.Definition.IWithCreate;
        }

        BatchAIJob.Definition.IWithCreate BatchAIJob.Definition.IWithOutputDirectory.WithOutputDirectory(string id, string pathPrefix)
        {
            return this.WithOutputDirectory(id, pathPrefix) as BatchAIJob.Definition.IWithCreate;
        }

        /// <param name="nodeCount">Number of nodes.</param>
        /// <return>The next staeg of the definition.</return>
        BatchAIJob.Definition.IWithStdOutErrPathPrefix BatchAIJob.Definition.IWithNodeCount.WithNodeCount(int nodeCount)
        {
            return this.WithNodeCount(nodeCount) as BatchAIJob.Definition.IWithStdOutErrPathPrefix;
        }
    }
}