// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;

    public partial class LegalHoldImpl  :
        Wrapper<LegalHoldInner>,
        ILegalHold
    {
        private StorageManager manager;

        internal  LegalHoldImpl(LegalHoldInner inner, StorageManager manager) : base(inner)
        {
            this.manager = manager;
        }

        StorageManager IHasManager<StorageManager>.Manager => this.manager;

        public bool? HasLegalHold()
        {
            return this.Inner.HasLegalHold;
        }

        public StorageManager Manager()
        {
            return this.manager;
        }

        public IReadOnlyList<string> Tags()
        {
            List<string> tagsList = this.Inner.Tags as List<string>;
            return tagsList.AsReadOnly();
        }
    }
}