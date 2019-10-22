// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.Definition;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKeyOperations.SqlServerKeyOperationsDefinition;
    using System;

    internal partial class SqlServerKeyImpl 
    {
        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Sets the server key creation date.
        /// </summary>
        /// <param name="creationDate">The server key creation date.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKey.Update.IUpdate SqlServerKey.Update.IWithCreationDate.WithCreationDate(DateTime creationDate)
        {
            return this.WithCreationDate(creationDate);
        }

        /// <summary>
        /// Sets the server key creation date.
        /// </summary>
        /// <param name="creationDate">The server key creation date.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKeyOperations.Definition.IWithCreate SqlServerKeyOperations.Definition.IWithCreationDate.WithCreationDate(DateTime creationDate)
        {
            return this.WithCreationDate(creationDate);
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Sets the parent SQL server for the new Server Key.
        /// </summary>
        /// <param name="sqlServerId">The parent SQL server ID.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKeyOperations.Definition.IWithServerKeyType SqlServerKeyOperations.Definition.IWithSqlServer.WithExistingSqlServerId(string sqlServerId)
        {
            return this.WithExistingSqlServerId(sqlServerId);
        }

        /// <summary>
        /// Sets the parent SQL server name and resource group it belongs to.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the parent SQL server.</param>
        /// <param name="sqlServerName">The parent SQL server name.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKeyOperations.Definition.IWithServerKeyType SqlServerKeyOperations.Definition.IWithSqlServer.WithExistingSqlServer(string resourceGroupName, string sqlServerName)
        {
            return this.WithExistingSqlServer(resourceGroupName, sqlServerName);
        }

        /// <summary>
        /// Sets the parent SQL server for the new Server Key.
        /// </summary>
        /// <param name="sqlServer">The parent SQL server.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKeyOperations.Definition.IWithServerKeyType SqlServerKeyOperations.Definition.IWithSqlServer.WithExistingSqlServer(ISqlServer sqlServer)
        {
            return this.WithExistingSqlServer(sqlServer);
        }

        /// <summary>
        /// Sets the thumbprint of the server key.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the server key.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKey.Update.IUpdate SqlServerKey.Update.IWithThumbprint.WithThumbprint(string thumbprint)
        {
            return this.WithThumbprint(thumbprint);
        }

        /// <summary>
        /// Sets the thumbprint of the server key.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the server key.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKeyOperations.Definition.IWithCreate SqlServerKeyOperations.Definition.IWithThumbprint.WithThumbprint(string thumbprint)
        {
            return this.WithThumbprint(thumbprint);
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlServerKey.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlServerKey.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Gets the server key creation date.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <summary>
        /// Gets the resource location.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the URI of the server key.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.Uri
        {
            get
            {
                return this.Uri();
            }
        }

        /// <summary>
        /// Gets the kind of encryption protector; this is metadata used for the Azure Portal experience.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Gets the thumbprint of the server key.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.Thumbprint
        {
            get
            {
                return this.Thumbprint();
            }
        }

        /// <summary>
        /// Gets the server key type.
        /// </summary>
        Models.ServerKeyType Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.ServerKeyType
        {
            get
            {
                return this.ServerKeyType();
            }
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this DNS alias belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Deletes the DNS alias.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Deletes the DNS alias asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey.DeleteAsync(CancellationToken cancellationToken)
        {
 
            await this.DeleteAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Sets the server key type as "AzureKeyVault" and the URI to the key.
        /// </summary>
        /// <param name="uri">The URI of the server key.</param>
        /// <return>The next stage of the definition.</return>
        SqlServerKeyOperations.Definition.IWithCreate SqlServerKeyOperations.Definition.IWithServerKeyType.WithAzureKeyVaultKey(string uri)
        {
            return this.WithAzureKeyVaultKey(uri);
        }
    }
}