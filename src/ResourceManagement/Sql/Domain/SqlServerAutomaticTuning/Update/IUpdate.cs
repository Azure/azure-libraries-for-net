// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update
{
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The update stage setting the server automatic tuning options.
    /// </summary>
    public interface IWithAutomaticTuningOptions 
    {
        /// <summary>
        /// Sets the various SQL server automatic tuning options desired state.
        /// </summary>
        /// <param name="tuningOptionName">Tuning option name (.</param>
        /// <return>Next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update.IUpdate WithAutomaticTuningOption(string tuningOptionName, AutomaticTuningOptionModeDesired desiredState);

        /// <summary>
        /// Sets the various SQL server automatic tuning options desired state.
        /// </summary>
        /// <return>Next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update.IUpdate WithAutomaticTuningOptions(IDictionary<string,Microsoft.Azure.Management.Sql.Fluent.Models.AutomaticTuningOptionModeDesired> tuningOptions);
    }

    /// <summary>
    /// The update stage setting the SQL server automatic tuning desired state.
    /// </summary>
    public interface IWithAutomaticTuningMode 
    {
        /// <summary>
        /// Sets the SQL server automatic tuning desired state.
        /// </summary>
        /// <param name="desiredState">The server automatic tuning desired state.</param>
        /// <return>Next stage of the update.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update.IUpdate WithAutomaticTuningMode(AutomaticTuningServerMode desiredState);
    }

    /// <summary>
    /// The template for a SqlServerAutomaticTuning update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update.IWithAutomaticTuningMode,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update.IWithAutomaticTuningOptions,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning>
    {
    }
}