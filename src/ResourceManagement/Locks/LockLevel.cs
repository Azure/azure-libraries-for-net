// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Locks.Fluent.Models
{
    /// <summary>
    /// Defines values for LockLevel.
    /// </summary>
    public class LockLevel : ExpandableStringEnum<LockLevel>
    {
        public static readonly LockLevel NotSpecified = Parse("NotSpecified");
        public static readonly LockLevel CanNotDelete = Parse("CanNotDelete");
        public static readonly LockLevel ReadOnly = Parse("ReadOnly");
    }
}
