// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class CheckNameAvailabilityResultImpl 
    {
        /// <summary>
        /// Gets true if the specified name is valid and available for use, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult.IsAvailable
        {
            get
            {
                return this.IsAvailable();
            }
        }

        /// <summary>
        /// Gets the reason why the user-provided name for the SQL server could not be used.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult.UnavailabilityReason
        {
            get
            {
                return this.UnavailabilityReason();
            }
        }

        /// <summary>
        /// Gets the error message that provides more detail for the reason why the name is not available.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ICheckNameAvailabilityResult.UnavailabilityMessage
        {
            get
            {
                return this.UnavailabilityMessage();
            }
        }
    }
}