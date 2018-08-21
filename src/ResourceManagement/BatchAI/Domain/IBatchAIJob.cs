// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// Client-side representation of Batch AI Job object, associated with Batch AI Cluster.
    /// </summary>
    public interface IBatchAIJob  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.Models.JobInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob>
    {
        /// <summary>
        /// Gets the Id of the cluster on which this job will run.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ResourceId Cluster { get; }

        /// <summary>
        /// Gets the creation time of the job.
        /// </summary>
        System.DateTime CreationTime { get; }

        /// <summary>
        /// Gets the experiment information of the job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIExperiment Experiment { get; }

        /// <summary>
        /// Gets the time at which the job entered its current provisioning state.
        /// </summary>
        System.DateTime ProvisioningStateTransitionTime { get; }

        /// <summary>
        /// Gets the path where the Batch AI service will upload stdout and stderror of the job.
        /// </summary>
        string StdOutErrPathPrefix { get; }

        /// <summary>
        /// Gets the settings for the container to run the job. If not provided, the job will run on the VM.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ContainerSettings ContainerSettings { get; }

        /// <summary>
        /// Gets constraints associated with the Job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPropertiesConstraints Constraints { get; }

        /// <summary>
        /// Gets the settings for CNTK (aka Microsoft Cognitive Toolkit) job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CNTKsettings CntkSettings { get; }

        /// <summary>
        /// Gets the settings for custom tool kit job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CustomToolkitSettings CustomToolkitSettings { get; }

        /// <summary>
        /// Gets the settings for pyTorch job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.PyTorchSettings PYTorchSettings { get; }

        /// <summary>
        /// Gets information about the execution of a job in the Azure Batch service.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPropertiesExecutionInfo ExecutionInfo { get; }

        /// <summary>
        /// Gets the settings for Tensor Flow job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.TensorFlowSettings TensorFlowSettings { get; }

        /// <summary>
        /// Gets number of compute nodes to run the job on. The job will be gang scheduled on that many compute nodes.
        /// </summary>
        int NodeCount { get; }

        /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">
        /// Id of the job output directory. This is the OutputDirectory--&gt;id
        /// parameter that is given by the user during Create Job.
        /// </param>
        /// <return>List of files inside the given output directory.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile> ListFiles(string outputDirectoryId);

        /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">Id of the job output directory. This is the OutputDirectory--&gt;id parameter that is given by the user during Create Job.</param>
        /// <param name="directory">The path to the directory.</param>
        /// <param name="linkExpiryMinutes">The number of minutes after which the download link will expire.</param>
        /// <param name="maxResults">The maximum number of items to return in the response. A maximum of 1000 files can be returned.</param>
        /// <return>List of files inside the given output directory.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile> ListFiles(string outputDirectoryId, string directory, int linkExpiryMinutes, int maxResults);


        /// <summary>
        /// Gets the list of input directories for the Job.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.InputDirectory> InputDirectories { get; }

        /// <summary>
        /// Gets a segment of job's output directories path created by BatchAI.
        /// Batch AI creates job's output directories under an unique path to avoid
        /// conflicts between jobs. This value contains a path segment generated by
        /// Batch AI to make the path unique and can be used to find the output
        /// directory on the node or mounted filesystem.
        /// </summary>
        string JobOutputDirectoryPathSegment { get; }

        /// <summary>
        /// Terminates a job.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task TerminateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of output directories where the models will be created.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectory> OutputDirectories { get; }

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
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ExecutionState ExecutionState { get; }

        /// <summary>
        /// Gets the provisioned state of the Batch AI job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Gets The toolkit type of this job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ToolType ToolType { get; }

        /// <summary>
        /// Gets the settings for Caffe job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.CaffeSettings CaffeSettings { get; }

        /// <summary>
        /// Gets the actions to be performed before tool kit is launched.
        /// The specified actions will run on all the nodes that are part of the
        /// job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPreparation JobPreparation { get; }

        /// <summary>
        /// Gets Additional environment variables to be passed to the job.
        /// Batch AI services sets the following environment variables for all jobs:
        /// AZ_BATCHAI_INPUT_id, AZ_BATCHAI_OUTPUT_id, AZ_BATCHAI_NUM_GPUS_PER_NODE,
        /// For distributed TensorFlow jobs, following additional environment
        /// variables are set by the Batch AI Service: AZ_BATCHAI_PS_HOSTS,
        /// AZ_BATCHAI_WORKER_HOSTS.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariable> EnvironmentVariables { get; }

        /// <summary>
        /// Gets priority associated with the job. Priority values can range from -1000
        /// to 1000, with -1000 being the lowest priority and 1000 being the highest
        /// priority. The default value is 0.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.JobPriority SchedulingPriority { get; }

        /// <summary>
        /// Gets environment variables with secret values to set on the job. Only names are reported,
        /// server will never report values of these variables back.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariableWithSecretValue> Secrets { get; }


        /// <summary>
        /// Gets the settings for Chainer job.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.ChainerSettings ChainerSettings { get; }

        /// <summary>
        /// Gets the time at which the job entered its current execution state.
        /// </summary>
        System.DateTime ExecutionStateTransitionTime { get; }

        /// <summary>
        /// Terminates a job.
        /// </summary>
        void Terminate();

        /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">
        /// Id of the job output directory. This is the OutputDirectory--&gt;id
        /// parameter that is given by the user during Create Job.
        /// </param>
        /// <return>An observable that emits output file information.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>> ListFilesAsync(string outputDirectoryId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List all files inside the given output directory (Only if the output directory is on Azure File Share or Azure Storage container).
        /// </summary>
        /// <param name="outputDirectoryId">Id of the job output directory. This is the OutputDirectory--&gt;id parameter that is given by the user during Create Job.</param>
        /// <param name="directory">The path to the directory.</param>
        /// <param name="linkExpiryMinutes">The number of minutes after which the download link will expire.</param>
        /// <param name="maxResults">The maximum number of items to return in the response. A maximum of 1000 files can be returned.</param>
        /// <return>An observable that emits output file information.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>> ListFilesAsync(string outputDirectoryId, string directory, int linkExpiryMinutes, int maxResults, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a list of currently existing nodes which were used for the Job execution. The returned information contains the node ID, its public IP and SSH port.
        /// </summary>
        /// <return>List of remote login details.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IRemoteLoginInformation> ListRemoteLoginInformation();

        /// <summary>
        /// Gets a list of currently existing nodes which were used for the Job execution. The returned information contains the node ID, its public IP and SSH port.
        /// </summary>
        /// <return>An observable that emits remote login information.</return>
        Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IRemoteLoginInformation>> ListRemoteLoginInformationAsync(CancellationToken cancellationToken = default(CancellationToken));


    }
}