// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    public interface IFunctionEnvelope :
        IBeta,
        IHasId,
        IHasName,
        IHasInner<Models.FunctionEnvelopeInner>
    {
        /// <summary>
        /// Gets the type of the resource
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the region of the resource
        /// </summary>
        Region Region { get; }

        /// <summary>
        /// Gets the region name of the resource
        /// </summary>
        string RegionName { get; }

        /// <summary>
        /// Gets or sets function App ID.
        /// </summary>
        string FunctionAppId { get; }

        /// <summary>
        /// Gets or sets script root path URI.
        /// </summary>
        string ScriptRootPathHref { get; }

        /// <summary>
        /// Gets or sets script URI.
        /// </summary>
        string ScriptHref { get; }

        /// <summary>
        /// Gets or sets config URI.
        /// </summary>
        string ConfigHref { get; }

        /// <summary>
        /// Gets or sets secrets file URI.
        /// </summary>
        string SecretsFileHref { get; }

        /// <summary>
        /// Gets or sets function URI.
        /// </summary>
        string Href { get; }

        /// <summary>
        /// Gets or sets config information.
        /// </summary>
        object Config { get; }

        /// <summary>
        /// Gets or sets file list.
        /// </summary>
        IDictionary<string, string> Files { get; }

        /// <summary>
        /// Gets or sets test data used when testing via the Azure Portal.
        /// </summary>
        string TestData { get; }
    }
}
