// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent;
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
    public partial class BatchAIJobImpl :
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
        IDefinition,
        IHasMountVolumes
    {
        private IBatchAICluster parent;
        private JobCreateParametersInner createParameters = new JobCreateParametersInner();


        ///GENMHASH:059CF0A75A891E3B7D5534F1F5D7677D:00DF86B9F15044D36FC5E32F6EF565A0
        internal void AttachImageSourceRegistry(ContainerImageSettingsImpl containerImageSettings)
        {
            EnsureContainerSettings().ImageSourceRegistry = containerImageSettings.Inner;
        }

        ///GENMHASH:4FAFAB18615996B56CCEB8BFCFE23ACC:AF1BAE64EA189C8AA1969355AFE86576
        internal void AttachOutputDirectory(OutputDirectorySettingsImpl outputDirectorySettings)
        {
            if (createParameters.OutputDirectories == null) {
                createParameters.OutputDirectories = new List<OutputDirectory>();
            }
            createParameters.OutputDirectories.Add(outputDirectorySettings.Inner);
        }

        ///GENMHASH:C796F226047BC1B11AF35DC9FF304304:4425A9599A84FC42448DE66CC23625A4
        internal void AttachPyTorchSettings(PyTorchImpl pyTorch)
        {
            createParameters.PyTorchSettings = pyTorch.Inner;
        }

        public IBatchAICluster Parent()
        {
            return parent;
        }

        public Models.ResourceId Cluster()
        {
            return Inner.Cluster;
        }

        ///GENMHASH:1F4CD06D2D5DFD44295C9BA374766A7A:609B1A7B082564619D52859AEE86BAE7
        private IList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariable> EnsureEnvironmentVariables()
        {
            if (createParameters.EnvironmentVariables == null) {
                createParameters.EnvironmentVariables = new List<EnvironmentVariable>();
            }
            return createParameters.EnvironmentVariables;
        }

        ///GENMHASH:5E03E122BA1157E26580A70A3DDCFC38:0F2E17AE5B0FFC742A50B16C0B8ECA93
        private IList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariableWithSecretValue> EnsureEnvironmentVariablesWithSecrets()
        {
            if (Inner.Secrets == null) {
                Inner.Secrets = new List<EnvironmentVariableWithSecretValue>();
            }
            return Inner.Secrets;
        }

        public BatchAIJobImpl WithContainerImage(string image)
        {
            if (EnsureContainerSettings().ImageSourceRegistry == null)
            {
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

        ///GENMHASH:CFB683D3617B006FFB78656F84281F44:103EED3DBBE3F4A4AF306B467C5B1187
        public Models.OutputDirectorySettings.Definition.IBlank<BatchAIJob.Definition.IWithCreate> DefineOutputDirectory(string id)
        {
            return new OutputDirectorySettingsImpl(new OutputDirectory()
            {
                Id = id
            }, this);
        }
        
        ///GENMHASH:278C07978C1DF117DBB062CC3DFD9D2A:93DE4F82471F2A0A009361D200635543
        public ToolTypeSettings.PyTorch.Definition.IBlank<BatchAIJob.Definition.IWithCreate> DefinePyTorch()
        {
            return new PyTorchImpl(new PyTorchSettings(), this);
        }

        public BatchAIJobImpl WithOutputDirectory(string id, string pathPrefix)
        {
            if (createParameters.OutputDirectories == null)
            {
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
            if (createParameters.ContainerSettings == null)
            {
                createParameters.ContainerSettings = new ContainerSettings();
            }
            return createParameters.ContainerSettings;
        }
        ///GENMHASH:E10772528575F047814BBD6121B8596C:C4F50FA839C51E21F77D0B204710BA16
        public IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariable> EnvironmentVariables()
        {
            return Inner.EnvironmentVariables.ToList().AsReadOnly();
        }

        public JobPropertiesExecutionInfo ExecutionInfo()
        {
            return Inner.ExecutionInfo;
        }

        public TensorFlowSettings TensorFlowSettings()
        {
            return Inner.TensorFlowSettings;
        }


        ///GENMHASH:5B794EC32B2017F4DB6D296D15C807EE:8B92CC87EAA8C304326EEEA4E104ADBF
        public string JobOutputDirectoryPathSegment()
        {
            return Inner.JobOutputDirectoryPathSegment;
        }


        ///GENMHASH:9CAEB126E31891FBCBEF610FA55F0B44:918CF333AEFA0C9472983BB4D3EAF455
        public IEnumerable<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile> ListFiles(string outputDirectoryId, string directory, int linkExpiryMinutes, int maxResults)
        {
            return Extensions.Synchronize(() => Manager.Inner.Jobs.ListOutputFilesAsync(this.ResourceGroupName, this.Name, new JobsListOutputFilesOptionsInner(outputDirectoryId, directory, linkExpiryMinutes, maxResults)))
                .Select(inner => new OutputFileImpl(inner));
        }

        ///GENMHASH:939E8F1032A1B8C0AB96D412B52318E0:B1E6A38821CED79E43B50A3034484B9D
        public async Task<IPagedCollection<IOutputFile>> ListFilesAsync(string outputDirectoryId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var files = await Manager.Inner.Jobs.ListOutputFilesAsync(this.ResourceGroupName, this.Name,
                new JobsListOutputFilesOptionsInner(outputDirectoryId), cancellationToken);
            var result = files.Select((inner) => new OutputFileImpl(inner));
            return PagedCollection<IOutputFile, File>.CreateFromEnumerable(result);
        }

        ///GENMHASH:C49DAA33A6BEC24793DA91B538DFB8F2:67C8DB89B63C9A02758CADAF8DE68104
        public async Task<IPagedCollection<Microsoft.Azure.Management.BatchAI.Fluent.IOutputFile>> ListFilesAsync(string outputDirectoryId, string directory, int linkExpiryMinutes, int maxResults, CancellationToken cancellationToken = default(CancellationToken))
        {
            var files = await Manager.Inner.Jobs.ListOutputFilesAsync(this.ResourceGroupName, this.Name,
                new JobsListOutputFilesOptionsInner(outputDirectoryId, directory, linkExpiryMinutes, maxResults), cancellationToken);
            var result = files.Select((inner) => new OutputFileImpl(inner));
            return PagedCollection<IOutputFile, File>.CreateFromEnumerable(result);
        }

        ///GENMHASH:1A830FCD0FD7E62DA41C4EC6DB518469:AC8FF8973958BDCA4BF309100541E49E
        public MountVolumes MountVolumes()
        {
            return Inner.MountVolumes;
        }

        ///GENMHASH:69CC6AFCF9ED26E6D8E28631DC87D78D:4D7B3C83F32FCAE1CD9D96BA701DD043
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
            if (parent == null)
            {
                parent = await Manager.BatchAIClusters.GetByIdAsync(createParameters.Cluster.Id, cancellationToken);
            }
            createParameters.Location = parent.RegionName;
            var inner = await Manager.Inner.Jobs.CreateAsync(parent.ResourceGroupName, this.Name, createParameters, cancellationToken);
            SetInner(inner);
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
            if (this.Inner.OutputDirectories == null || this.Inner.OutputDirectories.Count == 0)
            {
                return new List<OutputDirectory>();
            }
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

        public ToolType ToolType()
        {
            if (Inner.ToolType == null)
            {
                return null;
            }
            return Models.ToolType.Parse(Inner.ToolType);
        }

        internal void AttachCaffeSettings(CaffeImpl caffe)
        {
            createParameters.CaffeSettings = caffe.Inner;
        }

        public JobPreparation JobPreparation()
        {
            return Inner.JobPreparation;
        }

        public void AttachAzureBlobFileSystem(IAzureBlobFileSystem azureBlobFileSystem)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.AzureBlobFileSystems == null)
            {
                mountVolumes.AzureBlobFileSystems = new List<AzureBlobFileSystemReference>();
            }
            mountVolumes.AzureBlobFileSystems.Add(azureBlobFileSystem.Inner);
        }

        public void AttachAzureFileShare(IAzureFileShare azureFileShare)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.AzureFileShares == null)
            {
                mountVolumes.AzureFileShares = new List<AzureFileShareReference>();
            }
            mountVolumes.AzureFileShares.Add(azureFileShare.Inner);
        }

        public void AttachFileServer(IFileServer fileServer)
        {
            MountVolumes mountVolumes = EnsureMountVolumes();
            if (mountVolumes.FileServers == null)
            {
                mountVolumes.FileServers = new List<FileServerReference>();
            }
            mountVolumes.FileServers.Add(fileServer.Inner);
        }

        internal void AttachCntkSettings(CognitiveToolkitImpl cognitiveToolkit)
        {
            createParameters.CntkSettings = cognitiveToolkit.Inner;
        }

        internal void AttachChainerSettings(ChainerImpl chainer)
        {
            createParameters.ChainerSettings = chainer.Inner;
        }

        ///GENMHASH:2003E7A6C7E2166AEC611042BBC4B749:D882CF8F274A15693CEE6CE3EA5A5A4A
        public PyTorchSettings PYTorchSettings()
        {
            return Inner.PyTorchSettings;
        }

        ///GENMHASH:7C40B8F1CAC0870CB8598B5F3923153C:4693F9B6A45CFE5A5270DD5BA982E034
        public IReadOnlyList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariableWithSecretValue> Secrets()
        {
            return Inner.Secrets.ToList().AsReadOnly();
        }
        public void Terminate()
        {
            Extensions.Synchronize(() => TerminateAsync());

        }

        private MountVolumes EnsureMountVolumes()
        {
            if (createParameters.MountVolumes == null)
            {
                createParameters.MountVolumes = new MountVolumes();
            }
            return createParameters.MountVolumes;
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

        ///GENMHASH:446B156BB626194DD2A3F46642818AF8:551F630EC4E164B1BDC4E1F286DA3951
        public BatchAIJobImpl WithEnvironmentVariable(string name, string value)
        {
            EnsureEnvironmentVariables().Add(new EnvironmentVariable(name, value));
            return this;
        }

        ///GENMHASH:997F16B1AEBB01217D1CAE2B03B8B73E:E4346C9A19D9DCFF2986204E3D4749B1
        public BatchAIJobImpl WithEnvironmentVariableSecretValue(string name, string value)
        {
            EnsureEnvironmentVariablesWithSecrets().Add(new EnvironmentVariableWithSecretValue(name, value));
            return this;
        }

                ///GENMHASH:AB0BF9D0BEA18CD334AAF69A466D74DB:244EAB58A02E8C0EA8858C0AA028A77B
        public BatchAIJobImpl WithEnvironmentVariableSecretValue(string name, string keyVaultId, string secretUrl)
        {
            KeyVaultSecretReference secretReference = new KeyVaultSecretReference(new Models.ResourceId(keyVaultId), secretUrl);
            EnsureEnvironmentVariablesWithSecrets().Add(new EnvironmentVariableWithSecretValue(name, valueSecretReference: secretReference));
            return this;
        }

        ///GENMHASH:A851295FCC0E9F4FE107D9566C40A6D0:444BB1540F15B3A5BECC3E92D812699B
        public BatchAIJobImpl WithExistingCluster(IBatchAICluster cluster)
        {
            parent = cluster;
            createParameters.Cluster = new Models.ResourceId(cluster.Id);

            return this;
        }

        ///GENMHASH:A1AF6041EECB4ABC084125DFBF602670:8843DDA8D11922F11FAC857055250E18
        public BatchAIJobImpl WithExistingClusterId(string clusterId)
        {
            createParameters.Cluster = new Models.ResourceId(clusterId);
            return this;
        }

        public BatchAIJobImpl WithInputDirectory(string id, string path)
        {
            if (createParameters.InputDirectories == null)
            {
                createParameters.InputDirectories = new List<InputDirectory>();
            }
            createParameters.InputDirectories.Add(new InputDirectory(id, path));
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

        internal BatchAIJobImpl(string name, JobInner inner, IBatchAIManager manager)
            : base(name, inner, manager)
        {
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