// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;

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

    /// <summary>
    /// Implementation for BatchAIJob and its create interface.
    /// </summary>
    public partial class BatchAIJobImpl  :
        GroupableResource<
            IBatchAIJob,
            JobInner,
            BatchAIJobImpl,
            IBatchAIManager,
            IWithNodeCount,
            IWithNodeCount,
            IWithCreate,
            IWithCreate>,
        IBatchAIJob,
        IDefinition
    {
        private IBatchAICluster parent;
        private JobCreateParametersInner createParameters = new JobCreateParametersInner();
        public IBatchAICluster Parent()
        {
            return parent;
        }

        public Models.ResourceId Cluster()
        {
            return Inner.Cluster;
        }

        public BatchAIJobImpl WithContainerImage(string image)
        {
            if (EnsureContainerSettings().ImageSourceRegistry == null) {
                createParameters.ContainerSettings.ImageSourceRegistry = new ImageSourceRegistry();
            }
            createParameters.ContainerSettings.ImageSourceRegistry.Image = image;
            return this;
        }

        public string StdOutErrPathPrefix()
        {
            return Inner.StdOutErrPathPrefix;
        }

        public ContainerSettings ContainerSettings()
        {
            return Inner.ContainerSettings;
        }

        public BatchAIJobImpl WithOutputDirectory(string id, string pathPrefix)
        {
            if (createParameters.OutputDirectories == null) {
                createParameters.OutputDirectories = new List<OutputDirectory>();
            }
            createParameters.OutputDirectories.Add(new OutputDirectory()
            {
                Id = id,
                PathPrefix = pathPrefix
            });
            return this;
        }

        protected override async Task<JobInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Manager.Inner.Jobs.GetAsync(ResourceGroupName, Name);
        }

        public JobPropertiesConstraints Constraints()
        {
            return Inner.Constraints;
        }

        private ContainerSettings EnsureContainerSettings()
        {
            if (createParameters.ContainerSettings == null) {
                createParameters.ContainerSettings = new ContainerSettings();
            }
            return createParameters.ContainerSettings;
        }

        public JobPropertiesExecutionInfo ExecutionInfo()
        {
            return Inner.ExecutionInfo;
        }

        public TensorFlowSettings TensorFlowSettings()
        {
            return Inner.TensorFlowSettings;
        }

        public int NodeCount()
        {
            return Inner.NodeCount.GetValueOrDefault();
        }

        public IWithCreate WithExperimentName(string experimentName)
        {
            Inner.ExperimentName = experimentName;
            return this;
        }

        public ToolTypeSettings.CognitiveToolkit.Definition.IBlank<BatchAIJob.Definition.IWithCreate> DefineCognitiveToolkit()
        {
            return new CognitiveToolkitImpl(new CNTKsettings(), this);
        }

        public override async Task<Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIJob> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            createParameters.Cluster = new Models.ResourceId(parent.Id);
            createParameters.Location = Inner.Location;
            await Manager.Inner.Jobs.CreateAsync(parent.ResourceGroupName, this.Name, createParameters);
            return this;
        }

        public ToolTypeSettings.Caffe.Definition.IBlank<BatchAIJob.Definition.IWithCreate> DefineCaffe()
        {
            return new CaffeImpl(new CaffeSettings(), this);
        }

        public IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.InputDirectory> InputDirectories()
        {
            return Inner.InputDirectories.ToList();
        }

        internal void AttachCaffe2Settings(Caffe2Impl caffe2)
        {
            createParameters.Caffe2Settings = caffe2.Inner;
        }

        public IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectory> OutputDirectories()
        {
            return Inner.OutputDirectories.ToList();
        }

        public ProvisioningState ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        internal void AttachTensorFlowSettings(TensorFlowImpl tensorFlow)
        {
            createParameters.TensorFlowSettings = tensorFlow.Inner;
        }

        public int Priority()
        {
            return Inner.Priority.GetValueOrDefault();
        }

        public ToolType ToolType() {
            if (Inner.ToolType == null) {
                return null;
            }
            return Models.ToolType.Parse(Inner.ToolType);
        }

        private List<InputDirectory> EnsureInputDirectories()
        {
            if (createParameters.InputDirectories == null) {
                createParameters.InputDirectories = new List<InputDirectory>();
            }
            return createParameters.InputDirectories.ToList();
        }

        internal void AttachCaffeSettings(CaffeImpl caffe)
        {
            createParameters.CaffeSettings = caffe.Inner;
        }

        public JobPreparation JobPreparation()
        {
            return Inner.JobPreparation;
        }

        internal void AttachCntkSettings(CognitiveToolkitImpl cognitiveToolkit)
        {
            createParameters.CntkSettings = cognitiveToolkit.Inner;
        }

        internal void AttachChainerSettings(ChainerImpl chainer)
        {
            createParameters.ChainerSettings = chainer.Inner;
        }

        public void Terminate()
        {
            Extensions.Synchronize(() => TerminateAsync());

        }

        public async Task<IPagedCollection<IOutputFile>> ListFilesAsync(string outputDirectoryId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var connections = await Manager.Inner.Jobs.ListOutputFilesAsync(this.ResourceGroupName, this.Name,
                new JobsListOutputFilesOptionsInner(outputDirectoryId), cancellationToken);
            var result = connections.Select((inner) => new OutputFileImpl(inner));
            return PagedCollection<IOutputFile, File>.CreateFromEnumerable(result);
        }

        public string ExperimentName()
        {
            return Inner.ExperimentName;
        }

        public ToolTypeSettings.Caffe2.Definition.IBlank<BatchAIJob.Definition.IWithCreate> DefineCaffe2()
        {
            return new Caffe2Impl(new Caffe2Settings(), this);
        }

        public DateTime CreationTime()
        {
            return Inner.CreationTime.GetValueOrDefault();
        }

        public DateTime ProvisioningStateTransitionTime()
        {
            return Inner.ProvisioningStateTransitionTime.GetValueOrDefault();
        }

        public CNTKsettings CntkSettings()
        {
            return Inner.CntkSettings;
        }

        public CustomToolkitSettings CustomToolkitSettings()
        {
            return Inner.CustomToolkitSettings;
        }

        public IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile> ListFiles(string outputDirectoryId)
        {
            return Extensions.Synchronize(() => Manager.Inner.Jobs.ListOutputFilesAsync(this.ResourceGroupName, this.Name, new JobsListOutputFilesOptionsInner(outputDirectoryId)))
                .Select(inner => new OutputFileImpl(inner));
        }

        public BatchAIJobImpl WithNodeCount(int nodeCount)
        {
            createParameters.NodeCount = nodeCount;
            return this;
        }

        public async Task TerminateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Jobs.TerminateAsync(ResourceGroupName, Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        public ExecutionState ExecutionState()
        {
            return Inner.ExecutionState.GetValueOrDefault();
        }

        public BatchAIJobImpl WithStdOutErrPathPrefix(string stdOutErrPathPrefix)
        {
            createParameters.StdOutErrPathPrefix = stdOutErrPathPrefix;
            return this;
        }

        public BatchAIJobImpl WithCustomCommandLine(string commandLine)
        {
            Inner.CustomToolkitSettings = new CustomToolkitSettings()
            {
                CommandLine = commandLine
            };
        return this;
    }

        public ToolTypeSettings.Chainer.Definition.IBlank<BatchAIJob.Definition.IWithCreate> DefineChainer()
        {
            return new ChainerImpl(new ChainerSettings(), this);
        }

        public CaffeSettings CaffeSettings()
        {
            return Inner.CaffeSettings;
        }

        public BatchAIJobImpl WithInputDirectory(string id, string path)
        {
            EnsureInputDirectories().Add(new InputDirectory(id, path));
            return this;
        }

        public BatchAIJobImpl WithCommandLine(string commandLine)
        {
            createParameters.JobPreparation = new JobPreparation()
            {
                CommandLine = commandLine
            };
            return this;
        }

        internal  BatchAIJobImpl(string name, BatchAIClusterImpl parent, JobInner inner)
            : base(name, inner, parent.Manager)
        {
            this.parent = parent;
        }

        public IReadOnlyList<EnvironmentSetting> EnvironmentVariables()
        {
            return Inner.EnvironmentVariables.ToList();
        }

        public ChainerSettings ChainerSettings()
        {
            return Inner.ChainerSettings;
        }

        public DateTime ExecutionStateTransitionTime()
        {
            return Inner.ExecutionStateTransitionTime.GetValueOrDefault();
        }

        public ToolTypeSettings.TensorFlow.Definition.IBlank<BatchAIJob.Definition.IWithCreate> DefineTensorflow()
        {
            return new TensorFlowImpl(new TensorFlowSettings(), this);
        }
    }
}