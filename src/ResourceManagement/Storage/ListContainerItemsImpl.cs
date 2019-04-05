// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;

    public partial class ListContainerItemsImpl  :
        Wrapper<ListContainerItemsInner>,
        IListContainerItems
    {
        private StorageManager manager;

                internal  ListContainerItemsImpl(ListContainerItemsInner inner, StorageManager manager) : base(inner)
        {
            //$ super(inner);
            //$ this.manager = manager;
            //$ }

        }

        StorageManager IHasManager<StorageManager>.Manager => this.manager;

        public StorageManager Manager()
        {
            //$ return this.manager;

            return null;
        }

                public IReadOnlyList<ListContainerItem> Value()
        {
            //$ return this.Inner().Value();

            return null;
        }
    }
}