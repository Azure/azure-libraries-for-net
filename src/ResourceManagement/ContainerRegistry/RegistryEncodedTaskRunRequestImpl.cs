// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5RW5jb2RlZFRhc2tSdW5SZXF1ZXN0SW1wbA==
    internal partial class RegistryEncodedTaskRunRequestImpl  :
        IRegistryEncodedTaskRunRequest,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryEncodedTaskRunRequest.Definition.IDefinition,
        IHasInner<Models.EncodedTaskRunRequest>
    {
        private EncodedTaskRunRequest inner;
        private RegistryTaskRunImpl registryTaskRunImpl;

        ///GENMHASH:42C7ED29B91AB4C147A4EE61E1BF29F6:463F212A6968686C5930F9CD46E9CCFE
        internal  RegistryEncodedTaskRunRequestImpl(RegistryTaskRunImpl registryTaskRunImpl)
        {
            this.inner = new EncodedTaskRunRequest();
            this.registryTaskRunImpl = registryTaskRunImpl;
        }

        EncodedTaskRunRequest IHasInner<EncodedTaskRunRequest>.Inner => this.inner;

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:56E874AF57E42DA5B3AF93CB360AD2E1
        public RegistryTaskRunImpl Attach()
        {
            this.registryTaskRunImpl.WithEncodedTaskRunRequest(this.inner);
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

        ///GENMHASH:73584932215869E7415458AFF5090861:40A980295F5EA8FF8304DA8C06E899BF
        public RegistryEncodedTaskRunRequestImpl DefineEncodedTaskStep()
        {
            return this;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public EncodedTaskRunRequest Inner()
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

        ///GENMHASH:E01037F3D0330154A4A80927AAFE59DA:0FCAF36E1BB4306282B145BFF0A4DC2A
        public RegistryEncodedTaskRunRequestImpl WithBase64EncodedTaskContent(string encodedTaskContent)
        {
            this.inner.EncodedTaskContent = encodedTaskContent;
            return this;
        }

        ///GENMHASH:D6019DA3A6DCFCD04801ECA5DFFD3D79:77A25EE93870D4BAF55F9596A87603D5
        public RegistryEncodedTaskRunRequestImpl WithBase64EncodedValueContent(string encodedValueContent)
        {
            this.inner.EncodedValuesContent = encodedValueContent;
            return this;
        }

        ///GENMHASH:CB5CC47567CCCFA8E23A47A0D05562D7:CDC0F0BF36B2A755E91DF061F03252F2
        public RegistryEncodedTaskRunRequestImpl WithOverridingValue(string name, OverridingValue overridingValue)
        {
            if (this.inner.Values == null)
            {
                this.inner.Values = new List<SetValue>();
            }
            SetValue value = new SetValue
            {
                Name = name,
                Value = overridingValue.Value,
                IsSecret = overridingValue.IsSecret
            };
            this.inner.Values.Add(value);
            return this;
        }

        ///GENMHASH:B2D612D796CE42937533773625556681:8A6659DFE28D13773507071D42EAD636
        public RegistryEncodedTaskRunRequestImpl WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
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
            this.inner.Values = overridingValuesList;
            return this;
        }
    }
}