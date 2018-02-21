// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

/**namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal abstract partial class NestedResourceImpl<FluentModelT,InnerModelT,FluentModelImplT> 
    {
        /// <summary>
        /// Gets the resource name.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.INestedResource.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.INestedResource.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Gets resource id.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.INestedResource.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Management.EventHub.Fluent.EventHubManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Management.EventHub.Fluent.EventHubManager>.Manager
        {
            get
            {
                return this.Manager() as Management.EventHub.Fluent.EventHubManager;
            }
        }
    }
}
**/