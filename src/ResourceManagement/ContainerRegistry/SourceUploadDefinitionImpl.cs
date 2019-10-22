// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for SourceUploadDefinition.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlNvdXJjZVVwbG9hZERlZmluaXRpb25JbXBs
    internal partial class SourceUploadDefinitionImpl  :
        Wrapper<Models.SourceUploadDefinitionInner>,
        ISourceUploadDefinition
    {

        /// <summary>
        /// Creates an instance of the SourceUploadDefinition object.
        /// </summary>
        /// <param name="innerObject">The inner object.</param>
        ///GENMHASH:312084A92014267C3558D9E083E5A37A:C0C35E00AF4E17F141675A2C05C7067B
        internal  SourceUploadDefinitionImpl(SourceUploadDefinitionInner innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:5660FD06F60A4AEEF67A48D5973319D1:25422C84375B5B08165C5F6A3A861C69
        public string RelativePath
        {
            get
            {
                return this.Inner.RelativePath;
            }
        }

        ///GENMHASH:191F71081BADB90876C992118C03DC69:F54BCA700B268D25603524174B8660A4
        public string UploadUrl
        {
            get
            {
                return this.Inner.UploadUrl;
            }
        }
    }
}