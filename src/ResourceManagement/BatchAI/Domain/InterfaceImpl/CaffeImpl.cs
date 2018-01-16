// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class CaffeImpl 
    {
        /// <param>PythonScriptFilePath.</param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.Caffe.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Caffe.Definition.IWithFileType<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath) as ToolTypeSettings.Caffe.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate>;
        }

        /// <param name="configFilePath">The path of the config file.</param>
        /// <return>The next stage of the definition.</return>
        ToolTypeSettings.Caffe.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Caffe.Definition.IWithFileType<BatchAIJob.Definition.IWithCreate>.WithConfigFile(string configFilePath)
        {
            return this.WithConfigFile(configFilePath) as ToolTypeSettings.Caffe.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate>;
        }
    }
}