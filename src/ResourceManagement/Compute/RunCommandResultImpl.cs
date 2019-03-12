// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Collections.Generic;
    using Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Tenant.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRG9tYWluTGVnYWxBZ3JlZW1lbnRJbXBs
    internal sealed partial class RunCommandResultImpl :
        Wrapper<RunCommandResultInner>,
        IRunCommandResult
    {
        internal RunCommandResultImpl(RunCommandResultInner inner)
            : base(inner)
        {
        }

        public IList<InstanceViewStatus> Value()
        {
            return Inner.Value;
        }
    }
}