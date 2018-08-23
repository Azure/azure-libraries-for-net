// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Monitor.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    internal class ActionGroupInnerPage :
        Wrapper<IEnumerable<ActionGroupResourceInner>>,
        IPage<ActionGroupResourceInner>
    {
        internal ActionGroupInnerPage(IEnumerable<ActionGroupResourceInner> innerObject)
            : base(innerObject)
        {
        }

        // ther response from the server is supposed to be always singe paged.
        public string NextPageLink => null;

        public IEnumerator<ActionGroupResourceInner> GetEnumerator()
        {
            return this.Inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Inner.GetEnumerator();
        }
    }
}
