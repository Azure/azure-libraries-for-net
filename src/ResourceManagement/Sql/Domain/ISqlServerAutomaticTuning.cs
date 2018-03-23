// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server automatic tuning object.
    /// </summary>
    public interface ISqlServerAutomaticTuning  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ServerAutomaticTuningInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlServerAutomaticTuning.Update.IUpdate>
    {
        /// <summary>
        /// Gets the server automatic tuning desired state.
        /// </summary>
        Models.AutomaticTuningServerMode DesiredState { get; }

        /// <summary>
        /// Gets the server automatic tuning actual state.
        /// </summary>
        Models.AutomaticTuningServerMode ActualState { get; }

        /// <summary>
        /// Gets the server automatic tuning individual options.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.AutomaticTuningServerOptions> TuningOptions { get; }
    }
}