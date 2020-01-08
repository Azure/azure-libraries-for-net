// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class TableImpl
    {
        /// <summary>
        /// Gets name of the Cosmos DB Table database
        /// </summary>
        string ITable.TableId
        {
            get
            {
                return this.TableId();
            }
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string ITable._rid
        {
            get
            {
                return this._rid();
            }
        }

        /// <summary>
        /// Gets a system generated property that denotes the last
        /// updated timestamp of the resource.
        /// </summary>
        object ITable._ts
        {
            get
            {
                return this._ts();
            }
        }

        /// <summary>
        /// Gets a system generated property representing the resource
        /// etag required for optimistic concurrency control.
        /// </summary>
        string ITable._etag
        {
            get
            {
                return this._etag();
            }
        }

        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ITable, ICosmosDBAccount>.Id
        {
            get
            {
                return this.Id();
            }
        }

        ThroughputSettingsGetPropertiesResource ITable.GetThroughputSettings()
        {
            return this.GetThroughputSettings();
        }

        Task<ThroughputSettingsGetPropertiesResource> ITable.GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetThroughputSettingsAsync(cancellationToken);
        }

        Table.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<Table.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        Table.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<Table.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        Table.Update.IUpdate HasOptions.Update.IWithOptions<Table.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        Table.Update.IUpdate HasOptions.Update.IWithOptions<Table.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        Table.Update.IUpdate HasOptions.Update.IWithOptions<Table.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        Table.Update.IUpdate HasOptions.Update.IWithOptions<Table.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        Table.Update.IUpdate HasOptions.Update.IWithOptions<Table.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        Table.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasThroughputSettings.Definition.IWithThroughput<Table.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        Table.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<Table.Update.IUpdate>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CosmosDBAccount.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        CosmosDBAccount.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }

        // definition for parent update
        Table.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<Table.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        Table.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasOptions.Definition.IWithOptions<Table.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        Table.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals> HasThroughputSettings.Definition.IWithThroughput<Table.Definition.IWithAttach<CosmosDBAccount.Update.IWithOptionals>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CosmosDBAccount.Update.IWithOptionals Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Update.IWithOptionals>.Attach()
        {
            return this.Attach();
        }
    }
}
