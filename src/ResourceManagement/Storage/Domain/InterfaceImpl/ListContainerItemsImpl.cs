// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Collections.Generic;

    public partial class ListContainerItemsImpl 
    {
        /// <summary>
        /// Gets the value value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<ListContainerItem> Microsoft.Azure.Management.Storage.Fluent.IListContainerItems.Value
        {
            get
            {
                return this.Value();
            }
        }
    }
}