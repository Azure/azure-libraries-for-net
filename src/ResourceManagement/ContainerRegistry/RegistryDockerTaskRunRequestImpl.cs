// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5RG9ja2VyVGFza1J1blJlcXVlc3RJbXBs
    internal partial class RegistryDockerTaskRunRequestImpl  :
        IRegistryDockerTaskRunRequest,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryDockerTaskRunRequest.Definition.IDefinition,
        IHasInner<Models.DockerBuildRequest>
    {
        private DockerBuildRequest inner;
        private RegistryTaskRunImpl registryTaskRunImpl;

        ///GENMHASH:B6ABDB1A303D2874E421EEB05E30878B:7ADEBBBF3915FA4C3A896E04DA16AFF3
        internal  RegistryDockerTaskRunRequestImpl(RegistryTaskRunImpl registryTaskRunImpl)
        {
            this.inner = new DockerBuildRequest();
            this.registryTaskRunImpl = registryTaskRunImpl;
        }

        DockerBuildRequest IHasInner<DockerBuildRequest>.Inner => this.inner;

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:A7350BD65D9936DD56FCE13FEC9957C6
        public RegistryTaskRunImpl Attach()
        {
            this.registryTaskRunImpl.WithDockerTaskRunRequest(this.inner);
            return this.registryTaskRunImpl;
        }

        ///GENMHASH:4387C5E87FA0D633501796577B831820:1FE5D2191F139FAE85B9BCB3624CC4C9
        public int CpuCount()
        {
            if (this.inner.AgentConfiguration == null) {
                return 0;
            }
            return this.inner.AgentConfiguration.Cpu ?? 0;
        }

        ///GENMHASH:C27194343BD2F216A6BCA92288E7B5E8:40A980295F5EA8FF8304DA8C06E899BF
        public RegistryDockerTaskRunRequestImpl DefineDockerTaskStep()
        {
            return this;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public DockerBuildRequest Inner()
        {
            return this.inner;
        }

        ///GENMHASH:A672AE766499BCCE6A5F298C0C5DE2B5:596C372CD617A5ACFDF590902D332555
        public bool IsArchiveEnabled()
        {
            return this.inner.IsArchiveEnabled ?? false;
        }

        ///GENMHASH:DBBEFCAB8D5734A323833B0D693BA939:E8E31787F8EF6CCA1E226E99A2711C81
        public PlatformProperties Platform()
        {
            return this.inner.Platform;
        }

        ///GENMHASH:3E2D878FEED94F2D4ACBEC01AF7FCEBC:B13107C1EBE2F1E3EF3FD83F02D207BE
        public string SourceLocation()
        {
            return this.inner.SourceLocation;
        }

        ///GENMHASH:332B2E579C70776ECD324AB8F8010CBB:4173A50D78D6004F53F847D0B4EC9565
        public int Timeout()
        {
            return this.inner.Timeout ?? 0;
        }

        ///GENMHASH:08B6A35ED813DA83E5F192DF050923EA:E2F8A5C54D5C68C7A73075E665B1DF78
        public RegistryDockerTaskRunRequestImpl WithCacheEnabled(bool enabled)
        {
            this.inner.NoCache = enabled;
            return this;
        }

        ///GENMHASH:DBCFD44CE3E2172945A461FFA57CAF04:169C04E487C0C481B0155559FD3F76FE
        public RegistryDockerTaskRunRequestImpl WithDockerFilePath(string path)
        {
            this.inner.DockerFilePath = path;
            return this;
        }

        ///GENMHASH:DEA6AE170CA81CD1F88AE923E7CE21CB:0C1033C1CB79B4FBEE32218FF26E036D
        public RegistryDockerTaskRunRequestImpl WithImageNames(IList<string> imageNames)
        {
            this.inner.ImageNames = imageNames;
            return this;
        }

        ///GENMHASH:CE3C72F25B95240A224B656232E54EE5:21AA447F782234827F5E6EA24A1232EE
        public IDockerTaskRunRequestStepAttachable WithOverridingArgument(string name, OverridingArgument overridingArgument)
        {
            if (this.inner.Arguments == null) {
                this.inner.Arguments = new List<Argument>();
            }
            Argument argument = new Argument
            {
                Name = name,
                Value = overridingArgument.Value,
                IsSecret = overridingArgument.IsSecret
            };
            this.inner.Arguments.Add(argument);
            return this;
        }

        ///GENMHASH:D8897AC643E47DBE82A6971E56EBA309:D5D13F540527E256DBF1CEA7DC7A24F7
        public RegistryDockerTaskRunRequestImpl WithOverridingArguments(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingArgument> overridingArguments)
        {
            if (overridingArguments.Count == 0) {
                return this;
            }
            List<Argument> overridingArgumentsList = new List<Argument>();
            foreach (var entry in overridingArguments)
            {
                Argument argument = new Argument
                {
                    Name = entry.Key,
                    Value = entry.Value.Value,
                    IsSecret = entry.Value.IsSecret
                };
                overridingArgumentsList.Add(argument);
            }
            this.inner.Arguments = overridingArgumentsList;
            return this;
        }

        ///GENMHASH:AE2F42E4FD0C576F49C4A56DC4452821:D6DA2B49E97F4000645C750CB418E71C
        public RegistryDockerTaskRunRequestImpl WithPushEnabled(bool enabled)
        {
            this.inner.IsPushEnabled = enabled;
            return this;
        }
    }
}