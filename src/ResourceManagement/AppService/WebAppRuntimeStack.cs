// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines web app runtime stack on Windows operating system.
    /// </summary>
    public class WebAppRuntimeStack
    {
        public static WebAppRuntimeStack NETCore = new WebAppRuntimeStack("dotnetcore");
        public static WebAppRuntimeStack NET = new WebAppRuntimeStack("dotnet");
        public static WebAppRuntimeStack PHP = new WebAppRuntimeStack("php");
        public static WebAppRuntimeStack Python = new WebAppRuntimeStack("python");
        public static WebAppRuntimeStack Java = new WebAppRuntimeStack("java");

        /// <summary>
        /// The name of the language runtime.
        /// </summary>
        public string Runtime { get; }

        public WebAppRuntimeStack(string runtime)
        {
            Runtime = runtime;
        }

        public override bool Equals(object obj)
        {
            return obj is WebAppRuntimeStack stack &&
                   Runtime == stack.Runtime;
        }

        public override int GetHashCode()
        {
            return -986560893 + EqualityComparer<string>.Default.GetHashCode(Runtime);
        }
    }
}
