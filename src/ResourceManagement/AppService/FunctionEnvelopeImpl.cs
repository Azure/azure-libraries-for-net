// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal partial class FunctionEnvelopeImpl :
        Wrapper<Models.FunctionEnvelopeInner>,
        IFunctionEnvelope
    {
        internal FunctionEnvelopeImpl(Models.FunctionEnvelopeInner innerObject)
            : base(innerObject)
        {
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public string Name()
        {
            return this.Inner.Name;
        }

        public string Type()
        {
            return this.Inner.Type;
        }

        public Region Region()
        {
            return ResourceManager.Fluent.Core.Region.Create(this.RegionName());
        }

        public string RegionName()
        {
            return this.Inner.Location;
        }

        public string FunctionAppId()
        {
            return this.Inner.FunctionAppId;
        }

        public string ScriptRootPathHref()
        {
            return this.Inner.ScriptRootPathHref;
        }

        public string ScriptHref()
        {
            return this.Inner.ScriptHref;
        }

        public string ConfigHref()
        {
            return this.Inner.ConfigHref;
        }

        public string SecretsFileHref()
        {
            return this.Inner.SecretsFileHref;
        }

        public string Href()
        {
            return this.Inner.Href;
        }

        public object Config()
        {
            return this.Inner.Config;
        }

        public IReadOnlyDictionary<string, string> Files()
        {
            return new ReadOnlyDictionary<string, string>(this.Inner.Files == null ? new Dictionary<string, string>() : this.Inner.Files);
        }

        public string TestData()
        {
            return this.Inner.TestData;
        }
    }
}
