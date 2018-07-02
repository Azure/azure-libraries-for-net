// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabaseAutomaticTuning.Update;
    using Microsoft.Rest;
    using System.Collections.Generic;

    internal partial class SqlDatabaseAutomaticTuningImpl 
    {
        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning>.ApplyAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.ApplyAsync(cancellationToken);
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <return>The updated resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning>.Apply()
        {
            return this.Apply();
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlDatabaseAutomaticTuning.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlDatabaseAutomaticTuning.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Sets the SQL database automatic tuning desired state.
        /// </summary>
        /// <param name="desiredState">The server automatic tuning desired state.</param>
        /// <return>Next stage of the update.</return>
        SqlDatabaseAutomaticTuning.Update.IUpdate SqlDatabaseAutomaticTuning.Update.IWithAutomaticTuningMode.WithAutomaticTuningMode(AutomaticTuningMode desiredState)
        {
            return this.WithAutomaticTuningMode(desiredState);
        }

        /// <summary>
        /// Gets the index key.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable.Key
        {
            get
            {
                return this.Key();
            }
        }

        /// <summary>
        /// Gets the database automatic tuning actual state.
        /// </summary>
        Models.AutomaticTuningMode Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning.ActualState
        {
            get
            {
                return this.ActualState();
            }
        }

        /// <summary>
        /// Gets the database automatic tuning desired state.
        /// </summary>
        Models.AutomaticTuningMode Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning.DesiredState
        {
            get
            {
                return this.DesiredState();
            }
        }

        /// <summary>
        /// Gets the database automatic tuning individual options.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.AutomaticTuningOptions> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseAutomaticTuning.TuningOptions
        {
            get
            {
                return this.TuningOptions();
            }
        }

        /// <summary>
        /// Sets the various SQL database automatic tuning options desired state.
        /// </summary>
        /// <param name="tuningOptionName">Tuning option name (.</param>
        /// <return>Next stage of the update.</return>
        SqlDatabaseAutomaticTuning.Update.IUpdate SqlDatabaseAutomaticTuning.Update.IWithAutomaticTuningOptions.WithAutomaticTuningOption(string tuningOptionName, AutomaticTuningOptionModeDesired desiredState)
        {
            return this.WithAutomaticTuningOption(tuningOptionName, desiredState);
        }

        /// <summary>
        /// Sets the various SQL database automatic tuning options desired state.
        /// </summary>
        /// <return>Next stage of the update.</return>
        SqlDatabaseAutomaticTuning.Update.IUpdate SqlDatabaseAutomaticTuning.Update.IWithAutomaticTuningOptions.WithAutomaticTuningOptions(IDictionary<string,Models.AutomaticTuningOptionModeDesired> tuningOptions)
        {
            return this.WithAutomaticTuningOptions(tuningOptions);
        }
    }
}