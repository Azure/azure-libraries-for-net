// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure autoscale profile.
    /// </summary>
    public interface IAutoscaleProfile  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.AutoscaleProfileInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Monitor.Fluent.IAutoscaleSetting>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName
    {

        /// <summary>
        /// Gets the number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.
        /// </summary>
        /// <summary>
        /// Gets the defaultProperty value.
        /// </summary>
        int DefaultInstanceCount { get; }

        /// <summary>
        /// Gets the specific date-time for the profile. This element is not used if the Recurrence element is used.
        /// </summary>
        /// <summary>
        /// Gets the fixedDate value.
        /// </summary>
        Models.TimeWindow FixedDateSchedule { get; }

        /// <summary>
        /// Gets the maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.
        /// </summary>
        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        int MaxInstanceCount { get; }

        /// <summary>
        /// Gets the minimum number of instances for the resource.
        /// </summary>
        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        int MinInstanceCount { get; }

        /// <summary>
        /// Gets the repeating times at which this profile begins. This element is not used if the FixedDate element is used.
        /// </summary>
        /// <summary>
        /// Gets the recurrence value.
        /// </summary>
        Models.Recurrence RecurrentSchedule { get; }

        /// <summary>
        /// Gets the collection of rules that provide the triggers and parameters for the scaling action. A maximum of 10 rules can be specified.
        /// </summary>
        /// <summary>
        /// Gets the rules value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Monitor.Fluent.IScaleRule> Rules { get; }
    }
}