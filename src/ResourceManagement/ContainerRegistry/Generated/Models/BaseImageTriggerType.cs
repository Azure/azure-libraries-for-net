// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for BaseImageTriggerType.
    /// </summary>
    public partial class BaseImageTriggerType : ExpandableStringEnum<BaseImageTriggerType>, IBeta
    {
        /// <summary>
        /// Static value QuickBuild for BaseImageTriggerType.
        /// </summary>
        public static readonly BaseImageTriggerType All = Parse("All");

        /// <summary>
        /// Static value QuickRun for BaseImageTriggerType.
        /// </summary>
        public static readonly BaseImageTriggerType Runtime = Parse("Runtime");
    }
}
