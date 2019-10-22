// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5RG9ja2VyVGFza1N0ZXBJbXBs
    internal partial class RegistryDockerTaskStepImpl  :
        RegistryTaskStepImpl,
        IRegistryDockerTaskStep,
        RegistryDockerTaskStep.Definition.IDefinition,
        RegistryDockerTaskStep.Update.IUpdate,
        IHasInner<Models.DockerTaskStep>
    {
        private DockerBuildStepUpdateParameters dockerTaskStepUpdateParameters;
        private DockerTaskStep inner;
        private RegistryTaskImpl taskImpl;

        DockerTaskStep IHasInner<DockerTaskStep>.Inner => this.inner;

        ///GENMHASH:4DF71232342D4BA096268526F3BBAB4D:6A5CC3AD232B63D5445A65966E1B17CB
        internal  RegistryDockerTaskStepImpl(RegistryTaskImpl taskImpl) : base(taskImpl.Inner().Step)
        {
            this.inner = new DockerTaskStep();
            if (taskImpl.Inner().Step != null && !(taskImpl.Inner().Step is DockerTaskStep)) {
                throw new ArgumentException("Constructor for RegistryDockerTaskStepImpl invoked for class that is not DockerTaskStep");
            }
            this.taskImpl = taskImpl;
            this.dockerTaskStepUpdateParameters = new DockerBuildStepUpdateParameters();
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:72EDBFCCA418B658C21689517A5019C7
        private bool IsInCreateMode()
        {
            if (this.taskImpl.Inner().Id == null)
            {
                return true;
            }
            return false;
        }

        ///GENMHASH:78AAED6D42F18955E0DE0E502B2420A1:8C59EBAC653DBB85222F8B70821F6189
        public IReadOnlyList<Models.Argument> Arguments()
        {
            DockerTaskStep dockerTaskStep = (DockerTaskStep) this.taskImpl.Inner().Step;
            if (dockerTaskStep.Arguments == null)
            {
                return new List<Models.Argument>();
            }
            return new List<Models.Argument>(dockerTaskStep.Arguments); 
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:C4243420C37D5338320ABC4E4CCF12AE
        public ISourceTriggerDefinition Attach()
        {
            this.taskImpl.WithDockerTaskStepCreateParameters(inner);
            return this.taskImpl;
        }

        ///GENMHASH:FE21A8C5847AAC160C9631C22FBAF7CD:364CE0EF13422679EE2D34A6B76EF5A5
        public string DockerFilePath()
        {
            DockerTaskStep dockerTaskStep = (DockerTaskStep) this.taskImpl.Inner().Step;
            return dockerTaskStep.DockerFilePath;
        }

        ///GENMHASH:250066751D2D35CD71C43A51EC7F6EC1:F36C95FA9D287CD80CE5731CC0AF17F5
        public IReadOnlyList<string> ImageNames()
        {
            DockerTaskStep dockerTaskStep = (DockerTaskStep) this.taskImpl.Inner().Step;
            if (dockerTaskStep.ImageNames == null)
            {
                return new List<string>();
            }
            return new List<string>(dockerTaskStep.ImageNames);
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public DockerTaskStep Inner()
        {
            return this.inner;
        }

        ///GENMHASH:4F15A715A9499FDF9C3E33EFE6A56FB4:39BFD8929150F5A8A879C915DFEF62D8
        public bool IsPushEnabled()
        {
            DockerTaskStep dockerTaskStep = (DockerTaskStep) this.taskImpl.Inner().Step;
            return dockerTaskStep.IsPushEnabled ?? false;
        }

        ///GENMHASH:801568FE4A6C13086EA759BCDF0110AC:86C0B7DF8B3F2FCFB24FCF93BC30E465
        public bool NoCache()
        {
            DockerTaskStep dockerTaskStep = (DockerTaskStep) this.taskImpl.Inner().Step;
            return dockerTaskStep.NoCache ?? false;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:0447E97158211270EC784A87C6DAC022
        public RegistryTask.Update.IUpdate Parent()
        {
            this.taskImpl.WithDockerTaskStepUpdateParameters(dockerTaskStepUpdateParameters);
            return this.taskImpl;
        }

        ///GENMHASH:08B6A35ED813DA83E5F192DF050923EA:8A8ED378D5CACA432213936F341F32F2
        public RegistryDockerTaskStepImpl WithCacheEnabled(bool enabled)
        {
            if (IsInCreateMode())
            {
                this.inner.NoCache = !enabled;
            }
            else
            {
                this.dockerTaskStepUpdateParameters.NoCache = !enabled;
            }
            return this;
        }

        ///GENMHASH:DBCFD44CE3E2172945A461FFA57CAF04:D8C627DF67FF23D3A4BE51BD249A2AE6
        public RegistryDockerTaskStepImpl WithDockerFilePath(string path)
        {
            if (IsInCreateMode())
            {
                this.inner.DockerFilePath = path;
            }
            else
            {
                this.dockerTaskStepUpdateParameters.DockerFilePath = path;
            }
            return this;
        }

        ///GENMHASH:DEA6AE170CA81CD1F88AE923E7CE21CB:E771A9C12F14441F132F5DE65FFB52A2
        public RegistryDockerTaskStepImpl WithImageNames(IList<string> imageNames)
        {
            if (IsInCreateMode())
            {
                this.inner.ImageNames = imageNames;
            }
            else
            {
                this.dockerTaskStepUpdateParameters.ImageNames = imageNames;
            }
            return this;
        }

        ///GENMHASH:CE3C72F25B95240A224B656232E54EE5:DE4EC3CFF657B9C7C27674FB691D0902
        public RegistryDockerTaskStepImpl WithOverridingArgument(string name, OverridingArgument overridingArgument)
        {
            if (this.inner.Arguments == null)
            {
                this.inner.Arguments = new List<Argument>();
            }
            Argument value = new Argument
            {
                Name = name,
                Value = overridingArgument.Value,
                IsSecret = overridingArgument.IsSecret
            };
            if (IsInCreateMode()) {
                this.inner.Arguments.Add(value);
            } else {
                this.dockerTaskStepUpdateParameters.Arguments.Add(value);
            }
            return this;
        }

        ///GENMHASH:D8897AC643E47DBE82A6971E56EBA309:F39A322082751CC5742F445BAF5F0131
        public RegistryDockerTaskStepImpl WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments)
        {
            if (overridingArguments.Count == 0) {
                return this;
            }
            List<Argument> overridingValuesList = new List<Argument>();
            foreach (var entry in overridingArguments)
            {
                Argument value = new Argument
                {
                    Name = entry.Key,
                    Value = entry.Value.Value,
                    IsSecret = entry.Value.IsSecret
                };
                overridingValuesList.Add(value);
            }
            if (IsInCreateMode())
            {
                this.inner.Arguments = overridingValuesList;
            }
            else
            {
                this.dockerTaskStepUpdateParameters.Arguments = overridingValuesList;
            }
            return this;
        }

        ///GENMHASH:AE2F42E4FD0C576F49C4A56DC4452821:BC35FFEE64F5EC79DEA359014002DF5F
        public RegistryDockerTaskStepImpl WithPushEnabled(bool enabled)
        {
            if (IsInCreateMode())
            {
                this.inner.IsPushEnabled = enabled;
            }
            else
            {
                this.dockerTaskStepUpdateParameters.IsPushEnabled = enabled;
            }
            return this;
        }
    }
}