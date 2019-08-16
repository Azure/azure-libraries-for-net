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
        /// Gets the function App ID.
        /// </summary>
        string FunctionAppId { get; }

        /// <summary>
        /// Gets the script root path URI.
        /// </summary>
        string ScriptRootPathHref { get; }

        /// <summary>
        /// Gets the script URI.
        /// </summary>
        string ScriptHref { get; }

        /// <summary>
        /// Gets the config URI.
        /// </summary>
        string ConfigHref { get; }

        /// <summary>
        /// Gets the secrets file URI.
        /// </summary>
        string SecretsFileHref { get; }

        /// <summary>
        /// Gets the function URI.
        /// </summary>
        string Href { get; }

        /// <summary>
        /// Gets the config information.
        /// </summary>
        object Config { get; }

        /// <summary>
        /// Gets the file list.
        /// </summary>
        IReadOnlyDictionary<string, string> Files { get; }

        /// <summary>
        /// Gets the test data used when testing via the Azure Portal.
        /// </summary>
        string TestData { get; }
    }
}
