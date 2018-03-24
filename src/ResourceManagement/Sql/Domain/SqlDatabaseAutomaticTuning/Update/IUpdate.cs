// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update
{
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The update stage setting the database automatic tuning desired state.
    /// </summary>
    public interface IWithAutomaticTuningMode 
    {
        /// <summary>
        /// Sets the SQL database automatic tuning desired state.
        /// </summary>
        /// <param name="desiredState">The server automatic tuning desired state.</param>
        /// <return>Next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update.IUpdate WithAutomaticTuningMode(AutomaticTuningMode desiredState);
    }

    /// <summary>
    /// The template for a SqlDatabaseAutomaticTuning update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update.IWithAutomaticTuningMode,
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update.IWithAutomaticTuningOptions,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning>
    {
    }

    /// <summary>
    /// The update stage setting the database automatic tuning options.
    /// </summary>
    public interface IWithAutomaticTuningOptions 
    {
        /// <summary>
        /// Sets the various SQL database automatic tuning options desired state.
        /// </summary>
        /// <param name="tuningOptionName">Tuning option name (.</param>
        /// <return>Next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update.IUpdate WithAutomaticTuningOption(string tuningOptionName, AutomaticTuningOptionModeDesired desiredState);

        /// <summary>
        /// Sets the various SQL database automatic tuning options desired state.
        /// </summary>
        /// <return>Next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update.IUpdate WithAutomaticTuningOptions(IDictionary<string,Microsoft.Azure.Management.Sql.Fluent.Models.AutomaticTuningOptionModeDesired> tuningOptions);
    }
}