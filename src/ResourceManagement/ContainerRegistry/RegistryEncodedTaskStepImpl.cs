// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5RW5jb2RlZFRhc2tTdGVwSW1wbA==
    internal partial class RegistryEncodedTaskStepImpl  :
        RegistryTaskStepImpl,
        IRegistryEncodedTaskStep,
        RegistryEncodedTaskStep.Definition.IDefinition,
        RegistryEncodedTaskStep.Update.IUpdate,
        IHasInner<Models.EncodedTaskStep>
    {
        private EncodedTaskStepUpdateParameters encodedTaskStepUpdateParameters;
        private EncodedTaskStep inner;
        private RegistryTaskImpl taskImpl;

        EncodedTaskStep IHasInner<EncodedTaskStep>.Inner => this.inner;

        ///GENMHASH:4641DDCC05BB52F8555772EA9ADE8A42:FC9C9EE51368094AC252B1C35729FDF7
        internal  RegistryEncodedTaskStepImpl(RegistryTaskImpl taskImpl) : base(taskImpl.Inner().Step)
        {
            
            this.inner = new EncodedTaskStep();
            if (taskImpl.Inner().Step != null && !(taskImpl.Inner().Step is EncodedTaskStep)) {
                throw new ArgumentException("Constructor for RegistryEncodedTaskStepImpl invoked for class that is not an EncodedTaskStep");
            }
            this.taskImpl = taskImpl;
            this.encodedTaskStepUpdateParameters = new EncodedTaskStepUpdateParameters();
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:72EDBFCCA418B658C21689517A5019C7
        private bool IsInCreateMode()
        {
            if (this.taskImpl.Inner().Id == null) {
                return true;
            }
            return false;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:3EAA7B8980203C4AD85B7F5420B7497F
        public ISourceTriggerDefinition Attach()
        {
            this.taskImpl.WithEncodedTaskStepCreateParameters(this.inner);
            return this.taskImpl;
        }

        ///GENMHASH:5A8D8588E2C353C7ACD493477186EEED:2DDD9986BB0A99EA92336941400BB9CD
        public string EncodedTaskContent()
        {
            EncodedTaskStep encodedTaskStep = (EncodedTaskStep) this.taskImpl.Inner().Step;
            return encodedTaskStep.EncodedTaskContent;
        }

        ///GENMHASH:B18BEF64C00FE9E84CC2292742591BBC:062D4E38F13895D22FA7D81E6E3C6289
        public string EncodedValuesContent()
        {
            EncodedTaskStep encodedTaskStep = (EncodedTaskStep) this.taskImpl.Inner().Step;
            return encodedTaskStep.EncodedValuesContent;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public EncodedTaskStep Inner()
        {
            return this.inner;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:D6713E5B02CA8710E48E50CD8459C73A
        public RegistryTask.Update.IUpdate Parent()
        {
            this.taskImpl.WithEncodedTaskStepUpdateParameters(this.encodedTaskStepUpdateParameters);
            return this.taskImpl;
        }

        ///GENMHASH:B6EAF7CA43219B097DF06B50881D6E8F:3B270FF0BB6F97BD6B3F36C3305DBEB0
        public IReadOnlyList<Models.SetValue> Values()
        {
            EncodedTaskStep encodedTaskStep = (EncodedTaskStep) this.taskImpl.Inner().Step;
            if (encodedTaskStep.Values == null)
            {
                return new List<SetValue>();
            }
            return new List<Models.SetValue>(encodedTaskStep.Values);
        }

        ///GENMHASH:E01037F3D0330154A4A80927AAFE59DA:62DBD3D6697F29F06595F391639E456E
        public RegistryEncodedTaskStepImpl WithBase64EncodedTaskContent(string encodedTaskContent)
        {
            if (IsInCreateMode())
            {
                this.inner.EncodedTaskContent = encodedTaskContent;
            }
            else
            {
                this.encodedTaskStepUpdateParameters.EncodedTaskContent = encodedTaskContent;
            }
            return this;
        }

        ///GENMHASH:D6019DA3A6DCFCD04801ECA5DFFD3D79:50A3CF5ACB5E2D8EB97BD23D6F55BE86
        public RegistryEncodedTaskStepImpl WithBase64EncodedValueContent(string encodedValueContent)
        {
            if (IsInCreateMode())
            {
                this.inner.EncodedValuesContent = encodedValueContent;
            }
            else
            {
                this.encodedTaskStepUpdateParameters.EncodedValuesContent = encodedValueContent;
            }
            return this;
        }

        ///GENMHASH:CB5CC47567CCCFA8E23A47A0D05562D7:39C107D338D51667A4C7C7CF4E97887B
        public RegistryEncodedTaskStepImpl WithOverridingValue(string name, OverridingValue overridingValue)
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
            if (IsInCreateMode())
            {
                this.inner.Values.Add(value);
            }
            else
            {
                this.encodedTaskStepUpdateParameters.Values.Add(value);
            }
            return this;
        }

        ///GENMHASH:B2D612D796CE42937533773625556681:5103EBB316D7850527E784CD8376CAF2
        public RegistryEncodedTaskStepImpl WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
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
            if (IsInCreateMode())
            {
                this.inner.Values = overridingValuesList;
            }
            else
            {
                this.encodedTaskStepUpdateParameters.Values = overridingValuesList;
            }
            return this;
        }
    }
}