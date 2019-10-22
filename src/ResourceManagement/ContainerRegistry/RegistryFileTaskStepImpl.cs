// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5RmlsZVRhc2tTdGVwSW1wbA==
    internal partial class RegistryFileTaskStepImpl  :
        RegistryTaskStepImpl,
        IRegistryFileTaskStep,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryFileTaskStep.Definition.IDefinition,
        RegistryFileTaskStep.Update.IUpdate,
        IHasInner<Models.FileTaskStep>
    {
        private FileTaskStepUpdateParameters fileTaskStepUpdateParameters;
        private FileTaskStep inner;
        private RegistryTaskImpl taskImpl;

        FileTaskStep IHasInner<FileTaskStep>.Inner => this.inner;

        ///GENMHASH:F609722862E2C2E21FAB982E438440A0:01FDF68A6CCD16D14B74163D25ABFE25
        internal  RegistryFileTaskStepImpl(RegistryTaskImpl taskImpl) : base(taskImpl.Inner().Step)
        {
            this.inner = new FileTaskStep();
            if (taskImpl.Inner().Step != null &&  !(taskImpl.Inner().Step is FileTaskStep))
            {
                throw new ArgumentException("Constructor for RegistryFileTaskStepImpl invoked for class that is not FileTaskStep");
            }
            this.taskImpl = taskImpl;
            this.fileTaskStepUpdateParameters = new FileTaskStepUpdateParameters();
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

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:5F4AA3407FDFF831C829A7134F4E8F26
        public ISourceTriggerDefinition Attach()
        {
            this.taskImpl.WithFileTaskStepCreateParameters(this.inner);
            return this.taskImpl;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public FileTaskStep Inner()
        {
            return this.inner;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:6B44A60B23532745DEE6CF9166F06BC9
        public RegistryTask.Update.IUpdate Parent()
        {
            this.taskImpl.WithFileTaskStepUpdateParameters(this.fileTaskStepUpdateParameters);
            return this.taskImpl;
        }

        ///GENMHASH:85D56FB68893F07FCBDC9267ECBCC2EA:A40B4C67701D430EB3D40D8B007A3E21
        public string TaskFilePath()
        {
            FileTaskStep fileTaskStep = (FileTaskStep) this.taskImpl.Inner().Step;
            return fileTaskStep.TaskFilePath;
        }

        ///GENMHASH:B6EAF7CA43219B097DF06B50881D6E8F:AA07800D0178FBBF84887556A1E83751
        public IReadOnlyList<Models.SetValue> Values()
        {
            FileTaskStep fileTaskStep = (FileTaskStep) this.taskImpl.Inner().Step;
            if (fileTaskStep.Values == null)
            {
                return new List<Models.SetValue>();
            }
            return new List<Models.SetValue>(fileTaskStep.Values);
        }

        ///GENMHASH:BF82636AD60CFFCEB709BB0A2FE5BF20:FE0AF66504695AAF8BD745E3677A0134
        public string ValuesFilePath()
        {
            FileTaskStep fileTaskStep = (FileTaskStep) this.taskImpl.Inner().Step;
            return fileTaskStep.ValuesFilePath;
        }

        ///GENMHASH:CB5CC47567CCCFA8E23A47A0D05562D7:BD04F2D9B28489BF539A5B4EEBBBBD4B
        public RegistryFileTaskStepImpl WithOverridingValue(string name, OverridingValue overridingValue)
        {
            if (this.inner.Values == null) {
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
                this.fileTaskStepUpdateParameters.Values.Add(value);
            }
            return this;
        }

        ///GENMHASH:B2D612D796CE42937533773625556681:6BF05B94B389F8B3DB77579FBF6E79E6
        public RegistryFileTaskStepImpl WithOverridingValues(IDictionary<string,Microsoft.Azure.Management.ContainerRegistry.Fluent.OverridingValue> overridingValues)
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
                this.fileTaskStepUpdateParameters.Values = overridingValuesList;
            }
            return this;
        }

        ///GENMHASH:D9B1A0D4766F363FD17BB72E65982C9B:B72227B8853C1DBC4A9A485B6F9C918B
        public RegistryFileTaskStepImpl WithTaskPath(string path)
        {
            if (IsInCreateMode())
            {
                this.inner.TaskFilePath = path;
            }
            else
            {
                this.fileTaskStepUpdateParameters.TaskFilePath = path;
            }
            return this;
        }

        ///GENMHASH:28BB1B72890A59AC3D243D998DF0E04F:EE4F49D3331F70FBE5D1CD83D4A01F31
        public RegistryFileTaskStepImpl WithValuesPath(string path)
        {
            if (IsInCreateMode())
            {
                this.inner.ValuesFilePath = path;
            }
            else
            {
                this.fileTaskStepUpdateParameters.ValuesFilePath = path;
            }
            return this;
        }
    }
}