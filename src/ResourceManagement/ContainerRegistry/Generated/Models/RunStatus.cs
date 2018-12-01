// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for RunType.
    /// </summary>
    public partial class RunStatus : ExpandableStringEnum<RunStatus>, IBeta
    {
        /// <summary>
        /// Static value QuickBuild for RunType.
        /// </summary>
        public static readonly RunStatus Queued = Parse("Queued");

        /// <summary>
        /// Static value QuickRun for RunType.
        /// </summary>
        public static readonly RunStatus Started = Parse("Started");

        /// <summary>
        /// Static value AutoBuild for RunType.
        /// </summary>
        public static readonly RunStatus Running = Parse("Running");

        /// <summary>
        /// Static value AutoRun for RunType.
        /// </summary>
        public static readonly RunStatus Succeeded = Parse("Succeeded");
        /// <summary>
        /// Static value Failed for RunType.
        /// </summary>
        public static readonly RunStatus Failed = Parse("Failed");

        /// <summary>
        /// Static value Error for RunType.
        /// </summary>
        public static readonly RunStatus Error = Parse("Error");

        /// <summary>
        /// Static value Running for RunType.
        /// </summary>
        public static readonly RunStatus Canceled = Parse("Canceled");

        /// <summary>
        /// Static value Timeout for RunType.
        /// </summary>
        public static readonly RunStatus Timeout = Parse("Timeout");
    }
}
