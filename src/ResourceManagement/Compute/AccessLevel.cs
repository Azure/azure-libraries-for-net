// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for AccessLevel.
    /// </summary>
    public class AccessLevel : ExpandableStringEnum<AccessLevel>
    {
        public static readonly AccessLevel None = Parse("None");
        public static readonly AccessLevel Read = Parse("Read");
    }
}
