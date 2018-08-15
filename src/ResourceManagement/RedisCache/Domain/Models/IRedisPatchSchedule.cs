// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent.Models
{
    using Microsoft.Azure.Management.Redis.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The Azure Redis Patch Schedule entries are of type ScheduleEntry.
    /// </summary>
    public interface IRedisPatchSchedule  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.Redis.Fluent.Models.IRedisPatchSchedule,Microsoft.Azure.Management.Redis.Fluent.IRedisCache>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Redis.Fluent.Models.RedisPatchScheduleInner>
    {

        /// <summary>
        /// Gets the scheduleEntries value.
        /// </summary>
        /// <summary>
        /// Gets the scheduleEntries value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Redis.Fluent.Models.ScheduleEntry> ScheduleEntries { get; }
    }
}