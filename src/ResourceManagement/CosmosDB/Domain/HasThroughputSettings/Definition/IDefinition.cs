// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.HasThroughputSettings.Definition
{
    /// <summary>
    /// The stage of a resource definition allowing to set throughput.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithThroughput<ReturnT>
    {
        /// <summary>
        /// Specifies the throughput value.
        /// </summary>
        /// <param name="throughput">The vaule of the throughput.</param>
        /// <returns>The next stage of the definition.</returns>
        ReturnT WithThroughput(int throughput);
    }
}
