// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A type contains subset of ARM envelop properties in  com.microsoft.azure.Resource namely id, name and type.
    /// </summary>
    public interface INestedResource  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable, 
        IHasId
    {
        /// <summary>
        /// Gets the resource name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        string Type { get; }
    }
}