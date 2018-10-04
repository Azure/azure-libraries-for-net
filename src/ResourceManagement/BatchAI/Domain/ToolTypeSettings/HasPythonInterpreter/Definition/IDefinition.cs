// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasPythonInterpreter.Definition
{
    /// <summary>
    /// The stage of a definition allowing to specify the python interpreter path.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithPythonInterpreter<ReturnT>
    {
        /// <summary>
        /// Specifies the python interpreter path.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ReturnT WithPythonInterpreterPath(string path);
    }
}