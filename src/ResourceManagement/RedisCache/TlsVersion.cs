// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Defines values for TlsVersion.
    /// </summary>
    public sealed partial class TlsVersion : ExpandableStringEnum<TlsVersion>
    {
        public static readonly TlsVersion OneFullStopZero = Parse("1.0");
        public static readonly TlsVersion OneFullStopOne = Parse("1.1");
        public static readonly TlsVersion OneFullStopTwo = Parse("1.2");
    }
}
