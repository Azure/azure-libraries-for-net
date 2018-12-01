// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for RunType.
    /// </summary>
    public partial class RunType : ExpandableStringEnum<RunType>, IBeta
    {
        /// <summary>
        /// Static value QuickBuild for RunType.
        /// </summary>
        public static readonly RunType QuickBuild = Parse("QuickBuild");

        /// <summary>
        /// Static value QuickRun for RunType.
        /// </summary>
        public static readonly RunType QuickRun = Parse("QuickRun");

        /// <summary>
        /// Static value AutoBuild for RunType.
        /// </summary>
        public static readonly RunType AutoBuild = Parse("AutoBuild");

        /// <summary>
        /// Static value AutoRun for RunType.
        /// </summary>
        public static readonly RunType AutoRun = Parse("AutoRun");
    }
}
