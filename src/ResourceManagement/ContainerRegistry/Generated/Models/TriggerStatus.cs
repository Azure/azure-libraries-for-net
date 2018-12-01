// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for TriggerStatus.
    /// </summary>
    public partial class TriggerStatus : ExpandableStringEnum<TriggerStatus>, IBeta
    {
        /// <summary>
        /// Static value Disabled for TriggerStatus.
        /// </summary>
        public static readonly TriggerStatus Disabled = Parse("Disabled");

        /// <summary>
        /// Static value Enabled for TriggerStatus.
        /// </summary>
        public static readonly TriggerStatus Enabled = Parse("Enabled");
    }
}
