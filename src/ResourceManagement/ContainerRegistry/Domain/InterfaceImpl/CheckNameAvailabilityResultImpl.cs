// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class CheckNameAvailabilityResultImpl
    {
        /// <summary>
        /// Gets true if the specified name is valid and available for use, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult.IsAvailable
        {
            get
            {
                return this.IsAvailable();
            }
        }

        /// <summary>
        /// Gets the reason why the user-provided name for the container registry could not be used.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult.UnavailabilityReason
        {
            get
            {
                return this.UnavailabilityReason();
            }
        }

        /// <summary>
        /// Gets the error message that provides more detail for the reason why the name is not available.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.ICheckNameAvailabilityResult.UnavailabilityMessage
        {
            get
            {
                return this.UnavailabilityMessage();
            }
        }
    }
}