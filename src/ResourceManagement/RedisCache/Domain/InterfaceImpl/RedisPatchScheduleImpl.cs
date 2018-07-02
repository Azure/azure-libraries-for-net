// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RedisPatchScheduleImpl 
    {
        /// <summary>
        /// Gets the scheduleEntries value.
        /// </summary>
        /// <summary>
        /// Gets the scheduleEntries value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.ScheduleEntry> Models.IRedisPatchSchedule.ScheduleEntries
        {
            get
            {
                return this.ScheduleEntries();
            }
        }
    }
}