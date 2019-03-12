// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure Virtual Machine Instance View.
    /// </summary>
    public interface IRunCommandResult :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.RunCommandResultInner>
    {
        /// <summary>
        /// Gets run command operation response.
        /// </summary>
        IList<InstanceViewStatus> Value { get; }
    }
}