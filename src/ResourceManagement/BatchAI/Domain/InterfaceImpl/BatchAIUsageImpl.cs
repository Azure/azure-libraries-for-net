// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class BatchAIUsageImpl 
    {
        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        int Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the
        /// subscription.
        /// </summary>
        long Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <summary>
        /// Gets the name of the type of usage.
        /// </summary>
        Microsoft.Azure.Management.BatchAI.Fluent.Models.UsageName Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the unit of usage measurement.
        /// </summary>
        UsageUnit Microsoft.Azure.Management.BatchAI.Fluent.IBatchAIUsage.Unit
        {
            get
            {
                return this.Unit();
            }
        }
    }
}