// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtector.Update;

    internal partial class SqlEncryptionProtectorImpl 
    {
        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        SqlEncryptionProtector.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlEncryptionProtector.Update.IUpdate>.Update()
        {
            return this.Update();
        }

        /// <summary>
        /// Gets the resource location.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the name of the server key.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.ServerKeyName
        {
            get
            {
                return this.ServerKeyName();
            }
        }

        /// <summary>
        /// Gets the URI of the server key.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.Uri
        {
            get
            {
                return this.Uri();
            }
        }

        /// <summary>
        /// Gets the kind of encryption protector; this is metadata used for the Azure Portal experience.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Gets thumbprint of the server key.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.Thumbprint
        {
            get
            {
                return this.Thumbprint();
            }
        }

        /// <summary>
        /// Gets the encryption protector type.
        /// </summary>
        Models.ServerKeyType Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.ServerKeyType
        {
            get
            {
                return this.ServerKeyType();
            }
        }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.ParentId
        {
            get
            {
                return this.ParentId();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this DNS alias belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

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
        /// Updates the Encryption Protector to use an AzureKeyVault server key.
        /// </summary>
        /// <param name="serverKeyName">The server key name.</param>
        /// <return>The next stage of the definition.</return>
        SqlEncryptionProtector.Update.IUpdate SqlEncryptionProtector.Update.IWithServerKeyNameAndType.WithAzureKeyVaultServerKey(string serverKeyName)
        {
            return this.WithAzureKeyVaultServerKey(serverKeyName);
        }

        /// <summary>
        /// Updates the Encryption Protector to use the default service managed server key.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlEncryptionProtector.Update.IUpdate SqlEncryptionProtector.Update.IWithServerKeyNameAndType.WithServiceManagedServerKey()
        {
            return this.WithServiceManagedServerKey();
        }
    }
}