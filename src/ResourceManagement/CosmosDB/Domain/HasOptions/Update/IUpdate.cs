// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.HasOptions.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The stage of a resource update allowing to set options.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the update.</typeparam>
    public interface IWithOptions<ReturnT>
    {
        /// <summary>
        /// Specifies an option.
        /// </summary>
        /// <param name="key">The key of the option. Supported keys are "If-Match", "If-None-Match", "Session-Token" and "Throughput" in api-version 2019-08-01.</param>
        /// <param name="value">The value of the option.</param>
        /// <returns>The next stage of update.</returns>
        ReturnT WithOption(string key, string value);

        /// <summary>
        /// Appends all options to current options.
        /// </summary>
        /// <param name="options">The options needs appending.</param>
        /// <returns>The next stage of update.</returns>
        ReturnT WithOptionsAppend(IDictionary<string, string> options);

        /// <summary>
        /// Replace the current options with new options.
        /// </summary>
        /// <param name="options">The options needs replacing.</param>
        /// <returns>The next stage of update.</returns>
        ReturnT WithOptionsReplace(IDictionary<string, string> options);

        /// <summary>
        /// Removes an option.
        /// </summary>
        /// <param name="key">The key of the option.</param>
        /// <returns>The next stage of update.</returns>
        ReturnT WithoutOption(string key);

        /// <summary>
        /// Removes all options.
        /// </summary>
        /// <returns>The next stage of update.</returns>
        ReturnT WithoutOptions();
    }
}
