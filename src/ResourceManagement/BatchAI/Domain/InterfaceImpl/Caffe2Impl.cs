// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Caffe2.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class Caffe2Impl 
    {
        ToolTypeSettings.Caffe2.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Caffe2.Definition.IWithPython<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath) as ToolTypeSettings.Caffe2.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate>;
        }
    }
}