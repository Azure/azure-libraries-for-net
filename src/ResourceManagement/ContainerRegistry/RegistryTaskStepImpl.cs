// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using System.Collections.Generic;

///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5VGFza1N0ZXBJbXBs
    internal abstract partial class RegistryTaskStepImpl  :
        IRegistryTaskStep
    {
        private TaskStepProperties taskStepProperties;

        ///GENMHASH:39EA9CA1E52A8D11B6B555CAAE3A6B10:9FC7DBDE3CAF5AFFBABB6A2843EE1892
        internal  RegistryTaskStepImpl(TaskStepProperties taskStepProperties)
        {
            this.taskStepProperties = taskStepProperties;
        }

        ///GENMHASH:B213094DDD1B5F63A49C0E6FBBE205A0:5A6AA13E080A34479EAA0DABC504C592
        public IReadOnlyList<Models.BaseImageDependency> BaseImageDependencies()
        {
            return new List<Models.BaseImageDependency>(taskStepProperties.BaseImageDependencies);
        }

        ///GENMHASH:0D2C272BD97EF6F86B8E9636D76E9A5D:46B995E29F16DE57286A0A52B88CA158
        public string ContextPath()
        {
            return taskStepProperties.ContextPath;
        }
    }
}