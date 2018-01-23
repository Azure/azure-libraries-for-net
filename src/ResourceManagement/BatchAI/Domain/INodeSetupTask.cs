// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A client-side representation of a mode setup task of a Batch AI cluster.
    /// </summary>
    public interface INodeSetupTask  :
        IBeta,
        IHasInner<Models.SetupTask>,
        IIndexable
    {
    }
}