// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure Batch AI resource usage info object.
    /// </summary>
    public interface IBatchAIUsage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.BatchAI.Fluent.Models.UsageInner>
    {

        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        int CurrentValue { get; }

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the
        /// subscription.
        /// </summary>
        long Limit { get; }

        /// <summary>
        /// Gets the name of the type of usage.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.UsageName Name { get; }

        /// <summary>
        /// Gets the unit of usage measurement.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.UsageUnit Unit { get; }
    }
}