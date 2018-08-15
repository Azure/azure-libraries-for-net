// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAIJob.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings;
    using Microsoft.Azure.Management.BatchAI.Fluent.Models.OutputDirectorySettings.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    internal partial class OutputDirectorySettingsImpl 
    {
        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        BatchAIJob.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<BatchAIJob.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <param name="pathPrefix">Path prefix.</param>
        /// <return>The next stage of the definition.</return>
        Models.OutputDirectorySettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> Models.OutputDirectorySettings.Definition.IWithPathPrefix<BatchAIJob.Definition.IWithCreate>.WithPathPrefix(string pathPrefix)
        {
            return this.WithPathPrefix(pathPrefix);
        }

        /// <param name="pathSuffix">Path prefix.</param>
        /// <return>The next stage of the definition.</return>
        Models.OutputDirectorySettings.Definition.IWithAttach<BatchAIJob.Definition.IWithCreate> Models.OutputDirectorySettings.Definition.IWithPathSuffix<BatchAIJob.Definition.IWithCreate>.WithPathSuffix(string pathSuffix)
        {
            return this.WithPathSuffix(pathSuffix);
        }
    }
}