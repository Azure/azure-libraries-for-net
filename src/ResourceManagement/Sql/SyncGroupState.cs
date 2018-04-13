// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for SyncGroupState.
    /// </summary>
    public class SyncGroupState : ExpandableStringEnum<SyncGroupState>
    {
        public static readonly SyncGroupState NotReady = Parse("NotReady");
        public static readonly SyncGroupState Error = Parse("Error");
        public static readonly SyncGroupState Warning = Parse("Warning");
        public static readonly SyncGroupState Progressing = Parse("Progressing");
        public static readonly SyncGroupState Good = Parse("Good");
    }
}
