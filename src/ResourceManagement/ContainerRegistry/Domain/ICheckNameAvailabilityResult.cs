// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The result of checking for container registry name availability.
    /// </summary>
    public interface ICheckNameAvailabilityResult :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.RegistryNameStatusInner>
    {
        /// <summary>
        /// Gets true if the specified name is valid and available for use, otherwise false.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets the error message that provides more detail for the reason why the name is not available.
        /// </summary>
        string UnavailabilityMessage { get; }

        /// <summary>
        /// Gets the reason why the user-provided name for the container registry could not be used.
        /// </summary>
        string UnavailabilityReason { get; }
    }
}