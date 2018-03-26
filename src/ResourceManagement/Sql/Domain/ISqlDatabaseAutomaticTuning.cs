// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database automatic tuning object.
    /// </summary>
    public interface ISqlDatabaseAutomaticTuning  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DatabaseAutomaticTuningInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlDatabaseAutomaticTuning.Update.IUpdate>
    {
        /// <summary>
        /// Gets the database automatic tuning desired state.
        /// </summary>
        Models.AutomaticTuningMode DesiredState { get; }

        /// <summary>
        /// Gets the database automatic tuning actual state.
        /// </summary>
        Models.AutomaticTuningMode ActualState { get; }

        /// <summary>
        /// Gets the database automatic tuning individual options.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.AutomaticTuningOptions> TuningOptions { get; }
    }
}