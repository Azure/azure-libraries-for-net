// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5VGFza0ltcGw=
    internal partial class RegistryTaskImpl  :
        IRegistryTask,
        RegistryTask.Definition.IDefinition,
        RegistryTask.Update.IUpdate
    {
        internal TaskUpdateParametersInner taskUpdateParameters;
        private TaskInner inner;
        private string key;
        private string registryName;
        private IRegistryTaskStep registryTaskStep;
        private string resourceGroupName;
        private string taskName;
        private ITasksOperations tasksInner;

        ///GENMHASH:90436C433DC4B4C48CC8286CCD933506:75801DEBDE7DF693898C5439817D4492
        internal  RegistryTaskImpl(IRegistryManager registryManager, string taskName)
        {
            this.tasksInner = registryManager.Inner.Tasks;
            this.taskName = taskName;
            this.inner = new TaskInner();
            this.taskUpdateParameters = new TaskUpdateParametersInner();
        }

        ///GENMHASH:F712FF2645AF2A9EDD0A69A05FB730DB:9CE14828E093066A7923277DDBEF714A
        internal  RegistryTaskImpl(IRegistryManager registryManager, TaskInner inner)
        {
            this.tasksInner = registryManager.Inner.Tasks;
            this.taskName = inner.Name;
            this.inner = inner;
            this.resourceGroupName = ResourceUtils.GroupFromResourceId(this.inner.Id);
            this.registryName = ResourceUtils.NameFromResourceId(ResourceUtils.ParentResourcePathFromResourceId(this.inner.Id));
            this.taskUpdateParameters = new TaskUpdateParametersInner();
            SetTaskUpdateParameterTriggers();
        }

        TaskInner IHasInner<TaskInner>.Inner => this.inner;

        string ICreatable<IRegistryTask>.Name => this.taskName;

        ///GENMHASH:B1E212415883B191E7F422B24021C086:D0AAE4DCBE36DC8BDDF25C2ED585C7CC
        internal BaseImageTriggerUpdateParameters SetTaskUpdateParameterBaseImageTrigger()
        {
            BaseImageTriggerUpdateParameters baseImageTriggerUpdateParameters = new BaseImageTriggerUpdateParameters
            {
                Name = this.inner.Trigger.BaseImageTrigger.Name,
                BaseImageTriggerType = this.inner.Trigger.BaseImageTrigger.BaseImageTriggerType,
                Status = this.inner.Trigger.BaseImageTrigger.Status
            };
            return baseImageTriggerUpdateParameters;
        }

        ///GENMHASH:7453CAB1F19C194A769160FBCD6A4645:6AC4E2F2B74D00C340F84A737560D28C
        internal void SetTaskUpdateParameterTriggers()
        {
            if (this.taskUpdateParameters.Trigger == null)
            {
                this.taskUpdateParameters.Trigger = new TriggerUpdateParameters();
            }
            //Clone the source triggers
            if (this.inner.Trigger == null)
            {
                return;
            }
            if (this.inner.Trigger.SourceTriggers != null)
            {
                List<SourceTriggerUpdateParameters> sourceTriggerUpdateParameters = new List<SourceTriggerUpdateParameters>();
                foreach(var sourceTrigger in this.inner.Trigger.SourceTriggers)
                {
                    sourceTriggerUpdateParameters.Add(SourceTriggerToSourceTriggerUpdateParameters(sourceTrigger));
                }
                this.taskUpdateParameters.Trigger.SourceTriggers = sourceTriggerUpdateParameters;
            }
            //Clone the base image trigger
            if (this.inner.Trigger.BaseImageTrigger != null)
            {
                this.taskUpdateParameters.Trigger.BaseImageTrigger = SetTaskUpdateParameterBaseImageTrigger();
            }
        }

        ///GENMHASH:30C98FF9034C1FF1815B95FA5BA504A9:12DFBCBE7D8A63F0C3680DEAB462A319
        internal SourceUpdateParameters SourcePropertiesToSourceUpdateParameters(SourceProperties sourceProperties)
        {
            SourceUpdateParameters sourceUpdateParameters = new SourceUpdateParameters
            {
                SourceControlType = sourceProperties.SourceControlType,
                RepositoryUrl = sourceProperties.RepositoryUrl,
                Branch = sourceProperties.Branch,
                SourceControlAuthProperties = null
            };
            return sourceUpdateParameters;
        }

        ///GENMHASH:F870F3991CAA692DDBAF3C2B35A41CD8:47AC5D78C354A44FC64B4667B18E5C29
        internal SourceTriggerUpdateParameters SourceTriggerToSourceTriggerUpdateParameters(SourceTrigger sourceTrigger)
        {
            SourceTriggerUpdateParameters sourceTriggerUpdateParameters = new SourceTriggerUpdateParameters
            {
                Name = sourceTrigger.Name,
                SourceRepository = SourcePropertiesToSourceUpdateParameters(sourceTrigger.SourceRepository),
                Status = sourceTrigger.Status,
                SourceTriggerEvents = sourceTrigger.SourceTriggerEvents
            };

            return sourceTriggerUpdateParameters;
        }

        ///GENMHASH:3F7C9757D983EB9B94E070784701D15D:F1B70DBFE43A6EB7454ABFFAA48ED2CF
        internal void WithDockerTaskStepCreateParameters(DockerTaskStep dockerTaskStep)
        {
            this.inner.Step = dockerTaskStep;
        }

        ///GENMHASH:482E59CE20101F094DEC595D9E060EA0:8DCE1757BBE11781324E2AFCAB0D6C2A
        internal void WithDockerTaskStepUpdateParameters(DockerBuildStepUpdateParameters dockerTaskStepUpdateParameters)
        {
            this.taskUpdateParameters.Step = dockerTaskStepUpdateParameters;
        }

        ///GENMHASH:3EC3FA0D09AE86B989CD33788093F762:760FCBC7BB4AC1B39DAE15D6745CD3D7
        internal void WithEncodedTaskStepCreateParameters(EncodedTaskStep encodedTaskStep)
        {
            this.inner.Step = encodedTaskStep;
        }

        ///GENMHASH:BB22066EB4F899B122C0C9DFED9B8C02:7BFD72A3BB6A7E6F1179062459711916
        internal void WithEncodedTaskStepUpdateParameters(EncodedTaskStepUpdateParameters encodedTaskStepUpdateParameters)
        {
            this.taskUpdateParameters.Step = encodedTaskStepUpdateParameters;
        }

        ///GENMHASH:79E9FE6D4D43A8CE83EC7872D0217DEF:3BAD044152F7AAA6DCD54893E650C859
        internal void WithFileTaskStepCreateParameters(FileTaskStep fileTaskStep)
        {
            this.inner.Step = fileTaskStep;
        }

        ///GENMHASH:2282D507A6F30ED975BFA75A7D378FC1:9F0AD57FF8FFF70D0DCA3FCDC09106BC
        internal void WithFileTaskStepUpdateParameters(FileTaskStepUpdateParameters fileTaskStepUpdateParameters)
        {
            this.taskUpdateParameters.Step = fileTaskStepUpdateParameters;
        }

        ///GENMHASH:A12EF75C751E8A9F075D9FDDAC3ACB36:B68070588A43DEB02613AD616C58D1C9
        internal void WithSourceTriggerCreateParameters(SourceTrigger sourceTrigger)
        {
            IList<SourceTrigger> sourceTriggers = this.inner.Trigger.SourceTriggers;
            sourceTriggers.Add(sourceTrigger);
            this.inner.Trigger.SourceTriggers = sourceTriggers;
        }

        ///GENMHASH:C46DB33A96FEC2246EB5699A72532FC4:3A4E089FD5FF8B32BAE54515326FAD28
        internal void WithSourceTriggerUpdateParameters(SourceTriggerUpdateParameters sourceTriggerUpdateParameters)
        {
            IList<SourceTriggerUpdateParameters> sourceTriggerUpdateParametersList = this.taskUpdateParameters.Trigger.SourceTriggers;
            sourceTriggerUpdateParametersList.Add(sourceTriggerUpdateParameters);
            this.taskUpdateParameters.Trigger.SourceTriggers = sourceTriggerUpdateParametersList;
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:A4249A4308B8EF08AAB4450D3284D303
        private bool IsInCreateMode()
        {
            if (this.Inner().Id == null)
            {
                return true;
            }
            return false;
        }

        ///GENMHASH:7A26D184347EA91F532899FC93DA3E8B:8456BBCBBB11CEBC17C9ECE561F7920E
        public IRegistryTask Apply()
        {
            return Extensions.Synchronize(() => ApplyAsync());
        }

        ///GENMHASH:93F5525F475C77754B229151C3005F4B:15FFC6B02454B908A913F74C496F88F7
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> ApplyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ RegistryTaskImpl self = this;
            TaskInner taskInner = await this.tasksInner.UpdateAsync(this.resourceGroupName, this.registryName, this.taskName, this.taskUpdateParameters, cancellationToken);
            this.inner = taskInner;
            this.taskUpdateParameters = new TaskUpdateParametersInner();
            this.registryTaskStep = null;
            this.SetTaskUpdateParameterTriggers();
            return this;
        }

        ///GENMHASH:4387C5E87FA0D633501796577B831820:1FE5D2191F139FAE85B9BCB3624CC4C9
        public int CpuCount()
        {
            if (this.inner.AgentConfiguration == null)
            {
                return 0;
            }
            return this.inner.AgentConfiguration.Cpu ?? 0;
        }

        ///GENMHASH:5E4C278C0FA45BB98AA6EAEE080D4953:30474ECB3073C7FC977444DB52C37E74
        public IRegistryTask Create()
        {
            return Extensions.Synchronize(() => this.CreateAsync());
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:6E689D4AD380A772074C5FF08C5F3351
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            TaskInner taskInner = await this.tasksInner.CreateAsync(this.resourceGroupName, this.registryName, this.taskName, this.inner, cancellationToken);
            this.inner = taskInner;
            this.taskUpdateParameters = new TaskUpdateParametersInner();
            this.SetTaskUpdateParameterTriggers();
            return this;
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:B05F00D7CD45A83A3CC6B4D5E878E717
        public DateTime? CreationDate()
        {
            return this.inner.CreationDate;
        }

        ///GENMHASH:C27194343BD2F216A6BCA92288E7B5E8:B6D6B0D69F8C235F3E3A40FFCE3CDC30
        public RegistryDockerTaskStep.Definition.IBlank DefineDockerTaskStep()
        {
            return new RegistryDockerTaskStepImpl(this);
        }

        ///GENMHASH:73584932215869E7415458AFF5090861:58F55C6B33DFDBAC52478C4C0367A390
        public RegistryEncodedTaskStep.Definition.IBlank DefineEncodedTaskStep()
        {
            return new RegistryEncodedTaskStepImpl(this);
        }

        ///GENMHASH:53377973854095773D864368042FD694:93C062F05A0531634AB1855A3662D419
        public RegistryFileTaskStep.Definition.IBlank DefineFileTaskStep()
        {
            return new RegistryFileTaskStepImpl(this);
        }

        ///GENMHASH:6D5670450504E52DA35544ED5DAAEF5F:9FC4E3AE70D346349F923BB9CCEC2944
        public RegistrySourceTriggerImpl DefineSourceTrigger(string sourceTriggerName)
        {
            if (IsInCreateMode())
            {
                    if (this.inner.Trigger == null) {
                        this.inner.Trigger = new TriggerProperties();
                    }
                    if (this.inner.Trigger.SourceTriggers == null) {
                        this.inner.Trigger.SourceTriggers = new List<SourceTrigger>();
                    }
                    return new RegistrySourceTriggerImpl(sourceTriggerName, this, true);
            }
            else
            {
                this.taskUpdateParameters = new TaskUpdateParametersInner();
                this.SetTaskUpdateParameterTriggers();
                return new RegistrySourceTriggerImpl(sourceTriggerName, this, true);

            }
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner().Id;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public TaskInner Inner()
        {
            return this.inner;
        }

        ///GENMHASH:3199B79470C9D13993D729B188E94A46:6653B80313D99B59B1A1B07C544D1CB7
        public string Key()
        {
            return this.key;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner().Name;
        }

        ///GENMHASH:7425374174BD04E47C36E4DF4CE90831:BF44555315B4D8F7DE5B31B09438FA0A
        public string ParentRegistryId()
        {
            return ResourceUtils.ParentResourcePathFromResourceId(this.Id());
        }

        ///GENMHASH:DBBEFCAB8D5734A323833B0D693BA939:E8E31787F8EF6CCA1E226E99A2711C81
        public PlatformProperties Platform()
        {
            return this.inner.Platform;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:8E6A2DAB36E2DF13D724251B6261809B
        public string ProvisioningState()
        {
            return this.inner.ProvisioningState;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:FF7924BFEF46CE7F250D6F5B1A727744
        public IRegistryTask Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync());
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:91AB6FE1CA9EB10C92D08B4F0D59B50C
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTask> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            TaskInner taskInner = await this.tasksInner.GetAsync(this.resourceGroupName, this.registryName, this.taskName, cancellationToken);
            this.inner = taskInner;
            this.taskUpdateParameters = new TaskUpdateParametersInner();
            this.SetTaskUpdateParameterTriggers();
            return this;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:4208AEB8137598AB1A39881825F4406A
        public Region Region()
        {
            return ResourceManager.Fluent.Core.Region.Create(this.RegionName());
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return this.inner.Location;
        }

        ///GENMHASH:0B229B5DA9D0B87884D1A598BA51DB29:9D52ABA446E4F5D20EEE5164D16DAA33
        public IRegistryTaskStep RegistryTaskStep()
        {
            if (this.registryTaskStep != null)
            {
                return this.registryTaskStep;
            }
            if (this.inner.Step is FileTaskStep)
            {
                this.registryTaskStep = new RegistryFileTaskStepImpl(this);
            }
            else if (this.inner.Step is EncodedTaskStep)
            {
                this.registryTaskStep = new RegistryEncodedTaskStepImpl(this);
            }
            else if (this.inner.Step is DockerTaskStep)
            {
                this.registryTaskStep = new RegistryDockerTaskStepImpl(this);
            }
            return this.registryTaskStep;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:354099EE2D93B12CA11EEC127089A1F0
        public string ResourceGroupName()
        {
            return ResourceUtils.GroupFromResourceId(this.Id());
        }

        ///GENMHASH:D2986FC9F97164E77008CD1A409088DD:448C0A9DD20BE304A983A28E2812BEB0
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistrySourceTrigger> SourceTriggers()
        {
            Dictionary<string, IRegistrySourceTrigger> sourceTriggerMap = new Dictionary<string, IRegistrySourceTrigger>();
            foreach (var sourceTrigger in this.inner.Trigger.SourceTriggers)
            {
                sourceTriggerMap.Add(sourceTrigger.Name, new RegistrySourceTriggerImpl(sourceTrigger.Name, this, false));
            }
            return sourceTriggerMap;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:83A5F71A1B328D8D590BAEBFA00AFA7A
        public Models.TaskStatus Status()
        {
            if (this.inner.Status == null)
            {
                return null;
            }
            return Models.TaskStatus.Parse(this.inner.Status);
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:3E9F81F446FDF2A19095DC13C7608416
        public IReadOnlyDictionary<string,string> Tags()
        {
            return new Dictionary<string, string>(this.inner.Tags);
        }

        ///GENMHASH:332B2E579C70776ECD324AB8F8010CBB:4173A50D78D6004F53F847D0B4EC9565
        public int Timeout()
        {
            return this.inner.Timeout ?? 0;
        }

        ///GENMHASH:3605E446652258F29EA85AB7DECDCFE0:6E86D8DB29D222EDA8C3A258C5CD7818
        public TriggerProperties Trigger()
        {
            return this.inner.Trigger;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.inner.Type;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:40A980295F5EA8FF8304DA8C06E899BF
        public RegistryTask.Update.IUpdate Update()
        {
            return this;
        }

        ///GENMHASH:5D86D9BB75D7C4CDAD3DAB9BB9BF4BF1:6A88A12D0F7BD43700E9147D2DD73E8C
        public RegistryTask.Update.IUpdate UpdateBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType)
        {
            this.taskUpdateParameters.Trigger.BaseImageTrigger = new BaseImageTriggerUpdateParameters()
            {
                BaseImageTriggerType = baseImageTriggerType.ToString(),
                Name = baseImageTriggerName
            };
            return this;
        }

        ///GENMHASH:A41D9FDC7DEF92635CB0D8267DD421E4:C971DBFAAFFE750BCDF37C20A656AFA8
        public RegistryTask.Update.IUpdate UpdateBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType, TriggerStatus triggerStatus)
        {
            this.taskUpdateParameters.Trigger.BaseImageTrigger = new BaseImageTriggerUpdateParameters()
            {
                BaseImageTriggerType = baseImageTriggerType.ToString(),
                Name = baseImageTriggerName,
                Status = triggerStatus.ToString()
            };
            return this;
        }

        ///GENMHASH:BCB7B1A3919664E0F14E640004B8CE09:CFACEE08C9A32134E785BDC99BD25589
        public RegistryDockerTaskStep.Update.IUpdate UpdateDockerTaskStep()
        {
            if (!(this.inner.Step is DockerTaskStep))
                {
                throw new ArgumentException("Calling updateDockerTaskStep on a RegistryTask that is of type " + this.inner.Step.GetType().Name + ".");
            }
            return new RegistryDockerTaskStepImpl(this);
        }

        ///GENMHASH:05B5DD07B42227C7DC047E77F4D8E11F:2ACC2F4A5EF27A9E7CFA9AF0F09FD4AD
        public RegistryEncodedTaskStep.Update.IUpdate UpdateEncodedTaskStep()
        {
            if (!(this.inner.Step is EncodedTaskStep))
            {
                throw new ArgumentException("Calling updateEncodedTaskStep on a RegistryTask that is of type " + this.inner.Step.GetType().Name + ".");
            }
            return new RegistryEncodedTaskStepImpl(this);
        }

        ///GENMHASH:A5C168824418E464802CF26CA50BA168:6951EB50DF2B2811EF4E3CE018395A58
        public RegistryFileTaskStep.Update.IUpdate UpdateFileTaskStep()
        {
            if (!(this.inner.Step is FileTaskStep))
            {
                throw new ArgumentException("Calling updateFileTaskStep on a RegistryTask that is of type " + this.inner.Step.GetType().Name + ".");
            }
            return new RegistryFileTaskStepImpl(this);
        }

        ///GENMHASH:DC05BFFF2CE1B1F639624F0C31BF5E07:221C7B647BC21AAEBF0F425237C40306
        public RegistrySourceTrigger.Update.IUpdate UpdateSourceTrigger(string sourceTriggerName)
        {
            return new RegistrySourceTriggerImpl(sourceTriggerName, this, false);
        }

        ///GENMHASH:55EB5C8356E4299B11A375287105ADA7:0F17F373B883B6EFD9CA54E7C723F924
        public ITaskCreatable WithBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType)
        {
            if (this.inner.Trigger == null)
            {
                this.inner.Trigger = new TriggerProperties();
            }
            this.inner.Trigger.BaseImageTrigger = new BaseImageTrigger()
            {
                BaseImageTriggerType = baseImageTriggerType.ToString(),
                Name = baseImageTriggerName,
            };
            return this;
        }

        ///GENMHASH:D257093B75A1FD6945C24122070979DA:06C7C22B7607C11E6DD1CC8B5181B9E5
        public ITaskCreatable WithBaseImageTrigger(string baseImageTriggerName, BaseImageTriggerType baseImageTriggerType, TriggerStatus triggerStatus)
        {
            if (this.inner.Trigger == null)
            {
                this.inner.Trigger = new TriggerProperties();
            }
            this.inner.Trigger.BaseImageTrigger = new BaseImageTrigger()
            {
                BaseImageTriggerType = baseImageTriggerType.ToString(),
                Name = baseImageTriggerName,
                Status = triggerStatus.ToString()
            };
            return this;
        }

        ///GENMHASH:18A9F88A694926B31F6279036D5EDE72:D51C183E2BA3C4C8DCF1BA75DE49956F
        public RegistryTaskImpl WithCpuCount(int count)
        {
            if (IsInCreateMode())
            {
                if (this.inner.AgentConfiguration == null)
                {
                    this.inner.AgentConfiguration = new AgentProperties();
                }
                this.inner.AgentConfiguration.Cpu = count;
            }
            else
            {
                if (this.taskUpdateParameters.AgentConfiguration == null)
                {
                    this.taskUpdateParameters.AgentConfiguration = new AgentProperties();
                }
                this.taskUpdateParameters.AgentConfiguration.Cpu = count;
            }
            return this;
        }

        ///GENMHASH:685F9AC80B6820590A7A092DD1CB580B:93AB789345E292AB3A71D7ACC23F308D
        public ILocation WithExistingRegistry(string resourceGroupName, string registryName)
        {
            this.resourceGroupName = resourceGroupName;
            this.registryName = registryName;
            return this;
        }

        ///GENMHASH:002B9FED6878745A10FBEF2FDB77458A:2F1F6056C960132ABEE30A6BD57416AB
        public RegistryTaskImpl WithLinux()
        {
            if (IsInCreateMode())
            {
                if (this.inner.Platform == null)
                {
                    this.inner.Platform = new PlatformProperties();
                }
                this.inner.Platform.Os = OS.Linux;
            }
            else
            {
                if (this.taskUpdateParameters.Platform == null)
                {
                    this.taskUpdateParameters.Platform = new PlatformUpdateParameters();
                }
                this.taskUpdateParameters.Platform.Os = OS.Linux;
            }
            return this;
        }

        ///GENMHASH:F500AC59E78218D9168FF3C7A41570E4:51752A84169750EF6CC67BBD49E08F86
        public RegistryTaskImpl WithLinux(Architecture architecture)
        {
            if (IsInCreateMode())
            {
                if (this.inner.Platform == null)
                {
                    this.inner.Platform = new PlatformProperties();
                }
                this.inner.Platform.Os = OS.Linux;
                this.inner.Platform.Architecture = architecture.ToString();
            }
            else
            {
                if (this.taskUpdateParameters.Platform == null)
                {
                    this.taskUpdateParameters.Platform = new PlatformUpdateParameters();
                }
                this.taskUpdateParameters.Platform.Os = OS.Linux;
                this.taskUpdateParameters.Platform.Architecture = architecture.ToString();
            }
            return this;
        }

        ///GENMHASH:038209D5CBAB8AC8C6F94B0BE7A2EC18:CD8C2E169DD531EEB29CE2EBBC071F9A
        public RegistryTaskImpl WithLinux(Architecture architecture, Variant variant)
        {
            if (IsInCreateMode())
            {
                if (this.inner.Platform == null)
                {
                    this.inner.Platform = new PlatformProperties();
                }
                this.inner.Platform.Os = OS.Linux;
                this.inner.Platform.Architecture = architecture.ToString();
                this.inner.Platform.Variant = variant.ToString();
            }
            else
            {
                if (this.taskUpdateParameters.Platform == null)
                {
                    this.taskUpdateParameters.Platform = new PlatformUpdateParameters();
                }
                this.taskUpdateParameters.Platform.Os = OS.Linux;
                this.taskUpdateParameters.Platform.Architecture = architecture.ToString();
                this.taskUpdateParameters.Platform.Variant = variant.ToString();
            }
            return this;
        }

        ///GENMHASH:C8421133DBC453BD76FCC9BC29C80FA1:DB103CA76D35B3F886387108E6D1DB51
        public Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.IPlatform WithLocation(string location)
        {
            this.inner.Location = location;
            return this;
        }

        ///GENMHASH:3E6A2E1842CF7045A3B0CF12AF9A85DA:E33041A1B1224A8FECB4AE9F5C506E26
        public Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition.IPlatform WithLocation(Region location)
        {
            this.inner.Location = location.ToString();
            return this;
        }

        ///GENMHASH:A96A757C20452610FED7B4572BE4EF30:AD5446D69223665E80C77696FF8DD55F
        public RegistryTaskImpl WithPlatform(PlatformProperties platformProperties)
        {
            this.inner.Platform = platformProperties;
            return this;
        }

        ///GENMHASH:E590895F83EFEDA0F00005209D8A6D68:33AACCCB511030D67212CEB658F787E7
        public RegistryTaskImpl WithPlatform(PlatformUpdateParameters platformProperties)
        {
            this.taskUpdateParameters.Platform = platformProperties;
            return this;
        }

        ///GENMHASH:D398244D45CBE77A13F467FDBCE1C475:D430E3D08F7B9614E6E16B6AEA57C80F
        public RegistryTaskImpl WithTimeout(int timeout)
        {
            if (IsInCreateMode())
            {
                this.inner.Timeout = timeout;
            }
            else
            {
                this.taskUpdateParameters.Timeout = timeout;
            }
            return this;
        }

        ///GENMHASH:21843F6A42DA7655078B0AAA573930DC:4337B7AE6B8051E9D67CDDFC3CA22D5D
        public RegistryTaskImpl WithWindows()
        {
            if (IsInCreateMode())
            {
                if (this.inner.Platform == null)
                {
                    this.inner.Platform = new PlatformProperties();
                }
                this.inner.Platform.Os = OS.Windows;
            }
            else
            {
                if (this.taskUpdateParameters.Platform == null)
                {
                    this.taskUpdateParameters.Platform = new PlatformUpdateParameters();
                }
                this.taskUpdateParameters.Platform.Os = OS.Windows;
            }
            return this;
        }

        ///GENMHASH:61927203232CC1A6BF93766EB4989EF2:59353B218FE76FAA5D56DF324C139590
        public RegistryTaskImpl WithWindows(Architecture architecture)
        {
            if (IsInCreateMode())
            {
                if (this.inner.Platform == null)
                {
                    this.inner.Platform = new PlatformProperties();
                }
                this.inner.Platform.Os = OS.Windows;
                this.inner.Platform.Architecture = architecture.ToString();
            }
            else
            {
                if (this.taskUpdateParameters.Platform == null)
                {
                    this.taskUpdateParameters.Platform = new PlatformUpdateParameters();
                }
                this.taskUpdateParameters.Platform.Os = OS.Windows;
                this.taskUpdateParameters.Platform.Architecture = architecture.ToString();
            }
            return this;
        }

        ///GENMHASH:8188E03EC2B823A7FA9542299E1BDE95:6CEDBE6501EDA164429C77601DC07219
        public RegistryTaskImpl WithWindows(Architecture architecture, Variant variant)
        {
            if (IsInCreateMode())
            {
                if (this.inner.Platform == null)
                {
                    this.inner.Platform = new PlatformProperties();
                }
                this.inner.Platform.Os = OS.Windows;
                this.inner.Platform.Architecture = architecture.ToString();
                this.inner.Platform.Variant = variant.ToString();
            }
            else
            {
                if (this.taskUpdateParameters.Platform == null)
                {
                    this.taskUpdateParameters.Platform = new PlatformUpdateParameters();
                }
                this.taskUpdateParameters.Platform.Os = OS.Windows;
                this.taskUpdateParameters.Platform.Architecture = architecture.ToString();
                this.taskUpdateParameters.Platform.Variant = variant.ToString();
            }
            return this;
        }
    }
}