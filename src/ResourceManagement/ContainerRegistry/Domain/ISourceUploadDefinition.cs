// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The source repository properties for a build task.
    /// </summary>
    public interface ISourceUploadDefinition  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SourceUploadDefinitionInner>
    {

        /// <summary>
        /// Gets the the relative path to the source; this is used to submit the subsequent queue build request.
        /// </summary>
        string RelativePath { get; }

        /// <summary>
        /// Gets the URL where the client can upload the source.
        /// </summary>
        string UploadUrl { get; }
    }
}