// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.CosmosDB.Fluent.Domain.SqlDatabase.Update
{
    /// <summary>
    /// The entirety of sql database update as a part of parent cosmos db account update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>,
        IWithOptions,
        IWithThroughput
    {
    }

    /// <summary>
    /// The stage of the sql database update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the sql database update allowing to set throughput.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }
}
