// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class FunctionEnvelopeImpl
    {
        string IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        string IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <returns>the type of the resource</returns>
        string IFunctionEnvelope.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <returns>the region the resource is in</returns>
        Region IFunctionEnvelope.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <returns>the name of the region the resource is in</returns>
        string IFunctionEnvelope.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets or sets function App ID.
        /// </summary>
        /// <returns>the type of the resource</returns>
        string IFunctionEnvelope.FunctionAppId
        {
            get
            {
                return this.FunctionAppId();
            }
        }

        /// <summary>
        /// Gets or sets script root path URI.
        /// </summary>
        string IFunctionEnvelope.ScriptRootPathHref
        {
            get
            {
                return this.ScriptRootPathHref();
            }
        }

        /// <summary>
        /// Gets or sets script URI.
        /// </summary>
        string IFunctionEnvelope.ScriptHref
        {
            get
            {
                return this.ScriptHref();
            }
        }

        /// <summary>
        /// Gets or sets config URI.
        /// </summary>
        string IFunctionEnvelope.ConfigHref
        {
            get
            {
                return this.ConfigHref();
            }
        }

        /// <summary>
        /// Gets or sets secrets file URI.
        /// </summary>
        string IFunctionEnvelope.SecretsFileHref
        {
            get
            {
                return this.SecretsFileHref();
            }
        }

        /// <summary>
        /// Gets or sets function URI.
        /// </summary>
        string IFunctionEnvelope.Href
        {
            get
            {
                return this.Href();
            }
        }

        /// <summary>
        /// Gets or sets config information.
        /// </summary>
        object IFunctionEnvelope.Config
        {
            get
            {
                return this.Config();
            }
        }

        /// <summary>
        /// Gets or sets file list.
        /// </summary>
        IDictionary<string, string> IFunctionEnvelope.Files
        {
            get
            {
                return this.Files();
            }
        }

        /// <summary>
        /// Gets or sets test data used when testing via the Azure Portal.
        /// </summary>
        string IFunctionEnvelope.TestData
        {
            get
            {
                return this.TestData();
            }
        }
    }
}
