// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerAutomaticTuning.Update;
    using Microsoft.Rest;
    using System.Collections.Generic;

    internal partial class SqlServerAutomaticTuningImpl 
    {
        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlServerAutomaticTuning.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlServerAutomaticTuning.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        async Task<Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning>.ApplyAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.ApplyAsync(cancellationToken);
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <return>The updated resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning>.Apply()
        {
            return this.Apply();
        }

        /// <summary>
        /// Sets the SQL server automatic tuning desired state.
        /// </summary>
        /// <param name="desiredState">The server automatic tuning desired state.</param>
        /// <return>Next stage of the update.</return>
        SqlServerAutomaticTuning.Update.IUpdate SqlServerAutomaticTuning.Update.IWithAutomaticTuningMode.WithAutomaticTuningMode(AutomaticTuningServerMode desiredState)
        {
            return this.WithAutomaticTuningMode(desiredState);
        }

        /// <summary>
        /// Gets the server automatic tuning actual state.
        /// </summary>
        Models.AutomaticTuningServerMode Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning.ActualState
        {
            get
            {
                return this.ActualState();
            }
        }

        /// <summary>
        /// Gets the server automatic tuning desired state.
        /// </summary>
        Models.AutomaticTuningServerMode Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning.DesiredState
        {
            get
            {
                return this.DesiredState();
            }
        }

        /// <summary>
        /// Gets the server automatic tuning individual options.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.AutomaticTuningServerOptions> Microsoft.Azure.Management.Sql.Fluent.ISqlServerAutomaticTuning.TuningOptions
        {
            get
            {
                return this.TuningOptions();
            }
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
        /// Sets the various SQL server automatic tuning options desired state.
        /// </summary>
        /// <param name="tuningOptionName">Tuning option name (.</param>
        /// <return>Next stage of the update.</return>
        SqlServerAutomaticTuning.Update.IUpdate SqlServerAutomaticTuning.Update.IWithAutomaticTuningOptions.WithAutomaticTuningOption(string tuningOptionName, AutomaticTuningOptionModeDesired desiredState)
        {
            return this.WithAutomaticTuningOption(tuningOptionName, desiredState);
        }

        /// <summary>
        /// Sets the various SQL server automatic tuning options desired state.
        /// </summary>
        /// <return>Next stage of the update.</return>
        SqlServerAutomaticTuning.Update.IUpdate SqlServerAutomaticTuning.Update.IWithAutomaticTuningOptions.WithAutomaticTuningOptions(IDictionary<string,Models.AutomaticTuningOptionModeDesired> tuningOptions)
        {
            return this.WithAutomaticTuningOptions(tuningOptions);
        }
    }
}