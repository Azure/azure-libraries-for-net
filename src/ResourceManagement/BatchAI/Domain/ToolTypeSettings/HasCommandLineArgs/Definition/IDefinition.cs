// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent.ToolTypeSettings.HasCommandLineArgs.Definition
{
    /// <summary>
    /// The stage of a definition allowing to specify command line arguments for the job.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithCommandLineArgs<ReturnT>
    {
        /// <summary>
        /// Specifies command line arguments for the job.
        /// </summary>
        /// <param name="commandLineArgs">Command line arguments for the job.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithCommandLineArgs(string commandLineArgs);
    }
}