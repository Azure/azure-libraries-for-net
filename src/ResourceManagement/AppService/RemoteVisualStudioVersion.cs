// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    /// <summary>
    /// Defines values for RemoteVisualStudioVersion.
    /// </summary>
    public class RemoteVisualStudioVersion : ExpandableStringEnum<RemoteVisualStudioVersion>
    {
        [Obsolete]
        public static readonly RemoteVisualStudioVersion VS2012 = Parse("VS2012");
        [Obsolete]
        public static readonly RemoteVisualStudioVersion VS2013 = Parse("VS2013");
        [Obsolete]
        public static readonly RemoteVisualStudioVersion VS2015 = Parse("VS2015");

        public static readonly RemoteVisualStudioVersion VS2017 = Parse("VS2017");
        public static readonly RemoteVisualStudioVersion VS2019 = Parse("VS2019");
    }
}
