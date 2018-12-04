// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskRunRequest.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5VGFza1J1bkltcGw=
    internal partial class RegistryTaskRunImpl  :
        IRegistryTaskRun,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition.IDefinition
    {
        private DockerBuildRequest dockerTaskRunRequest;
        private EncodedTaskRunRequest encodedTaskRunRequest;
        private FileTaskRunRequest fileTaskRunRequest;
        private RunInner inner;
        private string key;
        private PlatformProperties platform;
        private IRegistriesOperations registriesInner;
        private IRegistryManager registryManager;
        private string registryName;
        private string resourceGroupName;
        private TaskRunRequest taskRunRequest;

        RunInner IHasInner<RunInner>.Inner => this.inner;

        ///GENMHASH:FC4CCB4833EA2DD311741B384FD9316F:8E288AFF39988D3B6818D60EB161D26B
        internal  RegistryTaskRunImpl(IRegistryManager registryManager, RunInner runInner)
        {
            this.registryManager = registryManager;
            this.registriesInner = registryManager.Inner.Registries;
            this.platform = new PlatformProperties();
            this.inner = runInner;
        }

        ///GENMHASH:BC625F271E0C31AE9FFF20BDD16D4A51:FD96C5383DCC6CE16C2130FFBED378D3
        internal void WithDockerTaskRunRequest(DockerBuildRequest dockerTaskRunRequest)
        {
            this.dockerTaskRunRequest = dockerTaskRunRequest;
            this.dockerTaskRunRequest.Platform = this.platform;
        }

        ///GENMHASH:F8AFA78B929EB36D4670F6D6B7F31FAE:C934208C20F2BD45A133F17358CCCF17
        internal void WithEncodedTaskRunRequest(EncodedTaskRunRequest encodedTaskRunRequest)
        {
            this.encodedTaskRunRequest = encodedTaskRunRequest;
            this.encodedTaskRunRequest.Platform = this.platform;
        }

        ///GENMHASH:D9345593486BB5001FF0487CDADE6400:D4DB187C06FE363E81EB7F39C18B0357
        internal void WithFileTaskRunRequest(FileTaskRunRequest fileTaskRunRequest)
        {
            this.fileTaskRunRequest = fileTaskRunRequest;
            this.fileTaskRunRequest.Platform = this.platform;
        }

        ///GENMHASH:65903A017167E0C21C52B22C95EB0BF5:1FE5D2191F139FAE85B9BCB3624CC4C9
        public int Cpu()
        {
            if (this.inner.AgentConfiguration == null)
            {
                return 0;
            }
            return this.inner.AgentConfiguration.Cpu ?? 0;
        }

        ///GENMHASH:9CF9E7853E8D64C266B6DDF7D3CFD441:65E4949FDC279152AE454803CB651CE7
        public DateTime? CreateTime()
        {
            return this.inner.CreateTime;
        }

        ///GENMHASH:6E40675090A7C5A5E2DC401C96A422D5:AB14A1722EB486733144F3DE76934AFD
        public IRegistryTaskRun Execute()
        {
            return Extensions.Synchronize(() => ExecuteAsync());
        }

        ///GENMHASH:28267C95BE469468FC3C62D4CF4CCA7C:0C065EC515A62F7E683F51864F7D2D5F
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.fileTaskRunRequest != null)
            {
                RunInner runInner = await this.registriesInner.ScheduleRunAsync(this.resourceGroupName, this.registryName, this.fileTaskRunRequest, cancellationToken);
                this.inner = runInner;
                return this;
            }
            else if (this.encodedTaskRunRequest != null)
            {
                RunInner runInner = await this.registriesInner.ScheduleRunAsync(this.resourceGroupName, this.registryName, this.encodedTaskRunRequest, cancellationToken);
                this.inner = runInner;
                return this;
            }
            else if (this.dockerTaskRunRequest != null)
            {
                RunInner runInner = await this.registriesInner.ScheduleRunAsync(this.resourceGroupName, this.registryName, this.dockerTaskRunRequest, cancellationToken);
                this.inner = runInner;
                return this;
            }
            else if (this.taskRunRequest != null)
            {
                RunInner runInner = await this.registriesInner.ScheduleRunAsync(this.resourceGroupName, this.registryName, this.taskRunRequest, cancellationToken);
                this.inner = runInner;
                return this;
            }
            throw new InvalidOperationException("Unsupported file task run request");
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public RunInner Inner()
        {
            return this.inner;
        }

        ///GENMHASH:A672AE766499BCCE6A5F298C0C5DE2B5:596C372CD617A5ACFDF590902D332555
        public bool IsArchiveEnabled()
        {
            return this.inner.IsArchiveEnabled ?? false;
        }

        ///GENMHASH:3199B79470C9D13993D729B188E94A46:6653B80313D99B59B1A1B07C544D1CB7
        public string Key()
        {
            return this.key;
        }

        ///GENMHASH:DF5C039E76E3291E606FA7B30E6A35B8:D250719854E6E4B6B55FBDEC11F792F6
        public DateTime? LastUpdatedTime()
        {
            return this.inner.LastUpdatedTime;
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
        public IRegistryTaskRun Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync());
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:2F5CBFE7B258DDFB93CC76AAD3FE8250
        public async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            RunInner runInner = await registryManager.Inner.Runs.GetAsync(this.resourceGroupName, this.registryName, this.inner.RunId, cancellationToken);
            this.inner = runInner;
            return this;
        }

        ///GENMHASH:8D4C48697EFDB2929EBA7ECE9A8E3EF7:3F589FD6FA0A61235346B5B90763BF4D
        public string RegistryName()
        {
            return this.registryName;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:076E3CB13DB4884E2C901B72716B7FE9:5816F38C6BDF9C1FE0795F20F669CF5D
        public string RunId()
        {
            return this.inner.RunId;
        }

        ///GENMHASH:58D593974FB65CAF5BA69B97C68A8945:2D817181166F823B262E302FEAD74E9E
        public RunType RunType()
        {
            if (this.inner.RunType == null)
            {
                return null;
            }
            return Models.RunType.Parse(this.inner.RunType);
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:83A5F71A1B328D8D590BAEBFA00AFA7A
        public RunStatus Status()
        {
            if (this.inner.Status == null)
            {
                return null;
            }
            return RunStatus.Parse(this.inner.Status);
        }

        ///GENMHASH:D959AAB23C99334383E5EC42CE7DADC5:13CF9DD96FDC0B01ECBCF399F76B8557
        public string TaskName()
        {
            return this.inner.Task;
        }

        ///GENMHASH:5EE056E8DE5979116DCB5BF17D80AFE6:5034C25350158382900E0EE2C761AB4F
        public RegistryTaskRunImpl WithArchiveEnabled(bool enabled)
        {
            if (this.fileTaskRunRequest != null)
            {
                this.fileTaskRunRequest.IsArchiveEnabled = enabled;
            }
            else if (this.encodedTaskRunRequest != null)
            {
                this.encodedTaskRunRequest.IsArchiveEnabled = enabled;
            }
            else if (this.dockerTaskRunRequest != null)
            {
                this.dockerTaskRunRequest.IsArchiveEnabled = enabled;
            }
            else if (this.taskRunRequest != null)
            {
                this.taskRunRequest.IsArchiveEnabled = enabled;
            }
            return this;
        }

        ///GENMHASH:18A9F88A694926B31F6279036D5EDE72:2C04DC987EDE75595B65E3517914D724
        public RegistryTaskRunImpl WithCpuCount(int count)
        {
            if (this.fileTaskRunRequest != null)
            {
                if (this.fileTaskRunRequest.AgentConfiguration == null)
                {
                    this.fileTaskRunRequest.AgentConfiguration = new AgentProperties();
                }
                this.fileTaskRunRequest.AgentConfiguration.Cpu = count;
            } else if (this.encodedTaskRunRequest != null)
            {
                if (this.encodedTaskRunRequest.AgentConfiguration == null)
                {
                    this.encodedTaskRunRequest.AgentConfiguration = new AgentProperties();
                }
                this.encodedTaskRunRequest.AgentConfiguration.Cpu = count;
            } else if (this.dockerTaskRunRequest != null)
            {
                if (this.dockerTaskRunRequest.AgentConfiguration == null)
                {
                    this.dockerTaskRunRequest.AgentConfiguration = new AgentProperties();
                }
                this.dockerTaskRunRequest.AgentConfiguration.Cpu = count;
            }
            return this;
        }

        ///GENMHASH:962000C199E038512604D989DC565B37:F38B145F304ACA7B590D99C31B508020
        public RegistryDockerTaskRunRequestImpl WithDockerTaskRunRequest()
        {
            return new RegistryDockerTaskRunRequestImpl(this);
        }

        ///GENMHASH:555591951FBA43C7A7881F1E41FED2E5:1D916DF7AA25EB5611AA573194A1864B
        public RegistryEncodedTaskRunRequestImpl WithEncodedTaskRunRequest()
        {
            return new RegistryEncodedTaskRunRequestImpl(this);
        }

        ///GENMHASH:685F9AC80B6820590A7A092DD1CB580B:93AB789345E292AB3A71D7ACC23F308D
        public RegistryTaskRunImpl WithExistingRegistry(string resourceGroupName, string registryName)
        {
            this.resourceGroupName = resourceGroupName;
            this.registryName = registryName;
            return this;
        }

        ///GENMHASH:BC462BD70C8D95DA901327144923B3BF:65E34FA0DE1CDEF1B636BBFFBE0E39C6
        public RegistryFileTaskRunRequestImpl WithFileTaskRunRequest()
        {
            return new RegistryFileTaskRunRequestImpl(this);
        }

        ///GENMHASH:002B9FED6878745A10FBEF2FDB77458A:554D9D992ECEA010A6B76D4D843D5C07
        public RegistryTaskRunImpl WithLinux()
        {
            this.platform.Os = OS.Linux;
            return this;
        }

        ///GENMHASH:F500AC59E78218D9168FF3C7A41570E4:2A29BB3341F4419936A43F7F29AE49E4
        public RegistryTaskRunImpl WithLinux(Architecture architecture)
        {
            this.platform.Os = OS.Linux;
            this.platform.Architecture = architecture.ToString();
            return this;
        }

        ///GENMHASH:038209D5CBAB8AC8C6F94B0BE7A2EC18:4A762358B1CD7C965C7EF16D0A5FEF4F
        public RegistryTaskRunImpl WithLinux(Architecture architecture, Variant variant)
        {
            this.platform.Os = OS.Linux;
            this.platform.Architecture = architecture.ToString();
            this.platform.Variant = variant.ToString();
            return this;
        }

        ///GENMHASH:CB5CC47567CCCFA8E23A47A0D05562D7:BC0D1BBE8B391EF994E8465AE2265629
        public RegistryTaskRunImpl WithOverridingValue(string name, OverridingValue overridingValue)
        {
            if (this.taskRunRequest.Values == null)
            {
                this.taskRunRequest.Values = new List<SetValue>();
            }
            SetValue value = new SetValue
            {
                Name = name,
                Value = overridingValue.Value,
                IsSecret = overridingValue.IsSecret
            };
            this.taskRunRequest.Values.Add(value);
            return this;
        }

        ///GENMHASH:B2D612D796CE42937533773625556681:2F5E268055BFDB40961109D6CE6FE0CA
        public RegistryTaskRunImpl WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
        {
            if (overridingValues.Count == 0)
            {
                return this;
            }
            List<SetValue> overridingValuesList = new List<SetValue>();
            foreach (var entry in overridingValues)
            {
                SetValue value = new SetValue
                {
                    Name = entry.Key,
                    Value = entry.Value.Value,
                    IsSecret = entry.Value.IsSecret
                };
                overridingValuesList.Add(value);
            }
            this.taskRunRequest.Values = overridingValuesList;
            return this;
        }

        ///GENMHASH:A96A757C20452610FED7B4572BE4EF30:9339C1FD12EF3A231A4EC55FA741B2C8
        public RegistryTaskRunImpl WithPlatform(PlatformProperties platformProperties)
        {
            this.platform = platformProperties;
            return this;
        }

        ///GENMHASH:9179D30BA7C23D1E23BB8837AC989AC9:F97E57D1A742FEA7DE0EA73B5E04267F
        public RegistryTaskRunImpl WithSourceLocation(string location)
        {
            if (this.fileTaskRunRequest != null)
            {
                this.fileTaskRunRequest.SourceLocation = location;
            }
            else if (this.encodedTaskRunRequest != null)
            {
                this.encodedTaskRunRequest.SourceLocation = location;
            }
            else if (this.dockerTaskRunRequest != null)
            {
                this.dockerTaskRunRequest.SourceLocation = location;
            }
            return this;
        }

        ///GENMHASH:B5B0EFFF37E528D8869162FE4CF29D0B:B391B8D4A03F49AB5D7EEE0E0C80937F
        public RegistryTaskRunImpl WithTaskRunRequest(string taskName)
        {
            this.taskRunRequest = new TaskRunRequest
            {
                TaskName = taskName
            };
            this.inner.Task = taskName;
            return this;
        }

        ///GENMHASH:D398244D45CBE77A13F467FDBCE1C475:76BE1FD3FFA7B54CB06C768059757633
        public RegistryTaskRunImpl WithTimeout(int timeout)
        {
            if (this.fileTaskRunRequest != null)
            {
                this.fileTaskRunRequest.Timeout = timeout;
            }
            else if (this.encodedTaskRunRequest != null)
            {
                this.encodedTaskRunRequest.Timeout = timeout;
            }
            else if (this.dockerTaskRunRequest != null)
            {
                this.dockerTaskRunRequest.Timeout = timeout;
            }
            return this;
        }

        ///GENMHASH:21843F6A42DA7655078B0AAA573930DC:572D77BDDC510F7F358FAD4AAD41CF1F
        public RegistryTaskRunImpl WithWindows()
        {
            this.platform.Os = OS.Windows;
            return this;
        }

        ///GENMHASH:61927203232CC1A6BF93766EB4989EF2:B0743689306FDC29BE67D61D619B8E20
        public RegistryTaskRunImpl WithWindows(Architecture architecture)
        {
            this.platform.Os = OS.Windows;
            this.platform.Architecture = architecture.ToString();
            return this;
        }

        ///GENMHASH:8188E03EC2B823A7FA9542299E1BDE95:77B9E626CDC19C03E5105518511847C5
        public RegistryTaskRunImpl WithWindows(Architecture architecture, Variant variant)
        {
            this.platform.Os = OS.Windows;
            this.platform.Architecture = architecture.ToString();
            this.platform.Variant = variant.ToString();
            return this;
        }
    }
}