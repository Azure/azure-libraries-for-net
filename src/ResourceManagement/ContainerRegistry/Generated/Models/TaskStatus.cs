// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for TaskStatus.
    /// </summary>
    public partial class TaskStatus : ExpandableStringEnum<TaskStatus>, IBeta
    {
        /// <summary>
        /// Static value QuickBuild for TaskStatus.
        /// </summary>
        public static readonly TaskStatus Disabled = Parse("Disabled");

        /// <summary>
        /// Static value QuickRun for TaskStatus.
        /// </summary>
        public static readonly TaskStatus Enabled = Parse("Enabled");
    }
}
