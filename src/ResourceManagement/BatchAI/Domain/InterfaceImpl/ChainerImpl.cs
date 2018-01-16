// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.Chainer.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    public partial class ChainerImpl 
    {
        ToolTypeSettings.Chainer.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate> ToolTypeSettings.Chainer.Definition.IWithPython<BatchAIJob.Definition.IWithCreate>.WithPythonScriptFile(string pythonScriptFilePath)
        {
            return this.WithPythonScriptFile(pythonScriptFilePath) as ToolTypeSettings.Chainer.Definition.IWithAttachAndPythonInterpreter<BatchAIJob.Definition.IWithCreate>;
        }
    }
}