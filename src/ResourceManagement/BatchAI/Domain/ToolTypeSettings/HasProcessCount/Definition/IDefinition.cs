// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasProcessCount.Definition
{
    /// <summary>
    /// The stage of a definition allowing to specify the processes parameter that is passed to MPI runtime.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithProcessCount<ReturnT>
    {
        /// <summary>
        /// Specifies the number of processes parameter that is passed to MPI runtime.
        /// </summary>
        /// <param name="protocol">Number of processes parameter that is passed to MPI runtime</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithProcessCount(int processCount);
    }
}