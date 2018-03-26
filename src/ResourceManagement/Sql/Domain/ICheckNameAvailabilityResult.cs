// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// The result of checking for the SQL server name availability.
    /// </summary>
    public interface ICheckNameAvailabilityResult  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.CheckNameAvailabilityResponseInner>
    {
        /// <summary>
        /// Gets true if the specified name is valid and available for use, otherwise false.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets the reason why the user-provided name for the SQL server could not be used.
        /// </summary>
        string UnavailabilityReason { get; }

        /// <summary>
        /// Gets the error message that provides more detail for the reason why the name is not available.
        /// </summary>
        string UnavailabilityMessage { get; }
    }
}