// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for SourceTriggerEvent.
    /// </summary>
    public partial class SourceTriggerEvent : ExpandableStringEnum<SourceTriggerEvent>, IBeta
    {
        /// <summary>
        /// Static value Commit for SourceTriggerEvent.
        /// </summary>
        public static readonly SourceTriggerEvent Commit = Parse("commit");

        /// <summary>
        /// Static value pullrequest for SourceTriggerEvent.
        /// </summary>
        public static readonly SourceTriggerEvent Pullrequest = Parse("pullrequest");
    }
}
